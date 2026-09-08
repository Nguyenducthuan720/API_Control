using APISmartCity.Services;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using GemBox.Spreadsheet;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text.Json;

namespace DMS.Lib.Files
{
    public static class FileExcelAPI
    {
        public static string ExportTemplateToPdf(
            string templatePath,
            string outputFolder,
            string outputFileName,
            string jsonReplacements,
            string signType,
            string tablejson,
            string userFullName,
            ExcelToPdfService excelToPdfService)
        {
            var savedExcelPath = ExportTemplateToExcel(templatePath, outputFolder, outputFileName,
                jsonReplacements, signType, tablejson, userFullName);
            var savedPdfPath = Path.Combine(outputFolder, $"{outputFileName}.pdf");
            var tempXlsxPath = Path.Combine(outputFolder, $"{outputFileName}_temp.xlsx");

            // === Convert Excel sang PDF ===
            try
            {
                bool useGemBox = true;
                try
                {
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                    var workbook = ExcelFile.Load(savedExcelPath);
                    workbook.Save(savedPdfPath);
                }
                catch (Exception ex) //when (ex.Message.Contains("Free version limitation has been exceeded"))
                {
                    useGemBox = false;
                }

                if (!useGemBox)
                {
                    using var processedStream = new FileStream(savedExcelPath, FileMode.Open, FileAccess.Read);
                    using var pdfStream = excelToPdfService.ConvertXlsxToPdfAsync(processedStream).Result;
                    using (var fileStream = new FileStream(savedPdfPath, FileMode.Create, FileAccess.Write))
                    {
                        pdfStream.CopyTo(fileStream);
                    }
                }

                // Xóa file tạm nếu tồn tại
                if (File.Exists(tempXlsxPath) && tempXlsxPath != templatePath)
                    File.Delete(tempXlsxPath);

                return savedPdfPath;
            }
            catch (Exception ex)
            {
                return savedExcelPath;
            }
        }

        public static string ExportTemplateToExcel(
            string templatePath, string outputFolder, string outputFileName,
            string jsonReplacements, string signType, string tablejson, string userFullName,
            bool clearUnresolvedPlaceholders = false, bool preserveUnsignedSignatures = false,
            bool preserveMissingValues = false)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Không tìm thấy file template: {templatePath}");

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string fileExtension = Path.GetExtension(templatePath)?.ToLower();
            string tempXlsxPath = Path.Combine(outputFolder, $"{outputFileName}_temp.xlsx");
            string savedExcelPath = Path.Combine(outputFolder, $"{outputFileName}.xlsx");
            string savedPngPath = Path.Combine(outputFolder, $"{outputFileName}.png");

            var replacements = JsonSerializer.Deserialize<Dictionary<string, object>>(
                       string.IsNullOrWhiteSpace(jsonReplacements) ? "{}" : jsonReplacements)
                   ?? new Dictionary<string, object>();
            File.Copy(templatePath, tempXlsxPath, true);
            try { File.Delete(tempXlsxPath + ":Zone.Identifier"); } catch { }

