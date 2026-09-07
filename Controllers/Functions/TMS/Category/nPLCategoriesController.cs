using APISmartCity.DI;
using APISmartCity.GoogleTranslateServices;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using APISmartCity.VietmapGeocodeServices;
using DMS.Models.TMS.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.TMS.Category
{
    [ApiExplorerSettings(GroupName = "Microservice.Category.nPL")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class NPLCategoriesController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecnPLCategories";
        private readonly DBFolder _SettingOther;
        private readonly GoogleTranslateService _translate;
        private readonly KimTinService _kimTinService;

        public NPLCategoriesController(UserInfo userInfo, GoogleTranslateService googleTranslate, KimTinService kimTinService)
        {
            _kimTinService = kimTinService;
            _translate = googleTranslate;
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "AttachMents");
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] NPLCategories.Request.Get request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetSearch([FromBody] NPLCategories.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-Search" },
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetActive([FromBody] NPLCategories.Request.Get request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetByType([FromBody] NPLCategories.Request.Get request)
        {
            try
            {
                Dictionary<string, dynamic> Customize = new();

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetByType" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                //DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 0)
                {
                    var results = (dataResponse.Result as System.Collections.IList)?[0] as IEnumerable<dynamic>;
                    var ListColumn = (dataResponse.Result as System.Collections.IList)?[1] as IEnumerable<dynamic>;

                    foreach (var lang in results)
                    {
                        var ListCustomize = new List<dynamic>();
                        foreach (var item in ListColumn)
                        {
                            if (lang.CategoryCode == item.CategoryType)
                            {
                                ListCustomize.Add(item);
                            }
                        }
                        Customize.Add(lang.CategoryCode, ListCustomize);
                    }
                    dataResponse.Result = Customize;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrderTypesForDriver()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
                    { "@language", _UserInfo.Language },
                    { "@IsSelectAll", 1 },
                    { "@CategoryType", "OrderTypes" },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetGoodsTypesForDriver()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-ACTIVE" },
                    { "@language", _UserInfo.Language },
                    { "@IsSelectAll", 1 },
                    { "@CategoryType", "GoodsTypes" },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTransportTypeID([FromBody] NPLCategories.Request.TransportType request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetByTransportTypeID" },
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
        public async Task<IActionResult> GetById([FromBody] Default.Request.ID_ByInt request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NPLCategories.Request.Add request)
        {
            try
            {
                //if (request.CategoryType == "CustomerAttachments" || request.CategoryType == "DriverrAttachments")
                //{
                //    string folderExtention = DateTime.Now.ToString("yyyyMMdd");
                //    request.FileLink = request.FileLink.Replace(";", "").UploadBase64ImageReturnPath(_SettingOther.Path + folderExtention, _SettingOther.Link + folderExtention, Path.GetFileNameWithoutExtension(request.ExactFileName), Path.GetExtension(request.ExactFileName).Replace(".", ""), UploadType.NoCompressImage);
                //    if (request.FileLink is null)
                //    {
                //        return Ok(new DataResponse("Base64 không đúng", "", "-1"));
                //    }
                //}
                //request.ExactFileName = null;

                //{ "@TranslateName", (request.NameExtention1 == null || request.NameExtention1 == "" || request.NameExtention1 == ".") ? await _translate.Translate(request.Name, "Vi", "EN") : "" },
                //{ "@TranslateAddress", (request.AddressExtention1 == null || request.AddressExtention1 == "" || request.AddressExtention1 == ".") ? await _translate.Translate(request.Address, "Vi", "EN") : "" }

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@TranslateName", CheckGoogleTranslate(request.Name, request.NameExtention1) ? await _translate.Translate(request.Name, "Vi", "EN") : "" },
                    { "@TranslateAddress", CheckGoogleTranslate(request.Address, request.AddressExtention1) ? await _translate.Translate(request.Address, "Vi", "EN") : "" },
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

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] NPLCategories.Request.Edit request)
        {
            try
            {
                //if ((request.CategoryType == "CustomerAttachments" || request.CategoryType == "DriverrAttachments") && !Uri.IsWellFormedUriString(request.FileLink, UriKind.Absolute))
                //{
                //    string folderExtention = DateTime.Now.ToString("yyyyMMdd");
                //    request.FileLink = request.FileLink.Replace(";", "").UploadBase64ImageReturnPath(_SettingOther.Path + folderExtention, _SettingOther.Link + folderExtention, Path.GetFileNameWithoutExtension(request.ExactFileName), Path.GetExtension(request.ExactFileName).Replace(".", ""), UploadType.NoCompressImage);
                //    if (request.FileLink is null)
                //    {
                //        return Ok(new DataResponse("Base64 không đúng", "", "-1"));
                //    }
                //}
                //request.ExactFileName = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@TranslateName", CheckGoogleTranslate(request.Name, request.NameExtention1) ? await _translate.Translate(request.Name, "Vi", "EN") : "" },
                    { "@TranslateAddress", CheckGoogleTranslate(request.Address, request.AddressExtention1) ? await _translate.Translate(request.Address, "Vi", "EN") : "" },
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

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] NPLCategories.Request.Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
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
        public async Task<IActionResult> ChangeStatus([FromBody] NPLCategories.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDITSTATUS" },
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
        public async Task<IActionResult> Submit([FromBody] NPLCategories.Request.Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
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
        public async Task<IActionResult> Sync([FromBody] NPLCategories.Request.Sync request)
        {
            try
            {
                // lấy Mã LemonID từ CompanyConfig
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetByID" },
                    { "@ID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ExecCompanyConfigs", null!);
                string LemonID = dataResponse.Result?[0]?[0]?.LemonID ?? "";

                parameters = new()
                {
                    { "@Type", request.Type },
                    { "@json", await _kimTinService.SyncCategories(LemonID,request.Type)},
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, "ExecnPLCategoriesSync", null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel([FromBody] NPLCategories.Request.ImportExcel request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ImportExcel" },
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


    }
}