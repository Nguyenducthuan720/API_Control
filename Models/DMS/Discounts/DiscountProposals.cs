namespace OsControl.Models.DMS.Discounts
{
    public class DiscountProposals
    {
        public class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }

            public class AddOrEdit
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>Discounts</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>DiscountProposals</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã CT
                /// </summary>
                public string? OID { get; set; }

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
                /// Ngày CT
                /// </summary>
                /// <example>2025-09-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Tên bảng giá (VI)
                /// </summary>
                public string? Name { get; set; }

                /// <summary>
                /// Tên bảng giá (EN)
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
                /// Từ ngày
                /// </summary>
                /// <example>2025-09-24</example>
                public DateTime FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-09-24</example>
                public DateTime ToDate { get; set; }

                /// <summary>
                /// Nhóm giá theo ngành hàng
                /// </summary>
                /// <example></example>
                public string? Areas { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public string? GoodsTypes { get; set; }

                /// <summary>
                /// Doanh số tính từ
                /// </summary>
                public string? CalculateFrom { get; set; }

                /// <summary>
                /// Doanh số tính đến
                /// </summary>
                /// <example></example>
                public string? CalculateTo { get; set; }

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

                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public string? Extention10 { get; set; }
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }

                /// <summary>
                /// Chi tiết chiết khấu
                /// </summary>
                public List<DiscountProposalDetail> Details { get; set; }
            }

            public class DiscountProposalDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Khu vực
                /// </summary>
                public int? AreaID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Doanh số/Sản lượng
                /// </summary>
                public int? IsRevenue { get; set; }

                /// <summary>
                /// Doanh số TB tháng
                /// </summary>
                public decimal MonthlyAverage { get; set; }

                /// <summary>
                /// TSMTBT
                /// </summary>
                public int? TSMTBT { get; set; }

                /// <summary>
                /// CK cũ max
                /// </summary>
                public string? MaxOldLevel { get; set; }

                /// <summary>
                /// SL/DS max cũ
                /// </summary>
                public decimal MaxOldValue { get; set; }

                public string? CurrentDiscounts { get; set; }

                public string? Options { get; set; }

                /// <summary>
                /// Model
                /// </summary>
                public List<DiscountLevel> Levels { get; set; }
            }

            public class DiscountLevel
            {
                /// <summary>
                /// Bước duyệt
                /// </summary>
                /// <example>0</example>
                public int? Step { get; set; }

                /// <summary>
                /// CK max
                /// </summary>
                /// <example>0</example>
                public string? MaxLevel { get; set; }

                /// <summary>
                /// SL min
                /// </summary>
                /// <example>0</example>
                public decimal MinValue { get; set; }

                /// <summary>
                /// Giá trị chiết khấu
                /// </summary>
                /// <example>0</example>
                public decimal Value { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }

            public class GetDiscounts
            {
                /// <summary>
                /// Công ty
                /// </summary>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Khách hàng hàng
                /// </summary>/
                /// <example></example>
                public string? Customers { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example></example>
                public string? GoodsTypes { get; set; }

                /// <summary>
                /// Doanh số tính từ
                /// </summary>
                /// <example></example>
                public string? CalculateFrom { get; set; }

                /// <summary>
                /// Doanh số tính đến
                /// </summary>
                /// <example></example>
                public string? CalculateTo { get; set; }
            }
        }
    }
}