using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.DMS.TaskIntegrations
{
    [ApiExplorerSettings(GroupName = "Functions.Media.TaskIntegrations")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class TaskIntegrationsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecTaskIntegrations";

        public TaskIntegrationsController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
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

                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null);

                // 🔹 Kiểm tra Result có dữ liệu không
                if (dataResponse?.Result is not IList resultList || resultList.Count == 0)
                    return Ok(dataResponse);

                // === Lấy list 1: Summary (grouped by SystemCode) ===
                var list1 = resultList[0] as IEnumerable<object>;
                var dictList1 = list1?
                    .Select(item => item as IDictionary<string, object>)
                    .Where(d => d != null)
                    .ToList() ?? new List<IDictionary<string, object>>();

                var grouped = dictList1
                    .GroupBy(r => r["SystemCode"]?.ToString())
                    .Select(g => new
                    {
                        SystemCode = g.Key,
                        Status = g.Select(r => new
                        {

                            Status = r.ContainsKey("Status") ? r["Status"]?.ToString() : "",
                            StatusName = r.ContainsKey("StatusName") ? r["StatusName"]?.ToString() : "",
                            Amount = Convert.ToInt32(r.ContainsKey("Amount") ? r["Amount"] ?? 0 : 0),
                            StatusColor = r.ContainsKey("StatusColor") ? r["StatusColor"]?.ToString() : "",
                            StatusTextColor = r.ContainsKey("StatusTextColor") ? r["StatusTextColor"]?.ToString() : "",
                            StatusProgressColor = r.ContainsKey("StatusProgressColor") ? r["StatusProgressColor"]?.ToString() : ""

                        }).ToList()
                    }).ToList();

                // === Lấy list 2: ExtraTable ===
                var list2 = resultList.Count > 1 ? resultList[1] as IEnumerable<object> : null;
                var extraTable = list2?
                    .Select(item => item as IDictionary<string, object>)
                    .Where(d => d != null)
                    .Select(d => d.ToDictionary(k => k.Key, v => v.Value))
                    .ToList() ?? new List<Dictionary<string, object>>();

                // === Gộp kết quả ===
                var result = new
                {
                    Summary = grouped,
                    ExtraTable = extraTable
                };

                string message = dataResponse.Message ?? "";
                string errorCode = dataResponse.ErrorCode ?? "";

                return Ok(new DataResponse(message, result, errorCode)
                {
                    Success = dataResponse.Success,
                    StatusCode = dataResponse.StatusCode
                });
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] Default.Request.ID_ByInt request)
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

                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                dynamic result = null;

                if (dataResponse.Result != null && dataResponse.Result.Count > 0)
                {
                    result = dataResponse.Result[0];  

                    if (dataResponse.Result.Count > 1)
                        result.Histories = dataResponse.Result[1];
                }

                dataResponse.Result = result;
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> RePush ([FromBody] Default.Request.ID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "REPUSH" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
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