using APISmartCity.DI;
using APISmartCity.lib;
using Dapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using APISmartCity.TransferServices;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text.Json;

namespace APISmartCity.Helpers
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TransferDataDeviceService _transferService;

        public static string Language { get; set; }
        public Middleware(RequestDelegate next, IMemoryCache cache, IHttpClientFactory httpClientFactory, TransferDataDeviceService transferService)
        {
            _next = next;
            _cache = cache;
            _httpClientFactory = httpClientFactory;
            _transferService = transferService;
        }

        public async Task InvokeAsync(HttpContext context, UserInfo userInfo, APIInfo apiInfo)
        {
            // Xử lý yêu cầu dựa trên thông tin xác thực người dùng
            if (context.User?.Identity!.IsAuthenticated == true)
            {
                if (((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault().Value! != null)
                {
                    userInfo.UserID = ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault().Value!;
                }
                else
                {
                    userInfo.UserID = ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)!.Value;
                }

                userInfo.CmpnID = ((ClaimsIdentity)context.User.Identity).HasClaim(x => x.Type == "CmpnID") ? ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault(x => x.Type == "CmpnID")!.Value : "0";

                userInfo.TokenApp = "";

                using IDbConnection conn = new SqlConnection(Global.connectString);
                DynamicParameters p = new();
                p.Add("@Type", "Get-Status");
                p.Add("@UserID", userInfo.UserID.ToString());
                foreach (UserStatus user in conn.Query<UserStatus>("[ExecUser]", param: p, commandType: CommandType.StoredProcedure))
                {
                    if (user.UserID == userInfo.UserID)
                    {
                        if (user.IsActive == 0 || user.UserID.ToUpper() == "7788")
                        {
                            context.Response.Clear();
                            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            await context.Response.WriteAsync(HttpStatusCode.Forbidden.GetDisplayName());
                            return;
                        }
                    }
                }
            }

            userInfo.Language = context.Request.Headers["Language"].ToString();
            if(userInfo.Language == "")
            {
                userInfo.Language = "VN";
            }    

            var linkSubmit = context.Request.Path.ToString();
            const string pattern = "(swagger|/signalrServer|/NamLongHub|/test)";
            const string pattern2 = "(embedded|guests|lggateway)";

            var isPattern2Match = Regex.IsMatch(linkSubmit, pattern2, RegexOptions.IgnoreCase);
            var apiKey = context.Request.Headers["APIKEY"].ToString();
            apiInfo.APIKEY = apiKey;
            apiInfo.LinkSubmit = linkSubmit;
            apiInfo.Language = context.Request.Headers["Language"].ToString();


            if (Regex.IsMatch(linkSubmit, pattern, RegexOptions.IgnoreCase) || linkSubmit == "/")
            {
                await _next.Invoke(context);
            }
            else if (isPattern2Match)
            {
                if (Regex.IsMatch(linkSubmit, "guests", RegexOptions.IgnoreCase))
                {
                    if (apiKey != "")
                    {
                       // Sau khi hoàn thành, hiệu chỉnh về 30s
                        int TimeCheck = 10;

                        // bỏ token test
                        //if (apiKey != "p7uVDH9KYRHR7BuxSTveUOXugvIAonuKU8JveCthe7hzU+1H/AV6oyDDksEFus0B1JiT1ibQTgKEXGcNxkEL57eeJ+d2yLEjN+jXN/dvnNtb/cr38BQUDP2cuE3OA+8HyvjZJnraIUU9xQTz08fvW3K9w8ixTwQ1Wu5NXE4kbxbbcyKH8Hyfvds7W8GF9YOmchbbNdEfgYbBd536bd2JYbrIXRWpy+xHJ5XnsXV+4+w7bLFfku1Dg72KbtXMAzmYfaFvuXHLEWyE0jpTlAV0jg==")
                        //{
                        //    TimeCheck = 10;
                        //}

                        try
                        {

                            string Timmer = ""; string CollectFromServer = ""; string CmpnID = ""; string AppCode = ""; string token = "";

                            Global.ApiKeyGuest = apiKey;

                            string apiKeyDecrypt = APIKeyEncryption.APIKEYDecryptData(apiKey);

                            string[] parts = apiKeyDecrypt.Split(new string[] { APIKeyEncryption.APIKEYEncryptDataKey("NLT") }, StringSplitOptions.None);


                            Timmer = APIKeyEncryption.APIKEYDecryptDataKey(parts[1]);
                            CollectFromServer = APIKeyEncryption.APIKEYDecryptDataKey(parts[2]) ;
                            CmpnID = APIKeyEncryption.APIKEYDecryptDataKey(parts[3]);
                            AppCode = APIKeyEncryption.APIKEYDecryptDataKey(parts[5]); // check lai token ma hoa

                            apiInfo.CmpnID = CmpnID;
                            apiInfo.AppCode = AppCode;
                            apiInfo.CollectFromServer = CollectFromServer;

                            DateTime currentTime = DateTime.Now;
                            DateTime parsedTimeText = DateTime.ParseExact(Timmer, "HHmmss", null);

                            TimeSpan timeDifference = currentTime - parsedTimeText;

                            // Sau khi hoàn thành, hiệu chỉnh về 30s
                            if (timeDifference.TotalMinutes <= TimeCheck)
                            {
                                if (context.User?.Identity!.IsAuthenticated == true)
                                {
                                    string authorizationHeader = context.Request.Headers["Authorization"];

                                    token = GetTokenFromAuthorizationHeader(authorizationHeader);
                                    userInfo.CmpnID = CmpnID;
                                }

                                apiInfo.CmpnID = CmpnID;
                                apiInfo.AppCode = AppCode;
                                apiInfo.CollectFromServer = CollectFromServer;

                                await _next.Invoke(context);
                                return;
                            }
                            else
                            {
                                context.Response.Clear();
                                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                await context.Response.WriteAsync(HttpStatusCode.Unauthorized.GetDisplayName());
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            context.Response.Clear();
                            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                            await context.Response.WriteAsync(HttpStatusCode.MethodNotAllowed.GetDisplayName() + ex.ToString());
                            return;
                        }

                        
                    }
                    else
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await context.Response.WriteAsync(HttpStatusCode.Unauthorized.GetDisplayName());
                        return;
                    }
                }
                else
                {
                    try
                    {
                        string checkAuthenApiKey = Global.ListCompanyConfig?.Find(item => item.ServerConnectAPI == apiKey)?.ServerConnectString;

                        if (checkAuthenApiKey != null && checkAuthenApiKey != "" && apiKey.Trim().Length > 8)
                        {
                            if (context.Request.ContentLength == 0)
                            {
                                context.Response.Clear();
                                context.Response.StatusCode = (int)HttpStatusCode.UnsupportedMediaType;
                                await context.Response.WriteAsync(HttpStatusCode.UnsupportedMediaType.GetDisplayName());
                                return;
                            }

                            //next to controller
                            await _next(context);
                        }
                        else
                        {
                            context.Response.Clear();
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            await context.Response.WriteAsync(HttpStatusCode.Unauthorized.GetDisplayName());
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                        await context.Response.WriteAsync(HttpStatusCode.MethodNotAllowed.GetDisplayName() + ex.ToString());
                        return;
                    }
                }

            }
            else
            {
                await _next.Invoke(context);
                //await ProcessRedirectAsync(context, apiInfo, userInfo);
            }
        }
        private async Task TransferData(HttpContext context,  APIInfo apiInfo,  string Token, string LinkCall)
        {
            //Transfer data
            // Xử lý trường hợp Gateway đẩy về server lưu qua API
            string linkSubmintTransfer = LinkCall + apiInfo.LinkSubmit;
            ExpandoObject request = await GetRequestBodyAsExpandoAsync(context);
            string kq = await _transferService.TransferDynamicTokenAndAPIKey(request, linkSubmintTransfer, apiInfo.Language, Token, apiInfo.APIKEY);
            try
            {
                // Deserialize kq (the JSON string) into a JsonDocument
                using (JsonDocument jsonDoc = JsonDocument.Parse(kq))
                {
                    // Convert JsonDocument to a string
                    var jsonString = jsonDoc.RootElement.ToString();

                    // Write the JSON response
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(jsonString);
                    return;
                }
            }
            catch (Exception ex)
            {
                // Catch any other potential errors
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"An error occurred: {ex.Message}");
                return;
            }
        }

        public async Task<ExpandoObject> GetRequestBodyAsExpandoAsync(HttpContext context)
        {
            // Enable reading the request body multiple times
            context.Request.EnableBuffering();

            // Read the request body as a string
            using (var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();

                // Reset the request body position for further processing in the pipeline
                context.Request.Body.Position = 0;

                // Deserialize the JSON to an ExpandoObject
                var expandoConverter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
                return JsonConvert.DeserializeObject<ExpandoObject>(body, expandoConverter);
            }
        }

        private async Task ProcessRedirectAsync(HttpContext context, APIInfo apiInfo, UserInfo userInfo)
        {
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                var cmpnIDs = userInfo.CmpnID.Split(',');
                string linkCallApi = Global.ListCompanyConfig?.Find(item => cmpnIDs.Contains(item.ID))?.LinkMobileAPI;

                if (linkCallApi.Length > 10 && linkCallApi != "N/A")
                {
                    //Transfer data
                    // Xử lý trường hợp Gateway đẩy về server lưu qua API
                    string authorizationHeader = context.Request.Headers["Authorization"];
                    string token = GetTokenFromAuthorizationHeader(authorizationHeader);

                    string linkSubmintTransfer = linkCallApi + apiInfo.LinkSubmit;
                    ExpandoObject request = await GetRequestBodyAsExpandoAsync(context);
                    string kq = await _transferService.TransferDynamicToken(request, linkSubmintTransfer, apiInfo.Language, token);
                    try
                    {
                        // Deserialize kq (the JSON string) into a JsonDocument
                        using (JsonDocument jsonDoc = JsonDocument.Parse(kq))
                        {
                            // Convert JsonDocument to a string
                            var jsonString = jsonDoc.RootElement.ToString();

                            // Write the JSON response
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(jsonString);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any other potential errors
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync($"An error occurred: {ex.Message}");
                        return;
                    }
                }
            }

            await _next(context);


            //    if (_cache.TryGetValue(token, out string linkMobileAPI))
            //    {
            //        var scheme = context.Request.Scheme;
            //        var currentHost = context.Request.Host.ToString();
            //        var currentPath = context.Request.Path.ToString();
            //        var currentQuery = context.Request.QueryString.ToString();
            //        var currentUrl = $"{scheme}://{currentHost.TrimEnd('/')}{currentPath}{currentQuery}";

            //        if (!string.IsNullOrEmpty(linkMobileAPI) && Uri.IsWellFormedUriString(linkMobileAPI, UriKind.Absolute))
            //        {
            //            var newUrl = $"{linkMobileAPI.TrimEnd('/')}{currentPath}{currentQuery}";

            //            if (newUrl.Equals(currentUrl, StringComparison.OrdinalIgnoreCase))
            //            {
            //                await _next(context);
            //                return;
            //            }

            //            using (var newRequest = new HttpRequestMessage(new HttpMethod(context.Request.Method), newUrl))
            //            {
            //                foreach (var header in context.Request.Headers)
            //                {
            //                    if (IsHeaderAllowed(header.Key))
            //                    {
            //                        if (!newRequest.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()))
            //                        {
            //                            if (newRequest.Content != null)
            //                            {
            //                                newRequest.Content.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            //                            }
            //                        }
            //                    }
            //                }

            //                try
            //                {
            //                    using (var httpClient = _httpClientFactory.CreateClient())
            //                    {
            //                        newRequest.Headers.TryAddWithoutValidation("Language", Language);
            //                        if (context.Request.ContentLength > 0)
            //                        {
            //                            var content = await new StreamReader(context.Request.Body).ReadToEndAsync();
            //                            newRequest.Content = new StringContent(content, Encoding.UTF8, "application/json");
            //                        }

            //                        var response = await httpClient.SendAsync(newRequest, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted);
            //                        var responseBody = await response.Content.ReadAsStringAsync();

            //                        context.Response.StatusCode = (int)response.StatusCode;
            //                        context.Response.ContentType = "application/json";
            //                        context.Response.Headers["Language"] = apiInfo.Language;
            //                        await context.Response.WriteAsync(responseBody);
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    context.Response.StatusCode = 500;
            //                    await context.Response.WriteAsync($"Error reading or parsing JSON response: {ex.Message}");
            //                }

            //                return;
            //            }
            //        }
            //        else
            //        {
            //            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //            await context.Response.WriteAsync("Invalid redirect URL.");
            //            return;
            //        }
            //    }
            //}
            //else
            //{
            //    context.Response.Clear();
            //    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //    await context.Response.WriteAsync(HttpStatusCode.Unauthorized.GetDisplayName());
            //    return;
            //}    

            //await _next(context);
        }

        private bool IsHeaderAllowed(string headerName)
        {
            return headerName switch
            {
                "Authorization" => true,
                "Content-Type" => true,
                _ => false,
            };
        }

        private string GetTokenFromAuthorizationHeader(string authorizationHeader)
        {
            return authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
        }


    }

    public static class HandlerExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
