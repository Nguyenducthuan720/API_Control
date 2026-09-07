using static APISmartCity.Models.TMS.ShippingsHandovers.Request;

namespace APISmartCity.Models.TMS
{
    public static class ShippingInvoicesSplittings
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? ReferenceID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Ma KH
                /// </summary>
                /// <example>3</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// từ ngày
                /// </summary>
                /// <example>2023/07/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// đến ngày
                /// </summary>
                /// <example>2023/09/10</example>
                public string? ToDate { get; set; }
            }

            public class ByCustomerID
            {
                /// <summary>
                /// Ma KH
                /// </summary>
                /// <example>3</example>
                public int? CustomerID { get; set; }
            }

            public class Add : GetByID
            {
                public List<AddDetails> DetailsInvoice { get; set; }
            }

            public class AddDetails
            {
                /// <summary>
                /// Mã cty xuất hóa đơn
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Mã số thuế
                /// </summary>
                /// <example>0104160054</example>
                public string? TaxCode { get; set; }

                /// <summary>
                /// TotalAmnt
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalAmnt { get; set; }

                /// <summary>
                /// Ghi chú nếu cần
                /// </summary>
                /// <example>Ghi chú nha</example>
                public string? Note { get; set; }

                /// <summary>
                /// OID của lần bàn giao
                /// </summary>
                /// <example>BG019834718</example>
                public string? DataType { get; set; }
            }
        }
    }
}