            RewriteExcelByOpenXml(tempXlsxPath);
            //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            //var wbGem = ExcelFile.Load(tempClean);
            //wbGem.Save(tempClean);   // chỉ rewrite temp
            //wbGem = null;
            using (var fs = new FileStream(tempXlsxPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var wb = new XLWorkbook(tempXlsxPath))
            {
                foreach (var ws in wb.Worksheets)
                {
                    // One common 3:1 box, constrained by the smallest signature slot.
                    var signatureSlots = ws.CellsUsed(c => !c.HasFormula &&
                        c.GetString().Contains("@SignLink_", StringComparison.OrdinalIgnoreCase))
                        .Select(c => c.MergedRange() ?? c.AsRange()).ToList();
                    var signatureWidth = signatureSlots.Count == 0 ? 180d :
                        Math.Min(180d, signatureSlots.Min(r => Math.Min(
                            GetRangeWidthInPixels(ws, r) * .9,
                            GetRangeHeightInPixels(ws, r) * .9 * 3)));
                    foreach (var kv in replacements)
                    {
                        string key = kv.Key;
                        //string val = kv.Value?.Trim() ?? "";
                        string val = kv.Value?.ToString()?.Trim() ?? "";
                        if (preserveMissingValues && string.IsNullOrWhiteSpace(val))
                            continue;
                        if (preserveUnsignedSignatures && string.IsNullOrWhiteSpace(val) &&
                            (key.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase) ||
                             key.StartsWith("@SignNote_", StringComparison.OrdinalIgnoreCase)))
                            continue;

                        // === Xử lý chữ ký ===
                        if (key.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
                        {
                            string imgPath = val;
                            string ext = Path.GetExtension(val)?.ToLower();
                            //int signIndex = 0; Bổ sung nếu cần xử lý chèn nhiều chữ ký cùng loại

                            if (preserveUnsignedSignatures &&
                                (string.IsNullOrWhiteSpace(val) || val.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase)))
                                continue;

                            // Link có dữ liệu nhưng không đọc được ảnh là lỗi, không phải chưa ký.
                            if (preserveUnsignedSignatures && !File.Exists(imgPath))
                                throw new FileNotFoundException($"Không đọc được ảnh chữ ký {key} do procedure trả về.", imgPath);

                            // Nếu là SVG thì chuyển sang PNG
                            if (ext == ".svg")
                            {
                                var replacementsSvg = new Dictionary<string, string>
                                {
                                    ["@UserName"] = userFullName,
                                    ["@NgayKy"] = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")
                                };
                                FileSVG.ReplaceAndConvertSvgToPng(val, savedPngPath, replacementsSvg, 600, 200);
                                imgPath = savedPngPath;
                            }

                            if (!File.Exists(imgPath))
                                continue;

                            var matchedCells = ws.CellsUsed(c =>
                                                !c.HasFormula &&
                                                !c.Value.IsBlank &&
                                                (preserveUnsignedSignatures
                                                    ? Regex.IsMatch(c.GetString(), Regex.Escape(key) + @"(?![A-Za-z0-9_])", RegexOptions.IgnoreCase)
                                                    : c.Value.ToString().Contains(key, StringComparison.OrdinalIgnoreCase)))
                                                .ToList();

                            // === Tìm ô chứa placeholder ===
                            foreach (var cell in matchedCells)
                            {

                                cell.Value = "";
                                var range = cell.MergedRange() ?? cell.AsRange();

                                // === Tính kích thước vùng (pixel) ===
                                double cellWidthPx = GetRangeWidthInPixels(ws, range);
                                double cellHeightPx = GetRangeHeightInPixels(ws, range);

                                using (var img = Image.Load(imgPath))
                                using (var ms = new MemoryStream())
                                {
                                    // === Scale ảnh ===
                                    double scale = Math.Min(cellWidthPx / img.Width, cellHeightPx / img.Height) * 0.9;

                                    // Đảm bảo kích thước tối thiểu là 1px tránh crash SixLabors/ClosedXML khi scale
                                    int newWidth = Math.Max(1, (int)(img.Width * scale));
                                    int newHeight = Math.Max(1, (int)(img.Height * scale));

                                    if (preserveUnsignedSignatures)
                                    {
                                        newWidth = Math.Max(1, (int)signatureWidth);
                                        newHeight = Math.Max(1, (int)(signatureWidth / 3));
                                        img.Mutate(x => x.Resize(new ResizeOptions
                                        {
                                            Size = new Size(newWidth, newHeight),
                                            Mode = ResizeMode.Pad,
                                            PadColor = Color.Transparent
                                        }));
                                    }
                                    else
                                        img.Mutate(x => x.Resize(newWidth, newHeight));
                                    img.SaveAsPng(ms);
                                    ms.Seek(0, SeekOrigin.Begin);

                                    var picName = Guid.NewGuid().ToString("N").Substring(0, 30);

                                    var picture = ws.AddPicture(ms, XLPictureFormat.Png, picName);

                                    // === Căn giữa ngang + dọc ===
                                    var topLeft = range.FirstCell();
                                    int offsetX = Math.Max(0, (int)((cellWidthPx - newWidth) / 2));
                                    int offsetY = Math.Max(0, (int)((cellHeightPx - newHeight) / 2));

                                    picture.MoveTo(topLeft, offsetX, offsetY);
                                }
                            }
                            //if (ext == ".svg" && File.Exists(savedPngPath))
                            //{
                            //    try { File.Delete(savedPngPath); } catch { }
                            //}
                        }
                        else
                        {
                            // === Xử lý @SignName (ẩn nếu DF) ===
                            if (key.StartsWith("@SignName_", StringComparison.OrdinalIgnoreCase) &&
                                signType == "DF" && !preserveUnsignedSignatures)
                            {
                                val = "";
                            }

                            // === Replace text ===
                            foreach (var cell in ws.CellsUsed(c =>
                                        !c.HasFormula &&
                                        !c.Value.IsBlank &&
                                        c.Value.ToString().Contains(key, StringComparison.OrdinalIgnoreCase)))
                            {
                                string oldVal = cell.GetString();
                                cell.Value = preserveMissingValues
                                    ? Regex.Replace(oldVal, Regex.Escape(key) + @"(?![A-Za-z0-9_])",
                                        _ => val, RegexOptions.IgnoreCase)
                                    : oldVal.Replace(key, val, StringComparison.OrdinalIgnoreCase);
                            }
                        }
                    }
                }
                //foreach (var ws in wb.Worksheets)
                //{
                //    foreach (var cell in ws.CellsUsed(c => c.HasFormula))
                //    {
                //        try
                //        {
                //            var displayedValue = cell.GetFormattedString();
                //            if (!string.IsNullOrWhiteSpace(displayedValue))
                //                cell.SetValue(displayedValue);
                //        }
                //        catch { }
                //    }
                //}
               
                foreach (var ws in wb.Worksheets)
                    if (ws.Protection.IsProtected)
                        ws.Protection.Unprotect();
                InsertTableFromJson(wb, tablejson);
                foreach (var ws in wb.Worksheets) RemoveCheckRows(ws);
                if (clearUnresolvedPlaceholders)
                    ClearUnresolvedPlaceholders(wb, preserveUnsignedSignatures);
                foreach (var ws in wb.Worksheets)
                {
                    foreach (var cell in ws.CellsUsed(c => c.HasFormula))
                    {
                        var formula = cell.FormulaA1?.ToUpper() ?? "";

                        // 👉 chỉ xử lý công thức SUM bạn cần
                        if (formula.Contains("SUM(") && formula.Contains("INDEX"))
                        {
                            try
                            {
                                // Bắt buộc recalc
                                ws.Workbook.RecalculateAllFormulas();

                                // Lấy value sau khi tính
                                var val = cell.Value;

                                // Cache lại value (optional)
                                cell.Value = val;
                            }
                            catch { }
                        }
                        var displayedValue = cell.GetFormattedString();
                        if (!string.IsNullOrWhiteSpace(displayedValue))
                            cell.SetValue(displayedValue);
                    }
                }
                wb.SaveAs(savedExcelPath);
                wb.Dispose();
            }
                

