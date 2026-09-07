namespace APISmartCity.Models.Ver2.Categorys
{
    public static class AlertsSetups
    {
        public class Requets
        {
            public class Content
            {
                /// <summary>
                /// StationID
                /// </summary>
                /// <example></example>
                public string? StationID { get; set; }

                /// <summary>
                /// LoseConnect
                /// </summary>
                /// <example>0</example>
                public int? LoseConnect { get; set; }

                /// <summary>
                /// LoseConnectPeriod
                /// </summary>
                /// <example>0</example>
                public int? LoseConnectPeriod { get; set; }

                /// <summary>
                /// DeviceWarning
                /// </summary>
                /// <example>0</example>
                public int? DeviceWarning { get; set; }

                /// <summary>
                /// DeviceWarningPeriod
                /// </summary>
                /// <example>0</example>
                public int? DeviceWarningPeriod { get; set; }

                /// <summary>
                /// LowBatteryWarning
                /// </summary>
                /// <example>0</example>
                public int? LowBatteryWarning { get; set; }

                /// <summary>
                /// LowBatteryWarningPeriod
                /// </summary>
                /// <example>0</example>
                public int? LowBatteryWarningPeriod { get; set; }

                /// <summary>
                /// ExcessiveWarning
                /// </summary>
                /// <example>0</example>
                public int? ExcessiveWarning { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// StationID
                /// </summary>
                /// <example>2010</example>
                public string? StationID { get; set; }

                /// <summary>
                /// StationID
                /// </summary>
                /// <example>2010</example>
                public string? GeoCode { get; set; }
            }

            public class GetIndicatorCode : Get
            {
                /// <summary>
                /// IndicatorCode
                /// </summary>
                /// <example>CO2</example>
                public string? IndicatorCode { get; set; }
            }

            public class EditNodeIndicatorWarning : GetIndicatorCode
            {
                public string? ListIndicatorWarning { get; set; }
                public int? IsWarning { get; set; }
            }

            public class GetActive
            {
                /// <summary>
                /// StationID
                /// </summary>
                /// <example>2010</example>
                public string? StationID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// StationID
                /// </summary>
                /// <example>6</example>
                public int? ID { get; set; }
            }

            public class Add : Content

            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>6</example>
                public int? ID { get; set; }

                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>6</example>
                public string? GeoCode { get; set; }
            }
        }
    }
}