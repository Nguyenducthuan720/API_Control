using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Configs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Tools")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _TestDB;

        public ToolsController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _TestDB = Global.ListDB?.Find(item => item.DBType == "TES")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> ConvertNum2Text([FromBody] Tools.Request.ConvertNum2Text request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ToolConvertNum2Text", request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBusStop()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _TestDB, _ConfigurationDB, "UpdateBusStop", null!);
                dynamic result = dataResponse.Result;
                List<dynamic> results = new();
                foreach (dynamic item in result)
                {
                    Tools.Request.BusStops busStops = new()
                    {
                        Name = item.Name,
                        NameExtention1 = item.NameExtention1,
                        Address = item.Address,
                        AddressExtention1 = item.AddressExtention1.Replace(".", ""),
                        Extention1 = item.Extention1,
                        ID = item.ID,
                        Lat = item.Lat == 0 ? item.Extention1 != "" ? decimal.Parse(item.Extention1.Split(",")[0]) : 0 : item.Lat,
                        Long = item.Long == 0 ? item.Extention1 != "" ? decimal.Parse(item.Extention1.Split(",")[1]) : 0 : item.Long,
                    };

                    results.Add(await busStops.Translate());
                }
                parameters = new()
                {
                    { "@type", "Update" },
                    { "@json", JsonSerializer.Serialize(results) },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponses = await Function.GetDataResponse(parameters, _TestDB, _ConfigurationDB, "UpdateBusStop", null!);
                return Ok(dataResponses);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}