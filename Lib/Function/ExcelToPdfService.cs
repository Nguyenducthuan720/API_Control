using System.Diagnostics;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;

namespace APISmartCity.Services
{
    public class ExcelToPdfService
    {
        private readonly string _libreOfficePath;
        private readonly string _tempPath;
        private readonly string _userPath;
        private readonly HttpClient _httpClient;
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(15);

        public ExcelToPdfService(ILogger<ExcelToPdfService> logger, IConfiguration configuration)
        {
            _libreOfficePath = Path.Combine(configuration["LibreOffice:Path"], "soffice.exe");
            _tempPath = configuration["LibreOffice:TempPath"];
            _userPath = configuration["LibreOffice:UserPath"];
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
        }

        public async Task<MemoryStream> ConvertXlsToXlsxAsync(Stream inputStream, string fileExtension, string factorID, string entryID)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                if (fileExtension.ToLower() != ".xls")
                {
                    inputStream.Position = 0;
                    var outputStream = new MemoryStream();
                    await inputStream.CopyToAsync(outputStream);
                    return outputStream;
                }

                string tempDirectory = Path.Combine(_tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempDirectory);

                string inputXlsPath = Path.Combine(tempDirectory, $"{factorID}_{entryID}.xls");
                string outputXlsxPath = Path.Combine(tempDirectory, $"{factorID}_{entryID}.xlsx");

                using (var fileStream = new FileStream(inputXlsPath, FileMode.Create, FileAccess.Write))
                {
                    await inputStream.CopyToAsync(fileStream);
                }

