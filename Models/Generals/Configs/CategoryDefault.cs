using APISmartCity.Models.Systems;

namespace APISmartCity.Models.Categorys
{
    public static class CategoryDefault
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Tên mặc định</example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên 1
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên 2
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên 3
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên 4
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên 5
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên 6
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên 7
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên 8
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên 9
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Item : Content
            {
            }

            public class Add : Item
            {
            }

            public class Add_IsActive : Add
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Edit : Item
            {
                public int? ID { get; set; }
            }

            public class Edit_IsActive : Edit
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Del : Default.Request.Del
            {
            }

            public class EditStatus : Default.Request.EditStatus
            {
            }
        }

        public class Response
        {
        }
    }
}