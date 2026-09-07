using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace OsControl.Controllers.ShareData.PMS
{
    [ApiExplorerSettings(GroupName = "Microservice.ShareData.Authentication")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ShareAuthenticationController : Controller
    {
        private readonly IConfiguration _Configuration;
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly int _ExpireMinute = 1;
        private readonly IMemoryCache _memoryCache;

        public ShareAuthenticationController(IConfiguration configuration, UserInfo userInfo, IMemoryCache memoryCache)
        {
            _UserInfo = userInfo;
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
        [Route("api/share-authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> LoginUserCmpnID([FromBody] Users.Request.UserLoginCmpnRequest request)
        {
            try
            {
                DataResponse dataResponse = new();
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
                        { "IsUserDomain", IsUserDomain == true ? 1 : 0 }
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
    }
}