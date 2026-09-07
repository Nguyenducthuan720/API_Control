using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using APISmartCity.Models.Ver2.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.Menu")]
    [Authorize]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecMenu";
        private readonly string _SecondProcedureName = "ExecMenuRight";

        public MenuController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        /// <summary>
        /// Load Menu System
        /// </summary>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListMenu()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
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
        /// Load Menu System
        /// </summary>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetParentID([FromBody] Default.Request.ParentID_ByString request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-PARENTID" },
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

        [HttpPost]
        [Route("api/menu/[action]")]
        public async Task<IActionResult> GetMenuById([FromBody] Default.Request.ID_ByString request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@MenuID", request.ID!}
                };
                request.ID = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Properties = dataResponse.Result[1];
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
        /// Chỉnh sửa tên menu
        /// </summary>
        /// <remarks>chỉnh sửa tên menu</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> AddMenu([FromBody] Menus.Request.EditName request)
        {
            try
            {
                var datas = JsonConvert.SerializeObject(request.Datas);
                request.Datas = null;

                var datasNotify = JsonConvert.SerializeObject(request.DatasNotify);
                request.DatasNotify = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@data1", datas },
                    { "@data2", datasNotify }
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
        /// Chỉnh sửa tên menu
        /// </summary>
        /// <remarks>chỉnh sửa tên menu</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditMenu([FromBody] Menus.Request.EditName request)
        {
            
            try
            {
                var datas = JsonConvert.SerializeObject(request.Datas);
                request.Datas = null;

                var datasNotify = JsonConvert.SerializeObject(request.DatasNotify);
                request.DatasNotify = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@data1", datas },
                    { "@data2", datasNotify }

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
        /// Chỉnh sửa tên menu
        /// </summary>
        /// <remarks>chỉnh sửa tên menu</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditLinkDoc([FromBody] Menus.Request.EditExtention request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Edit-LinkDoc" },
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
        /// Chỉnh sửa menu status
        /// </summary>
        /// <remarks>chỉnh sửa menu status</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditStatus([FromBody] Menus.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
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
        /// Load danh sách menu để cấp quyền cho group
        /// </summary>
        /// <remarks>oad danh sách menu để cấp quyền cho group</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetListMenuByGroupID([FromBody] Default.Request.GroupID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-MENU-BYGROUP" },
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
        /// Load MenuRight
        /// </summary>
        /// <remarks>Load MenuRight</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetMenuRightByGroupID([FromBody] Menus.Request.GetMenuRightByGoupID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-MENU-RIGHT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@Ver", "v2" }
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
        /// Load MenuRight
        /// </summary>
        /// <remarks>Load MenuRight</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetMenuRightByParentID([FromBody] Menus.Request.GetParentID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetMenuRight-ParentID" },
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
        /// Chỉnh sửa quyền menu cho nhóm
        /// </summary>
        /// <remarks>Chỉnh sửa quyền menu cho nhóm</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditMenuRightByGroupID([FromBody] Menus.Request.EditMenuRight request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
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
        /// Thêm quyền menu cho nhóm
        /// </summary>
        /// <remarks>Thêm quyền menu cho nhóm</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> AddMenuRightByGroupID([FromBody] Menus.Request.EditMenuRight request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Add" },
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
        /// Chỉnh sửa quyền menu cho nhóm (bản mới)
        /// </summary>
        /// <remarks>Chỉnh sửa quyền menu cho nhóm</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> EditMenuRight([FromBody] Menus.Request.EditListMenuRight request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@ListMenuID", string.Join(";", request.ListMenuID.Select(r => $"{r.MenuID}:{r.AccessWrite}").ToArray()) }
                };
                request.ListMenuID = null!;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetMenuRightAppBarcode()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET_RIGHT_APP_BARCOE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}