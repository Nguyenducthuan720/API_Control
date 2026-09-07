namespace DMS.Models.DMS.ShipmentAllowances.ShipmentAllowances;
public static class ShipmentAllowances
{
    public static class Request
    {
        public class Add
        {

            //public string? CmpnID { get; set; }

            public string? FactorID { get;set;} 

            public string? EntryID {get;set;} 
            public DateTime Odate { get;set;}
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }
            public int? NormYear { get; set; }
            public string? NormMonths { get; set; }
            public decimal Amount { get; set; }
            public string? Name { get; set; }
            public string? NameExtention1 { get; set; }
            public string? NameExtention2 { get; set; }
            public string? NameExtention3 { get; set; }
            public string? NameExtention4 { get; set; }
            public string? NameExtention5 { get; set; }
            public string? NameExtention6 { get; set; }
            public string? NameExtention7 { get; set; }
            public string? NameExtention8 { get; set; }
            public string? NameExtention9 { get; set; }
            public string? NameExtention10 { get; set; }

            public string? Link { get; set; }
            public string? Note { get; set; }

            public DateTime FromDate {  get; set; }
            public DateTime ToDate { get; set; }

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

            public List<AllowanceOilDetails> AllowanceString { get; set; }
        }
        public class AllowanceOilDetails
        {
            public int? ReferenceID { get; set; }
            public List<AllowanceString> AllowanceJson { get; set; }
            public string? Note { get; set; }
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
        public class AllowanceString
        {
            public int? Month { get; set; }
            public decimal Quantity { get; set; }
            public int? Unit { get; set; }
        }

        public class Edit : Add
        {
            public string? OID { get; set; }
        }
        public class Submit
        {
            public string? OID { get; set; }
            public int? IsLock { get; set; }
        }
        public class Get
        {
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
        }
        public class GetByID
        {
            public string? OID { get; set; }
        }

        public class Del : GetByID
        {
        }
    }
}