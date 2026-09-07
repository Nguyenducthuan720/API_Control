namespace APISmartCity.Models
{
    public static class TokenAppsVer2
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


                public string? AppCode { get; set; }
            }

            public class Delete : Add
            {
            }
        }

        public class Response
        {
        }
    }
}