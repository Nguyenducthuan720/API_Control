using System.Diagnostics;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;

namespace APISmartCity.Services
{
    public class WordToPdfService
    {
        private readonly string _libreOfficePath;
        private readonly string _tempPath;
        private readonly string _userPath;
        private readonly HttpClient _httpClient;

        public WordToPdfService(ILogger<WordToPdfService> logger, IConfiguration configuration)
        {
            _libreOfficePath = Path.Combine(configuration["LibreOffice:Path"], "soffice.exe");
            _tempPath = configuration["LibreOffice:TempPath"];
            _userPath = configuration["LibreOffice:UserPath"];
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
        }

        public async Task<MemoryStream> ConvertDocToDocxAsync(Stream inputStream, string fileExtension, string factorID, string entryID)
        {
            if (fileExtension.ToLower() != ".doc")
            {
                inputStream.Position = 0;
                var outputStream = new MemoryStream();
                await inputStream.CopyToAsync(outputStream);
                return outputStream;
            }

            string tempDirectory = Path.Combine(_libreOfficePath, Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            string inputDocPath = Path.Combine(tempDirectory, $"{factorID}_{entryID}.doc");
            string inputDocxPath = Path.Combine(tempDirectory, $"{factorID}_{entryID}.docx");

            using (var fileStream = new FileStream(inputDocPath, FileMode.Create, FileAccess.Write))
            {
                await inputStream.CopyToAsync(fileStream);
            }

            var processInfo = new ProcessStartInfo
            {
                FileName = _libreOfficePath,
                Arguments = $"--headless --convert-to docx --outdir \"{tempDirectory}\" \"{inputDocPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processInfo })
            {
                process.Start();
                await process.WaitForExitAsync();

                using (var docxStream = new FileStream(inputDocxPath, FileMode.Open, FileAccess.Read))
                {
                    var resultStream = new MemoryStream();
                    await docxStream.CopyToAsync(resultStream);
                    resultStream.Position = 0;
                    return resultStream;
                }
            }
        }

        private async Task<string> DownloadSvgAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ($"Lỗi khi tải SVG từ {url}: {ex.Message}");
            }
        }

        public string ModifySvgContent(string svgContent, string userSignature, string dateTime)
        {
            try
            {
                string modifiedSvg = Regex.Replace(svgContent, @"<text([^>]*)>UserSignature</text>",
                    $"<text$1>{userSignature}</text>");
                modifiedSvg = Regex.Replace(modifiedSvg, @"<text([^>]*)>DatetimeSignature</text>",
                    $"<text$1>{dateTime}</text>");
                return modifiedSvg;
            }
            catch (Exception ex)
            {
                return ($"Lỗi khi sửa SVG: {ex.Message}");
            }
        }

