namespace APISmartCity.Models.TMS
{
    public static class ShippingAndCreditnPLTotal
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2022/12/26</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>RQ_SHIPPINGPRICE</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// % VAT
                /// </summary>
                /// <example>10</example>
                public decimal PercentVAT { get; set; }

                /// <summary>
                /// Điều chỉnh giá
                /// </summary>
                /// <example>1</example>
                public decimal AdjustPrices { get; set; }

                /// <summary>
                /// Điều chỉnh giá cặp cổ
                /// </summary>
                /// <example>1</example>
                public decimal AdjustNeckpair { get; set; }

                /// <summary>
                /// Điều chỉnh giá bán
                /// </summary>
                /// <example>1</example>
                public decimal AdjustSalePrices { get; set; }

                /// <summary>
                /// Điều chỉnh giá bán cặp cổ
                /// </summary>
                /// <example>1</example>
                public decimal AdjustSaleNeckpair { get; set; }

                /// <summary>
                /// Lý do điều chỉnh
                /// </summary>
                /// <example>1</example>
                public string? ReasonNote { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Link { get; set; }
            }

            public class Detail
            {
                /// <summary>
                /// OID đề xuất giá
                /// </summary>
                /// <example>1100000</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Add : Content
            {
                public List<Detail> Details { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
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
                /// <example>ÐXGVC/02/12/2022/001</example>
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
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>RQ_SHIPPINGPRICE</example>
                public string? EntryID { get; set; }
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