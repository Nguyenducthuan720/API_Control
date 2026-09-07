namespace DMS.Models.TMS.Category
{
    public static class nPLChargingStationDetails
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Mã loại thu phí
                /// </summary>
                /// <example>23320</example>
                public int? ChargingStationFareID { get; set; }

                /// <summary>
                /// vé lượt
                /// </summary>
                /// <example>100000</example>
                public decimal DailyFare { get; set; }

                /// <summary>
                /// vé tháng
                /// </summary>
                /// <example>1000000</example>
                public decimal MonthlyFare { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// Mã trạm thu phí
                /// </summary>
                /// <example>2897</example>
                public int? ReferenceID { get; set; }

                /// <summary>
                /// Danh sách loại phí thu
                /// </summary>
                public List<Content> Details { get; set; }
            }

            public class Edit : Add
            {
            }

            public class Get
            {
                /// <summary>
                /// Mã trạm thu phí
                /// </summary>
                /// <example>2897</example>
                public int? ReferenceID { get; set; }
            }
        }
    }
}