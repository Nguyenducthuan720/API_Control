namespace APISmartCity.Models.Configs
{
    public static class Tools
    {
        public static class Request
        {
            public class ConvertNum2Text
            {
                /// <summary>
                /// Số
                /// </summary>
                /// <example>11111</example>
                public int? Number { get; set; }
            }

            public class BusStops
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>1</example>
                public string? Name { get; set; }

                /// <summary>
                /// NameExtention1
                /// </summary>
                /// <example>1</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Address
                /// </summary>
                /// <example>1</example>
                public string? Address { get; set; }

                /// <summary>
                /// AddressExtention1
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention1 { get; set; }

                /// <summary>
                /// Lat
                /// </summary>
                /// <example>1</example>
                public decimal Lat { get; set; }

                /// <summary>
                /// Long
                /// </summary>
                /// <example>1</example>
                public decimal Long { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }
            }
        }

        public class Response
        {
        }
    }
}