namespace DMS.Models.DMS.Payments
{
    public class PaymentConfirmations
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>Payments</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>PaymentConfirmation</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// ODate
                /// </summary>
                /// <example>2025-04-26</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Yêu cầu cọc/thanh toán
                /// </summary>
                public string? PaymentRequestID { get; set; }

                /// <summary>
                /// Số tiền cọc/thanh toán
                /// </summary>
                public decimal PaymentAmount { get; set; }

                /// <summary>
                /// Nội dung
                /// </summary>
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
