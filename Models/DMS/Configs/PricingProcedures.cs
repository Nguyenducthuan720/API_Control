namespace DMS.Models.DMS.Configs
{
    public class PricingProcedures
    {
        public class Request
        {
            public class Add
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Tổ chức bán hàng
                /// </summary>
                public string? SalesOrgs { get; set; }

                /// <summary>
                /// Kênh bán hàng
                /// </summary>
                /// <example></example>
                public string? SalesChannels { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public string? GoodsTypes { get; set; }

                /// <summary>
                /// Loại chứng từ
                /// </summary>
                /// <example>Z1</example>
                public string? DocTypes { get; set; }

                /// <summary>
                /// Loại khách hàng
                /// </summary>
                /// <example>Z</example>
                public string? CustomerTypes { get; set; }

                /// <summary>
                /// Mã
                /// </summary>
                public string? Code { get; set; }

                /// <summary>
                /// Bộ key áp dụng
                /// </summary>
                public string? ConditionKeys { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>KIMTIN_Bảng giá Bán St</example>
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

                /// <summary>
                /// Công ty áp dụng
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Chi tiết
                /// </summary>
                public List<AddDetail> Details { get; set; }
            }

            public class AddDetail 
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Cấu trúc bảng giá
                /// </summary>
                public int? PricingProcedureID { get; set; }

                /// <summary>
                /// Tiêu chí tính giá
                /// </summary>
                public int? ConditionTypeID { get; set; }

                /// <summary>
                /// Bước
                /// </summary>
                public int? Step { get; set; }

                /// <summary>
                /// Từ bước
                /// </summary>
                public int? FromStep { get; set; }

                /// <summary>
                /// Đến bước
                /// </summary>
                public int? ToStep { get; set; }

                /// <summary>
                /// Loại công thức
                /// </summary>
                public string? FormulaType { get; set; }

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
}
