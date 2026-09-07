using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using DMS.Models.DMS.SaleInventorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DMS.Controllers.Functions.DMS.Inventorys;

[ApiExplorerSettings(GroupName = "Functions.SaleInventorys.SaleInventoryTransfers")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class SaleInventoryTransfersController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecSaleInventoryTransfers";
    
    public SaleInventoryTransfersController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "SAL")?.DBString!;
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
    public async Task<IActionResult> GetWatch()
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-WATCH" },
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
    public async Task<IActionResult> GetOrder([FromBody] SaleInventoryTransfers.Request.GetOrders request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-ORDER" },
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
    public async Task<IActionResult> GetByID([FromBody] SaleInventoryTransfers.Request.GetByOID request)
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
                var Details = dataResponse.Result[1];

                if (dataResponse.Result.Count > 4)
                {
                    var details = dataResponse.Result[2];
                    var Progress = dataResponse.Result[3];
                    var Histories = dataResponse.Result[3];

                    var detailsList = ((IEnumerable<dynamic>)details)
                        .Cast<IDictionary<string, object>>()
                        .ToList();

                    var groupedDetails = detailsList
                        .GroupBy(d => d["OrderID"]?.ToString())
                        .ToDictionary(
                            g => g.Key!,
                            g => g.Cast<dynamic>().ToList()
                        );

                    foreach (var item in Details)
                    {
                        var itemDict = (IDictionary<string, object>)item;
                        string orderId = itemDict["OrderID"]?.ToString();

                        if (orderId != null && groupedDetails.ContainsKey(orderId))
                        {
                            itemDict["Details"] = groupedDetails[orderId];
                        }
                    }

                    result.Details = Details;
                    result.Progress = Progress;
                    result.Histories = Histories;
                }
                else
                {
                    result.Details = Details;
                    result.Progress = dataResponse.Result[2];
                    result.Histories = dataResponse.Result[3];
                }

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
    public async Task<IActionResult> Add([FromBody] SaleInventoryTransfers.Request.AddOrEdit request)
    {
        try
        {
            var detailJson = JsonConvert.SerializeObject(request.Details);
            request.Details = null;

            Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@dataJson", detailJson }
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
    public async Task<IActionResult> Edit([FromBody] SaleInventoryTransfers.Request.Edit request)
    {
        try
        {
            var detailJson = request.Details == null ? "[]" : JsonConvert.SerializeObject(request.Details);
            request.Details = null;

            Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@dataJson", detailJson }
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
    public async Task<IActionResult> Delete([FromBody] SaleInventoryTransfers.Request.Del request)
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
    public async Task<IActionResult> Submit([FromBody] SaleInventoryTransfers.Request.Submit request)
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