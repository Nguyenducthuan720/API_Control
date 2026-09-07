using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json.Nodes;
using APISmartCity.TransferServices;
using Microsoft.AspNetCore.Authentication;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace APISmartCity.Controllers.Ver2.Categorys
{
    [ApiExplorerSettings(GroupName = "Microservice.Category.GeneralApprovals")]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeneralApprovalsController : ControllerBase
    {
        private readonly APIInfo _APIInfo;
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _FunctionDB;
        private readonly string _ProcedureName = "ExecTaskApprovals";
        private readonly TransferDataDeviceService _transferService;
        private IHttpClientFactory HttpClientFactory { get; }

        public GeneralApprovalsController(APIInfo APIInfo, UserInfo userInfo, TransferDataDeviceService transferService, IHttpClientFactory httpClientFactory)
        {
            this._UserInfo = userInfo;
            _APIInfo = APIInfo;
            _transferService = transferService;
            HttpClientFactory = httpClientFactory;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _FunctionDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetListProcess([FromBody] Default.Request.FromDateToDate request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-AllProcess" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result!.Count > 0)
                {
                    dynamic result = new ExpandoObject();
                    result.Processes = dataResponse.Result[0];

                    dynamic results = (IEnumerable<dynamic>)dataResponse.Result[1];
                    foreach (dynamic item in results)
                    {
                        item.Child = ((IEnumerable<dynamic>)dataResponse.Result[2]!).Where(r => r.FactorID == item.FactorID);
                    }
                    result.Entrys = results;
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
        public async Task<IActionResult> ApprovalList([FromBody] GeneralApprovals.Request.ProcessArray request)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(request.dataJson);
                request.dataJson = null;

                IDictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@type", "Approval-List" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@dataJson", jsonString },
                    { "@CmpnID", _UserInfo.CmpnID }

                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePlanWorking([FromBody] Default.Request.UpdatePlanWorking request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UpdatePlanWorking" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateFinal([FromBody] Default.Request.UpdateFinal request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UpdateFinal" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _FunctionDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}