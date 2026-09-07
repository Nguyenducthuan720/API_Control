namespace APISmartCity.Models.Ver2.PackagingRequests;

public static class PackagingRequests
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>CustomerRequest</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>PackagingRequests</example>
            public string? EntryID { get; set; }
			
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }
			
            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2024-11-19</example>
            public string? ODate { get; set; }

            /// <summary>
            /// SAPID
            /// </summary>
            /// <example></example>
            public string? SAPID { get; set; }

            /// <summary>
            /// LemonID
            /// </summary>
            /// <example></example>
            public string? LemonID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            /// <example>0</example>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Tên sản phẩm
            /// </summary>
            /// <example></example>
            public string? ItemName { get; set; }
            
            /// <summary>
            /// Số lượng yêu cầu
            /// </summary>
            /// <example>100</example>
            public int? Quantity { get; set; }

            /// <summary>
            /// Mô tả chi tiết
            /// </summary>
            /// <example>Đây là mô tả chi tiết của khách hàng</example>
            public string? Description { get; set; }

            /// <summary>
            /// File đính kèm
            /// </summary>
            /// <example></example>
            public string? ItemLink { get; set; }
            
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Ghi chú</example>
            public string? Note { get; set; }
        }

        public class Submit : GetByOID
        {
            /// <summary>
            /// Khóa/Mở khóa
            /// </summary>
            public int? IsLock { get; set; }

            /// <summary>
            /// Đồng ý/Từ chối
            /// </summary>
            public int? IsApprove { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            public string? Link { get; set; }

            /// <summary>
            /// Nội dung
            /// </summary>
            public string? Note { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }

        public class Del : GetByOID
        {
        }
    }
}