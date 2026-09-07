using APISmartCity.DI;
using APISmartCity.GoogleTranslateServices;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.DMS.TradeMKTs.Media
{
    [ApiExplorerSettings(GroupName = "Functions.Media.SyncData")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecSyncFiles";
        private readonly GoogleTranslateService _translate;

        public SyncController(UserInfo userInfo, GoogleTranslateService googleTranslate)
        {
            _translate = googleTranslate;
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> GetSync()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetSync" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}