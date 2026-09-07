using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using OsControl.Models.ShareData.PMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.Generals
{
    [ApiExplorerSettings(GroupName = "Microservice.ShareData.CategoryGeneralTreeSAP")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CategoryGeneralTreeSAPController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecCategoryGeneralTreeSAP";

        public CategoryGeneralTreeSAPController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
        }

        //[HttpPost]
        //public async Task<IActionResult> Get([FromBody] CategoryGeneralTreeSAP.Requets.Get request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "GET" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@CmpnID", _UserInfo.CmpnID }
        //        };
        //        DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> GetActive([FromBody] CategoryGeneralTreeSAP.Requets.Get request)
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "GET-ACTIVE" },
        //            { "@language", _UserInfo.Language },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@CmpnID", _UserInfo.CmpnID }
        //        };
        //        DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] CategoryGeneralTreeSAP.Requets.GetByID request)
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

                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                dynamic result = null;

                if (dataResponse.Result != null && dataResponse.Result.Count > 0)
                {
                    result = dataResponse.Result[0][0]; // luôn lấy object đầu tiên

                    // Nếu có thêm bảng lịch sử
                    if (dataResponse.Result.Count > 1)
                        result.Histories = dataResponse.Result[1];
                }

                dataResponse.Result = result;
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryGeneralTreeSAP.Requets.Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] CategoryGeneralTreeSAP.Requets.Edit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] CategoryGeneralTreeSAP.Requets.GetByID request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}