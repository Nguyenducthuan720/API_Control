using ExcelDataReader;
using System.Text.Json;
using System.Text.RegularExpressions;
using APISmartCity.GoogleTranslateServices;

namespace APISmartCity.Lib.Function
{
    public class ExcelImportService
    {
        internal readonly object TranslateService;
        private readonly GoogleTranslateService _translate;

        public ExcelImportService(GoogleTranslateService translate)
        {
            _translate = translate;
        }

        public async Task<(string? Json, string? DataTypeJson, string? RequiredJson, string? Row1Json, string ErrorMessage)> ParseExcelAsync(Stream excelStream)
        {
            try
            {
                // Đọc Sheet 1 từ file Excel
                using var reader = ExcelReaderFactory.CreateReader(excelStream, new ExcelReaderConfiguration { LeaveOpen = false });
                var dataset = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = false }
                });

                if (dataset.Tables.Count == 0)
                    return (null, null, null, null, "File Excel không chứa sheet nào!");

                var table = dataset.Tables[0]; // Chỉ lấy Sheet 1
                using var dataReader = table.CreateDataReader();

                // Đọc dòng 1: Xác định cột bắt buộc (có dấu *) và lưu dữ liệu dòng 1
                if (!dataReader.Read())
                    return (null, null, null, null, "Sheet 1 không chứa dữ liệu!");

