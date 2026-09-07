using iText.IO.Image;
using iText.Layout;
using SkiaSharp;
using Svg.Skia;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace OsControl.Lib.Files
{
    public static class MemoryPDF
    {
        public static string ExportTemplateToPdf(
            string templatePath,
            string outputFolder,
            string outputFileName,
            string jsonReplacements,
            string signType,
            string userFullName)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string finalPdfPath = Path.Combine(outputFolder, $"{outputFileName}.pdf");

            using var pdfStream = ExportTemplateToPdfStream(templatePath, jsonReplacements, signType, userFullName);
            File.WriteAllBytes(finalPdfPath, pdfStream.ToArray());

            return finalPdfPath;
        }

        public static MemoryStream ExportTemplateToPdfStream(
            string templatePath,
            string jsonReplacements,
            string signType,
            string userFullName)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Không tìm thấy file PDF gốc: {templatePath}");

            var outputStream = new MemoryStream();

            var replacements = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonReplacements)
                              ?? new Dictionary<string, object>();

            using (var readerStream = File.OpenRead(templatePath))
            using (var reader = new iText.Kernel.Pdf.PdfReader(readerStream))
            using (var writer = new iText.Kernel.Pdf.PdfWriter(outputStream))
            {
                writer.SetCloseStream(false);

                using (var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer))
                {
                    var doc = new Document(pdfDoc);

                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        var page = pdfDoc.GetPage(i);
                        var pageSize = page.GetPageSize();

                        foreach (var kv in replacements)
                        {
                            string key = kv.Key;
                            string val = kv.Value?.ToString()?.Trim() ?? "";

                            if (key.StartsWith("@SignLink_C99", StringComparison.OrdinalIgnoreCase))
                            {
                                byte[] imageBytes = null;
                                string ext = Path.GetExtension(val)?.ToLower();

                                if (ext == ".svg")
                                {
                                    imageBytes = ProcessSvgSignatureToBytes(val, userFullName);
                                }
                                else if (File.Exists(val))
                                {
                                    imageBytes = File.ReadAllBytes(val);
                                }

                                if (imageBytes != null && imageBytes.Length > 0)
                                {
                                    var imgData = ImageDataFactory.Create(imageBytes);
                                    var img = new iText.Layout.Element.Image(imgData);

                                    float w, h, x, y;

                                    if (pageSize.GetHeight() > pageSize.GetWidth()) // Trang dọc
                                    {
                                        w = pageSize.GetWidth() / 3f;
                                        h = pageSize.GetHeight() / 12f;
                                    }
                                    else // Trang ngang
                                    {
                                        w = pageSize.GetWidth() / 8f;
                                        h = pageSize.GetHeight() / 2f;
                                    }

                                    x = (pageSize.GetWidth() - w) / 2f;
                                    y = (pageSize.GetHeight() - h) / 2f;

                                    img.SetFixedPosition(i, x, y, w);
                                    img.SetAutoScale(false);
                                    img.SetRotationAngle(15 * Math.PI / 180);

                                    doc.Add(img);
                                }
                            }
                        }
                    }

                    doc.Close();
                }
            }

            outputStream.Position = 0;
            return outputStream;
        }

        private static byte[] ProcessSvgSignatureToBytes(string svgPath, string userFullName)
        {
            if (!File.Exists(svgPath)) return null;

            string svgContent = File.ReadAllText(svgPath);

            svgContent = svgContent.Replace("@UserName", userFullName)
                                   .Replace("@NgayKy", DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));

            svgContent = Regex.Replace(svgContent, "fill\\s*=\\s*\"white\"", "fill=\"none\"", RegexOptions.IgnoreCase);

            return ConvertSvgToPngBytes(svgContent, 1000, 500);
        }

        private static byte[] ConvertSvgToPngBytes(string svgContent, int width = 0, int height = 0)
        {
            if (string.IsNullOrEmpty(svgContent)) return null;

            using var svg = new SKSvg();
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svgContent));
            svg.Load(stream);

            if (svg.Picture == null)
                throw new InvalidOperationException("Không thể render được SVG sau khi replace.");

            var rect = svg.Picture.CullRect;
            if (width == 0) width = (int)rect.Width;
            if (height == 0) height = (int)rect.Height;

            using var bitmap = new SKBitmap(width, height);
            using var canvas = new SKCanvas(bitmap);
            canvas.Clear(SKColors.Transparent);

            float scaleX = width / rect.Width;
            float scaleY = height / rect.Height;
            canvas.Scale(scaleX, scaleY);
            canvas.DrawPicture(svg.Picture);
            canvas.Flush();

            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }
    }
}

