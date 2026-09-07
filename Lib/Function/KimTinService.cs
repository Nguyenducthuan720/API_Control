using APISmartCity.lib;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using static APISmartCity.Models.nPL.ReportProcess.Response;

namespace APISmartCity.VietmapGeocodeServices
{
    public class KimTinService
    {
        private IHttpClientFactory HttpClientFactory { get; }

        public KimTinService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task RequestToken()
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = "https://services.kimtingroup.com/KGOCEAN/api/TMSService/RequestToken";
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

        public async Task<string> GetDataCreditLimit(string CompanyCode, string CustomerID)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                //await RequestToken();
                string url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetCreditLimit?CompanyCode={0}&CustomerID={1}", CompanyCode, Uri.EscapeDataString(CustomerID));
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

        public async Task<string> SyncCustomer(string CompanyCode)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetCustomer?CompanyCode={0}&CustomerID=%", CompanyCode);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
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
        /// <summary>
        /// 8. Lấy thông tin vật tư + giá mua mới nhất theo khoảng thời gian
        /// </summary>
        public async Task<string> GetMaterialWithLatestPurchasePrice(string CompanyCode, string WareHouseID, string DateFrom, string DateTo)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();

                string url = string.Format(
                    "https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetMaterialStockAndLatestPrice?CompanyCode={0}&WareHouseID={1}&DateFrom={2}&DateTo={3}",
                    CompanyCode,
                    Uri.EscapeDataString(WareHouseID),
                    DateFrom,
                    DateTo);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);

                var result = await httpClient.GetAsync(url);

                if (!result.IsSuccessStatusCode)
                {
                    await RequestToken();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
                    result = await httpClient.GetAsync(url);
                }

                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 9. Lấy lịch sử mua hàng theo khoảng thời gian
        /// </summary>
        public async Task<string> GetPurchaseHistory(string CompanyCode, string DateFrom, string DateTo)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();

                string url = string.Format(
                    "https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetPurchaseHistory?CompanyCode={0}&DateFrom={1}&DateTo={2}",
                    CompanyCode,
                    DateFrom,
                    DateTo);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);

                var result = await httpClient.GetAsync(url);

                if (!result.IsSuccessStatusCode)
                {
                    await RequestToken();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
                    result = await httpClient.GetAsync(url);
                }

                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> SyncCategories(string CompanyCode, string Type)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = "";
                if (Type == "PetrolStations")
                {
                    url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetOilStation?CompanyCode={0}", CompanyCode);
                }
                else if (Type == "OutsourcedVehicleProviders")
                {
                    url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetVendors?CompanyCode={0}&VendorID=%", CompanyCode);
                }
                else
                {
                    url = string.Format("https://services.kimtingroup.com/KGOCEAN/api/TMSService/GetMaterial?CompanyCode={0}&MaterialID=%", CompanyCode);
                }

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.KimTinToken);
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