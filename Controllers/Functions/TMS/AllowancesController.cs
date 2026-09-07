using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.lib.Function;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.Allowances")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class AllowancesController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecAllowances";

        public AllowancesController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Allowances.Request.Get request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] Allowances.Request.GetByID request)
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
                    result.Properties = dataResponse.Result[1];
                    result.Histories = dataResponse.Result[2];
                    result.Details = dataResponse.Result[3];
                    result.Progress = dataResponse.Result[4];

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
        public async Task<IActionResult> Add([FromBody] Allowances.Request.Add request)
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
                if (request.CoatTarpAllowanceDetails != null)
                {
                    DataTable CoatTarpAllowanceDetails = request.CoatTarpAllowanceDetails.ToDataTable();
                    CoatTarpAllowanceDetails.SetTypeName("CoatTarpAllowanceDetail");
                    parameters.Add("@AllowancesDetailsCoatTarps", CoatTarpAllowanceDetails);
                    request.CoatTarpAllowanceDetails = null;
                }
                if (request.OutSideVehiclesAllowancesDetails != null)
                {
                    DataTable OutSideVehiclesAllowancesDetails = request.OutSideVehiclesAllowancesDetails.ToDataTable();
                    OutSideVehiclesAllowancesDetails.SetTypeName("OutSideVehiclesAllowancesDetail");
                    parameters.Add("@AllowancesDetailsOutSideVehicles", OutSideVehiclesAllowancesDetails);
                    request.OutSideVehiclesAllowancesDetails = null;
                }
                if (request.PairshipAllowancesDetails != null)
                {
                    DataTable PairshipAllowancesDetails = request.PairshipAllowancesDetails.ToDataTable();
                    PairshipAllowancesDetails.SetTypeName("PairshipAllowancesDetail");
                    parameters.Add("@AllowancesDetailsPairships", PairshipAllowancesDetails);
                    request.PairshipAllowancesDetails = null;
                }
                if (request.PieceTireAllowancesDetails != null)
                {
                    DataTable PieceTireAllowancesDetails = request.PieceTireAllowancesDetails.ToDataTable();
                    PieceTireAllowancesDetails.SetTypeName("PieceTireAllowancesDetail");
                    parameters.Add("@AllowancesDetailsPieceTires", PieceTireAllowancesDetails);
                    request.PieceTireAllowancesDetails = null;
                }

                if (request.AllowancesDetailsVehicles != null)
                {
                    DataTable AllowancesDetailsVehicles = request.AllowancesDetailsVehicles.ToDataTable();
                    AllowancesDetailsVehicles.SetTypeName("AllowancesDetailsVehicle");
                    parameters.Add("@AllowancesDetailsVehicles", AllowancesDetailsVehicles);
                    request.AllowancesDetailsVehicles = null;
                }
                //if (request.Vehicles != null)
                //{
                //    DataTable Vehicles = request.Vehicles.ToDataTable();
                //    Vehicles.SetTypeName("Vehicles");
                //    parameters.Add("@Vehicles", Vehicles);
                //    request.Vehicles = null;
                //}
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Allowances.Request.Edit request)
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
                if (request.CoatTarpAllowanceDetails != null)
                {
                    DataTable CoatTarpAllowanceDetails = request.CoatTarpAllowanceDetails.ToDataTable();
                    CoatTarpAllowanceDetails.SetTypeName("CoatTarpAllowanceDetail");
                    parameters.Add("@AllowancesDetailsCoatTarps", CoatTarpAllowanceDetails);
                    request.CoatTarpAllowanceDetails = null;
                }
                if (request.OutSideVehiclesAllowancesDetails != null)
                {
                    DataTable OutSideVehiclesAllowancesDetails = request.OutSideVehiclesAllowancesDetails.ToDataTable();
                    OutSideVehiclesAllowancesDetails.SetTypeName("OutSideVehiclesAllowancesDetail");
                    parameters.Add("@AllowancesDetailsOutSideVehicles", OutSideVehiclesAllowancesDetails);
                    request.OutSideVehiclesAllowancesDetails = null;
                }
                if (request.PairshipAllowancesDetails != null)
                {
                    DataTable PairshipAllowancesDetails = request.PairshipAllowancesDetails.ToDataTable();
                    PairshipAllowancesDetails.SetTypeName("PairshipAllowancesDetail");
                    parameters.Add("@AllowancesDetailsPairships", PairshipAllowancesDetails);
                    request.PairshipAllowancesDetails = null;
                }
                if (request.PieceTireAllowancesDetails != null)
                {
                    DataTable PieceTireAllowancesDetails = request.PieceTireAllowancesDetails.ToDataTable();
                    PieceTireAllowancesDetails.SetTypeName("PieceTireAllowancesDetail");
                    parameters.Add("@AllowancesDetailsPieceTires", PieceTireAllowancesDetails);
                    request.PieceTireAllowancesDetails = null;
                }
                if (request.AllowancesDetailsVehicles != null)
                {
                    DataTable AllowancesDetailsVehicles = request.AllowancesDetailsVehicles.ToDataTable();
                    AllowancesDetailsVehicles.SetTypeName("AllowancesDetailsVehicle");
                    parameters.Add("@AllowancesDetailsVehicles", AllowancesDetailsVehicles);
                    request.AllowancesDetailsVehicles = null;
                }
                //if (request.Vehicles != null)
                //{
                //    DataTable Vehicles = request.Vehicles.ToDataTable();
                //    Vehicles.SetTypeName("Vehicles");
                //    parameters.Add("@Vehicles", Vehicles);
                //    request.Vehicles = null;
                //}
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Allowances.Request.Del request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Copy([FromBody] Allowances.Request.GetByID request)
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
 
        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody] Allowances.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
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
        public async Task<IActionResult> Submit([FromBody] Allowances.Request.Submit request)
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
    }
}