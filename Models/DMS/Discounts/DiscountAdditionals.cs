namespace OsControl.Models.DMS.Discounts
{
    public class DiscountAdditionals
    {
        public static class Request
        {
            public class Add : GetByOID
            {
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

            public class AddProposal : Add
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>PriceCommercials</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>ProvisionalDiscount</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-03-25</example>
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
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-07-18</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2025-07-18</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Dữ liệu tính từ ngày
                /// </summary>
                /// <example>2025-07-18</example>
                public string? CalcFromDate { get; set; }

                /// <summary>
                /// Dữ liệu tính đến ngày
                /// </summary>
                /// <example>2025-07-18</example>
                public string? CalcToDate { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example></example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Khu vực áp dụng
                /// </summary>
                /// <example></example>
                public string? Areas { get; set; }

                /// <summary>
                /// Nội dung yêu cầu
                /// </summary>
                /// <example></example>
                public string? Content { get; set; }

                /// <summary>
                /// Lý do 
                /// </summary>
                /// <example></example>
                public string? Reason { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

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
                /// Tệp đính kèm
                /// </summary>
                /// <example>Link</example>
                public string? Link { get; set; }

                public List<AddDetail> Details { get; set; }
            }

            public class AddDetail : Add
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example></example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Ngành hàng 
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Đề xuất chiết khấu
                /// </summary>
                public string? ProposalID { get; set; }

                /// <summary>
                /// Loại chiết khấu (0: Sản lượng, 1: Doanh số)
                /// </summary>
                public int? IsRevenue { get; set; }

                /// <summary>
                /// Mức chiết khấu max
                /// </summary>
                public string? DiscountLevel { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                /// <example>>=</example>
                public string? Condition { get; set; }

                /// <summary>
                /// Chiết khấu
                /// </summary>
                /// <example></example>
                public decimal DiscountValue { get; set; }

                /// <summary>
                /// Sản lượng (kg)/Doanh số (VND)
                /// </summary>
                /// <example></example>
                public decimal Value { get; set; }

                /// <summary>
                /// SL thực tế xuất (kg)/DS thực tế (VND)
                /// </summary>
                /// <example></example>
                public decimal ActualExportValue { get; set; }

                /// <summary>
                /// Mức CK thực tế đạt được (VND)
                /// </summary>
                /// <example></example>
                public decimal ActualDiscount { get; set; }

                /// <summary>
                /// Hàng đặt đã mượn tháng trước (kg)
                /// </summary>
                /// <example></example>
                public decimal BorrowOrderedLastMonth { get; set; }

                /// <summary>
                /// Hàng đặt còn lại chưa lấy (kg)
                /// </summary>
                /// <example></example>
                public decimal RemainOrdered { get; set; }

                /// <summary>
                /// Mức CK đề xuất
                /// </summary>
                /// <example></example>
                public decimal? ProposeDiscountValue { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                /// <example>></example>
                public string? Conditions { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }
            }

            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
            }

            public class Del : GetByOID
            {

            }

            public class GetItems
            {
                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example></example>
                public int? CustomerID { get; set; }
            }

            public class GetDiscount
            {
                /// <summary>
                /// Dữ liệu tính từ ngày
                /// </summary>
                /// <example></example>
                public string? CalcFromDate { get; set; }

                /// <summary>
                /// Dữ liệu tính đến ngày
                /// </summary>
                /// <example></example>
                public string? CalcToDate { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example></example>
                public string? Customers { get; set; }

                /// <summary>
                /// Công ty
                /// </summary>
                /// <example></example>
                public string? CmpnID { get; set; }
            }

            public class GetItem
            {
                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example></example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example></example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Sản lượng (kg)/Doanh số (VND)
                /// </summary>
                public int? IsRevenue { get; set; }

                /// <summary>
                /// Hợp đồng
                /// </summary>
                public string? ContractID { get; set; }
            }
        }
    }
}
