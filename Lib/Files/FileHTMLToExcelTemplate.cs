using HtmlAgilityPack;
using System.Text;
using System.Text.Json;

namespace DMS.Lib.Files;

/// <summary>
/// Imports values edited in the supported HTML form into the original XLSX
/// template. The workbook remains the layout source, so merge cells, pictures,
/// formulas, styles and print settings are preserved by FileExcelAPI.
/// </summary>
public static class FileHTMLToExcelTemplate
{
    public static string ExportHtmlToExcel(
        string htmlPath,
        string templatePath,
        string outputPath,
        string signType,
        string userFullName)
    {
        if (!File.Exists(htmlPath))
            throw new FileNotFoundException("Không tìm thấy file HTML đã render.", htmlPath);

        if (!File.Exists(templatePath))
            throw new FileNotFoundException(
                $"Không tìm thấy template Excel gốc để giữ nguyên form: {templatePath}",
                templatePath);

        var extension = Path.GetExtension(templatePath).ToLowerInvariant();
        if (extension is not (".xlsx" or ".xlsm" or ".xltx"))
            throw new InvalidOperationException(
                "HTML-to-XLSX chỉ hỗ trợ template OpenXML .xlsx, .xlsm hoặc .xltx.");

        var document = HtmlTableParser.LoadDocument(File.ReadAllText(htmlPath, Encoding.UTF8));
        var bindings = ReadBindings(document);
        var outputDirectory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        var temporaryFiles = bindings.TemporaryFiles;
        try
        {
            var outputFileName = Path.GetFileNameWithoutExtension(outputPath);
            return FileExcelAPI.ExportTemplateToExcel(
                templatePath,
                outputDirectory ?? Directory.GetCurrentDirectory(),
                outputFileName,
                JsonSerializer.Serialize(bindings.Scalars),
                signType,
                JsonSerializer.Serialize(bindings.TableRows),
                userFullName,
                clearUnresolvedPlaceholders: false,
                preserveUnsignedSignatures: true,
                preserveMissingValues: false);
        }
        finally
        {
            foreach (var temporaryFile in temporaryFiles)
            {
                try
                {
                    if (File.Exists(temporaryFile))
                        File.Delete(temporaryFile);
                }
                catch
                {
                    // A temporary imported image must not hide the export result.
                }
            }
        }
    }

    private static ImportBindings ReadBindings(HtmlDocument document)
    {
        var nodes = document.DocumentNode.SelectNodes("//*[@data-excel-field]");
        if (nodes == null || nodes.Count == 0)
        {
            throw new InvalidOperationException(
                "HTML không có metadata data-excel-field để map ngược vào template Excel.");
        }

        var result = new ImportBindings();
        var tableRows = new List<TableRowBinding>();

        foreach (var node in nodes)
        {
            var field = node.GetAttributeValue("data-excel-field", string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(field))
                continue;

            var key = field.StartsWith("@", StringComparison.Ordinal)
                ? field
                : "@" + field;
            var cell = node.Ancestors("td").FirstOrDefault() ?? node.Ancestors("th").FirstOrDefault();
            var tableType = cell?.GetAttributeValue("data-excel-table", string.Empty).Trim();
            var row = node.Ancestors("tr").FirstOrDefault();
            var value = ReadNodeValue(node, key, result.TemporaryFiles);

            if (!string.IsNullOrWhiteSpace(tableType) && row != null)
            {
                var tableRow = tableRows.FirstOrDefault(candidate =>
                    candidate.TableType.Equals(tableType, StringComparison.OrdinalIgnoreCase) &&
                    ReferenceEquals(candidate.Row, row));
                if (tableRow == null)
                {
                    tableRow = new TableRowBinding(tableType, row);
                    tableRows.Add(tableRow);
                }

                SetValue(tableRow.Values, key, value);
                continue;
            }

            SetValue(result.Scalars, key, value);
        }

        result.TableRows.AddRange(tableRows.Select(row => row.Values));
        return result;
    }

    private static string ReadNodeValue(
        HtmlNode node,
        string key,
        ICollection<string> temporaryFiles)
    {
        if (node.Name.Equals("img", StringComparison.OrdinalIgnoreCase))
        {
            if (!HtmlTableParser.TryReadDataImage(node, out var bytes, out var mimeType))
            {
                throw new InvalidOperationException(
                    $"Ảnh của {key} trong HTML phải là data:image/...;base64 để nhập lại Excel.");
            }

            var extension = mimeType.ToLowerInvariant() switch
            {
                "image/svg+xml" => ".svg",
                "image/jpeg" or "image/jpg" => ".jpg",
                "image/gif" => ".gif",
                "image/bmp" => ".bmp",
                "image/webp" => ".webp",
                _ => ".png"
            };
            var temporaryFile = Path.Combine(
                Path.GetTempPath(),
                "nlt-html-import-" + Guid.NewGuid().ToString("N") + extension);
            File.WriteAllBytes(temporaryFile, bytes);
            temporaryFiles.Add(temporaryFile);
            return temporaryFile;
        }

        return HtmlTableParser.GetText(node);
    }

    private static void SetValue(
        IDictionary<string, object> target,
        string key,
        string value)
    {
        if (!target.TryGetValue(key, out var existing))
        {
            target[key] = value;
            return;
        }

        var existingText = existing?.ToString() ?? string.Empty;
        if (IsPlaceholder(existingText, key) && !IsPlaceholder(value, key))
            target[key] = value;
    }

    private static bool IsPlaceholder(string value, string key)
    {
        return value.Trim().Equals(key, StringComparison.OrdinalIgnoreCase);
    }

    private sealed class ImportBindings
    {
        public Dictionary<string, object> Scalars { get; } =
            new(StringComparer.OrdinalIgnoreCase);

        public List<Dictionary<string, object>> TableRows { get; } = new();

        public List<string> TemporaryFiles { get; } = new();
    }

    private sealed class TableRowBinding
    {
        public TableRowBinding(string tableType, HtmlNode row)
        {
            TableType = tableType;
            Row = row;
        }

        public string TableType { get; }

        public HtmlNode Row { get; }

        public Dictionary<string, object> Values { get; } =
            new(StringComparer.OrdinalIgnoreCase);
    }
}
