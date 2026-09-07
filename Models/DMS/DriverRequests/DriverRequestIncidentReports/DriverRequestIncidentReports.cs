namespace DMS.Models.DMS.DriverRequests.DriverRequestIncidentReports;

public static class DriverRequestIncidentReports
{
    public class Request
    {
        public class AddIncident
        {
            //public string? CmpnID { get; set; }
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public DateTime Odate { get; set; }
            public int? IncidentTypeID { get; set; }
            public int? DriverID { get; set; }
            public string? Licenseplate { get; set; }
            public decimal CurrentKM { get; set; }
            public int? IsActive { get; set; }
            public decimal Lat { get; set; }
            public decimal Long { get; set; }
            public string? Note { get; set; }
            public string? Content {  get; set; }
            public string? Link { get; set; }
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }
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
        public class Edit : AddIncident
        {
            public string? OID { get; set; }

        }
        public class GetMobile
        {
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
        }
        public class GetByOID
        {
            public string? OID { get; set; }

        }
        public class Process : GetByOID
        {
            public string? OID { get; set; }
            public int? ApprovalProcessID { get; set; }
            public int? ApprovalStep { get; set; }
            public int? ApprovalStatusID { get; set; }
            public string? EntryID { get; set; } = null!;
            public string? FactorID { get; set; } = null!;
        }
        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }
        public class UpdateStauts : GetByOID
        {

           public string? FinalKm {  get; set; } 
           public string? FinalAmount { get; set; }
           public string? FinalNote { get; set; }
           public string? FinalContent { get; set; }
           public string? FinalLink { get; set; }

        }



    }
}