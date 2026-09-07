using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using static APISmartCity.lib.Function;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.VehicleDatas")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class VehicleDatasController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecVehicleDatas";

        public VehicleDatasController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetListVehicleTeam()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@Type", "GetVehicleTeam-ByUserID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetTotalVehicleByTeamID([FromBody] Shippings.Request.GetDetailsVehicleByTeamID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@Type", "GET-VehicleByUserID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.TotalVehicelByUsers = dataResponse.Result[0];
                    result.VehicelDetails = dataResponse.Result[1];
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
        public async Task<IActionResult> GetLocationByLicensePlate([FromBody] Shippings.Request.GetLocationByLicensePlate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@Type", "Get-Location-ByLicensePlate" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetTotalVehicleByUser()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@Type", "GET-VehicleByUserID"},
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.TotalVehicelByUsers = dataResponse.Result[0];
                    result.VehicelDetails = dataResponse.Result[1];
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
        public async Task<IActionResult> GetDetailsByVehicleAndDriverID([FromBody] Shippings.Request.GetDetailsVehicleAndDriverID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@Type", "Get-ContractByVehicle" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.ListShippings = dataResponse.Result[0];
                    result.ListContractOKs = dataResponse.Result[1];
                    result.ListContractAlls = dataResponse.Result[1];

                    dataResponse.Result = result;
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