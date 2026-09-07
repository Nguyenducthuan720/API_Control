using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.VietmapGeocodeServices;
using Dapper;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.SaleContracts.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.SaleContracts")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class SaleContractsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _CategoryDB;
        private readonly DBFolder _SettingOther;
        private readonly string _ProcedureName = "ExecSaleContracts";
        private readonly VietmapGeocodeService _services;
        private readonly KimTinService _kimTinService;

        public SaleContractsController(UserInfo userInfo, VietmapGeocodeService service, KimTinService kimTinService)
        {
            this._UserInfo = userInfo;
            _services = service;
            _kimTinService = kimTinService; 
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "AttachFiles")!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", "1"}
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
        public async Task<IActionResult> GetMultiClose([FromBody] FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-Multi-Close" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", "1"}
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
        public async Task<IActionResult> AutoComplete([FromBody] GeoCode request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", request!);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    List<Models.Logistics.VietMap.Request.RefID> addrequest = await _services.GeoCode(request.Address);
                    if (addrequest?.Count == 0)
                    {
                        return Ok(new DataResponse("Api not found address", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRefID" },
                            { "@language", _UserInfo.Language },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataTable RefID = addrequest.ToDataTable();
                        RefID.SetTypeName("RefID");
                        addparameters.Add("@REFID", RefID);
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", request!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VietMapRoute([FromBody] GetRoute request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetRoute" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", request!);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    string json = await _services.Route(request.StringPoint);
                    if (json is null)
                    {
                        return Ok(new DataResponse("Api not found", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRoute" },
                            { "@language", _UserInfo.Language },
                            { "@json", json },
                            { "@StringPoint", request.StringPoint },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", null!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VietMapTSP([FromBody] GetRoute request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetRoute" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", request!);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    string json = await _services.TSP(request.StringPoint);
                    if (json is null)
                    {
                        return Ok(new DataResponse("Api not found", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRoute" },
                            { "@language", _UserInfo.Language },
                            { "@json", json },
                            { "@StringPoint", request.StringPoint },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", null!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Place([FromBody] GetLatLong request)
        {
            try
            {
                var result = await _services.Place(request.RefId);
                if (result is null)
                {
                    return Ok(new DataResponse("Api not found lat long", "", "-1"));
                }
                else
                {
                    Dictionary<string, object> parameters = new()
                    {
                        { "@type", "Add" },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID },
                        { "@Lat", result.Lat },
                        { "@Long", result.Long },
                        { "@ReferenceID", request.RefId }
                    };
                    DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", null);
                    return Ok(dataResponse);
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> GetGeoCode([FromBody] GeoCode request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "GET" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID }
        //        };
        //        DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", request!);
        //        if (dataResponse?.ErrorCode == "0")
        //        {
        //            return Ok(dataResponse);
        //        }
        //        else
        //        {
        //            AddGeoCode addrequest = await _services.GeoCode(request.Address);
        //            if (addrequest is null)
        //            {
        //                return Ok(new DataResponse("Api not found address", "", "-1"));
        //            }
        //            else
        //            {
        //                Dictionary<string, object> addparameters = new()
        //            {
        //                { "@type", "Add" },
        //                { "@language", _UserInfo.Language },
        //                { "@UserIDCurent", _UserInfo.UserID }
        //            };
        //                DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, "ExecGeoCodeVietMap", addrequest!);
        //                return Ok(adddataResponse);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] GetByID request)
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
                    result.SaleContractsInvoices = dataResponse.Result[1];
                    result.SaleContractsByConts = dataResponse.Result[2];
                    result.CT_NOBOX_GET = dataResponse.Result[3];
                    result.CT_NOBOX_RETURN = dataResponse.Result[4];
                    result.CT_CONT_IMP_GET_CONT = dataResponse.Result[5];
                    result.CT_CONT_IMP_RETURN_CONT = dataResponse.Result[6];
                    result.CT_CONT_IMP_DOWN_EMPTY = dataResponse.Result[7];
                    result.CT_CONT_EXP_GET_EMPTY = dataResponse.Result[8];
                    result.CT_CONT_EXP_PACKING = dataResponse.Result[9];
                    result.CT_CONT_EXP_DOWN_CONT = dataResponse.Result[10];
                    result.FeeIncurreds = dataResponse.Result[11];
                    result.RevIncurreds = dataResponse.Result[12];
                    result.Properties = dataResponse.Result[13];
                    result.Histories = dataResponse.Result[14];
                    result.Histories = dataResponse.Result[14];
                    result.EstimatedVehicleLogs = dataResponse.Result[16];
                    result.Progress = dataResponse.Result[17];
                    result.TrackingLogs = dataResponse.Result[18];


                    dynamic CT_DETAILS = dataResponse.Result[15];

                    foreach (var item in result.CT_NOBOX_GET)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == item.OID && r.DepotID == item.DepotID);
                    }
                    foreach (var item in result.CT_NOBOX_RETURN)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == item.OID && r.DepotID == item.DepotID);
                    }

                    foreach (var item in result.CT_CONT_IMP_GET_CONT)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == item.OID && r.DepotID == item.DepotID);
                    }
                    foreach (var item in result.CT_CONT_IMP_RETURN_CONT)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == item.OID && r.DepotID == item.DepotID);
                    }

                    foreach (var item in result.CT_CONT_EXP_GET_EMPTY)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == item.OID && r.DepotID == item.DepotID);
                    }
                    foreach (var item in result.CT_CONT_EXP_PACKING)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == item.OID && r.DepotID == item.DepotID);
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

        [HttpPost]
        public async Task<IActionResult> GetByIDCus([FromBody] GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID-CUS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.SaleContractsInvoices = dataResponse.Result[1];
                    result.SaleContractsByConts = dataResponse.Result[2];
                    result.CT_NOBOX_GET = dataResponse.Result[3];
                    result.CT_NOBOX_RETURN = dataResponse.Result[4];
                    result.CT_CONT_IMP_GET_CONT = dataResponse.Result[5];
                    result.CT_CONT_IMP_RETURN_CONT = dataResponse.Result[6];
                    result.CT_CONT_IMP_DOWN_EMPTY = dataResponse.Result[7];
                    result.CT_CONT_EXP_GET_EMPTY = dataResponse.Result[8];
                    result.CT_CONT_EXP_PACKING = dataResponse.Result[9];
                    result.CT_CONT_EXP_DOWN_CONT = dataResponse.Result[10];
                    //[result.FeeIncurreds = dataResponse.Result[11];
                    result.RevIncurreds = dataResponse.Result[12];
                    result.Properties = dataResponse.Result[13];
                    result.Histories = dataResponse.Result[14];
                    dynamic CT_DETAILS = dataResponse.Result[15];
                    foreach (var item in result.CT_NOBOX_GET)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.DepotID == item.ID);
                    }
                    foreach (var item in result.CT_CONT_IMP_GET_CONT)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.DepotID == item.ID);
                    }
                    foreach (var item in result.CT_CONT_EXP_GET_EMPTY)
                    {
                        item.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.DepotID == item.ID);
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

        [HttpPost]
        public async Task<IActionResult> GetBySelectObject()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-SelectObject" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.Customers = dataResponse.Result[0];
                    result.InspectionUnits = dataResponse.Result[1];
                    result.SpecialRequirements = dataResponse.Result[2];

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
        public async Task<IActionResult> GetBySelectCusID([FromBody] GetByCusID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-SelectCusID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.CustomerContacts = dataResponse.Result[0];
                    result.CustomerInvoices = dataResponse.Result[1];
                    result.CustomerRoutes = dataResponse.Result[2];
                    result.CustomerGoodTypes = dataResponse.Result[3];
                    result.CustomerUnits = dataResponse.Result[4];
                    result.CustomerDepots = dataResponse.Result[5];
                    result.CustomerSupports = dataResponse.Result[6];
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
        public async Task<IActionResult> GetByReference()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetReference" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
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
        public async Task<IActionResult> Add([FromBody] Add request)
        {
            try
            {
                //Dictionary<string, object> GetCustomersInfoparameters = new()
                //{
                //    { "@type", "GetCustomersInfo" },
                //    { "@CustomerID", request.CustomerID },
                //    { "@language", _UserInfo.Language },
                //    { "@UserIDCurent", _UserInfo.UserID },
                //    { "@CmpnID", _UserInfo.CmpnID }
                //};
                //DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);

                //if (GetCustomersInfo?.Result.Count >0)
                //{
                //    string CompanyCode = GetCustomersInfo?.Result[0].CompanyCode;
                //    string CustomerID = GetCustomersInfo?.Result[0].CustomerID;

                //    var aa = await _kimTinService.GetData(CompanyCode, CustomerID);
                //    Dictionary<string, object> AddDebitMoneyByCustomersparameters = new()
                //    {
                //        { "@type", "GetCustomersInfo" },
                //        { "@CustomerID", request.CustomerID },
                //        { "@language", _UserInfo.Language },
                //        { "@UserIDCurent", _UserInfo.UserID },
                //        { "@CmpnID", _UserInfo.CmpnID }
                //    };
                //}
                // lấy công nợ khách hàng
                string result = "";
                Dictionary<string, object> GetCustomersInfoparameters = new()
                {
                    { "@type", "GetCustomersInfo" },
                    { "@CustomerID", request.CustomerID },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);

                if (GetCustomersInfo?.Result.Count > 0)
                {
                    string CompanyCode = GetCustomersInfo?.Result[0].CompanyCode;
                    string CustomerID = GetCustomersInfo?.Result[0].CustomerID;
                    result = await _kimTinService.GetDataCreditLimit(CompanyCode, CustomerID);
                    if (result != "[]")
                    {
                        JsonNode jsonNode = JsonSerializer.Deserialize<JsonNode>(result);
                        if (jsonNode is JsonArray)
                        {
                            Dictionary<string, object> AddDebitMoneyByCustomersparameters = new()
                            {
                                { "@type", "AddDebitMoneyByCustomers" },
                                { "@CustomerID", request.CustomerID },
                                { "@LemonName", jsonNode.AsArray()[0]["CustomerID"].GetValue<string>() },
                                { "@CustomerName", jsonNode.AsArray()[0]["CustomerName"].GetValue<string>() },
                                { "@OrigClosingValue", jsonNode.AsArray()[0]["OrigClosingValue"].GetValue<decimal>() },
                                { "@language", _UserInfo.Language },
                                { "@UserIDCurent", _UserInfo.UserID },
                                { "@CmpnID", _UserInfo.CmpnID }
                            };
                            await GetDataResponse(AddDebitMoneyByCustomersparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                        }
                        else
                        {
                            return Ok(new DataResponse("Lemon Error", "", "-1"));
                        }
                    }
                }
                // kết thúc lấy công nợ khách hàng
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                if (request.CT_INVOICE != null)
                {
                    DataTable CT_INVOICE = request.CT_INVOICE.ToDataTable();
                    CT_INVOICE.SetTypeName("CT_INVOICE");
                    parameters.Add("@CT_INVOICE", CT_INVOICE);
                    request.CT_INVOICE = null;
                }

                DataTable CT_GET_DETAILS = new DataTable();
                DataTable CT_RETURN_DETAILS = new DataTable();
                DataTable CT_DOWN_DETAILS = new DataTable();
                if (request.EntryID == "CT_NOBOX")
                {
                    if (request.CT_NOBOX_GET != null)
                    {
                        CT_GET_DETAILS = request.CT_NOBOX_GET.Where(r => r.CT_GET_DETAILS != null).SelectMany(r => r.CT_GET_DETAILS).ToList().ToDataTable();
                        CT_GET_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_GET_DETAILS", CT_GET_DETAILS);
                        DataTable CT_NOBOX_GET = request.CT_NOBOX_GET.ToDataTable();
                        CT_NOBOX_GET.Columns.Remove("CT_GET_DETAILS");
                        CT_NOBOX_GET.SetTypeName("CT_NOBOX_GET");
                        parameters.Add("@CT_NOBOX_GET", CT_NOBOX_GET);
                    }

                    if (request.CT_NOBOX_RETURN != null)
                    {
                        CT_RETURN_DETAILS = request.CT_NOBOX_RETURN.Where(r => r.CT_RETURN_DETAILS != null).SelectMany(r => r.CT_RETURN_DETAILS).ToList().ToDataTable();
                        CT_RETURN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_RETURN_DETAILS", CT_RETURN_DETAILS);

                        DataTable CT_NOBOX_RETURN = request.CT_NOBOX_RETURN.ToDataTable();
                        CT_NOBOX_RETURN.Columns.Remove("CT_RETURN_DETAILS");
                        CT_NOBOX_RETURN.SetTypeName("CT_NOBOX_RETURN");
                        parameters.Add("@CT_NOBOX_RETURN", CT_NOBOX_RETURN);
                    }
                }

                if (request.EntryID == "CT_CONT_IMP")
                {
                    if (request.CT_LISTCONT != null)
                    {
                        DataTable CT_LISTCONT = request.CT_LISTCONT.ToDataTable();
                        CT_LISTCONT.SetTypeName("CT_LISTCONT");
                        parameters.Add("@CT_LISTCONT", CT_LISTCONT);
                    }

                    if (request.CT_CONT_IMP_GET_CONT != null)
                    {
                        CT_GET_DETAILS = request.CT_CONT_IMP_GET_CONT.Where(r => r.CT_GET_DETAILS != null).SelectMany(r => r.CT_GET_DETAILS).ToList().ToDataTable();
                        CT_GET_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_GET_DETAILS", CT_GET_DETAILS);

                        DataTable CT_CONT_IMP_GET_CONT = request.CT_CONT_IMP_GET_CONT.ToDataTable();
                        CT_CONT_IMP_GET_CONT.Columns.Remove("CT_GET_DETAILS");
                        CT_CONT_IMP_GET_CONT.SetTypeName("CT_CONT_IMP_GET_CONT");
                        parameters.Add("@CT_CONT_IMP_GET_CONT", CT_CONT_IMP_GET_CONT);
                    }

                    if (request.CT_CONT_IMP_RETURN_CONT != null)
                    {
                        CT_RETURN_DETAILS = request.CT_CONT_IMP_RETURN_CONT.Where(r => r.CT_RETURN_DETAILS != null).SelectMany(r => r.CT_RETURN_DETAILS).ToList().ToDataTable();
                        CT_RETURN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_RETURN_DETAILS", CT_RETURN_DETAILS);

                        DataTable CT_CONT_IMP_RETURN_CONT = request.CT_CONT_IMP_RETURN_CONT.ToDataTable();
                        CT_CONT_IMP_RETURN_CONT.Columns.Remove("CT_RETURN_DETAILS");
                        CT_CONT_IMP_RETURN_CONT.SetTypeName("CT_CONT_IMP_RETURN_CONT");
                        parameters.Add("@CT_CONT_IMP_RETURN_CONT", CT_CONT_IMP_RETURN_CONT);
                    }

                    if (request.CT_CONT_IMP_DOWN_EMPTY != null)
                    {
                        CT_DOWN_DETAILS = request.CT_CONT_IMP_DOWN_EMPTY.Where(r => r.CT_DOWN_DETAILS != null).SelectMany(r => r.CT_DOWN_DETAILS).ToList().ToDataTable();
                        CT_DOWN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_DOWN_DETAILS", CT_DOWN_DETAILS);

                        DataTable CT_CONT_IMP_DOWN_EMPTY = request.CT_CONT_IMP_DOWN_EMPTY.ToDataTable();
                        CT_CONT_IMP_DOWN_EMPTY.Columns.Remove("CT_DOWN_DETAILS");
                        CT_CONT_IMP_DOWN_EMPTY.SetTypeName("CT_CONT_IMP_DOWN_EMPTY");
                        parameters.Add("@CT_CONT_IMP_DOWN_EMPTY", CT_CONT_IMP_DOWN_EMPTY);
                    }
                }

                if (request.EntryID == "CT_CONT_EXP")
                {
                    if (request.CT_CONT_EXP_GET_EMPTY != null)
                    {
                        CT_GET_DETAILS = request.CT_CONT_EXP_GET_EMPTY.Where(r => r.CT_GET_DETAILS != null).SelectMany(r => r.CT_GET_DETAILS).ToList().ToDataTable();
                        CT_GET_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_GET_DETAILS", CT_GET_DETAILS);

                        DataTable CT_CONT_EXP_GET_EMPTY = request.CT_CONT_EXP_GET_EMPTY.ToDataTable();
                        CT_CONT_EXP_GET_EMPTY.Columns.Remove("CT_GET_DETAILS");
                        CT_CONT_EXP_GET_EMPTY.SetTypeName("CT_CONT_EXP_GET_EMPTY");
                        parameters.Add("@CT_CONT_EXP_GET_EMPTY", CT_CONT_EXP_GET_EMPTY);
                    }

                    if (request.CT_CONT_EXP_PACKING != null)
                    {
                        CT_RETURN_DETAILS = request.CT_CONT_EXP_PACKING.Where(r => r.CT_RETURN_DETAILS != null).SelectMany(r => r.CT_RETURN_DETAILS).ToList().ToDataTable();
                        CT_RETURN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_RETURN_DETAILS", CT_RETURN_DETAILS);

                        DataTable CT_CONT_EXP_PACKING = request.CT_CONT_EXP_PACKING.ToDataTable();
                        CT_CONT_EXP_PACKING.Columns.Remove("CT_RETURN_DETAILS");
                        CT_CONT_EXP_PACKING.SetTypeName("CT_CONT_EXP_PACKING");
                        parameters.Add("@CT_CONT_EXP_PACKING", CT_CONT_EXP_PACKING);
                    }

                    if (request.CT_CONT_EXP_DOWN_CONT != null)
                    {
                        CT_DOWN_DETAILS = request.CT_CONT_EXP_DOWN_CONT.Where(r => r.CT_DOWN_DETAILS != null).SelectMany(r => r.CT_DOWN_DETAILS).ToList().ToDataTable();
                        CT_DOWN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_DOWN_DETAILS", CT_DOWN_DETAILS);

                        DataTable CT_CONT_EXP_DOWN_CONT = request.CT_CONT_EXP_DOWN_CONT.ToDataTable();
                        CT_CONT_EXP_DOWN_CONT.Columns.Remove("CT_DOWN_DETAILS");
                        CT_CONT_EXP_DOWN_CONT.SetTypeName("CT_CONT_EXP_DOWN_CONT");
                        parameters.Add("@CT_CONT_EXP_DOWN_CONT", CT_CONT_EXP_DOWN_CONT);
                    }
                }

                request.CT_NOBOX_GET = null;
                request.CT_NOBOX_RETURN = null;
                request.CT_LISTCONT = null;
                request.CT_CONT_IMP_GET_CONT = null;
                request.CT_CONT_IMP_RETURN_CONT = null;
                request.CT_CONT_IMP_DOWN_EMPTY = null;
                request.CT_CONT_EXP_GET_EMPTY = null;
                request.CT_CONT_EXP_PACKING = null;
                request.CT_CONT_EXP_DOWN_CONT = null;

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
                // lấy công nợ khách hàng
                string result = "";
                Dictionary<string, object> GetCustomersInfoparameters = new()
                {
                    { "@type", "GetCustomersInfo" },
                    { "@CustomerID", request.CustomerID },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);

                if (GetCustomersInfo?.Result.Count > 0)
                {
                    string CompanyCode = GetCustomersInfo?.Result[0].CompanyCode;
                    string CustomerID = GetCustomersInfo?.Result[0].CustomerID;
                    result = await _kimTinService.GetDataCreditLimit(CompanyCode, CustomerID);
                    if (result != "[]")
                    {
                        JsonNode jsonNode = JsonSerializer.Deserialize<JsonNode>(result);
                        Dictionary<string, object> AddDebitMoneyByCustomersparameters = new()
                        {
                            { "@type", "AddDebitMoneyByCustomers" },
                            { "@CustomerID", request.CustomerID },
                            { "@LemonName", jsonNode.AsArray()[0]["CustomerID"].GetValue<string>() },
                            { "@CustomerName", jsonNode.AsArray()[0]["CustomerName"].GetValue<string>() },
                            { "@OrigClosingValue", jsonNode.AsArray()[0]["OrigClosingValue"].GetValue<decimal>() },
                            { "@language", _UserInfo.Language },
                            { "@UserIDCurent", _UserInfo.UserID },
                            { "@CmpnID", _UserInfo.CmpnID }
                        };
                        await GetDataResponse(AddDebitMoneyByCustomersparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                    }
                }
                // kết thúc lấy công nợ khách hàng
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                if (request.CT_INVOICE != null)
                {
                    DataTable CT_INVOICE = request.CT_INVOICE.ToDataTable();
                    CT_INVOICE.SetTypeName("CT_INVOICE");
                    parameters.Add("@CT_INVOICE", CT_INVOICE);
                    request.CT_INVOICE = null;
                }

                DataTable CT_GET_DETAILS = new DataTable();
                DataTable CT_RETURN_DETAILS = new DataTable();
                DataTable CT_DOWN_DETAILS = new DataTable();
                if (request.EntryID == "CT_NOBOX")
                {
                    if (request.CT_NOBOX_GET != null)
                    {
                        CT_GET_DETAILS = request.CT_NOBOX_GET.Where(r => r.CT_GET_DETAILS != null).SelectMany(r => r.CT_GET_DETAILS).ToList().ToDataTable();
                        CT_GET_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_GET_DETAILS", CT_GET_DETAILS);

                        DataTable CT_NOBOX_GET = request.CT_NOBOX_GET.ToDataTable();
                        CT_NOBOX_GET.Columns.Remove("CT_GET_DETAILS");
                        CT_NOBOX_GET.SetTypeName("CT_NOBOX_GET");
                        parameters.Add("@CT_NOBOX_GET", CT_NOBOX_GET);
                    }

                    if (request.CT_NOBOX_RETURN != null)
                    {
                        CT_RETURN_DETAILS = request.CT_NOBOX_RETURN.Where(r => r.CT_RETURN_DETAILS != null).SelectMany(r => r.CT_RETURN_DETAILS).ToList().ToDataTable();
                        CT_RETURN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_RETURN_DETAILS", CT_RETURN_DETAILS);

                        DataTable CT_NOBOX_RETURN = request.CT_NOBOX_RETURN.ToDataTable();
                        CT_NOBOX_RETURN.Columns.Remove("CT_RETURN_DETAILS");
                        CT_NOBOX_RETURN.SetTypeName("CT_NOBOX_RETURN");
                        parameters.Add("@CT_NOBOX_RETURN", CT_NOBOX_RETURN);
                    }
                }

                if (request.EntryID == "CT_CONT_IMP")
                {
                    if (request.CT_LISTCONT != null)
                    {
                        DataTable CT_LISTCONT = request.CT_LISTCONT.ToDataTable();
                        CT_LISTCONT.SetTypeName("CT_LISTCONT");
                        parameters.Add("@CT_LISTCONT", CT_LISTCONT);
                    }

                    if (request.CT_CONT_IMP_GET_CONT != null)
                    {
                        CT_GET_DETAILS = request.CT_CONT_IMP_GET_CONT.Where(r => r.CT_GET_DETAILS != null).SelectMany(r => r.CT_GET_DETAILS).ToList().ToDataTable();
                        CT_GET_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_GET_DETAILS", CT_GET_DETAILS);

                        DataTable CT_CONT_IMP_GET_CONT = request.CT_CONT_IMP_GET_CONT.ToDataTable();
                        CT_CONT_IMP_GET_CONT.Columns.Remove("CT_GET_DETAILS");
                        CT_CONT_IMP_GET_CONT.SetTypeName("CT_CONT_IMP_GET_CONT");
                        parameters.Add("@CT_CONT_IMP_GET_CONT", CT_CONT_IMP_GET_CONT);
                    }

                    if (request.CT_CONT_IMP_RETURN_CONT != null)
                    {
                        CT_RETURN_DETAILS = request.CT_CONT_IMP_RETURN_CONT.Where(r => r.CT_RETURN_DETAILS != null).SelectMany(r => r.CT_RETURN_DETAILS).ToList().ToDataTable();
                        CT_RETURN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_RETURN_DETAILS", CT_RETURN_DETAILS);

                        DataTable CT_CONT_IMP_RETURN_CONT = request.CT_CONT_IMP_RETURN_CONT.ToDataTable();
                        CT_CONT_IMP_RETURN_CONT.Columns.Remove("CT_RETURN_DETAILS");
                        CT_CONT_IMP_RETURN_CONT.SetTypeName("CT_CONT_IMP_RETURN_CONT");
                        parameters.Add("@CT_CONT_IMP_RETURN_CONT", CT_CONT_IMP_RETURN_CONT);
                    }

                    if (request.CT_CONT_IMP_DOWN_EMPTY != null)
                    {
                        CT_DOWN_DETAILS = request.CT_CONT_IMP_DOWN_EMPTY.Where(r => r.CT_DOWN_DETAILS != null).SelectMany(r => r.CT_DOWN_DETAILS).ToList().ToDataTable();
                        CT_DOWN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_DOWN_DETAILS", CT_DOWN_DETAILS);

                        DataTable CT_CONT_IMP_DOWN_EMPTY = request.CT_CONT_IMP_DOWN_EMPTY.ToDataTable();
                        CT_CONT_IMP_DOWN_EMPTY.Columns.Remove("CT_DOWN_DETAILS");
                        CT_CONT_IMP_DOWN_EMPTY.SetTypeName("CT_CONT_IMP_DOWN_EMPTY");
                        parameters.Add("@CT_CONT_IMP_DOWN_EMPTY", CT_CONT_IMP_DOWN_EMPTY);
                    }
                }

                if (request.EntryID == "CT_CONT_EXP")
                {
                    if (request.CT_CONT_EXP_GET_EMPTY != null)
                    {
                        CT_GET_DETAILS = request.CT_CONT_EXP_GET_EMPTY.Where(r => r.CT_GET_DETAILS != null).SelectMany(r => r.CT_GET_DETAILS).ToList().ToDataTable();
                        CT_GET_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_GET_DETAILS", CT_GET_DETAILS);

                        DataTable CT_CONT_EXP_GET_EMPTY = request.CT_CONT_EXP_GET_EMPTY.ToDataTable();
                        CT_CONT_EXP_GET_EMPTY.Columns.Remove("CT_GET_DETAILS");
                        CT_CONT_EXP_GET_EMPTY.SetTypeName("CT_CONT_EXP_GET_EMPTY");
                        parameters.Add("@CT_CONT_EXP_GET_EMPTY", CT_CONT_EXP_GET_EMPTY);
                    }

                    if (request.CT_CONT_EXP_PACKING != null)
                    {
                        CT_RETURN_DETAILS = request.CT_CONT_EXP_PACKING.Where(r => r.CT_RETURN_DETAILS != null).SelectMany(r => r.CT_RETURN_DETAILS).ToList().ToDataTable();
                        CT_RETURN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_RETURN_DETAILS", CT_RETURN_DETAILS);

                        DataTable CT_CONT_EXP_PACKING = request.CT_CONT_EXP_PACKING.ToDataTable();
                        CT_CONT_EXP_PACKING.Columns.Remove("CT_RETURN_DETAILS");
                        CT_CONT_EXP_PACKING.SetTypeName("CT_CONT_EXP_PACKING");
                        parameters.Add("@CT_CONT_EXP_PACKING", CT_CONT_EXP_PACKING);
                    }

                    if (request.CT_CONT_EXP_DOWN_CONT != null)
                    {
                        CT_DOWN_DETAILS = request.CT_CONT_EXP_DOWN_CONT.Where(r => r.CT_DOWN_DETAILS != null).SelectMany(r => r.CT_DOWN_DETAILS).ToList().ToDataTable();
                        CT_DOWN_DETAILS.SetTypeName("CT_GET_DETAILS");
                        parameters.Add("@CT_DOWN_DETAILS", CT_DOWN_DETAILS);

                        DataTable CT_CONT_EXP_DOWN_CONT = request.CT_CONT_EXP_DOWN_CONT.ToDataTable();
                        CT_CONT_EXP_DOWN_CONT.Columns.Remove("CT_DOWN_DETAILS");
                        CT_CONT_EXP_DOWN_CONT.SetTypeName("CT_CONT_EXP_DOWN_CONT");
                        parameters.Add("@CT_CONT_EXP_DOWN_CONT", CT_CONT_EXP_DOWN_CONT);
                    }
                }

                request.CT_NOBOX_GET = null;
                request.CT_NOBOX_RETURN = null;
                request.CT_LISTCONT = null;
                request.CT_CONT_IMP_GET_CONT = null;
                request.CT_CONT_IMP_RETURN_CONT = null;
                request.CT_CONT_IMP_DOWN_EMPTY = null;
                request.CT_CONT_EXP_GET_EMPTY = null;
                request.CT_CONT_EXP_PACKING = null;
                request.CT_CONT_EXP_DOWN_CONT = null;

                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditListCont([FromBody] EditListCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Edit-ListCont" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                if (request.CT_LISTCONT != null)
                {
                    DataTable CT_LISTCONT = request.CT_LISTCONT.ToDataTable();
                    CT_LISTCONT.SetTypeName("CT_LISTCONT");
                    parameters.Add("@CT_LISTCONT", CT_LISTCONT);
                }

                request.CT_LISTCONT = null;

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
                    { "@CmpnID",_UserInfo.CmpnID },
                    { "@IsLock", request.IsActive }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    return Ok(new DataResponse("Error","","-3"));
                }

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
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    return Ok(new DataResponse("Error", "", "-3"));
                }

            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetForWaitingApproval([FromBody] FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ForWaitingApproval" },
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
        public async Task<IActionResult> Approval([FromBody] Approval request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Approval" },
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
        public async Task<IActionResult> GetCancelReasonsApproval()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetReasonApproval" },
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
        public async Task<IActionResult> GetByCustomer([FromBody] FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetByCustomer" },
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
        public async Task<IActionResult> AddDepotByCustomer([FromBody] AddDepot request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CategoryType", "CustomerInvoices" }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecDepotByCustomers", request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoiceByCustomer([FromBody] AddInvoice request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Add" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, "ExecnPLCustomersDetails", request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetFileShipping([FromBody] GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetFileShip" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    var results = (IEnumerable<dynamic>)result[0]!;
                    foreach (var item in results)
                    {
                        item.File = ((IEnumerable<dynamic>)result[1]!).Where(r => r.OID == item.OID);
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

        //[HttpPost]
        //public async Task<IActionResult> Test([FromBody] Test request)
        //{
        //    try
        //    {
        //        string result = "";
        //        Dictionary<string, object> GetCustomersInfoparameters = new()
        //        {
        //            { "@type", "GetCustomersInfo" },
        //            { "@CustomerID", request.CustomerID },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@CmpnID", _UserInfo.CmpnID }
        //        };
        //        DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);

        //        if (GetCustomersInfo?.Result.Count > 0)
        //        {
        //            string CompanyCode = GetCustomersInfo?.Result[0].CompanyCode;
        //            string CustomerID = GetCustomersInfo?.Result[0].CustomerID;
        //            result = await _kimTinService.GetData(CompanyCode, CustomerID);
        //            JsonNode jsonNode = JsonSerializer.Deserialize<JsonNode>(result);
        //            Dictionary<string, object> AddDebitMoneyByCustomersparameters = new()
        //            {
        //                { "@type", "AddDebitMoneyByCustomers" },
        //                { "@CustomerID", request.CustomerID },
        //                { "@LemonName", jsonNode.AsArray()[0]["CustomerID"].GetValue<string>() },
        //                { "@CustomerName", jsonNode.AsArray()[0]["CustomerName"].GetValue<string>() },
        //                { "@OrigClosingValue", jsonNode.AsArray()[0]["OrigClosingValue"].GetValue<decimal>() },
        //                { "@language", _UserInfo.Language },
        //                { "@UserIDCurent", _UserInfo.UserID },
        //                { "@CmpnID", _UserInfo.CmpnID }
        //            };
        //            await GetDataResponse(AddDebitMoneyByCustomersparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Test([FromBody] Test1 request)
        //{
        //    try
        //    {
        //        return Ok(new DataResponse("", await _services.Route(request.StringPoint), "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> EditEstimatedNumberOfVehicles([FromBody] EstimatedNumberOfVehicles request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UPDATE_ESTIMATED_VEHICLE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> Copy([FromBody] Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Copy" },
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
        public async Task<IActionResult> UpdateMultiClose([FromBody] UpdateMultiClose request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Update-MultiClose" },
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
        public async Task<IActionResult> AddListSaleContractsInvoices([FromBody] ListInvoice request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "IMP_CT_INVOICE" },
                    { "@language", _UserInfo.Language }
                };
                DataTable CT_IMP_INVOICE = request.CT_IMP_INVOICE.ToDataTable();
                CT_IMP_INVOICE.SetTypeName("CT_IMP_INVOICE");
                parameters.Add("@CT_IMP_INVOICE", CT_IMP_INVOICE);
                request.CT_IMP_INVOICE = null;
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecSaleContractsInvoices", request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}