        private async Task<byte[]> ConvertSvgToPng(string svgContent)
        {
            try
            {
                string tempDirectory = Path.Combine(_tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempDirectory);
                string svgFilePath = Path.Combine(tempDirectory, "temp.svg");
                string pngFilePath = Path.Combine(tempDirectory, "temp.png");
                await File.WriteAllTextAsync(svgFilePath, svgContent);

                var processInfo = new ProcessStartInfo
                {
                    FileName = _libreOfficePath,
                    Arguments = $"--headless --convert-to png --outdir \"{tempDirectory}\" \"{svgFilePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Chạy LibreOffice
                using (var process = new Process { StartInfo = processInfo })
                {
                    process.Start();
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    await process.WaitForExitAsync();
                }
                byte[] imageBytes = await File.ReadAllBytesAsync(pngFilePath);
                // Xóa thư mục tạm
                if (Directory.Exists(tempDirectory)) Directory.Delete(tempDirectory, true);
                return imageBytes;
            }
            catch (Exception ex)
            {
                return Array.Empty<byte>();
            }
        }
        public async Task<MemoryStream> ReplacePlaceholdersAsync(Stream inputStream, Dictionary<string, string> parameters)
        {
            try
            {
                // Sao chép input stream vào MemoryStream
                var tempStream = new MemoryStream();
                inputStream.Position = 0;
                await inputStream.CopyToAsync(tempStream);
                tempStream.Position = 0;

                // Mở tài liệu Word để chỉnh sửa
                using var wordDoc = WordprocessingDocument.Open(tempStream, true);

                // Thay thế placeholder văn bản trong phần thân, header, footer
                ReplacePlaceholdersInElement(wordDoc.MainDocumentPart.Document, parameters);
                foreach (var headerPart in wordDoc.MainDocumentPart.HeaderParts)
                    ReplacePlaceholdersInElement(headerPart.Header, parameters);
                foreach (var footerPart in wordDoc.MainDocumentPart.FooterParts)
                    ReplacePlaceholdersInElement(footerPart.Footer, parameters);

                // Xử lý các placeholder chữ ký (@SignatureLink_)
                foreach (var param in parameters.Where(p => p.Key.StartsWith("@SignatureLink_")))
                {
                    string suffix = param.Key.Replace("@SignatureLink_", "");
                    string url = param.Value;
                    string userSignature = parameters.GetValueOrDefault($"@UserSignature_{suffix}", "");

                    var textElements = wordDoc.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>()
                        .Where(t => t.Text.Contains(param.Key, StringComparison.OrdinalIgnoreCase)).ToList();

                    // Nếu userSignature rỗng, thay thế @SignatureLink_X bằng chuỗi rỗng
                    if (string.IsNullOrEmpty(userSignature))
                    {
                        foreach (var textElement in textElements)
                        {
                            var parent = textElement.Parent as DocumentFormat.OpenXml.Wordprocessing.Run;
                            var paragraph = parent?.Parent as DocumentFormat.OpenXml.Wordprocessing.Paragraph;

                            string originalText = textElement.Text;
                            if (originalText == param.Key)
                            {
                                // Nếu placeholder là toàn bộ nội dung, xóa Run
                                parent.Remove();
                            }
                            else
                            {
                                // Tách văn bản thành trước, placeholder, sau
                                int placeholderIndex = originalText.IndexOf(param.Key, StringComparison.OrdinalIgnoreCase);
                                string beforeText = originalText.Substring(0, placeholderIndex);
                                string afterText = originalText.Substring(placeholderIndex + param.Key.Length);

                                // Tạo Run mới cho phần trước placeholder (nếu có)
                                if (!string.IsNullOrEmpty(beforeText))
                                {
                                    var beforeRun = new DocumentFormat.OpenXml.Wordprocessing.Run();
                                    beforeRun.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(beforeText));
                                    paragraph.InsertBefore(beforeRun, parent);
                                }

                                // Tạo Run mới cho phần sau placeholder (nếu có)
                                if (!string.IsNullOrEmpty(afterText))
                                {
                                    var afterRun = new DocumentFormat.OpenXml.Wordprocessing.Run();
                                    afterRun.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(afterText));
                                    paragraph.InsertBefore(afterRun, parent);
                                }

                                // Xóa Run chứa placeholder
                                parent.Remove();
                            }
                        }
                        continue;
                    }

                    // Nếu userSignature không rỗng, tiếp tục chèn ảnh
                    string dateTime = parameters.GetValueOrDefault($"@DatetimeSignature_{suffix}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    string svgContent = await DownloadSvgAsync(url);
                    if (string.IsNullOrEmpty(svgContent))
                    {
                        continue;
                    }

                    string modifiedSvg = ModifySvgContent(svgContent, userSignature, dateTime);

                    byte[] pngBytes = await ConvertSvgToPng(modifiedSvg);

                    string imagePartId = "ID_" + Guid.NewGuid().ToString().Replace("-", "");
                    ImagePart imagePart = wordDoc.MainDocumentPart.AddImagePart(ImagePartType.Png, imagePartId);
                    using (var imageStream = new MemoryStream(pngBytes))
                    {
                        imagePart.FeedData(imageStream);
                    }

                    foreach (var textElement in textElements)
                    {
                        var parent = textElement.Parent as DocumentFormat.OpenXml.Wordprocessing.Run;
                        var paragraph = parent?.Parent as DocumentFormat.OpenXml.Wordprocessing.Paragraph;
                        var tableCell = textElement.Ancestors<DocumentFormat.OpenXml.Wordprocessing.TableCell>().FirstOrDefault();

                        // Tính toán kích thước ảnh
                        int defaultWidthPx = 240;
                        int defaultHeightPx = 80;
                        long cx = defaultWidthPx * 9525L;
                        long cy = defaultHeightPx * 9525L;
                        if (tableCell != null)
                        {
                            var cellWidth = tableCell.TableCellProperties?.TableCellWidth?.Width?.Value;
                            if (cellWidth != null)
                            {
                                int cellWidthPx = int.Parse(cellWidth) / 15;
                                int imageWidthPx = Math.Min(defaultWidthPx, cellWidthPx);
                                cx = imageWidthPx * 9525L;
                                cy = (long)(defaultHeightPx * 9525L);
                            }
                        }

                        // Tạo Run chứa ảnh
                        var run = new DocumentFormat.OpenXml.Wordprocessing.Run();
                        var inline = new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline
                        {
                            Extent = new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent { Cx = cx, Cy = cy },
                            DocProperties = new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties
                            {
                                Id = (UInt32Value)1U,
                                Name = "SignatureImage"
                            }
                        };

                        var graphic = new DocumentFormat.OpenXml.Drawing.Graphic
                        {
                            GraphicData = new DocumentFormat.OpenXml.Drawing.GraphicData
                            {
                                Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"
                            }
                        };

                        var picture = new DocumentFormat.OpenXml.Drawing.Pictures.Picture
                        {
                            NonVisualPictureProperties = new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties
                            {
                                NonVisualDrawingProperties = new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties
                                {
                                    Id = (UInt32Value)1U,
                                    Name = "SignatureImage"
                                },
                                NonVisualPictureDrawingProperties = new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                            },
                            BlipFill = new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill
                            {
                                Blip = new DocumentFormat.OpenXml.Drawing.Blip { Embed = imagePartId }
                            },
                            ShapeProperties = new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties
                            {
                                Transform2D = new DocumentFormat.OpenXml.Drawing.Transform2D
                                {
                                    Offset = new DocumentFormat.OpenXml.Drawing.Offset { X = 0, Y = 0 },
                                    Extents = new DocumentFormat.OpenXml.Drawing.Extents { Cx = cx, Cy = cy }
                                }
                            }
                        };

                        graphic.GraphicData.Append(picture);
                        inline.Append(graphic);
                        var drawing = new DocumentFormat.OpenXml.Wordprocessing.Drawing();
                        drawing.Append(inline);
                        run.Append(drawing);

                        // Xử lý placeholder và giữ khoảng trắng
                        string originalText = textElement.Text;
                        if (originalText == param.Key)
                        {
                            // Nếu placeholder là toàn bộ nội dung, thay thế Run bằng ảnh
                            paragraph.ReplaceChild(run, parent);
                        }
                        else
                        {
                            // Tách văn bản thành trước, placeholder, sau
                            int placeholderIndex = originalText.IndexOf(param.Key, StringComparison.OrdinalIgnoreCase);
                            string beforeText = originalText.Substring(0, placeholderIndex);
                            string afterText = originalText.Substring(placeholderIndex + param.Key.Length);

                            // Tạo Run mới cho phần trước placeholder (nếu có)
                            if (!string.IsNullOrEmpty(beforeText))
                            {
                                var beforeRun = new DocumentFormat.OpenXml.Wordprocessing.Run();
                                beforeRun.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(beforeText));
                                paragraph.InsertBefore(beforeRun, parent);
                            }

                            // Chèn Run chứa ảnh
                            paragraph.InsertBefore(run, parent);

                            // Tạo Run mới cho phần sau placeholder (nếu có)
                            if (!string.IsNullOrEmpty(afterText))
                            {
                                var afterRun = new DocumentFormat.OpenXml.Wordprocessing.Run();
                                afterRun.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(afterText));
                                paragraph.InsertAfter(afterRun, run);
                            }

                            // Xóa Run chứa placeholder
                            parent.Remove();
                        }
                    }
                }

