namespace DMS.Models.DMS.Plans
{
    public class PromotionGiftPlans
    {
        public static class Request
        {
            public class GetByOID
            {
                public string? OID { get; set; }
            }
            public class Add
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// ODate
                /// </summary>
                /// <example>2021-09-11</example>
                public DateTime ODate { get; set; }

                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }

                public DateTime FromDate { get; set; }
                public DateTime ToDate { get; set; }

                /// <summary>
                /// SAPID
                /// </summary>
                /// <example></example>
                public string? SAPID { get; set; }

                /// <summary>
                /// LemonID
                /// </summary>
                /// <example></example>
                public string? LemonID { get; set; }

                /// <summary>
                /// CmpnID
                /// </summary>
                /// <example></example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example></example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// UserID
                /// </summary>
                /// <example></example>
                public int? UserID { get; set; }

                /// <summary>
                /// ProposalReason
                /// </summary>
                /// <example></example>
                public string? ProposalReason { get; set; }

                /// <summary>
                /// OtherContent
                /// </summary>
                /// <example></example>
                public string? OtherContent { get; set; }

                /// <summary>
                /// ProposalContent
                /// </summary>
                /// <example></example>
                public string? ProposalContent { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? Name { get; set; }

                /// <summary>
                /// NameExtention1
                /// </summary>
                /// <example></example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// NameExtention2
                /// </summary>
                /// <example></example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// PlanNameExtention3
                /// </summary>
                /// <example></example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// NameExtention4
                /// </summary>
                /// <example></example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// PlanNameExtention5
                /// </summary>
                /// <example></example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// NameExtention6
                /// </summary>
                /// <example></example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// NameExtention7
                /// </summary>
                /// <example></example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// NameExtention8
                /// </summary>
                /// <example></example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// NameExtention9
                /// </summary>
                /// <example></example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Extention10
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Extention11
                /// </summary>
                /// <example></example>
                public string? Extention11 { get; set; }

                /// <summary>
                /// Extention12
                /// </summary>
                /// <example></example>
                public string? Extention12 { get; set; }

                /// <summary>
                /// Extention13
                /// </summary>
                /// <example></example>
                public string? Extention13 { get; set; }

                /// <summary>
                /// Extention14
                /// </summary>
                /// <example></example>
                public string? Extention14 { get; set; }

                /// <summary>
                /// Extention15
                /// </summary>
                /// <example></example>
                public string? Extention15 { get; set; }

                /// <summary>
                /// Extention16
                /// </summary>
                /// <example></example>
                public string? Extention16 { get; set; }

                /// <summary>
                /// Extention17
                /// </summary>
                /// <example></example>
                public string? Extention17 { get; set; }

                /// <summary>
                /// Extention18
                /// </summary>
                /// <example></example>
                public string? Extention18 { get; set; }

                /// <summary>
                /// Extention19
                /// </summary>
                /// <example></example>
                public string? Extention19 { get; set; }

                /// <summary>
                /// Extention20
                /// </summary>
                /// <example></example>
                public string? Extention20 { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example></example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Details
                /// </summary>
                /// <example></example>
                public List<AddDetails> Details { get; set; }
            }
            public class AddDetails : GetByOID
            {
                public int? ID { get; set; }
                /// <summary>
                /// CmpnID
                /// </summary>
                /// <example></example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// GiftID
                /// </summary>
                /// <example></example>
                public int? GiftID { get; set; }

                /// <summary>
                /// ProposedReason
                /// </summary>
                /// <example></example>
                public string? ProposedReason { get; set; }

                /// <summary>
                /// ProposedQuantity
                /// </summary>
                /// <example></example>
                public decimal ProposedQuantity { get; set; }

                /// <summary>
                /// ProposedValue
                /// </summary>
                /// <example></example>
                public decimal ProposedValue { get; set; }

                /// <summary>
                /// InvolvedStaff
                /// </summary>
                /// <example></example>
                public string? Description { get; set; }
                public string? FromDate { get; set; }

                public string? ToDate { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Extention10
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Extention11
                /// </summary>
                /// <example></example>
                public string? Extention11 { get; set; }

                /// <summary>
                /// Extention12
                /// </summary>
                /// <example></example>
                public string? Extention12 { get; set; }

                /// <summary>
                /// Extention13
                /// </summary>
                /// <example></example>
                public string? Extention13 { get; set; }

                /// <summary>
                /// Extention14
                /// </summary>
                /// <example></example>
                public string? Extention14 { get; set; }

                /// <summary>
                /// Extention15
                /// </summary>
                /// <example></example>
                public string? Extention15 { get; set; }

                /// <summary>
                /// Extention16
                /// </summary>
                /// <example></example>
                public string? Extention16 { get; set; }

                /// <summary>
                /// Extention17
                /// </summary>
                /// <example></example>
                public string? Extention17 { get; set; }

                /// <summary>
                /// Extention18
                /// </summary>
                /// <example></example>
                public string? Extention18 { get; set; }

                /// <summary>
                /// Extention19
                /// </summary>
                /// <example></example>
                public string? Extention19 { get; set; }

                /// <summary>
                /// Extention20
                /// </summary>
                /// <example></example>
                public string? Extention20 { get; set; }
            }

            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
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
