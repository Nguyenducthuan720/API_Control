namespace APISmartCity.Models.Categorys
{
    public static class Status
    {
        public static class Request
        {
            public class Get
            {
                /// <summary>
                /// StatusTypes
                /// </summary>
                /// <example>DriverRequests</example>
                public string? StatusType { get; set; }
            }

            public class Content
            {
                public int? Status {  get; set; }
                public string? StatusType { get; set; }
                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? Name { get; set; }


                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Test</example>
                public string? Param1 { get; set; }
 
                public string? Param2 { get; set; }
 
                public string? Param3 { get; set; }

                public string? Param4 { get; set; }

                public string? Param5 { get; set; }

                public string? Param6 { get; set; }
 
                public string? Param7 { get; set; }

                public string? Param8 { get; set; }

                public string? Param9 { get; set; }

                public string? Param10 { get; set; }

                /// <summary>
                /// StatusColor
                /// </summary>
                /// <example>Blue</example>
                public string? StatusColor { get; set; }

                /// <summary>
                /// StatusTextColor
                /// </summary>
                /// <example>Blue</example>
                public string? StatusTextColor { get; set; }
                /// <summary>
                /// StatusTextColor
                /// </summary>
                /// <example>Blue</example>
                public string? StatusProgressColor { get; set; }

                /// <summary>
                /// Trang thai
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                public int? Sort { get; set; }

                /// <summary>
                /// note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Icon
                /// </summary>
                /// <example>https://</example>
                public string? StatusIcon { get; set; }
            }
            public class Add : Content
            {
            }
            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>Test</example>
                public int? ID { get; set; }
            }
        }
    }
}