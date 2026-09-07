namespace APISmartCity.Models.TMS
{
    public static class ProcessAdjustments
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>1</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }

                /// <summary>
                /// UserID
                /// </summary>
                /// <example>1</example>
                public int? UserID { get; set; }

                /// <summary>
                /// UserName
                /// </summary>
                /// <example>1</example>
                public string? UserName { get; set; }

                /// <summary>
                /// EffectFromDate
                /// </summary>
                /// <example>1</example>
                public DateTime? EffectFromDate { get; set; }

                /// <summary>
                /// ExpiredFromDate
                /// </summary>
                /// <example>1</example>
                public DateTime? ExpiredFromDate { get; set; }

                /// <summary>
                /// ExpiredFromDate
                /// </summary>
                /// <example>1</example>
                public DateTime? ApprovalToDate { get; set; }

                /// <summary>
                /// Reason
                /// </summary>
                /// <example>1</example>
                public string? Reason { get; set; }

                /// <summary>
                /// UnitPrice
                /// </summary>
                /// <example>5500000.00</example>
                public decimal UnitPrice { get; set; }

                /// <summary>
                /// FeeTransport
                /// </summary>
                /// <example>16500000</example>
                public decimal FeeTransport { get; set; }

                /// <summary>
                /// TotalRevenue
                /// </summary>
                /// <example>16000000</example>
                public decimal TotalRevenue { get; set; }

                /// <summary>
                /// Giá chưa VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal NonVATPrices { get; set; }

                /// <summary>
                /// % VAT
                /// </summary>
                /// <example>10</example>
                public decimal PercentVAT { get; set; }

                /// <summary>
                /// Giá đã có VAT
                /// </summary>
                /// <example>1100000</example>
                public decimal VATPrices { get; set; }

                /// <summary>
                /// Giá cặp cổ chưa VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceNotVATNeckpair { get; set; }

                /// <summary>
                /// Giá cặp cổ có VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceVATNeckpair { get; set; }

                /// <summary>
                /// ExpectedTime
                /// </summary>
                /// <example>1</example>
                public DateTime? ExpectedTime { get; set; }

                /// <summary>
                /// SaleContractsDepotID
                /// </summary>
                /// <example>1</example>
                public int? SaleContractsDepotID { get; set; }

                /// <summary>
                /// NewDepotID
                /// </summary>
                /// <example>1</example>
                public int? NewDepotID { get; set; }

                /// <summary>
                /// AdjustType
                /// </summary>
                /// <example>SaleContractsDepots</example>
                public string? AdjustType { get; set; }

                /// <summary>
                /// File lệnh hạ
                /// </summary>
                /// <example>file.pdf</example>
                public string? FileDown { get; set; }

                /// <summary>
                /// Số tiền được duyệt
                /// </summary>
                /// <example>1000000</example>
                public decimal ApprovalMoney { get; set; }
                /// <summary>
                /// Cập nhật nội dung duyệt phát sinh
                /// </summary>
                /// <example>Nhập nội dung</example>
                public string? ApprovalNote { get; set; }    

                /// <summary>
                /// Đồng ý:1, từ chối:0
                /// </summary>
                /// <example>1</example>
                public int? IsApproval { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Trường bổ sung 1
                /// </summary>
                public string? Extention1 {get;set;}
                /// <summary>
                /// Trường bổ sung 2
                /// </summary>
                public string? Extention2 {get;set;}
                /// <summary>
                /// Trường bổ sung 3
                /// </summary>
                public string? Extention3 {get;set;}
                /// <summary>
                /// Trường bổ sung 4
                /// </summary>
                public string? Extention4 {get;set;}
                /// <summary>
                /// Trường bổ sung 5
                /// </summary>
                public string? Extention5 { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>1</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }

                /// <summary>
                /// AdjustType
                /// </summary>
                /// <example></example>
                public string? AdjustType { get; set; }
            }

            public class UpdateExpired
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>1</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }
            }
        }
    }
}