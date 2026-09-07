namespace APISmartCity.Models.nPL
{
    public static class ReportProcess
    {
        public static class Request
        {
            public class Customers
            {
                /// <summary>
                /// Mã khách hàng
                /// </summary>
                /// <example>455</example>
                public int? CustomerID { get; set; }

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

                /// <summary>
                /// Đã chắc in hay chưa
                /// </summary>
                /// <example>1</example>
                public int? IsPrint { get; set; }
            }

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

            public class CmpnSearch : Search
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }
            }

            public class Cmpn
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

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

            public class HourSearch : Search
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Loại giờ: 0 cả giờ hành chính và ngoài giờ, 1 hành chính, 2 ngoài giờ
                /// </summary>
                /// <example>1</example>
                public int? HourType { get; set; }
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