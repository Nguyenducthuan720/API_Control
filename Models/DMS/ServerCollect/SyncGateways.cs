namespace APISmartCity.Models.Ver2.SyncGateways
{
    public static class SyncGateways
    {
        public class Requets
        {
            public class Synctype
            {
                /// <summary>
                /// Api Key hệ thống
                /// </summary>
                /// <example>jahkjashhaskhkashkahskahuashkhskashksah</example>
                public string? ApiKey { get; set; }

                /// <summary>
                /// Tên table Sync
                /// </summary>
                /// <example>CompanyConfigs</example>
                public string? TableName { get; set; }

                /// <summary>
                /// Tên Database Sync
                /// </summary>
                /// <example>NLConfiguration</example>
                public string? DBName { get; set; }
            }
        }
    }
}