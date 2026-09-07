using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authentication;

namespace APISmartCity.lib
{
    public static class Function2
    {
        private static readonly string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly object _logLock = new();
        private static readonly Dictionary<string, Func<IDataReader, object>> _mapperCache = new();


        public static bool ValidateUser(string username, string password)
        {
            try
            {
                using (var context = new PrincipalContext(
                    ContextType.Domain,
                    Global.DCServer,   // DC server
                    Global.BaseDN))    // Base DN
                {
                    return context.ValidateCredentials(username, password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        private static void Log(string level, string message)
        {
            try
            {
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                string path = Path.Combine(logDir, $"Function2_{DateTime.Now:yyyy-MM-dd}.txt");
                string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level}] {message}";
                lock (_logLock)
                    File.AppendAllText(path, line + Environment.NewLine);
            }
            catch { }
        }

        public static async Task<APIDataResponse> GetDataResponse2(
            IDictionary<string, object> parameters,
            string _stringConnect,
            string _stringConnectConfig,
            string procName,
            object request)
        {
            var swTotal = Stopwatch.StartNew();
            Log("INFO", $"[START] GetDataResponse2 => {procName}");

            var dataResponse = new APIDataResponse();
            try
            {
                using var conn = new SqlConnection(_stringConnect);
                await conn.OpenAsync().ConfigureAwait(false);

                // ========================
                // BUILD PARAMETERS
                // ========================
                var swParam = Stopwatch.StartNew();
                var p = new DynamicParameters();

                // 1️⃣ Add parameters từ dictionary
                foreach (var kv in parameters)
                    p.Add(kv.Key, kv.Value);

                // 2️⃣ Add từ request object (payload client)
                if (request != null)
                {
                    foreach (var prop in request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        var name = prop.Name.StartsWith("@") ? prop.Name : "@" + prop.Name;
                        var value = prop.GetValue(request);
                        p.Add(name, value ?? DBNull.Value);
                    }
                }

                swParam.Stop();
                Log("DEBUG", $"[PARAM] Built {p.ParameterNames.Count()} params in {swParam.ElapsedMilliseconds} ms");

                // ========================
                // GHI LOG SQL TRƯỚC KHI EXEC
                // ========================
                Log("INFO", $"LogActions2 started: {procName}");
                var logSw = Stopwatch.StartNew();
                LogActions2(procName, p, _stringConnectConfig);
                logSw.Stop();
                Log("INFO", $"LogActions2 completed: {procName} in {logSw.ElapsedMilliseconds} ms");

                // ========================
                // EXECUTE PROC
                // ========================
                var swExec = Stopwatch.StartNew();
                using var multi = await conn.QueryMultipleAsync(
                    new CommandDefinition(procName, p, commandType: CommandType.StoredProcedure, flags: CommandFlags.NoCache)
                ).ConfigureAwait(false);
                swExec.Stop();
                Log("DEBUG", $"[QUERY] QueryMultipleAsync done in {swExec.ElapsedMilliseconds} ms");

                // ========================
                // READ RESULT SET(S)
                // ========================
                var swMap = Stopwatch.StartNew();
                var resultSets = new List<object>();
                int count = 0;

                while (!multi.IsConsumed)
                {
                    var list = (await multi.ReadAsync().ConfigureAwait(false)).ToList();

                    if (count == 0 && list.Any())
                    {
                        var first = (IDictionary<string, object>)list.First();
                        dataResponse.ErrorCode = first.ContainsKey("Valuerr") ? first["Valuerr"]?.ToString() ?? "0" : "0";
                        dataResponse.Message = first.ContainsKey("ErrDescription") ? first["ErrDescription"]?.ToString() ?? "Success" : "Success";
                        foreach (var i in list)
                        {
                            ((IDictionary<string, object>)i).Remove("Valuerr");
                            ((IDictionary<string, object>)i).Remove("ErrDescription");
                        }
                    }

                    resultSets.Add(list);
                    count++;
                }

                swMap.Stop();
                Log("DEBUG", $"[MAP] {count} result set(s) mapped in {swMap.ElapsedMilliseconds} ms");

                // ========================
                // BUILD RESPONSE
                // ========================
                if (resultSets.Count == 1)
                    dataResponse.Result = resultSets.First();
                else
                    dataResponse.Result = resultSets;

                if (string.IsNullOrEmpty(dataResponse.ErrorCode))
                    dataResponse.ErrorCode = "0";

                dataResponse.Message ??= "Success";
            }
            catch (SqlException ex)
            {
                dataResponse.ErrorCode = "-4";
                dataResponse.Message = $"SQL Error: {ex.Message}";
                Log("ERROR", $"[SQL] {ex.Message}");
            }
            catch (Exception ex)
            {
                dataResponse.ErrorCode = "-3";
                dataResponse.Message = $"Exception: {ex.Message}";
                Log("ERROR", $"[EX] {ex.Message}");
            }
            finally
            {
                swTotal.Stop();
                Log("INFO", $"[END] GetDataResponse2 {procName} completed in {swTotal.ElapsedMilliseconds} ms");
            }

            return dataResponse;
        }

        // ========================
        // GHI LOG HỆ THỐNG (DB)
        // ========================
        private static void LogActions2(string ProcName, DynamicParameters p, string _stringConnectConfig)
        {
            try
            {
                if (ProcName == "ExecCustomize") return;

                var sbBefore = new System.Text.StringBuilder(2048);
                foreach (var paramName in p.ParameterNames)
                {
                    if ((p as SqlMapper.IParameterLookup)?[paramName] is DataTable dt)
                    {
                        sbBefore.Append($"DECLARE @{paramName} AS {dt.GetTypeName()} INSERT INTO @{paramName} SELECT ");
                        foreach (DataRow row in dt.Rows)
                        {
                            var vals = new List<string>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                var val = row[col];
                                vals.Add(val == null || val == DBNull.Value ? "NULL" : $"N'{val.ToString().Replace("'", "''")}'");
                            }
                            sbBefore.Append(string.Join(",", vals)).Append(" UNION ALL ");
                        }
                        sbBefore.Length -= 11; // remove last " UNION ALL "
                    }
                }

                var logSQL = string.Join(", ", p.ParameterNames.Select(n =>
                {
                    var val = (p as SqlMapper.IParameterLookup)?[n];
                    return $"@{n}={(val is DataTable ? $"@{n}" : $"'{val}'")}";
                }));

                var parameters = new DynamicParameters();
                parameters.Add("@LogAction", ProcName);
                parameters.Add("@LogSQL", $"{sbBefore} EXEC {ProcName} {logSQL}");
                parameters.Add("@UserID", 0);
                parameters.Add("@MAC", "localhost");
                parameters.Add("@LogDescription", ProcName);
                parameters.Add("@SearchID", ProcName);

                using var conn = new SqlConnection(_stringConnectConfig);
                conn.Execute("InsLogAction", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Log("WARN", $"[LogActions2] {ex.Message}");
            }
        }
    }

    // Response DTO
    public class APIDataResponse
    {
        public int? StatusCode { get; set; }
        public int? Success { get; set; }
        public string? ErrorCode { get; set; } = "";
        public string? Message { get; set; } = "";
        public object Result { get; set; } = new();

        public APIDataResponse()
        {
            StatusCode = 200;
            Success = 1;
            Message = "";
            ErrorCode = "";
        }

        public APIDataResponse(string des, dynamic result, string err)
        {
            if (err == "0" || err == "000")
            {
                Success = 1;
                StatusCode = 200;
            }
            else
            {
                Success = 0;
                StatusCode = int.Parse(err);
            }
            Message = des;
            Result = result;
            ErrorCode = err;
        }
    }
}