            if (File.Exists(tempXlsxPath) && tempXlsxPath != templatePath)
                File.Delete(tempXlsxPath);
            return savedExcelPath;
        }
        private static void ClearUnresolvedPlaceholders(XLWorkbook workbook, bool preserveSignatures)
        {
            const string pattern = @"(?<!\w)@[A-Za-z_][A-Za-z0-9_]*(?:%)?";
            foreach (var worksheet in workbook.Worksheets)
            {
                foreach (var cell in worksheet.CellsUsed(c => !c.HasFormula && !c.Value.IsBlank))
                {
                    var current = cell.GetString();
                    var cleaned = Regex.Replace(current, pattern, match =>
                        preserveSignatures && Regex.IsMatch(match.Value,
                            @"^@Sign(?:Link|Note)_C(?:[1-9]|[1-9][0-9])$", RegexOptions.IgnoreCase)
                            ? match.Value : string.Empty);
                    if (!string.Equals(current, cleaned, StringComparison.Ordinal))
                        cell.Value = cleaned;
                }
            }
        }

        // === Tính tổng chiều rộng của vùng (pixel) ===
        private static double GetRangeWidthInPixels(IXLWorksheet ws, IXLRange range)
        {
            double totalWidth = 0;
            foreach (var col in range.Columns())
            {
                var colIndex = col.ColumnNumber();
                double colWidth = ws.Column(colIndex).Width;
                totalWidth += ColumnWidthToPixels(colWidth);
            }
            return totalWidth;
        }

        // === Tính tổng chiều cao của vùng (pixel) ===
        private static double GetRangeHeightInPixels(IXLWorksheet ws, IXLRange range)
        {
            double totalHeight = 0;
            foreach (var row in range.Rows())
            {
                var rowIndex = row.RowNumber();
                double rowHeight = ws.Row(rowIndex).Height;
                totalHeight += RowHeightToPixels(rowHeight);
            }
            return totalHeight;
        }

        // === Quy đổi đơn vị Excel sang pixel ===
        private static double ColumnWidthToPixels(double width)
        {
            // công thức quy đổi chuẩn Excel
            return Math.Truncate((width + 0.72) * 7.0025);
        }

        private static double RowHeightToPixels(double height)
        {
            // công thức quy đổi chuẩn Excel
            return Math.Truncate(height * (4.0 / 3.0));
        }
        static void RewriteExcelByOpenXml(string path)
        {
            using (var doc = SpreadsheetDocument.Open(path, true))
            {
                doc.WorkbookPart.Workbook.Save();
            }
        }

