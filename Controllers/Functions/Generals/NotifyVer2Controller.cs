using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APISmartCity.Controllers.Categorys
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Notify")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class NotifyVer2Controller : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _SecondaryDB;
        private readonly string _ProcedureName = "ExecNotificationsVer3";

        public NotifyVer2Controller(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] NotifyVer2.Request.Get request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetTop20([FromBody] NotifyVer2.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-TOP20" },
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

        [HttpPost]
        public async Task<IActionResult> GetTotal([FromBody] NotifyVer2.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-TOTAL" },
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

        [HttpPost]
        public async Task<IActionResult> UpdateView([FromBody] NotifyVer2.Request.UpView request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT-ISVIEW" },
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

        [HttpPost]
        public async Task<IActionResult> DeleteNotifyByListDetails([FromBody] NotifyVer2.Request.UpView request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DELETE-BYLIST" },
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

        [HttpPost]
        public async Task<IActionResult> DeleteNotifyAll([FromBody] NotifyVer2.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DELETE-ALL" },
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
}