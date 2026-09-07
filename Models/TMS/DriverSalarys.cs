namespace APISmartCity.Models.TMS
{
    public class DriverSalarys
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>AJ_DECREASESALARY</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2023-02-08</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Số tiền
                /// </summary>
                /// <example>1000000.00</example>
                public decimal Amount { get; set; }

                /// <summary>
                /// Tháng
                /// </summary>
                /// <example>02/2023</example>
                public string? Month { get; set; }

                /// <summary>
                /// Lý do
                /// </summary>
                /// <example>Ði tr? quá nhi?u</example>
                public string? Reason { get; set; }

                /// <summary>
                /// ID tài xế
                /// </summary>
                /// <example>2</example>
                public int? nPLDriversID { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>TEST LAN 2</example>
                public string? Note { get; set; }


                /// <summary>
                /// Link
                /// </summary>
                /// <example>TEST LAN 2</example>
                public string? Link { get; set; }
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