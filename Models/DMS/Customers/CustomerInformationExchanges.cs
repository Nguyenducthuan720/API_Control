namespace APISmartCity.Models.CustomerInformationExchanges
{
    public static class CustomerInformationExchanges
    {
        public class Request
        {

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }


            public class AddOrEdit
            {
                public string? OID { get; set; }
                public string? EntryID { get; set; }
                public string? FactorID { get; set; }
                public string? SAPID { get; set; }
                public string? LemonID { get; set; }
                public DateTime ODate { get; set; }
                public int? UserID { get; set; }
                public int? CustomerID { get; set; }
                public string? Note { get; set; }
                public int? ReasonTypeID { get; set; }
                public string? Content { get; set; }
                public string? Link { get; set; }
                public int? FeedBackTypeID { get; set; }
                public string? FeedbackContent { get; set; }
                public string? FeedbackLink { get; set; }
                public int? ContactMethodID { get; set; }
                public DateTime ContactDate { get; set; }
                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public string? Extention10 { get; set; }
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }
                public int? IsActive { get; set; }

                public string? CmpnID { get; set; }
            }
            public class Del : GetByID
            {
            }
            public class GetByTaxCode
            {
                public string? TaxCode { get; set; }
            }
            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; } 
            }
        }
    }
}