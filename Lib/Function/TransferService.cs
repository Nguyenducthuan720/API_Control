using APISmartCity.lib;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static APISmartCity.Models.nPL.ReportProcess.Response;

namespace APISmartCity.TransferServices
{
    public class TransferService
    {
        private IHttpClientFactory HttpClientFactory { get; }

        public TransferService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task RequestToken()
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = "https://uatapi-control.npllogistics.com";
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("UserID", "API.TMS");
                httpClient.DefaultRequestHeaders.Add("Password", "KimTin2023");
                httpClient.DefaultRequestHeaders.Add("Grant_Type", "Password");
                JsonNode result = JsonSerializer.Deserialize<JsonNode>(await httpClient.GetStringAsync(url));
                Global.KimTinToken = result["access_token"].GetValue<string>();
            }
            catch (Exception ex)
            {
                Global.KimTinToken = ex.Message;
            }
        }

        public async Task<string> Transfer(string json, string controller, string function, string JWT)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                //await RequestToken();
                string url = string.Format("https://uatapi-control.npllogistics.com/api/{0}/{1}", controller, function);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", "vn");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
                if (json == null)
                {
                    json = "";
                }
                HttpContent httpContent = new StringContent(json, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> TransferFormFile<T>(T data, string controller, string function, string JWT)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                //await RequestToken();
                string url = string.Format("https://uatapi-control.npllogistics.com/api/{0}/{1}", controller, function);
                var content = new MultipartFormDataContent();

                foreach (var prop in data.GetType().GetProperties())
                {
                    var value = prop.GetValue(data);
                    if (value is List<IFormFile>)
                    {
                        foreach (var formFile in (List<IFormFile>)value)
                        {
                            content.Add(new StreamContent(formFile.OpenReadStream()), prop.Name, formFile.FileName);
                            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = prop.Name, FileName = formFile.FileName.Replace("\"", "") };
                        }
                    }
                    else
                    {
                        if (value is not null)
                        {
                            content.Add(new StringContent(JsonSerializer.Serialize(value).Replace("\"", "")), prop.Name);
                        }
                    }
                }
                httpClient.DefaultRequestHeaders.Accept.Clear();
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", "vn");

                if (!string.IsNullOrWhiteSpace(JWT))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
                var response = await httpClient.PostAsync(url, content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<PriceMaterial>> GetPriceMaterial(string CompanyCode, MaintenanceSupplyPrices item)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetPriceMaterial?CompanyCode={0}&MaterialID={1}&Period={2}", CompanyCode, item.LemonID, item.Period);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
                var result = await httpClient.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    await RequestToken();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
                    result = await httpClient.GetAsync(url);
                    var aaa = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<PriceMaterial>>(aaa);
                }
                else
                {
                    var aaa = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<PriceMaterial>>(aaa);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> GetDataOil(string CompanyCode, string LicensePlates, string Period)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                //await RequestToken();
                string url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetKMofOilFilling?CompanyCode={0}&LicensePlates={1}&Period={2}", CompanyCode, Uri.EscapeDataString(LicensePlates), Uri.EscapeDataString(Period));
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
                //JsonNode result = JsonSerializer.Deserialize<JsonNode>(await httpClient.GetStringAsync(url));
                var result = await httpClient.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    await RequestToken();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
                    result = await httpClient.GetAsync(url);
                    return await result.Content.ReadAsStringAsync();
                }
                else
                {
                    return await result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}