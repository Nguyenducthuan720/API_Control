using System.Dynamic;
using System.Text.Json;
using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using APISmartCity.Models.Systems;
using APISmartCity.Models.Ver2.Categorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APISmartCity.Controllers.Categorys.Ver2
{
    [ApiExplorerSettings(GroupName = "Microservice.Category.ItemsCshop")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ItemsCshopController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecCShop";

        public ItemsCshopController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
        }

        /// <summary>
        /// Get danh sách ngành hàng/Sản phẩm theo geocode
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] ItemsCshop.Request.Get request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Load list DataType Active
        /// </summary>
        /// <remarks>Load list DataType Active</remarks>
        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] ItemsCshop.Request.GetByID request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    var options = dataResponse.Result[1]; // Lấy danh sách Option

                    // Duyệt qua từng item trong Option để parse Specification
                    foreach (var option in options)
                    {
                        if (option.Specification != null && !string.IsNullOrEmpty(option.Specification.ToString()))
                        {
                            var specList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(option.Specification.ToString());

                            var formattedSpecList = new List<Dictionary<string, string>>();
                            foreach (var item in specList)
                            {
                                var key = item["key"];
                                var value = item["value"];
                                var name = item.ContainsKey("Name") ? item["Name"] : "";

                                var newItem = new Dictionary<string, string>
                                {
                                    { key, value },
                                    { key + "Name", name }
                                };

                                formattedSpecList.Add(newItem);
                            }

                            option.Specification = formattedSpecList;
                        }
                    }

                    result.Option = options;
                    dataResponse.Result = result;
                }
                else
                {
                    if (dataResponse.Result != null && dataResponse.Result.Count > 0)
                    {
                        dynamic result = dataResponse.Result[0];
                        dataResponse.Result = result;
                    }
                    else
                    {
                        dataResponse.Result = null;
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
        /// Get cấp 1 ra danh sách ngành hàng/Sản phẩm theo geocode
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetProductTypeByID([FromBody] ItemsCshop.Request.GetProductTypeByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-PRODUCTTYPE-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// GET cấp 1 của KTG/KES
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetProductType([FromBody] ItemsCshop.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-PRODUCTTYPE-ID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// GET Cấp 3 sản phẩm kes
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetGoodsTypeByKes()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-GOODSTYPE-BYKES" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
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
        /// GET Cấp 3 sản phẩm kes
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetKesByProductTypeID([FromBody] ItemsCshop.Request.GetProductTypeByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-KES-BYPRODUCTTYPE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        /// <summary>
        /// Get DS theo listGoodsTypeID -> DS GoodsType (chỉ KTG)
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetByListID([FromBody] ItemsCshop.Request.GetByListID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BY-LIST-GOODSTYPEID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        /// <summary>
        /// GET DS giỏ hàng theo geocode
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetCart([FromBody] ItemsCshop.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-CART" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// GET DS Yêu thích theo geocode
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> GetFavorite([FromBody] ItemsCshop.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-FAVORITE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Tìm kiếm nâng cao 
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] ItemsCshop.Request.Search request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SEARCH" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }



        /// <summary>
        /// Thêm giỏ hàng hoặc yêu thích
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] ItemsCshop.Request.Cart request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        /// <summary>
        /// chỉnh sửa giỏ hàng hoặc yêu thích
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> EditCart([FromBody] ItemsCshop.Request.Cart request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        /// <summary>
        /// Xóa list giỏ hàng hoặc yêu thích
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteCart([FromBody] ItemsCshop.Request.DelCart request)
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
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


    }
}