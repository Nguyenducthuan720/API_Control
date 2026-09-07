namespace APISmartCity.Models.Ver2.BrandingPromotionQuotas;

public static class BrandingPromotionQuotas
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }

            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }

            /// <summary>
            /// Link
            /// </summary>
            /// <example>Link</example>
            public string? Link { get; set; }

            /// <summary>
            /// Active
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
        }

        public class AddBrandingPromotionQuotas : Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>BrandPromotionBudgets</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>SetBudgets</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2025-01-08</example>
            public string? ODate { get; set; }

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
            /// Year
            /// </summary>
            /// <example></example>
            public string? Year { get; set; }


            /// <summary>
            /// FromDate
            /// </summary>
            /// <example></example>
            public string? FromDate { get; set; }

            /// <summary>
            /// ToDate
            /// </summary>
            /// <example></example>
            public string? ToDate { get; set; }

            /// <summary>
            /// Content
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// ContentExtention1
            /// </summary>
            /// <example></example>
            public string? ContentExtention1 { get; set; }

            /// <summary>
            /// ContentExtention2
            /// </summary>
            /// <example></example>
            public string? ContentExtention2 { get; set; }

            /// <summary>
            /// ContentExtention3
            /// </summary>
            /// <example></example>
            public string? ContentExtention3 { get; set; }

            /// <summary>
            /// ContentExtention4
            /// </summary>
            /// <example></example>
            public string? ContentExtention4 { get; set; }

            /// <summary>
            /// ContentExtention5
            /// </summary>
            /// <example></example>
            public string? ContentExtention5 { get; set; }

            /// <summary>
            /// ContentExtention6
            /// </summary>
            /// <example></example>
            public string? ContentExtention6 { get; set; }

            /// <summary>
            /// ContentExtention7
            /// </summary>
            /// <example></example>
            public string? ContentExtention7 { get; set; }

            /// <summary>
            /// ContentExtention8
            /// </summary>
            /// <example></example>
            public string? ContentExtention8 { get; set; }

            /// <summary>
            /// ContentExtention9
            /// </summary>
            /// <example></example>
            public string? ContentExtention9 { get; set; }

            /// <summary>
            /// Details
            /// </summary>
            public List<AddDetail> Details { get; set; }
        }

        public class AddDetail : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// MaterialOrGoodsID
            /// </summary>
            /// <example></example>
            public int? MaterialOrGoodsID { get; set; }

            /// <summary>
            /// Content
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// ContentExtention1
            /// </summary>
            /// <example></example>
            public string? ContentExtention1 { get; set; }

            /// <summary>
            /// ContentExtention2
            /// </summary>
            /// <example></example>
            public string? ContentExtention2 { get; set; }

            /// <summary>
            /// ContentExtention3
            /// </summary>
            /// <example></example>
            public string? ContentExtention3 { get; set; }

            /// <summary>
            /// ContentExtention4
            /// </summary>
            /// <example></example>
            public string? ContentExtention4 { get; set; }

            /// <summary>
            /// ContentExtention5
            /// </summary>
            /// <example></example>
            public string? ContentExtention5 { get; set; }

            /// <summary>
            /// ContentExtention6
            /// </summary>
            /// <example></example>
            public string? ContentExtention6 { get; set; }

            /// <summary>
            /// ContentExtention7
            /// </summary>
            /// <example></example>
            public string? ContentExtention7 { get; set; }

            /// <summary>
            /// ContentExtention8
            /// </summary>
            /// <example></example>
            public string? ContentExtention8 { get; set; }

            /// <summary>
            /// ContentExtention9
            /// </summary>
            /// <example></example>
            public string? ContentExtention9 { get; set; }

            /// <summary>
            /// PartnerData
            /// </summary>
            /// <example></example>
            public List<Partner> PartnerData { get; set; }
        }

        public class Partner
        {
            public int? PartnerID { get; set; }

            public decimal Quantity { get; set; }
        }


        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }

        public class GetByEntry
        {
            public string? EntryID { get; set; }
        }

        public class Del : GetByOID
        {
        }
    }
}