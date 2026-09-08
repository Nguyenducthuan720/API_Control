using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using APISmartCity.Services;
using DMS.Lib.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections;
using System.Text;
using System.Text.Json;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.ExportPDF")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ExportPDFController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecExportPDF";
        private readonly WordToPdfService _wordToPdfService;
        private readonly ExcelToPdfService _excelToPdfService;
        private readonly ILogger<ExportPDFController> _logger;
        private readonly DBFolder _SettingOther;
        private readonly CompanyUpload _SettingUpload;
        private readonly HandlebarsHtmlRenderer _htmlRenderer;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public ExportPDFController(
            UserInfo userInfo,
            WordToPdfService wordDocumentService,
            ExcelToPdfService excelToPdfService,
            ILogger<ExportPDFController> logger,
            HandlebarsHtmlRenderer htmlRenderer,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            _UserInfo = userInfo;
            _wordToPdfService = wordDocumentService;
            _excelToPdfService = excelToPdfService;
            _logger = logger;
            _htmlRenderer = htmlRenderer;
            _configuration = configuration;
            _environment = environment;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "Print");
            _SettingUpload = int.TryParse(_UserInfo.CmpnID, out var companyId)
                ? Global.CompanyUpload?.Find(item => item.ID == companyId)
                : null;
        }

        [HttpPost]
        public async Task<IActionResult> ExportPDF(ExportPDF.Request.Get request)
        {
            try
            {
                System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("vi-VN");
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
                // Step 1: Lấy mẫu in và Param
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Info" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FactorID", request.FactorID },
                    { "@EntryID", request.EntryID },
                    { "@OID", request.OID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result?.Count <= 1 || dataResponse.Result[0].Count == 0) return Ok(dataResponse);


                dynamic result = dataResponse.Result[0][0];
                dynamic jsonrs = dataResponse.Result[1][0];
                dynamic tablejsonrs = dataResponse.Result[2][0];

                string exportTemplate = result.ExportTemplate;
                string SignType = result.SignType;
                string CurrentStep = result.CurrentStep;
                string UserFullName = result.UserFullName;
                string FileAttach = result.FileAttach?.ToString() ?? "";
                string pdfPath = "";
                int IsSeal = result.IsSeal;

                object jsonValue = jsonrs.JsonData;
                string json = jsonValue?.ToString() ?? "{}";
                if (string.IsNullOrWhiteSpace(json))
                    json = "{}";
                string tablejson = tablejsonrs?.JsonTableData?.ToString() ?? "[]";

                // Step 5: Save PDF
                long unixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                string safeOid = request.OID.Replace("/", "_").Replace("\\", "_") + "_" + CurrentStep + "_" + unixSeconds;
                string pdfFileName = $"{request.FactorID}_{request.EntryID}_{safeOid}.pdf";
                string folder = $"{_SettingUpload.DiskFolderSave}/{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}/{request.OID.Replace("/", "")}";
                string linkview = $"{_SettingUpload.LinkFolderSave}/{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}/{request.OID.Replace("/", "")}";
                string fileNames = safeOid;
                string generatedFilePath = string.Empty;


                folder = folder.Replace('/', '\\').Replace(@"\\", @"\");
                linkview = linkview.Replace('\\', '/').Replace(@"\\", @"/");


                string fileExtension = Path.GetExtension(exportTemplate)?.ToUpperInvariant() ?? string.Empty;
                bool exportHtml = fileExtension == ".HTML"
                    || fileExtension == ".HTM"
                    || string.Equals(request.Extention1, "HTML", StringComparison.OrdinalIgnoreCase);
                if (exportHtml)
                    UserFullName = ResolveUserFullName(UserFullName, json, CurrentStep);

                if (exportHtml)
                {
                    generatedFilePath = await FileHTML.ExportTemplateToHtmlAsync(
                        exportTemplate,
                        folder,
                        safeOid,
                        json,
                        SignType,
                        tablejson,
                        UserFullName,
                        _htmlRenderer
                    );
                }
                else if (fileExtension == ".XLS" || fileExtension == ".XLSX")
                {
                    FileExcelAPI.ExportTemplateToPdf(
                        exportTemplate,
                        folder,
                        safeOid,
                        json,
                        SignType,
                        tablejson,
                        UserFullName,
                        _excelToPdfService
                    );
                }
                else if (fileExtension == ".DOC" || fileExtension == ".DOCX")
                {
                    await FileWord.ExportTemplateToPdf(
                        exportTemplate,
                        folder,
                        safeOid,
                        json,
                        SignType,
                        UserFullName,
                        _wordToPdfService
                    );
                }
                else if (fileExtension == ".PDF")
                {
                    FilePDF.ExportTemplateToPdf(
                        exportTemplate,
                        folder,
                        safeOid,
                        json,
                        SignType,
                        UserFullName
                    );
                }

                string outputExtension = exportHtml ? ".html" : fileExtension.ToLowerInvariant();
                string LinkExportLocal = folder + "\\" + fileNames + outputExtension;
                string LinkExportView = linkview + "/" + fileNames + (exportHtml ? ".html" : ".pdf");


                // Step 5.1: Gộp file PDF nếu có FileAttach
                string mergedPdfPath = folder + "\\" + fileNames + ".pdf";
                string mergedFileName = $"{safeOid}_merge";
                string mergedLinkExportLocal = Path.Combine(folder, $"{mergedFileName}.pdf").Replace('/', '\\').Replace(@"\\", @"\");
                string mergedLinkExportView = $"{linkview}/{mergedFileName}.pdf";

                if (!exportHtml && !string.IsNullOrEmpty(FileAttach))
                {

                    var pdfFiles = new List<string> { mergedPdfPath };
                    pdfFiles.AddRange(
                        FileAttach.Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Where(f => System.IO.File.Exists(f) && Path.GetExtension(f).ToLower() == ".pdf")
                            .ToList()
                    );

                    if (pdfFiles.Count > 1)
                    {
                        mergedPdfPath = FilePdfMerge.MergePdfs(pdfFiles, folder, mergedFileName, fileExtension.ToLowerInvariant(),
                        exportTemplate,
                        folder,
                        safeOid,
                        json,
                        SignType,
                        UserFullName,
                        IsSeal);
                        //LinkExportLocal = mergedLinkExportLocal;
                        LinkExportView = mergedLinkExportView;
                    }
                }

                // Step 6: Lưu file về Attachfile và ExportFile
                Dictionary<string, object> saveparameters = new()
                {
                    { "@type", "Update-LinkExport" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@LinkExportLocal", LinkExportLocal },
                    { "@LinkExportView", LinkExportView },
                    { "@Extention1", exportHtml ? "HTML" : request.Extention1 },
                    { "@FileMerge", exportHtml ? string.Empty : mergedLinkExportLocal },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@FactorID", request.FactorID },
                    { "@EntryID", request.EntryID },
                    { "@OID", request.OID }
                };

                var saveData = await GetDataResponse(saveparameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);

                if (exportHtml && System.IO.File.Exists(generatedFilePath))
                {
                    var previewLink = BuildPreviewLink(
                        request.FactorID,
                        request.EntryID,
                        request.OID.Replace("/", ""),
                        fileNames + ".html");
                    AddPreviewLink(saveData, request.OID, previewLink);
                }
               
                //CleanupOldFiles(folder, TimeSpan.FromMinutes(1));
                //if (CurrentStep == "99")
                //{
                //    CleanupPreviousStepFiles(folder);
                //}
                return Ok(saveData);
            }

            catch (TimeoutException tex)
            {
                return Ok(new DataResponse("Timeout khi xử lý Convert PDF", tex.Message, "-2"));
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExportHTML(ExportPDF.Request.Get request)
        {
            request ??= new ExportPDF.Request.Get();
            request.Extention1 = "HTML";
            return await ExportPDF(request);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult PreviewHTML([FromQuery] string path)
        {
            if (!_environment.IsDevelopment())
                return NotFound();

            if (string.IsNullOrWhiteSpace(path))
                return BadRequest("Đường dẫn HTML không được để trống.");

            var segments = path
                .Replace('\\', '/')
                .Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (segments.Length < 5 ||
                !int.TryParse(segments[0], out var companyId) ||
                segments.Any(segment => segment is "." or ".." || segment.Contains(':')))
            {
                return BadRequest("Đường dẫn HTML không hợp lệ.");
            }

            var fileName = segments[^1];
            if (!fileName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(fileName, Path.GetFileName(fileName), StringComparison.Ordinal))
            {
                return BadRequest("Chỉ cho phép preview file HTML.");
            }

            var setting = Global.CompanyUpload?.Find(item => item.ID == companyId);
            if (setting == null || string.IsNullOrWhiteSpace(setting.DiskFolderSave))
                return NotFound();

            var rootPath = GetStorageRoot(setting);
            var relativePath = string.Join(
                Path.DirectorySeparatorChar,
                segments);
            var fullPath = Path.GetFullPath(Path.Combine(rootPath, relativePath));
            var rootPrefix = rootPath.TrimEnd(
                Path.DirectorySeparatorChar,
                Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

            if (!fullPath.StartsWith(rootPrefix, StringComparison.OrdinalIgnoreCase))
                return BadRequest("Đường dẫn HTML không hợp lệ.");

            if (!System.IO.File.Exists(fullPath))
                return NotFound();

            return PhysicalFile(fullPath, "text/html; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetByID(ExportPDF.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ByID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        private string GetStorageRoot(CompanyUpload setting)
        {
            var root = _configuration["ExportHtml:StorageRoot"];
            if (string.IsNullOrWhiteSpace(root))
                root = setting.DiskFolderSave;
            if (string.IsNullOrWhiteSpace(root))
                throw new InvalidOperationException("Chưa cấu hình DiskFolderSave hoặc ExportHtml:StorageRoot.");
            return Path.GetFullPath(root.Replace('\\', Path.DirectorySeparatorChar));
        }

        private string BuildPreviewLink(string factorId, string entryId, string oidFolder, string fileName)
        {
            var relativePath = string.Join("/", _UserInfo.CmpnID, factorId, entryId, oidFolder, fileName);
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}".TrimEnd('/');
            return $"{baseUrl}/api/ExportPDF/PreviewHTML?path={Uri.EscapeDataString(relativePath)}";
        }

        private static string ResolveUserFullName(string metadataName, string json, string currentStep)
        {
            if (!string.IsNullOrWhiteSpace(metadataName))
                return metadataName.Trim();

            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using var document = JsonDocument.Parse(json);
                if (document.RootElement.ValueKind != JsonValueKind.Object)
                    return string.Empty;

                var step = int.TryParse(currentStep, out var parsedStep) && parsedStep > 0
                    ? parsedStep
                    : 1;
                var keys = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "@UserFullName",
                    "UserFullName",
                    $"@SignName_C{step}",
                    $"SignName_C{step}"
                };

                foreach (var property in document.RootElement.EnumerateObject())
                {
                    if (!keys.Contains(property.Name))
                        continue;

                    var value = property.Value.ValueKind == JsonValueKind.String
                        ? property.Value.GetString()
                        : property.Value.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                        return value.Trim();
                }
            }
            catch (JsonException)
            {
                // The existing renderer handles invalid JSON through its normal error path.
            }

            return string.Empty;
        }

        private static void AddPreviewLink(DataResponse response, string oid, string previewLink)
        {
            var rows = new List<Dictionary<string, object>>();
            if (response?.Result is IEnumerable result && response.Result is not string)
            {
                foreach (var item in result)
                {
                    if (item is not IDictionary<string, object> fields)
                        continue;

                    var row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                    foreach (var field in fields)
                        row[field.Key] = field.Value;
                    row["PreviewLinkFile"] = previewLink;
                    rows.Add(row);
                }
            }

            if (rows.Count == 0)
            {
                rows.Add(new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    ["OID"] = oid,
                    ["PreviewLinkFile"] = previewLink
                });
            }

            response.Result = rows;
        }

        private void CleanupOldFiles(string folderPath, TimeSpan maxAge)
        {
            if (!Directory.Exists(folderPath)) return;

            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var files = Directory.GetFiles(folderPath, "*.*");

            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var parts = fileName.Split('_');
                if (parts.Length >= 3 && long.TryParse(parts.Last(), out long timestamp))
                {
                    if (now - timestamp > (long)maxAge.TotalSeconds)
                    {
                        try
                        {
                            System.IO.File.Delete(file);
                        }
                        catch {}
                    }
                }
            }
        }
        private void CleanupPreviousStepFiles(string folderPath)
        {
            if (!Directory.Exists(folderPath)) return;

            var files = Directory.GetFiles(folderPath, "*.*");

            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var parts = fileName.Split('_');
                if (parts.Length >= 3 && int.TryParse(parts[parts.Length - 2], out int step) && step < 99)
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch {}
                }
            }
        }
    }
}
