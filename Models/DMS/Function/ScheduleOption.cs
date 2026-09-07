namespace APISmartCity.Models.Function
{
    public static class ScheduleOptions
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
                /// Danh sách độ sáng đèn
                /// </summary>
                /// <example>1:30,2:50,3:40,4:30</example>
                public string? ScheduleLists { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã lịch điều khiển
                /// </summary>
                /// <example>LÐK/24/04/003</example>
                public string? OID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã lịch điều khiển
                /// </summary>
                /// <example>LÐK/24/04/003</example>
                public string? OID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã lịch điều khiển
                /// </summary>
                /// <example>LÐK/24/04/003</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
        }
    }
}