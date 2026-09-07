using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.Plans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DMS.Controllers.Functions.DMS.Plans.Exhibitions;

[ApiExplorerSettings(GroupName = "Functions.Exhibitions.Evaluations")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class ExhibitionEvaluationsController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecExhibitionEvaluations";

    public ExhibitionEvaluationsController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
    }

    [HttpPost]
    public async Task<IActionResult> GetByID([FromBody] ExhibitionEvaluations.Request.GetByOID request)
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
                result.Details = dataResponse.Result[1];
                result.Images = dataResponse.Result[2];
                result.Progress = dataResponse.Result[3];
                result.Histories = dataResponse.Result[4];
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
    public async Task<IActionResult> Add([FromBody] ExhibitionEvaluations.Request.AddEvaluation request)
    {
        try
        {
            var detailsJson = JsonConvert.SerializeObject(request.Details);
            request.Details = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "ADD" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@dataJson", detailsJson }
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
    public async Task<IActionResult> Submit([FromBody] ExhibitionEvaluations.Request.Submit request)
    {
        try
        {
            var detailsJson = JsonConvert.SerializeObject(request.Details);
            request.Details = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "SUBMIT" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@dataJson", detailsJson }
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