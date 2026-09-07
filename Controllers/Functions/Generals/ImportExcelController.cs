using System.Data;
using System.Dynamic;
using APISmartCity.DI;
using APISmartCity.GoogleTranslateServices;
using APISmartCity.lib;
using APISmartCity.Lib.Function;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Categorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DMS.Controllers.Functions.Generals
{
    [ApiExplorerSettings(GroupName = "Functions.ImportExcel")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ImportExcelController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _MediaDB;
        private readonly string _ProcedureImport = "ExecExcelImport";
        private readonly string _ProcedureMapping = "ExecExcelMapping";
        private readonly string _ProcedureTrans = "ExecExcelTrans";
        private readonly ExcelImportService _excelImportService;
        private readonly GoogleTranslateService _translateService;

        public ImportExcelController(UserInfo userInfo, GoogleTranslateService translate)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _MediaDB = Global.ListDB?.Find(item => item.DBType == "MDA")?.DBString!;
            _excelImportService = new ExcelImportService(translate);
            _translateService = translate;
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file, [FromForm] string FactorID, [FromForm] string EntryID)
        {
            try
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;

                var (json, dataTypeJson, requiredJson, Row1Json, errorMessage) = await (FactorID != "Category" ?  _excelImportService.ParseExcelAsyncReplaceType(stream) : _excelImportService.ParseExcelAsync(stream));

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return Ok(new DataResponse(errorMessage, "", "-1"));
                }
                var parameters = new Dictionary<string, object>
                {
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FactorID", FactorID },
                    { "@EntryID", EntryID },
                    { "@Json", json! },
                    { "@DataTypeJson", dataTypeJson! },
                    { "@RequiredJson", requiredJson! },
                    { "@Row1Json", Row1Json! }
                };

                var dataResponse = await Function.GetDataResponse(parameters, _MediaDB, _ConfigurationDB, _ProcedureImport, null);
                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    var resultData = new Dictionary<string, object>
                    {
                        { "DataImportInFile", dataResponse.Result[0] },
                        { "Dashboard", dataResponse.Result[1] },
                        { "Customzise", dataResponse.Result[2] }
                    };
                    dataResponse.Result = new List<dynamic> { resultData };
                    //dynamic result = dataResponse.Result[0][0];
                    //result.DuplicateInFileData = dataResponse.Result[1];
                    //result.ErrorDataInFileData = dataResponse.Result[2];
                    //result.ExistedInDBData = dataResponse.Result[3];
                    //dataResponse.Result = result;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Mapping([FromBody] ImportExcel.Requets.Mapping request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _MediaDB, _ConfigurationDB, _ProcedureMapping, request);

                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
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
        public async Task<IActionResult> Trans([FromBody] ImportExcel.Requets.Trans request)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@type", "GET" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };

                var dataResponse = await Function.GetDataResponse(parameters, _MediaDB, _ConfigurationDB, _ProcedureTrans, request);

                if (dataResponse.Result == null || dataResponse.Result.Count < 2 || dataResponse.Result[0].Count == 0 || dataResponse.Result[1].Count == 0)
                {
                    return Ok(dataResponse);
                }

                var mappings = dataResponse.Result[0]; // EntryMappings
                var records = dataResponse.Result[1];  // Dữ liệu cần dịch

                var translatedData = new List<object>();

                foreach (IDictionary<string, object> item in records)
                {
                    string sourceText = item.TryGetValue("SourceText", out var srcVal) ? srcVal?.ToString() ?? "" : "";
                    string colName = item.TryGetValue("ColName", out var cn) ? cn?.ToString() ?? "" : "";
                    string colMapping = item.TryGetValue("ColMapping", out var cm) ? cm?.ToString() ?? "" : "";
                    string code = item.TryGetValue("Code", out var c) ? c?.ToString() ?? "" : "";

                    if (string.IsNullOrWhiteSpace(sourceText) || string.IsNullOrWhiteSpace(colName)) continue;

                    string language = "en";
                    foreach (IDictionary<string, object> map in mappings)
                    {
                        if (map.TryGetValue("ColName", out var mapColNameObj)
                            && mapColNameObj?.ToString() == colName
                            && map.TryGetValue("Language", out var langObj))
                        {
                            language = langObj?.ToString()?.ToLower() ?? "en";
                            break;
                        }
                    }

                    string translated = await _translateService.Translate(sourceText, "vi", language);

                    translatedData.Add(new
                    {
                        Code = code,
                        ColName = colName,
                        ColMapping = colMapping,
                        SourceText = sourceText,
                        TranslatedText = translated
                    });
                }



                // 4. Gửi dữ liệu đã dịch về lại SP để cập nhật
                var updateParameters = new Dictionary<string, object>
                {
                    { "@type", "TRANS" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@Json", JsonConvert.SerializeObject(translatedData) }
                };

                var updateResponse = await Function.GetDataResponse(updateParameters, _MediaDB, _ConfigurationDB, _ProcedureTrans, null);

                return Ok(updateResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

    }
}
