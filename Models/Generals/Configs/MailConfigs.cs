namespace APISmartCity.Models.Ver2.Configs
{
    public class MailConfigs
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Email
                /// </summary>
                /// <example>kinhdoanh@nlt-group.com</example>
                public string? Email { get; set; }
                /// <summary>
                /// Email
                /// </summary>
                /// <example>kinhdoanh@nlt-group.com</example>
                public string? EmailCC { get; set; }

                /// <summary>
                /// Password
                /// </summary>
                /// <example>123</example>
                public string? MailPass { get; set; }

                /// <summary>
                /// MailServer
                /// </summary>
                /// <example>smtp.gmail.com</example>
                public string? MailServer { get; set; }

                /// <summary>
                /// MailPort
                /// </summary>
                /// <example>587</example>
                public int MailPort { get; set; }

                /// <summary>
                /// SSL
                /// </summary>
                /// <example>1</example>
                public int? SSL { get; set; }

                public string? Subject { get; set; }
                public string? Body { get; set; }


            }

            public class Add : Content
            {
                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// MailConfigID
                /// </summary>
                /// <example>1006</example>
                public int? MailConfigID { get; set; }
            }

            public class GetByCmpnID
            {
                /// <summary>
                /// CmpnID
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }
            }
            public class GetByMailConfigID
            {
                /// <example>1</example>
                public string? MailConfigID { get; set; }
            }
            public class EditStatus : GetByMailConfigID
            {
                /// <example>0</example>
                public string? IsActive { get; set; }
            }
            public class Edit : Content
            {
                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
                public string? MailConfigID { get; set; }
            }
        }
    }
}