namespace APISmartCity.Models.TMS
{
    public static class ETCCosts
    {
        public static class Request
        {
            public class Details
            {
                /// <summary>
                /// Ngày giao dịch
                /// </summary>
                /// <example>28/02/2023 21:50:29</example>
                public string? ETCDate { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>90000</example>
                public string? Note { get; set; }

                /// <summary>
                /// Số xe
                /// </summary>
                /// <example>50H05137V</example>
                public string? LicensePlate { get; set; }

                /// <summary>
                /// Số tiền sau thuế
                /// </summary>
                /// <example>90000</example>
                public decimal Cost { get; set; }

                /// <summary>
                /// Số tiền sau thuế
                /// </summary>
                /// <example>Tân Lập</example>
                public string? ChargingStation { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                public List<Details> ListDetails { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>90000</example>
                public string? Note { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2023-02-10</example>
                public string? ODate { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>ETCCosts</example>
                public string? EntryID { get; set; }
            }

            public class ImportExcel
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>MCT123</example>
                public string? OID { get; set; }

                /// <summary>
                /// File Excel
                /// </summary>
                public IFormFile File { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
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
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
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
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
            }

            //public class GetMobile
            //{
            //    /// <summary>
            //    /// Loại nghiệp vụ
            //    /// </summary>
            //    /// <example>RQ_SHIPPINGPRICE</example>
            //    public string? EntryID { get; set; }
            //}
        }
    }
}