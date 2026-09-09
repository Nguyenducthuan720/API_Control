using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using HtmlAgilityPack;
using W = DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using WP = DocumentFormat.OpenXml.Drawing.Wordprocessing;

namespace DMS.Lib.Files;

/// <summary>
/// Converts the supported fixed HTML contract into a DOCX document.
/// It intentionally maps tables, text and embedded images only.
/// </summary>
public static class FileHTMLToWord
{
    private const string PictureRelationshipUri =
        "http://schemas.openxmlformats.org/drawingml/2006/picture";

    public static string ExportHtmlToWord(string htmlPath, string outputPath)
    {
        if (!File.Exists(htmlPath))
            throw new FileNotFoundException("Không tìm thấy file HTML đã render.", htmlPath);

        var document = HtmlTableParser.LoadDocument(File.ReadAllText(htmlPath));
        var tables = HtmlTableParser.ParseTables(document);
        if (tables.Count == 0)
            throw new InvalidOperationException("HTML không có bảng được hỗ trợ để xuất Word.");

        var outputDirectory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        using (var wordDocument = WordprocessingDocument.Create(
                   outputPath,
                   WordprocessingDocumentType.Document))
        {
            var mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new W.Document(new W.Body());
            var body = mainPart.Document.Body!;

            AppendFlowNodes(document.DocumentNode.SelectSingleNode("//body") ?? document.DocumentNode,
                body,
                mainPart);

            body.Append(new W.SectionProperties(
                new W.PageSize { Width = 11906, Height = 16838 },
                new W.PageMargin { Top = 0, Right = 0, Bottom = 0, Left = 0 }));
            mainPart.Document.Save();
        }

        return outputPath;
    }

    private static void AppendFlowNodes(HtmlNode parent, W.Body body, MainDocumentPart mainPart)
    {
        foreach (var child in parent.ChildNodes)
        {
            if (child.NodeType != HtmlNodeType.Element)
                continue;

            if (string.Equals(child.Name, "table", StringComparison.OrdinalIgnoreCase))
            {
                body.Append(BuildTable(child, mainPart));
                continue;
            }

            if (string.Equals(child.Name, "img", StringComparison.OrdinalIgnoreCase))
            {
                body.Append(BuildImageParagraph(child, mainPart));
                continue;
            }

            if (IsTextBlock(child))
            {
                var paragraph = BuildParagraph(child, mainPart);
                if (paragraph.ChildElements.Count > 0)
                    body.Append(paragraph);
                continue;
            }

            AppendFlowNodes(child, body, mainPart);
        }
    }

    private static bool IsTextBlock(HtmlNode node)
    {
        return node.Name is "p" or "div" or "section" or "main" or "h1" or "h2" or "h3" or "h4";
    }

    private static W.Table BuildTable(HtmlNode tableNode, MainDocumentPart mainPart)
    {
        var table = HtmlTableParser.ParseTables(HtmlTableParser.LoadDocument(tableNode.OuterHtml)).First();
        var wordTable = new W.Table();
        wordTable.Append(BuildTableProperties(table));

        var grid = new W.TableGrid();
        for (var column = 1; column <= table.ColumnCount; column++)
        {
            var width = table.ColumnWidths.ElementAtOrDefault(column - 1) ?? 96d;
            grid.Append(new W.GridColumn { Width = PixelsToTwips(width).ToString() });
        }
        wordTable.Append(grid);

        for (var row = 1; row <= table.RowCount; row++)
        {
            var wordRow = new W.TableRow();
            var column = 1;
            while (column <= table.ColumnCount)
            {
                if (!table.Occupied.TryGetValue((row, column), out var cell))
                {
                    wordRow.Append(BuildCell(null, 1, false, false, table, mainPart));
                    column++;
                    continue;
                }

                var isOrigin = cell.Row == row && cell.Column == column;
                if (isOrigin)
                {
                    wordRow.Append(BuildCell(cell, cell.ColumnSpan, cell.RowSpan > 1, true, table, mainPart));
                    column += cell.ColumnSpan;
                    continue;
                }

                // A continuation row has one cell for the original colspan.
                if (cell.Row < row && cell.Column == column)
                {
                    wordRow.Append(BuildCell(cell, cell.ColumnSpan, true, false, table, mainPart));
                    column += cell.ColumnSpan;
                }
                else
                {
                    column++;
                }
            }
            wordTable.Append(wordRow);
        }

        return wordTable;
    }

    private static W.TableProperties BuildTableProperties(HtmlTableDefinition table)
    {
        var width = table.ColumnWidths.Sum(value => value ?? 96d);
        return new W.TableProperties(
            new W.TableWidth { Width = PixelsToTwips(width).ToString(), Type = W.TableWidthUnitValues.Dxa },
            new W.TableLayout { Type = W.TableLayoutValues.Fixed },
            new W.TableBorders(
                new W.TopBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.LeftBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.BottomBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.RightBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.InsideHorizontalBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.InsideVerticalBorder { Val = W.BorderValues.Single, Size = 4 }));
    }

    private static W.TableCell BuildCell(
        HtmlCellDefinition cell,
        int columnSpan,
        bool verticalMerge,
        bool restartMerge,
        HtmlTableDefinition table,
        MainDocumentPart mainPart)
    {
        var properties = new W.TableCellProperties();
        var width = cell == null
            ? 96d
            : Enumerable.Range(cell.Column, columnSpan)
                .Sum(column => table.ColumnWidths.ElementAtOrDefault(column - 1) ?? 96d);
        properties.Append(new W.TableCellWidth
        {
            Width = PixelsToTwips(width).ToString(),
            Type = W.TableWidthUnitValues.Dxa
        });
        if (columnSpan > 1)
            properties.Append(new W.GridSpan { Val = columnSpan });
        if (verticalMerge)
            properties.Append(new W.VerticalMerge
            {
                Val = restartMerge ? W.MergedCellValues.Restart : W.MergedCellValues.Continue
            });

        var wordCell = new W.TableCell(properties);
        if (cell != null && restartMerge)
            wordCell.Append(BuildParagraph(cell.Node, mainPart, cell.IsHeader));
        else
            wordCell.Append(new W.Paragraph());
        return wordCell;
    }

