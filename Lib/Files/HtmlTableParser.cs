using HtmlAgilityPack;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DMS.Lib.Files;

internal sealed class HtmlTableDefinition
{
    public List<HtmlCellDefinition> Cells { get; } = new();
    public Dictionary<(int Row, int Column), HtmlCellDefinition> Occupied { get; } = new();
    public List<string> RowStyles { get; } = new();
    public List<double?> ColumnWidths { get; } = new();
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
}

internal sealed class HtmlCellDefinition
{
    public required HtmlNode Node { get; init; }
    public required string Text { get; init; }
    public int Row { get; init; }
    public int Column { get; init; }
    public int RowSpan { get; init; }
    public int ColumnSpan { get; init; }
    public bool IsHeader { get; init; }
}

internal static class HtmlTableParser
{
    private static readonly Regex CssDeclaration = new(
        @"(?<name>[\w-]+)\s*:\s*(?<value>[^;]+)",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static HtmlDocument LoadDocument(string html)
    {
        var document = new HtmlDocument
        {
            OptionFixNestedTags = true,
            OptionAutoCloseOnEnd = true
        };
        document.LoadHtml(html);
        return document;
    }

    public static IReadOnlyList<HtmlTableDefinition> ParseTables(HtmlDocument document)
    {
        var nodes = document.DocumentNode.SelectNodes("//table") ?? new HtmlNodeCollection(null);
        var result = new List<HtmlTableDefinition>();

        foreach (var table in nodes)
        {
            // A nested table belongs to the parent cell and must not become a
            // second worksheet/document table by accident.
            if (table.Ancestors("table").Any())
                continue;

            var definition = ParseTable(table);
            if (definition.Cells.Count > 0)
                result.Add(definition);
        }

        return result;
    }

    private static HtmlTableDefinition ParseTable(HtmlNode table)
    {
        var definition = new HtmlTableDefinition();
        var rows = table.SelectNodes(".//tr")?.Where(row =>
        {
            var nearestTable = row.Ancestors("table").FirstOrDefault();
            return ReferenceEquals(nearestTable, table);
        }).ToList() ?? new List<HtmlNode>();

        var occupied = definition.Occupied;
        for (var rowIndex = 1; rowIndex <= rows.Count; rowIndex++)
        {
            var row = rows[rowIndex - 1];
            definition.RowStyles.Add(row.GetAttributeValue("style", string.Empty));
            var cells = row.SelectNodes("./th|./td") ?? new HtmlNodeCollection(null);
            var column = 1;

            foreach (var cell in cells)
            {
                while (occupied.ContainsKey((rowIndex, column)))
                    column++;

                var rowSpan = ReadSpan(cell, "rowspan");
                var columnSpan = ReadSpan(cell, "colspan");
                var definitionCell = new HtmlCellDefinition
                {
                    Node = cell,
                    Text = GetText(cell),
                    Row = rowIndex,
                    Column = column,
                    RowSpan = rowSpan,
                    ColumnSpan = columnSpan,
                    IsHeader = string.Equals(cell.Name, "th", StringComparison.OrdinalIgnoreCase)
                };

                definition.Cells.Add(definitionCell);
                for (var rowOffset = 0; rowOffset < rowSpan; rowOffset++)
                {
                    for (var columnOffset = 0; columnOffset < columnSpan; columnOffset++)
                        occupied[(rowIndex + rowOffset, column + columnOffset)] = definitionCell;
                }

                column += columnSpan;
                definition.ColumnCount = Math.Max(definition.ColumnCount, column - 1);
            }
        }

        definition.RowCount = rows.Count;
        definition.ColumnWidths.AddRange(ReadColumnWidths(table));
        while (definition.ColumnWidths.Count < definition.ColumnCount)
            definition.ColumnWidths.Add(null);

        foreach (var cell in definition.Cells.Where(cell => cell.ColumnSpan == 1))
        {
            if (!TryReadLength(cell.Node, "width", out var width))
                continue;

            var index = cell.Column - 1;
            if (index >= definition.ColumnWidths.Count)
                continue;
            if (!definition.ColumnWidths[index].HasValue)
                definition.ColumnWidths[index] = width;
        }

        return definition;
    }

    public static string GetText(HtmlNode node)
    {
        var builder = new System.Text.StringBuilder();
        AppendText(node, builder);
        return HtmlEntity.DeEntitize(builder.ToString())
            .Replace('\u00a0', ' ')
            .Replace("\r\n", "\n", StringComparison.Ordinal)
            .Replace('\r', '\n');
    }

    private static void AppendText(HtmlNode node, System.Text.StringBuilder builder)
    {
        foreach (var child in node.ChildNodes)
        {
            if (child.NodeType == HtmlNodeType.Text)
            {
                builder.Append(child.InnerText);
                continue;
            }

            if (child.NodeType != HtmlNodeType.Element)
                continue;
            if (string.Equals(child.Name, "img", StringComparison.OrdinalIgnoreCase))
                continue;
            if (string.Equals(child.Name, "br", StringComparison.OrdinalIgnoreCase))
                builder.Append('\n');
            else
                AppendText(child, builder);
        }
    }

    public static Dictionary<string, string> ParseStyle(HtmlNode node)
    {
        return ParseStyle(node.GetAttributeValue("style", string.Empty));
    }

    public static Dictionary<string, string> ParseStyle(string source)
    {
        var style = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (Match match in CssDeclaration.Matches(source))
            style[match.Groups["name"].Value.Trim()] = match.Groups["value"].Value.Trim();
        return style;
    }

    public static bool TryReadLength(HtmlNode node, string name, out double pixels)
    {
        pixels = 0;
        var styles = ParseStyle(node);
        var value = styles.GetValueOrDefault(name);
        if (string.IsNullOrWhiteSpace(value))
            value = node.GetAttributeValue(name, string.Empty);
        return TryParsePixels(value, out pixels);
    }

    public static bool TryReadLengthFromStyle(string styleSource, string name, out double pixels)
    {
        pixels = 0;
        var styles = ParseStyle(styleSource);
        return styles.TryGetValue(name, out var value) && TryParsePixels(value, out pixels);
    }

    public static bool TryReadPointsFromStyle(
        IReadOnlyDictionary<string, string> styles,
        string name,
        out double points)
    {
        points = 0;
        if (!styles.TryGetValue(name, out var value) || string.IsNullOrWhiteSpace(value))
            return false;

        var text = value.Trim().ToLowerInvariant();
        if (text.EndsWith("pt", StringComparison.Ordinal))
            text = text[..^2];
        else if (text.EndsWith("px", StringComparison.Ordinal))
        {
            if (!double.TryParse(text[..^2], NumberStyles.Float, CultureInfo.InvariantCulture, out var pixels))
                return false;
            points = pixels * 72d / 96d;
            return points > 0;
        }

        return double.TryParse(text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out points)
            && points > 0;
    }

    public static bool TryParsePixels(string value, out double pixels)
    {
        pixels = 0;
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var text = value.Trim().ToLowerInvariant();
        var multiplier = 1d;
        if (text.EndsWith("pt", StringComparison.Ordinal))
        {
            multiplier = 96d / 72d;
            text = text[..^2];
        }
        else if (text.EndsWith("in", StringComparison.Ordinal))
        {
            multiplier = 96d;
            text = text[..^2];
        }
        else if (text.EndsWith("cm", StringComparison.Ordinal))
        {
            multiplier = 96d / 2.54d;
            text = text[..^2];
        }
        else if (text.EndsWith("px", StringComparison.Ordinal))
        {
            text = text[..^2];
        }

        return double.TryParse(text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var valueNumber)
            && (pixels = valueNumber * multiplier) > 0;
    }

    public static bool TryReadPoints(HtmlNode node, string name, out double points)
    {
        points = 0;
        var styles = ParseStyle(node);
        return TryReadPointsFromStyle(styles, name, out points);
    }

    public static string NormalizeColor(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;
        var text = value.Trim();
        if (text.StartsWith("#", StringComparison.Ordinal))
        {
            if (text.Length == 4)
                return $"#{text[1]}{text[1]}{text[2]}{text[2]}{text[3]}{text[3]}";
            return text.Length == 7 ? text : string.Empty;
        }

        var rgb = Regex.Match(text, @"rgb\s*\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*\)",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (rgb.Success && int.TryParse(rgb.Groups[1].Value, out var r) &&
            int.TryParse(rgb.Groups[2].Value, out var g) &&
            int.TryParse(rgb.Groups[3].Value, out var b))
        {
            return $"#{Math.Clamp(r, 0, 255):X2}{Math.Clamp(g, 0, 255):X2}{Math.Clamp(b, 0, 255):X2}";
        }

        return text.ToLowerInvariant() switch
        {
            "black" => "#000000",
            "white" => "#FFFFFF",
            "red" => "#FF0000",
            "green" => "#008000",
            "blue" => "#0000FF",
            "yellow" => "#FFFF00",
            "gray" or "grey" => "#808080",
            "transparent" => string.Empty,
            _ => string.Empty
        };
    }

    public static bool TryReadDataImage(HtmlNode image, out byte[] bytes, out string mimeType)
    {
        bytes = Array.Empty<byte>();
        mimeType = string.Empty;
        var source = HtmlEntity.DeEntitize(
            image.GetAttributeValue("src", string.Empty)).Trim();
        if (!source.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            return false;

        var separator = source.IndexOf(',', StringComparison.Ordinal);
        if (separator < 0)
            return false;

        var metadata = source[5..separator];
        if (!metadata.EndsWith(";base64", StringComparison.OrdinalIgnoreCase))
            return false;

        mimeType = metadata[..^7];
        try
        {
            bytes = Convert.FromBase64String(source[(separator + 1)..]);
            return bytes.Length > 0 && mimeType.StartsWith("image/", StringComparison.OrdinalIgnoreCase);
        }
        catch (FormatException)
        {
            bytes = Array.Empty<byte>();
            mimeType = string.Empty;
            return false;
        }
    }

    public static XlImageFormat GetImageFormat(string mimeType)
    {
        return mimeType.ToLowerInvariant() switch
        {
            "image/jpeg" or "image/jpg" => XlImageFormat.Jpeg,
            "image/gif" => XlImageFormat.Gif,
            "image/bmp" => XlImageFormat.Bmp,
            "image/tiff" => XlImageFormat.Tiff,
            "image/webp" => XlImageFormat.Webp,
            _ => XlImageFormat.Png
        };
    }

    private static IReadOnlyList<double?> ReadColumnWidths(HtmlNode table)
    {
        var columns = table.SelectNodes("./colgroup/col") ?? new HtmlNodeCollection(null);
        return columns.Select(column =>
        {
            return TryReadLength(column, "width", out var width) ? (double?)width : null;
        }).ToList();
    }

    private static int ReadSpan(HtmlNode node, string name)
    {
        var value = node.GetAttributeValue(name, "1");
        return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var span) && span > 0
            ? span
            : 1;
    }

    internal enum XlImageFormat
    {
        Png,
        Jpeg,
        Gif,
        Bmp,
        Tiff,
        Webp
    }
}
