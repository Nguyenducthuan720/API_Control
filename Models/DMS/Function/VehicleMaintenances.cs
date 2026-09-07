namespace APISmartCity.Models.Ver2.VehicleMaintenances;

public static class VehicleMaintenances
{
    public static class Request
    {
        public class Add
        {
            //public string? CmpnID { get; set; }
            public string? OID { get; set; }
            public string? FactorID { get; set; }
            public DateTime Odate { get; set; }

            public string? EntryID { get; set; }
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }
            public int? ExtendUnitID { get; set; }
            public int? DriverID { get; set; }
            public string? LicensePlate { get; set; }
            public string? FromDate { get; set; }
            public string? ToDate { get; set; }
            public decimal Amount { get; set; }
            public decimal MaintenanceKM { get; set; }
            public int? MaintenanceNext { get; set; }
            public string? Content { get; set; }
            public string? Note { get; set; }
            public string? Link { get; set; }
            public int? IsLock { get; set; }
        }

        public class Get
        {
            public string? FactorID { get; set; }
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