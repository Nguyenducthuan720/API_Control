using System.Globalization;
using System.Text.RegularExpressions;

namespace DMS.Lib.Files;

/// <summary>
/// Keeps the fixed Excel-derived form intact on screen while fitting it to an
/// A4 print area. The scale is calculated per sheet from the generated table
/// width, so the column proportions and absolute-positioned images stay aligned.
/// </summary>
internal static class HtmlPrintLayout
{
    private const double A4PrintWidthPixels = 790d;
    private const string StyleMarker = "id=\"nlt-html-print-layout\"";

    private static readonly Regex SheetRegex = new(
        "<section(?<attributes>\\s+[^>]*?\\bclass\\s*=\\s*\"[^\"]*\\bexcel-sheet\\b[^\"]*\"[^>]*)>(?<body>.*?)</section>",
        RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex TableWidthRegex = new(
        "<table(?=[^>]*\\bclass\\s*=\\s*\"[^\"]*\\bexcel-table\\b[^\"]*\")(?=[^>]*\\bstyle\\s*=\\s*\"[^\"]*\\bwidth\\s*:\\s*(?<width>[0-9]+(?:\\.[0-9]+)?)px)[^>]*>",
        RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex StyleAttributeRegex = new(
        "\\bstyle\\s*=\\s*\"(?<style>[^\"]*)\"",
        RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private const string PrintCss = """
        @page{size:A4 portrait;margin:0;}
        @media print{
          html,body{
            margin:0!important;
            padding:0!important;
            width:210mm;
            min-width:210mm;
            background:#fff!important;
            overflow:visible!important;
            -webkit-print-color-adjust:exact;
            print-color-adjust:exact;
          }
          .excel-document{
            box-sizing:border-box;
            width:210mm;
            min-width:210mm;
            padding:0!important;
            overflow:visible!important;
          }
          .excel-sheet{
            box-sizing:border-box;
            margin:0!important;
            zoom:var(--excel-print-scale,1);
            page-break-after:always;
            break-after:page;
            page-break-inside:avoid;
            break-inside:avoid;
          }
          .excel-sheet:last-child{
            page-break-after:auto;
            break-after:auto;
          }
          .excel-table{
            max-width:none;
          }
        }
        """;

    public static string Apply(string html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return html;

        var scaled = AddSheetScales(html);
        if (scaled.Contains(StyleMarker, StringComparison.OrdinalIgnoreCase))
            return scaled;

        var styleTag = $"<style {StyleMarker}>{PrintCss}</style>";
        var headEnd = scaled.IndexOf("</head>", StringComparison.OrdinalIgnoreCase);
        if (headEnd >= 0)
            return scaled.Insert(headEnd, styleTag);

        return styleTag + scaled;
    }

    private static string AddSheetScales(string html)
    {
        return SheetRegex.Replace(html, match =>
        {
            var attributes = match.Groups["attributes"].Value;
            if (attributes.Contains("--excel-print-scale:", StringComparison.OrdinalIgnoreCase))
                return match.Value;

            var table = TableWidthRegex.Match(match.Groups["body"].Value);
            if (!table.Success ||
                !double.TryParse(
                    table.Groups["width"].Value,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out var tableWidth) ||
                tableWidth <= 0)
            {
                return match.Value;
            }

            var scale = Math.Min(1d, A4PrintWidthPixels / tableWidth);
            var printStyle = "--excel-print-scale:" +
                scale.ToString("0.####", CultureInfo.InvariantCulture) + ";";
            var style = StyleAttributeRegex.Match(attributes);

            if (style.Success)
            {
                var updatedStyle = style.Groups["style"].Value.TrimEnd();
                updatedStyle += (updatedStyle.Length == 0 ? string.Empty : ";") + printStyle;
                attributes = attributes.Remove(style.Groups["style"].Index, style.Groups["style"].Length)
                    .Insert(style.Groups["style"].Index, updatedStyle);
            }
            else
            {
                attributes += " style=\"" + printStyle + "\"";
            }

            return "<section" + attributes + ">" + match.Groups["body"].Value + "</section>";
        });
    }
}
