namespace APISmartCity.Models.TMS
{
    public class RenewalDocs
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2023-02-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>RENEWALDOC</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>RENEWALDOC</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Đơn vị
                /// </summary>
                /// <example>93</example>
                public int? ExtendUnitsID { get; set; }

                /// <summary>
                /// Số xe
                /// </summary>
                /// <example>543</example>
                public int? LicensePlates { get; set; }

                /// <summary>
                /// Gia hạn
                /// </summary>
                /// <example>2023-02-24</example>
                public string? Renewal { get; set; }

                /// <summary>
                /// Hết hạn
                /// </summary>
                /// <example>2024-02-23</example>
                public string? Expired { get; set; }

                /// <summary>
                /// Số tiền
                /// </summary>
                /// <example>10000000.00</example>
                public decimal Amount { get; set; }

                /// <summary>
                /// Số Series
                /// </summary>
                /// <example>SR12345</example>
                public string? Series { get; set; }

                /// <summary>
                /// Số GH
                /// </summary>
                /// <example></example>
                public string? RenewalNumber { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>Test SQL</example>
                public string? Note { get; set; }
            }

            public class Add : Content
            {
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


            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
                public int? IsConfirm { get; set; }
                public string? ConfirmNote { get; set; }
                public string? ConfirmLink { get; set; }

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