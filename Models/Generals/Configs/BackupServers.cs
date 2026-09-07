namespace APISmartCity.Models.Ver2.Configs
{
    public class BackupServers
    {
        public class Request
        {
            public class Content
            {
                public int? ID { get; set; }

                public int? BackupID { get; set; }

                /// <summary>
                /// tên server
                /// </summary>
                /// <example>server nam long</example>
                public string? Name { get; set; }

                /// <summary>
                /// tên server mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention1 { get; set; }

                public string? NameExtention2 { get; set; }
                public string? NameExtention3 { get; set; }
                public string? NameExtention4 { get; set; }
                public string? NameExtention5 { get; set; }
                public string? NameExtention6 { get; set; }
                public string? NameExtention7 { get; set; }
                public string? NameExtention8 { get; set; }
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// IP server
                /// </summary>
                /// <example>192.168.1.1</example>
                public string? IP { get; set; }

                /// <summary>
                /// port server
                /// </summary>
                /// <example>21</example>
                public string? Port { get; set; }

                /// <summary>
                /// tài khoản
                /// </summary>
                /// <example>NamLong123</example>
                public string? UserName { get; set; }

                /// <summary>
                /// mật khẩu
                /// </summary>
                /// <example>123</example>
                public string? PassWord { get; set; }

                /// <summary>
                /// loại server
                /// </summary>
                /// <example>FTP</example>
                public int? ServerTypeID { get; set; }

                /// <summary>
                /// cột mở rộng
                /// </summary>
                public string? Extention1 { get; set; }

                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }

                /// <summary>
                /// trạng thái
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
                /// <summary>
                /// ghi chú
                /// </summary>
                /// <example>ghi chú</example>
                public string? Note { get; set; }
            }
        }
    }
}