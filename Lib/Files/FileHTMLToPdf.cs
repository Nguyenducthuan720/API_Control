using System.Diagnostics;
using System.Text;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace DMS.Lib.Files;

/// <summary>Creates PDF from the already-rendered HTML document.</summary>
public static class FileHTMLToPdf
{
    public static string ExportHtmlToPdf(
        string htmlPath,
        string outputPath,
        IConverter converter,
        string chromiumPath = null)
    {
        htmlPath = ResolveLocalPath(htmlPath);
        outputPath = ResolveLocalPath(outputPath);

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
                DPI = 96,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings
                {
                    Left = 0,
                    Right = 0,
                    Top = 0,
                    Bottom = 0
                },
                ViewportSize = "794x1123",
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
                        EnableIntelligentShrinking = false,
                        PrintMediaType = true,
                        DefaultEncoding = "utf-8"
                    },
                    LoadSettings = new LoadSettings
                    {
                        ZoomFactor = 1.0
                    }
                }
            }
        };

        try
        {
            var bytes = converter.Convert(document);
            File.WriteAllBytes(outputPath, bytes);
            return outputPath;
        }
        catch (Exception exception) when (IsNativeRendererUnavailable(exception))
        {
            return ExportWithChromium(htmlPath, outputPath, chromiumPath, exception);
        }
    }

    private static bool IsNativeRendererUnavailable(Exception exception)
    {
        if (exception is AggregateException aggregate)
            return aggregate.InnerExceptions.Any(IsNativeRendererUnavailable);

        return exception is NotSupportedException or
            DllNotFoundException or
            EntryPointNotFoundException or
            TypeInitializationException ||
            (exception.InnerException != null &&
             IsNativeRendererUnavailable(exception.InnerException));
    }

    private static string ExportWithChromium(
        string htmlPath,
        string outputPath,
        string configuredChromiumPath,
        Exception nativeRendererException)
    {
        var executable = ResolveChromiumPath(configuredChromiumPath);
        if (string.IsNullOrWhiteSpace(executable))
        {
            throw new InvalidOperationException(
                "Không tải được native wkhtmltopdf và không tìm thấy Chromium/Chrome để dự phòng. " +
                "Cấu hình ExportHtml:ChromiumPath hoặc cài Google Chrome/Chromium.",
                nativeRendererException);
        }

        var outputDirectory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        var userDataDirectory = Path.Combine(
            Path.GetTempPath(),
            "nlt-chromium-pdf-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(userDataDirectory);

        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            startInfo.ArgumentList.Add("--headless=new");
            startInfo.ArgumentList.Add("--disable-gpu");
            startInfo.ArgumentList.Add("--disable-background-networking");
            startInfo.ArgumentList.Add("--disable-component-update");
            startInfo.ArgumentList.Add("--disable-default-apps");
            startInfo.ArgumentList.Add("--disable-extensions");
            startInfo.ArgumentList.Add("--disable-crash-reporter");
            startInfo.ArgumentList.Add("--no-first-run");
            startInfo.ArgumentList.Add("--no-default-browser-check");
            startInfo.ArgumentList.Add("--no-pdf-header-footer");
            startInfo.ArgumentList.Add("--run-all-compositor-stages-before-draw");
            startInfo.ArgumentList.Add("--virtual-time-budget=1000");
            startInfo.ArgumentList.Add("--user-data-dir=" + userDataDirectory);
            startInfo.ArgumentList.Add("--print-to-pdf=" + Path.GetFullPath(outputPath));
            startInfo.ArgumentList.Add(new Uri(Path.GetFullPath(htmlPath)).AbsoluteUri);

            using var process = Process.Start(startInfo)
                ?? throw new InvalidOperationException("Không thể khởi động Chromium để xuất PDF.");
            var standardOutput = process.StandardOutput.ReadToEndAsync();
            var standardError = process.StandardError.ReadToEndAsync();
            var outputReady = false;
            var readySince = DateTime.MinValue;
            var deadline = DateTime.UtcNow.AddMinutes(2);

            while (!process.HasExited && DateTime.UtcNow < deadline)
            {
                if (IsPdfReady(outputPath))
                {
                    outputReady = true;
                    readySince = readySince == DateTime.MinValue
                        ? DateTime.UtcNow
                        : readySince;

                    // Some Chrome builds keep a background process alive after
                    // writing the PDF. Once the file is complete, stop that
                    // process instead of delaying the API response for 2 minutes.
                    if (DateTime.UtcNow - readySince >= TimeSpan.FromMilliseconds(500))
                    {
                        process.Kill(entireProcessTree: true);
                        break;
                    }
                }
                else
                {
                    readySince = DateTime.MinValue;
                }

                process.WaitForExit(200);
            }

            if (!process.HasExited)
                process.Kill(entireProcessTree: true);

            process.WaitForExit();

            Task.WaitAll(standardOutput, standardError);
            if (!outputReady)
                outputReady = IsPdfReady(outputPath);

            if (!outputReady)
            {
                var error = standardError.Result.Trim();
                throw new InvalidOperationException(
                    "Chromium không xuất được PDF." +
                    (string.IsNullOrWhiteSpace(error) ? string.Empty : " " + error),
                    nativeRendererException);
            }

            return outputPath;
        }
        finally
        {
            try
            {
                if (Directory.Exists(userDataDirectory))
                    Directory.Delete(userDataDirectory, recursive: true);
            }
            catch
            {
                // A temporary browser profile must not hide a successful export.
            }
        }
    }

    private static string ResolveChromiumPath(string configuredPath)
    {
        var candidates = new List<string>();
        if (!string.IsNullOrWhiteSpace(configuredPath))
            candidates.Add(configuredPath);

        if (OperatingSystem.IsMacOS())
        {
            candidates.Add("/Applications/Google Chrome.app/Contents/MacOS/Google Chrome");
            candidates.Add("/Applications/Chromium.app/Contents/MacOS/Chromium");
            candidates.Add("/Applications/Google Chrome Canary.app/Contents/MacOS/Google Chrome Canary");
        }
        else if (OperatingSystem.IsWindows())
        {
            candidates.Add(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                "Google", "Chrome", "Application", "chrome.exe"));
            candidates.Add(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                "Google", "Chrome", "Application", "chrome.exe"));
            candidates.Add(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Google", "Chrome", "Application", "chrome.exe"));
        }
        else
        {
            candidates.Add("/usr/bin/google-chrome");
            candidates.Add("/usr/bin/chromium");
            candidates.Add("/usr/bin/chromium-browser");
        }

        return candidates
            .Where(File.Exists)
            .Select(Path.GetFullPath)
            .FirstOrDefault();
    }

    private static string ResolveLocalPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || OperatingSystem.IsWindows())
            return path;

        return Path.GetFullPath(path.Replace('\\', Path.DirectorySeparatorChar));
    }

    private static bool IsPdfReady(string path)
    {
        if (!File.Exists(path))
            return false;

        try
        {
            using var stream = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);
            if (stream.Length < 8)
                return false;

            var count = (int)Math.Min(1024L, stream.Length);
            stream.Seek(-count, SeekOrigin.End);
            var tail = new byte[count];
            var read = stream.Read(tail, 0, tail.Length);
            return read == tail.Length &&
                   Encoding.ASCII.GetString(tail).Contains("%%EOF", StringComparison.Ordinal);
        }
        catch (IOException)
        {
            return false;
        }
    }
}
