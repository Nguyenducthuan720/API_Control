using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DMS.Lib.Files;

/// <summary>Fills a selected HTML template with the procedure's JSON, without database access.</summary>
public static class FileHTML
{
    public static string ExportTemplateToHtml(
        string templatePath, string outputFolder, string outputFileName,
        string jsonReplacements, string signType, string tablejson, string userFullName,
        HandlebarsHtmlRenderer renderer)
    {
        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Không tìm thấy file template: {templatePath}");

        var extension = Path.GetExtension(templatePath).ToLowerInvariant();
        if (extension is ".xlsx" or ".xlsm" or ".xltx")
        {
            var workbookPath = FileExcelAPI.ExportTemplateToExcel(
                templatePath,
                outputFolder,
                outputFileName,
                jsonReplacements,
                signType,
                tablejson,
                userFullName,
                clearUnresolvedPlaceholders: false,
                preserveUnsignedSignatures: true,
                preserveMissingValues: true);

            var workbookHtml = FileExcelToHtml.ConvertWorkbookToHtml(workbookPath);
            Directory.CreateDirectory(outputFolder);
            var workbookOutput = Path.Combine(outputFolder, outputFileName + ".html");
            File.WriteAllText(workbookOutput, workbookHtml, new UTF8Encoding(false));
            return workbookOutput;
        }

        if (extension is not (".html" or ".htm" or ".hbs" or ".handlebars"))
            throw new InvalidOperationException("Template HTML phải là .html, .htm, .hbs, .handlebars hoặc workbook OpenXML.");

        var source = File.ReadAllText(templatePath, Encoding.UTF8);
        var html = RenderTemplate(source, jsonReplacements, signType, tablejson, renderer, userFullName);
        Directory.CreateDirectory(outputFolder);
        var output = Path.Combine(outputFolder, outputFileName + ".html");
        File.WriteAllText(output, html, new UTF8Encoding(false));
        return output;
    }

    public static string RenderTemplate(string source, string jsonReplacements, string signType,
        string tablejson, HandlebarsHtmlRenderer renderer, string userFullName = "")
    {
        const string base64Prefix = "data:text/html;base64,";
        if (source.TrimStart().StartsWith(base64Prefix, StringComparison.OrdinalIgnoreCase))
            source = Encoding.UTF8.GetString(Convert.FromBase64String(source.Trim()[base64Prefix.Length..]));

        // Translate template tokens before rendering; never rescan inserted data.
        const string pattern = @"(?<![\w{])@[A-Za-z_][A-Za-z0-9_]*";
        var tokens = Regex.Matches(source, pattern)
            .Select(m => m.Value).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        tokens.AddRange(Regex.Matches(source, @"\{\{\s*([A-Za-z_][A-Za-z0-9_]*)\s*\}\}")
            .Select(m => "@" + m.Groups[1].Value));
        var values = JsonSerializer.Deserialize<Dictionary<string, object>>(
            string.IsNullOrWhiteSpace(jsonReplacements) ? "{}" : jsonReplacements)
            ?? new Dictionary<string, object>();
        var model = MakeModel(values, tokens);
        foreach (var key in values.Keys.Where(k => k.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase)))
        {
            var path = values[key]?.ToString();
            if (string.IsNullOrWhiteSpace(path)) continue;
            if (!File.Exists(path)) throw new FileNotFoundException("Không tìm thấy ảnh chữ ký do procedure trả về.", path);
            var extension = Path.GetExtension(path).ToLowerInvariant();
            var mime = extension switch
            {
                ".png" => "image/png", ".jpg" or ".jpeg" => "image/jpeg",
                ".gif" => "image/gif", ".svg" => "image/svg+xml",
                ".webp" => "image/webp", ".bmp" => "image/bmp",
                _ => throw new InvalidOperationException("Định dạng ảnh chữ ký không được hỗ trợ.")
            };
            byte[] image;
            if (extension == ".svg")
            {
                // Reuse the same SVG field substitution as Excel/Word/PDF.
                var png = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".png");
                try
                {
                    FileSVG.ReplaceAndConvertSvgToPng(path, png, new Dictionary<string, string>
                    {
                        ["@UserName"] = userFullName,
                        ["@NgayKy"] = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")
                    }, 600, 200);
                    image = File.ReadAllBytes(png);
                    mime = "image/png";
                }
                finally
                {
                    if (File.Exists(png)) File.Delete(png);
                }
            }
            else image = File.ReadAllBytes(path);
            model[key.TrimStart('@')] = "data:" + mime + ";base64," + Convert.ToBase64String(image);
            model["Has" + key.TrimStart('@')] = true;
        }
        if (signType == "DF")
            foreach (var key in values.Keys.Where(k => k.StartsWith("@SignName_", StringComparison.OrdinalIgnoreCase)))
                model[key.TrimStart('@')] = string.Empty;

        foreach (var table in FileExcelAPI.ReadTableData(tablejson))
        {
            model["table_" + table.Key] = table.Value.Select((row, index) =>
            {
                var item = MakeModel(row, tokens);
                foreach (var key in row.Keys.Where(k => k.Contains("_STT", StringComparison.OrdinalIgnoreCase)))
                    item[key.TrimStart('@')] = index + 1;
                return item;
            }).ToList();
        }
        var template = Regex.Replace(source, pattern,
            m => m.Value.StartsWith("@table_", StringComparison.OrdinalIgnoreCase)
                ? m.Value : "{{[" + m.Value[1..] + "]}}");
        return renderer.RenderSource(template, model);
    }

    private static Dictionary<string, object> MakeModel(Dictionary<string, object> values, List<string> tokens)
    {
        var model = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        foreach (var token in tokens)
        {
            model[token[1..]] = token;
            if (token.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
                model["Has" + token[1..]] = false;
        }
        foreach (var pair in values)
        {
            var key = pair.Key.TrimStart('@');
            var value = pair.Value?.ToString();
            model[key] = string.IsNullOrWhiteSpace(value) ? "@" + key : value;
        }
        return model;
    }
}
