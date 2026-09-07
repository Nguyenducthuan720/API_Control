using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.Models.Customizes.Request;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.System")]
    [Authorize]
    [ApiController]
    public class ConfigurationController : Controller
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecLanguage";
        private readonly string _SecondProcedureName = "ExecCustomize";

        public ConfigurationController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// Chọn ngôn ngữ
        /// </summary>
        /// <remarks>Chọn ngôn ngữ</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/config/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> ChoseLanguage()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Bảng ngôn ngữ
        /// </summary>
        /// <remarks>Bảng ngôn ngữ</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/config/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> LanguageTable()
        {
            try
            {
                Dictionary<string, object> listLanguage = new();
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-DETAIL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                if (dataResponse.Result!.Count > 0)
                {
                    var results = (IEnumerable<dynamic>)dataResponse.Result![0];
                    var ListColumn = (IEnumerable<dynamic>)dataResponse.Result![1];
                    foreach (var lang in results)
                    {
                        string codename = lang.CustomizeName;
                        Dictionary<string, object> listColumn = new();
                        foreach (var item in ListColumn)
                        {
                            listColumn.Add(item.ClName, ((IDictionary<string, object>)item)[codename]);
                        }
                        listLanguage.Add(lang.Code, listColumn);
                    }
                    dataResponse.Result = listLanguage;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Bảng ngôn ngữ mobile
        /// </summary>
        /// <remarks>Bảng ngôn ngữ mobile</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/config/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> MobileLanguage([FromBody] MobileLanguage request)
        {
            try
            {
                Dictionary<string, object> listLanguage = new();
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetDetailMobile" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 0)
                {
                    var results = (IEnumerable<dynamic>)dataResponse.Result![0];
                    var ListColumn = (IEnumerable<dynamic>)dataResponse.Result![1];
                    foreach (var lang in results)
                    {
                        string codename = lang.CustomizeName;
                        Dictionary<string, object> listColumn = new();
                        foreach (var item in ListColumn)
                        {
                            listColumn.Add(item.ClName, ((IDictionary<string, object>)item)[codename]);
                        }
                        listLanguage.Add(lang.Code, listColumn);
                    }
                    dataResponse.Result = listLanguage;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load list customize column by Language
        /// </summary>
        /// <remarks>Load list customize column by Language</remarks>
        [HttpPost]
        [Route("api/customize/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListCustomize()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Add Customize column
        /// </summary>
        /// <remarks>Add Customize column</remarks>
        [HttpPost]
        [Route("api/customize/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> AddCustomize([FromBody] AddEditCustomize request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Add" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Edit Customize column
        /// </summary>
        /// <remarks>Edit Customize column</remarks>
        [HttpPost]
        [Route("api/customize/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditCustomize([FromBody] AddEditCustomize request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// EDIT Status Hide Customize column
        /// </summary>
        /// <remarks>EDIT Status Hide Customize column</remarks>
        [HttpPost]
        [Route("api/customize/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditHideCustomize([FromBody] EditHideCustomize request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT-HIDE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Del Customize column
        /// </summary>
        /// <remarks>Del Customize column</remarks>
        [HttpPost]
        [Route("api/customize/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> DelCustomize([FromBody] DelCustomize request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy danh sách Column Show
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/customize/[action]")]
        public async Task<IActionResult> GetColumnShow([FromBody] GetCustomizeByObjectName request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-CLSHOW" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@TableName", request.ObjectName }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy thông tin Column Show theo ClName
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/customize/[action]")]
        public async Task<IActionResult> GetByClumnName([FromBody] GetCustomizeByColumnName request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYCOLNAME" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy danh sách Column Show theo ObjectName
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/customize/[action]")]
        public async Task<IActionResult> GetColumnShowByObjectName([FromBody] GetCustomizeByObjectName request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYTABLE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@TableName", request.ObjectName }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy danh sách Operator cho search
        /// </summary>
        [HttpPost]
        [Route("api/customize/[action]")]
        public async Task<IActionResult> GetMethod()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "METHOD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}