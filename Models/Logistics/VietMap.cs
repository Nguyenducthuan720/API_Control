namespace APISmartCity.Models.Logistics
{
    public static class VietMap
    {
        public static class Request
        {
            public class GeoCode
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>Bến Nhà Rồng</example>
                public string? Address { get; set; }
            }

            public class VietMapRoute
            {
                /// <summary>
                /// Danh sách GPS
                /// </summary>
                /// <example>[10.753915,106.574959],[10.749826,106.642388]</example>
                public string? StringPoint { get; set; }
            }

            public class GetRoute
            {
                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.753915,106.574959],[10.789581,106.652680],[10.749826,106.642388]</example>
                public string? StringPoint { get; set; }
            }

            public class GetRouteAddPoint
            {
                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.85155,106.81632],[10.83338,106.75286],[10.89877,106.73628],[10.75930,106.77595]</example>
                public string? StringPoint { get; set; }

                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.875450,106.752670],[10.855150,106.767480]</example>
                public string? Drag { get; set; }

                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.875750,106.752370],[10.855450,106.767180]</example>
                public string? Drop { get; set; }
            }

            public class Routes
            {
                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.753915,106.574959],[10.789581,106.652680],[10.749826,106.642388]</example>
                public string? StringPoint { get; set; }

                /// <summary>
                /// distance
                /// </summary>
                /// <example>1</example>
                public decimal distance { get; set; }

                /// <summary>
                /// weight
                /// </summary>
                /// <example>1</example>
                public decimal weight { get; set; }

                /// <summary>
                /// time
                /// </summary>
                /// <example>1</example>
                public decimal time { get; set; }

                /// <summary>
                /// transfers
                /// </summary>
                /// <example>1</example>
                public int? transfers { get; set; }

                /// <summary>
                /// points_encoded
                /// </summary>
                /// <example>1</example>
                public string? points_encoded { get; set; }

                /// <summary>
                /// Bbox
                /// </summary>
                /// <example>1</example>
                public string? Bbox { get; set; }

                /// <summary>
                /// Points
                /// </summary>
                /// <example>1</example>
                public string? Points { get; set; }

                /// <summary>
                /// Instructions
                /// </summary>
                /// <example>1</example>
                public string? Instructions { get; set; }

                /// <summary>
                /// Snapped_waypoints
                /// </summary>
                /// <example>1</example>
                public string? Snapped_waypoints { get; set; }
            }

            public class RefID
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>Bến Nhà Rồng</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                public string? RefId { get; set; }
            }

            public class GetLatLong
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                public string? RefId { get; set; }
            }

            public class AddGeoCode : GeoCode
            {
                /// <summary>
                /// Lat
                /// </summary>
                /// <example>10.8</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Long
                /// </summary>
                /// <example>106</example>
                public string? Long { get; set; }
            }

            public class Boundary
            {
                public int? Type { get; set; }
                public int? Id { get; set; }
                public string? Name { get; set; }
                public string? Prefix { get; set; }
                public string? FullName { get; set; }
            }

            public class Location
            {
                public string? RefId { get; set; }
                public string? Address { get; set; }
                public string? Name { get; set; }
                public string? Display { get; set; }
                public List<Boundary> Boundaries { get; set; }
                public List<string> Categories { get; set; }
            }
        }

        public class Response
        {
        }
    }
}