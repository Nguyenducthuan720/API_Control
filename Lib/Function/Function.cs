using APISmartCity.GoogleTranslateServices;
using APISmartCity.Models;
using Dapper;
using DocumentFormat.OpenXml.VariantTypes;
using ExcelDataReader;
using StaticService;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Convert;
using static System.Text.Encoding;
using Image = System.Drawing.Image;

namespace APISmartCity.lib
{
    public static class Function
    {
        private const string NumberPattern = "-{0}";
        private const string pattern1 = "(password|passnew)";
        private const string pattern2 = "(phone|Cloud|Device)";

        public static class ContentEnum
        {
            public static List<string> AllowedContentTypes = new List<string> { "image/jpeg", "image/png" };
        }

        public static async Task<DataResponse> GetDataResponse(IDictionary<string, object> parameters, string _stringConnect, string _stringConnectConfig, string procName, object request)
        {
            DataResponse dataResponse = new();
            try
            {
                using IDbConnection conn = new SqlConnection(_stringConnect);
                var p = new DynamicParameters();
                foreach (string key in parameters.Keys)
                {
                    p.Add(key, parameters[key]);
                }
                foreach (var item in request?.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>())
                {
                    var value = item.GetValue(request);
                    //if (item.Name != "LinkAvatar")
                    //{
                    //    if (value == null)
                    //    {
                    //        if (item.Name.Contains("Extent", StringComparison.OrdinalIgnoreCase))
                    //        {
                    //            p.Add("@" + item.Name, "");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        p.Add("@" + item.Name, (Regex.IsMatch(item.Name, pattern1, RegexOptions.IgnoreCase) && !Regex.IsMatch(item.Name, pattern2, RegexOptions.IgnoreCase)) ? value.ToString().MD5Hash() : value);
                    //    }
                    //}

                    if (value == null)
                    {
                        if (item.Name.Contains("Extent", StringComparison.OrdinalIgnoreCase))
                        {
                            p.Add("@" + item.Name, "");
                        }
                        if (item.Name == "CmpnID")
                        {
                            p.Add("@" + item.Name, "-1");
                        }
                    }
                    else
                    {
                        var exceptList = new List<string> { "APIPassword", "ERPPassword" };
                        if (!exceptList.Contains(item.Name))
                        { 
                            p.Add("@" + item.Name, (Regex.IsMatch(item.Name, pattern1, RegexOptions.IgnoreCase) && !Regex.IsMatch(item.Name, pattern2, RegexOptions.IgnoreCase)) ? value.ToString().MD5Hash() : value);
                        }
                        else
                        {
                            p.Add("@" + item.Name, value);
                        }
                    }
                }
                LogActions(procName, p, _stringConnectConfig);
                var result = new List<dynamic>();
                int Count = 0;
                var cmd = new CommandDefinition(
                    procName,
                    parameters: p,
                    commandType: CommandType.StoredProcedure,
                    flags: CommandFlags.NoCache);
                using (var multi = await conn.QueryMultipleAsync(cmd))
                {
                    while (!multi.IsConsumed)
                    {
                        var item = multi.Read<dynamic>();
                        if (Count == 0)
                        {
                            if (item.Any())
                            {
                                dataResponse.ErrorCode = ((IDictionary<string, object>)item.FirstOrDefault()!)["Valuerr"]?.ToString() ?? "-2";
                                dataResponse.Message = ((IDictionary<string, object>)item.FirstOrDefault()!)["ErrDescription"]?.ToString() ?? "Not Found ErrorCode";
                            }
                            else
                            {
                                dataResponse.ErrorCode = "0";
                                dataResponse.Message = "Success, Not Found Data";
                            }
                            foreach (var i in item)
                            {
                                ((IDictionary<string, object>)i).Remove("Valuerr");
                                ((IDictionary<string, object>)i).Remove("ErrDescription");
                            }
                        }
                        Count++;
                        result.Add(item);
                    }
                }

                if (dataResponse.ErrorCode == "0" || result.Count != 0)
                {
                    if (result.Count == 1)
                    {
                        dataResponse.Result = result[0];
                    }
                    else
                    {
                        dataResponse.Result = result;
                    }
                }
            }
            catch (Exception ex)
            {
                dataResponse.ErrorCode = "-3";
                dataResponse.Message = ex.Message;
            }
            return dataResponse;
        }

