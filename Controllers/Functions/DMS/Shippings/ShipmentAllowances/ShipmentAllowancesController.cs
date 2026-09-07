using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.ShipmentAllowances.ShipmentAllowances;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APISmartCity.Controllers.Ver2;

[ApiExplorerSettings(GroupName = "Functions.ShipmentAllowances")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class ShipmentAllowancesController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecShipmentAllowances";

    public ShipmentAllowancesController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "SHP")?.DBString!;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ShipmentAllowances.Request.Add request)
    {
        try
        {
            var DataDetailsJson = JsonConvert.SerializeObject(request.AllowanceString);
            request.AllowanceString = null;
            Dictionary<string, object> parameters = new()
            {
                { "@type", "ADD" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@DataDetailsJson", DataDetailsJson }
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
    public async Task<IActionResult> Edit([FromBody] ShipmentAllowances.Request.Edit request)
    {
        try
        {
            var DataDetailsJson = JsonConvert.SerializeObject(request.AllowanceString);
            request.AllowanceString = null;
            Dictionary<string, object> parameters = new()
            {
                { "@type", "EDIT" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@DataDetailsJson", DataDetailsJson },
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
    public async Task<IActionResult> Delete([FromBody] ShipmentAllowances.Request.Del request)
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
    public async Task<IActionResult> Submit([FromBody] ShipmentAllowances.Request.Submit request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromBody] ShipmentAllowances.Request.Get request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> GetByID([FromBody] ShipmentAllowances.Request.GetByID request)
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
                result.ListDetails = dataResponse.Result[1];
                result.Progress = dataResponse.Result[2];
                result.Histories = dataResponse.Result[3];
                result.Customize = dataResponse.Result[4];
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

}