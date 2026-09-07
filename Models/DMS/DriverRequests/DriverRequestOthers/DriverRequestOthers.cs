namespace DMS.Models.DMS.DriverRequests.DriverRequestOthers;

public static class DriverRequestOthers
{
    public static class Request
    {
        public class Add
        {
            //public string? CmpnID { get; set; }

            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>OrderRequests</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>OrderRequests</example>
            public string? EntryID { get; set; }
            public DateTime Odate { get; set; }

            public string? OID { get; set; }

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
            /// DriverID
            /// </summary>
            /// <example></example>
            public int? DriverID { get; set; }

            /// <summary>
            /// LicensePlate
            /// </summary>
            /// <example></example>
            public string? LicensePlate { get; set; }

            /// <summary>
            /// LinkImg
            /// </summary>
            /// <example></example>
            public string? LinkImg { get; set; }
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
            /// CurrentKM
            /// </summary>
            /// <example></example>
            public decimal CurrentKM { get; set; }
            /// <summary>
            /// Lat
            /// </summary>
            /// <example></example>
            public decimal Lat { get; set; }
            /// <summary>
            /// Long
            /// </summary>
            /// <example></example>
            public decimal Long { get; set; }

            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
            public string? Content { get; set; }

            /// <summary>
            /// Active
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
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

        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }

        public class Del : GetByOID
        {
        }
    }
}