        private static void InsertTableFromJson(XLWorkbook wb, string tablejson)
        {
            if (string.IsNullOrWhiteSpace(tablejson) || tablejson.Trim() == "[]")
                return;

            var groupedData = ReadTableData(tablejson);

            foreach (var ws in wb.Worksheets)
            {
                var tablePlaceholders = ws.CellsUsed(c =>
                    !c.HasFormula &&
                    c.GetString().Trim().StartsWith("@table_", StringComparison.OrdinalIgnoreCase)
                ).ToList();

                foreach (var placeholderCell in tablePlaceholders)
                {
                    string placeholderText = placeholderCell.GetString().Trim();
                    string tableType = placeholderText.Substring(7);

                    if (!groupedData.TryGetValue(tableType, out var tableData) || tableData.Count == 0)
                        continue;

                    var range = placeholderCell.MergedRange() ?? placeholderCell.AsRange();
                    int startRow = range.FirstCell().Address.RowNumber;
                    int startCol = range.FirstCell().Address.ColumnNumber;

                    range.Clear();
                    if (range.ColumnCount() > 1)
                        range.Unmerge();

                    int headerRow = startRow + 1;

                    // Map header -> column
                    var columnMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                    foreach (var cell in ws.Row(headerRow).CellsUsed())
                    {
                        if (cell.Address.ColumnNumber < startCol) continue;

                        string val = cell.GetString().Trim();
                        if (val.StartsWith("@") && val.Contains("_") &&
                            GetTablePrefix(val).Equals(tableType, StringComparison.OrdinalIgnoreCase))
                        {
                            columnMap[val] = cell.Address.ColumnNumber;
                        }
                    }

                    if (!columnMap.Any())
                        continue;

                    int dataStartRow = startRow + 1;

                    // Lấy merge mẫu ở dòng đầu
                    var sampleMerges = ws.MergedRanges
                        .Where(r => r.FirstCell().Address.RowNumber == dataStartRow &&
                                    r.LastCell().Address.RowNumber == dataStartRow)
                        .ToList();

                    // Insert thêm dòng nếu cần
                    if (tableData.Count > 1)
                        ws.Row(dataStartRow).InsertRowsBelow(tableData.Count - 1);

                    int currentRow = dataStartRow;
                    int rowIndex = 1;

                    foreach (var rowData in tableData)
                    {
                        // === COPY STYLE + MERGE ===
                        if (rowIndex > 1)
                        {
                            foreach (var kvp in columnMap)
                            {
                                int col = kvp.Value;
                                ws.Cell(currentRow, col).Style =
                                    ws.Cell(dataStartRow, col).Style;
                            }

                            foreach (var merge in sampleMerges)
                            {
                                int firstCol = merge.FirstCell().Address.ColumnNumber;
                                int lastCol = merge.LastCell().Address.ColumnNumber;
                                ws.Range(currentRow, firstCol, currentRow, lastCol).Merge();
                            }
                        }

                        // === FILL DATA ===
                        foreach (var kv in rowData)
                        {
                            string key = kv.Key;
                            if (!key.StartsWith("@") ||
                                !GetTablePrefix(key).Equals(tableType, StringComparison.OrdinalIgnoreCase))
                                continue;

                            if (!columnMap.TryGetValue(key, out int col))
                                continue;

                            var cell = ws.Cell(currentRow, col);
                            var headerCell = ws.Cell(headerRow, col);

                            // Giữ NumberFormat từ header
                            if (!string.IsNullOrEmpty(headerCell.Style.NumberFormat.Format))
                                cell.Style.NumberFormat = headerCell.Style.NumberFormat;

                            string strVal = kv.Value?.ToString() ?? "";

                            // Ép xuống dòng theo content dài + dấu phân cách
                            if (strVal.Length > 80 && strVal.Contains(","))
                                strVal = strVal.Replace(", ", ",\n");

                            //if (double.TryParse(
                            //        strVal.Replace(",", "").Replace(".", "").Replace(" ", ""),
                            //        NumberStyles.Any,
                            //        CultureInfo.InvariantCulture,
                            //        out double num))
                            //{
                            //    cell.Value = num;
                            //}
                            //else
                            //{
                            //    cell.SetValue(strVal);
                            //}
                            string raw = strVal.Trim();

                            decimal num;

                            if (raw.Contains(",") && raw.LastIndexOf(",") > raw.LastIndexOf("."))
                            {
                                // Format VN: 1.234,56 -> 1234.56
                                string vn = raw.Replace(".", "").Replace(",", ".");

                                if (decimal.TryParse(
                                        vn,
                                        NumberStyles.Any,
                                        CultureInfo.InvariantCulture,
                                        out num))
                                {
                                    cell.Value = num;
                                }
                                else
                                {
                                    cell.SetValue(strVal);
                                }
                            }
                            else
                            {
                                // Format US: 333.03 hoặc 1,984.78
                                string us = raw.Replace(",", "");

                                if (decimal.TryParse(
                                        us,
                                        NumberStyles.Any,
                                        CultureInfo.InvariantCulture,
                                        out num))
                                {
                                    cell.Value = num;
                                }
                                else
                                {
                                    cell.SetValue(strVal);
                                }
                            }

                            if (key.Contains("_STT", StringComparison.OrdinalIgnoreCase))
                                cell.SetValue(rowIndex);
                        }

                        ws.Row(currentRow).AdjustToContents();
                        ws.Row(currentRow).Height =
                            Math.Max(ws.Row(currentRow).Height, 42);

                        rowIndex++;
                        currentRow++;
                    }

                    // === AUTO WRAP TEXT COLUMN (KHÔNG AUTO WIDTH) ===
                    foreach (var kvp in columnMap)
                    {
                        int col = kvp.Value;

                        int cellCount = 0;
                        int numericCount = 0;
                        double totalLength = 0;

                        for (int r = dataStartRow; r < currentRow; r++)
                        {
                            string val = ws.Cell(r, col).GetString().Trim();
                            if (string.IsNullOrEmpty(val)) continue;

                            cellCount++;
                            totalLength += val.Length;

                            if (double.TryParse(
                                val.Replace(",", "").Replace(".", "").Replace(" ", ""),
                                NumberStyles.Any,
                                CultureInfo.InvariantCulture,
                                out _))
                                numericCount++;
                        }

                        if (cellCount == 0) continue;

                        double avgLength = totalLength / cellCount;
                        double numericRatio = (double)numericCount / cellCount;

                        bool isTextHeavyColumn =
                            avgLength > 15 &&
                            numericRatio < 0.6;

                        if (isTextHeavyColumn)
                        {
                            //ws.Column(col).Style.Alignment.WrapText = true;
                            //ws.Column(col).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            //ws.Column(col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            for (int r = dataStartRow; r < currentRow; r++)
                            {
                                var cell = ws.Cell(r, col);

                                // Chỉ wrap cho cell text dài
                                string val = cell.GetString();
                                if (string.IsNullOrEmpty(val)) continue;

                                if (val.Length > 80 && val.Contains(","))
                                {
                                    cell.Style.Alignment.WrapText = true;
                                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                    // Nếu cell KHÔNG phải số → canh trái
                                    if (!double.TryParse(
                                        val.Replace(",", "").Replace(".", "").Replace(" ", ""),
                                        NumberStyles.Any,
                                        CultureInfo.InvariantCulture,
                                        out _))
                                    {
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                    }
                                }
                            }

                        }

                    }

                    // Xóa dòng @table_
                    ws.Row(startRow).Delete();
                }
            }
        }

