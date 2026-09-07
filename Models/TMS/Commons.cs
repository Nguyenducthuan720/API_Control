namespace APISmartCity.Models.TMS
{
    public static class Commons
    {
        public static class Request
        {
            public class Chart
            {
                /// <summary>
                /// Loại chart (Year, Month,Week)
                /// </summary>
                /// <example>Year</example>
                public string? Type { get; set; }

                /// <summary>
                /// Loại dữ liệu (Request, Repair, Maintenance)
                /// </summary>
                /// <example>Request</example>
                public string? DataType { get; set; }
            }

            public class LicensePlate
            {
                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>02779-50H</example>
                public string? LicensePlates { get; set; }
            }

            public class Detail
            {
                /// <summary>
                /// Loại bảng (có trong StatName của Dashboard)
                /// </summary>
                /// <example>VTotal</example>
                public string? Type { get; set; }
            }
        }
    }
}