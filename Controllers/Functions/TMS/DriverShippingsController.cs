using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using APISmartCity.TransferServices;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.lib.Function;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.DriverShippings")]
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class DriverShippingsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _CategoryDB;
        private readonly DBFolder _SettingOther;
        private readonly TransferService _transferService;
        private readonly string _ProcedureName = "ExecShippings";

        public DriverShippingsController(UserInfo userInfo, TransferService transferService)
        {
            _transferService = transferService;
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "AttachFiles")!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Shippings.Request.GetByTypeList request)
        {
            try
            {
                //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
                //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "Get", jwtToken);
                //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
                string typeCall = "";
                switch (request.Type)
                {
                    case "WaitingApproval":
                        typeCall = "Get-WaitingDriverApproval";
                        break;

                    case "Received":
                        typeCall = "Get-DriverApproval";
                        break;

                    case "Shipping":
                        typeCall = "Get-DriverShipping";
                        break;

                    case "Finish":
                        typeCall = "Get-DriverFinish";
                        break;
                }
                Dictionary<string, object> parameters = new()
                {
                    { "@type", typeCall },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    var results = (IEnumerable<dynamic>)result[0]!;
                    //foreach (var item in results)
                    //{
                    //    item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);

                    //    foreach (var ship in item.Contracts)
                    //    {
                    //        ship.ShipTypes = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ship.ReferenceID);
                    //        foreach (var dt in ship.ShipTypes)
                    //        {
                    //            dt.ShippingDetails = ((IEnumerable<dynamic>)result[3]!).Where(r => r.OID == dt.OID &&  r.ShipType == dt.ShipType);
                    //        }
                    //    }
                    //}

                    //foreach (var item in results)
                    //{
                    //    item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
                    //    foreach (var ct in item.Contracts)
                    //    {
                    //        ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID);
                    //        foreach (var sp in ct.ShipPoints)
                    //        {
                    //            sp.ShipTypes = ((IEnumerable<dynamic>)result[3]!);
                    //            foreach (var st in sp.ShipTypes)
                    //            {
                    //                st.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.ShipType == st.ShipType && r.ShipPoint == sp.ShipPoint && r.OID == sp.OID);
                    //            }
                    //        }
                    //    }
                    //}

                    foreach (var item in results)
                    {
                        item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
                        foreach (var ct in item.Contracts)
                        {
                            //ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID);
                            //foreach (var sp in ct.ShipPoints)
                            //{
                            //    sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
                            //}

                            ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID && r.ReferenceID == ct.OID);
                            foreach (var sp in ct.ShipPoints)
                            {
                                sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                                //sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                            }
                        }
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
        public async Task<IActionResult> DriverApproval([FromBody] Shippings.Request.Approval request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "DriverApproval", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DriverApproval" },
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
        public async Task<IActionResult> GetListVehicleCrane()
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(null, "DriverShippings", "GetListVehicleCrane", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ListVehicleCrane" },
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

        [HttpPost]
        public async Task<IActionResult> EditVehicleCrane([FromBody] Shippings.Request.EditLicensePlates request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "EditVehicleCrane", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Edit-VehicleCrane" },
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
        public async Task<IActionResult> DriverShipping([FromBody] Shippings.Request.GetByOID request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "DriverShipping", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Driver-Shipping" },
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
        public async Task<IActionResult> GetDriverCancelReasonsApproval()
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(null, "DriverShippings", "GetDriverCancelReasonsApproval", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DriverCancelReasonsApproval" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> GetListFee()
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(null, "DriverShippings", "GetListFee", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ListFee" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> AddFee([FromBody] Shippings.Request.AddFeeByIncurreds request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "AddFee", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@FeeType", "FEE" },
                    { "@IsAddByDriver", "1" }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByIncurreds", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DriverCancelFee([FromBody] Shippings.Request.GetByID request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "DriverCancelFee", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DriverCancel" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByIncurreds", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DriverUpdateStatus([FromBody] Shippings.Request.DriverUpdate request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "DriverUpdateStatus", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DriverUpdateStatus" },
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

        //[HttpPost]
        //public async Task<IActionResult> GetDetailByOIDAndReferenceID([FromBody] Shippings.Request.GetByDetails request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "Get-DetailsByOIDAndReferenceID" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@CmpnID", _UserInfo.CmpnID }
        //        };
        //        DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
        //        if (dataResponse.Result!.Count > 1)
        //        {
        //            dynamic result = dataResponse.Result;
        //            var results = (IEnumerable<dynamic>)result[0]!;
        //            foreach (var item in results)
        //            {
        //                item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
        //                foreach (var ct in item.Contracts)
        //                {
        //                    ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID);
        //                    foreach (var sp in ct.ShipPoints)
        //                    {
        //                        sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
        //                    }
        //                }
        //                item.Lines = ((IEnumerable<dynamic>)result[5]!);
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
        public async Task<IActionResult> GetDetailByOIDAndReferenceID([FromBody] Shippings.Request.GetByDetails request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "GetDetailByOIDAndReferenceID", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DetailsByOIDAndReferenceID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    var results = (IEnumerable<dynamic>)result[0]!;
                    foreach (var item in results)
                    {
                        item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
                        item.DetailsByIncurreds = ((IEnumerable<dynamic>)result[6]!);
                        item.DetailsAttachFiles = ((IEnumerable<dynamic>)result[7]!);
                        foreach (var ct in item.Contracts)
                        {
                            //ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID);
                            //foreach (var sp in ct.ShipPoints)
                            //{
                            //    sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
                            //    sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
                            //}
                            ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID && r.ReferenceID == ct.OID);
                            foreach (var sp in ct.ShipPoints)
                            {
                                sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                                sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                            }
                        }
                        item.Lines = ((IEnumerable<dynamic>)result[5]!);
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
        public async Task<IActionResult> GetChargeStationsByOID([FromBody] Shippings.Request.GetByOID request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "GetChargeStationsByOID", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ChargeStationsByOID" },
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
        public async Task<IActionResult> CalculateDepotDistance([FromBody] Shippings.Request.DriverPosition request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverShippings", "CalculateDepotDistance", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "CalculateDepotDistance" },
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
        public async Task<IActionResult> GetFeeByDriver([FromBody] Shippings.Request.GetByDetails request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-FeeByOIDAndDriver" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "[ExecShippingsDetailsByIncurreds]", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}