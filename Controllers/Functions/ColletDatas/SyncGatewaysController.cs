using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.SyncGateways;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Functions.SynDataServers
{
    [ApiExplorerSettings(GroupName = "Microservice.ServerCollect.SyncData")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class SyncGatewaysController : Controller
    {
        private readonly IConfiguration _Configuration;
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly int _ExpireMinute = 1;

        public SyncGatewaysController(IConfiguration configuration, UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _Configuration = configuration;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// SyncData GateWay
        /// </summary>
        /// <remarks>Sync dữ liệu từ DB qua Gateway</remarks>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> Sync([FromBody] SyncGateways.Requets.Synctype request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Sync" },
                    { "@language", _UserInfo.Language }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "SyncGateways", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}