using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Function;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APISmartCity.Controllers.Ver2
{
    [ApiExplorerSettings(GroupName = "Functions.GPS.GPSTracking")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class GPSTracking : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _GPSDB;
        private readonly string _ProcedureName = "ExecUserTrackingGPS";

        public GPSTracking(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _GPSDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GPS.Request.AddGPS request)
        {
            try
            {
                var convertRequest = JsonSerializer.Serialize(request);

                IDictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@dataJson", convertRequest }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _GPSDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
       
        
        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] GPS.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-BYID" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _GPSDB, _ConfigurationDB, _ProcedureName, request);
                dynamic result = dataResponse.Result[0][0];
                dataResponse.Result = result;
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByUserID()
        {
            try
            {
                Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-BYUSERID" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _GPSDB, _ConfigurationDB, _ProcedureName, null);
                dynamic result = dataResponse.Result[0][0];
                dataResponse.Result = result;
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}