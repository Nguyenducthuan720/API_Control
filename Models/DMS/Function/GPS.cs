namespace APISmartCity.Models.Ver2.Function
{
    public class GPS
    {
        public class Request
        {
            public class AddGPS
            {
                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.803177</example>
                public string? Lat { get; set; }
                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.6747929</example>

                public string? Long { get; set; }
                /// <summary>
                /// Hướng
                /// </summary>
                /// <example>0</example>

                public string? Direction { get; set; }

            }
            public class AddGPSList
            {
                public List<AddGPS> ListGPS { get; set; }
            }

            public class GetByID
            {
                public int? ID { get; set; }
            }

        }
    }
}
