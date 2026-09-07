using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.VietmapGeocodeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.ReportShipping.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.ReportShipping")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ReportShippingController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecReportShippings";
        private readonly KimTinService _kimTinService;

        public ReportShippingController(UserInfo userInfo, KimTinService kimTinService)
        {
            _kimTinService = kimTinService;
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> OutsourceOil([FromBody] Search request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "OutsourceOil" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DebitOil([FromBody] Search request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DebitOil" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Incidents([FromBody] Search request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Incidents" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    var results = (IEnumerable<dynamic>)result[0]!;
                    foreach (var item in results)
                    {
                        item.listStation = ((IEnumerable<dynamic>)result[1]!).Where(r => r.LicensePlates == item.LicensePlates);
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

        [HttpPost]
        public async Task<IActionResult> GPS([FromBody] Search request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GPS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Pairship([FromBody] SearchWithDetail request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Pairship" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VehicleUsageHistory([FromBody] SearchVehicle request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_VehicleUsageHistory" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VehicleTools([FromBody] SearchVehicle request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_VehicleTools" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}