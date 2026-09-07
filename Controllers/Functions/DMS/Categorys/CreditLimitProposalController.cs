using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APISmartCity.Controllers.Ver2.Categorys
{
    [ApiExplorerSettings(GroupName = "Microservice.Category.CreditLimitProposal")]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditLimitProposalController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecCreditLimitProposals";

        public CreditLimitProposalController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] CreditLimitProposal.Request.GetByID request)
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
                    dynamic result = dataResponse.Result;
                    dynamic results = result[0][0]!;
                    results.Order = result[1]!;
                    results.Progress = result[2]!;
                    results.Histories = result[3]!;
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
        public async Task<IActionResult> GetByIdCshop([FromBody] CreditLimitProposal.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYIDCShop" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = result[0][0]!;
                    results.Order = result[1]!;
                    results.Progress = result[2]!;
                    results.Confirm = result[3]!;
                    results.Histories = result[4]!;
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
        public async Task<IActionResult> GetSAPInfo([FromBody] CreditLimitProposal.Request.GetSAPInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-SAPINFO" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = result[0][0]!;
                    results.Order = result[1]!;
                    results.Histories = result[2]!;
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
        public async Task<IActionResult> GetInfoSale([FromBody] CreditLimitProposal.Request.GetInfoSale request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-InfoSale" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                    //,{ "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = result[0][0]!;
                    results.Orders = result[1]!;
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
        public async Task<IActionResult> GetInfoGuarantee([FromBody] CreditLimitProposal.Request.GetInfoSale request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Info-Guarantee" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                    //,{ "@CmpnID", _UserInfo.CmpnID }
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
        public async Task<IActionResult> GetListCategories([FromBody] CreditLimitProposal.Request.GetListCategory request)
        {
            try
            {
                Dictionary<string, dynamic> Customize = new();

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ListCategories" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 0)
                {
                    var results = (dataResponse.Result as System.Collections.IList)?[0] as IEnumerable<dynamic>;
                    var ListColumn = (dataResponse.Result as System.Collections.IList)?[1] as IEnumerable<dynamic>;

                    foreach (var lang in results)
                    {
                        var ListCustomize = new List<dynamic>();
                        foreach (var item in ListColumn)
                        {
                            if (lang.CategoryType == item.CategoryType)
                            {
                                ListCustomize.Add(item);
                            }
                        }
                        Customize.Add(lang.CategoryType, ListCustomize);
                    }
                    dataResponse.Result = Customize;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] CreditLimitProposal.Request.GetBySO request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCshop([FromBody] CreditLimitProposal.Request.GetCShop request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-CShop" },
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
        public async Task<IActionResult> Add([FromBody] CreditLimitProposal.Request.AddOrEdit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
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
        public async Task<IActionResult> Edit([FromBody] CreditLimitProposal.Request.AddOrEdit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
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
        public async Task<IActionResult> Delete([FromBody] CreditLimitProposal.Request.Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
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
        public async Task<IActionResult> Submit([FromBody] CreditLimitProposal.Request.Submit request)
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

        [HttpPost]
        public async Task<IActionResult> Confirm([FromBody] CreditLimitProposal.Request.Confirm request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Confirm" },
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