using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Lib.Function;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISmartCity.Controllers.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Base64Decode")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DecodeBase64Controller : Controller
    {
        [HttpPost]
        public async Task<IActionResult> GetDecodeBase64([FromBody] Base64Request request)
        {
            try
            {
                var JsonData = Convert_Json_Base64.Base64ToString(request.Base64String);

                return Ok(new DataResponse("Success", JsonData, "0"));
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        // Request model
        public class Base64Request
        {
            public string? Base64String { get; set; }
        }
    }
}
