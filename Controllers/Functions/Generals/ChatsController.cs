using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using APISmartCity.DI;
using APISmartCity.Models;
using APISmartCity.lib;
using APISmartCity.GoogleTranslateServices;
using System.Dynamic;
using DMS.Models.Generals.Configs;

namespace DMS.Controllers.Functions.Generals
{
    [ApiExplorerSettings(GroupName = "Functions.Generals.Chats")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _RunDB;
        private readonly string _ProcedureName = "ExecChats";
        private readonly GoogleTranslateService _translate;

        public ChatsController(UserInfo userInfo, GoogleTranslateService googleTranslate)
        {
            _translate = googleTranslate;
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _RunDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        /// <summary>
        /// Lấy danh sách chat theo điều kiện
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Danh sách chat</returns>
        [HttpPost("Get")]
        public async Task<IActionResult> Get([FromBody] ChatsModel.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy thông tin chat theo ID
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Thông tin chi tiết chat</returns>
        [HttpPost("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] ChatsModel.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic result = new ExpandoObject();
                    result.Details = dataResponse.Result[0];
                    result.Historys = dataResponse.Result[1];
                    dataResponse.Result = result;
                }
                else
                {
                    dataResponse.Result = null;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới chat
        /// </summary>
        /// <param name="request">Thông tin chat cần thêm</param>
        /// <returns>Kết quả thêm chat</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ChatsModel.Request.Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Cập nhật thông tin chat
        /// </summary>
        /// <param name="request">Thông tin chat cần cập nhật</param>
        /// <returns>Kết quả cập nhật chat</returns>
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] ChatsModel.Request.Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xóa chat
        /// </summary>
        /// <param name="request">Thông tin chat cần xóa</param>
        /// <returns>Kết quả xóa chat</returns>
        [HttpPost("Del")]
        public async Task<IActionResult> Del([FromBody] ChatsModel.Request.Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
} 