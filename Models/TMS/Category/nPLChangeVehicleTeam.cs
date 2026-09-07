namespace APISmartCity.Models.TMS
{
    public static class nPLChangeVehicleTeam
    {
        public static class Request
        {
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
                public string? FactorID { get; set; }
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>1</example>
                public string? ODate { get; set; }
                /// <summary>
                /// Đội xe này
                /// </summary>
                public int? FromVehicleTeamID { get; set; }
                /// <summary>
                /// Đội xe kia
                /// </summary>
                public int? ToVehicleTeamID { get; set; }
                /// <summary>
                /// từ ngày
                /// </summary>
                public string? FromDate { get; set; }
                /// <summary>
                /// Đến ngày
                /// </summary>
                public string? ToDate { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Link { get; set; }
                /// <summary>
                /// Danh sách xe cách bởi dấu phẩy
                /// </summary>
                public string? ListVehicleID { get; set; }
                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention5 { get; set; }


            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class Del : GetByID
            {
            }
        }
    }
}