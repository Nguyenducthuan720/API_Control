using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Functions.SynDataServers
{
    [ApiExplorerSettings(GroupName = "Microservice.ServerCollect.ServerInfo")]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class ServerInfoController : Controller
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _GatewayDB;


        public ServerInfoController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _GatewayDB = Global.ListDB?.Find(item => item.DBType == "GAT")?.DBString!;

        }

        /// <summary>
        /// ServerInfo
        /// </summary>
        /// <remarks>Get ds server</remarks>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetListServer()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _GatewayDB, _ConfigurationDB, "ExecListServer", null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}