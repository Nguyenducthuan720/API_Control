namespace APISmartCity.Models.TMS
{
    public static class CapacityVehicle
    {
        public static class Request
        {
            public class Capacity
            {
                /// <summary>
                /// Ngày đánh giá
                /// </summary>
                /// <example>2023/06/14</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Đội xe
                /// </summary>
                /// <example>21,230</example>
                public string? VehicleTeamID { get; set; }
            }
        }

        public class Response
        {
        }
    }
}