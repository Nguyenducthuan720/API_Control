namespace APISmartCity.Models.Ver2.ShippingDetailByIncurreds;

public static class ShippingDetailByIncurreds
{
    public static class Request
    {
        public class Add
        {
            //public string? CmpnID { get; set; }
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public string? OID { get; set; }
            public DateTime Odate { get; set; }
       
            public string? ReferenceID { get; set; }
            public string? FeeType { get; set; }
            public int? FeeID { get; set; }
            public int? TollStationID { get; set; }
            public decimal RequestMoney { get; set; }
            public int? IsHasInvoice { get; set; }
            public string? Link { get; set; }
            public string? Note { get; set; }
            public int? IsAddByDriver { get; set; }
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
        }
        public class Edit : Add
        {
            public int? ID { get; set; }
        }
        public class Submit
        {
            public string? OID { get; set; }
            public int? IsLock { get; set; }
        }
        public class Get
        {
            public int? IsApproval { get; set; }
        }
        public class GetByID
        {
            public int? ID { get; set; }
        }

        public class GetByReferenceID
        {
            public string? ReferenceID { get; set; }
        }

        public class Del : GetByID
        {
        }
    }
}