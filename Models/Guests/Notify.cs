namespace APISmartCity.Models
{
    public class Notify
    {
        public class Request
        {
            public class UpView
            {
                /// <summary>
                /// Số ID của thông báo
                /// </summary>
                /// <example>1</example>
                public int? NotifyID { get; set; }
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