        public static async Task<DataResponseEmbedded> GetDataResponseEmbedded(IDictionary<string, object> parameters, string _stringConnect, string _stringConnectConfig, string procName, object request)
        {
            DataResponseEmbedded dataResponse = new();
            try
            {
                using IDbConnection conn = new SqlConnection(_stringConnect);
                var p = new DynamicParameters();
                foreach (string key in parameters.Keys)
                {
                    p.Add(key, parameters[key]);
                }
                foreach (var item in request?.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>())
                {
                    var value = item.GetValue(request);

                    if (value == null)
                    {
                        if (item.Name.Contains("Extent", StringComparison.OrdinalIgnoreCase))
                        {
                            p.Add("@" + item.Name, "");
                        }
                        if (item.Name == "CmpnID")
                        {
                            p.Add("@" + item.Name, "-1");
                        }
                    }
                    else
                    {
                        p.Add("@" + item.Name, (Regex.IsMatch(item.Name, pattern1, RegexOptions.IgnoreCase) && !Regex.IsMatch(item.Name, pattern2, RegexOptions.IgnoreCase)) ? value.ToString().MD5Hash() : value);
                    }
                }
                LogActions(procName, p, _stringConnectConfig);
                var result = new List<dynamic>();
                int Count = 0;
                var ErrorCode = "0";
                var cmd = new CommandDefinition(
                    procName,
                    parameters: p,
                    commandType: CommandType.StoredProcedure,
                    flags: CommandFlags.NoCache);
                using (var multi = await conn.QueryMultipleAsync(cmd))
                {
                    while (!multi.IsConsumed)
                    {
                        var item = multi.Read<dynamic>();
                        if (Count == 0)
                        {
                            if (item.Any())
                            {
                                ErrorCode = ((IDictionary<string, object>)item.FirstOrDefault()!)["Valuerr"]?.ToString() ?? "-2";
                                dataResponse.Message = ErrorCode + "|" + ((IDictionary<string, object>)item.FirstOrDefault()!)["ErrDescription"]?.ToString() ?? "Not Found ErrorCode";
                            }
                            else
                            {
                                ErrorCode = "-1";
                                dataResponse.Message = ErrorCode + "|Not Found Data";
                            }

                            foreach (var i in item)
                            {
                                ((IDictionary<string, object>)i).Remove("Valuerr");
                                ((IDictionary<string, object>)i).Remove("ErrDescription");
                            }
                        }
                        Count++;
                        result.Add(item);
                    }
                }

                if (ErrorCode == "0" || result.Count != 0)
                {
                    if (result.Count == 1)
                    {
                        dataResponse.Result = result[0];
                    }
                    else
                    {
                        dataResponse.Result = result;
                    }
                }
            }
            catch (Exception ex)
            {
                dataResponse.Message = ex.Message;
            }
            return dataResponse;
        }

        public static void LogActions(string ProcName, DynamicParameters p, string _stringConnectConfig)
        {
            if (ProcName != "ExecCustomize")
            {
                IHttpContextAccessor accessor = (IHttpContextAccessor)StaticServiceProvider.Provider!.GetService(typeof(IHttpContextAccessor))!;
                string beforeLogSQL = "";
                foreach (var item in p.ParameterNames)
                {
                    if ((p as SqlMapper.IParameterLookup)?[item] is DataTable dataTable)
                    {
                        beforeLogSQL += $" declare @{item} as {dataTable.GetTypeName()} Insert into @{item}";
                        foreach (DataRow row in dataTable.Rows)
                        {
                            beforeLogSQL += " Select ";
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                string value = row[column] == System.DBNull.Value ? "''" : $"N'{row[column]}'";
                                beforeLogSQL += $"{value}, ";
                            }
                            beforeLogSQL = beforeLogSQL.Remove(beforeLogSQL.Length - 2);
                            if (row != dataTable.Rows[^1])
                            {
                                beforeLogSQL += " Union all";
                            }
                        }
                    }
                }

                string logSQL = string.Join(", ", from pn in p.ParameterNames select string.Format("@{0}={1}", pn, (p as SqlMapper.IParameterLookup)?[pn] is DataTable table ? "@" + table.GetTypeName() : $"'{(p as SqlMapper.IParameterLookup)?[pn]}'"));
                DynamicParameters parameters = new();
                parameters.Add("@LogAction", ProcName);
                if (beforeLogSQL?.Length == 0)
                {
                    parameters.Add("@LogSQL", $"EXEC {ProcName} {logSQL}");
                }
                else
                {
                    parameters.Add("@LogSQL", $"{beforeLogSQL} EXEC {ProcName} {logSQL}");
                }
                parameters.Add("@UserID", 0);
                parameters.Add("@MAC", accessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "localhost");
                parameters.Add("@LogDescription", ProcName);
                parameters.Add("@SearchID", ProcName);
                using IDbConnection conn = new SqlConnection(_stringConnectConfig);
                conn.Execute("InsLogAction",
                        param: parameters,
                        commandType: CommandType.StoredProcedure);
            }
        }

