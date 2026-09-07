namespace APISmartCity.Models.Categorys
{
    public static class GeneralApprovals
    {
        public static class Request
        {
            public class Process
            {
                public string OID { get; set; }
                public string FactorID { get; set; }
                public string EntryID { get; set; }
                public int ApprovalProcessID { get; set; }
                public int ApprovalStatusID { get; set; }
                public string ApprovalNote { get; set; }
                public decimal Extention1 { get; set; }
                public DateTime Extention2 { get; set; }
                public string Extention3 { get; set; }
                public string Extention4 { get; set; }
                public string Extention5 { get; set; }
                public string StringObject { get; set; }

            }
            public class ProcessArray
            {
                public List<Process> dataJson { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// Url điều hướng
                /// </summary>
                /// <example>https://control-api.nlt-group.com:11998/api/CustomerProfiles</example>
                public string ProcessLink { get; set; }

                /// <summary>
                /// Tên phương thức xem chi tiết
                /// </summary>
                /// <example>GetByID</example>
                public string GetByOIDLink { get; set; }

                /// <summary>
                /// Tham số
                /// </summary>
                /// <example></example>
                public string Parameter { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string OID { get; set; }
            }
        }
    }
}