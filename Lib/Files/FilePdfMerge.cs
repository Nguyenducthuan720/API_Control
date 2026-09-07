using OsControl.Lib.Files;


namespace DMS.Lib.Files
{
    public static class FilePdfMerge
    {
        public static string MergePdfs(
            List<string> pdfFiles,
            string outputFolder,
            string outputFileName,
            string fileExtension,
            string exportTemplate,
            string folder,
            string safeOid,
            string json,
            string signType,
            string userFullName,
            int isSeal)
        {
            if (pdfFiles == null || pdfFiles.Count == 0)
                throw new ArgumentException("Danh sách file PDF trống hoặc null.", nameof(pdfFiles));

            var sourceFiles = pdfFiles
                .Where(f => File.Exists(f) && string.Equals(Path.GetExtension(f), ".pdf", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (sourceFiles.Count == 0)
                throw new ArgumentException("Không tìm thấy file PDF hợp lệ nào trong danh sách.", nameof(pdfFiles));

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string outputPdfPath = Path.GetFullPath(Path.Combine(outputFolder, $"{outputFileName}.pdf"));
            var activeStreams = new List<MemoryStream>();

            try
            {
                using (var mergedDoc = new PDFiumSharp.PdfDocument())
                {
                    for (int i = 0; i < sourceFiles.Count; i++)
                    {
                        string currentFile = sourceFiles[i];

                        // File đầu tiên (file trình ký) hoặc không cần đóng dấu -> Nạp trực tiếp từ file
                        if (i == 0 || isSeal != 1)
                        {
                            using var sourceDoc = new PDFiumSharp.PdfDocument(currentFile);
                            AppendPages(sourceDoc, mergedDoc);
                        }
                        else
                        {
                            // Xuất mẫu trực tiếp ra MemoryStream (In-Memory)
                            var pdfStream = MemoryPDF.ExportTemplateToPdfStream(
                                currentFile,
                                json,
                                signType,
                                userFullName
                            );

                            if (pdfStream != null && pdfStream.Length > 0)
                            {
                                activeStreams.Add(pdfStream);
                                using var sourceDoc = new PDFiumSharp.PdfDocument(pdfStream.ToArray());
                                AppendPages(sourceDoc, mergedDoc);
                            }
                            else
                            {
                                using var sourceDoc = new PDFiumSharp.PdfDocument(currentFile);
                                AppendPages(sourceDoc, mergedDoc);
                            }
                        }
                    }

                    mergedDoc.Save(outputPdfPath);
                }
            }
            finally
            {
                foreach (var stream in activeStreams)
                {
                    stream.Dispose();
                }
            }

            if (!File.Exists(outputPdfPath))
                throw new FileNotFoundException($"File PDF gộp không được tạo tại {outputPdfPath}");

            return outputPdfPath;
        }

        private static void AppendPages(PDFiumSharp.PdfDocument sourceDoc, PDFiumSharp.PdfDocument targetDoc)
        {
            foreach (var page in sourceDoc.Pages)
            {
                targetDoc.Pages.Add(sourceDoc, page.Index);
            }
        }
    }
}