    private static W.Paragraph BuildParagraph(HtmlNode node, MainDocumentPart mainPart, bool header = false)
    {
        var paragraph = new W.Paragraph();
        var styles = HtmlTableParser.ParseStyle(node);
        var paragraphProperties = new W.ParagraphProperties();
        if (styles.TryGetValue("text-align", out var alignment))
        {
            paragraphProperties.Append(new W.Justification
            {
                Val = alignment.Trim().ToLowerInvariant() switch
                {
                    "center" => W.JustificationValues.Center,
                    "right" => W.JustificationValues.Right,
                    "justify" => W.JustificationValues.Both,
                    _ => W.JustificationValues.Left
                }
            });
        }
        paragraph.Append(paragraphProperties);

        AppendInlineContent(node, paragraph, mainPart, header);
        return paragraph;
    }

    private static W.Paragraph BuildImageParagraph(HtmlNode image, MainDocumentPart mainPart)
    {
        var paragraph = new W.Paragraph();
        var run = BuildImageRun(image, mainPart, 160, 80);
        if (run != null)
            paragraph.Append(run);
        return paragraph;
    }

    private static void AppendInlineContent(
        HtmlNode node,
        W.Paragraph paragraph,
        MainDocumentPart mainPart,
        bool header)
    {
        foreach (var child in node.ChildNodes)
        {
            if (child.NodeType == HtmlNodeType.Text)
            {
                AppendTextRun(paragraph, HtmlAgilityPack.HtmlEntity.DeEntitize(child.InnerText), header);
                continue;
            }
            if (child.NodeType != HtmlNodeType.Element)
                continue;
            if (string.Equals(child.Name, "img", StringComparison.OrdinalIgnoreCase))
            {
                var run = BuildImageRun(child, mainPart, 180, 60);
                if (run != null) paragraph.Append(run);
                continue;
            }
            if (string.Equals(child.Name, "br", StringComparison.OrdinalIgnoreCase))
            {
                paragraph.Append(new W.Run(new W.Break()));
                continue;
            }
            AppendInlineContent(child, paragraph, mainPart, header);
        }
    }

    private static void AppendTextRun(W.Paragraph paragraph, string text, bool header)
    {
        if (string.IsNullOrEmpty(text))
            return;
        var runProperties = new W.RunProperties();
        if (header)
            runProperties.Append(new W.Bold());
        paragraph.Append(new W.Run(runProperties, new W.Text(text) { Space = SpaceProcessingModeValues.Preserve }));
    }

    private static W.Run BuildImageRun(HtmlNode image, MainDocumentPart mainPart, double defaultWidth, double defaultHeight)
    {
        if (!HtmlTableParser.TryReadDataImage(image, out var bytes, out var mimeType))
            return null;

        var width = HtmlTableParser.TryReadLength(image, "width", out var parsedWidth)
            ? parsedWidth : defaultWidth;
        var height = HtmlTableParser.TryReadLength(image, "height", out var parsedHeight)
            ? parsedHeight : defaultHeight;
        var imagePart = mainPart.AddImagePart(GetImagePartType(mimeType));
        using (var stream = new MemoryStream(bytes))
            imagePart.FeedData(stream);

        var relationshipId = mainPart.GetIdOfPart(imagePart);
        var cx = PixelsToEmu(width);
        var cy = PixelsToEmu(height);
        var picture = new PIC.Picture(
            new PIC.NonVisualPictureProperties(
                new PIC.NonVisualDrawingProperties { Id = 1U, Name = "HTML image" },
                new PIC.NonVisualPictureDrawingProperties()),
            new PIC.BlipFill(
                new A.Blip { Embed = relationshipId },
                new A.Stretch(new A.FillRectangle())),
            new PIC.ShapeProperties(
                new A.Transform2D(
                    new A.Offset { X = 0, Y = 0 },
                    new A.Extents { Cx = cx, Cy = cy }),
                new A.PresetGeometry { Preset = A.ShapeTypeValues.Rectangle }));
        var graphic = new A.Graphic(
            new A.GraphicData(picture) { Uri = PictureRelationshipUri });
        var inline = new WP.Inline(
            new WP.Extent { Cx = cx, Cy = cy },
            new WP.EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
            new WP.DocProperties { Id = 1U, Name = "HTML image" },
            new WP.NonVisualGraphicFrameDrawingProperties(
                new A.GraphicFrameLocks { NoChangeAspect = true }),
            graphic);

        return new W.Run(new W.Drawing(inline));
    }

    private static PartTypeInfo GetImagePartType(string mimeType)
    {
        return mimeType.ToLowerInvariant() switch
        {
            "image/jpeg" or "image/jpg" => ImagePartType.Jpeg,
            "image/gif" => ImagePartType.Gif,
            "image/bmp" => ImagePartType.Bmp,
            "image/tiff" => ImagePartType.Tiff,
            _ => ImagePartType.Png
        };
    }

    private static long PixelsToTwips(double pixels) => Math.Max(1, (long)Math.Round(pixels * 15d));
    private static long PixelsToEmu(double pixels) => Math.Max(1, (long)Math.Round(pixels * 9525d));
}
