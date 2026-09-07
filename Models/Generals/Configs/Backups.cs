using System.Data;

namespace APISmartCity.Models.Ver2.Configs
{
    public static class Backups
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Mã Code
                /// </summary>
                /// <example>0</example>
                public string? Code { get; set; }
                public string? LemonID { get; set; }

                /// <summary>
                /// Tên backup
                /// </summary>
                /// <example>Nam long 1</example>
                public string? Name { get; set; }

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
                /// Số ngày lưu trữ
                /// </summary>
                /// <example>10</example>
                public int? SaveDay { get; set; }

                /// <summary>
                /// danh sách database
                /// </summary>
                /// <example>NLCategory,NLSmartGas</example>
                public string? ListDB { get; set; }
                public string? ListBT { get; set; }

                /// <summary>
                /// Mã liên kết
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public int? IsActive { get; set; }
                /// <summary>
                /// ghi chú
                /// </summary>
                /// <example>ghi chú</example>
                public string? Note { get; set; }
            }

            public class Add : Content
            {
                public List<BackupServers.Request.Content> ListBackupServer { get; set; }
                public List<BackupTime.Request.Content> ListBackupTime { get; set; }

            }
            public class GetByID
            {
                /// <summary>
                /// Mã backup
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
          
            public class Edit : Content
            {
                public int? ID { get; set; }
                public List<BackupServers.Request.Content> ListBackupServer { get; set; }
                public List<BackupTime.Request.Content> ListBackupTime { get; set; }
            }

            public class Delete : GetByID
            {
            }
        }

        public class Response
        {
        }
    }
}