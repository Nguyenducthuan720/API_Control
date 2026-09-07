namespace APISmartCity.Models
{
    public class NotifyVer2
    {
        public class Request
        {
            public class Get
            {
                /// <summary>
                /// Loại nhóm
                /// </summary>
                /// <example>GroupUsers</example>
                public string? GroupType { get; set; }

                /// <summary>
                /// Loại app
                /// </summary>
                /// <example>wDMS</example>
                public string? AppCode { get; set; }
            }

            public class UpView
            {
                /// <summary>
                /// Số ID của thông báo
                /// </summary>
                /// <example>1</example>
                public string? ListDetailID { get; set; }
            }

            public class GetTop30
            {
                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>Air</example>
                public string? GeoCode { get; set; }
            }
        }

        public class Response
        {
        }
    }
}