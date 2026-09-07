using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.Configs;

[ApiExplorerSettings(GroupName = "Microservice.Init.PermissionLists")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class PermissionListsController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _ProcedureName = "ExecGetPermissionLists";
    
    public PermissionListsController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
    }
    
    [HttpPost]
    public async Task<IActionResult> GetListUsers([FromBody] PermissionLists.Request.GetListUsers request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-UserLists" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                //{ "@CmpnID", _UserInfo.CmpnID }
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
    public async Task<IActionResult> GetListCustomers([FromBody] PermissionLists.Request.GetListCustomers request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-CustomerLists" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                //{ "@CmpnID", _UserInfo.CmpnID } 
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