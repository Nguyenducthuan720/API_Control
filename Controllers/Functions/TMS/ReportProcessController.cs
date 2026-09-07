using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.VietmapGeocodeServices;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.ReportProcess.Request;
using static APISmartCity.Models.nPL.ReportProcess.Response;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.ReportProcess")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ReportProcessController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecReportProcess";
        private readonly KimTinService _kimTinService;

        public ReportProcessController(UserInfo userInfo, KimTinService kimTinService)
        {
            _kimTinService = kimTinService;
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Maintenances([FromBody] HourSearch request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Maintenances" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.All = result[0];
                    results.Teams = result[1];
                    results.Vehicles = (IEnumerable<dynamic>)result[2]!;
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
        public async Task<IActionResult> Daily([FromBody] HourSearch request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Daily" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.All = result[0];
                    results.Teams = result[1];
                    results.Vehicles = (IEnumerable<dynamic>)result[2]!;
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
        public async Task<IActionResult> Repairs([FromBody] HourSearch request)
        {
            try
            {
                await UpdateMaintenanceSupplyPrices(request);
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RepairTotals" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.All = result[0];
                    results.Teams = result[1];
                    results.Vehicles = (IEnumerable<dynamic>)result[2]!;
                    dataResponse.Result = results;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> RepairDetails([FromBody] Search request)
        //{
        //    try
        //    {
        //        await UpdateMaintenanceSupplyPrices(request);
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "RepairDetails" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@CmpnID", _UserInfo.CmpnID }
        //        };
        //        DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
        //        if (dataResponse.Result!.Count > 1)
        //        {
        //            dynamic result = dataResponse.Result;
        //            dynamic results = result[1];
        //            foreach (dynamic item in results)
        //            {
        //                item.Details = ((IEnumerable<dynamic>)result[0]!).Where(r => r.OID == item.OID);
        //            }
        //            dataResponse.Result = results;
        //        }
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Customers([FromBody] Customers request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Customers" },
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

        private async Task UpdateMaintenanceSupplyPrices(Search request)
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
            // lấy mã vật tư, thời gian còn thiếu
            parameters = new()
                {
                    { "@type", "GetMaintenanceSupplyPrices" },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@VehicleGroups", request.VehicleGroups },
                    { "@FromDate", request.FromDate },
                    { "@ToDate", request.ToDate },
                };

            IEnumerable<MaintenanceSupplyPrices> maintenanceSupplyPrices = new List<MaintenanceSupplyPrices>();
            maintenanceSupplyPrices = await connection.QueryAsync<MaintenanceSupplyPrices>(_ProcedureName,
                param: parameters,
                commandType: CommandType.StoredProcedure);
            List<PriceMaterial> priceMaterials = new();
            foreach (var item in maintenanceSupplyPrices)
            {
                priceMaterials.AddRange(await _kimTinService.GetPriceMaterial(LemonID, item));
            }
            // cập nhật giá tiền mã vật tư
            DataTable dataTable = priceMaterials.ToDataTable();
            dataTable.SetTypeName("MaintenanceSupplyPrice");
            parameters = new()
                {
                    { "@type", "MergeMaintenanceSupplyPrices" },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@MaintenanceSupplyPrice", dataTable }
                };
            await connection.ExecuteAsync(_ProcedureName,
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Xe dừng hoạt động
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportVehicleNotWorking([FromBody] HourSearch request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "NotWorking" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.All = result[0];
                    results.Teams = result[1];
                    results.Vehicles = (IEnumerable<dynamic>)result[2]!;
                    foreach (var item in results.Vehicles)
                    {
                        item.Details = ((IEnumerable<dynamic>)result[3]!).Where(r => r.LicensePlates == item.LicensePlates);
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
        public async Task<IActionResult> ReportVehicleHistories([FromBody] CmpnSearch request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Histories" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.All = result[0];
                    results.Teams = result[1];
                    results.Vehicles = (IEnumerable<dynamic>)result[2]!;
                    foreach (var item in results.Vehicles)
                    {
                        item.Details = ((IEnumerable<dynamic>)result[3]!).Where(r => r.LicensePlates == item.LicensePlates);
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
        public async Task<IActionResult> ReportMaterialVehicles([FromBody] CmpnSearch request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rpt_MaterialByVehicle" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.All = result[0];
                    results.Teams = result[1];
                    results.Materials = (IEnumerable<dynamic>)result[2]!;
                    foreach (var item in results.Materials)
                    {
                        item.Details = ((IEnumerable<dynamic>)result[3]!).Where(r => r.MaterialID == item.MaterialID);
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
        public async Task<IActionResult> RoutePerformances([FromBody] Cmpn request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RoutePerformances" },
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
        public async Task<IActionResult> VehiclePerformances([FromBody] Cmpn request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "VehiclePerformances" },
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
        public async Task<IActionResult> TotalVehicleCondition([FromBody] Cmpn request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_TotalVehiceCondition" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.Summary = result[0];
                    results.Vehicles = result[1];
                    foreach (var item in results.Vehicles)
                    {
                        item.Details = ((IEnumerable<dynamic>)result[2]!).Where(r => r.LicensePlates == item.LicensePlates);
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
        public async Task<IActionResult> ReportMaterialLatestPurchasePrice([FromBody] Cmpn request)
        {
            try
            {
                // Lấy CompanyCode (LemonID)
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetByID" },
                    { "@ID", _UserInfo.CmpnID }
                };

                DataResponse configResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecCompanyConfigs", null!);
                string companyCode = configResponse.Result?[0]?[0]?.LemonID ?? "";

                if (string.IsNullOrEmpty(companyCode))
                    return Ok(new DataResponse("Không tìm thấy CompanyCode (LemonID)", "", "-1"));

                // Convert sang định dạng yyyyMMdd không dấu gạch cho Kim Tin API
                string dateFromKimTin = string.IsNullOrEmpty(request.FromDate)
                    ? DateTime.Now.AddMonths(-1).ToString("yyyyMMdd")
                    : Convert.ToDateTime(request.FromDate).ToString("yyyyMMdd");

                string dateToKimTin = string.IsNullOrEmpty(request.ToDate)
                    ? DateTime.Now.ToString("yyyyMMdd")
                    : Convert.ToDateTime(request.ToDate).ToString("yyyyMMdd");

                // Gọi API Kim Tin
                string jsonData = await _kimTinService.GetMaterialWithLatestPurchasePrice(
                    companyCode, "%", dateFromKimTin, dateToKimTin);

                string jsonDataHistory = await _kimTinService.GetPurchaseHistory(
                    companyCode, dateFromKimTin, dateToKimTin);


                // Truyền xuống DB giữ nguyên định dạng có dấu gạch (2026-11-31)
                parameters = new Dictionary<string, object>
                {
                    { "@type", "Rp_MaterialLatestPurchasePrice" },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@JsonData", jsonData },
                    { "@JsonData1", jsonDataHistory },
                    { "@FromDate", request.FromDate },     // giữ nguyên 2026-11-31
                    { "@ToDate", request.ToDate },         // giữ nguyên 2026-11-31
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@language", _UserInfo.Language }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 3)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();

                    var materials = ((IEnumerable<dynamic>)result[0]).ToList();
                    var materialDetails = ((IEnumerable<dynamic>)result[1]).ToList();
                    var purchaseMasters = ((IEnumerable<dynamic>)result[2]).ToList();
                    var purchaseDetails = ((IEnumerable<dynamic>)result[3]).ToList();

                    foreach (var m in materials)
                    {
                        // ✅ Material Detail (Result 2)
                        m.Details = materialDetails
                            .Where(d => d.InventoryID == m.InventoryID)
                            .ToList();

                        // ✅ Purchase Master theo Inventory (ẩn, dùng khi click)
                        var purchases = purchaseMasters
                            .Where(p => p.InventoryID == m.InventoryID)
                            .ToList();

                        foreach (var p in purchases)
                        {
                            // ✅ Purchase Detail
                            p.Details = purchaseDetails
                                .Where(d => d.InventoryID == p.InventoryID)
                                         
                                .ToList();
                        }

                        // 👇 gắn vào Material
                        m.Purchases = purchases;
                    }

                    results.Materials = materials;
                    dataResponse.Result = results;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> ReportPurchaseHistory([FromBody] Cmpn request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "GetByID" },
        //            { "@ID", _UserInfo.CmpnID }
        //        };

        //        DataResponse configResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecCompanyConfigs", null!);
        //        string companyCode = configResponse.Result?[0]?[0]?.LemonID ?? "";

        //        if (string.IsNullOrEmpty(companyCode))
        //            return Ok(new DataResponse("Không tìm thấy CompanyCode (LemonID)", "", "-1"));

        //        // Convert sang yyyyMMdd cho Kim Tin
        //        string dateFromKimTin = string.IsNullOrEmpty(request.FromDate)
        //            ? DateTime.Now.AddMonths(-1).ToString("yyyyMMdd")
        //            : Convert.ToDateTime(request.FromDate).ToString("yyyyMMdd");

        //        string dateToKimTin = string.IsNullOrEmpty(request.ToDate)
        //            ? DateTime.Now.ToString("yyyyMMdd")
        //            : Convert.ToDateTime(request.ToDate).ToString("yyyyMMdd");

        //        string jsonData = await _kimTinService.GetPurchaseHistory(
        //            companyCode, dateFromKimTin, dateToKimTin);
             
        //        parameters = new Dictionary<string, object>
        //        {
        //            { "@type", "Rp-PurchaseHistory" },
        //            { "@CmpnID", _UserInfo.CmpnID },
        //            { "@JsonData", jsonData },
        //            { "@FromDate", request.FromDate },   // giữ nguyên dạng có dấu -
        //            { "@ToDate", request.ToDate },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@language", _UserInfo.Language }
        //        };

        //        DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

    }
}