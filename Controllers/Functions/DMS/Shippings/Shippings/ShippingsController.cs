using System.Collections;
using System.Dynamic;
using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Shippings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
 
namespace APISmartCity.Controllers.Ver2;

[ApiExplorerSettings(GroupName = "Functions.Shippings")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class ShippingController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecShippings";
    private readonly string _ProcedureNameDashboard = "ExecGetDashboardShippings";


    public ShippingController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "SHP")?.DBString!;
    }

    [HttpPost]
    public async Task<IActionResult> GetDashboard([FromBody] Shippings.Request.GetDashboard request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
        {
            { "@type", "GET-Dashboard" },
            { "@language", _UserInfo.Language },
            { "@UserIDCurent", _UserInfo.UserID },
            { "@CmpnID", _UserInfo.CmpnID }
        };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureNameDashboard, request);
            if (dataResponse.Result != null && dataResponse.Result.Count >= 5)
            {
                dynamic result = dataResponse.Result;
                dynamic results = new ExpandoObject();

                // Gộp SummaryShippings và SummaryMaintenances thành một Summary
                dynamic summary = new ExpandoObject();
                var summaryDict = (IDictionary<string, object>)summary;

                // Lấy dữ liệu từ SummaryShippings
                foreach (var item in result[0][0] as IDictionary<string, object>)
                {
                    summaryDict[item.Key] = item.Value;
                }

                // Lấy dữ liệu từ SummaryMaintenances và gộp vào
                foreach (var item in result[1][0] as IDictionary<string, object>)
                {
                    summaryDict[item.Key] = item.Value;
                }

                // Gán vào results
                results.Summary = new List<dynamic> { summary }; // Đưa vào danh sách để khớp cấu trúc mong muốn
                results.VehicleAlerts = result[2]!;
                results.DriverPerformances = result[3]!;
                results.HistoryActivity = result[4]!;

                dataResponse.Result = results;
            }
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> GetMapNow()
    {
        try
        {
            Dictionary<string, object> parameters = new()
        {
            { "@type", "GET-Map-Now" },
            { "@language", _UserInfo.Language },
            { "@UserIDCurent", _UserInfo.UserID },
            { "@CmpnID", _UserInfo.CmpnID }
        };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureNameDashboard, null);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> GetMapDetailByID([FromBody] Shippings.Request.GetDetailByID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
        {
            { "@type", "GET-DETAIL-BYID" },
            { "@language", _UserInfo.Language },
            { "@UserIDCurent", _UserInfo.UserID },
            { "@CmpnID", _UserInfo.CmpnID }
        };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureNameDashboard, request);
            if (dataResponse.Result is IList resultList && resultList.Count > 1)
            {
                var shippingList = (IEnumerable<dynamic>)resultList[0];
                dynamic shipping = shippingList.FirstOrDefault();

                var shippingDetails = (IEnumerable<dynamic>)resultList[1];
                var items = (IEnumerable<dynamic>)resultList[2];
                var tolls = (IEnumerable<dynamic>)resultList[3];
                var incurred = (IEnumerable<dynamic>)resultList[4];

                foreach (var detail in shippingDetails)
                {
                    string reference = detail.ReferenceID;
                    detail.Items = items
                        .Where(x => x.ReferenceID == reference)
                        .ToList();
                }

                shipping.ShippingDetails = shippingDetails;
                shipping.Tolls = tolls;
                shipping.Incurred = incurred;
                dataResponse.Result = shipping;
            }
            else if (dataResponse.Result is IList list && list.Count > 0)
            {
                dataResponse.Result = list[0];
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
    public async Task<IActionResult> Get([FromBody] Shippings.Request.GetMonitor request)
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
    public async Task<IActionResult> GetByID([FromBody] Shippings.Request.GetByOID request)
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
                result.ShippingDetails = dataResponse.Result[1];
                result.Items = dataResponse.Result[2];
                result.Tracking = dataResponse.Result[3];
                result.Histories = dataResponse.Result[4];
                result.Customize = dataResponse.Result[5];
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
    public async Task<IActionResult> GetMonitorByID([FromBody] Shippings.Request.GetByOID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
        {
            { "@type", "GET-MONITOR-BYID" },
            { "@language", _UserInfo.Language },
            { "@UserIDCurent", _UserInfo.UserID },
            { "@CmpnID", _UserInfo.CmpnID }
        };

            DataResponse dataResponse = await Function.GetDataResponse(
                parameters,
                _SecondaryDB,
                _ConfigurationDB,
                _ProcedureName,
                request
            );

            if (dataResponse.Result is not null
                && dataResponse.Result.Count >= 2
                && dataResponse.Result[0].Count > 0)
            {
                // Ép kiểu "Shipping chính"
                var shippingList = (IEnumerable<dynamic>)dataResponse.Result[0];
                dynamic shipping = shippingList.FirstOrDefault(); // Lấy record đầu tiên

                // Ép kiểu các danh sách còn lại
                var shippingDetails = (IEnumerable<dynamic>)dataResponse.Result[1];
                var items = (IEnumerable<dynamic>)dataResponse.Result[2];
                var tracking = (IEnumerable<dynamic>)dataResponse.Result[3];

                var tolls = (IEnumerable<dynamic>)dataResponse.Result[4];
                var incurred = (IEnumerable<dynamic>)dataResponse.Result[5];

                var histories = (IEnumerable<dynamic>)dataResponse.Result[4];
                var customize = (IEnumerable<dynamic>)dataResponse.Result[5];

                // Gộp Items và Tracking vào từng ShippingDetail
                foreach (var detail in shippingDetails)
                {
                    // Mặc định detail.ReferenceID là dynamic
                    string reference = detail.ReferenceID;

                    // Ép lambda thành Func<dynamic,bool>
                    var detailItems = items
                        .Where(x => x.ReferenceID == reference)
                        .ToList();

                    var detailTracking = tracking
                        .Where(x => x.ReferenceID == reference)
                        .ToList();
                    detail.Items = detailItems;
                    detail.Tracking = detailTracking;
                }
                shipping.ShippingDetails = shippingDetails;
                shipping.Tolls = tolls;
                shipping.Incurred = incurred;
                shipping.Histories = histories;
                shipping.Customize = customize;
                dataResponse.Result = shipping;
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
    public async Task<IActionResult> GetListSO([FromBody] Shippings.Request.GetSO request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-LISTSO" },
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
    public async Task<IActionResult> GetListItemBySO([FromBody] Shippings.Request.GetSoByID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-LISTITEM-BYSO" },
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
    public async Task<IActionResult> GetMonitorSO()
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-MONITOR-SO" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, null);
            if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
            {
                dynamic result = dataResponse.Result;
                dynamic results = new ExpandoObject();
                results.Summary = result[0]!;
                results.ListSO = result[1]!;
                dataResponse.Result = results;
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
    public async Task<IActionResult> GetMonitorSOByID([FromBody] Shippings.Request.GetByOID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-MONITOR-SO-BYID" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);

            if (dataResponse.Result!.Count > 1)
            {
                dynamic result = dataResponse.Result;
                dynamic results = new ExpandoObject();
                results.Order = result[0]!;
                results.OrderDetails = result[1]!;
                dataResponse.Result = results;
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
    public async Task<IActionResult> GetMoblie()
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

            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, null);

            if (dataResponse.Result != null && dataResponse.Result.Count > 1)
            {
                var resultList = (List<dynamic>)dataResponse.Result[0];
                var shippingList = (List<dynamic>)dataResponse.Result[1];
                foreach (var result in resultList)
                {
                    string oid = result.OID.ToString();
                    var shippingDetails = shippingList.Where(detail => detail.OID.ToString() == oid).ToList();
                    result.ShippingDetails = shippingDetails.Count > 0 ? shippingDetails : null;
                }

                dataResponse.Result = resultList;
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
    public async Task<IActionResult> GetMobileByID([FromBody] Shippings.Request.GetByOID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-MOBILE-BYID" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
            {
                dynamic result = dataResponse.Result[0][0];
                result.ShippingDetails = dataResponse.Result[1];
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
    public async Task<IActionResult> GetHistory([FromBody] Shippings.Request.GetHistory request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-HISTORY" },
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
    public async Task<IActionResult> GetKPI()
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-KPI" },
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
    public async Task<IActionResult> GetDrivers()
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-DRIVER" },
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
    public async Task<IActionResult> GetLicensePlateByDriverID([FromBody] Shippings.Request.GetLicensePlateByDriverID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-LicensePlates" },
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
    public async Task<IActionResult> Add([FromBody] Shippings.Request.Add request)
    {
        try
        {
            var DataDetailsJson = JsonConvert.SerializeObject(request.Item);
            request.Item = null;

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
    public async Task<IActionResult> Edit([FromBody] Shippings.Request.Add request)
    {
        try
        {
            var DataDetailsJson = JsonConvert.SerializeObject(request.Item);
            request.Item = null;

            Dictionary<string, object> parameters = new()
            {
                { "@type", "EDIT" },
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
    public async Task<IActionResult> Delete([FromBody] Shippings.Request.Del request)
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
    public async Task<IActionResult> Submit([FromBody] Shippings.Request.Submit request)
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
    public async Task<IActionResult> Confirm([FromBody] Shippings.Request.Confirm request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "CONFIRM" },
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
    public async Task<IActionResult> Running([FromBody] Shippings.Request.Running request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "RUNNING" },
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
    public async Task<IActionResult> Finished([FromBody] Shippings.Request.Finished request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "FINISHED" },
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
    public async Task<IActionResult> Cancel([FromBody] Shippings.Request.Cancel request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "CANCELED" },
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