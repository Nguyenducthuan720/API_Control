using System.Text;
using System.Text.Json;

namespace APISmartCity.Lib.Function
{
    public class Convert_Json_Base64
    {
        public static string Base64ToString(string Base64String)
        {
            try
            {
                byte[] bytes = System.Convert.FromBase64String(Base64String);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (FormatException)
            {
                return "Invalid Base64 string";
            }
        }
        public class Base64
        {
            public string? Base64String { get; set; }

        }
        public class Json
        {
            public JsonElement JsonString { get; set; }

        }
        public static string StringToBase64(string Base64String)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Base64String);
                return System.Convert.ToBase64String(bytes);
            }
            catch (FormatException)
            {
                return "Invalid Json";
            }
        }
    }
}