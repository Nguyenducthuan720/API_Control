namespace APISmartCity.Models.Ver2.Function
{
    public class DashboardMaintenanceProcess
    {
        public static class Request
        {
            public class EntryFromDateToDateReportType
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/03/10</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/05/10</example>
                public string? ToDate { get; set; }
                public string? ReportType { get; set; }
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>LightMaintence</example>
                public string? EntryID { get; set; }
            }
            public class GetEntryIDFromDateToDate
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2024/03/10</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2024/05/10</example>
                public string? ToDate { get; set; }
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>LightMaintence</example>
                public string? EntryID { get; set; }
            }
            public class GetEntryID
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>LightMaintence</example>
                public string? EntryID { get; set; }
            }
        }
    }
}
