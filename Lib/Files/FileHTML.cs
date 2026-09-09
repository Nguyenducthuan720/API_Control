using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace DMS.Lib.Files;

/// <summary>Fills a selected HTML template with the procedure's JSON, without database access.</summary>
public static class FileHTML
{
    private static readonly HttpClient SignatureClient = new()
    {
        Timeout = TimeSpan.FromSeconds(30)
    };

    public static bool IsHtmlTemplate(string path)
    {
        var extension = Path.GetExtension(path);
        return extension is not null &&
            (extension.Equals(".html", StringComparison.OrdinalIgnoreCase) ||
             extension.Equals(".htm", StringComparison.OrdinalIgnoreCase) ||
             extension.Equals(".hbs", StringComparison.OrdinalIgnoreCase) ||
             extension.Equals(".handlebars", StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Resolves the canonical HTML source for a form. A sidecar or configured
    /// source template wins; the original workbook is returned as a compatibility
    /// fallback for forms that have not migrated yet.
    /// </summary>
    public static string ResolveCanonicalTemplate(
        string templatePath,
        string templateRoot,
        string factorId,
        string entryId)
    {
        if (IsHtmlTemplate(templatePath))
            return templatePath;

        var candidates = new List<string>();
        if (!string.IsNullOrWhiteSpace(templatePath))
        {
            candidates.Add(Path.ChangeExtension(templatePath, ".hbs"));
            candidates.Add(Path.ChangeExtension(templatePath, ".html"));
        }

        var safeFactor = SafeTemplateSegment(factorId);
        var safeEntry = SafeTemplateSegment(entryId);
        var root = string.IsNullOrWhiteSpace(templateRoot)
            ? Path.Combine(AppContext.BaseDirectory, "Templates", "Export")
            : templateRoot;
        if (!string.IsNullOrWhiteSpace(safeFactor) && !string.IsNullOrWhiteSpace(safeEntry))
        {
            candidates.Add(Path.Combine(root, safeFactor, safeEntry + ".hbs"));
            candidates.Add(Path.Combine(root, safeFactor, safeEntry + ".html"));
            if (safeFactor.Equals("SALE_SHIPPINGPRICE", StringComparison.OrdinalIgnoreCase))
                candidates.Add(Path.Combine(root, safeFactor, "ShippingAndCreditnPL.hbs"));
        }

        return candidates.FirstOrDefault(File.Exists) ?? templatePath;
    }

    /// <summary>
    /// Resolves the original OpenXML workbook used as the layout source for an
    /// HTML-to-XLSX export. The HTML file supplies values; this method supplies
    /// the workbook whose merge cells, pictures, formulas and print settings are
    /// preserved by <see cref="FileExcelAPI"/>.
    /// </summary>
    public static string ResolveOriginalExcelTemplate(
        string templatePath,
        string templateRoot,
        string factorId,
        string entryId)
    {
        var candidates = new List<string>();
        var resolvedTemplate = ResolveExistingPath(templatePath);
        if (!string.IsNullOrWhiteSpace(resolvedTemplate))
            candidates.Add(resolvedTemplate);

        if (!string.IsNullOrWhiteSpace(templatePath))
        {
            var normalized = templatePath.Replace('\\', '/');
            var fileName = Path.GetFileName(normalized);
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                var extension = Path.GetExtension(fileName);
                if (extension.Equals(".html", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".htm", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".hbs", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".handlebars", StringComparison.OrdinalIgnoreCase))
                {
                    fileName = Path.ChangeExtension(fileName, ".xlsx");
                }

                var root = ResolveExistingPath(templateRoot);
                if (!string.IsNullOrWhiteSpace(root))
                {
                    candidates.Add(Path.Combine(root, fileName));
                    var safeEntry = SafeTemplateSegment(entryId);
                    if (!string.IsNullOrWhiteSpace(safeEntry))
                        candidates.Add(Path.Combine(root, safeEntry, fileName));
                    var safeFactor = SafeTemplateSegment(factorId);
                    if (!string.IsNullOrWhiteSpace(safeFactor))
                        candidates.Add(Path.Combine(root, safeFactor, fileName));
                }
            }
        }

        var existing = candidates
            .Select(ResolveExistingPath)
            .FirstOrDefault(path => IsOpenXmlWorkbook(path) && File.Exists(path));
        return existing ?? resolvedTemplate;
    }

    public static string ExportTemplateToHtml(
        string templatePath, string outputFolder, string outputFileName,
        string jsonReplacements, string signType, string tablejson, string userFullName,
        HandlebarsHtmlRenderer renderer, string storageRoot = "", string storageUrl = "")
    {
        return ExportTemplateToHtmlAsync(
            templatePath, outputFolder, outputFileName, jsonReplacements,
            signType, tablejson, userFullName, renderer, storageRoot, storageUrl).GetAwaiter().GetResult();
    }

    public static async Task<string> ExportTemplateToHtmlAsync(
        string templatePath, string outputFolder, string outputFileName,
        string jsonReplacements, string signType, string tablejson, string userFullName,
        HandlebarsHtmlRenderer renderer, string storageRoot = "", string storageUrl = "")
    {
        var databaseTemplatePath = templatePath;
        templatePath = ResolveExistingPath(templatePath);
        outputFolder = ResolveOutputFolder(outputFolder);

        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Không tìm thấy file template: {databaseTemplatePath}");

        var extension = Path.GetExtension(templatePath).ToLowerInvariant();
        // The legacy procedure selects signature slots and the previous signed template.
        if (extension is ".xlsx" or ".xlsm" or ".xltx")
        {
            var prepared = await PrepareSignatureFilesAsync(jsonReplacements, storageRoot, storageUrl);
            try
            {
                var workbookPath = FileExcelAPI.ExportTemplateToExcel(
                    templatePath,
                    outputFolder,
                    outputFileName,
                    prepared.Json,
                    signType,
                    tablejson,
                    userFullName,
                    clearUnresolvedPlaceholders: false,
                    preserveUnsignedSignatures: true,
                    preserveMissingValues: true);

                var workbookHtml = FileExcelToHtml.ConvertWorkbookToHtml(workbookPath);
                Directory.CreateDirectory(outputFolder);
                var workbookOutput = Path.Combine(outputFolder, outputFileName + ".html");
                await File.WriteAllTextAsync(workbookOutput, workbookHtml, new UTF8Encoding(false));
                return workbookOutput;
            }
            finally
            {
                foreach (var file in prepared.TemporaryFiles)
                {
                    try
                    {
                        if (File.Exists(file))
                            File.Delete(file);
                    }
                    catch
                    {
                        // A temporary signature file must not hide the export result.
                    }
                }
            }
        }

        if (extension is not (".html" or ".htm" or ".hbs" or ".handlebars"))
            throw new InvalidOperationException("Template HTML phải là .html, .htm, .hbs, .handlebars hoặc workbook OpenXML.");

        var source = File.ReadAllText(templatePath, Encoding.UTF8);
        var signatures = await PrepareSignatureFilesAsync(jsonReplacements, storageRoot, storageUrl);
        string html;
        try
        {
            html = RenderTemplate(source, signatures.Json, signType, tablejson, renderer, userFullName);
        }
        finally
        {
            foreach (var file in signatures.TemporaryFiles)
                File.Delete(file);
        }
        Directory.CreateDirectory(outputFolder);
        var output = Path.Combine(outputFolder, outputFileName + ".html");
        await File.WriteAllTextAsync(output, html, new UTF8Encoding(false));
        return output;
    }

    private static async Task<(string Json, List<string> TemporaryFiles)> PrepareSignatureFilesAsync(
        string jsonReplacements, string storageRoot, string storageUrl)
    {
        var json = string.IsNullOrWhiteSpace(jsonReplacements) ? "{}" : jsonReplacements;
        var values = JsonSerializer.Deserialize<Dictionary<string, object>>(json)
            ?? new Dictionary<string, object>();
        var temporaryFiles = new List<string>();

        foreach (var key in values.Keys
                     .Where(k => k.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
                     .ToList())
        {
            var source = values[key]?.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(source) || source.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
                continue;
            if (!Uri.TryCreate(source, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            {
                var localPath = ResolveExistingPath(source);
                if (File.Exists(localPath))
                {
                    values[key] = localPath;
                    continue;
                }
                // Resolve the same DB asset on the configured file server when running locally.
                var prefix = storageRoot.Replace('\\', '/').TrimEnd('/') + "/";
                var normalized = source.Replace('\\', '/');
                if (string.IsNullOrWhiteSpace(storageRoot) || string.IsNullOrWhiteSpace(storageUrl) ||
                    !normalized.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    throw new FileNotFoundException($"Không đọc được ảnh chữ ký {key} do procedure trả về.", source);
                var relative = normalized[prefix.Length..].Split('/');
                if (relative.Any(segment => segment is "." or ".."))
                    throw new InvalidOperationException("Đường dẫn ảnh chữ ký không hợp lệ.");
                uri = new Uri(storageUrl.TrimEnd('/') + "/" + string.Join("/", relative.Select(Uri.EscapeDataString)));
            }

            var localFile = await DownloadSignatureAsync(uri);
            if (string.IsNullOrWhiteSpace(localFile))
            {
                throw new IOException($"Không tải được ảnh chữ ký {key} do procedure trả về.");
            }

            values[key] = localFile;
            temporaryFiles.Add(localFile);
        }

        return (JsonSerializer.Serialize(values), temporaryFiles);
    }

    private static async Task<string> DownloadSignatureAsync(Uri uri)
    {
        try
        {
            using var response = await SignatureClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
                return string.Empty;

            var extension = GetSignatureExtension(uri, response.Content.Headers.ContentType?.MediaType);
            if (string.IsNullOrWhiteSpace(extension))
                return string.Empty;

            var localFile = Path.Combine(
                Path.GetTempPath(),
                "nlt-signature-" + Guid.NewGuid().ToString("N") + extension);
            await using var source = await response.Content.ReadAsStreamAsync();
            await using var destination = File.Create(localFile);
            await source.CopyToAsync(destination);
            return localFile;
        }
        catch (HttpRequestException)
        {
            return string.Empty;
        }
        catch (TaskCanceledException)
        {
            return string.Empty;
        }
    }

    private static string GetSignatureExtension(Uri uri, string mediaType)
    {
        var extension = Path.GetExtension(uri.AbsolutePath)?.ToLowerInvariant();
        if (extension is ".svg" or ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".webp")
            return extension;

        return mediaType?.ToLowerInvariant() switch
        {
            "image/svg+xml" => ".svg",
            "image/png" => ".png",
            "image/jpeg" => ".jpg",
            "image/gif" => ".gif",
            "image/bmp" => ".bmp",
            "image/webp" => ".webp",
            _ => string.Empty
        };
    }

    private static string ResolveExistingPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || File.Exists(path))
            return path;

        var normalizedPath = NormalizePath(path);
        return File.Exists(normalizedPath) ? normalizedPath : path;
    }

    private static bool IsOpenXmlWorkbook(string path)
    {
        var extension = Path.GetExtension(path);
        return extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".xlsm", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".xltx", StringComparison.OrdinalIgnoreCase);
    }

    private static string ResolveOutputFolder(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || OperatingSystem.IsWindows())
            return path;

        return NormalizePath(path);
    }

    private static string NormalizePath(string path)
    {
        var normalizedPath = path.Replace('\\', Path.DirectorySeparatorChar);
        return Path.GetFullPath(normalizedPath);
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
            var path = values[key]?.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(path) || path.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
            {
                model[key.TrimStart('@')] = key;
                continue;
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Không đọc được ảnh chữ ký {key} do procedure trả về.", path);
            }
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
        foreach (var table in FileExcelAPI.ReadTableData(tablejson))
        {
            model["table_" + table.Key] = table.Value.Select((row, index) =>
            {
                var item = MakeModel(NormalizeTableRow(row, table.Key), tokens);
                if (row.Keys.Any(k => k.Contains("_STT", StringComparison.OrdinalIgnoreCase)))
                    item["STT"] = index + 1;
                return item;
            }).ToList();
        }
        var template = Regex.Replace(source, pattern,
            m => m.Value.StartsWith("@table_", StringComparison.OrdinalIgnoreCase)
                ? m.Value : "{{[" + m.Value[1..] + "]}}");
        // A previous Excel-derived HTML file keeps unfilled signature cells as text.
        // Render those cells as images; leave existing images and src bindings intact.
        template = Regex.Replace(template,
            @"\{\{\s*#if\s+(Sign(?:Link|Note)_C(?:[1-9]|[1-9][0-9]))\s*\}\}",
            match => "{{#if Has" + match.Groups[1].Value + "}}",
            RegexOptions.IgnoreCase);
        template = Regex.Replace(template,
            @"(?<=>)\s*\{\{\[(SignLink_C\d{1,2})\]\}\}\s*(?=<)",
            match => "{{#if Has" + match.Groups[1].Value + "}}<img class=\"excel-signature\" " +
                "style=\"width:180px;height:60px;object-fit:contain;max-width:100%\" " +
                "src=\"{{[" + match.Groups[1].Value + "]}}\" alt=\"Chữ ký\">" +
                "{{else}}{{[" + match.Groups[1].Value + "]}}{{/if}}");
        return HtmlPrintLayout.Apply(renderer.RenderSource(template, model));
    }
    private static Dictionary<string, object> MakeModel(Dictionary<string, object> values, List<string> tokens)
    {
        var model = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        foreach (var token in tokens)
        {
            var key = token[1..];
            model[key] = token;
            if (key.StartsWith("SignLink_", StringComparison.OrdinalIgnoreCase) ||
                key.StartsWith("SignNote_", StringComparison.OrdinalIgnoreCase))
                model["Has" + key] = false;
        }
        foreach (var pair in values)
        {
            var key = pair.Key.TrimStart('@');
            var value = pair.Value?.ToString();
            var isSignature = key.StartsWith("SignLink_", StringComparison.OrdinalIgnoreCase) ||
                              key.StartsWith("SignNote_", StringComparison.OrdinalIgnoreCase);
            var hasValue = !string.IsNullOrWhiteSpace(value) &&
                           !value.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase) &&
                           !value.StartsWith("@SignNote_", StringComparison.OrdinalIgnoreCase);
            model[key] = hasValue ? value : "@" + key;
            if (isSignature)
                model["Has" + key] = hasValue;
        }
        return model;
    }

    private static Dictionary<string, object> NormalizeTableRow(
        Dictionary<string, object> row,
        string tableType)
    {
        var prefix = "@" + tableType + "_";
        return row.ToDictionary(
            pair => pair.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                ? "@" + pair.Key[prefix.Length..]
                : pair.Key,
            pair => pair.Value,
            StringComparer.OrdinalIgnoreCase);
    }

    private static string SafeTemplateSegment(string value)
    {
        if (string.IsNullOrWhiteSpace(value) ||
            value.Contains(Path.DirectorySeparatorChar) ||
            value.Contains(Path.AltDirectorySeparatorChar) ||
            value is "." or "..")
            return string.Empty;
        return value;
    }
}
