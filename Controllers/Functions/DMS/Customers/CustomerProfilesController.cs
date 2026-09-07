using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.CustomerInformationExchanges;
using APISmartCity.Models.Ver2.Function;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DMS.Controllers.Functions.DMS.Customers.Customers
{
    [ApiExplorerSettings(GroupName = "Functions.Customer.CustomerProfiles")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CustomerProfilesController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "[ExecCustomerProfiles]";
        private readonly string _ProcedureRelationShip = "[ExecCustomerRelationships]";
        private readonly string _ProcCategoryCustomer = "ExecGetWarehouse";



        public CustomerProfilesController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!; 
        }


        [HttpPost]
        public async Task<IActionResult> CheckInfoTaxCode([FromBody] CustomerProfiles.Request.GetByTaxCode request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "CheckInfo-TaxCode" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetInfo([FromBody] CustomerProfiles.Request.GetInfoCus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetInfo-Customer" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                    //{ "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] CustomerProfiles.Request.GetByID request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.CusContact = dataResponse.Result[1];
                    result.CusShipping = dataResponse.Result[2];
                    result.CusBank = dataResponse.Result[3];
                    result.CusDocument = dataResponse.Result[4];
                    result.Credit = dataResponse.Result[5];
                    result.CusEvaluation = dataResponse.Result[6];
                    result.BusinessItemEvaluation = dataResponse.Result[7];
                    result.SalesPolicy = dataResponse.Result[8];
                    result.ResultJson = dataResponse.Result[9];
                    result.CustomerGoals = dataResponse.Result[10];
                    result.Data1 = dataResponse.Result[11];
                    result.Data2 = dataResponse.Result[12];
                    result.CusEvaluationGrid = dataResponse.Result[13];
                    result.CusEvaluation_Cus = dataResponse.Result[14];
                    result.BusinessItemEvaluation_Cus = dataResponse.Result[15];
                    result.SalesPolicy_Cus = dataResponse.Result[16];
                    result.ResultJson_Cus = dataResponse.Result[17];
                    result.CustomerGoals_Cus = dataResponse.Result[18];
                    result.Data1_Cus = dataResponse.Result[19];
                    result.Data2_Cus = dataResponse.Result[20];
                    result.CusInformationExchanges = dataResponse.Result[21];
                    result.Progress = dataResponse.Result[22];
                    result.Histories = dataResponse.Result[23];
                    result.CurrentDocs = dataResponse.Result[24]; // mới thêm
                    result.Relationship = dataResponse.Result[25]; // mới thêm
                    result.Partner = dataResponse.Result[26]; // mới thêm

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
        public async Task<IActionResult> GetByManagement([FromBody] CustomerProfiles.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYManagement" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.CusContact = dataResponse.Result[1];
                    result.CusShipping = dataResponse.Result[2];
                    result.CusBank = dataResponse.Result[3];
                    result.CusDocument = dataResponse.Result[4];
                    result.Credit = dataResponse.Result[5];
                    result.CusEvaluation = dataResponse.Result[6];
                    result.BusinessItemEvaluation = dataResponse.Result[7];
                    result.SalesPolicy = dataResponse.Result[8];
                    result.ResultJson = dataResponse.Result[9];
                    result.CustomerGoals = dataResponse.Result[10];
                    result.Data1 = dataResponse.Result[11];
                    result.Data2 = dataResponse.Result[12];
                    result.CusEvaluationGrid = dataResponse.Result[13];
                    result.CusEvaluation_Cus = dataResponse.Result[14];
                    result.BusinessItemEvaluation_Cus = dataResponse.Result[15];
                    result.SalesPolicy_Cus = dataResponse.Result[16];
                    result.ResultJson_Cus = dataResponse.Result[17];
                    result.CustomerGoals_Cus = dataResponse.Result[18];
                    result.Data1_Cus = dataResponse.Result[19];
                    result.Data2_Cus = dataResponse.Result[20];
                    result.CusInformationExchanges = dataResponse.Result[21];
                    result.CusManagementInfo = dataResponse.Result[22];
                    result.Progress = dataResponse.Result[23];
                    result.Histories = dataResponse.Result[24];
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetCustomerIDSAP(CustomerProfiles.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GETCustomerIDSAP" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCategoryCustomer(CustomerProfiles.Request.GetCategoryCustomer request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetCategoryCustomer" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcCategoryCustomer, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerProfiles.Request.AddOrEdit request)
        {
            try
            {
                var contactsJson = JsonConvert.SerializeObject(request.Contacts);
                var shippingJson = JsonConvert.SerializeObject(request.Shipping);
                var banksJson = JsonConvert.SerializeObject(request.Banks);
                var documentsJson = JsonConvert.SerializeObject(request.Documents);
                var businessSectorJson = JsonConvert.SerializeObject(request.BusinessSector);
                var currentDocs = JsonConvert.SerializeObject(request.CurrentDocs);

                //var customerEvaluationJson = JsonConvert.SerializeObject(request.CustomerEvaluation);
                request.Contacts = null;
                request.Shipping = null;
                request.Banks = null;
                request.Documents = null;
                request.BusinessSector = null;
                request.CurrentDocs = null;

                //request.CustomerEvaluation = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@ContactList", contactsJson },
                    { "@ShippingList", shippingJson },
                    { "@BankList", banksJson },
                    { "@DocumentList", documentsJson },
                    { "@BusinessSector", businessSectorJson },
                    { "@currentDocs", currentDocs }

                    //{ "@CustomerEvaluation", customerEvaluationJson }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] CustomerProfiles.Request.AddOrEdit request)
        {
            try
            {
                var detailJson1 = JsonConvert.SerializeObject(request.BusinessSector);
                var detailJson2 = JsonConvert.SerializeObject(request.Contacts);
                var detailJson3 = JsonConvert.SerializeObject(request.Shipping);
                var detailJson4 = JsonConvert.SerializeObject(request.Banks);
                var detailJson5 = JsonConvert.SerializeObject(request.Documents);
                var detailJson6 = JsonConvert.SerializeObject(request.CurrentDocs);

                //var detailJson6 = JsonConvert.SerializeObject(request.CustomerEvaluation);
                request.BusinessSector = null;
                request.Contacts = null;
                request.Shipping = null;
                request.Banks = null;
                request.Documents = null;
                request.CurrentDocs = null;
                //request.CustomerEvaluation = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@ManagementInfo", detailJson1 },
                    { "@ContactList", detailJson2 },
                    { "@ShippingList", detailJson3 },
                    { "@BankList", detailJson4 },
                    { "@DocumentList", detailJson5 },
                    { "@CurrentDocs", detailJson6 }

                    //{ "@CustomerEvaluation", detailJson6 }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] CustomerProfiles.Request.Del request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] CustomerProfiles.Request.Submit request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditRelationship ([FromBody] CustomerProfiles.Request.EditRelationShip request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureRelationShip, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

    }
}