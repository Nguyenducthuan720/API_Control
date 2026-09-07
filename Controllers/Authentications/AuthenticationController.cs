using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using System.DirectoryServices.AccountManagement;
using System.Net;

namespace APISmartCity.Controllers
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Authentication")]
    [SwaggerTag("Microservice.Init.Authentication")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _Configuration;
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly int _ExpireMinute = 1;
        private readonly IMemoryCache _memoryCache;

        public AuthenticationController(IConfiguration configuration, UserInfo userInfo, IMemoryCache memoryCache)
        {
            this._UserInfo = userInfo;
            _Configuration = configuration;
            _ExpireMinute = _Configuration.GetValue<int>("JwtToken:ExpireMinute");
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Người dùng đăng nhập
        /// </summary>
        /// <remarks>Người dùng đăng nhập</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> LoginUserCmpnID([FromBody] Users.Request.UserLoginCmpnRequest request)
        {
            try
            {
                DataResponse dataResponse = new();
                if(request.UserName.ToUpper() == "PMS")
                {
                    dataResponse.StatusCode = (int)HttpStatusCode.Forbidden;
                    dataResponse.ErrorCode = "401";
                    dataResponse.Message = "Access denied";
                    dataResponse.Success = 1; 

                    return Ok(dataResponse);
                }

                bool IsUserDomain = false;
                if (Global.IsUserDomain == "1" || Global.IsUserDomain == "2")
                {
                    IsUserDomain = Function2.ValidateUser(request.UserName, request.UserPassword);

                    if (IsUserDomain == false)
                    {
                        if(Global.IsUserDomain == "1")
                        {
                            dataResponse.StatusCode = 200;
                            dataResponse.Message = $"Sai Tên đăng nhập hoặc Mật khẩu";
                            dataResponse.ErrorCode = "009";
                            dataResponse.Result = null;
                            return Ok(dataResponse);
                        }    
                    }
                }

                if (Global.IsUserDomain != "1" || IsUserDomain == true)
                {
                    Dictionary<string, object> parameters = new()
                    {
                        { "@type", "LOGIN-CmpnID" },
                        { "@language", _UserInfo.Language },
                        { "IsUserDomain", (IsUserDomain == true ? 1 : 0) }
                    };


                    dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);

                    if (dataResponse.Result?.Count > 0 && dataResponse.ErrorCode == "0")
                    {
                        dynamic result = dataResponse.Result![0];
                        string UserID = Convert.ToString(result.UserID ?? "");
                        if (UserID != "")
                        {
                            string CmpnID = Convert.ToString(result.CmpnID ?? "");
                            JwtSecurityTokenHandler tokenHandler = new();
                            byte[] key = Encoding.UTF8.GetBytes(_Configuration["JwtToken:SecretKey"]);
                            DateTime Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute);
                            SecurityTokenDescriptor tokenDescriptor = new()
                            {
                                Subject = new ClaimsIdentity(new Claim[]
                                {
                                new Claim(ClaimTypes.Name, UserID),
                                new Claim("CmpnID", CmpnID)
                                }),
                                Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                            };
                            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                            RefreshToken _refreshTokenObj = new()
                            {
                                Username = UserID,
                                Refreshtoken = Guid.NewGuid().ToString()
                            };
                            Dictionary<string, object> parameter1 = new()
                            {
                                { "@type", "ADD" },
                                { "@language", _UserInfo.Language },
                                { "@CmpnID", CmpnID },
                                { "@TokenLogin", tokenHandler.WriteToken(token) },
                                { "@Expires", Expires }
                            };
                            await Function.GetDataResponse(parameter1, _ConfigurationDB, _ConfigurationDB, "ExecRefreshTokens", _refreshTokenObj);
                            result.Token = tokenHandler.WriteToken(token);
                            result.RefreshToken = _refreshTokenObj.Refreshtoken;
                            dataResponse.Result = new List<dynamic>() { result };
                        }
                    }
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, null!, "-1"));
            }
        }

        /// <summary>
        /// Chuyển công ty
        /// </summary>
        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> SwitchCompanyUserCmpnID([FromBody] Users.Request.SwitchCompanyUserCmpnID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SWITCH-CmpnID" },
                    { "@language", _UserInfo.Language },
                    { "@UserID", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters,_ConfigurationDB,_ConfigurationDB,"ExecAuthenticationSystem",request);

                if (dataResponse.Result?.Count > 0 && dataResponse.ErrorCode == "0")
                {
                    dynamic result = dataResponse.Result![0];
                    string UserID = Convert.ToString(result.UserID ?? "");
                    if (!string.IsNullOrEmpty(UserID))
                    {
                        string NewCmpnID = Convert.ToString(result.CmpnID ?? "");
                        JwtSecurityTokenHandler tokenHandler = new();
                        byte[] key = Encoding.UTF8.GetBytes(_Configuration["JwtToken:SecretKey"]);
                        DateTime Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute);
                        SecurityTokenDescriptor tokenDescriptor = new()
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, UserID),
                                new Claim("CmpnID", NewCmpnID)
                            }),
                            Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                        RefreshToken refreshTokenObj = new()
                        {
                            Username = UserID,
                            Refreshtoken = Guid.NewGuid().ToString()
                        };

                        Dictionary<string, object> parameter1 = new()
                        {
                            { "@type", "ADD" },
                            { "@language", _UserInfo.Language },
                            { "@CmpnID", NewCmpnID },
                            { "@TokenLogin", tokenHandler.WriteToken(token) },
                            { "@Expires", Expires }
                        };
                        await Function.GetDataResponse(parameter1, _ConfigurationDB, _ConfigurationDB, "ExecRefreshTokens", refreshTokenObj);
                        result.Token = tokenHandler.WriteToken(token);
                        result.RefreshToken = refreshTokenObj.Refreshtoken;
                        dataResponse.Result = new List<dynamic>() { result };
                    }
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, null!, "-1"));
            }
        }


        ///// <summary>
        ///// Người dùng đăng nhập
        ///// </summary>
        ///// <remarks>Người dùng đăng nhập</remarks>
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //[ProducesResponseType(200, Type = typeof(DataResponse))]
        //public async Task<IActionResult> LoginUserApp([FromBody] Users.Request.UserLoginApp request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "LOGIN-APP" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = new();
        //        dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        if (dataResponse.Result?.Count > 0 && dataResponse.ErrorCode == "0")
        //        {
        //            dynamic result = dataResponse.Result![0];
        //            string UserID = Convert.ToString(result.UserID ?? "");
        //            if (UserID != "")
        //            {
        //                string CmpnID = Convert.ToString(result.CmpnID ?? "");
        //                JwtSecurityTokenHandler tokenHandler = new();
        //                byte[] key = Encoding.UTF8.GetBytes(_Configuration["JwtToken:SecretKey"]);
        //                DateTime Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute);
        //                SecurityTokenDescriptor tokenDescriptor = new()
        //                {
        //                    Subject = new ClaimsIdentity(new Claim[]
        //                    {
        //                    new Claim(ClaimTypes.Name, UserID),
        //                    new Claim("CmpnID", CmpnID)
        //                    }),
        //                    Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute),
        //                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //                };
        //                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        //                RefreshToken _refreshTokenObj = new()
        //                {
        //                    Username = UserID,
        //                    Refreshtoken = Guid.NewGuid().ToString()
        //                };
        //                Dictionary<string, object> parameter1 = new()
        //                {
        //                    { "@type", "ADD" },
        //                    { "@language", _UserInfo.Language },
        //                    { "@CmpnID", CmpnID },
        //                    { "@TokenLogin", tokenHandler.WriteToken(token) },
        //                    { "@Expires", Expires }
        //                };
        //                await Function.GetDataResponse(parameter1, _ConfigurationDB, _ConfigurationDB, "ExecRefreshTokens", _refreshTokenObj);
        //                result.Token = tokenHandler.WriteToken(token);
        //                result.RefreshToken = _refreshTokenObj.Refreshtoken;
        //                dataResponse.Result = new List<dynamic>() { result };
        //            }
        //        }
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, null!, "-1"));
        //    }
        //}

         
        /// <summary>
        /// RefreshToken
        /// </summary>
        /// <remarks>RefreshToken</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> RefreshToken([FromBody] Users.Request.RefreshTokenRequest request)
        {
            try
            {
                string newRefreshToken = Guid.NewGuid().ToString();
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "CHECK" },
                    { "@language", _UserInfo.Language },
                    { "@NewRefreshtoken", newRefreshToken }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecRefreshTokens", request);
                int IsRefreshToken = dataResponse.Result![0].IsRefreshToken ?? 0;
                if (IsRefreshToken == 0)
                {
                    dataResponse = new DataResponse("", new { Token = "Not_Found", RefreshToken = "Not_Found" }, "404");
                }
                else
                {
                    byte[] key = Encoding.UTF8.GetBytes(_Configuration["JwtToken:SecretKey"]);
                    string CmpnID = dataResponse.Result![0].CmpnID;
                    JwtSecurityTokenHandler tokenHandler = new();
                    DateTime Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute);
                    SecurityTokenDescriptor tokenDescriptor = new()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, dataResponse.Result![0].Username ?? "0")
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    if (CmpnID is not null)
                    {
                        tokenDescriptor.Subject.AddClaim(new Claim("CmpnID", CmpnID));
                    }
                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                    string newToken = tokenHandler.WriteToken(token);
                    Dictionary<string, object> parameter1 = new()
                        {
                            { "@type", "EDIT" },
                            { "@language", _UserInfo.Language },
                            { "@NewRefreshtoken", newRefreshToken },
                            { "@CmpnID", CmpnID },
                            { "@TokenLogin", newToken },
                            { "@Expires", Expires }
                        };
                    DataResponse editResponse = await Function.GetDataResponse(parameter1, _ConfigurationDB, _ConfigurationDB, "ExecRefreshTokens", request);
                    dataResponse = new DataResponse("", new { Token = newToken, RefreshToken = newRefreshToken }, "0");
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public IActionResult CheckToken([FromBody] Users.Request.CheckTokenRequest rt)
        {
            const string des = "";
            const string ErrorCode = "0";

            JwtSecurityToken jwtToken = new();
            try
            {
                jwtToken = new JwtSecurityToken(rt.Token);
            }
            catch
            {
                DataResponse dataResponse = new(des, new { Code = "Wrong_Format" }, "009");
                return BadRequest(dataResponse);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                DataResponse dataResponse = new(des, new { Code = "Ok" }, ErrorCode);
                return Ok(dataResponse);
            }
            else
            {
                DataResponse dataResponse = new(des, new { Code = "Expire" }, "009");
                return BadRequest(dataResponse);
            }
        }

        /// <summary>
        /// Đổi mật khẩu user
        /// </summary>
        /// <remarks>Đổi mật khẩu user</remarks>
        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> ChangePasswordUser([FromBody] Users.Request.ChangePassword request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ChangePW-CONTROL" },
                    { "@language", _UserInfo.Language }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        ///// <summary>
        ///// Đổi mật khẩu Employer
        ///// </summary>
        ///// <remarks>Đổi mật khẩu Employer</remarks>
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //[ProducesResponseType(200, Type = typeof(DataResponse))]
        //public async Task<IActionResult> ChangePasswordEmployer([FromBody] Users.Request.ChangePassword request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "ChangePW-Employer" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        ///// <summary>
        ///// Đổi mật khẩu Customer
        ///// </summary>
        ///// <remarks>Đổi mật khẩu Customer</remarks>
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //[ProducesResponseType(200, Type = typeof(DataResponse))]
        //public async Task<IActionResult> ChangePasswordCustomer([FromBody] Users.Request.ChangePassword request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "ChangePW-CUS" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        ///// <summary>
        ///// Gửi mã đổi password
        ///// </summary>
        ///// <remarks>Gửi mã đổi password</remarks>
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //public async Task<IActionResult> SendCodeForgetPassword([FromBody] Users.Request.SendCodeForgetPassword request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "SendCode-Employer" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        dynamic result = dataResponse.Result!;
        //        dataResponse.Result = null;
        //        MailMessage mailMessage = new();
        //        SmtpClient smtpClient = new(result.MailServer);
        //        mailMessage.From = new MailAddress(result.Email);
        //        mailMessage.To.Add(request.UserEmail);
        //        mailMessage.Subject = "Đặt lại mật khẩu / Reset Password";
        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.Body = $@"<html><body>
        //                                <p>Mã bảo mật của bạn là: {result.SecurityCode}. Vui lòng nhập mã trong vòng 5 phút.<p>
        //                                <p>Your security code is: {result.SecurityCode}. Please enter within 5 minutes.<p>
        //                                </body></html>";
        //        smtpClient.Port = int.Parse(result.Rows[0]["MailPort"]?.ToString());
        //        smtpClient.Credentials = new System.Net.NetworkCredential(result.Email, result.Password);
        //        smtpClient.EnableSsl = Convert.ToBoolean(result.SSL);
        //        smtpClient.Send(mailMessage);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        ///// <summary>
        ///// Đổi mật khẩu bằng mã
        ///// </summary>
        ///// <remarks>Đổi mật khẩu bằng mã</remarks>
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //public async Task<IActionResult> ChangePasswordBySecurityCode([FromBody] Users.Request.ChangePasswordBySecurityCode request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "ChangePW-Employer-ByCode" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        ///// <summary>
        ///// CheckSecurityByEmployerId
        ///// </summary>
        ///// <remarks>CheckSecurityByEmployerId</remarks>
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //public async Task<IActionResult> CheckSecurityByEmployerId([FromBody] Users.Request.CheckSecurityByEmployerId request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "Check-SecutityCode-ByEmployer" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        /// <summary>
        /// Logout
        /// </summary>
        /// <remarks>Logout</remarks>
        //[HttpPost]
        //[Route("api/authentication/[action]")]
        //[ProducesResponseType(200, Type = typeof(DataResponse))]
        //public async Task<IActionResult> Logout([FromBody] Users.Request.Logout request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "Logout" },
        //            { "@language", _UserInfo.Language }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}


        /// <summary>
        /// Đổi mật khẩu user
        /// </summary>
        /// <remarks>Đổi mật khẩu user</remarks>
        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> LogOut([FromBody] TokenAppsVer2.Request.Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "LogOut" },
                    { "@language", _UserInfo.Language },
                    { "@CmpnID", _UserInfo.CmpnID },

                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecAuthenticationSystem", request);
                _memoryCache.Remove("LinkMobileAPI");
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        private bool IsHeaderAllowed(string headerKey)
        {
            // Implement your logic to check if a header is allowed
            // For example, allow "Language" header
            return headerKey.Equals("Language", StringComparison.OrdinalIgnoreCase) ||
                   headerKey.Equals("OtherHeader", StringComparison.OrdinalIgnoreCase);
        }

    }
}