using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DMS.Lib.Files
{
    /// <summary>
    /// Tool chuyen Excel (.xlsx) sang HTML dung Handlebars.Net.
    /// - Doc file Excel giu nguyen layout (merge, style, width/height column/row).
    /// - Chuyen cac placeholder dang @key trong cell thanh {{key}} cua Handlebars.
    /// - Hoi tu JsonTableData (array) thanh cac bien {{table_<Type>}} de dung {{#each table_<Type>}}.
    /// - Chay Handlebars voi data model BuildModel(JsonData, JsonTableData) => HTML cuoi cung.
    /// </summary>
    public static class FileExcelToHtml
    {
        /// <summary>
        /// Chuyen template .xlsx -> chuoi HTML da render (Handlebars).
        /// </summary>
        public static string ConvertToHtml(
            string templatePath,
            string jsonReplacements,
            string tablejson,
            string signType,
            string userFullName)
        {
            if (!System.IO.File.Exists(templatePath))
                throw new System.IO.FileNotFoundException($"Khong tim thay file template: {templatePath}");

            string htmlTemplate = BuildHtmlTemplateFromXlsx(templatePath);
            string handlebarsTemplate = ToHandlebars(htmlTemplate);

            var data = BuildModel(jsonReplacements, tablejson, signType, userFullName);
            var html = HandlebarsDotNet.Handlebars.Compile(handlebarsTemplate)(data);

            return WrapDocument(html);
        }

        /// <summary>Tra ve HTML template (chua render) bang Handlebars, de debug/kiem tra.</summary>
        public static string BuildTemplate(string templatePath)
        {
            string htmlTemplate = BuildHtmlTemplateFromXlsx(templatePath);
            return ToHandlebars(htmlTemplate);
        }

        // ===================== 1. Excel -> HTML table =====================
        private static string BuildHtmlTemplateFromXlsx(string templatePath)
        {
            var sb = new StringBuilder();
            using var wb = new XLWorkbook(templatePath);
            var ws = wb.Worksheets.First();

            var usedRange = ws.RangeUsed();
            if (usedRange == null) return "<table></table>";

            int firstRow = usedRange.RangeAddress.FirstAddress.RowNumber;
            int lastRow = usedRange.RangeAddress.LastAddress.RowNumber;
            int firstCol = usedRange.RangeAddress.FirstAddress.ColumnNumber;
            int lastCol = usedRange.RangeAddress.LastAddress.ColumnNumber;
            int totalRows = lastRow - firstRow + 1;
            int totalCols = lastCol - firstCol + 1;

            // Xay dung ma tran merged range
            var mergeMap = new Dictionary<int, HashSet<int>>();
            foreach (var m in ws.MergedRanges)
            {
                var a = m.RangeAddress;
                int r1 = a.FirstAddress.RowNumber, r2 = a.LastAddress.RowNumber;
                int c1 = a.FirstAddress.ColumnNumber, c2 = a.LastAddress.ColumnNumber;
                if (r1 < r2 || c1 < c2)
                {
                    for (int r = r1; r <= r2; r++)
                    {
                        if (!mergeMap.ContainsKey(r)) mergeMap[r] = new HashSet<int>();
                        for (int c = c1; c <= c2; c++)
                        {
                            if (r == r1 && c == c1) continue;
                            mergeMap[r].Add(c);
                        }
                    }
                }
            }

            // Colgroup widths
            sb.Append("<table class=\"excel-table\" style=\"border-collapse:collapse;width:100%;\">");
            sb.Append("<colgroup>");
            for (int c = firstCol; c <= lastCol; c++)
            {
                double w = ws.Column(c).Width;
                sb.Append($"<col style=\"width:{WidthToPx(w)}px;\">");
            }
            sb.Append("</colgroup>");

            for (int r = firstRow; r <= lastRow; r++)
            {
                double rowH = ws.Row(r).Height;
                sb.Append($"<tr style=\"height:{RowHeightToPx(rowH)}px;\">");
                for (int c = firstCol; c <= lastCol; c++)
                {
                    if (mergeMap.ContainsKey(r) && mergeMap[r].Contains(c))
                        continue;

                    var cell = ws.Cell(r, c);
                    int rowspan = 1, colspan = 1;
                    foreach (var m in ws.MergedRanges)
                    {
                        var a = m.RangeAddress;
                        if (a.FirstAddress.RowNumber == r && a.FirstAddress.ColumnNumber == c)
                        {
                            rowspan = a.LastAddress.RowNumber - r + 1;
                            colspan = a.LastAddress.ColumnNumber - c + 1;
                            break;
                        }
                    }

                    string style = BuildCellStyle(cell);
                    string content = CellContent(cell);
                    string span = (rowspan > 1 ? $" rowspan=\"{rowspan}\"" : "") +
                                  (colspan > 1 ? $" colspan=\"{colspan}\"" : "");
                    sb.Append($"<td{span} style=\"{style}\">{content}</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        private static string CellContent(IXLCell cell)
        {
            if (cell.HasFormula)
            {
                try
                {
                    string f = cell.GetFormattedString();
                    if (!string.IsNullOrWhiteSpace(f)) return Escape(f);
                }
                catch { }
            }
            var v = cell.Value;
            if (v.IsBlank) return "&nbsp;";
            string text = cell.GetFormattedString();
            return Escape(string.IsNullOrEmpty(text) ? "&nbsp;" : text.Replace("\n", "<br>"));
        }

        private static string Escape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "&nbsp;";
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }

        private static string BuildCellStyle(IXLCell cell)
        {
            var parts = new List<string>();
            var s = cell.Style;

            if (s.Font.Bold) parts.Add("font-weight:bold;");
            if (s.Font.Italic) parts.Add("font-style:italic;");
            if (s.Font.FontSize > 0) parts.Add($"font-size:{s.Font.FontSize.ToString(System.Globalization.CultureInfo.InvariantCulture)}pt;");
            if (!string.IsNullOrEmpty(s.Font.FontName)) parts.Add($"font-family:'{s.Font.FontName}';");

            var fColor = s.Font.FontColor;
            if (fColor != null && !fColor.HasIndexedColor || (fColor.HasIndexedColor && fColor.Indexed != 0))
            {
                string hex = TryColorHex(fColor);
                if (hex != null) parts.Add($"color:{hex};");
            }

            var bg = s.Fill.BackgroundColor;
            string bgHex = TryColorHex(bg, true);
            if (bgHex != null) parts.Add($"background-color:{bgHex};");

            switch (s.Alignment.Horizontal)
            {
                case XLAlignmentHorizontalValues.Left: parts.Add("text-align:left;"); break;
                case XLAlignmentHorizontalValues.Center: parts.Add("text-align:center;"); break;
                case XLAlignmentHorizontalValues.Right: parts.Add("text-align:right;"); break;
                case XLAlignmentHorizontalValues.Justify: parts.Add("text-align:justify;"); break;
            }
            switch (s.Alignment.Vertical)
            {
                case XLAlignmentVerticalValues.Top: parts.Add("vertical-align:top;"); break;
                case XLAlignmentVerticalValues.Center: parts.Add("vertical-align:middle;"); break;
                case XLAlignmentVerticalValues.Bottom: parts.Add("vertical-align:bottom;"); break;
            }
            if (s.Alignment.WrapText) parts.Add("white-space:pre-wrap;word-wrap:break-word;");

            string border = BuildBorder(s);
            if (!string.IsNullOrEmpty(border)) parts.Add(border);

            return string.Join("", parts);
        }

        private static string BuildBorder(IXLStyle s)
        {
            var bs = new StringBuilder();
            AddBorderEdge(bs, s.Border.TopBorder, "top");
            AddBorderEdge(bs, s.Border.BottomBorder, "bottom");
            AddBorderEdge(bs, s.Border.LeftBorder, "left");
            AddBorderEdge(bs, s.Border.RightBorder, "right");
            return bs.ToString();
        }

        private static void AddBorderEdge(StringBuilder bs, XLBorderValues b, string edge)
        {
            string style = b switch
            {
                XLBorderValues.Thin => "1px solid",
                XLBorderValues.Medium => "2px solid",
                XLBorderValues.Thick => "3px solid",
                XLBorderValues.Double => "3px double",
                XLBorderValues.Dashed => "1px dashed",
                XLBorderValues.Dotted => "1px dotted",
                XLBorderValues.Hair => "1px solid",
                _ => null
            };
            if (style == null) return;
            string hex = TryColorHex(b.Color) ?? "#000000";
            bs.Append($"border-{edge}:{style} {hex};");
        }

        private static string TryColorHex(XLColor c, bool isBackground = false)
        {
            try
            {
                if (c.HasColor) return "#" + c.Color.ToHex();
                if (c.HasIndexedColor)
                {
                    if (isBackground && c.Indexed == 64) return null; // transparent
                    // ClosedXML khong cung cap bang mau indexed -> bo qua
                    return null;
                }
                if (!string.IsNullOrEmpty(c.ColorHex)) return "#" + c.ColorHex;
            }
            catch { }
            return null;
        }

        private static double WidthToPx(double width) => Math.Truncate((width + 0.72) * 7.0025);
        private static double RowHeightToPx(double height) => Math.Truncate(height * (4.0 / 3.0));

        // ===================== 2. @key -> {{key}} =====================
        private static string ToHandlebars(string html)
        {
            // @SignLink_*, @SignName_*, @SignNote_* giu nguyen (khong chuyen {}) vi xu ly rieng
            var result = System.Text.RegularExpressions.Regex.Replace(
                html,
                @"@([A-Za-z_][A-Za-z0-9_]*)",
                m => m.Value.StartsWith("@Sign") || m.Value.StartsWith("@table") || m.Value.StartsWith("@check")
                    ? m.Value
                    : "{{" + m.Value.Substring(1).Trim() + "}}");
            return result;
        }

        // ===================== 3. Build du lieu cho Handlebars =====================
        private static Dictionary<string, object> BuildModel(
            string jsonReplacements,
            string tablejson,
            string signType,
            string userFullName)
        {
            var model = new Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);

            // JsonData: object root, cac key co dau @ -> bo dau @
            if (!string.IsNullOrWhiteSpace(jsonReplacements))
            {
                var doc = JsonDocument.Parse(jsonReplacements);
                if (doc.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (var p in doc.RootElement.EnumerateObject())
                    {
                        string key = p.Name;
                        if (key.StartsWith("@")) key = key.Substring(1);
                        model[key] = ReadValue(p.Value);
                    }
                }
                // userFullName/phan chu ky mac dinh
                if (!model.ContainsKey("UserFullName") && !string.IsNullOrEmpty(userFullName))
                    model["UserFullName"] = userFullName;
            }

            // JsonTableData: array -> model["table_<Type>"] = list<dict>
            if (!string.IsNullOrWhiteSpace(tablejson) && tablejson.Trim() != "[]")
            {
                var doc = JsonDocument.Parse(tablejson);
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    var rows = new List<Dictionary<string, object>>();
                    foreach (var item in doc.RootElement.EnumerateArray())
                    {
                        var row = new Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);
                        if (item.ValueKind == JsonValueKind.Object)
                        {
                            foreach (var p in item.EnumerateObject())
                            {
                                string key = p.Name;
                                if (key.StartsWith("@")) key = key.Substring(1);
                                if (key.StartsWith("I_")) key = key.Substring(2);
                                row[key] = ReadValue(p.Value);
                            }
                        }
                        rows.Add(row);
                    }
                    // Type mac dinh "I" (tu ExecExportPDF_ShippingAndCreditnPL)
                    model["table_I"] = rows;
                }
            }

            return model;
        }

        private static object ReadValue(JsonElement el)
        {
            switch (el.ValueKind)
            {
                case JsonValueKind.String: return el.GetString();
                case JsonValueKind.Number: return el.TryGetInt64(out long l) ? (object)l : el.GetDouble();
                case JsonValueKind.True: return true;
                case JsonValueKind.False: return false;
                case JsonValueKind.Null: return null;
                case JsonValueKind.Object:
                    var d = new Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);
                    foreach (var p in el.EnumerateObject()) d[p.Name] = ReadValue(p.Value);
                    return d;
                case JsonValueKind.Array:
                    return el.EnumerateArray().Select(ReadValue).ToList();
                default: return el.ToString();
            }
        }

        // ===================== 4. Wrap document =====================
        private static string WrapDocument(string body)
        {
            return "<!DOCTYPE html><html lang=\"vi\"><head><meta charset=\"utf-8\">" +
                   "<style>body{font-family:Arial,sans-serif;margin:20px;} .excel-table td{border:1px solid #000;padding:4px;}</style>" +
                   "</head><body>" + body + "</body></html>";
        }
    }
}