        internal static Dictionary<string, List<Dictionary<string, object>>> ReadTableData(string tablejson)
        {
            if (string.IsNullOrWhiteSpace(tablejson))
                return new();
            List<Dictionary<string, object>> allRows;
            var json = tablejson.TrimStart();
            if (json.StartsWith("["))
                allRows = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(tablejson);
            else
                allRows = new List<Dictionary<string, object>>
                {
                    JsonSerializer.Deserialize<Dictionary<string, object>>(tablejson)
                };

            if (allRows == null || allRows.Count == 0)
                return new();

            return allRows
                .SelectMany(row => row.Keys
                    .Where(k => k.StartsWith("@") && k.Contains("_"))
                    .Select(key => new { Key = key, Row = row }))
                .GroupBy(x => GetTablePrefix(x.Key))
                .ToDictionary(g => g.Key, g => g.Select(x => x.Row).Distinct().ToList());

        }

        private static string GetTablePrefix(string key)
        {
            if (string.IsNullOrEmpty(key) || !key.StartsWith("@")) return "";
            int underscorePos = key.IndexOf('_', 1);
            if (underscorePos <= 1) return "";
            return key.Substring(1, underscorePos - 1); ;
        }

        private static void RemoveCheckRows(IXLWorksheet ws)
        {
            var rowsToDel = ws.CellsUsed(c => c.GetString().StartsWith("@check_C_"))
                              .Select(c => c.Address.RowNumber)
                              .Distinct()
                              .OrderByDescending(r => r);

            foreach (int r in rowsToDel)
                ws.Row(r).Delete();
        }
    }
}
