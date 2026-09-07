using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using APISmartCity.Services;
using DMS.Lib.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ExportPDFController(UserInfo userInfo, WordToPdfService wordDocumentService, ExcelToPdfService excelToPdfService, ILogger<ExportPDFController> logger)
        {
            _UserInfo = userInfo;
            _wordToPdfService = wordDocumentService;
            _excelToPdfService = excelToPdfService;
            _logger = logger;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "Print");
            _SettingUpload = Global.CompanyUpload?.Find(item => item.ID == int.Parse(_UserInfo.CmpnID));
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

                string json = jsonrs.JsonData;
                string tablejson = tablejsonrs?.JsonTableData?.ToString() ?? "[]";

                // Step 5: Save PDF
                long unixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                string safeOid = request.OID.Replace("/", "_").Replace("\\", "_") + "_" + CurrentStep + "_" + unixSeconds;
                string pdfFileName = $"{request.FactorID}_{request.EntryID}_{safeOid}.pdf";
                string folder = $"{_SettingUpload.DiskFolderSave}/{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}/{request.OID.Replace("/", "")}";
                string linkview = $"{_SettingUpload.LinkFolderSave}/{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}/{request.OID.Replace("/", "")}";
                string fileNames = safeOid;


                folder = folder.Replace('/', '\\').Replace(@"\\", @"\");
                linkview = linkview.Replace('\\', '/').Replace(@"\\", @"/");


                string fileExtension = Path.GetExtension(exportTemplate)?.ToLower();
                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
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

                if (fileExtension.ToUpper() == ".DOC" || fileExtension.ToUpper() == ".DOCX")
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


                if (fileExtension.ToUpper() == ".PDF")
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

                string LinkExportLocal = folder + "\\" + fileNames + fileExtension;
                string LinkExportView = linkview + "/" + fileNames + ".pdf";


                // Step 5.1: Gộp file PDF nếu có FileAttach
                string mergedPdfPath = folder + "\\" + fileNames + ".pdf";
                string mergedFileName = $"{safeOid}_merge";
                string mergedLinkExportLocal = Path.Combine(folder, $"{mergedFileName}.pdf").Replace('/', '\\').Replace(@"\\", @"\");
                string mergedLinkExportView = $"{linkview}/{mergedFileName}.pdf";

                if (!string.IsNullOrEmpty(FileAttach))
                {

                    var pdfFiles = new List<string> { mergedPdfPath };
                    pdfFiles.AddRange(
                        FileAttach.Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Where(f => System.IO.File.Exists(f) && Path.GetExtension(f).ToLower() == ".pdf")
                            .ToList()
                    );

                    if (pdfFiles.Count > 1)
                    {
                        mergedPdfPath = FilePdfMerge.MergePdfs(pdfFiles, folder, mergedFileName, fileExtension,
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
                    { "@FileMerge", mergedLinkExportLocal },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@FactorID", request.FactorID },
                    { "@EntryID", request.EntryID },
                    { "@OID", request.OID }
                };

                var saveData = await GetDataResponse(saveparameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);
               
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