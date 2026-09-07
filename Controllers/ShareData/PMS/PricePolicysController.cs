using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsControl.Models.ShareData.PMS;

namespace OsControl.Controllers.ShareData.PMS
{
    [ApiExplorerSettings(GroupName = "Microservice.ShareData.PricePolicys")]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PricePolicysController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecPricePolicys";

        public PricePolicysController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "PRI")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetBasePrices([FromBody] PricePolicys.Request.GetBasePrices request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BASE-PRICES" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}