                var processInfo = new ProcessStartInfo
                {
                    FileName = _libreOfficePath,
                    Arguments = $"--headless --convert-to xlsx --outdir \"{tempDirectory}\" \"{inputXlsPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = processInfo })
                {
                    process.Start();
                    var processTask = process.WaitForExitAsync();
                    var completedTask = await Task.WhenAny(processTask, Task.Delay(_timeout));
                    if (completedTask != processTask)
                        throw new TimeoutException("Convert XLS to XLSX exceeded 15 seconds");

                    await processTask; // Ensure process completes

                    using (var xlsxStream = new FileStream(outputXlsxPath, FileMode.Open, FileAccess.Read))
                    {
                        var resultStream = new MemoryStream();
                        await xlsxStream.CopyToAsync(resultStream);
                        resultStream.Position = 0;
                        Directory.Delete(tempDirectory, true);
                        return resultStream;
                    }
                }
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        private async Task<string> DownloadSvgAsync(string url)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var responseTask = _httpClient.GetAsync(url);
                var completedTask = await Task.WhenAny(responseTask, Task.Delay(_timeout));
                if (completedTask != responseTask)
                    throw new TimeoutException($"Download SVG from {url} exceeded 15 seconds");

                var response = await responseTask;
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"Lỗi khi tải SVG từ {url}: {ex.Message}";
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        public string ModifySvgContent(string svgContent, string userSignature, string dateTime)
        {
            var stopwatch = Stopwatch.StartNew();
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
                return $"Lỗi khi sửa SVG: {ex.Message}";
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        private async Task<byte[]> ConvertSvgToPng(string svgContent)
        {
            var stopwatch = Stopwatch.StartNew();
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

                using (var process = new Process { StartInfo = processInfo })
                {
                    process.Start();
                    var processTask = process.WaitForExitAsync();
                    var completedTask = await Task.WhenAny(processTask, Task.Delay(_timeout));
                    if (completedTask != processTask)
                        throw new TimeoutException("Convert SVG to PNG exceeded 15 seconds");

                    await processTask; // Ensure process completes
                    byte[] imageBytes = await File.ReadAllBytesAsync(pngFilePath);
                    if (Directory.Exists(tempDirectory)) Directory.Delete(tempDirectory, true);
                    return imageBytes;
                }
            }
            catch (Exception ex)
            {
                return Array.Empty<byte>();
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        public async Task<MemoryStream> ReplacePlaceholdersAsync(Stream inputStream, Dictionary<string, string> parameters, string SignNumber, string imageHeight, string imageWidth)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var tempStream = new MemoryStream();
                inputStream.Position = 0;
                await inputStream.CopyToAsync(tempStream);
                tempStream.Position = 0;

                using var spreadsheetDoc = SpreadsheetDocument.Open(tempStream, true);
                var workbookPart = spreadsheetDoc.WorkbookPart;
                var sheets = workbookPart.Workbook.Descendants<Sheet>().ToList();

                foreach (var sheet in sheets)
                {
                    var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                    var worksheet = worksheetPart.Worksheet;
                    var sheetData = worksheet.GetFirstChild<SheetData>();

                    // Bước 1: Xử lý dynamic rows cho lists
                    var rows = sheetData.Elements<Row>().ToList();
                    for (int i = 0; i < rows.Count; i++)
                    {
                        var cells = rows[i].Elements<Cell>().ToList();
                        var listPlaceholderCell = cells.FirstOrDefault(c => GetCellText(workbookPart, c)?.Contains("@List", StringComparison.OrdinalIgnoreCase) ?? false);
                        if (listPlaceholderCell == null) continue;

                        string listPlaceholder = GetCellText(workbookPart, listPlaceholderCell)?.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries)
                            .FirstOrDefault(s => s.StartsWith("List", StringComparison.OrdinalIgnoreCase));

                        if (listPlaceholder == null) continue;

                        string listKey = $"@List{listPlaceholder}";
                        if (!parameters.TryGetValue(listKey, out string jsonItems) || string.IsNullOrEmpty(jsonItems)) continue;

                        var items = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonItems);
                        if (items == null || !items.Any()) continue;

                        var templateRow = rows[i].CloneNode(true) as Row;
                        rows[i].Remove(); // Xóa template row

                        uint newRowIndex = templateRow.RowIndex.Value + 1;
                        foreach (var item in items)
                        {
                            var newRow = templateRow.CloneNode(true) as Row;
                            newRow.RowIndex = newRowIndex++;

                            var newCells = newRow.Elements<Cell>().ToList();
                            foreach (var cell in newCells)
                            {
                                string cellText = GetCellText(workbookPart, cell);
                                if (cellText == null) continue;

                                foreach (var kvp in item)
                                {
                                    cellText = cellText.Replace($"@List{listPlaceholder}{kvp.Key}", kvp.Value, StringComparison.OrdinalIgnoreCase);
                                }

                                SetCellText(workbookPart, cell, cellText);
                            }

                            sheetData.InsertAfter(newRow, rows[i - 1]); // Chèn sau row trước template
                        }

                        rows = sheetData.Elements<Row>().ToList();
                        i--; // Điều chỉnh index vì rows thay đổi
                    }

                    // Bước 2: Xử lý placeholders chữ ký (@SignatureLink_)
                    var allCells = sheetData.Descendants<Cell>().ToList();
                    foreach (var param in parameters.Where(p => p.Key.StartsWith("@SignLink_")))
                    {
                        string suffix = param.Key.Replace("@SignLink_", "");
                        string url = param.Value;
                        string userSignature = parameters.GetValueOrDefault($"@SignName_{suffix}", "");

                        var signatureCells = allCells.Where(c => GetCellText(workbookPart, c)?.Contains(param.Key, StringComparison.OrdinalIgnoreCase) ?? false).ToList();

                        if (string.IsNullOrEmpty(userSignature))
                        {
                            foreach (var cell in signatureCells)
                            {
                                SetCellText(workbookPart, cell, "");
                            }
                            continue;
                        }

                        string dateTime = parameters.GetValueOrDefault($"@DatetimeSignature_{suffix}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        var svgTask = DownloadSvgAsync(url);
                        var completedSvgTask = await Task.WhenAny(svgTask, Task.Delay(_timeout));
                        if (completedSvgTask != svgTask)
                            throw new TimeoutException($"Download SVG for signature {suffix} exceeded 15 seconds");

                        string svgContent = await svgTask;
                        if (string.IsNullOrEmpty(svgContent)) continue;

                        string modifiedSvg = ModifySvgContent(svgContent, userSignature, dateTime);
                        var pngTask = ConvertSvgToPng(modifiedSvg);
                        var completedPngTask = await Task.WhenAny(pngTask, Task.Delay(_timeout));
                        if (completedPngTask != pngTask)
                            throw new TimeoutException($"Convert SVG to PNG for signature {suffix} exceeded 15 seconds");

                        byte[] pngBytes = await pngTask;
                        if (pngBytes.Length == 0) continue;

                        foreach (var cell in signatureCells)
                        {
                            string cellReference = cell.CellReference?.Value;
                            if (string.IsNullOrEmpty(cellReference)) continue;

                            var (rowIndex, colIndex) = GetRowAndColumnIndex(cellReference);
                            var drawingsPart = worksheetPart.DrawingsPart;
                            if (drawingsPart == null)
                            {
                                drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                                worksheetPart.Worksheet.Append(new DocumentFormat.OpenXml.Spreadsheet.Drawing { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                            }

                            if (drawingsPart.WorksheetDrawing == null)
                            {
                                drawingsPart.WorksheetDrawing = new DocumentFormat.OpenXml.Drawing.Spreadsheet.WorksheetDrawing();
                            }

                            ImagePart imagePart = drawingsPart.AddImagePart(ImagePartType.Png);
                            string imagePartId = drawingsPart.GetIdOfPart(imagePart);
                            using (var imageStream = new MemoryStream(pngBytes))
                            {
                                imagePart.FeedData(imageStream);
                            }

                            int w = int.TryParse(imageWidth, out int tmpW) ? tmpW : 240;
                            int h = int.TryParse(imageHeight, out int tmpH) ? tmpH : 80;

                            long cx = w * 9525L;
                            long cy = h * 9525L;


                            var twoCellAnchor = new DocumentFormat.OpenXml.Drawing.Spreadsheet.TwoCellAnchor
                            {
                                FromMarker = new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker
                                {
                                    ColumnId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.ColumnId { Text = colIndex.ToString() },
                                    ColumnOffset = new DocumentFormat.OpenXml.Drawing.Spreadsheet.ColumnOffset { Text = "0" },
                                    RowId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowId { Text = (rowIndex - 1).ToString() },
                                    RowOffset = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowOffset { Text = "0" }
                                },
                                ToMarker = new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker
                                {
                                    ColumnId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.ColumnId { Text = (colIndex + 1).ToString() },
                                    ColumnOffset = new DocumentFormat.OpenXml.Drawing.Spreadsheet.ColumnOffset { Text = "0" },
                                    RowId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowId { Text = rowIndex.ToString() },
                                    RowOffset = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowOffset { Text = "0" }
                                }
                            };

                            var picture = new DocumentFormat.OpenXml.Drawing.Spreadsheet.Picture
                            {
                                NonVisualPictureProperties = new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualPictureProperties
                                {
                                    NonVisualDrawingProperties = new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties
                                    {
                                        Id = new UInt32Value((uint)drawingsPart.WorksheetDrawing.ChildElements.Count + 1),
                                        Name = $"Signature_{suffix}"
                                    },
                                    NonVisualPictureDrawingProperties = new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualPictureDrawingProperties()
                                },
                                BlipFill = new DocumentFormat.OpenXml.Drawing.Spreadsheet.BlipFill
                                {
                                    Blip = new DocumentFormat.OpenXml.Drawing.Blip { Embed = imagePartId }
                                },
                                ShapeProperties = new DocumentFormat.OpenXml.Drawing.Spreadsheet.ShapeProperties
                                {
                                    Transform2D = new DocumentFormat.OpenXml.Drawing.Transform2D
                                    {
                                        Offset = new DocumentFormat.OpenXml.Drawing.Offset { X = 0, Y = 0 },
                                        Extents = new DocumentFormat.OpenXml.Drawing.Extents { Cx = cx, Cy = cy }
                                    }
                                }
                            };

                            twoCellAnchor.Append(picture);
                            drawingsPart.WorksheetDrawing.Append(twoCellAnchor);
                            SetCellText(workbookPart, cell, "");
                        }
                    }

                    // Bước 3: Thay thế các placeholder text đơn giản
                    foreach (var cell in allCells)
                    {
                        string cellText = GetCellText(workbookPart, cell);
                        if (cellText == null) continue;
                        foreach (var param in parameters.Where(p => !p.Key.StartsWith("@SignatureLink_") && !p.Key.StartsWith("@List")))
                        {
                            cellText = cellText.Replace(param.Key, param.Value, StringComparison.OrdinalIgnoreCase);
                        }
                        SetCellText(workbookPart, cell, cellText);
                    }
                    worksheet.Save();
                }

                spreadsheetDoc.Save();
                tempStream.Position = 0;
                return tempStream;
            }
            catch (OpenXmlPackageException ex)
            {
                throw new Exception("Tài liệu Excel không hợp lệ hoặc bị hỏng.", ex);
            }
            catch (IOException ex)
            {
                throw new Exception("Lỗi khi đọc/ghi tài liệu.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Lỗi khi parse JSON dữ liệu danh sách.", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        public async Task<MemoryStream> ConvertXlsxToPdfAsync(Stream xlsxStream, Dictionary<string, double>? timings = null)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var tempXlsxFileName = $"{Guid.NewGuid()}.xlsx";
                var tempXlsxFilePath = Path.Combine(_tempPath, tempXlsxFileName);
                var tempPdfFileName = $"{Path.GetFileNameWithoutExtension(tempXlsxFileName)}.pdf";
                var tempPdfFilePath = Path.Combine(_tempPath, tempPdfFileName);

                using (var fileStream = new FileStream(tempXlsxFilePath, FileMode.Create, FileAccess.Write))
                {
                    await xlsxStream.CopyToAsync(fileStream);
                }

                var userProfilePath = _userPath;

                var processInfo = new ProcessStartInfo
                {
                    FileName = _libreOfficePath,
                    Arguments = $"-env:UserInstallation=file:///{userProfilePath.Replace("\\", "/")} " +
                                $"--headless --nologo --norestore --convert-to pdf --outdir \"{_tempPath}\" \"{tempXlsxFilePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = _tempPath,
                    EnvironmentVariables = { ["HOME"] = @"ConvertTemp" }
                };

                using (var process = new Process { StartInfo = processInfo })
                {
                    process.Start();
                    var processTask = process.WaitForExitAsync();
                    var completedTask = await Task.WhenAny(processTask, Task.Delay(_timeout));
                    if (completedTask != processTask)
                        throw new TimeoutException("Convert XLSX to PDF exceeded 15 seconds");

                    await processTask; // Ensure process completes
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();

                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"LibreOffice conversion failed: {error}");
                    }
                }

                var pdfStream = new MemoryStream();
                using (var pdfFileStream = new FileStream(tempPdfFilePath, FileMode.Open, FileAccess.Read))
                {
                    await pdfFileStream.CopyToAsync(pdfStream);
                }
                pdfStream.Position = 0;

                if (File.Exists(tempXlsxFilePath)) File.Delete(tempXlsxFilePath);
                if (File.Exists(tempPdfFilePath)) File.Delete(tempPdfFilePath);

                return pdfStream;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (timings != null)
                {
                    timings["ConvertXlsxToPdf"] = stopwatch.Elapsed.TotalSeconds;
                }
            }
        }

        private (int rowIndex, int colIndex) GetRowAndColumnIndex(string cellReference)
        {
            var regex = new Regex(@"([A-Z]+)(\d+)");
            var match = regex.Match(cellReference);
            if (!match.Success)
                return (0, 0);

            string col = match.Groups[1].Value;
            int row = int.Parse(match.Groups[2].Value);

            int colIndex = 0;
            for (int i = 0; i < col.Length; i++)
            {
                colIndex = colIndex * 26 + (col[i] - 'A' + 1);
            }

            return (row, colIndex - 1);
        }

        private string GetCellText(WorkbookPart workbookPart, Cell cell)
        {
            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                int id = int.Parse(cell.CellValue?.Text ?? "0");
                return workbookPart.SharedStringTablePart.SharedStringTable.ElementAt(id).InnerText;
            }
            return cell.CellValue?.Text;
        }

        private void SetCellText(WorkbookPart workbookPart, Cell cell, string text)
        {
            var sharedStringTablePart = workbookPart.SharedStringTablePart ?? workbookPart.AddNewPart<SharedStringTablePart>();
            var sharedStringTable = sharedStringTablePart.SharedStringTable ?? new SharedStringTable();

            int index = InsertSharedStringItem(text, sharedStringTable);
            cell.CellValue = new CellValue(index.ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        private int InsertSharedStringItem(string text, SharedStringTable sharedStringTable)
        {
            int i = 0;
            foreach (SharedStringItem item in sharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text) return i;
                i++;
            }

            sharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
            return i;
        }
    }
}