using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APISmartCity.Controllers.Ver2.Categorys
{
    [ApiExplorerSettings(GroupName = "Microservice.Category.CustomerEvaluation")]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerEvaluationController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecCustomerEvaluations";

        public CustomerEvaluationController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] CustomerEvaluation.Request.GetByID request)
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

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic results = dataResponse.Result[0][0];
                    results.BusinessItemEvaluation = dataResponse.Result[1];
                    results.SalesPolicy = dataResponse.Result[2];
                    results.ResultJson = dataResponse.Result[3];
                    results.CustomerGoals = dataResponse.Result[4];
                    results.Data1 = dataResponse.Result[5];
                    results.Data2 = dataResponse.Result[6];
                    results.CusEvaluationGrid = dataResponse.Result[7];
                    results.Histories = dataResponse.Result[8];
                    dataResponse.Result = results;
                }
                else
                {
                    dataResponse.Result = null;
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
        public async Task<IActionResult> Add([FromBody] CustomerEvaluation.Request.AddOrEdit request)
        {
            try
            {
                var salesPolicyJson = JsonConvert.SerializeObject(request.SalesPolicy);
                var customerGoalsJson = JsonConvert.SerializeObject(request.CustomerGoals);
                var businessItemJson = JsonConvert.SerializeObject(request.BusinessItem);
                var purchaseOrderJson = JsonConvert.SerializeObject(request.PurchaseOrder);
                request.SalesPolicy = null;
                request.CustomerGoals = null;
                request.BusinessItem = null;
                request.PurchaseOrder = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@PolicyList", salesPolicyJson },
                    { "@GoalList", customerGoalsJson },
                    { "@BusinessItemList", businessItemJson },
                    { "@PurchaseOrderList", purchaseOrderJson }
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
        public async Task<IActionResult> Edit([FromBody] CustomerEvaluation.Request.AddOrEdit request)
        {
            try
            {
                var salesPolicyJson = JsonConvert.SerializeObject(request.SalesPolicy);
                var customerGoalsJson = JsonConvert.SerializeObject(request.CustomerGoals);
                var businessItemJson = JsonConvert.SerializeObject(request.BusinessItem);
                var purchaseOrderJson = JsonConvert.SerializeObject(request.PurchaseOrder);
                request.SalesPolicy = null;
                request.CustomerGoals = null;
                request.BusinessItem = null;
                request.PurchaseOrder = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@PolicyList", salesPolicyJson },
                    { "@GoalList", customerGoalsJson },
                    { "@BusinessItemList", businessItemJson },
                    { "@PurchaseOrderList", purchaseOrderJson }
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
        public async Task<IActionResult> Delete([FromBody] CustomerEvaluation.Request.Del request)
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
        public async Task<IActionResult> Submit([FromBody] CustomerEvaluation.Request.Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Submit" },
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

    }
}