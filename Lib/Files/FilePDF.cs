using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DMS.Lib.Files
{
    public static class FilePDF
    {
        public static string ExportTemplateToPdf(
            string templatePath,
            string outputFolder,
            string outputFileName,
            string jsonReplacements,
            string signType,
            string userFullName)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Không tìm thấy file PDF gốc: {templatePath}");

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string finalPdfPath = Path.Combine(outputFolder, $"{outputFileName}.pdf");
            string tempSignPath = Path.Combine(outputFolder, $"{outputFileName}_sign.png");

            var replacements = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonReplacements)
                              ?? new Dictionary<string, object>();

            string tempTemplate = Path.Combine(Path.GetTempPath(), Path.GetFileName(templatePath));
            File.Copy(templatePath, tempTemplate, true);

            using (var reader = new PdfReader(tempTemplate))
            using (var writer = new PdfWriter(finalPdfPath))
            using (var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer))
            {
                var doc = new Document(pdfDoc);

                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    var page = pdfDoc.GetPage(i);
                    var pageSize = page.GetPageSize();

                    // --- Chèn ký nếu có
                    foreach (var kv in replacements)
                    {
                        string key = kv.Key;
                        string val = kv.Value?.ToString()?.Trim() ?? "";

                        if (key.StartsWith("@SignLink_C99", StringComparison.OrdinalIgnoreCase))
                        {
                            string imagePath = val;
                            string ext = Path.GetExtension(val)?.ToLower();

                            if (ext == ".svg")
                            {
                                imagePath = ProcessSvgSignature(val, tempSignPath, userFullName);
                            }

                            if (File.Exists(imagePath))
                            {
                                var imgData = ImageDataFactory.Create(imagePath);
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

            if (File.Exists(tempSignPath))
                File.Delete(tempSignPath);

            return finalPdfPath;
        }

        /// <summary>
        /// Xử lý file SVG: thay biến, đổi màu, convert sang PNG tạm.
        /// </summary>
        private static string ProcessSvgSignature(string svgPath, string tempSignPath, string userFullName)
        {
            string svgContent = File.ReadAllText(svgPath);

            // Thay giá trị động
            svgContent = svgContent.Replace("@UserName", userFullName)
                                   .Replace("@NgayKy", DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));

            // Đổi fill trắng thành trong suốt
            svgContent = Regex.Replace(svgContent, "fill\\s*=\\s*\"white\"", "fill=\"none\"", RegexOptions.IgnoreCase);

            // Ghi ra file SVG tạm
            string tempSvgPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(svgPath));
            File.WriteAllText(tempSvgPath, svgContent);

            // Convert sang PNG
            FileSVG.ReplaceAndConvertSvgToPng(tempSvgPath, tempSignPath, new Dictionary<string, string>(), 1000, 500);

            return tempSignPath;
        }
    }
}
