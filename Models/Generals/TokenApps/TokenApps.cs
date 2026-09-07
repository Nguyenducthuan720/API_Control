namespace APISmartCity.Models
{
    public static class TokenApps
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// Mã FireBase
                /// </summary>
                /// <example>E0F2301F9A83CB76F8</example>
                public string? Token { get; set; }

                /// <summary>
                /// Không cần nhập
                /// </summary>
                /// <example>2</example>
                public string? UserID { get; set; }
            }

            public class Delete
            {
                /// <summary>
                /// Mã FireBase
                /// </summary>
                /// <example>E0F2301F9A83CB76F8</example>
                public string? Token { get; set; }
            }
        }

        public class Response
        {
        }
    }
}