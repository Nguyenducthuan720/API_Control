using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.DriverRequests.DriverRequestIncidentReports;
using APISmartCity.Models.Ver2.Function;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Functions.DMS.Shippings.IncidentReports
{
    [ApiExplorerSettings(GroupName = "Functions.DriverRequestIncidentReports")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class DriverRequestIncidentReportsController : ControllerBase
    {
        private readonly UserInfo _userInfo;
        private readonly string _stringConnect;
        private readonly string _stringConnectConfig;
        private readonly string _procedureName = "ExecDriverRequestIncidentReports";

        public DriverRequestIncidentReportsController(UserInfo userInfo)
        {
            _userInfo = userInfo;
            _stringConnectConfig = Global.ListDB?.Find(item => item.DBType == "SHP")?.DBString!;
            _stringConnect = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DriverRequestIncidentReports.Request.AddIncident report)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }


                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, report);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditIncidentReport([FromBody] DriverRequestIncidentReports.Request.Edit report)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, report);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] DriverRequestIncidentReports.Request.GetByOID report)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, report);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Progress = dataResponse.Result[1];
                    result.Histories = dataResponse.Result[2];
                    result.Customize = dataResponse.Result[3];
                    dataResponse.Result = result;
                }
                else
                {
                    dataResponse.Result = null;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetMoblie([FromBody] DriverRequestIncidentReports.Request.GetMobile request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-MOBILE" },
                { "@language", _userInfo.Language },
                { "@UserIDCurent", _userInfo.UserID },
                { "@CmpnID", _userInfo.CmpnID }
            };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetMobileByID([FromBody] DriverRequestIncidentReports.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-MOBILE-BYID" },
                { "@language", _userInfo.Language },
                { "@UserIDCurent", _userInfo.UserID },
                { "@CmpnID", _userInfo.CmpnID }
            };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, request);
                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Progress = dataResponse.Result[1];
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
        public async Task<IActionResult> Delete([FromBody] DriverRequestIncidentReports.Request.GetByOID report)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, report);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] DriverRequestIncidentReports.Request.Submit report)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, report);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] DriverRequestIncidentReports.Request.UpdateStauts report)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UPDATE-FINAL" },
                    { "@Language", _userInfo.Language },
                    { "@UserIDCurent", _userInfo.UserID },
                    { "@CmpnID", _userInfo.CmpnID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _stringConnectConfig, _stringConnect, _procedureName, report);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
