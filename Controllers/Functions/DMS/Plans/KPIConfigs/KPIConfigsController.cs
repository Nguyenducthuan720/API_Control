using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.KPIConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APISmartCity.Controllers.Ver2;

[ApiExplorerSettings(GroupName = "Functions.Plans.KPIConfigs")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class KPIConfigsController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecKPIConfigs";

    public KPIConfigsController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, null);
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, null);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> GetByID([FromBody] KPIConfigs.Request.GetByOID request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);

            if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
            {
                dynamic result = dataResponse.Result[0][0];
                result.ModelByNames = dataResponse.Result[1];
                result.ModelByDepartments = dataResponse.Result[1];
                result.DividedByNames = dataResponse.Result[2];
                result.DividedByDepartments = dataResponse.Result[3];
                result.DividedByRegions = dataResponse.Result[4];
                result.SKUDividedByRegions = dataResponse.Result[5];
                result.Progress = dataResponse.Result[6];
                result.Histories = dataResponse.Result[7];
                dataResponse.Result = result;
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
    public async Task<IActionResult> Add([FromBody] KPIConfigs.Request.AddKPI request)
    {
        try
        {
            var forecastingModelsJson = JsonConvert.SerializeObject(request.ForecastingModels);
            var dividedByNamesJson = JsonConvert.SerializeObject(request.DividedByNames);
            var dividedByDepartmentsJson = JsonConvert.SerializeObject(request.DividedByDepartments);
            var dividedByRegionsJson = JsonConvert.SerializeObject(request.DividedByRegions);
            var skuDividedByRegionsJson = JsonConvert.SerializeObject(request.SKUDividedByRegions);
            request.ForecastingModels = null;
            request.DividedByNames = null;
            request.DividedByDepartments = null;
            request.DividedByRegions = null;
            request.SKUDividedByRegions = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "ADD" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@ForecastingModelsJson", forecastingModelsJson },
                { "@DividedByNamesJson", dividedByNamesJson },
                { "@DividedByDepartmentsJson", dividedByDepartmentsJson },
                { "@DividedByRegionsJson", dividedByRegionsJson },
                { "@SKUDividedByRegionsJson", skuDividedByRegionsJson }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] KPIConfigs.Request.AddKPI request)
    {
        try
        {
            var forecastingModelsJson = JsonConvert.SerializeObject(request.ForecastingModels);
            var dividedByNamesJson = JsonConvert.SerializeObject(request.DividedByNames);
            var dividedByDepartmentsJson = JsonConvert.SerializeObject(request.DividedByDepartments);
            var dividedByRegionsJson = JsonConvert.SerializeObject(request.DividedByRegions);
            var skuDividedByRegionsJson = JsonConvert.SerializeObject(request.SKUDividedByRegions);
            request.ForecastingModels = null;
            request.DividedByNames = null;
            request.DividedByDepartments = null;
            request.DividedByRegions = null;
            request.SKUDividedByRegions = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "EDIT" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@ForecastingModelsJson", forecastingModelsJson },
                { "@DividedByNamesJson", dividedByNamesJson },
                { "@DividedByDepartmentsJson", dividedByDepartmentsJson },
                { "@DividedByRegionsJson", dividedByRegionsJson },
                { "@SKUDividedByRegionsJson", skuDividedByRegionsJson }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] KPIConfigs.Request.Del request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Submit([FromBody] KPIConfigs.Request.Submit request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
}