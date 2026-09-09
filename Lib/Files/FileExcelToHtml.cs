using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DMS.Lib.Files
{
    /// <summary>
    /// Render trực tiếp form Excel thành HTML.
    ///
    /// Template Excel vẫn là nguồn layout: merge cell, kích thước hàng/cột,
    /// border, font, màu nền và hình ảnh được chuyển sang HTML. Handlebars chỉ
    /// thay dữ liệu trong các placeholder của template, không dựng lại một form
    /// khác.
    /// </summary>
    public static class FileExcelToHtml
    {
        private static readonly Regex PlaceholderRegex = new(
            @"@([A-Za-z_][A-Za-z0-9_]*)",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static string ConvertToHtml(
            string templatePath,
            string jsonReplacements,
            string tableJson,
            string signType,
            string userFullName,
            string signatureUrl = null)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException(
                    $"Không tìm thấy file template Excel: {templatePath}",
                    templatePath);

            var model = BuildModel(
                jsonReplacements,
                tableJson,
                signType,
                userFullName,
                signatureUrl);
            var handlebarsTemplate = BuildHtmlTemplateFromXlsx(templatePath, signType);
            var rendered = HandlebarsDotNet.Handlebars.Compile(handlebarsTemplate)(model);

            return WrapDocument(rendered);
        }

        /// <summary>
        /// Chỉ dựng template Handlebars từ Excel để kiểm tra layout/placeholders.
        /// </summary>
        public static string ConvertWorkbookToHtml(string workbookPath)
        {
            var workbookHtml = BuildHtmlTemplateFromXlsx(workbookPath, null, true);
            // Workbook values are already escaped; do not compile user data as template syntax.
            var render = HandlebarsDotNet.Handlebars.Compile("{{{Workbook}}}");
            return WrapDocument(render(new { Workbook = workbookHtml }));
        }

        public static string BuildTemplate(string templatePath)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException(
                    $"Không tìm thấy file template Excel: {templatePath}",
                    templatePath);

            return BuildHtmlTemplateFromXlsx(templatePath, null);
        }

        /// <summary>
        /// Builds a complete Handlebars document from the workbook layout.
        /// The generated bindings are consumed when an edited HTML document is
        /// imported back into the original workbook template.
        /// </summary>
        public static string BuildTemplateDocument(string templatePath)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException(
                    $"Không tìm thấy file template Excel: {templatePath}",
                    templatePath);

            return WrapDocument(BuildHtmlTemplateFromXlsx(templatePath, null));
        }

        private static string BuildHtmlTemplateFromXlsx(string templatePath, string signType, bool filled = false)
        {
            var document = new StringBuilder();

            using var workbook = new XLWorkbook(templatePath);
            foreach (var worksheet in workbook.Worksheets)
            {
                // The workbook's print area is the source of truth for the form.
                // RangeUsed() can include styled cells outside the printable form
                // (this workbook declares A1:N20 but has a styled P column).
                var usedRange = worksheet.PageSetup.PrintAreas.FirstOrDefault()
                    ?? worksheet.RangeUsed();
                if (usedRange == null)
                    continue;

                document.Append("<section class=\"excel-sheet\">");
                document.Append(BuildWorksheetTable(worksheet, usedRange, signType, filled));
                document.Append(BuildWorksheetPictures(worksheet, usedRange));
                document.Append("</section>");
            }

            return document.Length == 0
                ? "<section class=\"excel-sheet\"><table class=\"excel-table\"></table></section>"
                : document.ToString();
        }

        private static string BuildWorksheetTable(
            IXLWorksheet worksheet,
            IXLRange usedRange,
            string signType, bool filled)
        {
            var firstRow = usedRange.RangeAddress.FirstAddress.RowNumber;
            var lastRow = usedRange.RangeAddress.LastAddress.RowNumber;
            var firstColumn = usedRange.RangeAddress.FirstAddress.ColumnNumber;
            var lastColumn = usedRange.RangeAddress.LastAddress.ColumnNumber;
            var mergedCells = BuildMergedCellMap(worksheet);
            var tableRows = filled ? new Dictionary<int, string>() : FindTableRows(usedRange);
            var checkRows = filled ? new HashSet<int>() : FindCheckRows(usedRange);

            var html = new StringBuilder();
            var tableWidth = Enumerable.Range(firstColumn, lastColumn - firstColumn + 1)
                .Sum(column => Math.Max(1, WidthToPixels(worksheet.Column(column).Width)));
            html.Append($"<table class=\"excel-table\" style=\"width:{tableWidth.ToString(CultureInfo.InvariantCulture)}px\"><colgroup>");
            for (var column = firstColumn; column <= lastColumn; column++)
            {
                var width = Math.Max(1, WidthToPixels(worksheet.Column(column).Width));
                html.Append($"<col style=\"width:{width.ToString(CultureInfo.InvariantCulture)}px\">");
            }

            html.Append("</colgroup><tbody>");
            for (var row = firstRow; row <= lastRow; row++)
            {
                if (checkRows.Contains(row) || tableRows.ContainsKey(row))
                    continue;

                tableRows.TryGetValue(row - 1, out var tableType);
                if (tableType != null)
                    html.Append($"{{{{#each table_{tableType}}}}}");

                html.Append($"<tr style=\"height:{RowHeightToPixels(worksheet.Row(row).Height).ToString(CultureInfo.InvariantCulture)}px\">");
                for (var column = firstColumn; column <= lastColumn; column++)
                {
                    if (mergedCells.ContainsKey((row, column)))
                        continue;

                    var cell = worksheet.Cell(row, column);
                    var (rowSpan, columnSpan) = GetSpan(
                        worksheet,
                        row,
                        column,
                        lastRow,
                        lastColumn);
                    var span = rowSpan > 1 ? $" rowspan=\"{rowSpan}\"" : string.Empty;
                    span += columnSpan > 1 ? $" colspan=\"{columnSpan}\"" : string.Empty;
                    var content = filled
                        ? RenderFilledCell(cell)
                        : BuildCellContent(cell, tableType, signType);
                    var style = BuildCellStyle(cell);
                    var metadata = filled
                        ? string.Empty
                        : BuildCellMetadata(cell, tableType);

                    html.Append($"<td{span}{metadata} style=\"{style}\">{content}</td>");
                }

                html.Append("</tr>");
                if (tableType != null)
                    html.Append("{{/each}}");
            }

            html.Append("</tbody></table>");
            return html.ToString();
        }

        private static string RenderFilledCell(IXLCell cell)
        {
            var value = cell.GetFormattedString();
            // Filled content is data, including literal @ text and unresolved placeholders.
            return WebUtility.HtmlEncode(value).Replace("\r\n", "\n").Replace("\n", "<br>");
        }

        private static Dictionary<(int Row, int Column), bool> BuildMergedCellMap(IXLWorksheet worksheet)
        {
            var map = new Dictionary<(int Row, int Column), bool>();
            foreach (var mergedRange in worksheet.MergedRanges)
            {
                var address = mergedRange.RangeAddress;
                for (var row = address.FirstAddress.RowNumber; row <= address.LastAddress.RowNumber; row++)
                {
                    for (var column = address.FirstAddress.ColumnNumber;
                         column <= address.LastAddress.ColumnNumber;
                         column++)
                    {
                        if (row == address.FirstAddress.RowNumber &&
                            column == address.FirstAddress.ColumnNumber)
                        {
                            continue;
                        }

                        map[(row, column)] = true;
                    }
                }
            }

            return map;
        }

        private static Dictionary<int, string> FindTableRows(IXLRange usedRange)
        {
            var tableRows = new Dictionary<int, string>();
            foreach (var cell in usedRange.Cells())
            {
                var value = cell.GetString().Trim();
                if (!value.StartsWith("@table_", StringComparison.OrdinalIgnoreCase))
                    continue;

                var tableType = value[7..].Trim();
                if (tableType.Length > 0)
                    tableRows[cell.Address.RowNumber] = tableType;
            }

            return tableRows;
        }

        private static HashSet<int> FindCheckRows(IXLRange usedRange)
        {
            var rows = new HashSet<int>();
            foreach (var cell in usedRange.Cells())
            {
                if (cell.GetString().Trim().StartsWith("@check_C_", StringComparison.OrdinalIgnoreCase))
                    rows.Add(cell.Address.RowNumber);
            }

            return rows;
        }

        private static (int RowSpan, int ColumnSpan) GetSpan(
            IXLWorksheet worksheet,
            int row,
            int column,
            int lastRow,
            int lastColumn)
        {
            foreach (var mergedRange in worksheet.MergedRanges)
            {
                var address = mergedRange.RangeAddress;
                if (address.FirstAddress.RowNumber != row ||
                    address.FirstAddress.ColumnNumber != column)
                {
                    continue;
                }

                return (
                    Math.Min(address.LastAddress.RowNumber, lastRow) - row + 1,
                    Math.Min(address.LastAddress.ColumnNumber, lastColumn) - column + 1);
            }

            return (1, 1);
        }

        private static string BuildCellContent(
            IXLCell cell,
            string tableType,
            string signType)
        {
            var value = cell.HasFormula
                ? GetFormulaValue(cell)
                : cell.GetFormattedString();

            if (string.IsNullOrWhiteSpace(value))
                return "&nbsp;";

            var encodedValue = WebUtility.HtmlEncode(value)
                .Replace("\r\n", "\n", StringComparison.Ordinal)
                .Replace("\r", "\n", StringComparison.Ordinal)
                .Replace("\n", "<br>", StringComparison.Ordinal);

            return PlaceholderRegex.Replace(
                encodedValue,
                match => ReplacePlaceholder(match.Groups[1].Value, tableType, signType));
        }

        private static string BuildCellMetadata(IXLCell cell, string tableType)
        {
            var metadata = new StringBuilder();
            metadata.Append(" data-excel-cell=\"");
            metadata.Append(WebUtility.HtmlEncode(cell.Address.ToString()));
            metadata.Append('"');

            if (!string.IsNullOrWhiteSpace(tableType))
            {
                metadata.Append(" data-excel-table=\"");
                metadata.Append(WebUtility.HtmlEncode(tableType));
                metadata.Append('"');
            }

            return metadata.ToString();
        }

        private static string GetFormulaValue(IXLCell cell)
        {
            try
            {
                return cell.GetFormattedString();
            }
            catch
            {
                return cell.GetString();
            }
        }

        private static string ReplacePlaceholder(
            string key,
            string tableType,
            string signType)
        {
            if (key.StartsWith("SignLink", StringComparison.OrdinalIgnoreCase))
            {
                var field = FieldBinding(key);
                return "{{#if " + key + "}}<img class=\"excel-signature\" data-excel-field=\"" +
                    field + "\" src=\"{{" + key + "}}\" alt=\"Chữ ký\">{{else}}" +
                    "<span data-excel-field=\"" + field + "\">@" + key + "</span>{{/if}}";
            }

            if (key.StartsWith("SignNote", StringComparison.OrdinalIgnoreCase))
            {
                var field = FieldBinding(key);
                return "{{#if " + key + "}}<span data-excel-field=\"" + field + "\">{{" + key +
                    "}}</span>{{else}}<span data-excel-field=\"" + field + "\">@" + key + "</span>{{/if}}";
            }

            if (key.StartsWith("SignName", StringComparison.OrdinalIgnoreCase))
            {
                return string.Equals(signType, "DF", StringComparison.OrdinalIgnoreCase)
                    ? string.Empty
                    : "<span data-excel-field=\"" + FieldBinding(key) + "\">{{" + key + "}}</span>";
            }

            if (key.StartsWith("table_", StringComparison.OrdinalIgnoreCase))
                return string.Empty;

            if (!string.IsNullOrWhiteSpace(tableType) &&
                key.StartsWith(tableType + "_", StringComparison.OrdinalIgnoreCase))
            {
                return "<span data-excel-field=\"" + FieldBinding(key) + "\">{{" +
                    key[(tableType.Length + 1)..] + "}}</span>";
            }

            return "<span data-excel-field=\"" + FieldBinding(key) + "\">{{" + key + "}}</span>";
        }

        private static string FieldBinding(string key)
        {
            return WebUtility.HtmlEncode(key);
        }

        private static string BuildWorksheetPictures(
            IXLWorksheet worksheet,
            IXLRange usedRange)
        {
            var firstRow = usedRange.RangeAddress.FirstAddress.RowNumber;
            var firstColumn = usedRange.RangeAddress.FirstAddress.ColumnNumber;
            var pictures = new StringBuilder();

            foreach (var picture in worksheet.Pictures)
            {
                var topLeftCell = picture.TopLeftCell;
                if (topLeftCell == null)
                    continue;

                var imageData = ReadPictureData(picture);
                if (imageData == null)
                    continue;

                var left = (double)picture.Left;
                for (var column = firstColumn; column < topLeftCell.Address.ColumnNumber; column++)
                    left += WidthToPixels(worksheet.Column(column).Width);

                var top = (double)picture.Top;
                for (var row = firstRow; row < topLeftCell.Address.RowNumber; row++)
                    top += RowHeightToPixels(worksheet.Row(row).Height);

                var width = Math.Max(1d, picture.Width);
                var height = Math.Max(1d, picture.Height);
                var leftText = left.ToString("0.##", CultureInfo.InvariantCulture);
                var topText = top.ToString("0.##", CultureInfo.InvariantCulture);
                var widthText = width.ToString("0.##", CultureInfo.InvariantCulture);
                var heightText = height.ToString("0.##", CultureInfo.InvariantCulture);

                pictures.Append(
                    $"<img class=\"excel-picture\" src=\"data:{imageData.Value.MimeType};base64,{imageData.Value.Base64}\" " +
                    $"alt=\"Excel image\" style=\"left:{leftText}px;top:{topText}px;width:{widthText}px;height:{heightText}px\">");
            }

            return pictures.ToString();
        }

        private static (string MimeType, string Base64)? ReadPictureData(IXLPicture picture)
        {
            try
            {
                var stream = picture.ImageStream;
                if (stream == null)
                    return null;

                if (stream.CanSeek)
                    stream.Position = 0;

                using var buffer = new MemoryStream();
                stream.CopyTo(buffer);
                if (buffer.Length == 0)
                    return null;

                var mimeType = picture.Format.ToString().ToLowerInvariant() switch
                {
                    "jpg" or "jpeg" => "image/jpeg",
                    "gif" => "image/gif",
                    "bmp" => "image/bmp",
                    "tif" or "tiff" => "image/tiff",
                    "svg" => "image/svg+xml",
                    _ => "image/png"
                };

                return (mimeType, Convert.ToBase64String(buffer.ToArray()));
            }
            catch
            {
                return null;
            }
        }

        private static string BuildCellStyle(IXLCell cell)
        {
            var style = cell.Style;
            var parts = new List<string>();

            if (style.Font.Bold)
                parts.Add("font-weight:bold;");
            if (style.Font.Italic)
                parts.Add("font-style:italic;");
            if (style.Font.FontSize > 0)
            {
                parts.Add($"font-size:{style.Font.FontSize.ToString(CultureInfo.InvariantCulture)}pt;");
            }
            if (!string.IsNullOrWhiteSpace(style.Font.FontName))
                parts.Add($"font-family:'{WebUtility.HtmlEncode(style.Font.FontName)}';");

            var fontColor = TryColorHex(style.Font.FontColor);
            if (fontColor != null)
                parts.Add($"color:{fontColor};");

            var backgroundColor = TryColorHex(style.Fill.BackgroundColor);
            if (backgroundColor != null)
                parts.Add($"background-color:{backgroundColor};");

            switch (style.Alignment.Horizontal)
            {
                case XLAlignmentHorizontalValues.Left:
                    parts.Add("text-align:left;");
                    break;
                case XLAlignmentHorizontalValues.Center:
                    parts.Add("text-align:center;");
                    break;
                case XLAlignmentHorizontalValues.Right:
                    parts.Add("text-align:right;");
                    break;
                case XLAlignmentHorizontalValues.Justify:
                    parts.Add("text-align:justify;");
                    break;
            }

            switch (style.Alignment.Vertical)
            {
                case XLAlignmentVerticalValues.Top:
                    parts.Add("vertical-align:top;");
                    break;
                case XLAlignmentVerticalValues.Center:
                    parts.Add("vertical-align:middle;");
                    break;
                case XLAlignmentVerticalValues.Bottom:
                    parts.Add("vertical-align:bottom;");
                    break;
            }

            if (style.Alignment.WrapText)
                parts.Add("white-space:pre-wrap;word-wrap:break-word;");

            AddBorder(parts, style.Border.TopBorder, style.Border.TopBorderColor, "top");
            AddBorder(parts, style.Border.BottomBorder, style.Border.BottomBorderColor, "bottom");
            AddBorder(parts, style.Border.LeftBorder, style.Border.LeftBorderColor, "left");
            AddBorder(parts, style.Border.RightBorder, style.Border.RightBorderColor, "right");

            return string.Join(string.Empty, parts);
        }

        private static void AddBorder(
            ICollection<string> styles,
            XLBorderStyleValues border,
            XLColor color,
            string edge)
        {
            var borderStyle = border switch
            {
                XLBorderStyleValues.Thin => "1px solid",
                XLBorderStyleValues.Medium => "2px solid",
                XLBorderStyleValues.Thick => "3px solid",
                XLBorderStyleValues.Double => "3px double",
                XLBorderStyleValues.Dashed => "1px dashed",
                XLBorderStyleValues.Dotted => "1px dotted",
                XLBorderStyleValues.Hair => "1px solid",
                _ => null
            };

            if (borderStyle == null)
                return;

            styles.Add(
                $"border-{edge}:{borderStyle} {TryColorHex(color) ?? "#000000"};");
        }

        private static string TryColorHex(XLColor color)
        {
            try
            {
                if (color == null || !color.HasValue || color.ColorType != XLColorType.Color)
                    return null;

                return $"#{color.Color.R:X2}{color.Color.G:X2}{color.Color.B:X2}";
            }
            catch
            {
                return null;
            }
        }

        private static double WidthToPixels(double width)
        {
            return Math.Truncate((width + 0.72) * 7.0025);
        }

        private static double RowHeightToPixels(double height)
        {
            return Math.Truncate(height * (4.0 / 3.0));
        }

        private static Dictionary<string, object> BuildModel(
            string jsonData,
            string tableJson,
            string signType,
            string userFullName,
            string signatureUrl)
        {
            var model = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                using var document = JsonDocument.Parse(jsonData);
                if (document.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (var property in document.RootElement.EnumerateObject())
                    {
                        var key = NormalizeKey(property.Name);
                        model[key] = ReadValue(property.Value);
                    }
                }
            }

            // Keep each procedure field intact; a shared image is not a per-slot value.
            model["SignatureUrl"] = signatureUrl ?? string.Empty;
            model["SignType"] = signType ?? string.Empty;
            model["UserFullName"] = string.IsNullOrWhiteSpace(userFullName)
                ? GetString(model, "UserFullName") ?? string.Empty
                : userFullName;

            foreach (var group in ParseTableRows(tableJson).GroupBy(row => row.TableType))
                model["table_" + group.Key] = group.Select(row => row.Values).ToList();

            return model;
        }

        private static List<(string TableType, Dictionary<string, object> Values)> ParseTableRows(string tableJson)
        {
            var result = new List<(string TableType, Dictionary<string, object> Values)>();
            if (string.IsNullOrWhiteSpace(tableJson) || tableJson.Trim() == "[]")
                return result;

            using var document = JsonDocument.Parse(tableJson);
            var elements = document.RootElement.ValueKind == JsonValueKind.Array
                ? document.RootElement.EnumerateArray().ToList()
                : new List<JsonElement> { document.RootElement };

            foreach (var element in elements)
            {
                if (element.ValueKind != JsonValueKind.Object)
                    continue;

                var values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                var tableType = "I";
                foreach (var property in element.EnumerateObject())
                {
                    var key = NormalizeKey(property.Name);
                    var separator = key.IndexOf('_');
                    if (separator > 0)
                    {
                        tableType = key[..separator];
                        key = key[(separator + 1)..];
                    }

                    values[key] = ReadValue(property.Value);
                }

                result.Add((tableType, values));
            }

            return result;
        }

        private static string NormalizeKey(string key)
        {
            return key.StartsWith("@", StringComparison.Ordinal)
                ? key[1..]
                : key;
        }

        private static object ReadValue(JsonElement element)
        {
            return element.ValueKind switch
            {
                JsonValueKind.String => element.GetString(),
                JsonValueKind.Number when element.TryGetInt64(out var integer) => integer,
                JsonValueKind.Number => element.GetDecimal(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Object => ReadObject(element),
                JsonValueKind.Array => element.EnumerateArray().Select(ReadValue).ToList(),
                _ => null
            };
        }

        private static Dictionary<string, object> ReadObject(JsonElement element)
        {
            var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            foreach (var property in element.EnumerateObject())
                result[NormalizeKey(property.Name)] = ReadValue(property.Value);

            return result;
        }

        private static string GetString(Dictionary<string, object> values, string key)
        {
            return values.TryGetValue(key, out var value)
                ? Convert.ToString(value, CultureInfo.InvariantCulture)
                : null;
        }

        private static string WrapDocument(string body)
        {
            var document = "<!DOCTYPE html><html lang=\"vi\"><head><meta charset=\"utf-8\">" +
                   "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
                   "<style>" +
                   "html,body{margin:0;padding:0;background:#f3f4f6;}" +
                   "body{font-family:Arial,sans-serif;color:#000;}" +
                   ".excel-document{padding:16px;box-sizing:border-box;width:100%;overflow-x:auto;}" +
                   ".excel-sheet{position:relative;width:max-content;max-width:none;margin:0 auto 24px;background:#fff;overflow:visible;page-break-after:always;}" +
                   ".excel-sheet:last-child{page-break-after:auto;}" +
                   ".excel-table{border-collapse:collapse;table-layout:fixed;width:auto;background:#fff;}" +
                   ".excel-table td{box-sizing:border-box;padding:2px 4px;overflow:hidden;}" +
                   ".excel-picture,.excel-signature{position:absolute;display:block;object-fit:contain;}" +
                   ".excel-picture{z-index:10;pointer-events:none;}" +
                   ".excel-signature{position:relative;display:inline-block;max-width:100%;max-height:100%;vertical-align:middle;}" +
                   "</style></head><body><main class=\"excel-document\">" +
                   body +
                   "</main></body></html>";

            return HtmlPrintLayout.Apply(document);
        }
    }
}
