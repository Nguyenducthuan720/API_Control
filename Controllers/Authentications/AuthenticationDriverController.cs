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

namespace APISmartCity.Controllers
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Authentication")]
    [SwaggerTag("Microservice.Init.Authentication")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class AuthenticationDriverController : Controller
    {
        private readonly IConfiguration _Configuration;
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecAuthenticationDrivernPL";
        private readonly int _ExpireMinute = 1;

        public AuthenticationDriverController(IConfiguration configuration, UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _Configuration = configuration;
            _ExpireMinute = _Configuration.GetValue<int>("JwtToken:ExpireMinute");
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// Authentication Driver
        /// </summary>
        /// <remarks>Authentication Driver</remarks>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> CheckUser([FromBody] Users.Request.UserLoginRequest request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "CheckUser" },
                    { "@language", _UserInfo.Language }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, null!, "-1"));
            }
        }

        /// <summary>
        /// Authentication Driver
        /// </summary>
        /// <remarks>Authentication Driver</remarks>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> LoginDriver([FromBody] Users.Request.UserLoginRequest request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "LoginDriver" },
                    { "@language", _UserInfo.Language }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result?.Count > 0 && dataResponse.ErrorCode == "0")
                {
                    dynamic result = dataResponse.Result![0];
                    string CmpnID = Convert.ToString(result.CmpnID ?? "");
                    JwtSecurityTokenHandler tokenHandler = new();
                    byte[] key = Encoding.UTF8.GetBytes(_Configuration["JwtToken:SecretKey"]);
                    string UserID = Convert.ToString(result.ID);
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
                        { "@language", _UserInfo.Language }
                    };
                    await Function.GetDataResponse(parameter1, _ConfigurationDB, _ConfigurationDB, "ExecRefreshTokens", _refreshTokenObj);
                    result.Token = tokenHandler.WriteToken(token);
                    result.RefreshToken = _refreshTokenObj.Refreshtoken;
                    dataResponse.Result = new List<dynamic>() { result };
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, null!, "-1"));
            }
        }

        /// <summary>
        /// RefreshToken
        /// </summary>
        /// <remarks>RefreshToken</remarks>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> RefreshToken([FromBody] Users.Request.RefreshTokenRequest request)
        {
            try
            {
                string newRefreshToken = Guid.NewGuid().ToString();
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
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
                    JwtSecurityTokenHandler tokenHandler = new();
                    SecurityTokenDescriptor tokenDescriptor = new()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, dataResponse.Result![0].Username ?? "0")
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(_ExpireMinute),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                    dataResponse = new DataResponse("", new { Token = tokenHandler.WriteToken(token), RefreshToken = newRefreshToken }, "0");
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
        /// Đổi mật khẩu Driver
        /// </summary>
        /// <remarks>Đổi mật khẩu Driver</remarks>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> ChangePasswordDriver([FromBody] Users.Request.ChangePassword request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ChangePasswordDriver" },
                    { "@language", _UserInfo.Language }
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