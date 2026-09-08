using HandlebarsDotNet;
using System.Collections.Concurrent;

namespace DMS.Lib.Files
{
    /// <summary>
    /// Reads and renders HTML/Handlebars templates. Compiled templates are reused
    /// until the source file changes.
    /// </summary>
    public sealed class HandlebarsHtmlRenderer
    {
        private readonly ConcurrentDictionary<string, CachedTemplate> _cache = new(StringComparer.OrdinalIgnoreCase);

        public string RenderSource(string source, object model) => Handlebars.Compile(source)(model);

        public string Render(string templatePath, object model)
        {
            if (string.IsNullOrWhiteSpace(templatePath))
                throw new ArgumentException("Template HTML không được để trống.", nameof(templatePath));

            var extension = Path.GetExtension(templatePath);
            if (!string.Equals(extension, ".html", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(extension, ".hbs", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(extension, ".handlebars", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Template HTML phải có phần mở rộng .html, .hbs hoặc .handlebars.");
            }

            var fullPath = Path.GetFullPath(templatePath);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Không tìm thấy template HTML.", fullPath);

            var lastWriteUtc = File.GetLastWriteTimeUtc(fullPath);
            if (!_cache.TryGetValue(fullPath, out var cached) || cached.LastWriteUtc != lastWriteUtc)
            {
                cached = Compile(fullPath, lastWriteUtc);
                _cache[fullPath] = cached;
            }

            return cached.Render(model);
        }

        private static CachedTemplate Compile(string path, DateTime lastWriteUtc)
        {
            var source = File.ReadAllText(path);
            var compiled = Handlebars.Compile(source);
            Func<object, string> render = model => compiled(model);
            return new CachedTemplate(lastWriteUtc, render);
        }

        private sealed record CachedTemplate(DateTime LastWriteUtc, Func<object, string> Render);
    }
}
