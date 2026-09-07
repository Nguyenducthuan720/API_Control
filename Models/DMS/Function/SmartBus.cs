namespace APISmartCity.Models.Ver2.Function
{
    public class SmartBus
    {
        public class Request
        {
            public class GetByID
            {
                /// <summary>
                ///  LicensePlates
                /// </summary>
                /// <example>50F02075</example>
                public string? StationID { get; set; }
            }

            public class GetChartDetail
            {
                /// <summary>
                ///  LicensePlates
                /// </summary>
                /// <example>50F02075</example>
                public string? StationID { get; set; }
                /// <summary>
                ///  Month, 3Month, Year, FromTo
                /// </summary>
                /// <example>Year</example>
                public string? ChartType { get; set; }

                /// <example></example>
                public string? FromDate { get; set; }
                /// <example></example>
                public string? ToDate { get; set; }
            }


            public class GetReportType
            {

                /// <summary>
                /// Companies, Routes, Stations
                /// </summary>
                /// <example>Companies</example>
                public string? ReportType { get; set; }
                /// <summary>
                ///  Month, 3Month, Year, FromTo
                /// </summary>
                /// <example>Year</example>
                public string? ChartType { get; set; }

                /// <example></example>
                public string? FromDate { get; set; }
                /// <example></example>
                public string? ToDate { get; set; }

            }

        }
    }
}
