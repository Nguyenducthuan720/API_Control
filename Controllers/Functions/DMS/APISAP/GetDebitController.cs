using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Function;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.DMS.TaskIntegrations
{
    [ApiExplorerSettings(GroupName = "Functions.APISAP")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class DebitController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecGetDebitSAP";

        public DebitController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetDebit([FromBody] CustomerProfiles.Request.GetByCustomerID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "getdebit" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}