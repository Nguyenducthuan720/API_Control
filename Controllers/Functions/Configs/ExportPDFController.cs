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
using static APISmartCity.lib.Function;
using WkHtmlToPdfDotNet.Contracts;

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
        private readonly IConverter _htmlToPdfConverter;

        public ExportPDFController(
            UserInfo userInfo,
            WordToPdfService wordDocumentService,
            ExcelToPdfService excelToPdfService,
            ILogger<ExportPDFController> logger,
            HandlebarsHtmlRenderer htmlRenderer,
            IConfiguration configuration,
            IWebHostEnvironment environment,
            IConverter htmlToPdfConverter)
        {
            _UserInfo = userInfo;
            _wordToPdfService = wordDocumentService;
            _excelToPdfService = excelToPdfService;
            _logger = logger;
            _htmlRenderer = htmlRenderer;
            _configuration = configuration;
            _environment = environment;
            _htmlToPdfConverter = htmlToPdfConverter;
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

                // HTML uses the same template, approver and replacement JSON as PDF.
                // Extention1=HTML selects the output/save route only.
                object infoRequest = request;
                if (string.Equals(request.Extention1, "HTML", StringComparison.OrdinalIgnoreCase))
                {
                    infoRequest = new
                    {
                        request.FactorID, request.EntryID, request.OID, request.TempID,
                        Extention1 = "", request.Extention2, request.Extention3,
                        request.Extention4, request.Extention5, request.Json
                    };
                }
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, infoRequest);

                if (dataResponse.Result?.Count <= 1 || dataResponse.Result[0].Count == 0) return Ok(dataResponse);


                dynamic result = dataResponse.Result[0][0];
                dynamic jsonrs = dataResponse.Result[1][0];
                dynamic tablejsonrs = dataResponse.Result[2][0];

                string exportTemplate = result.ExportTemplate;
                string SignType = result.SignType;
                string CurrentStep = result.CurrentStep;
                string UserFullName = result.UserFullName;
                string FileAttach = result.FileAttach?.ToString() ?? "";
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
                var outputFolder = OperatingSystem.IsWindows()
                    ? folder
                    : Path.GetFullPath(folder.Replace('\\', Path.DirectorySeparatorChar));


                string fileExtension = Path.GetExtension(exportTemplate)?.ToUpperInvariant() ?? string.Empty;
                bool exportHtml = fileExtension == ".HTML"
                    || fileExtension == ".HTM"
                    || string.Equals(request.Extention1, "HTML", StringComparison.OrdinalIgnoreCase);

                if (exportHtml)
                {
                    var htmlTemplate = FileHTML.ResolveCanonicalTemplate(
                        exportTemplate,
                        _configuration["ExportHtml:TemplateRoot"],
                        request.FactorID,
                        request.EntryID);
                    generatedFilePath = await FileHTML.ExportTemplateToHtmlAsync(
                        htmlTemplate,
                        outputFolder,
                        safeOid,
                        json,
                        SignType,
                        tablejson,
                        UserFullName,
                        _htmlRenderer,
                        _SettingUpload.DiskFolderSave,
                        _SettingUpload.LinkFolderSave
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
                var htmlOutputPaths = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    ["HTML"] = generatedFilePath
                };

                if (exportHtml)
                {
                    var htmlOutputs = ParseHtmlOutputFormats(request.Extention2);
                    if (htmlOutputs.Contains("XLSX") || htmlOutputs.Contains("DOCX"))
                        htmlOutputs.Add("PDF");

                    var renderedHtmlPath = generatedFilePath;
                    if (htmlOutputs.Contains("PDF"))
                    {
                        var path = Path.Combine(outputFolder, fileNames + ".pdf");
                        htmlOutputPaths["PDF"] = FileHTMLToPdf.ExportHtmlToPdf(
                            renderedHtmlPath,
                            path,
                            _htmlToPdfConverter,
                            _configuration["ExportHtml:ChromiumPath"]);
                    }

                    if (htmlOutputs.Contains("XLSX"))
                    {
                        var path = Path.Combine(outputFolder, fileNames + ".xlsx");
                        var excelTemplate = FileHTML.ResolveOriginalExcelTemplate(
                            exportTemplate,
                            _configuration["ExportHtml:ExcelTemplateRoot"],
                            request.FactorID,
                            request.EntryID,
                            _environment.IsDevelopment()
                                ? _configuration["ExportHtml:ExcelTemplatePath"]
                                : string.Empty);
                        htmlOutputPaths["XLSX"] = FileHTMLToExcelTemplate.ExportHtmlToExcel(
                            renderedHtmlPath,
                            excelTemplate,
                            path,
                            SignType,
                            UserFullName);
                    }

                    if (htmlOutputs.Contains("DOCX"))
                    {
                        var path = Path.Combine(outputFolder, fileNames + ".docx");
                        htmlOutputPaths["DOCX"] = FileHTMLToWord.ExportHtmlToWord(renderedHtmlPath, path);
                    }

                    // HTML remains the primary link written through the existing
                    // procedure. Additional outputs are returned without changing
                    // the legacy LinkFile meaning.
                    LinkExportLocal = generatedFilePath;
                    LinkExportView = linkview + "/" + fileNames + ".html";
                }


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
                    var outputLinks = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["PreviewLinkFile"] = previewLink,
                        ["HTMLLocalFile"] = generatedFilePath
                    };
                    foreach (var output in htmlOutputPaths.Where(output => !output.Key.Equals("HTML", StringComparison.OrdinalIgnoreCase)))
                    {
                        outputLinks[output.Key + "LocalFile"] = output.Value;
                        outputLinks[output.Key + "LinkFile"] = linkview + "/" + fileNames + "." + output.Key.ToLowerInvariant();
                    }
                    AddOutputLinks(saveData, request.OID, outputLinks);
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

        private static void AddPreviewLink(DataResponse response, string oid, string previewLink)
        {
            AddOutputLinks(response, oid, new Dictionary<string, object>
            {
                ["PreviewLinkFile"] = previewLink
            });
        }

        private static void AddOutputLinks(
            DataResponse response,
            string oid,
            IReadOnlyDictionary<string, object> outputLinks)
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
                    foreach (var output in outputLinks)
                        row[output.Key] = output.Value;
                    rows.Add(row);
                }
            }

            if (rows.Count == 0)
            {
                rows.Add(new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    ["OID"] = oid,
                });
                foreach (var output in outputLinks)
                    rows[0][output.Key] = output.Value;
            }

            response.Result = rows;
        }

        private static HashSet<string> ParseHtmlOutputFormats(string value)
        {
            var formats = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "HTML"
            };
            if (string.IsNullOrWhiteSpace(value))
                return formats;

            foreach (var format in value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var normalized = format.Trim().ToUpperInvariant();
                if (normalized == "ALL")
                {
                    formats.UnionWith(new[] { "PDF", "XLSX", "DOCX" });
                    continue;
                }

                if (normalized is "PDF" or "XLSX" or "DOCX")
                    formats.Add(normalized);
            }

            return formats;
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
