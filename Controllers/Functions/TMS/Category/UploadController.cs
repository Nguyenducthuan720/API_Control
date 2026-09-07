using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.Models.Categorys.Uploads.Response;

namespace APISmartCity.Controllers.Categorys
{
    [ApiExplorerSettings(GroupName = "Microservice.Categorys.Uploads")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _CategoryDB;
        private readonly DBFolder _SettingOther;
        private readonly string _ProcedureName = "ExecUploadFiles";
        private Uploads.Response.Results resResults;

        public UploadController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "StationImages")!;
        }

        [HttpPost]
        public async Task<IActionResult> UploadBase64([FromBody] Uploads.Request.FormBase64s request)
        {
            // Check if files are null
            if (request.Base64s == null || request.Base64s.Count == 0)
                return Ok(new DataResponse("Please upload at least one file.", "", "-1"));

            List<Uploads.Request.ImportDatabase> importDatabase = new();
            resResults = new Uploads.Response.Results()
            {
                TotalUpload = request.Base64s.Count,
                SuccessInfos = new List<SuccessInfos>(),
                FailureInfos = new List<FailureInfos>()
            };

            long totalFileSize = 0;

            // Check valid base64 string
            List<int> indexRemoves = new List<int>();
            for (int i = 0; i < request.Base64s.Count; i++)
            {
                // Check base64
                if (string.IsNullOrEmpty(request.Base64s[i].Base64))
                {
                    indexRemoves.Add(i);
                    resResults.FailureInfos.Add(new FailureInfos()
                    {
                        FileName = request.Base64s[i].FileName,
                        Description = "Nothing to upload."
                    });
                }
                else
                {
                    bool result = Uri.TryCreate(request.Base64s[i].Base64, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        continue;
                    }
                    else if (request.Base64s[i].Base64.IsBase64String())
                    {
                        // Sum file size
                        totalFileSize += Convert.FromBase64String(request.Base64s[i].Base64).Length;
                    }
                    else
                    {
                        indexRemoves.Add(i);
                        resResults.FailureInfos.Add(new FailureInfos()
                        {
                            FileName = request.Base64s[i].FileName,
                            Description = "Base64 string is invalid."
                        });
                    }
                }
            }
            foreach (int index in indexRemoves)
            {
                request.Base64s.RemoveAt(index);
            }
            indexRemoves.Clear();

            // Check total file size (maximum 300 MB)
            if (totalFileSize > 300 * 1024 * 1024)
                return Ok(new DataResponse("Total file size limit exceeded. Maximum allowed total file size is 300 MB.", "", "-1"));

            // Check file types
            for (int i = 0; i < request.Base64s.Count; i++)
            {
                if (!Function.ContentEnum.AllowedContentTypes.Contains(request.Base64s[i].ContentType))
                {
                    indexRemoves.Add(i);
                    resResults.FailureInfos.Add(new FailureInfos()
                    {
                        FileName = request.Base64s[i].FileName,
                        Description = "Invalid file type. Only JPEG and PNG image files are allowed."
                    });
                    continue;
                }

                try
                {
                    // Store file paths for successful uploads
                    var fileUploadResults = new Dictionary<string, string>();

                    // Decode base64 string to byte array
                    byte[] fileBytes = Convert.FromBase64String(request.Base64s[i].Base64);

                    // Generate unique file name
                    string fileName, fileExtentions = "";
                    if (string.IsNullOrEmpty(request.Base64s[i].FileName))
                    {
                        fileName = Guid.NewGuid().ToString();
                        fileExtentions = "." + Function.GetFileExtension(request.Base64s[i].Base64);

                        // Check file extentions exists
                        if (string.IsNullOrEmpty(fileExtentions))
                        {
                            indexRemoves.Add(i);
                            resResults.FailureInfos.Add(new FailureInfos()
                            {
                                FileName = request.Base64s[i].FileName,
                                Description = "Invalid FileName."
                            });
                            continue;
                        }
                        else
                        {
                            fileName += fileExtentions;
                        }
                    }
                    else
                    {
                        fileExtentions = Path.GetExtension(request.Base64s[i].FileName);
                        if (string.IsNullOrEmpty(fileExtentions))
                        {
                            fileName = request.Base64s[i].FileName;
                            fileExtentions = "." + Function.GetFileExtension(request.Base64s[i].Base64);
                            fileName += fileExtentions;
                        }
                        else
                        {
                            fileName = request.Base64s[i].FileName;
                        }
                    }

                    // Save file to disk
                    string directory = Path.Combine(_SettingOther.Path, request.Code, request.OID.RemoveSpecialCharacters());
                    string filePath = Path.Combine(directory, fileName);
                    string validFilePath = Function.NextAvailableFilename(filePath);
                    Uri baseUri = new Uri(_SettingOther.Link);
                    string path = $"{request.Code}/{request.OID.RemoveSpecialCharacters()}/{Path.GetFileName(validFilePath)}";
                    Uri fullUri = new Uri(baseUri, path);
                    string validFileLink = fullUri.ToString();

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    System.IO.File.WriteAllBytes(validFilePath, fileBytes);

                    // Store file link for successful upload
                    resResults.SuccessInfos.Add(new SuccessInfos()
                    {
                        FileName = request.Base64s[i].FileName,
                        Link = validFileLink
                    });

                    importDatabase.Add(new Uploads.Request.ImportDatabase()
                    {
                        FileName = request.Base64s[i].FileName,
                        ContentType = request.Base64s[i].ContentType,
                        Link = validFileLink,
                        Path = validFilePath
                    });
                }
                catch (Exception ex)
                {
                    resResults.FailureInfos.Add(new FailureInfos()
                    {
                        FileName = request.Base64s[i].FileName,
                        Description = ex.Message
                    });
                }
            }
            resResults.TotalSuccess = resResults.SuccessInfos.Count;
            resResults.TotalFailure = resResults.FailureInfos.Count;
            foreach (int index in indexRemoves)
            {
                request.Base64s.RemoveAt(index);
            }
            indexRemoves.Clear();

            // Return response
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "UPLOAD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataTable dataTable = importDatabase.ToDataTable();
                dataTable.SetTypeName("UploadFiles");
                if (dataTable.Rows.Count > 0)
                {
                    parameters.Add("@UploadFiles", dataTable);
                }
                request.Base64s = null;
                DataResponse dataResponse = await Function.GetDataResponse(parameters, _CategoryDB, _ConfigurationDB, _ProcedureName, request);
                dataResponse.Result = resResults;
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] StationImages.Request.GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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