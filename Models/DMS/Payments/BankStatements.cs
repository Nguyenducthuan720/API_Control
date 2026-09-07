namespace DMS.Models.DMS.Payments
{
    public class BankStatements
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// Số phiếu
                /// </summary>
                /// <example>Payments</example>
                public string? ReferenceNumber { get; set; }

                /// <summary>
                /// Ngày giao dịch
                /// </summary>
                /// <example>PayForDeposit</example>
                public string? TransactionDate { get; set; }

                /// <summary>
                /// Số giao dịch
                /// </summary>
                /// <example></example>
                public string? TransactionNumber { get; set; }

                /// <summary>
                /// Tài khoản giao dịch
                /// </summary>
                /// <example>2025-04-26</example>
                public string? TransactionAccount { get; set; }

                /// <summary>
                /// Tổng tiền
                /// </summary>
                /// <example></example>
                public decimal TotalAmount { get; set; }

                /// <summary>
                /// Số tiền đã phân bổ
                /// </summary>
                /// <example></example>
                public decimal AllocatedAmount { get; set; }

                /// <summary>
                /// Số đơn hàng phân bổ
                /// </summary>
                public string? AllocatedOrders { get; set; }

                /// <summary>
                /// Diễn giải
                /// </summary>
                /// <example></example>
                public string? Description { get; set; }

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
            }

            public class Get
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-01-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2026-01-01</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Số phiếu
                /// </summary>
                /// <example>1</example>
                public string? ReferenceNumber { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }
            }

            public class Confirm : GetByID
            {
                /// <summary>
                /// Xác nhận
                /// </summary>
                public int? IsLock { get; set; }

                /// <summary>
                /// Chi tiết tách tiền
                /// </summary>
                public List<BankStatementDetail> Details { get; set; }
            }

            public class BankStatementDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Số phiếu
                /// </summary>
                public string? ReferenceNumber { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example></example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Số SO
                /// </summary>
                /// <example></example>
                public string? OrderID { get; set; }

                /// <summary>
                /// Số tiền còn nợ
                /// </summary>
                public decimal RemainingAmount { get; set; }

                /// <summary>
                /// Số tiền phân bổ
                /// </summary>
                public decimal AllocatedAmount { get; set; }

                /// <summary>
                /// Tài khoản
                /// </summary>
                public string? BankAccount { get; set; }

                /// <summary>
                /// Điện thoại hỗ trợ
                /// </summary>
                public string? SupportPhone { get; set; }

                /// <summary>
                /// IO
                /// </summary>
                public string? IO { get; set; }

                /// <summary>
                /// Điều kiện thanh toán
                /// </summary>
                public int? PaymentTermID { get; set; }

                /// <summary>
                /// Hóa đơn
                /// </summary>
                public string? InvoiceNO { get; set; }

                /// <summary>
                /// Đơn vị
                /// </summary>
                public string? Unit { get; set; }

                /// <summary>
                /// Khu vực
                /// </summary>
                public string? Region { get; set; }

                /// <summary>
                /// Đã kiểm
                /// </summary>
                public int? IsCheck { get; set; }

                /// <summary>
                /// Đã nhập
                /// </summary>
                public int? IsImported { get; set; }

                /// <summary>
                /// Mô tả
                /// </summary>
                /// <example></example>
                public string? Description { get; set; }
            }
        }
    }
}
