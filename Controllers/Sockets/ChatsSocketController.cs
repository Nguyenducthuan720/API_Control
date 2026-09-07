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
using DMS.Models.Sockets;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Sockets
{
    [ApiExplorerSettings(GroupName = "Sockets.Chats")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChatsSocketController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _RunDB;
        private readonly string _ProcedureName = "ExecChats";
        private readonly GoogleTranslateService _translate;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatsSocketController(
            UserInfo userInfo, 
            GoogleTranslateService googleTranslate,
            IHubContext<ChatHub> hubContext)
        {
            _translate = googleTranslate;
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _RunDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Kết nối vào phòng chat
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Kết quả kết nối</returns>
        [HttpPost("Connect")]
        public async Task<IActionResult> Connect([FromBody] ChatsSocketModel.Request.Connect request)
        {
            try
            {
                // Tạo group name
                string groupName = $"Chat_{request.FactorID}_{request.EntryID}_{request.OID}";

                // Gửi thông báo có user mới tham gia
                await _hubContext.Clients.Group(groupName).SendAsync("UserJoined", new
                {
                    UserID = request.UserID,
                    GroupName = groupName
                });

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Gửi tin nhắn
        /// </summary>
        /// <param name="request">Thông tin tin nhắn</param>
        /// <returns>Kết quả gửi tin nhắn</returns>
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] ChatsSocketModel.Request.SendMessage request)
        {
            try
            {
                // Tạo group name
                string groupName = $"Chat_{request.FactorID}_{request.EntryID}_{request.OID}";

                // Lưu tin nhắn vào database
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _RunDB, _ConfigurationDB, _ProcedureName, request);

                if (dataResponse.ErrorCode == "0")
                {
                    // Gửi tin nhắn đến tất cả user trong group
                    await _hubContext.Clients.Group(groupName).SendAsync("ReceiveMessage", new
                    {
                        UserID = request.UserID,
                        UserName = request.UserName,
                        ChatType = request.ChatType,
                        ChatMessage = request.ChatMessage,
                        CreatedDate = DateTime.Now
                    });
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Ngắt kết nối khỏi phòng chat
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Kết quả ngắt kết nối</returns>
        [HttpPost("Disconnect")]
        public async Task<IActionResult> Disconnect([FromBody] ChatsSocketModel.Request.Disconnect request)
        {
            try
            {
                // Tạo group name
                string groupName = $"Chat_{request.FactorID}_{request.EntryID}_{request.OID}";

                // Gửi thông báo user đã rời đi
                await _hubContext.Clients.Group(groupName).SendAsync("UserLeft", new
                {
                    UserID = request.UserID,
                    GroupName = groupName
                });

                return Ok(new DataResponse("Disconnected successfully", "", "0"));
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
} 