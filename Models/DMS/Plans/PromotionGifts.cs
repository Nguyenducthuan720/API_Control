namespace DMS.Models.DMS.Plans
{
    public class PromotionGifts
    {
        public static class Request
        {
            public class GetByOID
            {
                public string? OID { get; set; }
            }
            public class Add
            {
                public string? OID { get; set; }
                public string? SAPID { get; set; }
                public string? LemonID { get; set; }
                public DateTime ODate { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? CmpnID { get; set; }
                public string? ReferenceID { get; set; }
                public int? EventTypeID { get; set; }
                public int? GiftID { get; set; }
                public int? UserID { get; set; }
                public DateTime FromDate { get; set; }
                public DateTime ToDate { get; set; }
                public int? IsPlanned { get; set; }
                public int? IsRequiredImage { get; set; }
                public int? IsRegistered { get; set; }
                public DateTime? ExpirationDate { get; set; }
                public decimal? GiftQuantity { get; set; }
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
                public string? TargetNote { get; set; }
                public string? Note { get; set; }
                public string? Link { get; set; }
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
                public List<AddDetails> Details { get; set; }
            }
            public class AddDetails
            {
                public string? OID { get; set; }
                public string? ReferenceID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public DateTime ODate { get; set; }
                public string? CmpnID { get; set; }
                public int? CustomerID { get; set; }
                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public decimal AllocatedQuantity { get; set; }
                public decimal RequestedQuantity { get; set; }
                public DateTime RegistrationTime { get; set; }
                public string? Note { get; set; }
                public string? Link { get; set; }
            }

            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
            }

            public class Confirm : GetByOID
            {
            }
            public class Del : GetByOID
            {
            }
            public class GetListCustomers
            {
                public int? CustomerRepresentativeID { get; set; }
                public int? SalesStaffID { get; set; }
                public string? Function { get; set; }
                public int? GiftID { get; set; }
                public string? ODate { get; set; }
                public string? OID { get; set; }
            }
        }
    }
}
