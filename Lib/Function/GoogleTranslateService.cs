using APISmartCity.lib;
using System.Reflection;
using System.Text.Json;

namespace APISmartCity.GoogleTranslateServices
{
    public class GoogleTranslateService
    {
        private IHttpClientFactory HttpClientFactory { get; }

        public GoogleTranslateService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<string> Translate(string source, string lgSource, string lgDest)
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

        public async Task<object> TranslateObject(object source)
        {
            try
            {
                var translate = source;
                var httpClient = HttpClientFactory.CreateClient();
                string Name = "";
                string NameExtension1 = "";
                string Address = "";
                string AddressExtension1 = "";
                foreach (var item in translate?.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>())
                {
                    if (item.Name == "NameExtention1")
                    {
                        NameExtension1 = item.GetValue(translate).ToString();
                    }
                    if (item.Name == "Name")
                    {
                        Name = item.GetValue(translate).ToString();
                    }
                    if (item.Name == "AddressExtention1")
                    {
                        AddressExtension1 = item.GetValue(translate).ToString();
                    }
                    if (item.Name == "Address")
                    {
                        Address = item.GetValue(translate).ToString();
                    }
                }

                if (Function.CheckGoogleTranslate(Name, NameExtension1))
                {
                    string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", "VI", "EN", Uri.EscapeDataString(Name));
                    var result = await httpClient.GetStringAsync(url);
                    var jsonData = JsonSerializer.Deserialize<List<dynamic>>(result);
                    var translationItems = jsonData[0][0][0].ToString();
                    PropertyInfo propertyInfo = translate.GetType().GetProperty("NameExtention1");
                    propertyInfo?.SetValue(translate, Convert.ChangeType(translationItems, propertyInfo.PropertyType), null);
                }

                if (Function.CheckGoogleTranslate(Address, AddressExtension1))
                {
                    string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", "VI", "EN", Uri.EscapeDataString(Address));
                    var result = await httpClient.GetStringAsync(url);
                    var jsonData = JsonSerializer.Deserialize<List<dynamic>>(result);
                    var translationItems = jsonData[0][0][0].ToString();
                    PropertyInfo propertyInfo = translate.GetType().GetProperty("AddressExtention1");
                    propertyInfo?.SetValue(translate, Convert.ChangeType(translationItems, propertyInfo.PropertyType), null);
                }
                return translate;
            }
            catch
            {
                return source;
            }
        }
    }
}