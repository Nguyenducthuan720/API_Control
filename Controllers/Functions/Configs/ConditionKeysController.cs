using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.Configs;

[ApiExplorerSettings(GroupName = "Microservice.Init.ConditionKeys")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class ConditionKeysController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _ProcedureName = "ExecConditionKeys";
    
    public ConditionKeysController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
    }
    
    [HttpPost]
    public async Task<IActionResult> GetParam([FromBody] ConditionKeys.Request.GetParam request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-PARAMETERS" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
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
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);
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
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> GetByID([FromBody] ConditionKeys.Request.GetByID request)
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
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            if (dataResponse.Result!.Count > 1)
            {
                dynamic result = dataResponse.Result[0][0];
                result.Params = dataResponse.Result[1];
                result.Histories = dataResponse.Result[2];
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
    public async Task<IActionResult> GetConfigs([FromBody] ConditionKeys.Request.GetConfigs request)
    {
        try
        {
            Dictionary<string, dynamic> Customize = new();
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-CONFIGS" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            if (dataResponse.Result!.Count > 0)
            {
                var results = (dataResponse.Result as System.Collections.IList)?[0] as IEnumerable<dynamic>;

                int index = 1;
                foreach (var lang in results)
                {
                    var ListCustomize = new List<dynamic>();
                    if ((dataResponse.Result as System.Collections.IList)?[index] is not IEnumerable<dynamic> ListColumn) continue;
                    foreach (var item in ListColumn)
                    {
                        ListCustomize.Add(item);
                    }
                    Customize.Add(lang.Param, new { Name = lang.Name, Data = ListCustomize });
                    index++;
                }
            }
            dataResponse.Result = Customize;
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ConditionKeys.Request.Add request)
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
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] ConditionKeys.Request.Add request)
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
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] ConditionKeys.Request.Del request)
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
            DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
}