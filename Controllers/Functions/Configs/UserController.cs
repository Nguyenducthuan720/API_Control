using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.Models.GroupUsers.Request;
using static APISmartCity.Models.Users.Request;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Users")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecGroupUser";
        private readonly string _SecondProcedureName = "ExecUser";

        public UserController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// Load list group user
        /// </summary>
        /// <remarks>Load list group user</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListGroupUser([FromBody] ByGroupType request)
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
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListFullUser()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-LIST-FULL-USER" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// GetByGroupUserCode
        /// </summary>
        /// <remarks>GetByGroupUserCode</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetGroupUserByGroupUserCode([FromBody] GroupUserCodes request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load group user by ID
        /// </summary>
        /// <remarks>Load group user by ID</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetGroupUserByID([FromBody] Default.Request.ID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@GroupID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                //if (dataResponse.Result!.Count > 1)
                //{
                //    dynamic result = dataResponse.Result[0][0];
                //    result.Properties = dataResponse.Result[1];
                //    dataResponse.Result = result;
                //}
                //return Ok(dataResponse);

                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Properties = dataResponse.Result[1];
                    result.Histories = dataResponse.Result[2];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load group user have status active
        /// </summary>
        /// <remarks>Load group user have status active</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetGroupUserActive()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load group user have status active all
        /// </summary>
        /// <remarks>Load group user have status active all</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetActiveAll()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetActiveAll" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Add Group User
        /// </summary>
        /// <remarks>Add Group User</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> AddGroupUser([FromBody] Add request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Edit Group User
        /// </summary>
        /// <remarks>Edit Group User</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditGroupUser([FromBody] Edit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@GroupID", request.ID!},
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Edit Group User
        /// </summary>
        /// <remarks>Edit Group User</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditGroupUserVer2([FromBody] EditVer2 request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITVer2" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@GroupID", request.ID!},
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.ListStationRight != null)
                {
                    DataTable ListStationRight = request.ListStationRight.Where(x => x.GeoCode != null).ToList().ToDataTable();
                    ListStationRight.SetTypeName("StationRights");
                    parameters.Add("@StationRights", ListStationRight);
                    request.ListStationRight = null;
                }
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// EditStatus Group User
        /// </summary>
        /// <remarks>EditStatus Group User</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditStatusGroupUser([FromBody] EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@GroupID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Del Group User
        /// </summary>
        /// <remarks>Del Group User</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> DelGroupUser([FromBody] Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@GroupID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load groupuser by GEOCODE
        /// </summary>
        /// <remarks>Load groupuser by GEOCODE</remarks>
        [HttpPost]
        [Route("api/groupuser/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetGroupUserByGeoCode(GetGeoCode request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYGEOCODE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load user by groupid
        /// </summary>
        /// <remarks>Load user by groupid</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetUserByGroupID(GetGroupID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-GROUPID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load list user
        /// </summary>
        /// <remarks>Load list user</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListUser([FromBody] ByCmpnID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                    //{ "@CmpnID", _UserInfo.CmpnID }
                };
                //DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                APIDataResponse dataResponse = await Function2.GetDataResponse2(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIDataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// GetByGroupUserCode
        /// </summary>
        /// <remarks>GetByGroupUserCode</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetUserByGroupUserCode([FromBody] GroupUserCodes request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// GetByName
        /// </summary>
        /// <remarks>GetByName</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetUserByName([FromBody] ByName request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BY-NAME" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// </summary>
        /// <remarks>Get current user</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-CURRENT-USER" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result![0].Count > 0)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Company = dataResponse.Result[1];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }



        /// <summary>
        /// Load user by ID
        /// </summary>
        /// <remarks>Load user by ID</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetUserByUserID([FromBody] Default.Request.ID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    //result.Properties = dataResponse.Result[1];
                    result.Histories = dataResponse.Result[1];
                    result.UserRights = dataResponse.Result[2];
                    dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <remarks>Add User</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> AddUser([FromBody] AddUser request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    //{ "@CmpnID", _UserInfo.CmpnID },
                    { "@UserPassword", request.UserPassword}
                };
                request.UserPassword = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <remarks>Edit User</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditUser([FromBody] EditUser request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", request.ID!},
                    //{ "@CmpnID", _UserInfo.CmpnID }
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Edit Avatar
        /// </summary>
        /// <remarks> Edit Avatar</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditAvatar([FromBody] EditAvatar request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT-AVATAR" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", request.ID!},
                    //{ "@CmpnID", _UserInfo.CmpnID }
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// EditStatus User
        /// </summary>
        /// <remarks>EditStatus User</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditStatusUser([FromBody] EditStatusUser request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Del User
        /// </summary>
        /// <remarks>Del User</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> DelUser([FromBody] DelUser request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Reset Password User
        /// </summary>
        /// <remarks>Reset Password User</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> ResetPasswordUser([FromBody] ResetPasswordUser request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "RESET-PW" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", request.ID!},
                    { "@NewPassword", request.NewPassword}
                };
                request.ID = null;
                request.NewPassword = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy danh sách saler
        /// </summary>
        /// <remarks>Lấy danh sách saler</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetSaler()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-SALER" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên bán hàng của cửa hàng
        /// </summary>
        /// <remarks>Lấy danh sách nhân viên bán hàng của cửa hàng</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetSalerByStore([FromBody] GetSaler request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-SALER-BYSTORE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// </summary>
        /// <remarks>Get current user</remarks>
        [HttpPost]
        [Route("api/user/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetUserLogs()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-USERLOG" },
                    { "@language", _UserInfo.Language },
                     {"@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}