namespace APISmartCity.Models.TMS
{
    public static class ShippingsDetailsByTollFees
    {
        public static class Request
        {
            public class GetByOID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }

                /// <summary>
                /// ChargingStationID
                /// </summary>
                /// <example>1</example>
                public int? ChargingStationID { get; set; }

                /// <summary>
                /// TicketType
                /// </summary>
                /// <example>1</example>
                public int? TicketType { get; set; }

                /// <summary>
                /// TicketPrice
                /// </summary>
                /// <example>1</example>
                public decimal TicketPrice { get; set; }

                /// <summary>
                /// TicketTime
                /// </summary>
                /// <example>2023-05-08 3:10:30</example>
                public string? TicketTime { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example>1</example>
                public string? Extention9 { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
        }

        public class Response
        {
        }
    }
}