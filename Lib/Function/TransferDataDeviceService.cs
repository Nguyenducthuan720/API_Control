using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace APISmartCity.TransferServices
{
    public class TransferDataDeviceService
    {
        private IHttpClientFactory HttpClientFactory { get; }

        public TransferDataDeviceService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<string> TransferDynamic(ExpandoObject json, string linkApiSubmint, string language, string apikey)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = linkApiSubmint;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", language);
                httpClient.DefaultRequestHeaders.Add("APIKEY", apikey);
                var convertRequest = JsonSerializer.Serialize(json);
                HttpContent httpContent = new StringContent(convertRequest, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> TransferDynamicToken(ExpandoObject json, string linkApiSubmint, string language, string token)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = linkApiSubmint;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", language);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var convertRequest = JsonSerializer.Serialize(json);
                HttpContent httpContent = new StringContent(convertRequest, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public async Task<string> TransferDynamicToken(string json, string linkApiSubmint, string language, string token)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = linkApiSubmint;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", language);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
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

        public async Task<string> TransferDynamicTokenAndAPIKey(ExpandoObject json, string linkApiSubmint, string language, string token, string apikey)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = linkApiSubmint;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", language);
                httpClient.DefaultRequestHeaders.Add("APIKEY", apikey);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var convertRequest = JsonSerializer.Serialize(json);
                HttpContent httpContent = new StringContent(convertRequest, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public async Task<string> Transfer(string json, string linkApiSubmint, string language, string apikey)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = linkApiSubmint;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Language", language);
                httpClient.DefaultRequestHeaders.Add("APIKEY", apikey);
                if (json != null)
                {
                    json = "";
                }
                var convertRequest = JsonSerializer.Serialize(json);
                HttpContent httpContent = new StringContent(convertRequest, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}