                var row1Data = new List<string>(); // Lưu dữ liệu dòng 1
                var requiredIndexes = new List<int>();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    string value = dataReader.GetValue(i)?.ToString()?.Trim() ?? "";
                    row1Data.Add(value); // Lưu giá trị dòng 1
                    if (value.Contains("*"))
                        requiredIndexes.Add(i);
                }

                // Đọc dòng 2: Schema (tên cột và kiểu dữ liệu)
                if (!dataReader.Read())
                    return (null, null, null, null, "Không tìm thấy schema hợp lệ!");

                var schema = new List<(string ColumnName, string DataType)>();
                var columnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var validColumns = new List<int>(); // Store indices of valid columns
                var row1ValidData = new List<string>(); // Dữ liệu dòng 1 tương ứng với cột hợp lệ
                int dimensionCount = 0;

                var typeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "nvarchar", "NVARCHAR(255)" },
                    { "int", "INT" },
                    { "decimal", "DECIMAL(18,2)" },
                    { "datetime", "DATETIME" },
                    { "date", "DATE" }
                };

                // Regex để kiểm tra định dạng hợp lệ của nvarchar(n)
                var nvarcharRegex = new Regex(@"^nvarchar\(\d+\)$", RegexOptions.IgnoreCase);

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    string raw = dataReader.GetValue(i)?.ToString()?.Trim() ?? "";
                    if (string.IsNullOrEmpty(raw)) // Skip if row 2 is empty or ""
                        continue;

                    var match = Regex.Match(raw, @"^(?<name>.+?)(?:\((?<type>.+?)\))?$");
                    if (!match.Success)
                        continue;

                    string name = match.Groups["name"].Value.Trim();
                    string type = match.Groups["type"].Success ? match.Groups["type"].Value.Trim() : "NVARCHAR(255)";

                    // Xử lý cột Dimension
                    if (name.Equals("Dimension", StringComparison.OrdinalIgnoreCase))
                    {
                        dimensionCount++;
                        name = $"Dimension{dimensionCount}";
                    }

                    // Kiểm tra tên cột trùng lặp
                    if (!columnNames.Add(name))
                        return (null, null, null, null, $"Tên cột trùng lặp: {name}");

                    // Chuẩn hóa kiểu dữ liệu
                    if (type.StartsWith("nvarchar", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!nvarcharRegex.IsMatch(type))
                        {
                            if (Regex.IsMatch(type, @"^nvarchar\(\d+$", RegexOptions.IgnoreCase))
                            {
                                type = type + ")";
                            }
                            else
                            {
                                type = "NVARCHAR(255)";
                            }
                        }
                    }
                    else
                    {
                        type = typeMap.Any(t => t.Key.Equals(type, StringComparison.OrdinalIgnoreCase)) ? typeMap.First(t => type.Equals(t.Key, StringComparison.OrdinalIgnoreCase)).Value : "NVARCHAR(255)";
                    }

                    schema.Add((name, type));
                    validColumns.Add(i); // Track valid column index
                    row1ValidData.Add(row1Data[i]); // Lưu dữ liệu dòng 1 tương ứng
                }

                if (schema.Count == 0)
                    return (null, null, null, null, "Không tìm thấy schema hợp lệ!");

                // Danh sách cột bắt buộc
                var requiredColumns = requiredIndexes
                    .Where(i => validColumns.Contains(i)) // Chỉ lấy các cột bắt buộc hợp lệ
                    .Select(i => schema[validColumns.IndexOf(i)].ColumnName)
                    .ToList();

                // Đọc dữ liệu
                var allRows = new List<Dictionary<string, object>>(dataReader.RecordsAffected > 0 ? dataReader.RecordsAffected : 100);
                while (dataReader.Read())
                {
                    var rowDict = new Dictionary<string, object>(schema.Count);
                    for (int j = 0; j < validColumns.Count; j++)
                    {
                        int i = validColumns[j]; // Use valid column index
                        string name = schema[j].ColumnName;
                        string type = schema[j].DataType;
                        var rawValue = dataReader.GetValue(i)?.ToString()?.Trim() ?? "";

                        object parsedValue = type switch
                        {
                            var t when t.StartsWith("INT") => int.TryParse(rawValue, out var intVal) ? intVal : 0,
                            var t when t.StartsWith("DECIMAL") => decimal.TryParse(rawValue, out var decVal) ? decVal : 0m,
                            var t when t.StartsWith("DATETIME") => DateTime.TryParse(rawValue, out var dtVal) ? dtVal : DateTime.Now,
                            _ => rawValue
                        };

                        rowDict[name] = parsedValue;
                    }
                    allRows.Add(rowDict);
                }

                if (allRows.Count == 0)
                    return (null, null, null, null, "Không có dữ liệu để import");

                // Serialize dữ liệu
                var schemaList = schema.Select(s => new { s.ColumnName, s.DataType }).ToList();
                return (
                    JsonSerializer.Serialize(allRows, new JsonSerializerOptions { WriteIndented = false }),
                    JsonSerializer.Serialize(schemaList, new JsonSerializerOptions { WriteIndented = false }),
                    JsonSerializer.Serialize(requiredColumns, new JsonSerializerOptions { WriteIndented = false }),
                    JsonSerializer.Serialize(row1ValidData, new JsonSerializerOptions { WriteIndented = false }), // Trả về dữ liệu dòng 1
                    ""
                );
            }
            catch (Exception ex)
            {
                return (null, null, null, null, $"Lỗi xử lý Excel: {ex.Message}");
            }
        }

        public async Task<(string? Json, string? DataTypeJson, string? RequiredJson, string? Row1Json, string ErrorMessage)> ParseExcelAsyncReplaceType(Stream excelStream)
        {
            try
            {
                // Đọc Sheet 1 từ file Excel
                using var reader = ExcelReaderFactory.CreateReader(excelStream, new ExcelReaderConfiguration { LeaveOpen = false });
                var dataset = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = false }
                });

                if (dataset.Tables.Count == 0)
                    return (null, null, null, null, "File Excel không chứa sheet nào!");

                var table = dataset.Tables[0]; // Chỉ lấy Sheet 1
                using var dataReader = table.CreateDataReader();

                // Đọc dòng 1: Xác định cột bắt buộc (có dấu *) và lưu dữ liệu dòng 1
                if (!dataReader.Read())
                    return (null, null, null, null, "Sheet 1 không chứa dữ liệu!");

                var row1Data = new List<string>(); // Lưu dữ liệu dòng 1
                var requiredIndexes = new List<int>();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    string value = dataReader.GetValue(i)?.ToString()?.Trim() ?? "";
                    row1Data.Add(value); // Lưu giá trị dòng 1
                    if (value.Contains("*"))
                        requiredIndexes.Add(i);
                }

                // Đọc dòng 2: Schema (tên cột và kiểu dữ liệu)
                if (!dataReader.Read())
                    return (null, null, null, null, "Không tìm thấy schema hợp lệ!");

                var schema = new List<(string ColumnName, string DataType)>();
                var columnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var validColumns = new List<int>(); // Store indices of valid columns
                var row1ValidData = new List<string>(); // Dữ liệu dòng 1 tương ứng với cột hợp lệ
                int dimensionCount = 0;

                var typeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "nvarchar", "NVARCHAR(255)" },
                    { "int", "INT" },
                    { "decimal", "DECIMAL(18,2)" },
                    { "datetime", "DATETIME" },
                    { "date", "DATE" }
                };

                // Regex để kiểm tra định dạng hợp lệ của nvarchar(n)
                var nvarcharRegex = new Regex(@"^nvarchar\(\d+\)$", RegexOptions.IgnoreCase);

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    string raw = dataReader.GetValue(i)?.ToString().Replace("\n", " ").Replace("\r", " ")?.Trim() ?? "";
                    if (string.IsNullOrEmpty(raw)) // Skip if row 2 is empty or ""
                        continue;

                    var match = Regex.Match(raw, @"^(?<name>.+?)(?:\((?<type>.+?)\))?$");
                    if (!match.Success)
                        continue;

                    string name = match.Groups["name"].Value.Split(" ")[0].Trim().Split(@"\r\n|\r|\n")[0].Trim();
                    string type = match.Groups["type"].Success ? match.Groups["type"].Value.Trim() : "NVARCHAR(255)";

                    // Xử lý cột Dimension
                    if (name.Equals("Dimension", StringComparison.OrdinalIgnoreCase))
                    {
                        dimensionCount++;
                        name = $"Dimension{dimensionCount}";
                    }

                    // Kiểm tra tên cột trùng lặp
                    if (!columnNames.Add(name))
                        return (null, null, null, null, $"Tên cột trùng lặp: {name}");

                    // Chuẩn hóa kiểu dữ liệu
                    if (type.StartsWith("nvarchar", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!nvarcharRegex.IsMatch(type))
                        {
                            if (Regex.IsMatch(type, @"^nvarchar\(\d+$", RegexOptions.IgnoreCase))
                            {
                                type = type + ")";
                            }
                            else
                            {
                                type = "NVARCHAR(255)";
                            }
                        }
                    }
                    else
                    {
                        type = typeMap.Any(t => t.Key.Equals(type, StringComparison.OrdinalIgnoreCase)) ? typeMap.First(t => type.Equals(t.Key, StringComparison.OrdinalIgnoreCase)).Value : "NVARCHAR(255)";
                    }

                    schema.Add((name, type));
                    validColumns.Add(i); // Track valid column index
                    row1ValidData.Add(row1Data[i]); // Lưu dữ liệu dòng 1 tương ứng
                }

                if (schema.Count == 0)
                    return (null, null, null, null, "Không tìm thấy schema hợp lệ!");

                // Danh sách cột bắt buộc
                var requiredColumns = requiredIndexes
                    .Where(i => validColumns.Contains(i)) // Chỉ lấy các cột bắt buộc hợp lệ
                    .Select(i => schema[validColumns.IndexOf(i)].ColumnName)
                    .ToList();

                // Đọc dữ liệu
                var allRows = new List<Dictionary<string, object>>(dataReader.RecordsAffected > 0 ? dataReader.RecordsAffected : 100);
                while (dataReader.Read())
                {
                    var rowDict = new Dictionary<string, object>(schema.Count);
                    for (int j = 0; j < validColumns.Count; j++)
                    {
                        int i = validColumns[j]; // Use valid column index
                        string name = schema[j].ColumnName;
                        string type = schema[j].DataType;
                        var rawValue = dataReader.GetValue(i)?.ToString()?.Trim() ?? "";

                        object parsedValue = type switch
                        {
                            var t when t.StartsWith("INT") => int.TryParse(rawValue, out var intVal) ? intVal : 0,
                            var t when t.StartsWith("DECIMAL") => decimal.TryParse(rawValue, out var decVal) ? decVal : 0m,
                            var t when t.StartsWith("DATETIME") => DateTime.TryParse(rawValue, out var dtVal) ? dtVal : DateTime.Now,
                            _ => rawValue
                        };

                        rowDict[name] = parsedValue;
                    }
                    allRows.Add(rowDict);
                }

                if (allRows.Count == 0)
                    return (null, null, null, null, "Không có dữ liệu để import");

                // Serialize dữ liệu
                var schemaList = schema.Select(s => new { s.ColumnName, s.DataType }).ToList();
                return (
                    JsonSerializer.Serialize(allRows, new JsonSerializerOptions { WriteIndented = false }),
                    JsonSerializer.Serialize(schemaList, new JsonSerializerOptions { WriteIndented = false }),
                    JsonSerializer.Serialize(requiredColumns, new JsonSerializerOptions { WriteIndented = false }),
                    JsonSerializer.Serialize(row1ValidData, new JsonSerializerOptions { WriteIndented = false }), // Trả về dữ liệu dòng 1
                    ""
                );
            }
            catch (Exception ex)
            {
                return (null, null, null, null, $"Lỗi xử lý Excel: {ex.Message}");
            }
        }
    }
}