        public static string GetFileExtension(string base64String)
        {
            var data = base64String[..5];

            return data.ToUpper() switch
            {
                "PHN2Z" => "svg",
                "IVBOR" => "png",
                "/9J/4" => "jpg",
                "AAAAF" => "mp4",
                "JVBER" => "pdf",
                "AAABA" => "ico",
                "UMFYI" => "rar",
                "E1XYD" => "rtf",
                "U1PKC" => "txt",
                "MQOWM" or "77U/M" => "srt",
                _ => string.Empty,
            };
        }

        public static void MasterImport(IFormFile file, string path, string fileName, string importType)
        {
            try
            {
                path = $@"{path}import\save";
                string byDate = DateTime.Now.Date.ToString("yyyy/MM/dd");
                string dirPath = Path.Combine(path, byDate);
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

                string fullPath = Path.Combine(dirPath, fileName);

                Stream FileStream = file.OpenReadStream();
                byte[] bytes = ReadToEnd(FileStream);

                using (FileStream FileWrite = new(fullPath, FileMode.Create))
                {
                    FileWrite.Write(bytes, 0, bytes.Length);
                    FileWrite.Flush();
                }

                IExcelDataReader reader = null;
                if (file.FileName.EndsWith(".xls"))
                    reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                else if (file.FileName.EndsWith(".xlsx"))
                    reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                DataSet dsexcelRecords = reader.AsDataSet();
                reader.Close();

                string colName = "";
                string ListCol = "";
                DataTable DataImport = dsexcelRecords.Tables[0];

                bool Flagcheck = false;
                for (int i = 0; i < DataImport.Columns.Count; i++)
                {
                    if (DataImport.Columns[i].DataType.Name == "Object")
                    {
                        Flagcheck = true;
                    }
                    DataColumn dataColumn = DataImport.Columns[i];
                    colName = $"[{DataImport.Rows[0][dataColumn]}]";
                    colName += dataColumn.DataType.Name.ToUpper() switch
                    {
                        "STRING" => " [NVARCHAR](500) NULL,",
                        "DATE" => " [DATE] NULL,",
                        "DATETIME" => " [DATETIME] NULL,",
                        "DECIMAL" or "DOUBLE" => " [DECIMAL](18,3) NULL,",
                        "INT16" or "INT32" or "INT64" => " [INT] NULL,",
                        _ => " [NVARCHAR](500) NULL,",
                    };
                    ListCol += colName;
                }
                ListCol = ListCol[0..^1];

                DataImport.Rows.RemoveAt(0);

                if (Flagcheck)
                {
                    DataTable dtCloned = DataImport.Clone();
                    for (int fix = 0; fix < dtCloned.Columns.Count - 1; fix++)
                    {
                        dtCloned.Columns[fix].DataType = typeof(string);
                    }
                    foreach (DataRow row in DataImport.Rows)
                    {
                        dtCloned.ImportRow(row);
                    }
                    DataImport = dtCloned;
                }

                using IDbConnection conn = new SqlConnection(Global.ListDB?.Find(item => item.DBType == "CLL")?.DBString);
                string typeName = $"Data{importType}Imports".Replace(" ", "");
                conn.Execute($"DROP PROC IF EXISTS Insert_{typeName}");
                conn.Execute($"DROP TYPE IF EXISTS {typeName}");
                conn.Execute($"DROP TABLE IF EXISTS {typeName}");
                conn.Execute($"CREATE TYPE {typeName} AS TABLE ({ListCol})");
                conn.Execute($"CREATE PROCEDURE Insert_{typeName} @myTableType {typeName} READONLY AS BEGIN SELECT * INTO {typeName} FROM @myTableType END");

                var p = new DynamicParameters();
                p.Add("@myTableType", DataImport);
                conn.Query($"Insert_{typeName}", param: p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string NextAvailableFilename(string path)
        {
            if (!File.Exists(path))
            {
                return path;
            }

            if (Path.HasExtension(path))
            {
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path), StringComparison.Ordinal), NumberPattern));
            }

