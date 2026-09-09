using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using HtmlAgilityPack;
using System.Globalization;
using System.Text;

namespace DMS.Lib.Files;

/// <summary>
/// Converts the supported, fixed HTML table contract into an XLSX workbook.
/// This is intentionally not a general HTML-to-Excel engine.
/// </summary>
public static class FileHTMLToExcel
{
    public static string ExportHtmlToExcel(string htmlPath, string outputPath)
    {
        if (!File.Exists(htmlPath))
            throw new FileNotFoundException("Không tìm thấy file HTML đã render.", htmlPath);

        var document = HtmlTableParser.LoadDocument(File.ReadAllText(htmlPath, Encoding.UTF8));
        var tables = HtmlTableParser.ParseTables(document);
        if (tables.Count == 0)
            throw new InvalidOperationException("HTML không có bảng được hỗ trợ để xuất Excel.");

        var outputDirectory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        using var workbook = new XLWorkbook();
        var pictureIndex = 0;
        for (var index = 0; index < tables.Count; index++)
            WriteTable(workbook, tables[index], index + 1, ref pictureIndex);

        AddFloatingImages(workbook.Worksheets.First(), document, ref pictureIndex);
        workbook.SaveAs(outputPath);
        return outputPath;
    }

    private static void WriteTable(
        XLWorkbook workbook,
        HtmlTableDefinition table,
        int index,
        ref int pictureIndex)
    {
        var worksheet = workbook.Worksheets.Add($"Sheet{index}");
        for (var column = 1; column <= table.ColumnCount; column++)
        {
            var widthPixels = table.ColumnWidths.ElementAtOrDefault(column - 1) ?? 96d;
            worksheet.Column(column).Width = Math.Max(1d, widthPixels / 7d - 0.72d);
        }

        for (var row = 1; row <= table.RowCount; row++)
        {
            if (row - 1 >= table.RowStyles.Count ||
                !HtmlTableParser.TryReadLengthFromStyle(table.RowStyles[row - 1], "height", out var heightPixels))
                continue;
            worksheet.Row(row).Height = Math.Max(1d, heightPixels * 0.75d);
        }

        foreach (var cell in table.Cells)
        {
            var target = worksheet.Cell(cell.Row, cell.Column);
            SetCellValue(target, cell);
            ApplyStyle(target.Style, cell.Node);

            var range = worksheet.Range(
                cell.Row,
                cell.Column,
                cell.Row + cell.RowSpan - 1,
                cell.Column + cell.ColumnSpan - 1);
            if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
                range.Merge();

            AddCellImages(worksheet, cell, range, ref pictureIndex);
        }
    }

    private static void SetCellValue(IXLCell cell, HtmlCellDefinition definition)
    {
        var formula = definition.Node.GetAttributeValue("data-formula", string.Empty).Trim();
        if (!string.IsNullOrWhiteSpace(formula))
        {
            cell.FormulaA1 = formula;
            return;
        }

        var text = definition.Text;
        var type = definition.Node.GetAttributeValue("data-excel-type", string.Empty).Trim().ToLowerInvariant();
        switch (type)
        {
            case "number":
                if (TryParseDecimal(text, out var number))
                    cell.Value = number;
                else
                    cell.Value = text;
                break;
            case "date":
                if (DateTime.TryParse(text, CultureInfo.CurrentCulture, DateTimeStyles.None, out var date))
                    cell.Value = date;
                else
                    cell.Value = text;
                break;
            case "boolean":
                if (bool.TryParse(text, out var boolean))
                    cell.Value = boolean;
                else
                    cell.Value = text;
                break;
            default:
                cell.Value = text;
                break;
        }

        var numberFormat = definition.Node.GetAttributeValue("data-excel-format", string.Empty).Trim();
        if (!string.IsNullOrWhiteSpace(numberFormat))
            cell.Style.NumberFormat.Format = numberFormat;
    }

