using APISmartCity.lib;
using APISmartCity.Models;
using Dapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Data;
using System.Data.SqlClient;

namespace APISmartCity.Lib.Function
{
    public static class Init
    {
        public static void IntDB()
        {
            using IDbConnection conn = new SqlConnection(Global.connectString);
            DynamicParameters p = new();
            p.Add("@Type", "GET");
            foreach (DBInfo dBInfo in conn.Query<DBInfo>("ExecDbConfigs", param: p, commandType: CommandType.StoredProcedure))
            {
                DBConnect dBConnect = new()
                {
                    DBType = dBInfo.DBType,
                    DBString = $"Server={dBInfo.ServerIP};Database={dBInfo.DBName};User Id={dBInfo.DBUserName};Password={dBInfo.DBPassWord.DecryptData()}"
                };
                Global.ListDB.Add(dBConnect);
            }

            p = new();
            p.Add("@Type", "Get");
            foreach (CompanyConfig CfInfo in conn.Query<CompanyConfig>("ExecCompanyConfigs", param: p, commandType: CommandType.StoredProcedure))
            {
                string _ServerConnectString = "";
                try
                {
                    _ServerConnectString = CfInfo.ServerConnectString.DecryptData();
                }
                catch
                {
                    _ServerConnectString = CfInfo.ServerConnectString;
                }

                CompanyConfig cfConnect = new()
                {
                    ID = CfInfo.ID,
                    Code = CfInfo.Code,
                    LemonID = CfInfo.LemonID,
                    Name = CfInfo.Name,
                    ServerName = CfInfo.ServerName,
                    ServerCode = CfInfo.ServerCode,
                    ServerConnectAPI = CfInfo.ServerConnectAPI,
                    ServerConnectString = _ServerConnectString,
                    LinkDeviceAPI = CfInfo.LinkDeviceAPI,
                    LinkMobileAPI = CfInfo.LinkMobileAPI
                };
                Global.ListCompanyConfig.Add(cfConnect);
            }

            p = new();
            p.Add("@Type", "Get");
            DBConnect dBConnectConfig = new()
            {
                DBType = "CON",
                DBString = Global.connectString
            };
            Global.ListDB.Add(dBConnectConfig);
            Global.ListFolder = conn.Query<DBFolder>("ExecSettingOthers", param: p, commandType: CommandType.StoredProcedure).ToList();
            if (Global.NamLongHubUrl?.Length > 0)
            {
                Global.ConfigHub();
            }
            //Ducnd ADD Url File upload Attach
            Global.CompanyUpload = conn.Query<CompanyUpload>("Select ID, DiskFolderSave, LinkFolderSave, Code as CompanyCode From CompanyConfigs").ToList();
        }
    }
}