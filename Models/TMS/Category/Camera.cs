using APISmartCity.Models.Systems;

namespace APISmartCity.Models.Categorys
{
    public static class Cameras
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ 1
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention1 { get; set; }

                /// <summary>
                /// Địa chỉ 2
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention2 { get; set; }

                /// <summary>
                /// Địa chỉ 3
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention3 { get; set; }

                /// <summary>
                /// Địa chỉ 4
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention4 { get; set; }

                /// <summary>
                /// Địa chỉ 5
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention5 { get; set; }

                /// <summary>
                /// Địa chỉ 6
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention6 { get; set; }

                /// <summary>
                /// Địa chỉ 7
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention7 { get; set; }

                /// <summary>
                /// Địa chỉ 8
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention8 { get; set; }

                /// <summary>
                /// Địa chỉ 9
                /// </summary>
                /// <example>43R Ho Van Hue</example>
                public string? AddressExtention9 { get; set; }

                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.803177</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.6747929</example>
                public string? Long { get; set; }

                /// <summary>
                /// Đường dẫn rtsp chất lượng SD
                /// </summary>
                /// <example>rtsp://namlongSD.com</example>
                public string? RtspSD { get; set; }

                /// <summary>
                /// Đường dẫn rtsp chất lượng HD
                /// </summary>
                /// <example>rtsp://namlongHD.com</example>
                public string? RtspHD { get; set; }

                /// <summary>
                /// Port Rtsp
                /// </summary>
                /// <example>99</example>
                public string? RtspPort { get; set; }

                /// <summary>
                /// Port ws
                /// </summary>
                /// <example>99</example>
                public string? WsPort { get; set; }
            }

            public class ContentRequest : Content
            {
            }

            public class Add : ContentRequest
            {
            }

            public class Edit : ContentRequest
            {
                /// <summary>
                /// Mã trạm camera
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class EditStatus : Default.Request.EditStatus
            {
            }

            public class Del : Default.Request.Del
            {
            }
        }

        public static class Response
        {
        }
    }
}