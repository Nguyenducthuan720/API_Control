namespace DMS.Models.DMS.Payments
{
    public static class PaymentRequests
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>Payments</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>PayForDeposit</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-04-26</example>
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
                public int? CustomerID { get; set; }

                /// <summary>
                /// Đơn hàng
                /// </summary>
                public string? OrderID { get; set; }

                /// <summary>
                /// Theo %/giá trị
                /// </summary>
                public int? IsPercent { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                public decimal RequestValue { get; set; }

                /// <summary>
                /// Số tiền yêu cầu
                /// </summary>
                public decimal RequestAmount { get; set; }

                /// <summary>
                /// Đơn vị tiền tệ
                /// </summary>
                public int? CurrencyID { get; set; }

                /// <summary>
                /// Tỷ giá theo ngày
                /// </summary>
                public decimal CurrencyRate { get; set; }

                /// <summary>
                /// Ngày tỷ giá
                /// </summary>
                public string? CurrencyDate { get; set; }

                /// <summary>
                /// Tài khoản nhận
                /// </summary>
                public int? BankAccountID { get; set; }

                /// <summary>
                /// Nội dung yêu cầu
                /// </summary>
                /// <example></example>
                public string? Content { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention11 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention12 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention13 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention14 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention15 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention16 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention17 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention18 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention19 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention20 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Tệp đính kèm
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }
            }

            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
            }

            public class Del : GetByOID
            {

            }
        }
    }
}