    private static bool TryParseDecimal(string text, out decimal value)
    {
        return decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out value)
            || decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value);
    }

    private static void ApplyStyle(IXLStyle style, HtmlNode node)
    {
        var styles = HtmlTableParser.ParseStyle(node);
        if (styles.TryGetValue("font-family", out var fontFamily))
            style.Font.FontName = fontFamily.Trim().Trim('\'', '"');
        if (HtmlTableParser.TryReadPointsFromStyle(styles, "font-size", out var fontSize))
            style.Font.FontSize = fontSize;
        if (styles.TryGetValue("font-weight", out var fontWeight) &&
            (fontWeight.Contains("bold", StringComparison.OrdinalIgnoreCase) || fontWeight == "700"))
            style.Font.Bold = true;
        if (styles.TryGetValue("font-style", out var fontStyle) &&
            fontStyle.Contains("italic", StringComparison.OrdinalIgnoreCase))
            style.Font.Italic = true;
        if (styles.TryGetValue("color", out var color))
            SetFontColor(style, color);
        if (styles.TryGetValue("background-color", out var background))
            SetBackgroundColor(style, background);

        if (styles.TryGetValue("text-align", out var horizontal))
        {
            style.Alignment.Horizontal = horizontal.Trim().ToLowerInvariant() switch
            {
                "center" => XLAlignmentHorizontalValues.Center,
                "right" => XLAlignmentHorizontalValues.Right,
                "justify" => XLAlignmentHorizontalValues.Justify,
                _ => XLAlignmentHorizontalValues.Left
            };
        }

        if (styles.TryGetValue("vertical-align", out var vertical))
        {
            style.Alignment.Vertical = vertical.Trim().ToLowerInvariant() switch
            {
                "middle" or "center" => XLAlignmentVerticalValues.Center,
                "bottom" => XLAlignmentVerticalValues.Bottom,
                _ => XLAlignmentVerticalValues.Top
            };
        }

        if (styles.TryGetValue("white-space", out var whiteSpace) &&
            whiteSpace.Contains("pre", StringComparison.OrdinalIgnoreCase))
            style.Alignment.WrapText = true;

        SetBorder(style, styles, "top");
        SetBorder(style, styles, "right");
        SetBorder(style, styles, "bottom");
        SetBorder(style, styles, "left");
    }

    private static void SetBorder(IXLStyle style, IReadOnlyDictionary<string, string> styles, string edge)
    {
        var value = styles.GetValueOrDefault("border-" + edge) ?? styles.GetValueOrDefault("border");
        if (string.IsNullOrWhiteSpace(value) || value.Contains("none", StringComparison.OrdinalIgnoreCase))
            return;

        var border = value.Contains("double", StringComparison.OrdinalIgnoreCase)
            ? XLBorderStyleValues.Double
            : value.Contains("dashed", StringComparison.OrdinalIgnoreCase)
                ? XLBorderStyleValues.Dashed
                : XLBorderStyleValues.Thin;
        var color = value.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(HtmlTableParser.NormalizeColor)
            .FirstOrDefault(value => value.StartsWith("#", StringComparison.Ordinal));

        switch (edge)
        {
            case "top":
                style.Border.TopBorder = border;
                if (!string.IsNullOrWhiteSpace(color)) style.Border.TopBorderColor = XLColor.FromHtml(color);
                break;
            case "right":
                style.Border.RightBorder = border;
                if (!string.IsNullOrWhiteSpace(color)) style.Border.RightBorderColor = XLColor.FromHtml(color);
                break;
            case "bottom":
                style.Border.BottomBorder = border;
                if (!string.IsNullOrWhiteSpace(color)) style.Border.BottomBorderColor = XLColor.FromHtml(color);
                break;
            case "left":
                style.Border.LeftBorder = border;
                if (!string.IsNullOrWhiteSpace(color)) style.Border.LeftBorderColor = XLColor.FromHtml(color);
                break;
        }
    }

    private static void SetFontColor(IXLStyle style, string color)
    {
        var normalized = HtmlTableParser.NormalizeColor(color);
        if (!string.IsNullOrWhiteSpace(normalized))
            style.Font.FontColor = XLColor.FromHtml(normalized);
    }

    private static void SetBackgroundColor(IXLStyle style, string color)
    {
        var normalized = HtmlTableParser.NormalizeColor(color);
        if (!string.IsNullOrWhiteSpace(normalized))
            style.Fill.BackgroundColor = XLColor.FromHtml(normalized);
    }

    private static void AddCellImages(
        IXLWorksheet worksheet,
        HtmlCellDefinition cell,
        IXLRange range,
        ref int pictureIndex)
    {
        var images = cell.Node.SelectNodes(".//img") ?? new HtmlNodeCollection(null);
        foreach (var image in images)
        {
            if (!HtmlTableParser.TryReadDataImage(image, out var bytes, out var mimeType))
                continue;

            using var stream = new MemoryStream(bytes);
            var picture = worksheet.AddPicture(
                stream,
                ToPictureFormat(HtmlTableParser.GetImageFormat(mimeType)),
                NextPictureName(ref pictureIndex));
            var width = ReadImageSize(image, "width") ?? Math.Max(1d, range.ColumnCount() * 96d);
            var height = ReadImageSize(image, "height") ?? Math.Max(1d, range.RowCount() * 24d);
            picture.MoveTo(range.FirstCell(), 2, 2).WithSize(
                Math.Max(1, (int)Math.Round(width)),
                Math.Max(1, (int)Math.Round(height)));
        }
    }

    private static void AddFloatingImages(
        IXLWorksheet worksheet,
        HtmlAgilityPack.HtmlDocument document,
        ref int pictureIndex)
    {
        var images = document.DocumentNode.SelectNodes("//img") ?? new HtmlNodeCollection(null);
        foreach (var image in images)
        {
            if (image.Ancestors("td").Any() || image.Ancestors("th").Any() ||
                !HtmlTableParser.TryReadDataImage(image, out var bytes, out var mimeType))
                continue;

            var style = HtmlTableParser.ParseStyle(image);
            var left = ParseStyleLength(style, "left") ?? 0;
            var top = ParseStyleLength(style, "top") ?? 0;
            var width = ReadImageSize(image, "width") ?? 120;
            var height = ReadImageSize(image, "height") ?? 60;
            var column = 1;
            var lastColumn = Math.Max(1, worksheet.LastColumnUsed()?.ColumnNumber() ?? 1);
            while (left > 96 && column < lastColumn)
            {
                left -= 96;
                column++;
            }

            var row = Math.Max(1, (int)(top / 24) + 1);
            using var stream = new MemoryStream(bytes);
                worksheet.AddPicture(
                    stream,
                    ToPictureFormat(HtmlTableParser.GetImageFormat(mimeType)),
                    NextPictureName(ref pictureIndex))
                .MoveTo(worksheet.Cell(row, column), 2, 2)
                .WithSize(Math.Max(1, (int)Math.Round(width)), Math.Max(1, (int)Math.Round(height)));
        }
    }

    private static double? ReadImageSize(HtmlNode image, string attribute)
    {
        if (HtmlTableParser.TryReadLength(image, attribute, out var pixels))
            return pixels;
        return null;
    }

    private static double? ParseStyleLength(IReadOnlyDictionary<string, string> styles, string name)
    {
        return styles.TryGetValue(name, out var value) &&
            HtmlTableParser.TryParsePixels(value, out var pixels)
            ? pixels
            : null;
    }

    private static string NextPictureName(ref int pictureIndex)
    {
        pictureIndex++;
        return "html_picture_" + pictureIndex.ToString(CultureInfo.InvariantCulture);
    }

    private static XLPictureFormat ToPictureFormat(HtmlTableParser.XlImageFormat format)
    {
        return format switch
        {
            HtmlTableParser.XlImageFormat.Jpeg => XLPictureFormat.Jpeg,
            HtmlTableParser.XlImageFormat.Gif => XLPictureFormat.Gif,
            HtmlTableParser.XlImageFormat.Bmp => XLPictureFormat.Bmp,
            HtmlTableParser.XlImageFormat.Tiff => XLPictureFormat.Tiff,
            HtmlTableParser.XlImageFormat.Webp => XLPictureFormat.Webp,
            _ => XLPictureFormat.Png
        };
    }
}
