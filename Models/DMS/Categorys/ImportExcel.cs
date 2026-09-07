namespace APISmartCity.Models.Ver2.Categorys
{
    public static class ImportExcel
    {
        public class Requets
        {
            public class ImportExcel
            {
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? CategoryType { get; set; }
            }

            public class Mapping
            {
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
            }

            public class Trans
            {
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
            }
        }
    }
}