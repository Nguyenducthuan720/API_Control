using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.MailConfigs")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class MailConfigsVer2Controller : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecMailConfig";

        public MailConfigsVer2Controller(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SendMailCC([FromBody] MailConfigs.Request.Content request)
        {
            try
            {
                using (MailMessage Email = new MailMessage())
                {
                    // 📨 FROM (lấy mail đầu tiên trong danh sách)
                    var fromAddress = request.Email.Split(';', StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                    Email.From = new MailAddress(fromAddress);

                    // 📨 TO
                    foreach (var to in request.Email.Split(';', StringSplitOptions.RemoveEmptyEntries))
                        Email.To.Add(to.Trim());

                    // 📨 CC
                    if (!string.IsNullOrWhiteSpace(request.EmailCC))
                    {
                        foreach (var cc in request.EmailCC.Split(';', StringSplitOptions.RemoveEmptyEntries))
                            Email.CC.Add(cc.Trim());
                    }

                    // 🧾 SUBJECT & BODY lấy từ payload
                    Email.Subject = string.IsNullOrWhiteSpace(request.Subject) ? "(No Subject)" : request.Subject;
                    Email.Body = string.IsNullOrWhiteSpace(request.Body) ? "" : request.Body;
                    Email.IsBodyHtml = true;

                    using (SmtpClient MailClient = new SmtpClient(request.MailServer, request.MailPort))
                    {
                        MailClient.EnableSsl = request.SSL == 1;
                        MailClient.UseDefaultCredentials = false;
                        MailClient.Credentials = new System.Net.NetworkCredential(fromAddress, request.MailPass);

                        await MailClient.SendMailAsync(Email);
                    }
                }

                return Ok(new DataResponse("Send mail successful", "", "0"));
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get()
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
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] MailConfigs.Request.GetByMailConfigID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GETBYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        /// <summary>
        /// Lấy mail theo cty
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> GetByCompany([FromBody] MailConfigs.Request.GetByCmpnID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_BYCOMPANY" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mail
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MailConfigs.Request.Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] MailConfigs.Request.Edit request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStatus([FromBody] MailConfigs.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xóa mail
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] MailConfigs.Request.Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}