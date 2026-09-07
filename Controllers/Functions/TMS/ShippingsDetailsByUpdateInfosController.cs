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
    [ApiExplorerSettings(GroupName = "Microservice.nPL.ShippingsDetailsByUpdateInfos")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ShippingsDetailsByUpdateInfosController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _CategoryDB;
        private readonly DBFolder _SettingOther;
        private readonly string _ProcedureName = "ExecShippingsDetailsByUpdateInfos";

        public ShippingsDetailsByUpdateInfosController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "AttachFiles")!;
        }

        [HttpPost]
        public async Task<IActionResult> GetListLOLOs()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-LIST-HELP-PAYMENT" },
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
        public async Task<IActionResult> GetListContID([FromBody] Shippings.Request.GetByDetails request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetContID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByLOLOFees", request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetListFeeLOLOByOIDAndReferenceID([FromBody] Shippings.Request.GetByDetails request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ByOIDAndReferenceID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByLOLOFees", request);

                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.ListFees = dataResponse.Result[0];
                    result.Histories = dataResponse.Result[1];
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
        public async Task<IActionResult> AddFeeLOLO([FromBody] Shippings.Request.AddFeeLOLO request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByLOLOFees", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditFeeLOLO([FromBody] Shippings.Request.EditFeeLOLO request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByLOLOFees", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DelFeeLOLO([FromBody] Shippings.Request.DelFeeLOLO request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Del" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecShippingsDetailsByLOLOFees", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetListDepotByReferenceID([FromBody] Shippings.Request.GetByReferenceID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ListDepot-ByReferenceID" },
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
        public async Task<IActionResult> GetListFinals([FromBody] Shippings.Request.FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-LISTFINAL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = new ExpandoObject();
                    result.ListShippings = dataResponse.Result[0];
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

        [HttpPost]
        public async Task<IActionResult> GetFinalDetailsByOID([FromBody] Shippings.Request.GetByDetailsByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ByOID" },
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
                        item.FeeIncurreds = ((IEnumerable<dynamic>)result[1]!);
                        item.FeeTolls = ((IEnumerable<dynamic>)result[2]!);
                        item.FeeOthers = ((IEnumerable<dynamic>)result[3]!);
                        item.ListContracts = ((IEnumerable<dynamic>)result[4]!);

                        foreach (var ct in item.ListContracts)
                        {
                            ct.ListConts = ((IEnumerable<dynamic>)result[5]!).Where(r => r.OID == ct.ReferenceID);
                            ct.RevIncurreds = ((IEnumerable<dynamic>)result[6]!).Where(r => r.ReferenceID == ct.ReferenceID);

                            ct.CT_NOBOX_GET = ((IEnumerable<dynamic>)dataResponse.Result[7]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_NOBOX_RETURN = ((IEnumerable<dynamic>)dataResponse.Result[8]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_CONT_IMP_GET_CONT = ((IEnumerable<dynamic>)dataResponse.Result[9]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_CONT_IMP_RETURN_CONT = ((IEnumerable<dynamic>)dataResponse.Result[10]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_CONT_IMP_DOWN_EMPTY = ((IEnumerable<dynamic>)dataResponse.Result[11]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_CONT_EXP_GET_EMPTY = ((IEnumerable<dynamic>)dataResponse.Result[12]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_CONT_EXP_PACKING = ((IEnumerable<dynamic>)dataResponse.Result[13]!).Where(r => r.OID == ct.ReferenceID);
                            ct.CT_CONT_EXP_DOWN_CONT = ((IEnumerable<dynamic>)dataResponse.Result[14]!).Where(r => r.OID == ct.ReferenceID);

                            dynamic CT_DETAILS = dataResponse.Result[15];
                            foreach (var cont in ct.CT_NOBOX_GET)
                                cont.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == cont.OID && r.DepotID == cont.DepotID);

                            foreach (var cont in ct.CT_NOBOX_RETURN)
                                cont.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == cont.OID && r.DepotID == cont.DepotID);

                            foreach (var cont in ct.CT_CONT_IMP_GET_CONT)
                                cont.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == cont.OID && r.DepotID == cont.DepotID);

                            foreach (var cont in ct.CT_CONT_IMP_RETURN_CONT)
                                cont.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == cont.OID && r.DepotID == cont.DepotID);

                            foreach (var cont in ct.CT_CONT_EXP_GET_EMPTY)
                                cont.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == cont.OID && r.DepotID == cont.DepotID);

                            foreach (var cont in ct.CT_CONT_EXP_PACKING)
                                cont.Details = ((IEnumerable<dynamic>)CT_DETAILS).Where(r => r.OID == cont.OID && r.DepotID == cont.DepotID);
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
        public async Task<IActionResult> EditShippingsByOIDAndReferenceID([FromBody] Shippings.Request.ShippingEdit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Edit-ShippingByOIDAndReferenceID" },
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
        public async Task<IActionResult> UpdateCTGCL([FromBody] Shippings.Request.EditCTGCL request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UpdateCTGCL" },
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
        public async Task<IActionResult> UpdateTollFee([FromBody] Shippings.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UpdateTollFee" },
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
        public async Task<IActionResult> AddListExportDownCont([FromBody] Shippings.Request.ListExportDownCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD_CT_EXP_LISTCONT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataTable CT_EXP_LISTCONT = request.CT_LISTCONT.ToDataTable();
                CT_EXP_LISTCONT.SetTypeName("CT_EXP_LISTCONT");
                parameters.Add("@CT_EXP_LISTCONT", CT_EXP_LISTCONT);
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
        public async Task<IActionResult> AddListImportGetCont([FromBody] Shippings.Request.ListImportGetCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD_CT_IMP_LISTCONT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataTable CT_GET_LISTCONT = request.CT_GET_LISTCONT.ToDataTable();
                CT_GET_LISTCONT.SetTypeName("CT_GET_LISTCONT");
                parameters.Add("@CT_GET_LISTCONT", CT_GET_LISTCONT);
                request.CT_GET_LISTCONT = null;
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCodeDownCont([FromBody] Shippings.Request.GetCodeDownCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_CODE_DOWN_CONT" },
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
                        item.ListCodeDownCont = ((IEnumerable<dynamic>)result[1]!);
                        item.LicensePlates = ((IEnumerable<dynamic>)result[2]!);
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
        public async Task<IActionResult> UpdateCodeDownCont([FromBody] Shippings.Request.UpdateCodeDownCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UPDATE_CODE_DOWN_CONT" },
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
        public async Task<IActionResult> SaleContractByCont_GetByID([FromBody] Shippings.Request.SaleContractByCont_GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SaleContractByCont_GetByID" },
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
        public async Task<IActionResult> Edit_SaleContractByCont([FromBody] Shippings.Request.Edit_SaleContractByCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT_SaleContractByCont" },
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
        public async Task<IActionResult> EditShipping([FromBody] Shippings.Request.EditShipping request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditShipping" },
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
        public async Task<IActionResult> CalculateSalaryAndFee([FromBody] Shippings.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditShipping" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@IsAgain", "2" },
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "Calculate_SalaryAndFee", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRealMealManuals([FromBody] Shippings.Request.ContentRealMeal request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Add" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecDriverRealMealManuals", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditRealMealManuals([FromBody] Shippings.Request.EditRealMeal request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Edit" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecDriverRealMealManuals", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DelRealMealManuals([FromBody] Shippings.Request.DelByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Del" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecDriverRealMealManuals", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetRealMealManuals([FromBody] Shippings.Request.GetByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ByOID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecDriverRealMealManuals", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSaleContractCont([FromBody] Shippings.Request.AddCont request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "AddOneCont" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "[ExecSaleContractsByConts]", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}