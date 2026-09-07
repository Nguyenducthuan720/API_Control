using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Ver2.Configs;
using APISmartCity.TransferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.DMS.General
{
    [ApiExplorerSettings(GroupName = "Functions.General.AttachFiles")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class AttachFilesController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly CompanyUpload _SettingOther;
        private readonly DBFolder _SettingOther2;

        private readonly string _ProcedureName = "ExecAttachFiles_Ver2";
        private readonly TransferService _transferService;

        public AttachFilesController(UserInfo userInfo, TransferService transferService)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            var cmpnIDs = userInfo.CmpnID.Split(',');
            _SettingOther = Global.CompanyUpload?.Find(item => cmpnIDs.Contains(item.ID.ToString()));
            _SettingOther2 = Global.ListFolder?.Find(item => item.Type == "AttachFiles");

            _transferService = transferService;
        }

        /// <summary>
        /// Lấy danh sách Yêu cầu
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Get(AttachFiles.Request.Get request)
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
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới File
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AttachFiles.Request.Add request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.TransferFormFile<AttachFiles.Request.Add>(request, "AttachFiles", "Add", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                List<string> errors = new();
                var maxFileSize = (long) 2 * 1024 * 1024 * 1024; // 2GB
                foreach (IFormFile file in request.File)
                {
                    if (file.Length > maxFileSize)
                    {
                        errors.Add($"File {file.FileName} vượt quá kích thước cho phép (2GB)");
                        continue; 
                    }
                }

                if (errors.Count > 0)
                {
                    return Ok(new DataResponse(string.Join("\n", errors), "", "-1"));
                }

                if (string.IsNullOrEmpty(request.OID))
                {
                    request.OID = DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                IEnumerable<string> fileNameArr = request.File.Select(file => UploadFileReturnFileName(file, $"{_SettingOther.DiskFolderSave}/{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}/{request.OID.Replace("/", "")}"));
                string fileNames = string.Join(",", fileNameArr);
                request.File = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FileNames", fileNames },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới File
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddFileCont([FromForm] AttachFiles.Request.AddFileCont request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.TransferFormFile<AttachFiles.Request.AddFileCont>(request, "AttachFiles", "AddFileCont", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                string FactorID = "FileConts";
                IEnumerable<string> fileNameArr = request.File.Select(file => UploadFileReturnFileName(file, $"{_SettingOther2.Path}/{FactorID}/{request.EntryID}/{DateTime.Now:yyyyMMdd}"));
                string fileNames = string.Join(",", fileNameArr);
                request.File = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD-FileCont" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FileNames", fileNames }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới File
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddFileDriver([FromForm] AttachFiles.Request.AddFileDriver request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.TransferFormFile<AttachFiles.Request.AddFileDriver>(request, "AttachFiles", "AddFileDriver", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                string FactorID = "FileDriver";
                IEnumerable<string> fileNameArr = request.File.Select(file => UploadFileReturnFileName(file, $"{_SettingOther2.Path}/{FactorID}/{request.EntryID}/{DateTime.Now:yyyyMMdd}"));
                string fileNames = string.Join(",", fileNameArr);
                request.File = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD-FileDriver" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FileNames", fileNames }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        /// <summary>
        /// Sửa File
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] AttachFiles.Request.Edit request)
        {
            try
            {
                /*string newName = "";
                if (request.OldLinks == null)
                {
                    newName = "";
                }
                else
                {
                    string[] Oldlink = request.OldLinks.Split(';');
                    foreach (string oldLink in Oldlink)
                    {
                        newName += oldLink.Remove(0, oldLink.LastIndexOf('/') + 1) + ',';
                    }
                }
                string newNames = "";
                if (request.File is null)
                {
                    newNames = newName;
                }
                else
                {
                    foreach (IFormFile file in request.File)
                    {
                        string FileName = UploadFileReturnFileName(file, _SettingOther.Path + "/" + request.FactorID + "/" + request.EntryID + "/" + request.OID.Replace("/", ""), file.FileName);
                        if (FileName is not null)
                        {
                            newNames += FileName + ',';
                        }
                    }
                    if (newName != null)
                    {
                        newNames = newNames + newName;
                    }
                }

                newNames = newNames.Remove(newNames.LastIndexOf(','));*/

                string fileNames = "";
                string[] linkArr = request.OldLinks?.Split(';');
                if (linkArr != null)
                {
                    IEnumerable<string> oldFileNameArr = linkArr.Select(link => Path.GetFileName(link));
                    fileNames = string.Join(",", oldFileNameArr);
                }
                if (request.File?.Count > 0)
                {
                    IEnumerable<string> fileNameArr = request.File.Select(file => UploadFileReturnFileName(file, $"{_SettingOther.DiskFolderSave}/{_UserInfo.CmpnID}/{request.FactorID}/{request.EntryID}/{request.OID.Replace("/", "")}"));
                    if (string.IsNullOrEmpty(fileNames))
                    {
                        fileNames = string.Join(",", fileNameArr);
                    }
                    else if (fileNameArr.Count() > 0)
                    {
                        fileNames += "," + string.Join(",", fileNameArr);
                    }
                }
                request.File = null;
                request.OldLinks = null;
                request.EntryID = null;
                request.FactorID = null;
                request.OID = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FileNames", fileNames },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Xóa Yêu cầu vận chuyển
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(AttachFiles.Request.Del request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "AttachFiles", "Delete", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Lấy danh sách Yêu cầu
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> GetFileDriver(AttachFiles.Request.GetFileDriver request)
        {
            //string? jwtToken = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            //string kq = await _transferService.Transfer(JsonSerializer.Serialize(request), "AttachFiles", "GetFileDriver", jwtToken);
            //return Ok(JsonSerializer.Deserialize<JsonNode>(kq));
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-FileDriver" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Điều độ xóa file
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteFileByOID(AttachFiles.Request.DelByOID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL_BYOID_BYLINK" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Thêm mới File Base 64
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBase64([FromBody] AttachFiles.Request.AddBase64 request)
        {
            try
            {
                string pacth = $"{_SettingOther2.Path}/{request.FactorID}/{request.EntryID}/{request.OID.RemoveSpecialCharacters()}/";
                string[] fileNames = new string[request.ListBase64.Count];
                string timeStamp = DateTime.Now.Ticks.ToString();
                for (int i = 0; i < request.ListBase64.Count; i++)
                {
                    UploadBase64Image(request.ListBase64[i], pacth, request.OID.RemoveSpecialCharacters() + "_" + timeStamp, "jpg");
                    fileNames[i] = request.OID.RemoveSpecialCharacters() + "_" + timeStamp + ".jpg";
                }
                request.ListBase64 = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD-BASE64" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FileNames", string.Join("|", fileNames) }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}