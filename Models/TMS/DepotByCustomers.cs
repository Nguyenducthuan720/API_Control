namespace APISmartCity.Models.TMS
{
    public static class DepotByCustomers
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>1</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>1</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// ContactName
                /// </summary>
                /// <example>1</example>
                public string? ContactName { get; set; }

                /// <summary>
                /// ContactPhone
                /// </summary>
                /// <example>1</example>
                public string? ContactPhone { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>1</example>
                public string? Request { get; set; }

                /// <summary>
                /// Lat
                /// </summary>
                /// <example>1</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Long
                /// </summary>
                /// <example>1</example>
                public string? Long { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7</example>
                public int? ID { get; set; }

                /// <summary>
                /// Có dùng/ không dùng
                /// </summary>
                /// <example>7</example>
                public int? IsActive { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã khách hàng
                /// </summary>
                /// <example>7</example>
                public int? CustomerID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7</example>
                public int? ID { get; set; }
            }
        }
    }
}