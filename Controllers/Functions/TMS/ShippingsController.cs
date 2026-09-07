using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Dynamic;
using static APISmartCity.lib.Function;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.Shippings")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _CategoryDB;
        private readonly DBFolder _SettingOther;
        private readonly string _ProcedureName = "ExecShippings";

        public ShippingsController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "AttachFiles")!;
        }

        [HttpPost]
        public async Task<IActionResult> GetWaitingForCoordination([FromBody] Shippings.Request.ShowHideExpired request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-WaitingForCoordination" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecSaleContracts", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetMonitor([FromBody] Shippings.Request.FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ListMonitor" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID } 
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.DetailMonitors = dataResponse.Result[0];
                    result.TotalMonitors = dataResponse.Result[1];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> GetDetailByOID([FromBody] Shippings.Request.GetByOID request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "Get-DetailsByOID" },
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
        //                item.Contracts = ((IEnumerable<dynamic>)result[8]!).Where(r => r.OID == item.OID);
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
        public async Task<IActionResult> GetDetailByOID([FromBody] Shippings.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DetailsByOID" },
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
                        item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
                        item.DetailsAttachFiles = ((IEnumerable<dynamic>)result[7]!);
                        item.ContractReferences = ((IEnumerable<dynamic>)result[8]!).Where(r => r.OID == item.OID);
                        item.DetailsByIncurreds = ((IEnumerable<dynamic>)result[9]!);
                        item.DetailsByRevenues = ((IEnumerable<dynamic>)result[10]!);
                        foreach (var ct in item.Contracts)
                        {
                            ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID && r.ReferenceID == ct.OID);
                            foreach (var sp in ct.ShipPoints)
                            {
                                sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                                sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                            }
                            ct.Trackings = ((IEnumerable<dynamic>)result[13]!).Where(r => r.OID == ct.ReferenceID && r.ReferenceID == ct.OID);
                        }
                        item.Lines = ((IEnumerable<dynamic>)result[5]!);
                        item.ListContractFulls = ((IEnumerable<dynamic>)result[12]!);
                        item.Progress = ((IEnumerable<dynamic>)result[14]!);
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
        public async Task<IActionResult> GetTotalContractByReferenceID([FromBody] Shippings.Request.GetByReferenceID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-TotalByReferenceID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    if (dataResponse.Result[0].Count > 0)
                    {
                        dynamic result = dataResponse.Result[0][0];
                        result.ListShippings = dataResponse.Result[1];
                        dataResponse.Result = result;
                    }
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Shippings.Request.Add request)
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
                if (request.Details != null)
                {
                    DataTable Details = request.Details.ToDataTable();
                    Details.SetTypeName("SP_ShippingsDetails");
                    parameters.Add("@ShippingsDetails", Details);
                    request.Details = null;
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
        public async Task<IActionResult> Edit([FromBody] Shippings.Request.Edit request)
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
                if (request.Details != null)
                {
                    DataTable Details = request.Details.ToDataTable();
                    Details.SetTypeName("SP_ShippingsDetails");
                    parameters.Add("@ShippingsDetails", Details);
                    request.Details = null;
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
        public async Task<IActionResult> GetDetailByOIDAndReferenceID([FromBody] Shippings.Request.GetByDetails request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DetailsByOIDAndReferenceID" },
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
                        item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
                        foreach (var ct in item.Contracts)
                        {
                            ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID);
                            foreach (var sp in ct.ShipPoints)
                            {
                                sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
                                sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
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
        public async Task<IActionResult> Delete([FromBody] Shippings.Request.GetByOID request)
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
        public async Task<IActionResult> ChangeStatus([FromBody] Shippings.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@IsLock", request.IsActive}
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
        public async Task<IActionResult> Submit([FromBody] Shippings.Request.Submit request)
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
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetVehicle([FromBody] Shippings.Request.GetVehicleByDepotID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Vehicle" },
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
        public async Task<IActionResult> GetVehicleHasCrane([FromBody] Shippings.Request.GetVehicleByDepotID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Vehicle-HasCrane" },
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
        public async Task<IActionResult> GetDriver()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Driver" },
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
        public async Task<IActionResult> GetDepotContract([FromBody] Shippings.Request.GetDepotContract request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DepotContract" },
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
                        item.DepotDetails = ((IEnumerable<dynamic>)result[1]!).Where(r => r.OID == item.OID & r.DepotType == item.DepotType);
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
        public async Task<IActionResult> GetCargoCraneType()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-CargoCraneTypes" },
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
        public async Task<IActionResult> GetListContByReferenceID([FromBody] Shippings.Request.GetByReferenceID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ListCont-ReferenceID" },
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
        public async Task<IActionResult> GetListContractByDriverID([FromBody] Shippings.Request.GetByDriverID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Contract-ByListOID" },
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
        public async Task<IActionResult> GetListOutSide([FromBody] Shippings.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ListOutSide" },
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
                        item.ListVehicles = ((IEnumerable<dynamic>)result[1]!).Where(r => r.OutSideID == item.OutSideID);
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
        public async Task<IActionResult> GetPriceByOutSide([FromBody] Shippings.Request.GetPriceByOutSide request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-PriceByOutSide" },
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
        public async Task<IActionResult> GetCacheStringPoint([FromBody] Shippings.Request.Getcache request)
        {
            //try
            //{
            //    request.StringPoint = request.StringPoint.Replace(" ", "");
            //    Dictionary<string, object> parameters = new()
            //    {
            //        { "@type", "GetRoute" },
            //        { "@language", _UserInfo.Language },
            //        { "@UserIDCurent", _UserInfo.UserID }
            //    };
            //    DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
            //    if (dataResponse?.ErrorCode == "0")
            //    {
            //        return Ok(dataResponse);
            //    }
            //    else
            //    {
            //        string json = await _services.Route(request.StringPoint);
            //        if (json is null)
            //        {
            //            return Ok(new DataResponse("Api not found", "", "-1"));
            //        }
            //        else
            //        {
            //            Dictionary<string, object> addparameters = new()
            //            {
            //                { "@type", "AddRoute" },
            //                { "@language", _UserInfo.Language },
            //                { "@json", json },
            //                { "@StringPoint", request.StringPoint },
            //                { "@UserIDCurent", _UserInfo.UserID }
            //            };
            //            DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
            //           //return Ok(adddataResponse);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new DataResponse(ex.Message, "", "-1"));
            //}

            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "LoadCacheStringPoint" },
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
        public async Task<IActionResult> GetFileShip([FromBody] Shippings.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetFileShip" },
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
                        item.FileGets = ((IEnumerable<dynamic>)result[1]!).Where(r => r.OID == item.OID && r.ReferenceID == item.ReferenceID);
                        item.FileReturns = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == item.OID && r.ReferenceID == item.ReferenceID);
                        item.FileDowns = ((IEnumerable<dynamic>)result[3]!).Where(r => r.OID == item.OID && r.ReferenceID == item.ReferenceID);
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
        public async Task<IActionResult> UpdateOutSide([FromBody] Shippings.Request.EditOutSide request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UpdateOutSideFull" },
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
        public async Task<IActionResult> UpdateOutSideFinish([FromBody] Shippings.Request.OutSideID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "OutSideFinish" },
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
        public async Task<IActionResult> DeleteOutSide([FromBody] Shippings.Request.OutSideID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DelOutSideFull" },
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