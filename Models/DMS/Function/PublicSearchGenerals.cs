namespace APISmartCity.Models.Ver2.Function
{
    public static class PublicSearchGenerals
    {
        public static class Request
        {
            public class Get
            {
                public string? SearchKey { get; set; }
                public string? GeoCode { get; set; }
                public int? PageNumber { get; set; }
                public int? PageSize { get; set; }

            }

            public class GetByID
            {
                public string? Id { get; set; }
                public string? GeoCode { get; set; }
            }

        }
    }
}
