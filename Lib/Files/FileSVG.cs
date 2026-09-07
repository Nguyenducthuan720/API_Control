using System.Text.RegularExpressions;
using SkiaSharp;
using Svg.Skia;

public static class FileSVG
{
    /// <summary>
    /// Replace các placeholder trong file SVG và chuyển sang PNG (không bị cache lỗi)
    /// </summary>
    public static void ReplaceAndConvertSvgToPng(string svgPath, string outputPngPath,
        Dictionary<string, string> replacements, int width = 0, int height = 0)
    {
        if (!File.Exists(svgPath))
            throw new FileNotFoundException($"Không tìm thấy file SVG: {svgPath}");

        // 1️⃣ Đọc nội dung SVG
        string svgContent = File.ReadAllText(svgPath);

        // 2️⃣ Replace placeholder
        foreach (var kv in replacements)
        {
            string key = kv.Key.Trim();
            string val = kv.Value ?? "";
            svgContent = Regex.Replace(svgContent, Regex.Escape(key), val, RegexOptions.IgnoreCase);
        }

        // 3️⃣ Load trực tiếp từ memory, không dùng file tạm (tránh cache)
        using var svg = new SKSvg();
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(svgContent));
        svg.Load(stream);

        if (svg.Picture == null)
            throw new Exception("Không thể render được SVG sau khi replace.");

        var rect = svg.Picture.CullRect;
        if (width == 0) width = (int)rect.Width;
        if (height == 0) height = (int)rect.Height;

        // 4️⃣ Render ra PNG
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
        using var fs = File.OpenWrite(outputPngPath);
        data.SaveTo(fs);
    }
}
