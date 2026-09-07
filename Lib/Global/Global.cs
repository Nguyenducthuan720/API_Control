using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace APISmartCity.lib
{
    public static class Global
    {
        public static string connectString = "";
        public static string connectStringPostgreSQL = "";

        public static string RunAPIShare = "";

        public static string KimTinToken = "";
        public static List<DBConnect> ListDB { get; set; } = new List<DBConnect>();

        public static List<UserStatus> ListUserStatus { get; set; } = new List<UserStatus>();

        public static List<CompanyConfig> ListCompanyConfig { get; set; } = new List<CompanyConfig>();

        public static List<DBFolder> ListFolder { get; set; } = new List<DBFolder>();

        //ducnd ADD
        public static List<CompanyUpload> CompanyUpload { get; set; } = new List<CompanyUpload>();

        public static string ApiKey { get; set; } = "";
        public static string VietMapApiKey { get; set; } = "";
        public static string VietMapVehicle { get; set; } = "";
        public static string SmartRadioUrl { get; set; } = "";
        public static string NamLongHubUrl { get; set; } = "";
        public static string MQTTAddress { get; set; }
        public static string MQTTUser { get; set; }
        public static string MQTTPassword { get; set; }
        public static string ApiKeyGuest { get; set; } = "";

        public static HubConnection SmartRadioHub { get; set; }
        public static HubConnection NamLongHub { get; set; }

        public static void ConfigHub()
        {
            SmartRadioHub = new HubConnectionBuilder()
            .WithUrl(SmartRadioUrl, options => options.Headers.Add("APIKEY", ApiKey))
            .WithAutomaticReconnect()
            .Build();

            SmartRadioHub.Closed += async (ex) =>
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("Reconnection");
                await Task.Delay(new Random().Next(1, 5) * 1000);
                await SmartRadioHub.StartAsync();
            };

            NamLongHub = new HubConnectionBuilder()
            .WithUrl(NamLongHubUrl, options => options.Headers.Add("APIKEY", ApiKey))
            .WithAutomaticReconnect()
            .Build();

            NamLongHub.Closed += async (ex) =>
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("Reconnection");
                await Task.Delay(new Random().Next(1, 5) * 1000);
                await NamLongHub.StartAsync();
            };
        }

        public static string IsUserDomain { get; set; }
        public static string DCServer { get; set; }
        public static string DCPort { get; set; }
        public static string BaseDN { get; set; }
        public static string DCUserName { get; set; }
        public static string DCPassword { get; set; }

    }

    public class DBConnect
    {
        public string? DBType { get; set; }
        public string? DBString { get; set; }
    }

    public class CompanyConfig
    {
        public string? ID { get; set; }

        public string? Code { get; set; }

        public string? LemonID { get; set; }

        public string? Name { get; set; }

        public string? ServerName { get; set; }

        public string? ServerCode { get; set; }

        public string? ServerConnectAPI { get; set; }

        public string? ServerConnectString { get; set; }

        public string? LinkDeviceAPI { get; set; }

        public string? LinkMobileAPI { get; set; }
    }
    public class CompanyConfigGateway
    {
        public string? CmpnID { get; set; }

        public string? CollectFromServer { get; set; }

        public string? Name { get; set; }

        public string? LinkMobileAPI { get; set; }
    }

    public class DBFolder
    {
        public string? Type { get; set; }
        public string? Link { get; set; }
        public string? Path { get; set; }
    }

    public class UserStatus
    {
        public string? UserID { get; set; }

        public string? UserName { get; set; }

        public int? IsActive { get; set; }
    }

    public class NLApiKey
    {
        public string? ServerName { get; set; }
        public string? ApiKey { get; set; }
    }

    public class CompanyUpload
    {
        public int? ID { get; set; }
        public string? DiskFolderSave { get; set; }
        public string? LinkFolderSave { get; set; }
        public string? CompanyCode { get; set; }
    }
}