            return GetNextFilename(path + NumberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);

            if (!File.Exists(tmp))
            {
                return tmp;
            }

            int min = 1, max = 2;

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                {
                    min = pivot;
                }
                else
                {
                    max = pivot;
                }
            }

            return string.Format(pattern, max);
        }

        public static byte[] ReadToEnd(Stream stream)
        {
            MemoryStream ms = new();
            stream.CopyTo(ms);
            return ms.ToArray();
        }

        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", string.Empty, RegexOptions.Compiled);
        }

        private static byte[] ResizeIfLargerThan(this string data, int maxWidth, int maxHeight)
        {
            try
            {
                byte[] bytes = FromBase64String(data);
                MemoryStream ms = new(bytes, 0, bytes.Length);
                Image image = Image.FromStream(ms, true);
                var imageSize = image.Size.ResizeKeepAspect(maxWidth, maxHeight);
                Bitmap b = new(imageSize.Width, imageSize.Height);
                Graphics g = Graphics.FromImage(b);
                g.DrawImage(image, 0, 0, imageSize.Width, imageSize.Height);
                g.Dispose();
                image = b;
                using MemoryStream ms1 = new();
                image.Save(ms1, ImageFormat.Jpeg);
                return ms1.ToArray();
            }
            catch
            {
                return null;
            }
        }

        private static Size ResizeKeepAspect(this Size src, int maxWidth, int maxHeight, bool enlarge = false)
        {
            maxWidth = enlarge ? maxWidth : Math.Min(maxWidth, src.Width);
            maxHeight = enlarge ? maxHeight : Math.Min(maxHeight, src.Height);
            decimal rnd = Math.Min(maxWidth / (decimal)src.Width, maxHeight / (decimal)src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }

        public enum UploadType
        {
            CompressImage,
            NoCompressImage
        }

        public static string UploadBase64Image(string base64, string folder, string name, string extention = "jpg", UploadType uploadType = UploadType.CompressImage)
        {
            try
            {
                if (base64 is null)
                {
                    return "base null";
                }
                string strPathAvatar = Path.Combine(folder);
                Directory.CreateDirectory(strPathAvatar);
                string fileNameAvatar = name + "." + extention;
                string filepathAvatar = strPathAvatar + "/" + fileNameAvatar;
                byte[] bytes = (extention == "svg" || uploadType == UploadType.NoCompressImage) ? FromBase64String(base64) : ResizeIfLargerThan(base64, 1024, 1280);
                if (bytes is not null)
                {
                    using FileStream imageFile = new(filepathAvatar, FileMode.Create);
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                    return "OK";
                }
                else
                {
                    return "Upload fail";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static bool CheckGoogleTranslate(string StrValue, string strValueExtention1)
        {
            if (strValueExtention1 == null || strValueExtention1 == "" || strValueExtention1 == "." || strValueExtention1 == "*" || strValueExtention1 == "1")
            {
                if (!string.IsNullOrEmpty(StrValue) && StrValue != "." && StrValue != "*" && StrValue != "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string UploadBase64ImageReturnPath(this string base64, string folder, string link, string name, string extention = "png", UploadType uploadType = UploadType.CompressImage)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string strPathAvatar = Path.Combine(folder);
                string filepathAvatar = NextAvailableFilename($"{strPathAvatar}/{name}.{extention}");
                byte[] bytes = uploadType == UploadType.CompressImage ? base64.ResizeIfLargerThan(1024, 1280) : FromBase64String(base64);
                FileStream imageFile = new(filepathAvatar, FileMode.Create);
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
                return $"{link}/{Path.GetFileName(filepathAvatar)}";
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public static string UploadFileImageReturnPath(IFormFile file, string folder, string link, string name, string extention = "jpg")
        {
            try
            {
                string strPathAvatar = Path.Combine(folder);
                string filepathAvatar = "";
                Directory.CreateDirectory(strPathAvatar);
                filepathAvatar = NextAvailableFilename($"{strPathAvatar}/{name}.{extention}");
                using FileStream imageFile = new(filepathAvatar, FileMode.Create);
                file.CopyTo(imageFile);
                return $"{link}/{Path.GetFileName(filepathAvatar)}";
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public static string UploadFileReturnFileName(IFormFile file, string folder)
        {
            try
            {
                static string RemoveSpecialCharacters(string input)
                {
                    // Dùng biểu thức chính quy (Regex) để loại bỏ ký tự đặc biệt
                    return Regex.Replace(input, "[^a-zA-Z0-9.-]", "");
                }
                // Sử dụng Regex để loại bỏ ký tự đặc biệt
                string resultString = RemoveSpecialCharacters(file.FileName);
                folder = folder.Replace(",", "");
                string strPathAvatar = Path.Combine(folder);
                string filepathAvatar = "";
                Directory.CreateDirectory(strPathAvatar);
                filepathAvatar = NextAvailableFilename($"{strPathAvatar}/{resultString}");
                using FileStream imageFile = new(filepathAvatar, FileMode.Create);
                file.CopyTo(imageFile);
                return $"{Path.GetFileName(filepathAvatar)}";
            }
            catch (Exception ex)
            {
                return ex.ToString()!;
            }
        }

        public static string UploadFileReturnLink(IFormFile file, string folder, string link)
        {
            try
            {
                string strPathAvatar = Path.Combine(folder);
                Directory.CreateDirectory(strPathAvatar);
                string filepathAvatar = NextAvailableFilename($"{strPathAvatar}/{file.FileName.RemoveSpecialCharacters()}");
                using FileStream copyToFile = new(filepathAvatar, FileMode.Create);
                file.CopyTo(copyToFile);
                return $"{link}{Path.GetFileName(filepathAvatar)}";
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public static List<string> UploadMultipleFile(List<IFormFile> files, string folder, string link)
        {
            try
            {
                string fileName = "";
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                return files.ConvertAll(file =>
                {
                    fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
                    using Stream fileStream = new FileStream(Path.Combine(folder, fileName), FileMode.Create);
                    file.CopyTo(fileStream);
                    return $"{link}/{fileName}";
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataTable ToDataTableNotNull<T>(this List<T> items)
        {
            DataTable dataTable = new(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null) ?? "";
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataTable ToDataTable_OneColumn<T>(this List<string> Details, string ClName = "StationID")
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(ClName);
            foreach (string Item in Details)
            {
                dataTable.Rows.Add(Item);
            }

            return dataTable;
        }

        public static bool CheckPublicKey(this string publickey)
        {
            if (string.IsNullOrEmpty(publickey))
            {
                return false;
            }
            else
            {
                TimeSpan howClose = ToDateTime(UTF8.GetString(FromBase64String(publickey)).Split('|')[1]) - DateTime.Now;
                if (Math.Abs(howClose.TotalMinutes) > 5)
                {
                    return false;
                }
            }
            return true;
        }

        public static async Task<IFormFile> CopyToIFormFile(this string url)
        {
            try
            {
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    Uri uri = new Uri(url);
                    string filename = uri.Segments.Last();
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                        response.EnsureSuccessStatusCode();
                        using (Stream stream = await response.Content.ReadAsStreamAsync())
                        {
                            MemoryStream memoryStream = new MemoryStream();
                            await stream.CopyToAsync(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            return new FormFile(memoryStream, 0, memoryStream.Length, filename.Split('.')[0], filename);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static bool IsBase64String(this string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return TryFromBase64String(base64, buffer, out _);
        }

        /// <summary>
        /// Copy from:
        /// 1. Excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //public static DataTable ExcelCopyToDataTable(this IFormFile input)
        //{
        //    DataTable output = new DataTable();
        //    IExcelDataReader reader = null;
        //    switch (Path.GetExtension(input.FileName))
        //    {
        //        case ".xls":
        //            reader = ExcelReaderFactory.CreateBinaryReader(input.OpenReadStream());
        //            output = reader.AsDataSet().Tables[0];
        //            break;

        //        case ".xlsx":
        //            reader = ExcelReaderFactory.CreateOpenXmlReader(input.OpenReadStream());
        //            output = reader.AsDataSet().Tables[0];
        //            break;

        //        default:
        //            output = null;
        //            break;
        //    }
        //    reader.Close();
        //    // Remove row title vietnam
        //    output.Rows.RemoveAt(0);
        //    // Change table column name to title english
        //    for (int i = 0; i < output.Columns.Count; i++)
        //    {
        //        output.Columns[i].DefaultValue = string.Empty;
        //        // output.Columns[i].ColumnName = output.Rows[0][i].ToString();
        //        output.Columns[i].ColumnName = System.Convert.ToString(output.Rows[0][i], CultureInfo.InvariantCulture);
        //    }

        //    //foreach (DataRow row in output.Rows)
        //    //{
        //    //    foreach (DataColumn column in output.Columns)
        //    //    {
        //    //        if (row[column] == System.DBNull.Value)
        //    //        {
        //    //            row[column] = "";
        //    //        }
        //    //    }
        //    //}
        //    // Change row title english
        //    //output.Rows.RemoveAt(0);
        //    return output;
        //}
        public static DataTable ExcelCopyToDataTable(this IFormFile input)
        {
            var oldCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                DataTable output = new DataTable();
                IExcelDataReader reader = null;

                switch (Path.GetExtension(input.FileName))
                {
                    case ".xls":
                        reader = ExcelReaderFactory.CreateBinaryReader(input.OpenReadStream());
                        break;
                    case ".xlsx":
                        reader = ExcelReaderFactory.CreateOpenXmlReader(input.OpenReadStream());
                        break;
                    default:
                        return null;
                }

                output = reader.AsDataSet().Tables[0];
                reader.Close();

                output.Rows.RemoveAt(0);

                for (int i = 0; i < output.Columns.Count; i++)
                {
                    output.Columns[i].DefaultValue = string.Empty;
                    output.Columns[i].ColumnName =
                        System.Convert.ToString(output.Rows[0][i], CultureInfo.InvariantCulture);
                }

                return output;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = oldCulture;
            }
        }
        public static DataTable FileToDataTable(this IFormFile input)
        {
            IExcelDataReader reader = Path.GetExtension(input.FileName) switch
            {
                ".xls" => ExcelReaderFactory.CreateBinaryReader(input.OpenReadStream()),
                ".xlsx" => ExcelReaderFactory.CreateOpenXmlReader(input.OpenReadStream()),
                _ => null,
            };
            DataTable output = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true,
                    ReadHeaderRow = (rowReader) => rowReader.Read(),
                    FilterRow = (rowReader) => rowReader.Depth >= 1
                }
            }).Tables[0];
            reader.Close();
            return output;
        }

        public static DataTable ExeclETC(this IFormFile input)
        {
            DataTable output = new DataTable();
            IExcelDataReader reader = null;
            switch (Path.GetExtension(input.FileName))
            {
                case ".xls":
                    reader = ExcelReaderFactory.CreateBinaryReader(input.OpenReadStream());
                    output = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            FilterColumn = (rowReader, columnIndex) => new int[] { 3, 4, 5, 9, 10 }.Contains(columnIndex),
                            FilterRow = (rowReader) => rowReader.Depth >= 1
                        }
                    }).Tables[0];
                    break;

                case ".xlsx":
                    reader = ExcelReaderFactory.CreateOpenXmlReader(input.OpenReadStream());
                    output = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            FilterColumn = (rowReader, columnIndex) => new int[] { 3, 4, 5, 9, 10 }.Contains(columnIndex),
                            FilterRow = (rowReader) => rowReader.Depth >= 1
                        }
                    }).Tables[0];
                    break;

                default:
                    output = null;
                    break;
            }
            reader.Close();
            output.Columns[0].ColumnName = "ETCDate";
            output.Columns[1].ColumnName = "Note";
            output.Columns[2].ColumnName = "LicensePlate";
            output.Columns[3].ColumnName = "Cost";
            output.Columns[4].ColumnName = "ChargingStation";
            return output;
        }

        public static async Task<object> Translate(this object source)
        {
            GoogleTranslateService translate = (GoogleTranslateService)StaticServiceProvider.Provider!.GetService(typeof(GoogleTranslateService))!;
            return await translate.TranslateObject(source);
        }

        public static void LoopMonths(string startYearMonth, string endYearMonth, Func<DateTime, Task> action)
        {
            string format = "yyyy-MM-dd";
            DateTime startDT = DateTime.ParseExact(startYearMonth, format, CultureInfo.InvariantCulture);
            DateTime endDT = DateTime.ParseExact(endYearMonth, format, CultureInfo.InvariantCulture);
            while (startDT <= endDT)
            {
                action(startDT);
                startDT = startDT.AddMonths(1);
            }
        }
    }
}