using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using APISmartCity.VietmapGeocodeServices;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using static APISmartCity.lib.Function;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.DebitPeriodOils")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class DebitPeriodOilsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecDebitPeriodOils";
        private readonly DBFolder _SettingOther;
        private readonly KimTinService _kimTinService;

        public DebitPeriodOilsController(UserInfo userInfo, KimTinService kimTinService)
        {
            this._UserInfo = userInfo;
            _kimTinService = kimTinService;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "StationImages")!;
        }

        [HttpPost]
        public async Task<IActionResult> Get()
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetForAdd([FromBody] DebitPeriodOils.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-ForAdd" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "[ExecDebitPeriodOilsDetails]", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] DebitPeriodOils.Request.GetByID request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Properties = dataResponse.Result[1];
                    result.Details = dataResponse.Result[2];
                    result.Histories = dataResponse.Result[3];
                    result.Progress = dataResponse.Result[4];

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
        public async Task<IActionResult> GetByVehicelGroupID([FromBody] DebitPeriodOils.Request.GetVehicleGroupID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-VehicleGroup" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetDetailByDriver()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DrvierDetail" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };

                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    var results = (IEnumerable<dynamic>)result[0]!;
                    foreach (var item in results)
                    {
                        item.Images = ((IEnumerable<dynamic>)result[1]!).Where(r => int.Parse(r.OID) == item.ID);
                    }
                    dataResponse.Result = results;
                }

                //DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] DebitPeriodOils.Request.Add request)
        //{
        //    try
        //    {
        //        DataTable DebitPeriodOilsDetails = request.DebitPeriodOilsDetail.ToDataTable();
        //        DebitPeriodOilsDetails.SetTypeName("OL_DebitPeriodOilsDetail");
        //        Dictionary<string, object> parameters = new()
        //        {
        //            { "@type", "ADD" },
        //            { "@language", _UserInfo.Language },
        //            { "@DebitPeriodOilsDetails", DebitPeriodOilsDetails },
        //            { "@UserIDCurent", _UserInfo.UserID },
        //            { "@CmpnID", _UserInfo.CmpnID }
        //        };
        //        request.DebitPeriodOilsDetail = null;
        //        DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
        //        return Ok(dataResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse(ex.Message, "", "-1"));
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DebitPeriodOils.Request.Add request)
        {
            try
            {
                var contentDetails = JsonConvert.SerializeObject(request.DebitPeriodOilsDetail);
                request.DebitPeriodOilsDetail = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@dataJson", contentDetails },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                request.DebitPeriodOilsDetail = null;
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] DebitPeriodOils.Request.Edit request)
        {
            try
            {
                var contentDetails = JsonConvert.SerializeObject(request.DebitPeriodOilsDetail);
                request.DebitPeriodOilsDetail = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@dataJson", contentDetails },
                };
                request.DebitPeriodOilsDetail = null;
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DebitPeriodOils.Request.Del request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody] DebitPeriodOils.Request.EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@IsLock", request.IsActive }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] DebitPeriodOils.Request.Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DriverUpdateDetails([FromBody] DebitPeriodOils.Request.DrvierUdpdateDetails request)
        {
            try
            {
                string resultJson = "";
                Dictionary<string, object> GetCustomersInfoparameters = new()
                {
                    { "@type", "Get-Param-Lemon3" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@ID", request.ID }
                };
                DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                // Lấy dữ liệu đã đỗ dầu trước đó
                string CompanyCode = GetCustomersInfo?.Result[0].CompanyCode;
                string LicensePlates = GetCustomersInfo?.Result[0].LicensePlates;
                string PeriodOfMonth = GetCustomersInfo?.Result[0].PeriodOfMonth;
                resultJson = await _kimTinService.GetDataOil(CompanyCode, LicensePlates, PeriodOfMonth);
                if (resultJson != "[]")
                {
                    Dictionary<string, object> AddOils = new()
                    {
                        { "@JsonData", resultJson },
                    };
                    await GetDataResponse(AddOils, _nPLDB, _ConfigurationDB, "ExecDataOilLemon3s", null);
                }

                // kết thúc lấy dữ liệu đã đỗ dầu trước đó
                List<DebitPeriodOils.Request.UploadFiles> uploadFiles = new List<DebitPeriodOils.Request.UploadFiles>();
                foreach (DebitPeriodOils.Request.ContentBase64 content in request.Base64s)
                {
                    DebitPeriodOils.Request.UploadFiles upload = new DebitPeriodOils.Request.UploadFiles()
                    {
                        FileName = content.FileName,
                        ContentType = content.ContentType
                    };
                    bool result = Uri.TryCreate(content.Base64, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        upload.FileLink = content.Base64;
                        upload.FilePath = _SettingOther.Path + "/" + Path.GetFileName(upload.FileLink);
                        uploadFiles.Add(upload);
                    }
                    else if (!string.IsNullOrEmpty(content.Base64))
                    {
                        if (content.Base64.IsBase64String() == true)
                        {
                            string link = content.Base64.UploadBase64ImageReturnPath(_SettingOther.Path, _SettingOther.Link, "Images", Path.GetExtension(content.FileName).Replace(".", ""));
                            upload.FileLink = link;
                            upload.FilePath = _SettingOther.Path + "/" + Path.GetFileName(upload.FileLink);
                            uploadFiles.Add(upload);
                        }
                    }
                }
                System.Data.DataTable dataTable = uploadFiles.ToDataTable();
                dataTable.SetTypeName("UploadFiles");
                request.Base64s = null;

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DRIVER-UPDATE" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@UploadFiles", dataTable }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApprovalFinal([FromBody] DebitPeriodOils.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "APPROVAL-FINAL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDetails([FromBody] DebitPeriodOils.Request.AddDetails request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "ExecDebitPeriodOilsDetails", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}