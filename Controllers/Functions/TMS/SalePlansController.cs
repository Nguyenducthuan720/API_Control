using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.SalePlans.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.SalePlans")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class SalePlansController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecSalePlans";

        public SalePlansController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Get()
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
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
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Customers = dataResponse.Result[1];
                    result.Outsources = dataResponse.Result[2];
                    result.OrderTypes = dataResponse.Result[3];
                    result.GoodTypes = dataResponse.Result[4];
                    result.Properties = dataResponse.Result[5];
                    result.Histories = dataResponse.Result[6];
                    result.Progress = dataResponse.Result[7];

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
        public async Task<IActionResult> Add([FromBody] Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.Customers != null)
                {
                    DataTable Customers = request.Customers.ToDataTable();
                    Customers.SetTypeName("SalePlanCustomerDetails");
                    parameters.Add("@Customers", Customers);
                    request.Customers = null;
                }
                if (request.Outsources != null)
                {
                    DataTable Outsources = request.Outsources.ToDataTable();
                    Outsources.SetTypeName("SalePlanDetails");
                    parameters.Add("@Outsources", Outsources);
                    request.Outsources = null;
                }
                if (request.OrderTypes != null)
                {
                    DataTable OrderTypes = request.OrderTypes.ToDataTable();
                    OrderTypes.SetTypeName("SalePlanDetails");
                    parameters.Add("@OrderTypes", OrderTypes);
                    request.OrderTypes = null;
                }
                if (request.GoodTypes != null)
                {
                    DataTable GoodTypes = request.GoodTypes.ToDataTable();
                    GoodTypes.SetTypeName("SalePlanDetails");
                    parameters.Add("@GoodTypes", GoodTypes);
                    request.GoodTypes = null;
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
                if (request.Customers != null)
                {
                    DataTable Customers = request.Customers.ToDataTable();
                    Customers.SetTypeName("SalePlanCustomerDetails");
                    parameters.Add("@Customers", Customers);
                    request.Customers = null;
                }
                if (request.Outsources != null)
                {
                    DataTable Outsources = request.Outsources.ToDataTable();
                    Outsources.SetTypeName("SalePlanDetails");
                    parameters.Add("@Outsources", Outsources);
                    request.Outsources = null;
                }
                if (request.OrderTypes != null)
                {
                    DataTable OrderTypes = request.OrderTypes.ToDataTable();
                    OrderTypes.SetTypeName("SalePlanDetails");
                    parameters.Add("@OrderTypes", OrderTypes);
                    request.OrderTypes = null;
                }
                if (request.GoodTypes != null)
                {
                    DataTable GoodTypes = request.GoodTypes.ToDataTable();
                    GoodTypes.SetTypeName("SalePlanDetails");
                    parameters.Add("@GoodTypes", GoodTypes);
                    request.GoodTypes = null;
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
        public async Task<IActionResult> Delete([FromBody] Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> ChangeStatus([FromBody] EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@IsLock", request.IsActive }

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
        public async Task<IActionResult> Submit([FromBody] Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
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
        public async Task<IActionResult> Copy([FromBody] GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "COPY" },
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