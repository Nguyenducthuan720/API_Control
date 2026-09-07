using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.Categorys.Entrys.Request;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Entry")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class EntrysController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecEntrys";
        private readonly CompanyUpload _SettingOther;

        public EntrysController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            var cmpnIDs = userInfo.CmpnID.Split(',');
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SettingOther = Global.CompanyUpload?.Find(item => cmpnIDs.Contains(item.ID.ToString()));
        }

        /// <summary>
        /// Danh sách tất cả chức năng
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Danh sách chức năng theo nghiệp vụ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> GetByFactorID([FromBody] GetByFactorID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYFACTORID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// thông tin chi tiết của 1 chức năng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetByFactorEntry([FromBody] GetByFactorEntry request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_BYFACTOR_ENTRY" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result![0].Count > 0)
                {
                    var results = new List<object>();

                    foreach (var item in dataResponse.Result[0])
                    {
                        var result = item as IDictionary<string, object>;
                        foreach (var field in new[] { "ImportTemplates", "ExportTemplates", "PrintTemplates" })
                        {
                            result[field] = result.ContainsKey(field) && result[field] is string json && !string.IsNullOrEmpty(json)
                                ? System.Text.Json.JsonSerializer.Deserialize<object[]>(json)
                                : new object[0]; 
                        }

                        if (dataResponse.Result.Count > 1)
                            result["Histories"] = dataResponse.Result[1];

                        results.Add(result);
                    }
                    dataResponse.Result = results;
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Danh sách chức năng có notify
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetNotifyByFactorID([FromBody] GetByFactorID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-NOTIFY-BYFACTORID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// danh sách chức năng đang dùng
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm chức năng mới
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddEntry([FromBody] AddEditEntry request)
        {
            try
            {
                var ImportTemplateJson = JsonConvert.SerializeObject(request.ImportTemplates);
                var ExportTemplateJson = JsonConvert.SerializeObject(request.ExportTemplates);
                var PrintTemplateJson = JsonConvert.SerializeObject(request.PrintTemplates);
                request.ImportTemplates = null;
                request.ExportTemplates = null;
                request.PrintTemplates = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@ImportTemplates", ImportTemplateJson },
                    { "@ExportTemplates", ExportTemplateJson },
                    { "@PrintTemplates", PrintTemplateJson }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Chỉnh sửa chức năng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditEntry([FromBody] Edit request)
        {
            try
            {
                var ImportTemplateJson = JsonConvert.SerializeObject(request.ImportTemplates);
                var ExportTemplateJson = JsonConvert.SerializeObject(request.ExportTemplates);
                var PrintTemplateJson = JsonConvert.SerializeObject(request.PrintTemplates);
                request.ImportTemplates = null;
                request.ExportTemplates = null;
                request.PrintTemplates = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@ImportTemplates", ImportTemplateJson },
                    { "@ExportTemplates", ExportTemplateJson },
                    { "@PrintTemplates", PrintTemplateJson }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xoá chức năng nghiệp vụ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteEntry([FromBody] DeleteEntry request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới file hướng dẫn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddFileDocument([FromForm] UploadDocument request)
        {
            try
            {
                IEnumerable<string> fileNameArr = request.File.Select(file => UploadFileReturnFileName(file, $"{_SettingOther.DiskFolderSave}/{_SettingOther.CompanyCode}{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}"));
                string fileNames = string.Join(",", fileNameArr);
                request.File = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD-FILE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FileNames", fileNames },
                    { "@CodeCompany", _SettingOther.CompanyCode },
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

        /// <summary>
        /// Xóa file hướng dẫn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteFileDocument([FromForm] DeleteEntry request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL-FILE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}