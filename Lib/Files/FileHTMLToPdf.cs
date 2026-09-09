using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace DMS.Lib.Files;

/// <summary>Creates PDF from the already-rendered HTML document.</summary>
public static class FileHTMLToPdf
{
    public static string ExportHtmlToPdf(string htmlPath, string outputPath, IConverter converter)
    {
        if (!File.Exists(htmlPath))
            throw new FileNotFoundException("Không tìm thấy file HTML đã render.", htmlPath);
        if (converter == null)
            throw new ArgumentNullException(nameof(converter));

        var outputDirectory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        var document = new HtmlToPdfDocument
        {
            GlobalSettings =
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                DocumentTitle = Path.GetFileNameWithoutExtension(htmlPath)
            },
            Objects =
            {
                new ObjectSettings
                {
                    Page = new Uri(Path.GetFullPath(htmlPath)).AbsoluteUri,
                    WebSettings =
                    {
                        Background = true,
                        LoadImages = true,
                        EnableJavascript = false,
                        PrintMediaType = true,
                        DefaultEncoding = "utf-8"
                    }
                }
            }
        };

        var bytes = converter.Convert(document);
        File.WriteAllBytes(outputPath, bytes);
        return outputPath;
    }
}
