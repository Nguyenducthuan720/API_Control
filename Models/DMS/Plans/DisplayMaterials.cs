using System;

namespace APISmartCity.Models.Ver2.DisplayMaterials;

public static class DisplayMaterials
{
    public static class Request
    {
        public class Add
        {
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public DateTime Odate { get; set; }
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }
            public string? ReferenceID { get; set; }
            public int? InProgram { get; set; }
            public int? OutProgram { get; set; }
            public int? EventTypeID { get; set; }
            public int? RequestUserID { get; set; }
            public DateTime RequestDate { get; set; }
            public string? Content { get; set; }
            public decimal GiftAmount { get; set; }
            public decimal ConsignmentAmount { get; set; }
            public decimal TotalAmount { get; set; }
            public string? Link { get; set; }
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
            public List<DisplayMaterialsDetails> DisplayMaterialsJson { get; set; }

        }
        public class DisplayMaterialsDetails
        {
            public string? OID { get; set; }
            public int? CustomerID { get; set; }
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public string? ReferenceID { get; set; }
            public int? IsConsigned { get; set; }
            public DateTime Odate { get; set; }
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
            public List<ItemDetails> ItemDetails { get; set; }


        }

        public class ItemDetails
        {
            public int? ID { get; set; }
            public int? ItemID { get; set; }
            public string? OID { get; set; }
            public decimal ItemQty { get; set; }
            public decimal ItemQtyGift { get; set; }
            public decimal ItemQtyConsigned { get; set; }
            public int? ItemUnit { get; set; }
            public decimal ItemPrice { get; set; }
            public decimal ItemTotalPrice { get; set; }
            public string? Note { get; set; }
            public string? Link { get; set; }
            public int? IsGiftCompleted { get; set; }
            public int? IsConsigned { get; set; }
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
        }

        public class Edit : Add
        {
            public string? OID { get; set; }
        }
        public class GetMobile
        {
            public string? EntryID { get; set; }
        }

        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }
        public class ItemInProcess
        {
            public string? ReferenceID { get; set; }
            public int? EventTypeID { get; set; }
        }

        public class Del : GetByOID
        {

        }

        public class AddRequest
        {
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public string? OID { get; set; }
            public DateTime ODate { get; set; }
            public string? ReferenceID { get; set; }
            public int? RequestUserID { get; set; }
            public DateTime RequestDate { get; set; }
            public int? ReasonTypeID { get; set; }
            public string? Content { get; set; }
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
            public List<DisplayMaterialsDetails> DisplayMaterialsJson { get; set; }
        }

        public class EditRequest : AddRequest
        {

        }

    }
}