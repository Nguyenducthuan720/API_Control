using System;
using static APISmartCity.Models.Ver2.BudgetProposals.BudgetProposals.Request;

namespace APISmartCity.Models.Ver2.BudgetProposals;

public static class BudgetProposals
{
    public static class Request
    {
        public class Add
        {
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public string? CmpnID { get; set; }
            public DateTime Odate { get; set; }
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }
            public int? UserID { get; set; }
            public int? ProposalTypeID { get; set; }
            public int? CurrencyTypeID { get; set; }
            public decimal TotalAmount { get; set; }
            public string? Reason { get; set; }
            public string? Link { get; set; }
            public string? Note { get; set; }
            public string? NameExtention1 { get; set; }
            public string? NameExtention2 { get; set; }
            public string? NameExtention3 { get; set; }
            public string? NameExtention4 { get; set; }
            public string? NameExtention5 { get; set; }
            public string? NameExtention6 { get; set; }
            public string? NameExtention7 { get; set; }
            public string? NameExtention8 { get; set; }
            public string? NameExtention9 { get; set; }
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
            public List<BudgetProposalDetails> BudgetProposalJson { get; set; }

        }
        public class BudgetProposalDetails
        {
            public int? ID { get; set; }
            public string? ReferenceID { get; set; }
            public DateTime ODate { get; set; }
            public int? CostTypeID { get; set; }
            public decimal Amount { get; set; }
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

    }
}