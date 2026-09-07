namespace APISmartCity.Models.Ver2.Function
{
    public class SmartControlIOT
    {
        public class Request
        {
            public class GetByStationID
            {
                public string? StationID { get; set; }
            }

            public class GetByLocalID
            {
                public string? LocalID { get; set; }
            }


            public class GetZoomDetailID
            {
                public string? ZoneDetailID { get; set; }
            }

            public class GetReportType
            {
                /// <summary>
                /// Total, Details
                /// </summary>
                /// <example>SmartBuoy</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Total, Details
                /// </summary>
                /// <example>Total</example>
                public string? ReportType { get; set; }

                /// <summary>
                /// Khi chartType = Day moi truyen them thong tin nay
                /// </summary>
                /// <example>2024/01/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Khi chartType = Day moi truyen them thong tin nay
                /// </summary>
                /// <example>2024/05/01</example>
                public string? ToDate { get; set; }
            }

            public class GetChartType
            {
                /// <summary>
                /// Day, Month, 3Month, Year
                /// </summary>
                /// <example>Year</example>
                public string? ChartType { get; set; }

                /// <summary>
                /// Khi chartType = Day moi truyen them thong tin nay
                /// </summary>
                /// <example>2024/01/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Khi chartType = Day moi truyen them thong tin nay
                /// </summary>
                /// <example>2024/05/01</example>
                public string? ToDate { get; set; }
            }

            public class GetChartDetails : GetByStationID
            {
                /// <summary>
                /// Day, Month, 3Month, Year
                /// </summary>
                /// <example>Year</example>
                public string? ChartType { get; set; }

                /// <summary>
                /// Khi chartType = Day moi truyen them thong tin nay
                /// </summary>
                /// <example>2024/01/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Khi chartType = Day moi truyen them thong tin nay
                /// </summary>
                /// <example>2024/05/01</example>
                public string? ToDate { get; set; }
            }


            public class ChangeActionSchedule
            {
                /// <summary>
                /// Lịch điều khiển
                /// </summary>
                /// <example>LPT/NLT/003</example>
                public string? OID { get; set; }

                /// <summary>
                /// Hành động, 1 Phát, 2 tạm dựng, 3 tiếp tục, 0 dừng(kết thúc)
                /// </summary>
                /// <example>1</example>
                public int? ActionID { get; set; }
            }
            public class ChangeMode
            {
                public string? StationID { get; set; }

                public string? ControlMode { get; set; }
            }

            public class ChangeAction
            {
                public string? StationID { get; set; }

                public int? ActionPhase { get; set; }

                public int? ActionID { get; set; }

                public int? LightID { get; set; }

                public string? CustomID { get; set; }
            }

          
            public class ChangeActionTraffic
            {
                public string? StationID { get; set; }

                public int? ActionMode { get; set; }

                public dynamic ActionDetail { get; set; }
            }

            public class ChangeActionMonitor
            {
                public string? StationID { get; set; }

                public int? ActionID { get; set; }
            }
        }
    }
}