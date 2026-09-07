namespace APISmartCity.Models
{
    public static class GuestComments
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }

                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Trung</example>
                public string? Name { get; set; }

                /// <summary>
                /// Phone
                /// </summary>
                /// <example>0333666999</example>
                public string? Phone { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>trung@gmail.com</example>
                public string? Email { get; set; }

                /// <summary>
                /// Comment
                /// </summary>
                /// <example>Tôi hay ngồi dưới gốc cây này chống nắng</example>
                public string? Comment { get; set; }

                /// <summary>
                /// Ratings
                /// </summary>
                /// <example>4.0</example>
                public string? Ratings { get; set; }
            }

            public class GetByGeoCode
            {
                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? GeoCode { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }

                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? GeoCode { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
        }
    }
}