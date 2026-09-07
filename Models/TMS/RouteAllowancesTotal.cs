namespace APISmartCity.Models.TMS
{
    public static class RouteAllowancesTotal
    {
        public static class Request
        {
            public class RouteAllowancesTotalDetails
            {
                public string? ReferenceID { get; set; }

                public decimal? NoOverloadCost { get; set; }
                public decimal? NoOverloadSalary { get; set; }
                public decimal? OverloadCost { get; set; }
                public decimal? OverloadSalary { get; set; }
                public decimal? OtherCost { get; set; }
                public decimal? Distance { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
            }

            public class Add
            {
                /// <summary>
                /// OID (Edit mới cần)
                /// </summary>

                public string ODate { get; set; }

                public string? FromDate { get; set; }
                public string? ToDate { get; set; }

                public string? Content { get; set; }

                public string? Note { get; set; }

                public string? SAPID { get; set; }
                public string? LemonID { get; set; }

                public string? Link { get; set; }

                // Extentions
                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }

                /// <summary>
                /// Danh sách chi tiết → sẽ serialize thành JSON
                /// </summary>
                public List<RouteAllowancesTotalDetails>? Details { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class Submit : GetByID
            {
 
                public int? IsLock { get; set; }
            }
            public class EditStatus : GetByID
            {

                public int? IsActive { get; set; }
            }
            public class Del : GetByID
            {
            }
        }
    }
}