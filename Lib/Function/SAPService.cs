using System.Text.Json;

namespace APISmartCity.SAPServices
{
    public class SAPService
    {
        private IHttpClientFactory HttpClientFactory { get; }

        public SAPService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<string> GetInfoTO(string source, string lgSource, string lgDest)
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();
                string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", lgSource, lgDest, Uri.EscapeDataString(source));
                var result = await httpClient.GetStringAsync(url);
                var jsonData = JsonSerializer.Deserialize<List<dynamic>>(result);
                var translationItems = jsonData[0][0][0];
                return translationItems.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}