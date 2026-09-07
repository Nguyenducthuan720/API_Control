using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APISmartCity.Controllers.Ver2;

[ApiExplorerSettings(GroupName = "Functions.Contracts.Contracts")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class ContractsController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecContracts";

    public ContractsController(UserInfo userInfo)
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
    public async Task<IActionResult> GetDiscounts([FromBody] Contracts.Request.GetDiscounts request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-DISCOUNTS" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID }
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
    public async Task<IActionResult> GetItems([FromBody] Contracts.Request.GetItems request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-ITEMS" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID }
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
    public async Task<IActionResult> EditPrices([FromBody] Contracts.Request.EditPrices request)
    {
        try
        {
            var itemsJson = JsonConvert.SerializeObject(request.Items);
            request.Items = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "EDIT-PRICES" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@ItemsJson", itemsJson }
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
    public async Task<IActionResult> GetByID([FromBody] Contracts.Request.GetByOID request)
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
                result.Payments = dataResponse.Result[1];
                result.Documents = dataResponse.Result[2];
                result.Discounts = dataResponse.Result[3];
                result.Items = dataResponse.Result[4];
                result.Products = dataResponse.Result[5];
                result.Commits = dataResponse.Result[6];
                result.Orders = dataResponse.Result[7];
                result.Sponsorships = dataResponse.Result[8];
                result.Progress = dataResponse.Result[9];
                result.Histories = dataResponse.Result[10];
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
    public async Task<IActionResult> Add([FromBody] Contracts.Request.AddContract request)
    {
        try
        {
            var paymentsJson = JsonConvert.SerializeObject(request.Payments);
            var documentsJson = JsonConvert.SerializeObject(request.Documents);
            var discountsJson = JsonConvert.SerializeObject(request.Discounts);
            var itemsJson = JsonConvert.SerializeObject(request.Items);
            var productsJson = JsonConvert.SerializeObject(request.Products);
            var commitsJson = JsonConvert.SerializeObject(request.Commits);
            var ordersJson = JsonConvert.SerializeObject(request.Orders);
            var sponsorshipsJson = JsonConvert.SerializeObject(request.Sponsorships);
            request.Payments = null;
            request.Documents = null;
            request.Discounts = null;
            request.Items = null;
            request.Products = null;
            request.Commits = null;
            request.Orders = null;
            request.Sponsorships = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "ADD" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@PaymentsJson", paymentsJson },
                { "@DocumentsJson", documentsJson },
                { "@ItemsJson", itemsJson },
                { "@DiscountsJson", discountsJson },
                { "@ProductsJson", productsJson },
                { "@CommitsJson", commitsJson },
                { "@OrdersJson", ordersJson },
                { "@SponsorshipsJson", sponsorshipsJson }
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
    public async Task<IActionResult> Edit([FromBody] Contracts.Request.AddContract request)
    {
        try
        {
            var paymentsJson = JsonConvert.SerializeObject(request.Payments);
            var documentsJson = JsonConvert.SerializeObject(request.Documents);
            var discountsJson = JsonConvert.SerializeObject(request.Discounts);
            var itemsJson = JsonConvert.SerializeObject(request.Items);
            var productsJson = JsonConvert.SerializeObject(request.Products);
            var commitsJson = JsonConvert.SerializeObject(request.Commits);
            var ordersJson = JsonConvert.SerializeObject(request.Orders);
            var sponsorshipsJson = JsonConvert.SerializeObject(request.Sponsorships);
            request.Payments = null;
            request.Documents = null;
            request.Discounts = null;
            request.Items = null;
            request.Products = null;
            request.Commits = null;
            request.Orders = null;
            request.Sponsorships = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "EDIT" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@PaymentsJson", paymentsJson },
                { "@DocumentsJson", documentsJson },
                { "@ItemsJson", itemsJson },
                { "@DiscountsJson", discountsJson },
                { "@ProductsJson", productsJson },
                { "@CommitsJson", commitsJson },
                { "@OrdersJson", ordersJson },
                { "@SponsorshipsJson", sponsorshipsJson }
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
    public async Task<IActionResult> Delete([FromBody] Contracts.Request.Del request)
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
    public async Task<IActionResult> Submit([FromBody] Contracts.Request.Submit request)
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

    [HttpPost]
    public async Task<IActionResult> CustomerSign([FromBody] Contracts.Request.CustomerSign request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "CUSTOMER-SIGN" },
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
    public async Task<IActionResult> Extend([FromBody] Contracts.Request.Extend request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "EXTEND" },
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
    public async Task<IActionResult> Cancel([FromBody] Contracts.Request.Cancel request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "CANCEL" },
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