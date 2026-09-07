using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.Inventorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Functions.DMS.Inventorys;

[ApiExplorerSettings(GroupName = "Functions.SaleInventorys")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class SaleInventorysController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecSaleInventorys";
    
    public SaleInventorysController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "SAL")?.DBString!;
    }
    
    [HttpPost]
    public async Task<IActionResult> Get([FromBody] SaleInventorys.Request.Get request)
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
    public async Task<IActionResult> GetMobile([FromBody] SaleInventorys.Request.Get request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-MOBILE" },
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
    public async Task<IActionResult> GetItem([FromBody] SaleInventorys.Request.GetItem request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-ITEM" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);

            if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
            {
                dynamic result = dataResponse.Result[0][0];
                result.Warehhouses = dataResponse.Result[1];
                result.KeepSales = dataResponse.Result[2];
                result.KeepSO = dataResponse.Result[3]; 
                result.KeepOD = dataResponse.Result[4];
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