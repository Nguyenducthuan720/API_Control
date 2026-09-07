using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xceed.Words.NET;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Xceed.Document.NET;
using Document = Spire.Doc.Document;
using APISmartCity.Services;
using System.Threading.Tasks;
using OpenXmlPowerTools;

namespace DMS.Lib.Files
{
    public static class FileWord
    {
        public static async Task<string> ExportTemplateToPdf(
            string templatePath,
            string outputFolder,
            string outputFileName,
            string jsonReplacements,
            string signType = "DF",
            string UserFullName = "",
            WordToPdfService wordToPdfService = null)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Không tìm thấy file template: {templatePath}");

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            var replacements = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonReplacements)
                              ?? new Dictionary<string, string>();

            string savedDocPath = Path.Combine(outputFolder, $"{outputFileName}.docx").Replace('/', '\\').Replace(@"\\", @"\");
            string savedPdfPath = Path.Combine(outputFolder, $"{outputFileName}.pdf").Replace('/', '\\').Replace(@"\\", @"\");

            //if (File.Exists(savedDocPath)) File.Delete(savedDocPath);
            //if (File.Exists(savedPdfPath)) File.Delete(savedPdfPath);

            using (var doc = DocX.Load(templatePath))
            {
                foreach (var kv in replacements)
                {
                    string key = kv.Key;
                    if (kv.Value is not string val) continue;
                    val = val?.Trim() ?? "";
                    if (key.StartsWith("@SignName_", StringComparison.OrdinalIgnoreCase) && signType == "DF")
                        val = "";
                    if (key.StartsWith("@SignLink_", StringComparison.OrdinalIgnoreCase))
                    {
                        string imagePath = val;
                        string ext = Path.GetExtension(val)?.ToLower();
                        // Note: Nếu là SVG, thay thế nội dung (@UserName, @NgayKy) và convert sang PNG.
                        if (ext == ".svg")
                        {
                            var replacementsSvg = new Dictionary<string, string>
                            {
                                ["@UserName"] = UserFullName,
                                ["@NgayKy"] = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")
                            };
                            string pngPath = Path.Combine(outputFolder, $"{outputFileName}_{key}.png");
                            FileSVG.ReplaceAndConvertSvgToPng(val, pngPath, replacementsSvg, 400, 150);
                            imagePath = pngPath;
                        }
                        if (File.Exists(imagePath))
                        {
                            // Note: Chèn ảnh vào bảng nếu placeholder ở trong bảng.
                            foreach (var table in doc.Tables)
                            {
                                foreach (var row in table.Rows)
                                {
                                    foreach (var cell in row.Cells)
                                    {
                                        // Copy danh sách để tránh lỗi "Collection was modified"
                                        var cellParagraphs = new List<Xceed.Document.NET.Paragraph>(cell.Paragraphs);
                                        foreach (var para in cellParagraphs)
                                        {
                                            if (para.Text.Contains(key, StringComparison.OrdinalIgnoreCase))
                                            {
                                                para.ReplaceText(key, "");
                                                var pic = doc.AddImage(imagePath).CreatePicture();
                                                // === Auto scale ảnh để vừa khung ô (cả khi ảnh nhỏ) ===
                                                double targetWidth = 110; // max chiều ngang ô
                                                double targetHeight = 55; // max chiều cao ô
                                                // Tính tỉ lệ scale
                                                double scale = Math.Min(targetWidth / pic.Width, targetHeight / pic.Height) - 0.055;
                                                // Giới hạn scale tối đa 1.5 lần (để không vỡ ảnh nếu gốc quá nhỏ)
                                                if (scale > 1.5) scale = 1.5;
                                                pic.Width = (int)(pic.Width * scale);
                                                pic.Height = (int)(pic.Height * scale);
                                                // === Căn giữa ngang + dọc ===
                                                para.Alignment = Alignment.center;
                                                cell.VerticalAlignment = Xceed.Document.NET.VerticalAlignment.Center;
                                                // === Cân chỉnh spacing để hình nằm giữa thật ===
                                                double freeSpace = (targetHeight - pic.Height) / 2;
                                                if (freeSpace < 0) freeSpace = 0;
                                                para.SpacingBefore(freeSpace * 1.0);
                                                para.Alignment = Alignment.left; // giữ left để margin có tác dụng
                                                para.IndentationBefore = 0; // đẩy hình qua phải
                                                para.SpacingAfter(0);
                                                // === Xóa tất cả nội dung cũ còn sót ===
                                                para.RemoveText(0);
                                                // === Chèn ảnh ===
                                                para.InsertPicture(pic);
                                            }
                                        }
                                    }
                                }
                            }

                            // === Duyệt đoạn ngoài bảng ===
                            foreach (var para in doc.Paragraphs)
                            {
                                if (para.Text.Contains(key, StringComparison.OrdinalIgnoreCase))
                                {
                                    para.ReplaceText(key, "");
                                    var pic = doc.AddImage(imagePath).CreatePicture(80, 40);
                                    para.InsertPicture(pic);
                                    para.Alignment = Alignment.center;
                                }
                            }
                        }
                        if (ext == ".svg" && File.Exists(imagePath)) 
                        {
                            try { File.Delete(imagePath); } catch { }
                        }


                    }
                    else
                    {
                        doc.ReplaceText(key, val, false, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    }
                }

                doc.SaveAs(savedDocPath);
            }

            var document = new Document();
            document.LoadFromFile(savedDocPath);
            int pageCount = document.PageCount;

            if (pageCount > 3 && wordToPdfService != null)
            {
                using (var docxStream = new FileStream(savedDocPath, FileMode.Open, FileAccess.Read))
                {
                    var pdfStream = await wordToPdfService.ConvertDocxToPdfAsync(docxStream);
                    using (pdfStream)
                    {
                        using (var fileStream = new FileStream(savedPdfPath, FileMode.Create, FileAccess.Write))
                        {
                            pdfStream.Position = 0;
                            await pdfStream.CopyToAsync(fileStream);
                            await fileStream.FlushAsync();
                        }
                    }
                }
            }
            else
            {
                ExportWordToPdf(savedDocPath, savedPdfPath);
            }

            return savedPdfPath;
        }

        private static void ExportWordToPdf(string docxPath, string pdfPath)
        {
            var document = new Document();
            document.LoadFromFile(docxPath);
            document.SaveToFile(pdfPath, FileFormat.PDF);
        }
    }
}
