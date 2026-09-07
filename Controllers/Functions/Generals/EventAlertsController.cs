using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Function;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.DMS.General
{
    [ApiExplorerSettings(GroupName = "Functions.General.EventAlerts")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class EventAlertsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _FunctionDB;
        private readonly string _ProcedureName = "[ExecEventAlerts]";

        public EventAlertsController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _FunctionDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
        }

        /// <remarks>lay ra thong tin chung thiet lap canh bao theo StationID</remarks>
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] EventAlerts.Request.GetEntryID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <remarks>lay ra thong tin chung thiet lap canh bao theo StationID</remarks>
        [HttpPost]
        public async Task<IActionResult> GetByOID([FromBody] EventAlerts.Request.GetOIDByEntryID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ByOID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Stations = dataResponse.Result[1];
                    result.Events = dataResponse.Result[2];
                    result.Indicators = dataResponse.Result[3];
                    result.LevelWarnings = dataResponse.Result[4];
                    result.IndicatorWarnings = dataResponse.Result[5];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EventAlerts.Request.Add request)
        {
            try
            {
                string JsonEvent = JsonSerializer.Serialize(request.Events);
                request.Events = null;
                string JsonIndicator = JsonSerializer.Serialize(request.Indicators);
                request.Indicators = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "JsonEvent", JsonEvent },
                    { "JsonIndicator", JsonIndicator }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EventAlerts.Request.Add request)
        {
            try
            {
                string JsonEvent = JsonSerializer.Serialize(request.Events);
                request.Events = null;
                string JsonIndicator = JsonSerializer.Serialize(request.Indicators);
                request.Indicators = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "JsonEvent", JsonEvent },
                    { "JsonIndicator", JsonIndicator }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xoa thong tin chung thiet lap canh bao cho Station
        /// </summary>
        /// <remarks>Xoa thong tin chung thiet lap canh bao theo StationID</remarks>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] EventAlerts.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody] EventAlerts.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}