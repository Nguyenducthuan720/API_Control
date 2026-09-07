using System.ComponentModel;

namespace OsControl.Models.DMS.Discounts
{
    public class DiscountLevels
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
                /// <example>PriceCommercials</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>GeneralPrice</example>
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
                /// Ngày CT
                /// </summary>
                /// <example>2025-09-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Tên định mức (VI)
                /// </summary>
                public string? Name { get; set; }

                /// <summary>
                /// Tên định mức (EN)
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
                /// Phòng ban áp dụng
                /// </summary>
                public string? SalesOrgs { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public string? GoodsTypes { get; set; }

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

                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                public List<DiscountLevelDetail> Details { get; set; }
            }

            public class DiscountLevelDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                [DefaultValue(0)]
                public int? ID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example>1</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Nhóm khách hàng
                /// </summary>
                /// <example>1</example>
                public int? CustomerTypeID { get; set; }

                /// <summary>
                /// Loại (0: sản lượng, 1: Doanh số)
                /// </summary>
                public int? IsRevenue { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                public string? Condition { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                public decimal Value { get; set; }

                /// <summary>
                /// Chiết khấu tháng
                /// </summary>
                public int? DiscountValue { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                public string? Condition1 { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                public decimal Value1 { get; set; }

                /// <summary>
                /// Chiết khấu tháng
                /// </summary>
                public int? DiscountValue1 { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                public string? Condition2 { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                public decimal Value2 { get; set; }

                /// <summary>
                /// Chiết khấu tháng
                /// </summary>
                public int? DiscountValue2 { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                public string? Condition3 { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                public decimal Value3 { get; set; }

                /// <summary>
                /// Chiết khấu tháng
                /// </summary>
                public int? DiscountValue3 { get; set; }

                /// <summary>
                /// Điều kiện
                /// </summary>
                public string? Condition4 { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                public decimal Value4 { get; set; }

                /// <summary>
                /// Chiết khấu tháng
                /// </summary>
                public int? DiscountValue4 { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }
        }
    }
}
