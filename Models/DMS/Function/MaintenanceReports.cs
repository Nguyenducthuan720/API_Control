namespace APISmartCity.Models.Function
{
    public static class MaintenanceReports
    {
        public static class Request
        {
            public class GetEntryID : FromDateToDate
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>LightMaintence</example>
                public string? EntryID { get; set; }
            }
            public class FromDateToDate
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2021-08-22</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2021-09-11</example>
                public string? ToDate { get; set; }
            }
            public class GeocodeAccept
            {
                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>SmartLighting</example>
                public string? GeoCode { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Ngày tạo
                /// </summary>
                /// <example>2023-11-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Mã sự cố
                /// </summary>
                /// <example>1</example>
                public int? IncidentID { get; set; }

                /// <summary>
                /// Tạo ở web
                /// </summary>
                /// <example>1</example>
                public int? IsCreateByUser { get; set; }

                /// <summary>
                /// Mô tả yêu cầu
                /// </summary>
                /// <example>Sử lý sự cố cây xanh</example>
                public string? FullContent { get; set; }

                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.802343270986903</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.67625829413228</example>
                public string? Long { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example>1</example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Xin chào</example>
                public string? Note { get; set; }

                /// <summary>
                /// Kích hoạt
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// URL hình ảnh, nối bởi dấu chấm phẩy (;)
                /// </summary>
                /// <example>http;http;http</example>
                public string? LinkImages { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>LightMaintence</example>
                public string? EntryID { get; set; }
            }
            public class Edit  
            {

                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }
                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày tạo
                /// </summary>
                /// <example>2023-11-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Mã sự cố
                /// </summary>
                /// <example>1</example>
                public int? IncidentID { get; set; }

                /// <summary>
                /// Mô tả yêu cầu
                /// </summary>
                /// <example>Sử lý sự cố cây xanh</example>
                public string? FullContent { get; set; }

                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.802343270986903</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.67625829413228</example>
                public string? Long { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example>1</example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Xin chào</example>
                public string? Note { get; set; }

                /// <summary>
                /// Kích hoạt
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// URL hình ảnh, nối bởi dấu chấm phẩy (;)
                /// </summary>
                /// <example>http;http;http</example>
                public string? LinkImages { get; set; }
            }

            public class Accept
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCDT/23/11/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Lý do chấp thuận
                /// </summary>
                /// <example>Hợp lệ</example>
                public string? ApprovalDescription { get; set; }
            }

            public class Reject
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCDT/23/11/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Lý do từ chối
                /// </summary>
                /// <example>Không hơp lệ</example>
                public string? RejectDescription { get; set; }
            }
        }
    }
}