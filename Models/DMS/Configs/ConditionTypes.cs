namespace DMS.Models.DMS.Configs;

public static class ConditionTypes
{
    public class Request
    {
        public class Add
        {
            public int? ID { get; set; }
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }

            /// <summary>
            /// Loại điều kiện
            /// </summary>
            /// <example>Price</example>
            public string? EntryType { get; set; }

            /// <summary>
            /// Mã
            /// </summary>
            public string? Code { get; set; }

            /// <summary>
            /// Tên
            /// </summary>
            /// <example>Bán cơ sở (+VAT)</example>
            public string? Name { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention1 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention2 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention3 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention4 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention5 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention6 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention7 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention8 { get; set; }
            
            /// <summary>
            /// Tên mở rộng
            /// </summary>
            public string? NameExtention9 { get; set; }
            
            /// <summary>
            /// Điều kiện tính (Price/%)
            /// </summary>
            public string? Condition { get; set; }

            /// <summary>
            /// Tăng/giảm giá trị (+/-)
            /// </summary>
            /// <example>+</example>
            public string? Operator { get; set; }

            /// <summary>
            /// Phương thức tính
            /// </summary>
            public string? FormulaType { get; set; }

            /// <summary>
            /// Công thức tính giá
            /// </summary>
            public string? Formula { get; set; }

            /// <summary>
            /// Áp chiết khấu
            /// </summary>
            public int? ApplyDiscount { get; set; }

            /// <summary>
            /// Áp khuyến mãi
            /// </summary>
            public int? ApplyPromotion { get; set; }

            /// <summary>
            /// Áp trưng bày
            /// </summary>
            public int? ApplyExhibition { get; set; }

            /// <summary>
            /// Áp hỗ trợ vận chuyển
            /// </summary>
            public int? ApplyShipping { get; set; }

            /// <summary>
            /// Đơn vị tính
            /// </summary>
            public int? UnitID { get; set; }

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

            /// <summary>
            /// Ghi chú
            /// </summary>
            public string? Note { get; set; }
            
            /// <summary>
            /// Đang hoạt động
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
        }

        public class Get
        {
            /// <summary>
            /// Loại điều kiện
            /// </summary>
            /// <example>Price</example>
            public string? EntryType { get; set; }
        }

        public class GetByID
        {
            public int? ID { get; set; }
        }

        public class Del : GetByID
        {
        }
    }
}