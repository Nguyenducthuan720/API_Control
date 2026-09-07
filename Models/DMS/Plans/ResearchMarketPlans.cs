namespace DMS.Models.Plans;

public static class ResearchMarketPlans
{
    public static class Request
    {
        public class GetByOID
        {
            public string? OID { get; set; }
        }
        public class AddOrEdit
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
            /// UserID
            /// </summary>
            /// <example></example>
            public int? UserID { get; set; }

            /// <summary>
            /// Reason
            /// </summary>
            /// <example></example>
            public string? Reason { get; set; }

            /// <summary>
            /// Content
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// OtherContent
            /// </summary>
            /// <example></example>
            public string? OtherContent { get; set; }

            /// <summary>
            /// Link
            /// </summary>
            /// <example></example>
            public string? Link { get; set; }

            /// <summary>
            /// PlanName
            /// </summary>
            /// <example></example>
            public string? PlanName { get; set; }

            /// <summary>
            /// PlanNameExtention1
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention1 { get; set; }

            /// <summary>
            /// PlanNameExtention2
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention2 { get; set; }

            /// <summary>
            /// PlanNameExtention3
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention3 { get; set; }

            /// <summary>
            /// PlanNameExtention4
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention4 { get; set; }

            /// <summary>
            /// PlanNameExtention5
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention5 { get; set; }

            /// <summary>
            /// PlanNameExtention6
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention6 { get; set; }

            /// <summary>
            /// PlanNameExtention7
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention7 { get; set; }

            /// <summary>
            /// PlanNameExtention8
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention8 { get; set; }

            /// <summary>
            /// PlanNameExtention9
            /// </summary>
            /// <example></example>
            public string? PlanNameExtention9 { get; set; }

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
            /// ProvinceID
            /// </summary>
            /// <example></example>
            public int? ProvinceID { get; set; }

            /// <summary>
            /// RegionID
            /// </summary>
            /// <example></example>
            public int? RegionID { get; set; }

            /// <summary>
            /// MoreDetails
            /// </summary>
            /// <example></example>
            public string? MoreDetails { get; set; }

            /// <summary>
            /// InvolvedStaff
            /// </summary>
            /// <example></example>
            public string? InvolvedStaff { get; set; }
            public DateTime FromDate { get; set; }
           
            public DateTime ToDate { get; set; }

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
    }
}