using APISmartCity.Models.Systems;

namespace APISmartCity.Models.Categorys
{
    public static class Regions
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Mã vùng cha
                /// </summary>
                /// <example>50</example>
                public int? ParentId { get; set; }

                /// <summary>
                /// Mã SAP
                /// </summary>
                public string? SAPID { get; set; }

                /// <summary>
                /// Tên vùng
                /// </summary>
                /// <example>Cần Thơ</example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên tiếng Anh
                /// </summary>
                /// <example>CanTho</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên vùng 2
                /// </summary>
                /// <example></example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên vùng 3
                /// </summary>
                /// <example></example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên vùng 4
                /// </summary>
                /// <example></example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên vùng 5
                /// </summary>
                /// <example></example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên vùng 6
                /// </summary>
                /// <example></example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên vùng 7
                /// </summary>
                /// <example></example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên vùng 8
                /// </summary>
                /// <example></example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên vùng 9
                /// </summary>
                /// <example></example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
                public string? Code { get; set; }
                public string? Postalcode { get; set; }
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
                public int? LocationType { get; set; }
                public decimal Lat { get; set; }
                public decimal Long { get; set; }
                public int? SalesAreaID { get; set; }
                public string? CustomName { get; set; }

            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã vùng
                /// </summary>
                /// <example>50</example>
                public int? ID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class GetByLevel
            {
                public int? Level { get; set; }
            }

            public class GetByParentID
            {
                public int? ParentId { get; set; }
            }

            public class EditStatus : Default.Request.EditStatus
            {
            }

            public class Del : Default.Request.Del
            {
            }
        }
    }
}