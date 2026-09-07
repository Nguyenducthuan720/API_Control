using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Complaints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;

namespace APISmartCity.Controllers.Ver2;

[ApiExplorerSettings(GroupName = "Functions.SaleSupports.Complaints")]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class ComplaintsController : ControllerBase
{
    private readonly UserInfo _UserInfo;
    private readonly string _ConfigurationDB;
    private readonly string _SecondaryDB;
    private readonly string _ProcedureName = "ExecComplaints";

    public ComplaintsController(UserInfo userInfo)
    {
        _UserInfo = userInfo;
        _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
    }

    /// <summary>
    /// Get danh sách KN/BH
    /// </summary>
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
    /// <summary>
    /// Get chi tiết KN/BH
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetByID([FromBody] Complaints.Request.GetByOID request)
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

                List<dynamic> listSO = dataResponse.Result[1];
                List<dynamic> listItem = dataResponse.Result[2];
                List<dynamic> listTask = dataResponse.Result[3];

                foreach (var so in listSO)
                {
                    // Tìm các Item theo ReferenceID
                    var items = listItem
                        .Where(item => item.ReferenceID?.ToString() == so.ReferenceID?.ToString())
                        .ToList();

                    foreach (var item in items)
                    {
                        var parentID = Convert.ToInt32(item.ID);

                        item.ListTask = listTask
                            .Where(t => Convert.ToInt32(t.ParentID) == parentID)
                            .ToList();
                    }

                    // Gắn danh sách item vào SO
                    so.ListItem = items;
                }

                result.ListSO = listSO;
                result.Chat = dataResponse.Result[4];
                result.Progress = dataResponse.Result[5];
                result.Histories = dataResponse.Result[6];
                result.Customize = dataResponse.Result[7];

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
    /// <summary>
    /// Get danh sách mã CT tham chiếu trước đó 
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetByCusID([FromBody] Complaints.Request.GetByCusID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-BY-CUSID" },
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

    /// <summary>
    /// GET danh sách cho mobile Cshop
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetMobile()
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
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    /// <summary>
    /// Get chi tiết cho mobile Cshop
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetMobileByID([FromBody] Complaints.Request.GetByOID request)
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
                result.Progress = dataResponse.Result[1];
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

    /// <summary>
    /// Get danh sách OD theo SO
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetODBySO([FromBody] Complaints.Request.GetODBySo request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-OD-BYSO" },
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

    /// <summary>
    /// Get danh sách điều xe ngoài
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetNotOD()
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-NOTOD" },
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

    /// <summary>
    /// GET danh sách đơn hàng của khách hàng
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetSOByCusID([FromBody] Complaints.Request.GetSOByCusID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-SO-BYCUSID" },
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

    /// <summary>
    /// GET sản phẩm theo đơn hàng
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetItemBySO([FromBody] Complaints.Request.GetByOID request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "GET-ITEM-BYSO" },
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
    /// <summary>
    /// Thêm khiếu nại/bảo hành
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Complaints.Request.Add request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    /// <summary>
    /// Chỉnh sửa khiếu nại/bảo hành
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] Complaints.Request.Edit request)
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
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    /// <summary>
    /// Xóa khiếu nại/bảo hành
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] Complaints.Request.GetByOID request)
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
    /// <summary>
    /// Khóa khiếu nại/bảo hành
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Submit([FromBody] Complaints.Request.Submit request)
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
    /// <summary>
    /// Cập nhật đánh giá chất lượng
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateRating([FromBody] Complaints.Request.UpdateRating request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "UPDATE-RATING" },
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
    /// <summary>
    /// Cập nhật đóng hồ sơ
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateClose([FromBody] Complaints.Request.UpdateClose request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "UPDATE-CLOSE" },
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
    /// <summary>
    /// Cập nhật tiếp nhận yều câu cho khách hàng
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateRequest([FromBody] Complaints.Request.UpdateRequest request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "UPDATE-REQUEST" },
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
    /// <summary>
    /// Phản hồi kết quả cho khách hàng
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateResponse([FromBody] Complaints.Request.UpdateResponse request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "UPDATE-RESPONSE" },
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
     /// <summary>
     /// Thêm hồ sơ 
     /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddProfile([FromBody] Complaints.Request.AddProfile request)
    {
        try
        {
            // Parse từng ListErrors thành JSON và gán vào ItemListErrors
            foreach (var item in request.ListItem)
            {
                item.ItemListErrors = JsonConvert.SerializeObject(item.ListErrors);
                item.ListErrors = null; // bỏ nếu không cần truyền thừa
            }

            var dataJson = JsonConvert.SerializeObject(request.ListItem);
            request.ListItem = null;
            Dictionary<string, object> parameters = new()
            {
                { "@type", "ADD-PROFILE" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@dataJson", dataJson }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    /// <summary>
    /// Chỉnh sửa hồ sơ 
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> EditProfile([FromBody] Complaints.Request.AddProfile request)
    {
        try
        {
            // Parse từng ListErrors thành JSON và gán vào ItemListErrors
            foreach (var item in request.ListItem)
            {
                item.ItemListErrors = JsonConvert.SerializeObject(item.ListErrors);
                item.ListErrors = null;
            }

            var dataJson = JsonConvert.SerializeObject(request.ListItem);
            request.ListItem = null;
            Dictionary<string, object> parameters = new()
            {
                { "@type", "EDIT-PROFILE" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                { "@dataJson", dataJson }
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    /// <summary>
    /// Xóa hồ sơ 
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> DeleteProfile([FromBody] Complaints.Request.DeleteProfile request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "DEL-PROFILE" },
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

    /// <summary>
    /// Xác nhận hồ sơ 
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> SubmitProfile([FromBody] Complaints.Request.SubmitProfile request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "SUBMIT-PROFILE" },
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
    /// <summary>
    /// Cập nhật tiếp nhận và chuyển bộ phận liên quan
    /// </summary>
 
    [HttpPost]
    public async Task<IActionResult> ReceptionItem([FromBody] Complaints.Request.ReceptionItem request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "RECEPTION-ITEM" },
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
    /// <summary>
    /// Cập nhật thông tin phản hồi 
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ResponseItem([FromBody] Complaints.Request.ResponseItem request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "RESPONSE-ITEM" },
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
    /// <summary>
    /// Cập nhật quyết định xử lý và các công việc
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ProcessItem([FromBody] Complaints.Request.ProcessItem request)
    {
        try
        {
            var dataTaskJson = JsonConvert.SerializeObject(request.ListTask);
            request.ListTask = null;
            Dictionary<string, object> parameters = new()
            {
                { "@type", "PROCESS-ITEM" },
                { "@language", _UserInfo.Language },
                { "@UserIDCurent", _UserInfo.UserID },
                { "@CmpnID", _UserInfo.CmpnID },
                {"@dataTaskJson" ,  dataTaskJson}
            };
            DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
            return Ok(dataResponse);
        }
        catch (Exception ex)
        {
            return Ok(new DataResponse(ex.Message, "", "-1"));
        }
    }
    /// <summary>
    /// Cập nhật đánh giá / kết quả xử lý
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ProcessFeedback([FromBody] Complaints.Request.ProcessFeedback request)
    {
        try
        {
            Dictionary<string, object> parameters = new()
            {
                { "@type", "PROCESS-FEEDBACK" },
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