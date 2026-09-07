using static APISmartCity.Models.Systems.Default.Request;

namespace APISmartCity.Models.Ver2.Categorys
{
    public static class EventSystems
    {
        public class Requets
        {
            public class Content : EventExtention
            {
                /// <summary>
                /// FunctionType
                /// </summary>
                /// <example>LOCK</example>
                public string? FunctionType { get; set; }
                
                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>SmartLighting</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Code
                /// </summary>
                /// <example>AAA</example>
                public string? Code { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? Title { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention1 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention2 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention3 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention4 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention5 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention6 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention7 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention8 { get; set; }

                /// <summary>
                /// Tiêu đề
                /// </summary>
                /// <example>Test</example>
                public string? TitleExtention9 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? Body { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention1 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention2 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention3 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention4 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention5 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention6 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention7 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention8 { get; set; }

                /// <summary>
                /// Nội dung thông báo
                /// </summary>
                /// <example>Test</example>
                public string? BodyExtention9 { get; set; }

                /// <summary>
                /// Ảnh icon
                /// </summary>
                /// <example>AAaaaaaaaaaaaaaA</example>
                public string? Image { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Test</example>
                public string? Note { get; set; }

                /// <summary>
                /// Dùng/không
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Công ty áp dụng
                /// </summary>
                /// <example>0</example>
                public string? CmpnIDList { get; set; }

                /// <summary>
                /// Nghiệp vụ áp dụng
                /// </summary>
                public List<Factor> Datas { get; set; }
            }

            public class GetByID
            {
                public int? ID { get; set; }
            }

            public class ByEntry
            {
                public string? EntryType { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
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