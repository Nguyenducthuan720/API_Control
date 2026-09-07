using APISmartCity.lib;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using static APISmartCity.Models.Logistics.VietMap.Request;

namespace APISmartCity.VietmapGeocodeServices
{
    public class VietmapGeocodeService
    {
        private IHttpClientFactory HttpClientFactory { get; }

        //private readonly string Apikey = "6b23c579121400aab9b6cd2b928e857f403cf4ed22fa5344";
        private readonly string Apikey = Global.VietMapApiKey;

        public VietmapGeocodeService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<List<RefID>> GeoCode(string address)
        {
            try
            {
                List<RefID> listAutoComplete = new();
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://maps.vietmap.vn/api/search/v3?api-version=1.1&apikey={0}&text={1}", Apikey, Uri.EscapeDataString(address));
                var result = await httpClient.GetStringAsync(url);
                JsonNode data2 = JsonSerializer.Deserialize<JsonNode>(result);
                foreach (JsonNode item in data2.AsArray())
                {
                    RefID addGeoCode = new()
                    {
                        Address = item["display"].GetValue<string>(),
                        RefId = item["ref_id"].GetValue<string>()
                    };
                    listAutoComplete.Add(addGeoCode);
                }
                return listAutoComplete;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<AddGeoCode> Place(string RefID)
        {
            try
            {
                List<RefID> listAutoComplete = new();
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://maps.vietmap.vn/api/place/v3?apikey={0}&refid={1}", Apikey, Uri.EscapeDataString(RefID));
                var result = await httpClient.GetStringAsync(url);
                JsonNode data2 = JsonSerializer.Deserialize<JsonNode>(result);
                return new AddGeoCode()
                {
                    Address = RefID,
                    Lat = data2["lat"].GetValue<decimal>().ToString(),
                    Long = data2["lng"].GetValue<decimal>().ToString()
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<AddGeoCode>> AutoComplete(string address)
        {
            try
            {
                List<AddGeoCode> listAutoComplete = new();
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://maps.vietmap.vn/api/search?api-version=1.1&apikey={0}&text={1}", Apikey, Uri.EscapeDataString(address));
                var result = await httpClient.GetStringAsync(url);
                JsonNode data2 = JsonSerializer.Deserialize<JsonNode>(result);
                foreach (JsonNode item in data2["data"]["features"].AsArray())
                {
                    AddGeoCode addGeoCode = new()
                    {
                        Address = item["properties"]["label"].GetValue<string>(),
                        Lat = item["geometry"]["coordinates"][1].GetValue<decimal>().ToString(),
                        Long = item["geometry"]["coordinates"][0].GetValue<decimal>().ToString()
                    };
                    listAutoComplete.Add(addGeoCode);
                }
                return listAutoComplete;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> Route(string StringPoint)
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string point = StringPoint.Replace("[", "point=").Replace("],", "&").Replace("]", "");
                List<Routes> ListRoute = new();
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://maps.vietmap.vn/api/route?api-version=1.1&apikey={0}&{1}&points_encoded=false&vehicle={2}&roundtrip=false&destinations=last&sources=first", Apikey, point, Global.VietMapVehicle);
                return await httpClient.GetStringAsync(url);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> TSP(string StringPoint)
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string point = StringPoint.Replace("[", "point=").Replace("],", "&").Replace("]", "");
                List<Routes> ListRoute = new();
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://maps.vietmap.vn/api/tsp?api-version=1.1&apikey={0}&{1}&points_encoded=false&vehicle={2}&roundtrip=false&destinations=last&sources=first", Apikey, point, Global.VietMapVehicle);
                return await httpClient.GetStringAsync(url);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> GeoCodeVer2(string address)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://maps.vietmap.vn/api/search/v3?api-version=1.1&apikey={0}&text={1}", Apikey, Uri.EscapeDataString(address));
                return await httpClient.GetStringAsync(url);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}