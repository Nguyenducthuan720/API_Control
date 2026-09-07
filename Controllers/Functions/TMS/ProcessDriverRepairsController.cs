using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.VietmapGeocodeServices;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.ProcessDriverRepairs.Request;
using static APISmartCity.Models.nPL.ReportProcess.Response;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.ProcessDriverRepairs")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ProcessDriverRepairsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecProcessDriverRepairs";
        private readonly KimTinService _kimTinService;

        public ProcessDriverRepairsController(UserInfo userInfo, KimTinService kimTinService)
        {
            _kimTinService = kimTinService;
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Get request)
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
        public async Task<IActionResult> GetRescueInfo()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetRescueInfo" },
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
        public async Task<IActionResult> GetMaintenances()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetMaintenances" },
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
                    result.Images = dataResponse.Result[1];
                    result.Insurances = dataResponse.Result[2];
                    result.Outsources = dataResponse.Result[3];
                    result.Rescues = dataResponse.Result[4];
                    result.Supplies = dataResponse.Result[5];
                    result.Repairs = dataResponse.Result[6];
                    result.Properties = dataResponse.Result[7];
                    result.Histories = dataResponse.Result[8];
                    result.Progress = dataResponse.Result[9];
                    result.PrintForms = dataResponse.Result[10];


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
                    { "@type", "Add" },
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
        public async Task<IActionResult> EditComplete([FromBody] EditComplete request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditComplete" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.Insurances != null)
                {
                    DataTable Insurances = request.Insurances.ToDataTable();
                    Insurances.SetTypeName("PdrInsurances");
                    parameters.Add("@Insurances", Insurances);
                    request.Insurances = null;
                }
                if (request.Outsources != null)
                {
                    DataTable Outsources = request.Outsources.ToDataTable();
                    Outsources.SetTypeName("PdrOutsources");
                    parameters.Add("@Outsources", Outsources);
                    request.Outsources = null;
                }
                if (request.Rescues != null)
                {
                    DataTable Rescues = request.Rescues.ToDataTable();
                    Rescues.SetTypeName("PdrRescues");
                    parameters.Add("@Rescues", Rescues);
                    request.Rescues = null;
                }
                if (request.Supplies != null)
                {
                    DataTable Supplies = request.Supplies.ToDataTable();
                    Supplies.SetTypeName("PdrSupplies");
                    parameters.Add("@Supplies", Supplies);
                    request.Supplies = null;
                }

                if (request.Repairs != null)
                {
                    DataTable Repairs = request.Repairs.ToDataTable();
                    Repairs.SetTypeName("PdrRepairs");
                    parameters.Add("@Repairs", Repairs);
                    request.Repairs = null;
                }
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditReceive([FromBody] EditReceive request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditReceive" },
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
        public async Task<IActionResult> EditReceiveInfo([FromBody] EditReceiveInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditReceiveInfo" },
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
        public async Task<IActionResult> ReceiveInfo([FromBody] ReceiveInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Receive-Info" },
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
        public async Task<IActionResult> ProcessComplete([FromBody] GetByID request)
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

        [HttpPost]
        public async Task<IActionResult> GetMaintenanceSupplyPrices([FromBody] Prices request)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_nPLDB);
                // lấy Mã LemonID từ CompanyConfig
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetByID" },
                    { "@ID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecCompanyConfigs", null!);
                string LemonID = dataResponse.Result?[0]?[0]?.LemonID ?? "";

                parameters = new()
                {
                    { "@type", "GetMaintenanceSupplyPrices" },
                    { "@Period", DateTime.Now.AddMonths(-1).ToString("yyyyMM") },
                    { "@MaterialID", request.MaintenanceSuppliesID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                if (dataResponse.ErrorCode != "0")
                {
                    List<PriceMaterial> priceMaterials = new();
                    MaintenanceSupplyPrices maintenanceSupplyPrices = new()
                    {
                        Period = DateTime.Now.AddMonths(-1).ToString("yyyyMM"),
                        LemonID = request.MaintenanceSuppliesID
                    };
                    priceMaterials.AddRange(await _kimTinService.GetPriceMaterial(LemonID, maintenanceSupplyPrices));
                    // cập nhật giá tiền mã vật tư
                    DataTable dataTable = priceMaterials.ToDataTable();
                    dataTable.SetTypeName("MaintenanceSupplyPrice");
                    parameters = new()
                    {
                        { "@type", "MergeMaintenanceSupplyPrices" },
                        { "@CmpnID", _UserInfo.CmpnID },
                        { "@MaintenanceSupplyPrice", dataTable }
                    };
                    dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                    return Ok(dataResponse);
                }
                else
                {
                    return Ok(dataResponse);
                }
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
                    { "@type", "Edit" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.Insurances != null)
                {
                    DataTable Insurances = request.Insurances.ToDataTable();
                    Insurances.SetTypeName("PdrInsurances");
                    parameters.Add("@Insurances", Insurances);
                    request.Insurances = null;
                }
                if (request.Outsources != null)
                {
                    DataTable Outsources = request.Outsources.ToDataTable();
                    Outsources.SetTypeName("PdrOutsources");
                    parameters.Add("@Outsources", Outsources);
                    request.Outsources = null;
                }
                if (request.Rescues != null)
                {
                    DataTable Rescues = request.Rescues.ToDataTable();
                    Rescues.SetTypeName("PdrRescues");
                    parameters.Add("@Rescues", Rescues);
                    request.Rescues = null;
                }
                if (request.Supplies != null)
                {
                    DataTable Supplies = request.Supplies.ToDataTable();
                    Supplies.SetTypeName("PdrSupplies");
                    parameters.Add("@Supplies", Supplies);
                    request.Supplies = null;
                }

                if (request.Repairs != null)
                {
                    DataTable Repairs = request.Repairs.ToDataTable();
                    Repairs.SetTypeName("PdrRepairs");
                    parameters.Add("@Repairs", Repairs);
                    request.Repairs = null;
                }

                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
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
        public async Task<IActionResult> UpdatePayments([FromBody] UpdatePayments request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UPDATE-PAYMENTS" },
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
        public async Task<IActionResult> AddNoDriver([FromBody] AddNoDriver request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "AddNoDriver" },
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