using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using APISmartCity.TransferServices;
using APISmartCity.VietmapGeocodeServices;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.DriverRequests.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.DriverRequests")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class DriverRequestsController : ControllerBase
    {
        private readonly DI.UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecDriverRequests";
        private readonly DBFolder _SettingOther;
        private readonly TransferService _transferService;

        private readonly KimTinService _kimTinService;

        public DriverRequestsController(DI.UserInfo userInfo, KimTinService kimTinService, TransferService transferService)
        {
            _transferService = transferService;
            this._UserInfo = userInfo;
            _kimTinService = kimTinService;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "StationImages")!;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Get request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByDriver([FromBody] Get request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverRequests", "GetByDriver", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYDRIVER" },
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
        public async Task<IActionResult> GetById([FromBody] GetByID request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverRequests", "GetByID", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.Images = dataResponse.Result[1];
                    result.Properties = dataResponse.Result[2];
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
        public async Task<IActionResult> GetListVehicleByDriverID([FromBody] DriverInfo request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetListVehicleByDriverID" },
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
        public async Task<IActionResult> Add([FromBody] Add request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverRequests", "Add", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));

            try
            {
                if (request.EntryID == "RQ_Gas")
                {
                    string resultJson = "";
                    Dictionary<string, object> GetCustomersInfoparameters = new()
                    {
                        { "@type", "Get-Param-Lemon3" },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID },
                        { "@DriverID", _UserInfo.UserID }
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
                }

                string subPath = request.EntryID;
                string outputPath = _SettingOther.Path + subPath + "/";
                string outputLink = _SettingOther.Link + subPath;
                List<UploadFiles> uploadFiles = new List<UploadFiles>();
                foreach (ContentBase64 content in request.Base64s)
                {
                    UploadFiles upload = new UploadFiles()
                    {
                        FileName = content.FileName,
                        ContentType = content.ContentType
                    };
                    bool result = Uri.TryCreate(content.Base64, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        upload.FileLink = content.Base64;
                        upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                        uploadFiles.Add(upload);
                    }
                    else if (!string.IsNullOrEmpty(content.Base64))
                    {
                        if (content.Base64.IsBase64String())
                        {
                            string link = content.Base64.UploadBase64ImageReturnPath(outputPath, outputLink, "Images", Path.GetExtension(content.FileName).Replace(".", ""));
                            upload.FileLink = link;
                            upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                            uploadFiles.Add(upload);
                        }
                    }
                }
                System.Data.DataTable dataTable = uploadFiles.ToDataTable();
                dataTable.SetTypeName("UploadFiles");
                request.Base64s = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
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
        public async Task<IActionResult> Edit([FromBody] Edit request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "DriverRequests", "Edit", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                string subPath = request.EntryID;
                string outputPath = _SettingOther.Path + subPath + "/";
                string outputLink = _SettingOther.Link + subPath;
                List<UploadFiles> uploadFiles = new List<UploadFiles>();
                foreach (DriverRequests.Request.ContentBase64 content in request.Base64s)
                {
                    UploadFiles upload = new UploadFiles()
                    {
                        FileName = content.FileName,
                        ContentType = content.ContentType
                    };
                    bool result = Uri.TryCreate(content.Base64, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        upload.FileLink = content.Base64;
                        upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                        uploadFiles.Add(upload);
                    }
                    else if (!string.IsNullOrEmpty(content.Base64))
                    {
                        if (content.Base64.IsBase64String())
                        {
                            string link = content.Base64.UploadBase64ImageReturnPath(outputPath, outputLink, "Images", Path.GetExtension(content.FileName).Replace(".", ""));
                            upload.FileLink = link;
                            upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                            uploadFiles.Add(upload);
                        }
                    }
                }
                System.Data.DataTable dataTable = uploadFiles.ToDataTable();
                dataTable.SetTypeName("UploadFiles");
                request.Base64s = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
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
        public async Task<IActionResult> Cancel([FromBody] Cancel request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Cancel" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> EditStatus([FromBody] GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@IsLock" , 0}
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
        public async Task<IActionResult> Submit([FromBody] Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> Approval([FromBody] Approval request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "APPROVAL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> UpdateGasContract([FromBody] UpdateGasContract request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UpdateGasContract" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> ReCalculateOil([FromBody] GetByID request)
        {
            try
            {
                string resultJson = "";
                Dictionary<string, object> GetCustomersInfoparameters = new()
                    {
                        { "@type", "GetInfo" },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID }
                    };
                DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, "Calculate_DataOil", request);

                // Lấy dữ liệu đã đỗ dầu trước đó
                foreach (dynamic result in GetCustomersInfo.Result)
                {
                    string CompanyCode = result.CompanyCode;
                    string LicensePlates = result.LicensePlates;
                    string PeriodOfMonth = result.PeriodOfMonth;
                    resultJson = await _kimTinService.GetDataOil(CompanyCode, LicensePlates, PeriodOfMonth);
                    if (resultJson != "[]")
                    {
                        Dictionary<string, object> AddOils = new()
                        {
                            { "@JsonData", resultJson },
                        };
                        await GetDataResponse(AddOils, _nPLDB, _ConfigurationDB, "ExecDataOilLemon3s", null);
                    }
                }
                // kết thúc lấy dữ liệu đã đỗ dầu trước đó

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Calculate" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "Calculate_DataOil", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CalculateOilFromDateToDate([FromBody] FromDateToDate request)
        {
            try
            {
                string resultJson = "";
                Dictionary<string, object> GetCustomersInfoparameters = new()
                    {
                        { "@type", "GetInfo" },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID }
                    };
                DataResponse GetCustomersInfo = await GetDataResponse(GetCustomersInfoparameters, _nPLDB, _ConfigurationDB, "Calculate_DataOil", null!);

                // Lấy dữ liệu đã đỗ dầu trước đó
                string CompanyCode = GetCustomersInfo.Result[0].CompanyCode;
                LoopMonths(request.FDate, request.TDate, async date =>
                {
                    resultJson = await _kimTinService.GetDataOil(CompanyCode, "%", date.ToString("yyyyMM"));
                    if (resultJson != "[]")
                    {
                        Dictionary<string, object> AddOils = new()
                        {
                            { "@JsonData", resultJson },
                        };
                        await GetDataResponse(AddOils, _nPLDB, _ConfigurationDB, "ExecDataOilLemon3s", null);
                    }
                });
                // kết thúc lấy dữ liệu đã đỗ dầu trước đó
                Dictionary<string, object> parameters = new()
                {
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, "Calculate_DataOilTotal", request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCoordinator([FromBody] AddCoordinator request)
        {
            try
            {
                string subPath = request.EntryID;
                string outputPath = _SettingOther.Path + subPath + "/";
                string outputLink = _SettingOther.Link + subPath;
                List<UploadFiles> uploadFiles = new List<UploadFiles>();
                foreach (ContentBase64 content in request.Base64s)
                {
                    UploadFiles upload = new UploadFiles()
                    {
                        FileName = content.FileName,
                        ContentType = content.ContentType
                    };
                    bool result = Uri.TryCreate(content.Base64, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        upload.FileLink = content.Base64;
                        upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                        uploadFiles.Add(upload);
                    }
                    else if (!string.IsNullOrEmpty(content.Base64))
                    {
                        if (content.Base64.IsBase64String())
                        {
                            string link = content.Base64.UploadBase64ImageReturnPath(outputPath, outputLink, "Images", Path.GetExtension(content.FileName).Replace(".", ""));
                            upload.FileLink = link;
                            upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                            uploadFiles.Add(upload);
                        }
                    }
                }
                System.Data.DataTable dataTable = uploadFiles.ToDataTable();
                dataTable.SetTypeName("UploadFiles");
                request.Base64s = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "AddCoordinator" },
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
        public async Task<IActionResult> EditCoordinator([FromBody] EditCoordinator request)
        {
            try
            {
                string subPath = request.EntryID;
                string outputPath = _SettingOther.Path + subPath + "/";
                string outputLink = _SettingOther.Link + subPath;
                List<UploadFiles> uploadFiles = new List<UploadFiles>();
                foreach (ContentBase64 content in request.Base64s)
                {
                    UploadFiles upload = new UploadFiles()
                    {
                        FileName = content.FileName,
                        ContentType = content.ContentType
                    };
                    bool result = Uri.TryCreate(content.Base64, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        upload.FileLink = content.Base64;
                        upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                        uploadFiles.Add(upload);
                    }
                    else if (!string.IsNullOrEmpty(content.Base64))
                    {
                        if (content.Base64.IsBase64String())
                        {
                            string link = content.Base64.UploadBase64ImageReturnPath(outputPath, outputLink, "Images", Path.GetExtension(content.FileName).Replace(".", ""));
                            upload.FileLink = link;
                            upload.FilePath = outputPath + Path.GetFileName(upload.FileLink);
                            uploadFiles.Add(upload);
                        }
                    }
                }
                System.Data.DataTable dataTable = uploadFiles.ToDataTable();
                dataTable.SetTypeName("UploadFiles");
                request.Base64s = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EditCoordinator" },
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
        public async Task<IActionResult> GetDriver()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetDriver" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}