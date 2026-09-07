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
using DMS.Models.DMS.Media;
using Microsoft.AspNetCore.Authorization;

namespace DMS.Controllers.Functions.DMS.SaleSupports.Media
{
    [ApiExplorerSettings(GroupName = "Functions.Media.Posts")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PostsMediaController : ControllerBase
    {


        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecPosts";
        private readonly GoogleTranslateService _translate;

        public PostsMediaController(UserInfo userInfo, GoogleTranslateService googleTranslate)
        {
            _translate = googleTranslate;
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
        }
        /// <summary>
        /// Lấy tất cả bài viết theo loại danh mục và mã công ty
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Danh sách bài viết</returns>
        [HttpPost("Get")]
        public async Task<IActionResult> Get([FromBody] PostModel.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@CategoryType", request.CategoryType },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                if (dataResponse.Result?.Count > 0 && dataResponse.ErrorCode == "0")
                {
                    foreach (dynamic item in dataResponse.Result)
                    {
                        string? tagsRaw = item.Tags;
                        item.Tags = string.IsNullOrWhiteSpace(tagsRaw)
                            ? new List<string>()
                            : JsonSerializer.Deserialize<List<string>>(tagsRaw!);
                    }
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy thông tin bài viết theo ID
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Thông tin chi tiết bài viết</returns>
        [HttpPost("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] PostModel.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@ID", request.ID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);

                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    foreach (dynamic item in dataResponse.Result[0])
                    {
                        string? tagsRaw = item.Tags;
                        item.Tags = string.IsNullOrWhiteSpace(tagsRaw)
                            ? new List<string>()
                            : JsonSerializer.Deserialize<List<string>>(tagsRaw!);
                    }
                    dynamic result = new ExpandoObject();
                    result.Details = dataResponse.Result[0];
                    result.Historys = dataResponse.Result[1];
                    dataResponse.Result = result;
                }
                else
                {
                    dataResponse.Result = null;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy các bài viết đang active theo loại danh mục và mã công ty
        /// </summary>
        /// <param name="request">Thông tin request</param>
        /// <returns>Danh sách bài viết đang active</returns>
        [HttpPost("GetActive")]
        public async Task<IActionResult> GetActive([FromBody] PostModel.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
                    { "@language", _UserInfo.Language },
                    { "@CategoryType", request.CategoryType },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UserID", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới bài viết
        /// </summary>
        /// <param name="request">Thông tin bài viết cần thêm</param>
        /// <returns>Kết quả thêm bài viết</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostModel.Request.Content request)
        {
            try
            {
                string Tags = JsonSerializer.Serialize(request.Tags);
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@Tags", Tags }
                };
                request.Tags = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Cập nhật thông tin bài viết
        /// </summary>
        /// <param name="request">Thông tin bài viết cần cập nhật</param>
        /// <returns>Kết quả cập nhật bài viết</returns>
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] PostModel.Request.Edit request)
        {
            try
            {
                string Tags = JsonSerializer.Serialize(request.Tags);
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@Tags", Tags }
                };
                request.Tags = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="request">Thông tin bài viết cần xóa</param>
        /// <returns>Kết quả xóa bài viết</returns>
        [HttpPost("Del")]
        public async Task<IActionResult> Del([FromBody] PostModel.Request.Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@ID", request.ID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] PostModel.Request.Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@ID", request.ID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}