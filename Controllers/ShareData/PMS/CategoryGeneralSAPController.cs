using APISmartCity.Models.Categorys;
using APISmartCity.DI;
using APISmartCity.GoogleTranslateServices;
using APISmartCity.lib;
using APISmartCity.Models;
using OsControl.Models.ShareData.PMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static APISmartCity.lib.Function;
using System.Text;
using APISmartCity.Services;

namespace OsControl.Controllers.ShareData.PMS
{
    [ApiExplorerSettings(GroupName = "Microservice.ShareData.CategoryGeneralSAP")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CategoryGeneralSAPController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly string _ProcedureName = "ExecCategoryGeneralSAP";
        private readonly DBFolder _SettingOther;
        private readonly GoogleTranslateService _translate;
        private readonly WordToPdfService _wordToPdfService;
        private readonly CompanyUpload _SettingUpload;

        public CategoryGeneralSAPController(UserInfo userInfo, GoogleTranslateService googleTranslate, WordToPdfService wordDocumentService)
        {
            _translate = googleTranslate;
            _UserInfo = userInfo;
            _wordToPdfService = wordDocumentService;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            var cmpnIDs = userInfo.CmpnID.Split(',');
            _SettingUpload = Global.CompanyUpload?.Find(item => cmpnIDs.Contains(item.ID.ToString()));
        }

        //[HttpPost]
        //public async Task<IActionResult> Get([FromBody] CategoryGeneralSAP.Requets.Get request)
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
        //public async Task<IActionResult> GetActive([FromBody] CategoryGeneralSAP.Requets.Get request)
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
        public async Task<IActionResult> GetByID([FromBody] CategoryGeneralSAP.Requets.GetByID request)
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

                if (dataResponse.Result?.Count > 0 && dataResponse.Result[0]?.Count > 0 && dataResponse.ErrorCode == "0")
                {
                    dynamic result = dataResponse.Result[0][0];

                    if (dataResponse.Result.Count > 1 && dataResponse.Result[1] != null)
                    {
                        foreach (var item in dataResponse.Result[1])
                        {
                            if (item?.DetailFee is string detailFeeStr && !string.IsNullOrWhiteSpace(detailFeeStr))
                            {
                                try
                                {
                                    if (item.DetailType == "Expense")
                                    {
                                        item.DetailFee = JsonSerializer.Deserialize<object>(detailFeeStr);
                                    }
                                }
                                catch
                                {
                                    item.DetailFee = null;
                                }
                            }
                        }
                        result.ExpenseDetails = dataResponse.Result[1];
                    }

                    if (dataResponse.Result.Count > 2)
                    {
                        result.Histories = dataResponse.Result[2];
                    }

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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryGeneralSAP.Requets.Add request)
        {
            try
            {
                string Details = JsonSerializer.Serialize(request.Details);
                string ExpenseDetails = JsonSerializer.Serialize(request.ExpenseDetails);
                string Specifications = JsonSerializer.Serialize(request.Specifications);

                if (!string.IsNullOrEmpty(request.Link) && Path.GetExtension(request.Link)?.ToLower() == ".svg")
                {
                    using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                    using var response = await httpClient.GetAsync(request.Link);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest(new
                        {
                            Response = new DataResponse($"Không thể tải file SVG: {response.ReasonPhrase}", "", "-1"),
                        });
                    }

                    string svgContent;
                    using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                    {
                        svgContent = await reader.ReadToEndAsync();
                    }

                    string replacedSvg = _wordToPdfService.ModifySvgContent(
                        svgContent,
                        _UserInfo.UserID,
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    );
                    string categoryType = request.CategoryType;
                    string safeOid = $"{DateTime.Now:yyyyMMddHHmmssfff}";
                    string svgFileName = $"FileSvg_Category_{categoryType}_{safeOid}.svg";
                    string folder = $"{_SettingUpload.DiskFolderSave}/DemoSvg/Category/{categoryType}/{safeOid}";

                    var bytes = Encoding.UTF8.GetBytes(replacedSvg);
                    using var ms = new MemoryStream(bytes);
                    IFormFile svgFile = new FormFile(ms, 0, ms.Length, "file", svgFileName)
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "image/svg+xml"
                    };

                    string savedFileName = UploadFileReturnFileName(svgFile, folder);
                    request.LinkImg = savedFileName;

                    Dictionary<string, object> saveparameters = new()
                        {
                            { "@type", "Save" },
                            { "@CategoryType", request.CategoryType },
                            { "@UserIDCurent", _UserInfo.UserID },
                            { "@FileNames", savedFileName }
                        };

                    var saveData = await GetDataResponse(saveparameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                    if (saveData.Result != null && saveData.Result.Count > 0)
                    {
                        var row = saveData.Result[0]; 
                        request.LinkImg = ((IDictionary<string, object>)row)["LinkFile"]?.ToString();
                    }
                }
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@Details", Details },
                    { "@ExpenseDetails", ExpenseDetails },
                    { "@Specifications", Specifications }
                };

                request.Details = null;
                request.ExpenseDetails = null;
                request.Specifications = null;

                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] CategoryGeneralSAP.Requets.Edit request)
        {
            try
            {
                string Details = JsonSerializer.Serialize(request.Details);
                string ExpenseDetails = JsonSerializer.Serialize(request.ExpenseDetails);
                string Specifications = JsonSerializer.Serialize(request.Specifications);
                if (!string.IsNullOrEmpty(request.Link) && Path.GetExtension(request.Link)?.ToLower() == ".svg")
                {
                    using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                    using var response = await httpClient.GetAsync(request.Link);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest(new
                        {
                            Response = new DataResponse($"Không thể tải file SVG: {response.ReasonPhrase}", "", "-1"),
                        });
                    }

                    string svgContent;
                    using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                    {
                        svgContent = await reader.ReadToEndAsync();
                    }

                    string replacedSvg = _wordToPdfService.ModifySvgContent(
                        svgContent,
                        _UserInfo.UserID,
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    );
                    string categoryType = request.CategoryType;
                    string safeOid = $"{DateTime.Now:yyyyMMddHHmmssfff}";
                    string svgFileName = $"FileSvg_Category_{categoryType}_{safeOid}.svg";
                    string folder = $"{_SettingUpload.DiskFolderSave}/DemoSvg/Category/{categoryType}/{safeOid}";

                    var bytes = Encoding.UTF8.GetBytes(replacedSvg);
                    using var ms = new MemoryStream(bytes);
                    IFormFile svgFile = new FormFile(ms, 0, ms.Length, "file", svgFileName)
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "image/svg+xml"
                    };

                    string savedFileName = UploadFileReturnFileName(svgFile, folder);
                    request.LinkImg = savedFileName;

                    Dictionary<string, object> saveparameters = new()
                    {
                        { "@type", "Save" },
                        { "@CategoryType", request.CategoryType },
                        { "@UserIDCurent", _UserInfo.UserID },
                        { "@FileNames", savedFileName }
                    };

                    var saveData = await GetDataResponse(saveparameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);

                    if (saveData.Result != null && saveData.Result.Count > 0)
                    {
                        var row = saveData.Result[0];
                        request.LinkImg = ((IDictionary<string, object>)row)["LinkFile"]?.ToString();
                    }
                }

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@Details", Details },
                    { "@ExpenseDetails", ExpenseDetails },
                    { "@Specifications", Specifications }
                };
                request.Details = null;
                request.ExpenseDetails = null;
                request.Specifications = null;
                DataResponse dataResponse = await GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] CategoryGeneralSAP.Requets.GetByID request)
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