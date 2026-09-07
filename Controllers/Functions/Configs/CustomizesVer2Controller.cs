using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static APISmartCity.Models.Ver2.Configs.CustomizesVer2.Request;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Customize")]
    [Route("api/customize-ver2/[action]")]
    [ApiController]
    [Authorize]
    public class CustomizesVer2Controller : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecCustomizesVer2";

        public CustomizesVer2Controller(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// Get all list customize
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetListCustomize()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        /// Get Column Name show
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetColumnNameShow(GetByTableName request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_CLNAMESHOW" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Get List Customize by TableName
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetByTableName(GetByTableName request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYTABLENAME" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        /// <summary>
        /// Get Customize by multiple entry
        /// </summary>
        /// <remarks></remarks>
        [HttpPost]
        public async Task<IActionResult> GetCustomizeByEntry([FromBody] GetCustomizeByEntry request)
        {
            try
            {
                Dictionary<string, dynamic> Customize = new();


                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetCustomizeByEntry" },
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
                        var ListCustomize = new List<dynamic>();
                        foreach (var item in ListColumn)
                        {
                            if (lang.TableCode == item.TableName)
                            {
                                ListCustomize.Add(item);
                            }
                        }
                        Customize.Add(lang.TableCode, ListCustomize);
                    }
                    dataResponse.Result = Customize;
                }
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
        public async Task<IActionResult> Add([FromBody] AddOrEdit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
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
        public async Task<IActionResult> Edit([FromBody] AddOrEdit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Delete Customize column
        /// </summary>
        /// <remarks>Delete Customize column</remarks>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Delete request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// ADD multiple Customize column
        /// </summary>
        /// <remarks>Add multiple Customize column</remarks>
        [HttpPost]
        public async Task<IActionResult> AddRange([FromBody] AddEditRangeCustomize request)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(request.Customizes, new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                });

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD-RANGE" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CustomizesVer2", jsonString },
                    { "@TableName", request.TableName }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);
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
        public async Task<IActionResult> EditRange([FromBody] AddEditRangeCustomize request)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(request.Customizes, new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                });

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT-RANGE" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CustomizesVer2", jsonString },
                    { "@TableName", request.TableName }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);
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
        public async Task<IActionResult> MobileLanguage([FromBody] GetByTableName request)
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
        /// Add Customize table and customize by TableNameShow
        /// </summary>
        /// <remarks>Add Customize column</remarks>
        [HttpPost]
        public async Task<IActionResult> AddCustomizByTableNameShow([FromBody] AddCustomizByTableNameShow request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "AddCustomizByTableNameShow" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}