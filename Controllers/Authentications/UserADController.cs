using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;
using System.Security.Principal;

namespace OsControl.Controllers.Authentications
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.UserDomain")]
    [Authorize]
    [ApiController]
    public class UserDomainController : ControllerBase
    {

        [HttpPost]
        [Route("api/authentication/[action]")]
        [ProducesResponseType(200, Type = typeof(DataResponse))]
        public IActionResult GetListUser()
        {
            var response = new DataResponse();

            try
            {
                // ===== [STEP 1] Cấu hình thông tin LDAP =====
                string ldapPath = "LDAP://svr2025.kimtingroup.com/DC=kimtingroup,DC=com";
                string username = "kimtingroup\\dms";
                string password = "526@DmsKT";

                // ===== [STEP 2] Kết nối tới LDAP =====
                using var entry = new DirectoryEntry(ldapPath, username, password);
                using var searcher = new DirectorySearcher(entry)
                {
                    Filter = "(objectClass=user)",
                    PageSize = 1000
                };

                searcher.PropertiesToLoad.AddRange(new[] {
                   "samaccountname", "displayname"
                });

                // ===== [STEP 3] Truy vấn và đọc dữ liệu =====
                var results = searcher.FindAll();
                var users = new List<object>();

                foreach (SearchResult r in results)
                {
                    var p = r.Properties;

                    string GetProp(string key)
                    {
                        return p.Contains(key) ? p[key][0]?.ToString().Replace("\"", "") ?? "" : "";
                    }

                    //string objectGuid = p.Contains("objectguid")
                    //    ? new Guid((byte[])p["objectguid"][0]).ToString()
                    //    : "";

                    //string objectSid = p.Contains("objectsid")
                    //    ? new SecurityIdentifier((byte[])p["objectsid"][0], 0).Value
                    //    : "";

                    users.Add(new
                    {
                        //ObjectGUID = objectGuid,
                        //ObjectSID = objectSid,
                        SAMAccountName =  GetProp("samaccountname") ,
                        DisplayName = GetProp("displayname") 
                        //Email = GetProp("mail"),
                        //UserPrincipalName = GetProp("userprincipalname")
                    });
                }

                response.Message = $"✅ Lấy danh sách thành công. Tổng số user: {users.Count}";
                response.ErrorCode = "0";
                response.Result = users;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Success = 0;
                response.ErrorCode = "500";
                response.Message = "Lỗi khi lấy danh sách user domain: " + ex.Message;
                return StatusCode(500, response);
            }
        }
    }
}
