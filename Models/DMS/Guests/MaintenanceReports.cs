namespace APISmartCity.Models.Ver2.Guests
{
    public class MaintenanceReports
    {
        public static class Request
        {
            public class Add
            {
                 
                public string? GeoCode { get; set; }
                public int? IncidentID { get; set; }
                public string? FullContent { get; set; }
              
                public string? Lat { get; set; }
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
            public class getbyid
            {
                public string? OID { get; set; }

            }
            
        }
    }
}
