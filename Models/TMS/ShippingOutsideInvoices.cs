namespace APISmartCity.Models.TMS
{
    public class ShippingOutsideInvoices
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
            }

            public class GetShippingsOutside
            {
                public string? FromDate { get; set; }
                public string? ToDate { get; set; }
                public decimal? VAT { get; set; }
                public int? OutSideID { get; set; }

            }

            public class GetCheckInvoices
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

            public class GetDetailByCustomer
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>ShippingOutsideInvoices</example>
                public string? EntryID { get; set; }

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

                /// <summary>
                /// %VAT
                /// </summary>
                /// <example>8</example>
                public int? VAT { get; set; }
            }

            public class GetDetailByTaxCode
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>ShippingOutsideInvoices</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ma KH
                /// </summary>
                /// <example>3</example>
                public string? TaxCode { get; set; }

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

                /// <summary>
                /// %VAT
                /// </summary>
                /// <example>8</example>
                public int? VAT { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Trạng thái
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Submit
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Trạng thái
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }
            }

            public class Add : Content
            {
            }

            public class Content
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>INVOICE</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>ShippingOutsideInvoices</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Odate
                /// </summary>
                /// <example>2023/09/01</example>
                public string? ODate { get; set; }

                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example>HDBH018130138</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// ReferenceDate
                /// </summary>
                /// <example>2023/09/01</example>
                public string? ReferenceDate { get; set; }

                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>3</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// FromDate
                /// </summary>
                /// <example>2023/07/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// FromDate
                /// </summary>
                /// <example>2023/09/10</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// FromDate
                /// </summary>
                /// <example>8</example>
                public int? VAT { get; set; }

                /// <summary>
                /// InvoiceCode
                /// </summary>
                /// <example>TC/18E</example>
                public string? InvoiceCode { get; set; }

                /// <summary>
                /// InvoiceNo
                /// </summary>
                /// <example>123456</example>
                public string? InvoiceNo { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalAmntShip { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalAmntLOLO { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalAmntCOC { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalAmnt { get; set; }

                /// <summary>
                /// TotalIncurred
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalIncurred { get; set; }

                /// <summary>
                /// TotalIncurred
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalVAT { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public string? Note { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public string? Link { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Đại diện bên A</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>Chức vụ bên A</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>Đại diện bên B</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>Chức vụ bên B</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// TaxCode
                /// </summary>
                /// <example>041233213</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// StrDetail
                /// </summary>
                /// <example>Json string nha</example>
                public string? StrDetail { get; set; }
            }
        }
    }
}