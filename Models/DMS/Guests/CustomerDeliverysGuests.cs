namespace APISmartCity.Models.Ver2.Categorys
{
    public static class CustomerDeliverysGuests
    {
        public class Requets
        {
            public class Content
            {
                public string? DepotName { get; set; }

                public string? ContactName { get; set; }

                public string? ContactPhone { get; set; }

                public string? ContactAddress { get; set; }

                public int? DistrictID { get; set; }

                public int? CityID { get; set; }

                public int? RegionID { get; set; }

                public string? Request { get; set; }

                public string? Lat { get; set; }

                public string? Long { get; set; }
                public string? AddressType { get; set; }
                public int? IsDefault { get; set; }

                public string? Extention1 { get; set; }

                public string? Extention2 { get; set; }

                public string? Extention3 { get; set; }

                public string? Extention4 { get; set; }

                public string? Extention5 { get; set; }

                public string? Extention6 { get; set; }

                public string? Extention7 { get; set; }

                public string? Extention8 { get; set; }

                public string? Extention9 { get; set; }

                public string? Note { get; set; }
                public int? IsActive { get; set; }
            }

            public class Get
            {
            }

            public class GetByID
            {
                public int? ID { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
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