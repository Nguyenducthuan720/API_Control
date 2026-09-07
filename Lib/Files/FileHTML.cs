using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using DMS.Lib.Files;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using static APISmartCity.lib.Function;

namespace NLTShipping.Export;

public sealed class FileHTML(
    UserInfo user, IConfiguration configuration, IWebHostEnvironment environment,
    IHttpClientFactory clients, ILogger<FileHTML> logger)
{
    private const string Procedure = "ExecExportPDF";

    public string GetStorageRoot(CompanyUpload setting)
    {
        var root = configuration["ExportHtml:StorageRoot"];
        if (string.IsNullOrWhiteSpace(root))
            root = setting.DiskFolderSave;
        if (string.IsNullOrWhiteSpace(root))
            throw new InvalidOperationException("Chưa cấu hình DiskFolderSave hoặc ExportHtml:StorageRoot.");
        return Path.GetFullPath(root.Replace('\\', Path.DirectorySeparatorChar));
    }

    public async Task<DataResponse> ExportAsync(ExportPDF.Request.Get request, string apiBaseUrl)
    {
        var temporarySignatureFiles = new List<string>();

        try
        {
            if (request == null || string.IsNullOrWhiteSpace(request.OID) ||
                string.IsNullOrWhiteSpace(request.FactorID) || string.IsNullOrWhiteSpace(request.EntryID))
                return Error("FactorID, EntryID và OID là bắt buộc.");
            var setting = int.TryParse(user.CmpnID, out var id)
                ? Global.CompanyUpload?.Find(x => x.ID == id) : null;
            if (setting == null)
                return Error("Không tìm thấy cấu hình lưu file của công ty.");

            var publish = configuration.GetValue<bool>("ExportHtml:Publish", true);
            if (!publish && !environment.IsDevelopment())
                return Error("Chưa cấu hình ExportHtml:Publish và storage public cho HTML.");

            DataResponse selectedInfo = null;
            ProcedureOutput procedureOutput = null;
            string databaseOid = null;

            // Legacy records may contain Ð (U+00D0) where the request carries
            // Đ (U+0110). Try the exact OID first, then the known legacy alias.
            foreach (var oidCandidate in OidCandidates(request.OID))
            {
                var candidateInfo = await ExecuteAsync(
                    "Get-Info", request, oidOverride: oidCandidate);
                if (!Success(candidateInfo))
                    continue;

                var candidateOutput = ReadProcedureOutput(candidateInfo);
                selectedInfo ??= candidateInfo;
                procedureOutput ??= candidateOutput;
                databaseOid ??= oidCandidate;

                if (HasBusinessData(candidateOutput))
                {
                    selectedInfo = candidateInfo;
                    procedureOutput = candidateOutput;
                    databaseOid = oidCandidate;
                    break;
                }
            }

            if (selectedInfo == null || !Success(selectedInfo))
                return Error(selectedInfo?.Message ?? "Không lấy được dữ liệu xuất file.");

            databaseOid ??= request.OID;
            var metadata = procedureOutput.Metadata;
            if (metadata == null)
                return Error("Procedure không trả ExportTemplate để dựng form HTML.");

            // Missing business values are valid: the workbook keeps its own
            // blank/@--- placeholders. The JSON envelope itself can be empty.
            var json = string.IsNullOrWhiteSpace(procedureOutput.JsonData)
                ? "{}"
                : procedureOutput.JsonData;
            var values = JsonSerializer.Deserialize<Dictionary<string, object>>(json)
                ?? new Dictionary<string, object>();
            var oid = Text(values, "@OID") ?? Text(values, "OID");
            if (string.IsNullOrWhiteSpace(oid))
            {
                values["@OID"] = databaseOid;
                json = JsonSerializer.Serialize(values);
            }
            else if (!string.Equals(oid.Trim(), databaseOid.Trim(), StringComparison.Ordinal))
                return Error("OID trong dữ liệu nguồn không khớp request.");

            var template = ResolvePath(Text(metadata, "ExportTemplate"), setting);
            if (Path.GetExtension(template).ToLowerInvariant() is not (".xlsx" or ".xlsm" or ".xltx"))
                return Error("Xuất HTML cần workbook Excel OpenXML. Không dùng HTML/PDF đã xuất làm template.");

            var table = procedureOutput.JsonTableData ?? "[]";
            var name = Segment(databaseOid) + "_" + Segment(Text(metadata, "CurrentStep") ?? "0")
                + "_" + Guid.NewGuid().ToString("N");
            var parts = new[] { Segment(user.CmpnID), Segment(request.FactorID), Segment(request.EntryID),
                Segment(databaseOid.Replace("/", "").Replace("\\", "")) };
            var folder = Path.Combine(GetStorageRoot(setting), Path.Combine(parts));

            // Both PDF and HTML use the same workbook population rules.
            var signatureKeys = values.Keys
                .Where(k => k.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var key in signatureKeys)
            {
                var source = Convert.ToString(values[key], System.Globalization.CultureInfo.InvariantCulture);
                if (string.IsNullOrWhiteSpace(source))
                {
                    values.Remove(key);
                    continue;
                }

                var path = await ResolveSignatureAsync(
                    source, setting, folder, key, temporarySignatureFiles);
                if (string.IsNullOrWhiteSpace(path))
                {
                    logger.LogWarning(
                        "Không resolve được ảnh chữ ký cho {Key}. Nguồn do procedure trả về: {Source}",
                        key, source);
                    return Error("Không tìm thấy ảnh chữ ký của bước hiện tại. " +
                        "Đã thử đường dẫn local và LinkFolderSave của file server.");
                }

                // FileExcelAPI reuses the legacy Excel signature insertion code,
                // which expects a physical image path.
                values[key] = path;
            }
            var excel = FileExcelAPI.ExportTemplateToExcel(template, folder, name,
                JsonSerializer.Serialize(values), Text(metadata, "SignType"), table,
                Text(metadata, "UserFullName"), clearUnresolvedPlaceholders: false,
                preserveUnsignedSignatures: true, preserveMissingValues: true);
            var htmlPath = Path.Combine(folder, name + ".html");
            var html = FileExcelToHtml.ConvertWorkbookToHtml(excel);
            await File.WriteAllTextAsync(htmlPath, html, new UTF8Encoding(false));

            var relative = string.Join("/", parts);
            var preview = apiBaseUrl + "/api/ExportPDF/PreviewHTML?path="
                + Uri.EscapeDataString(relative + "/" + name + ".html");
            if (!publish)
                return new DataResponse("Đã tạo bản xem thử local; chưa xuất bản và chưa cập nhật link trong DB.",
                    new[] { new { OID = databaseOid, Published = false, DatabaseUpdated = false,
                        LinkFile = (string)null, PreviewLinkFile = preview } }, "0");

            // Keep the legacy URL join semantics. In this system
            // LinkFolderSave commonly already ends with '/', and the old PDF
            // flow intentionally produced ':15006//1/...'.
            var urlRoot = setting.LinkFolderSave?.Replace('\\', '/');
            if (!Uri.TryCreate(urlRoot, UriKind.Absolute, out var uri) || uri.Scheme != "https")
                return Error("LinkFolderSave phải là URL HTTPS của file server.");
            var urlFolder = urlRoot + "/" + string.Join("/", parts.Select(Uri.EscapeDataString));
            var htmlUrl = urlFolder + "/" + name + ".html";
            var excelUrl = urlFolder + "/" + name + ".xlsx";

            // Check actual bytes: a 200 login page or a stale file is not publication.
            await VerifyPublicFileAsync(htmlUrl, htmlPath, true);
            await VerifyPublicFileAsync(excelUrl, excel, false);
            var databaseExcel = setting.DiskFolderSave.Replace('/', '\\').TrimEnd('\\')
                + "\\" + string.Join("\\", parts) + "\\" + name + ".xlsx";
            var databaseRequest = CopyRequestWithOid(request, databaseOid);
            var saved = await ExecuteAsync("Update-LinkExport", databaseRequest, null, new()
            {
                ["@LinkExportLocal"] = databaseExcel,
                ["@LinkExportView"] = htmlUrl,
                ["@FileMerge"] = string.Empty
            });
            if (!Success(saved))
                return Error("File đã xuất bản nhưng cập nhật DB thất bại: " + saved?.Message);
            var readback = await ExecuteAsync("Get-ByID", databaseRequest);
            if (!Success(readback) || Text(Row(readback, 0), "LinkFile") != htmlUrl)
                return Error("File đã xuất bản nhưng chưa xác nhận được LinkFile trong DB; không tự động rollback.");

            return new DataResponse("Đã xuất bản HTML và xác nhận link trong DB.",
                new[] { new { OID = databaseOid, Published = true, DatabaseUpdated = true,
                    LinkFile = htmlUrl, ExcelLinkFile = excelUrl } }, "0");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "ExportHTML thất bại.");
            return Error(ex.Message);
        }
        finally
        {
            foreach (var file in temporarySignatureFiles)
            {
                try
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }
                catch (Exception ex)
                {
                    logger.LogDebug(ex, "Không xóa được file chữ ký tạm {File}.", file);
                }
            }
        }
    }

    private async Task VerifyPublicFileAsync(string url, string localFile, bool html)
    {
        using var client = clients.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(30);
        using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        if (!response.IsSuccessStatusCode ||
            (html && response.Content.Headers.ContentType?.MediaType != "text/html"))
            throw new InvalidOperationException(
                $"File server chưa phục vụ đúng file ({(int)response.StatusCode}). Chưa cập nhật DB. Kiểm tra StorageRoot và cấu hình IIS.");
        await using var remote = await response.Content.ReadAsStreamAsync();
        await using var local = File.OpenRead(localFile);
        var expected = await SHA256.HashDataAsync(local);
        var actual = await SHA256.HashDataAsync(remote);
        if (!actual.SequenceEqual(expected))
            throw new InvalidOperationException("File public khác file vừa xuất. Chưa cập nhật DB.");
    }

    private string ResolvePath(string value, CompanyUpload setting)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new FileNotFoundException("Procedure không trả đường dẫn template/ảnh.");

        var path = LocalPathCandidates(value, setting).FirstOrDefault(File.Exists);
        if (!string.IsNullOrWhiteSpace(path))
            return path;

        throw new FileNotFoundException(
            $"Không tìm thấy file local do procedure trả về: {value}", value);
    }

    private async Task<string> ResolveSignatureAsync(
        string source,
        CompanyUpload setting,
        string outputFolder,
        string key,
        ICollection<string> temporaryFiles)
    {
        if (string.IsNullOrWhiteSpace(source))
            return null;

        source = source.Trim();
        var urlSource = source.Replace('\\', '/');
        if (TryCreateHttpUri(urlSource, out var sourceUri))
            return await DownloadImageAsync(sourceUri, outputFolder, key, temporaryFiles);

        // The procedure converts LinkFolderSave back to DiskFolderSave. On a
        // developer machine that Windows path may not be mounted, so try the
        // configured local root first and then the public file-server URL.
        var localPath = LocalPathCandidates(source, setting).FirstOrDefault(File.Exists);
        if (!string.IsNullOrWhiteSpace(localPath))
            return localPath;

        var publicUrl = MapDiskPathToPublicUrl(source, setting);
        if (TryCreateHttpUri(publicUrl, out var publicUri))
            return await DownloadImageAsync(publicUri, outputFolder, key, temporaryFiles);

        return null;
    }

    private async Task<string> DownloadImageAsync(
        Uri uri,
        string outputFolder,
        string key,
        ICollection<string> temporaryFiles)
    {
        try
        {
            using var client = clients.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            using var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
                return null;

            var mediaType = response.Content.Headers.ContentType?.MediaType;
            var extension = GetImageExtension(uri, mediaType);
            if (!IsImage(mediaType, extension))
                return null;

            Directory.CreateDirectory(outputFolder);
            var fileName = ".signature_" + Segment(key.TrimStart('@')) + "_" +
                Guid.NewGuid().ToString("N") + extension;
            var localPath = Path.Combine(outputFolder, fileName);

            await using var source = await response.Content.ReadAsStreamAsync();
            await using var destination = File.Create(localPath);
            await source.CopyToAsync(destination);
            temporaryFiles.Add(localPath);
            return localPath;
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
    }

    private IEnumerable<string> LocalPathCandidates(string value, CompanyUpload setting)
    {
        var raw = value.Trim();

        // This is the normal case when the API and the file server share a
        // Windows volume.
        if (File.Exists(raw))
            yield return Path.GetFullPath(raw);

        var normalized = NormalizePath(raw);
        var diskRoot = NormalizePath(setting.DiskFolderSave);
        if (TryGetRelativePath(normalized, diskRoot, out var relative))
        {
            yield return Path.Combine(GetStorageRoot(setting), ToPlatformPath(relative));
            yield break;
        }

        if (!LooksLikeWindowsAbsolutePath(raw))
            yield return Path.GetFullPath(raw.Replace('/', Path.DirectorySeparatorChar));
    }

    private static string MapDiskPathToPublicUrl(string value, CompanyUpload setting)
    {
        var linkRoot = setting.LinkFolderSave?.Replace('\\', '/');
        if (!Uri.TryCreate(linkRoot, UriKind.Absolute, out var linkUri) ||
            (linkUri.Scheme != Uri.UriSchemeHttp && linkUri.Scheme != Uri.UriSchemeHttps))
            return null;

        var normalized = NormalizePath(value);
        var diskRoot = NormalizePath(setting.DiskFolderSave);
        if (!TryGetRelativePath(normalized, diskRoot, out var relative))
            return null;

        var encodedRelative = string.Join(
            "/",
            relative.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(Uri.EscapeDataString));
        return string.IsNullOrWhiteSpace(encodedRelative)
            ? linkRoot
            : linkRoot + "/" + encodedRelative;
    }

    private static ProcedureOutput ReadProcedureOutput(DataResponse response)
    {
        var rows = FlattenRows((object)response?.Result).ToList();

        // Accept both contracts:
        //   1) three result sets: metadata, JsonData, JsonTableData;
        //   2) one result set containing one or more of those columns.
        var metadata = rows.FirstOrDefault(row => HasField(row, "ExportTemplate"))
            ?? Row(response, 0);
        var jsonRow = rows.FirstOrDefault(row => HasField(row, "JsonData"))
            ?? Row(response, 1);
        var tableRow = rows.FirstOrDefault(row => HasField(row, "JsonTableData"))
            ?? Row(response, 2);

        return new ProcedureOutput(
            metadata,
            Text(jsonRow, "JsonData"),
            Text(tableRow, "JsonTableData"));
    }

    private static IEnumerable<object> FlattenRows(object value)
    {
        if (value == null)
            yield break;

        if (value is string || value is IDictionary)
        {
            yield return value;
            yield break;
        }

        if (value is IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                foreach (var row in FlattenRows(item))
                    yield return row;
            }

            yield break;
        }

        yield return value;
    }

    private static bool HasField(object row, string name)
    {
        if (row is IDictionary<string, object> dictionary)
            return dictionary.Keys.Any(key => string.Equals(key, name, StringComparison.OrdinalIgnoreCase));

        if (row is IDictionary nonGenericDictionary)
        {
            return nonGenericDictionary.Keys.Cast<object>()
                .Any(key => string.Equals(key?.ToString(), name, StringComparison.OrdinalIgnoreCase));
        }

        return row?.GetType().GetProperties()
            .Any(property => string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase)) == true;
    }

    private static bool HasBusinessData(ProcedureOutput output)
    {
        if (!string.IsNullOrWhiteSpace(output?.JsonData))
            return true;

        return !string.IsNullOrWhiteSpace(output?.JsonTableData) &&
            !string.Equals(output.JsonTableData.Trim(), "[]", StringComparison.Ordinal);
    }

    private static IEnumerable<string> OidCandidates(string oid)
    {
        if (string.IsNullOrWhiteSpace(oid))
            yield break;

        yield return oid;

        var legacyOid = oid.Replace('\u0110', '\u00D0').Replace('\u0111', '\u00F0');
        if (!string.Equals(legacyOid, oid, StringComparison.Ordinal))
            yield return legacyOid;
    }

    private static ExportPDF.Request.Get CopyRequestWithOid(
        ExportPDF.Request.Get source,
        string oid)
    {
        return new ExportPDF.Request.Get
        {
            FactorID = source.FactorID,
            EntryID = source.EntryID,
            OID = oid,
            TempID = source.TempID,
            Extention1 = source.Extention1,
            Extention2 = source.Extention2,
            Extention3 = source.Extention3,
            Extention4 = source.Extention4,
            Extention5 = source.Extention5,
            Json = source.Json
        };
    }

    private static bool TryCreateHttpUri(string value, out Uri uri)
    {
        return Uri.TryCreate(value, UriKind.Absolute, out uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    private static bool TryGetRelativePath(string path, string root, out string relative)
    {
        relative = null;
        if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(root))
            return false;

        path = path.TrimEnd('/');
        root = root.TrimEnd('/');
        if (path.Equals(root, StringComparison.OrdinalIgnoreCase))
        {
            relative = string.Empty;
            return true;
        }

        var prefix = root + "/";
        if (!path.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            return false;

        relative = path[prefix.Length..];
        return !string.IsNullOrWhiteSpace(relative);
    }

    private static string NormalizePath(string value) =>
        (value ?? string.Empty).Trim().Replace('\\', '/').TrimEnd('/');

    private static string ToPlatformPath(string relative) =>
        relative.Replace('/', Path.DirectorySeparatorChar);

    private static bool LooksLikeWindowsAbsolutePath(string value) =>
        value.Length >= 3 && char.IsLetter(value[0]) && value[1] == ':' &&
        (value[2] == '\\' || value[2] == '/');

    private static string GetImageExtension(Uri uri, string mediaType)
    {
        var extension = Path.GetExtension(uri.AbsolutePath)?.ToLowerInvariant();
        if (IsImageExtension(extension))
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

    private static bool IsImage(string mediaType, string extension)
    {
        if (!string.IsNullOrWhiteSpace(mediaType))
        {
            return mediaType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
                (mediaType.Equals("application/octet-stream", StringComparison.OrdinalIgnoreCase) &&
                 IsImageExtension(extension));
        }

        return IsImageExtension(extension);
    }

    private static bool IsImageExtension(string extension) => extension is
        ".svg" or ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".webp";

    private Task<DataResponse> ExecuteAsync(string mode, ExportPDF.Request.Get request,
        object body = null, Dictionary<string, object> extra = null, string oidOverride = null)
    {
        var oid = string.IsNullOrWhiteSpace(oidOverride) ? request.OID : oidOverride;
        var parameters = new Dictionary<string, object>
        {
            ["@type"] = mode, ["@language"] = user.Language, ["@UserIDCurent"] = user.UserID,
            ["@CmpnID"] = user.CmpnID, ["@FactorID"] = request.FactorID,
            ["@EntryID"] = request.EntryID, ["@OID"] = oid,
            ["@TempID"] = request.TempID ?? string.Empty,
            ["@Extention1"] = "HTML",
            ["@Extention2"] = request.Extention2 ?? string.Empty,
            ["@Extention3"] = request.Extention3 ?? string.Empty,
            ["@Extention4"] = request.Extention4 ?? string.Empty,
            ["@Extention5"] = request.Extention5 ?? string.Empty,
            ["@Json"] = request.Json ?? string.Empty
        };
        if (extra != null)
            foreach (var entry in extra) parameters[entry.Key] = entry.Value;
        var db = Global.ListDB?.Find(x => x.DBType == "CON")?.DBString;
        return GetDataResponse(parameters, db, db, Procedure, body);
    }

    private static object Row(DataResponse response, int index)
    {
        if (response?.Result is not IEnumerable result) return null;
        var sets = result.Cast<object>().ToList();
        if (sets.FirstOrDefault() is IDictionary<string, object> or IDictionary)
            return index == 0 ? sets[0] : null;
        return index < sets.Count && sets[index] is IEnumerable rows
            ? rows.Cast<object>().FirstOrDefault() : null;
    }

    private static string Text(object row, string key)
    {
        object value = null;
        if (row is IDictionary<string, object> fields)
            value = fields.FirstOrDefault(x => string.Equals(x.Key, key,
                StringComparison.OrdinalIgnoreCase)).Value;
        else if (row != null)
            value = row.GetType().GetProperty(key)?.GetValue(row);
        return value == null || value == DBNull.Value ? null
            : Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
    }
    private static bool Success(DataResponse value) => value?.ErrorCode is "0" or "000";
    private static DataResponse Error(string message) => new(message, "", "-1");
    private sealed record ProcedureOutput(object Metadata, string JsonData, string JsonTableData);

    private static string Segment(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value is "." or "..")
            throw new ArgumentException("Thành phần đường dẫn trống hoặc không hợp lệ.");
        return string.Concat(value.Select(c => char.IsControl(c) || "<>:\"/\\|?*".Contains(c) ? '_' : c));
    }
}
