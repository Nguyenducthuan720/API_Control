using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APISmartCity.Controllers
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.MobileMenu")]
    [Authorize]
    [ApiController]
    public class MobileMenuController : Controller
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _SecondProcedureName = "ExecMobileMenuRight";

        public MobileMenuController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
        }

        ///// <summary>
        ///// Load danh sách menu để cấp quyền cho group
        ///// </summary>
        ///// <remarks>Load danh sách menu để cấp quyền cho group</remarks>
        //[HttpPost]
        //[Route("api/menu/[action]")]
        //[ProducesResponseType(200, Type = typeof(DataResponse))]
        //public async Task<IActionResult> GetListMobileMenuByGroupID([FromBody] Default.Request.GroupID_ByInt request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "GET-MENU-BYGROUP" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        /// <summary>
        /// Load MenuRight
        /// </summary>
        /// <remarks>Load MenuRight</remarks>
        [HttpPost]
        [Route("api/menu/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public async Task<IActionResult> GetMobileMenu()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-MENU-RIGHT" },
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

        ///// <summary>
        ///// Chỉnh sửa quyền menu cho nhóm
        ///// </summary>
        ///// <remarks>Chỉnh sửa quyền menu cho nhóm</remarks>
        //[HttpPost]
        //[Route("api/menu/[action]")]
        //[ProducesResponseType(200, Type = typeof(DataResponse))]
        //public async Task<IActionResult> EditMobileMenu([FromBody] Menus.Request.EditMenuRight request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "EDIT" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID }
        //        };
        //        DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _SecondProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}
    }
}