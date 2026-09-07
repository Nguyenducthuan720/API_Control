namespace DMS.Models.DMS.Configs
{
    public class DocumentTypes
    {
        public class Request
        {
            public class Add
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Mã
                /// </summary>
                /// <example></example>
                public string? Code { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Hợp đồng</example>
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
                /// Lệnh SQL
                /// </summary>
                /// <example></example>
                public string? Formula { get; set; }

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
                /// Công ty áp dụng
                /// </summary>
                /// <example>0</example>
                public string? CmpnIDList { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

                /// <summary>
                /// Dùng/không
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Nghiệp vụ áp dụng
                /// </summary>
                public List<Factor> Datas { get; set; }
            }

            public class Get
            {
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
            }

            public class GetByID
            {
                public int? ID { get; set; }
            }

            public class GetDocuments : GetByID
            {
                public int? CustomerID { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Entry
            {
                public string? EntryID { get; set; }
            }

            public class Factor
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>Contracts</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng theo nghiệp vụ
                /// </summary>
                /// <example>PrincipalContract</example>
                public List<Entry> Entry { get; set; }
            }
        }
    }
}
