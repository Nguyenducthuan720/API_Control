using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OsControl.Controllers.Authentications
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.FileProxy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileProxyController : ControllerBase
    {
        private const string ROOT_PATH = @"C:\NLT\SaveFile";
        private const string FILE_DOMAIN = "https://uatviewfile-dms.kimtingroup.com:44352";

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] string url)
        {
            try
            {
                var token = GetTokenFromRequest();

                if (string.IsNullOrWhiteSpace(token))
                    return Unauthorized("Token is null");

                var userId = GetUserIdFromJwt(token);

                if (string.IsNullOrWhiteSpace(userId))
                    return Unauthorized("UserId not found");

                if (string.IsNullOrWhiteSpace(url))
                    return BadRequest("Url is null");

                if (!url.StartsWith(FILE_DOMAIN, StringComparison.OrdinalIgnoreCase))
                    return Forbid();

                var uri = new Uri(url);
                var filePath = uri.AbsolutePath;
                // /5/Customers/CustomerProfileChanges/20260319180148/HDNTngVnhTn.pdf

                var fullPath = BuildSafePhysicalPath(filePath);

                if (fullPath == null)
                    return BadRequest("Invalid file path");

                if (!System.IO.File.Exists(fullPath))
                    return NotFound();

                // TODO: check quyền thật ở đây
                // var allow = CheckPermission(userId, filePath);
                // if (!allow) return Forbid();

                var contentType = GetContentType(fullPath);

                return PhysicalFile(
                    fullPath,
                    contentType,
                    enableRangeProcessing: true
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        private string? GetTokenFromRequest()
        {
            var token = Request.Cookies["DMS_AUTH"];

            if (!string.IsNullOrWhiteSpace(token))
                return token;

            var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(authHeader) &&
                authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return authHeader.Substring("Bearer ".Length).Trim();
            }

            return null;
        }

        private string? GetUserIdFromJwt(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
                return null;

            var jwt = handler.ReadJwtToken(token);

            return jwt.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value
                ?? jwt.Claims.FirstOrDefault(x => x.Type == "uid")?.Value
                ?? jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value
                ?? jwt.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        }

        private string? BuildSafePhysicalPath(string filePath)
        {
            filePath = Uri.UnescapeDataString(filePath);
            filePath = filePath.Replace("/", "\\");

            if (filePath.Contains(".."))
                return null;

            var fullPath = Path.GetFullPath(
                Path.Combine(ROOT_PATH, filePath.TrimStart('\\'))
            );

            if (!fullPath.StartsWith(ROOT_PATH, StringComparison.OrdinalIgnoreCase))
                return null;

            return fullPath;
        }

        private string GetContentType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLower();

            return ext switch
            {
                ".pdf" => "application/pdf",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".html" or ".htm" => "text/html; charset=utf-8",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                _ => "application/octet-stream"
            };
        }
    }
}
