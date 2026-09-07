namespace OsControl.Lib.Files
{
    public class PdfSocket
    {

        public static void ConvertExcelToPdfBySocket(string inputPath, string outputDir)
        {
            if (!File.Exists(inputPath))
                throw new FileNotFoundException(inputPath);

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "soffice.exe",
                Arguments = $"--headless --convert-to pdf --outdir \"{outputDir}\" \"{inputPath}\" --accept=\"socket,host=127.0.0.1,port=8100;urp;\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using var process = System.Diagnostics.Process.Start(psi);
            process.WaitForExit(10000); // timeout 10 giây

            if (process.ExitCode != 0)
            {
                string err = process.StandardError.ReadToEnd();
                throw new Exception($"LibreOffice convert error: {err}");
            }
        }
    }
}
