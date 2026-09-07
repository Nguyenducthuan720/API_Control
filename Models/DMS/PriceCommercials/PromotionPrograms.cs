namespace DMS.Models.DMS.PriceCommercials
{
    public static class PromotionPrograms
    {
        public static class Request
        {

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }
            }

            public class AddOrEdit
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>PriceCommercials</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>PromotionGift</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-05-31</example>
                public string? ODate { get; set; }

                public string? SAPID { get; set; }
                public string? LemonID { get; set; }

                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Tên chương trình (VI)
                /// </summary>
                /// <example></example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên chương trình (EN)
                /// </summary>
                /// <example></example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên chương trình mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-01-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2025-12-31</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Khu vực áp dụng
                /// </summary>
                /// <example></example>
                public string? Areas { get; set; }

                /// <summary>
                /// Tỉnh/thành phố áp dụng
                /// </summary>
                /// <example></example>
                public string? Regions { get; set; }

                /// <summary>
                /// Diễn giải phạm vi áp dụng
                /// </summary>
                /// <example></example>
                public string? RegionExplanation { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example></example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example></example>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Loại khuyến mãi
                /// </summary>
                /// <example>0</example>
                public int? PromotionType { get; set; }

                /// <summary>
                /// Số lượng dự kiến
                /// </summary>
                /// <example></example>
                public int? ExpectedQuantity { get; set; }

                /// <summary>
                /// Đơn giá dự kiến
                /// </summary>
                /// <example></example>
                public decimal ExpectedPrice { get; set; }

                /// <summary>
                /// Doanh thu dự kiến
                /// </summary>
                /// <example></example>
                public decimal ExpectedRevenue { get; set; }

                /// <summary>
                /// Chi phí khuyến mãi (%)
                /// </summary>
                /// <example></example>
                public int? PromotionalCostPercent { get; set; }

                /// <summary>
                /// Chi phí khuyến mãi (VNĐ)
                /// </summary>
                /// <example></example>
                public decimal PromotionalCostAmount { get; set; }

                /// <summary>
                /// Điều kiện khác
                /// </summary>
                /// <example></example>
                public string? OtherCondition { get; set; }

                /// <summary>
                /// Loại tiền tệ
                /// </summary>
                /// <example></example>
                public int? CurrencyTypeID { get; set; }

                /// <summary>
                /// Tỉ giá
                /// </summary>
                /// <example></example>
                public decimal CurrencyRate { get; set; }

                /// <summary>
                /// Ngày tỉ giá
                /// </summary>
                /// <example>2025-10-18</example>
                public string? CurrencyDate { get; set; }

                /// <summary>
                /// Khách hàng thương mại thuộc kênh
                /// </summary>
                /// <example></example>
                public string? CommercialSalesChannels { get; set; }

                /// <summary>
                /// Cộng dồn sản lượng hàng nợ và đặt sản xuất từ ngày
                /// </summary>
                /// <example>2025-10-18</example>
                public string? CumulativeFromDate { get; set; }

                /// <summary>
                /// Cộng dồn sản lượng hàng nợ và đặt sản xuất đến ngày
                /// </summary>
                /// <example>2025-10-18</example>
                public string? CumulativeToDate { get; set; }

                /// <summary>
                /// Khách hàng trực tiếp thuộc kênh
                /// </summary>
                /// <example></example>
                public string? DirectSalesChannels { get; set; }

                /// <summary>
                /// Hỗ trợ hàng đặt trước từ ngày
                /// </summary>
                /// <example>2025-10-18</example>
                public string? SupportPreorderFromDate { get; set; }

                /// <summary>
                /// Hỗ trợ hàng đặt trước đến ngày
                /// </summary>
                /// <example>2025-10-18</example>
                public string? SupportPreorderToDate { get; set; }

                /// <summary>
                /// Số lượng hàng đặt
                /// </summary>
                /// <example></example>
                public int? OrderQuantity { get; set; }

                /// <summary>
                /// Số lượng tặng
                /// </summary>
                /// <example></example>
                public int? GiftQuantity { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// File đính kèm
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

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

                public List<PromotionGift> Gifts { get; set; }

                public List<PromotionDetail> Details { get; set; }
            }

            public class PromotionGift
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// ID sinh tạm
                /// </summary>
                public int? TempID { get; set; }

                /// <summary>
                /// Tên nhóm quà tặng
                /// </summary>
                /// <example></example>
                public string? Name { get; set; }

                /// <summary>
                /// Quà tặng
                /// </summary>
                /// <example></example>
                public string? Gifts { get; set; }
            }

            public class PromotionDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Model
                /// </summary>
                public int? ModelID { get; set; }

                /// <summary>
                /// Quy cách đóng gói
                /// </summary>
                public int? PackingType2ID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? ItemID { get; set; }

                /// <summary>
                /// ĐVT bán
                /// </summary>
                public int? UnitSaleID { get; set; }

                /// <summary>
                /// SL từ
                /// </summary>
                public int? From { get; set; }

                /// <summary>
                /// SL đến
                /// </summary>
                public int? To { get; set; }

                /// <summary>
                /// Giá niêm yết
                /// </summary>
                public decimal BasePrice { get; set; }

                /// <summary>
                /// Giảm giá/KG
                /// </summary>
                public decimal DiscountPerKg { get; set; }

                /// <summary>
                /// Giảm giá/ĐVT bán
                /// </summary>
                public decimal DiscountPerUnit { get; set; }

                /// <summary>
                /// Tùy chọn quà tặng
                /// </summary>
                /// <example></example>
                public int? GiftOption { get; set; }

                /// <summary>
                /// Danh sách quà tặng
                /// </summary>
                /// <example></example>
                public int? GiftID { get; set; }

                /// <summary>
                /// Danh sách quà tặng
                /// </summary>
                /// <example></example>
                public int? GiftTempID { get; set; }

                /// <summary>
                /// SL tặng
                /// </summary>
                /// <example></example>
                public int? GiftQuantity { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
            }
        }
    }
}