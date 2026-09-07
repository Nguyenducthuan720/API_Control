namespace APISmartCity.Models.TMS
{
    public static class ReportShipping
    {
        public static class Request
        {
            public class Search
            {
                /// <summary>
                /// Danh sách đội xe
                /// </summary>
                /// <example>21, 230, 507, 607, 691, 23529</example>
                public string? VehicleGroups { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023-04-14</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2023-06-14</example>
                public string? ToDate { get; set; }
            }

            public class SearchVehicle
            {
                /// <summary>
                /// Danh sách đội xe
                /// </summary>
                /// <example>21, 230, 507, 607, 691, 23529</example>
                public string? VehicleTeamID { get; set; }
            }
            
            public class SearchWithDetail : Search
            {
                /// <summary>
                /// Tổng hợp hay chi tiết--Total or Detail
                /// </summary>
                /// <example>Total</example>
                public string? DetailType { get; set; }
            }

            public class DailyDate
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023-04-14</example>
                public string? Daily { get; set; }
            }
        }

        public static class Response
        {
            public class MaintenanceSupplyPrices
            {
                public string? LemonID { get; set; }
                public string? Period { get; set; }
            }

            public class PriceMaterial
            {
                public int? Period { get; set; }
                public string? MaterialID { get; set; }
                public string? MaterialUnit { get; set; }
                public double MaterialUnitPrice { get; set; }
            }
        }
    }
}