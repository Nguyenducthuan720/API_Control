using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static APISmartCity.Models.Ver2.Configs.CustomizeTablesVer2.Request;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.CustomizeTable")]
    [Route("api/customize-table-ver2/[action]")]
    [ApiController]
    [Authorize]
    public class CustomizeTablesVer2Controller : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecCustomizeTablesVer2";

        public CustomizeTablesVer2Controller(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// Get all list customize table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetListCustomizeTable()
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
        /// Get List Customize table by TableName
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetByEntryID(GetByEntryID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_BYENTRYID" },
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
        /// Get customize table by TableName
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetByTableCode(GetByTableCode request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_BYTABLECODE" },
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
        /// Add Customize Table column
        /// </summary>
        /// <remarks>Add Customize Table column</remarks>
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
        /// Copy Customize Table column
        /// </summary>
        /// <remarks>Copy Customize Table column</remarks>
        [HttpPost]
        public async Task<IActionResult> CopyTable([FromBody] CopyTable request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Copy" },
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
        /// Edit Customize Table column
        /// </summary>
        /// <remarks>Edit Customize Table column</remarks>
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
        /// Delete Customize Table column
        /// </summary>
        /// <remarks>Delete Customize Table column</remarks>
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
        /// ADD multiple Customize Table column
        /// </summary>
        /// <remarks>Add multiple Customize Table column</remarks>
        [HttpPost]
        public async Task<IActionResult> AddRange([FromBody] AddRangeTable request)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(request.CustomizeTables, new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                });

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD_RANGE" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@TableList", jsonString}
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}