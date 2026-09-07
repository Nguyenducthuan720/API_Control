using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Dynamic;
using static APISmartCity.Models.GuestContacts.Request;


namespace APISmartCity.Controllers.Ver2
{
    [ApiExplorerSettings(GroupName = "Functions.General.Contacts")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class FuncContactsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly APIInfo _apiInfo;
        private readonly string _ConfigurationDB;
        private readonly string _SecondaryDB;
        private readonly string _ProcedureName = "ExecFuncContacts";

        public FuncContactsController(UserInfo userInfo, APIInfo apiInfo)
        {
            _UserInfo = userInfo;
            _apiInfo = apiInfo;
            _apiInfo = apiInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromBody] Default.Request.GetByGeoCode request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Dashboard(Default.Request.GetByGeoCode request)
        {
            try
            {
                var dayParameters = new Dictionary<string, object>
                {
                    { "@type", "Dashboard" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(dayParameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    dynamic results = new ExpandoObject();
                    results.Total = result[0]!;
                    results.Today = result[1]!;
                    dataResponse.Result = results;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] Default.Request.ID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Add request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditContacts request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedback([FromBody] SendFeedback request)
        {
            try
            {
                Dictionary<string, object> mailParameters = new()
                {
                    { "@type", "GET-TOSEND" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID } //1
                };
                DataResponse mailDataResponse = await Function.GetDataResponse(mailParameters, _SecondaryDB, _ConfigurationDB, _ProcedureName, request!);
                var mailResult = mailDataResponse.Result[0];

                MailMessage Email = new()
                {
                    From = new MailAddress(mailResult.FromEmail)
                };
                Email.To.Add(mailResult.ToEmail);
                Email.CC.Add(mailResult.Extension11);
                Email.Subject = request.FeedbackSubject;
                Email.Body = request.Feedback;
                Email.IsBodyHtml = true;

                SmtpClient MailClient = new(mailResult.EmailServer, mailResult.EmailPort);
                MailClient.EnableSsl = mailResult.EmailSSL == 1;
                MailClient.UseDefaultCredentials = false;
                MailClient.Credentials = new NetworkCredential(mailResult.FromEmail, mailResult.Extension12);
                MailClient.Send(Email);

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "FEEDBACK" },
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
        public async Task<IActionResult> Del([FromBody] DelContacts request)
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