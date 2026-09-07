using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APISmartCity.Controllers.Category
{
    [ApiExplorerSettings(GroupName = "Microservice.Category.Excel")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ExcelTemplatesController : Controller
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ImportPath;
        private readonly string _ExportPath;
        private readonly string _ExcelPath;
        private readonly string _ProcedureName = "ExecExcelTemplates";

        public ExcelTemplatesController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _ImportPath = Global.ListFolder?.Find(item => item.Type == "PathImportExcelTemplate")?.Link!;
            _ExportPath = Global.ListFolder?.Find(item => item.Type == "PathExportExcelTemplate")?.Link!;
            _ExcelPath = Global.ListFolder?.Find(item => item.Type == "PathExcel")?.Link!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
        }

        /// <summary>
        /// Load list excel template
        /// </summary>
        /// <remarks>Load list excel template</remarks>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListImportExcelTemplate()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-IMPORT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load list excel template
        /// </summary>
        /// <remarks>Load list excel template</remarks>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListExportExcelTemplate()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-EXPORT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load list ExcelTemplate
        /// </summary>
        /// <remarks>Load list ExcelTemplate</remarks>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListExcelTemplateActive()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy thông tin excel template theo ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetExcelTemplateById([FromBody] Default.Request.ID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Properties = dataResponse.Result[1];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới import template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddImportExcelTemplates([FromForm] ExcelTemplates.Request.Add request)
        {
            try
            {
                string savePath = _ImportPath;
                string path = _ExcelPath + savePath;
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{request.file.FileName}";
                string fullPath = Path.Combine(path, fileName);
                Stream FileStream = request.file.OpenReadStream();
                byte[] bytes = Function.ReadToEnd(FileStream);

                using (FileStream FileWrite = new(fullPath, FileMode.Create))
                {
                    FileWrite.Write(bytes, 0, bytes.Length);
                    FileWrite.Flush();
                }
                savePath += fileName;
                request.file = null!;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@Link", savePath.Replace(@"\", "/") },
                    { "@ExcelType", "Import" }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới export template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddExportExcelTemplates([FromForm] ExcelTemplates.Request.Add request)
        {
            try
            {
                string savePath = _ExportPath;
                string path = _ExcelPath + savePath;
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{request.file.FileName}";
                string fullPath = Path.Combine(path, fileName);
                Stream FileStream = request.file.OpenReadStream();
                byte[] bytes = Function.ReadToEnd(FileStream);

                using (FileStream FileWrite = new(fullPath, FileMode.Create))
                {
                    FileWrite.Write(bytes, 0, bytes.Length);
                    FileWrite.Flush();
                }
                savePath += fileName;
                request.file = null!;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@Link", savePath.Replace(@"\", "/") },
                    { "@ExcelType", "Export" }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Sửa template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditExcelTemplate([FromForm] ExcelTemplates.Request.Edit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                if (request.file is not null)
                {
                    string savePath = _ExportPath;
                    string path = _ExcelPath + savePath;
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{request.file.FileName}";
                    string fullPath = Path.Combine(path, fileName);
                    Stream FileStream = request.file.OpenReadStream();
                    byte[] bytes = Function.ReadToEnd(FileStream);

                    using (FileStream FileWrite = new(fullPath, FileMode.Create))
                    {
                        FileWrite.Write(bytes, 0, bytes.Length);
                        FileWrite.Flush();
                    }
                    savePath += fileName;
                    request.file = null!;
                    parameters.Add("@Link", savePath.Replace(@"\", "/"));
                    parameters.Add("@IsEditLink", "1");
                }
                else
                {
                    parameters.Add("@IsEditLink", "0");
                }
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xóa excel template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteExcelTemplate(ExcelTemplates.Request.Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thay đổi trạng thái excel template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangeStatusExcelTemplate(ExcelTemplates.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}