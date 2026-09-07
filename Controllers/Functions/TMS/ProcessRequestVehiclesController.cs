using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Dynamic;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.ProcessRequestVehicles.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.ProcessRequestVehicles")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ProcessRequestVehiclesController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecProcessRequestVehicles";
        private readonly string _ProcedureGetName = "GetCurrentMaintenance";

        public ProcessRequestVehiclesController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrentMaintenance()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureGetName, null!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.Details = result[0];
                    results.Totals = result[1];
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
        public async Task<IActionResult> Get([FromBody] GetApproval request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetHandoverLicensePlate([FromBody] Handover request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetHandoverLicensePlate" },
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
        public async Task<IActionResult> GetEvictionLicensePlateByDriverID([FromBody] Driver request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetEvictionLicensePlateByDriverID" },
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
        public async Task<IActionResult> GetLicensePlatesByDriverID([FromBody] DriverInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetLicensePlatesByDriverID" },
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
        public async Task<IActionResult> GetVehicleByDriverID([FromBody] DriverInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetVehicleByDriverID" },
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
                        item.Documents = ((IEnumerable<dynamic>)result[1]!).Where(r => r.OID == item.OID);
                        item.Tools = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == item.OID);
                        item.Tires = ((IEnumerable<dynamic>)result[3]!).Where(r => r.OID == item.OID);
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
        public async Task<IActionResult> GetById([FromBody] GetByID request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Documents = dataResponse.Result[1];
                    result.Tires = dataResponse.Result[2];
                    result.Tools = dataResponse.Result[3];
                    result.Properties = dataResponse.Result[4];
                    result.Histories = dataResponse.Result[5];
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
        public async Task<IActionResult> GetDocument([FromBody] GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetDocument" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Documents = dataResponse.Result[1];
                    result.Tires = dataResponse.Result[2];
                    result.Tools = dataResponse.Result[3];
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
        public async Task<IActionResult> Edit([FromBody] Edit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.Documents != null)
                {
                    DataTable Documents = request.Documents.ToDataTable();
                    Documents.SetTypeName("PrvByDocuments");
                    parameters.Add("@ProcessRequestVehicles_ByDocuments", Documents);
                    request.Documents = null;
                }
                if (request.Tools != null)
                {
                    DataTable Tools = request.Tools.ToDataTable();
                    Tools.SetTypeName("PrvByTools");
                    parameters.Add("@ProcessRequestVehicles_ByTools", Tools);
                    request.Tools = null;
                }
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEvict([FromBody] EditEvict request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditEvict" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.Documents != null)
                {
                    DataTable Documents = request.Documents.ToDataTable();
                    Documents.SetTypeName("PrvEvictByDocuments");
                    parameters.Add("@Evict_ByDocuments", Documents);
                    request.Documents = null;
                }
                if (request.Tools != null)
                {
                    DataTable Tools = request.Tools.ToDataTable();
                    Tools.SetTypeName("PrvEvictByTools");
                    parameters.Add("@Evict_ByTools", Tools);
                    request.Tools = null;
                }
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProcessReceive([FromBody] Receive request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Receive" },
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
        public async Task<IActionResult> ProcessComplete([FromBody] Complete request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Complete" },
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