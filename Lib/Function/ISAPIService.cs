using APISmartCity.Models.Ver2.Function;
using System.Net;

namespace APISmartCity.ISAPIServices
{
    public class ISAPIService
    {
        public async Task<byte[]> GetImage(ISAPIInformation ISAPI)
        {
            try
            {
                string requestUri = $"http://{ISAPI.IPAddress}:{ISAPI.HttpPort}/ISAPI/Streaming/channels/{ISAPI.Channel}01/picture";
                using var httpClient = new HttpClient(
                            new HttpClientHandler
                            {
                                Credentials =
                                    new NetworkCredential(
                                        ISAPI.UserName,
                                        ISAPI.Password)
                            });
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(requestUri));
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}