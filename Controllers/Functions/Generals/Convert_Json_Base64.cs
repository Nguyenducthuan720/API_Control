using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APISmartCity.Lib.Function;
namespace DMS.Controllers.Functions.DMS.General.Convert
{
    [ApiExplorerSettings(GroupName = "Functions.BarCode.ConvertJsonBase64")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ConvertJsonBase64 : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Base64ToJson(Convert_Json_Base64.Base64 request)
        {
            try
            {
                var JsonData = JsonSerializer.Deserialize<dynamic>(Convert_Json_Base64.Base64ToString(request.Base64String));
                return Ok(new
                {
                    StatusCode = 200,
                    Success = 1,
                    ErrorCode = "0",
                    Message = "Xử lý thành công",
                    Result = JsonData
                });
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> JsonToBase64(Convert_Json_Base64.Json request)
        {
            try
            {

                string rawJsonString = request.JsonString.GetRawText();

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(rawJsonString);

                string formattedJsonString = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                var base64Json = Convert_Json_Base64.StringToBase64(formattedJsonString);

                return Ok(new
                {
                    StatusCode = 200,
                    Success = 1,
                    ErrorCode = "0",
                    Message = "Xử lý thành công",
                    Result = base64Json
                });
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}
