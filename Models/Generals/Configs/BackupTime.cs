namespace APISmartCity.Models.Ver2.Configs
{
    public  class BackupTime
    {
        public  class Request
        {
            public class Content
            {
                public int? ID { get; set; }
                /// <summary>
                /// ID backup
                /// </summary>
                /// <example></example>
                public int? BackupID { get; set; }

                /// <summary>
                /// giờ
                /// </summary>
                /// <example></example>
                public int? Hour { get; set; }

                /// <summary>
                /// phút
                /// </summary>
                /// <example></example>
                public int? Minute { get; set; }


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

                /// <summary>
                /// cột mở rộng
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

            }
        }
    }
}