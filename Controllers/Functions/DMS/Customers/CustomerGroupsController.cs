using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Function;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Functions.DMS.Customers;

[ApiExplorerSettings(GroupName = "Functions.Customer.CustomerGroups")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class CustomerGroupsController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _ProcedureName = "ExecCustomerGroupPermissions";

    public CustomerGroupsController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> GetByID([FromBody] CustomerGroups.Request.GetByID request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            if (dataResponse.Result!.Count > 1)
            {
                dynamic result = dataResponse.Result[0][0];
                result.Details = dataResponse.Result[1];
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
    public async Task<IActionResult> GetBYIDDetail([FromBody] CustomerGroups.Request.GetBYIDDetails request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYIDDetails" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            if (dataResponse.Result!.Count > 1)
            {
                dynamic result = dataResponse.Result[0][0];
                result.Details = dataResponse.Result[1];
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
    public async Task<IActionResult> AddUserAndGroup([FromBody] CustomerGroups.Request.AddOrEditUsers request)
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

            DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> EditUserAndGroup([FromBody] CustomerGroups.Request.AddOrEditUsers request)
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

            DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> EditGroup([FromBody] CustomerGroups.Request.EditGroup request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT-Group" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

            DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
}