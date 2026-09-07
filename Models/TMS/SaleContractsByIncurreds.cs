namespace APISmartCity.Models.TMS
{
    public static class SaleContractsByIncurreds
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// FeeType
                /// </summary>
                /// <example></example>
                public string? FeeType { get; set; }

                /// <summary>
                /// FeeID
                /// </summary>
                /// <example>0</example>
                public int? FeeID { get; set; }

                /// <summary>
                /// nPLUnitID
                /// </summary>
                /// <example>744</example>
                public int? nPLUnitID { get; set; }

                /// <summary>
                /// UnitPrice
                /// </summary>
                /// <example>0.00</example>
                public decimal UnitPrice { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }
            }
        }

        public class Response
        {
        }
    }
}