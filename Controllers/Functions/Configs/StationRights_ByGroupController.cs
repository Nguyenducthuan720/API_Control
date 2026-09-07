using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.StationRight_ByGroups")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class StationRights_ByGroupController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _SecondaryDB;
        private readonly string _ProcedureName = "ExecStationRight_ByGroups";
        private readonly string _SecondProcedureName = "ExecDataTypes";

        public StationRights_ByGroupController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] ConfigStationRights.Request.Get request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetChild([FromBody] ConfigStationRights.Request.GetChild request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_CHILD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetIsSelected([FromBody] ConfigStationRights.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ISSELECTED" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetNotSelected([FromBody] ConfigStationRights.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-NOTSELECTED" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetGeoCode()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-RIGHT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ConfigStationRights.Request.EditRight request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditByList([FromBody] ConfigStationRights.Request.EditRightByList request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITLIST" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInfo([FromBody] ConfigStationRights.Request.AddInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "AddInfo" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DelInfo([FromBody] ConfigStationRights.Request.AddInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DelInfo" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}