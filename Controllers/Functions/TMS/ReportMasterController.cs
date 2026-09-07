using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.ReportMasters.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.ReportMasters")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ReportMasterController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecReportMasters";

        public ReportMasterController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        /// <summary>
        /// Get Period
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> GetPeriod()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-PERIOD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// nhật ký vận chuyển
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> ReportShippingMasters([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_Shipping_Masters" },
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

        /// <summary>
        /// nhật ký vận chuyển
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> ReportShippingDetails([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_Shipping_Details" },
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

        /// <summary>
        /// nhật ký đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportContractDetails([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_Contract_Details" },
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

        /// <summary>
        /// Hiệu suất xe
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportVehiclePerformance([FromBody] FindByVehicleTeamByPeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_VehiclePerformance" },
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

        /// <summary>
        /// Hiệu suất xe tổng hợp (chi tiết)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportVehiclePerformanceDetail([FromBody] FindFromToDatePeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_VehiclePerformanceDetail" },
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

        /// <summary>
        /// Hiệu suất xe tổng hợp
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportVehiclePerformanceTotal([FromBody] FindFromToDatePeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_VehiclePerformanceTotal" },
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

        /// <summary>
        /// Dầu đổ ngoài
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportGasOutSide([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_GasOutSide" },
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

        /// <summary>
        /// Phí nâng/hạ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportFeeLOLO([FromBody] FindByManagementRegionID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_FeeLOLO" },
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

        /// <summary>
        /// Phí nâng/hạ tổng hợp
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportFeeLOLOMaster([FromBody] FindByManagementRegionID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_FeeLOLOMaster" },
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

        /// <summary>
        /// Phí phát sinh/ doanh thu phát sinh
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportIncurred([FromBody] FindDateByType request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
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

        /// <summary>
        /// Gia hạn giấy tờ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportRenewDoc([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_RenewDoc" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.TeamLists = dataResponse.Result[0];
                    foreach (var item in result.TeamLists)
                    {
                        item.ListTotals = ((IEnumerable<dynamic>)dataResponse.Result[1]!).Where(r => r.VehicleTeamID == item.VehicleTeamID);
                    }

                    result.ListPivots = ((IEnumerable<dynamic>)dataResponse.Result[2]!);
                    foreach (var itemPV in result.ListPivots)
                    {
                        itemPV.Details = ((IEnumerable<dynamic>)dataResponse.Result[3]!).Where(r => r.LicensePlates == itemPV.LicensePlates);
                    }

                    result.RenewDocDetails = ((IEnumerable<dynamic>)dataResponse.Result[3]!);

                    dataResponse.Result = result;
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// sự cố, sửa chửa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportIncident([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_Incident" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.TeamLists = dataResponse.Result[0];
                    foreach (var item in result.TeamLists)
                    {
                        item.ListTotals = ((IEnumerable<dynamic>)dataResponse.Result[1]!).Where(r => r.VehicleTeamID == item.VehicleTeamID);
                    }

                    result.IncidentDetails = ((IEnumerable<dynamic>)dataResponse.Result[2]!);

                    dataResponse.Result = result;
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Chênh lệch GPS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportKmDifferenceGPS([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_GPS" },
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

        /// <summary>
        /// Chốt dầu tài xế
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportDebitOil([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_DebitOil" },
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

        /// <summary>
        /// Theo dõi tài vế vào làm/nghỉ làm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportDriverInOut([FromBody] FindCmpnID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_Driver" },
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

        /// <summary>
        /// Hiệu suất chuyến ghép, cặp cổ, tăng bo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportShippingPerformance([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_ShippingPerformance" },
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

        /// <summary>
        /// Hiệu suất chuyến ghép
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportShippingJoinTrip([FromBody] FindByVehicleTeamByPeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_ShippingJoinTrip" },
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

        /// <summary>
        /// Hiệu suất chuyến ghép tổng hợp
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportShippingJoinTripTotal([FromBody] FindFromToDatePeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_ShippingJoinTripTotal" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result[0]!.Json is not null)
                {
                    dataResponse.Result = JsonSerializer.Deserialize<dynamic>(dataResponse.Result[0].Json);
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Báo cáo đơn hàng ngày
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportSaleByDay([FromBody] FindODate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_SaleDay" },
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

        /// <summary>
        /// Theo dõi tài vế vào làm/nghỉ làm theo năm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportDriverPairshipTotal([FromBody] FindByVehicleTeamByPeriodYear request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_DriverPairshipTotal" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.LitsTeams = dataResponse.Result[0];
                    foreach (var item in result.LitsTeams)
                    {
                        item.ListTotals = ((IEnumerable<dynamic>)dataResponse.Result[1]!).Where(r => r.VehicleTeamID == item.VehicleTeamID);
                    }

                    result.PairshipDetails = ((IEnumerable<dynamic>)dataResponse.Result[2]!);

                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Theo dõi tài vế vào làm/nghỉ làm theo tháng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportDriverPairship([FromBody] FindByVehicleTeamByPeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_DriverPairship" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.LitsTeams = dataResponse.Result[0];
                    result.PairshipDetails = ((IEnumerable<dynamic>)dataResponse.Result[1]!);
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Tạm ứng tài xế
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportPayDriver([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_PayDriver" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.LitsTeams = dataResponse.Result[0];

                    result.ListDrviers = ((IEnumerable<dynamic>)dataResponse.Result[1]!);
                    foreach (var itemDetails in result.ListDrviers)
                    {
                        itemDetails.Details = ((IEnumerable<dynamic>)dataResponse.Result[2]!).Where(r => r.DriverID == itemDetails.DriverID);
                    }

                    result.ListDetails = ((IEnumerable<dynamic>)dataResponse.Result[2]!);
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Doanh thu đơn hàng theo ngày
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportShippingRev([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_RevShipping" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.LitsTeams = dataResponse.Result[0];
                    foreach (var itemDetails in result.LitsTeams)
                    {
                        itemDetails.ListTotalEntrys = ((IEnumerable<dynamic>)dataResponse.Result[1]!).Where(r => r.VehicleTeamID == itemDetails.VehicleTeamID);
                        itemDetails.ListTotalGoodTypes = ((IEnumerable<dynamic>)dataResponse.Result[3]!).Where(r => r.VehicleTeamID == itemDetails.VehicleTeamID);
                        itemDetails.ListTotalRoutes = ((IEnumerable<dynamic>)dataResponse.Result[2]!).Where(r => r.VehicleTeamID == itemDetails.VehicleTeamID);
                    }

                    result.ListDetails = ((IEnumerable<dynamic>)dataResponse.Result[4]!);
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lương cẩu cho tài xế
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportCraneShippingRevFee([FromBody] FindByVehicleTeamByDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_CraneShipping" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.LitsTeams = dataResponse.Result[0];
                    result.LitsDrivers = ((IEnumerable<dynamic>)dataResponse.Result[1]!);
                    foreach (var itemDetails in result.LitsDrivers)
                    {
                        itemDetails.Details = ((IEnumerable<dynamic>)dataResponse.Result[2]!).Where(r => r.LicensePlates == itemDetails.LicensePlates);
                    }
                    result.ListDetails = ((IEnumerable<dynamic>)dataResponse.Result[2]!);
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Doanh thu đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportSaleRev([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RP_SaleDetails" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.AllContracts = dataResponse.Result[0];
                    foreach (var itemDetails in result.AllContracts)
                    {
                        itemDetails.ListTotalEntrys = ((IEnumerable<dynamic>)dataResponse.Result[1]!);
                        itemDetails.ListTotalGoodTypes = ((IEnumerable<dynamic>)dataResponse.Result[2]!);
                        itemDetails.ListTotalRoutes = ((IEnumerable<dynamic>)dataResponse.Result[3]!);
                        itemDetails.ListUsers = ((IEnumerable<dynamic>)dataResponse.Result[4]!);
                        itemDetails.ListCustomers = ((IEnumerable<dynamic>)dataResponse.Result[5]!);
                        itemDetails.ListAreas = ((IEnumerable<dynamic>)dataResponse.Result[6]!);
                        itemDetails.ListProductTypes = ((IEnumerable<dynamic>)dataResponse.Result[7]!);
                        itemDetails.ListGroupRoutes = ((IEnumerable<dynamic>)dataResponse.Result[8]!);
                    }

                    result.ListContracts = ((IEnumerable<dynamic>)dataResponse.Result[9]!);
                    foreach (var itemsDetails in result.ListContracts)
                    {
                        itemsDetails.DetailShippings = ((IEnumerable<dynamic>)dataResponse.Result[10]!).Where(r => r.ReferenceID == itemsDetails.OID);
                    }
                    result.ListShippings = ((IEnumerable<dynamic>)dataResponse.Result[10]!);
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Doanh thu đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportSaleOutSide([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_SaleOutside" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.NCCAlls = dataResponse.Result[0];
                    result.NCCOutSides = dataResponse.Result[1];
                    result.ListContracts = ((IEnumerable<dynamic>)dataResponse.Result[2]!);
                    foreach (var itemsDetails in result.ListContracts)
                    {
                        itemsDetails.DetailShippings = ((IEnumerable<dynamic>)dataResponse.Result[3]!).Where(r => r.ReferenceID == itemsDetails.OID);
                    }
                    result.ListShippings = ((IEnumerable<dynamic>)dataResponse.Result[3]!);
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        /// <summary>
        /// Doanh thu đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportSaleOutSideByID([FromBody] FindByOutsideID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_SaleOutside_ByID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.NCCOutSides = dataResponse.Result[0];
                    result.ListShipping = dataResponse.Result[1];
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
        public async Task<IActionResult> ReportSaleByRegion([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RP_SaleByRegion" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.Summary = dataResponse.Result[0];
                    result.Details = dataResponse.Result[1];

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
        public async Task<IActionResult> ReportSaleByTop15Customer([FromBody] FindByType request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RP_Top15Customer" },
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


        /// <summary>
        /// Doanh thu đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportSalePlan([FromBody] FindYear request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_SaleByPlan" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.Rp_Customers = dataResponse.Result[0];
                    result.Rp_OrderTypes = dataResponse.Result[1];
                    result.Rp_GoodTypes = dataResponse.Result[2];
                    result.Rp_OutSides = dataResponse.Result[3];

                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thánh toán phí cho tài xế
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportPaymentFeeByDriver([FromBody] FindByVehicleTeamByPeriod request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "PaymentFee" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.Total = dataResponse.Result[0];
                    result.Drivers = dataResponse.Result[1];
                    foreach (var itemDetails in result.Drivers)
                    {
                        itemDetails.DetailFees = ((IEnumerable<dynamic>)dataResponse.Result[2]!).Where(r => r.DriverID == itemDetails.DriverID);
                        itemDetails.DetailSalarys = ((IEnumerable<dynamic>)dataResponse.Result[3]!).Where(r => r.DriverID == itemDetails.DriverID);
                    }

                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thánh toán phí cho tài xế
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportPaymentFeeByDriverID([FromBody] FindByDrvierID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "PaymentFee_ByDriver" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.DetailFees = dataResponse.Result[0];
                    result.DetailSalarys = dataResponse.Result[1];

                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Vé ETC lời lỗ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportETC([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RP_ADACost" },
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

        /// <summary>
        /// Điều độ thao tác yêu cầu tài xế
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReportCoordinatorShipping([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_CoordinatorShipping" },
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


        /// <summary>
        /// Báo cáo khách hàng theo tuyến
        /// </summary>
        //[HttpPost]
        //public async Task<IActionResult> ReportRouteCustomer([FromBody] FindDate request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //{
        //    { "@type", "Rp_Route_Customer" },
        //    { "@language", _UserInfo.Language },
        //    { "@UserIDCurent", _UserInfo.UserID }
        //};

        //        DataResponse dataResponse = await GetDataResponse(
        //            parameters,
        //            _nPLDB,
        //            _ConfigurationDB,
        //            _ProcedureName,
        //            request
        //        );

        //        // ===============================
        //        // RESULT FROM STORE
        //        // ===============================
        //        var summary = dataResponse.Result[0];   // #CustomerSummary
        //        var pivotData = dataResponse.Result[1]; // Pivot result
        //        var routeMap = dataResponse.Result[2];  // RouteIndex map

        //        // ===============================
        //        // MAP ROUTE INDEX (R1, R2...)
        //        // ===============================
        //        var routeDict = new Dictionary<string, (string RouteCode, string RouteName)>();

        //        foreach (dynamic r in routeMap)
        //        {
        //            routeDict[r.RouteKey] = (
        //                (string)r.RouteCode,
        //                (string)r.RouteName
        //            );
        //        }

        //        // ===============================
        //        // BUILD DETAILS
        //        // ===============================
        //        var details = new List<dynamic>();

        //        foreach (dynamic row in pivotData)
        //        {
        //            IDictionary<string, object> rowDict = row as IDictionary<string, object>;

        //            dynamic customer = new ExpandoObject();
        //            customer.CustomerID = rowDict["CustomerID"];
        //            customer.CustomerName = rowDict["CustomerName"];

        //            var routes = new List<dynamic>();

        //            foreach (var route in routeDict)
        //            {
        //                string routeKey = route.Key; // R1, R2...

        //                dynamic routeObj = new ExpandoObject();
        //                routeObj.RouteCode = route.Value.RouteCode;
        //                routeObj.RouteName = route.Value.RouteName;

        //                string giaBanKey = $"{routeKey}_PriceShipping";
        //                string giaMuaKey = $"{routeKey}_PriceOutside";

        //                routeObj.PriceShipping = rowDict.ContainsKey(giaBanKey)
        //                    ? rowDict[giaBanKey] ?? 0
        //                    : 0;

        //                routeObj.PriceOutside = rowDict.ContainsKey(giaMuaKey)
        //                    ? rowDict[giaMuaKey] ?? 0
        //                    : 0;

        //                routes.Add(routeObj);
        //            }

        //            customer.Routes = routes;
        //            details.Add(customer);
        //        }

        //        // ===============================
        //        // FINAL RESULT
        //        // ===============================
        //        dynamic result = new ExpandoObject();
        //        result.Summary = summary;
        //        result.Details = details;

        //        dataResponse.Result = result;
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}


        /// <summary>
        /// Báo cáo khách hàng theo tuyến
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ReportRouteCustomer([FromBody] FindDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Rp_Route_Customer" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.Summary = dataResponse.Result[0];
                    result.DetailCustomers = dataResponse.Result[1];
                    result.DetailRoutes = dataResponse.Result[2];

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