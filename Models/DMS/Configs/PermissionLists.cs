using System.ComponentModel;

namespace DMS.Models.DMS.Configs;

public static class PermissionLists
{
    public class Request
    {
       
        public class GetListUsers
        {
            public int? UserID { get; set; }

            [DefaultValue("")]
            public string? CmpnID { get; set; }
        }

        public class GetListCustomers
        {
            public int? CustomerRepresentativeID { get; set; }
            public int? SalesStaffID { get; set; } 
            public string? Function { get; set; }

            [DefaultValue("")]
            public string? CmpnID { get; set; }
        }
    }
}