                // Lưu tài liệu Word cuối cùng
                wordDoc.Save();
                tempStream.Position = 0;
                return tempStream;
            }
            catch (OpenXmlPackageException ex)
            {
                throw new Exception("Tài liệu Word không hợp lệ hoặc bị hỏng.", ex);
            }
            catch (IOException ex)
            {
                throw new Exception("Lỗi khi đọc/ghi tài liệu.", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ReplacePlaceholdersInElement(OpenXmlElement element, Dictionary<string, string> parameters)
        {
            var textElements = element.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().ToList();
            foreach (var text in textElements)
            {
                foreach (var param in parameters)
                {
                    if (text.Text.Contains(param.Key, StringComparison.OrdinalIgnoreCase) && !param.Key.StartsWith("@SignatureLink_"))
                    {
                        text.Text = text.Text.Replace(param.Key, param.Value);
                    }
                }
            }
        }

        public async Task<MemoryStream> ConvertDocxToPdfAsync(Stream docxStream, Dictionary<string, double>? timings = null)
        {
            try
            {
                var tempDocxFileName = $"{Guid.NewGuid()}.docx";
                var tempDocxFilePath = Path.Combine(_tempPath, tempDocxFileName);
                var tempPdfFileName = $"{Path.GetFileNameWithoutExtension(tempDocxFileName)}.pdf";
                var tempPdfFilePath = Path.Combine(_tempPath, tempPdfFileName);

                try
                {
                    using (var fileStream = new FileStream(tempDocxFilePath, FileMode.Create, FileAccess.Write))
                    {
                        await docxStream.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lưu file DOCX tạm", ex);
                }

                var userProfilePath = _userPath;

                var processInfo = new ProcessStartInfo
                {
                    FileName = _libreOfficePath,
                    Arguments = $"-env:UserInstallation=file:///{userProfilePath.Replace("\\", "/")} " +
                                $"--headless --nologo --norestore --convert-to pdf --outdir \"{_tempPath}\" \"{tempDocxFilePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = _tempPath,
                    EnvironmentVariables = { ["HOME"] = @"ConvertTemp" }
                };

                try
                {

                    using (var process = new Process { StartInfo = processInfo })
                    {
                        process.Start();
                        string output = await process.StandardOutput.ReadToEndAsync();
                        string error = await process.StandardError.ReadToEndAsync();
                        await process.WaitForExitAsync(new CancellationTokenSource(TimeSpan.FromSeconds(120)).Token);

                        if (process.ExitCode != 0)
                        {
                            throw new Exception($"LibreOffice conversion failed: {error}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi chạy LibreOffice để convert PDF", ex);
                }

                var pdfStream = new MemoryStream();
                try
                {
                    using (var pdfFileStream = new FileStream(tempPdfFilePath, FileMode.Open, FileAccess.Read))
                    {
                        await pdfFileStream.CopyToAsync(pdfStream);
                    }
                    pdfStream.Position = 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi đọc file PDF", ex);
                }
                if (File.Exists(tempDocxFilePath)) File.Delete(tempDocxFilePath);
                if (File.Exists(tempPdfFilePath)) File.Delete(tempPdfFilePath);
                return pdfStream;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}