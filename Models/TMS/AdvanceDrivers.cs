namespace APISmartCity.Models.TMS
{
    public class AdvanceDrivers
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
                /// ODate
                /// </summary>
                /// <example>10/02/2023</example>
                public string? ODate { get; set; }

                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example>abc123</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// PaymentTypesID
                /// </summary>
                /// <example>1</example>
                public int? PaymentTypesID { get; set; }

                /// <summary>
                /// DriverQuantity
                /// </summary>
                /// <example>10</example>
                public int? DriverQuantity { get; set; }

                /// <summary>
                /// AdvanceMoney
                /// </summary>
                /// <example>1000000</example>
                public decimal AdvanceMoney { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>test</example>
                public string? Note { get; set; }
            }

            public class AdvanceDriversDetails
            {
                /// <summary>
                /// nPLDriversID
                /// </summary>
                /// <example>1</example>
                public int? nPLDriversID { get; set; }

                /// <summary>
                /// Amount
                /// </summary>
                /// <example>10000000</example>
                public decimal Amount { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>test</example>
                public string? Note { get; set; }
            }

            public class Add : Content
            {
                public List<AdvanceDriversDetails> AdvanceDriversDetails { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
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
                /// <example>PCTU/10/02/2023/001</example>
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
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
            }

            public class GetMobile
            {
                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>RQ_SHIPPINGPRICE</example>
                public string? EntryID { get; set; }
            }
        }
    }
}