using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.CapacityVehicle.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.CapacityVehicle")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CapacityVehicleController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecCapacityVehicle";

        public CapacityVehicleController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Current([FromBody] Capacity request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@Type", "Currents" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@IsContract", 0 },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.CapacityVehicle = result[0];
                    foreach (dynamic item in results.CapacityVehicle)
                    {
                        item.Details = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ItemHH == item.IndexHH);
                    }
                    results.Vehicles = dataResponse.Result[2];
                    dataResponse.Result = results;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}