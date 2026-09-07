using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.PriceCommercials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DMS.Controllers.Functions.DMS.PriceCommercials
{
    [ApiExplorerSettings(GroupName = "Functions.PriceCommercials.PricePolicys")]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PricePolicysController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecPricePolicys";

        public PricePolicysController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "PRI")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] PricePolicys.Request.GetByID request)
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
                    results.Details = dataResponse.Result[1];
                    //results.Discounts = dataResponse.Result[2];
                    results.Progress = dataResponse.Result[2];
                    results.Histories = dataResponse.Result[3];
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
        public async Task<IActionResult> GetActive()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
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

        //[HttpPost]
        //public async Task<IActionResult> GetBasePrices([FromBody] PricePolicys.Request.GetBasePrices request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "GET-BASE-PRICES" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GetPricesBefore([FromBody] PricePolicys.Request.GetPricesBefore request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-PRICES-BEFORE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> CalculatePrices([FromBody] PricePolicys.Request.CalculatePrice request)
        {
            try
            {
                var itemsJson = JsonConvert.SerializeObject(request.Items);
                request.Items = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "CALCULATE-PRICES" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@dataJson", itemsJson }
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
        public async Task<IActionResult> Add([FromBody] PricePolicys.Request.AddOrEdit request)
        {
            try
            {
                var pricePolicyJson = JsonConvert.SerializeObject(request.Details);
                //var discountJson = JsonConvert.SerializeObject(request.Discounts);
                request.Details = null;
                //request.Discounts = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@dataJson", pricePolicyJson },
                    //{ "@DiscountJson", discountJson }
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
        public async Task<IActionResult> Edit([FromBody] PricePolicys.Request.AddOrEdit request)
        {
            try
            {
                var pricePolicyJson = JsonConvert.SerializeObject(request.Details);
                //var discountJson = JsonConvert.SerializeObject(request.Discounts);
                request.Details = null;
                //request.Discounts = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@dataJson", pricePolicyJson },
                    //{ "@DiscountJson", discountJson }
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
        public async Task<IActionResult> Delete([FromBody] PricePolicys.Request.Del request)
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
        public async Task<IActionResult> Submit([FromBody] PricePolicys.Request.Submit request)
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