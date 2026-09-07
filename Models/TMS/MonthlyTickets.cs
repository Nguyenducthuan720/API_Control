namespace APISmartCity.Models.TMS
{
    public static class MonthlyTickets
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// ngày áp dụng
                /// </summary>
                /// <example>10/02/2023</example>
                public string? ODate { get; set; }

                /// <summary>
                /// ID Trạm thu phí
                /// </summary>
                /// <example>1</example>
                public int? ChargingStationsID { get; set; }

                /// <summary>
                /// Số HD
                /// </summary>
                /// <example>1</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>10/02/2023</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>11/02/2023</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Chi Phí
                /// </summary>
                /// <example>100000</example>
                public decimal Free { get; set; }

                /// <summary>
                /// Tổng chi phí
                /// </summary>
                /// <example>10000000</example>
                public decimal Total { get; set; }

                /// <summary>
                /// Ghi Chú
                /// </summary>
                /// <example>Test</example>
                public string? Note { get; set; }
            }

            public class MonthlyTicketsDetails
            {
                /// <summary>
                /// ID phương tiện
                /// </summary>
                /// <example>1</example>
                public int? VehiclesID { get; set; }
            }

            public class Add : Content
            {
                public List<MonthlyTicketsDetails> MonthlyTicketsDetails { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>DKVX/10/02/23/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>DKVX/10/02/23/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>DKVX/10/02/23/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Submit
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>DKVX/10/02/23/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>DKVX/10/02/23/001</example>
                public string? OID { get; set; }
            }

            public class GetInfo
            {
                /// <summary>
                /// ngày áp dụng
                /// </summary>
                /// <example>10/02/2023</example>
                public string? ODate { get; set; }
            }

            public class Get
            {
            }

            public class GetMobile
            {
                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>DKVX/10/02/23/001</example>
                public string? EntryID { get; set; }
            }
        }
    }
}