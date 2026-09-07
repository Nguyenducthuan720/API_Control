namespace APISmartCity.Models.Ver2.ShippingNotSOs;

public static class ShippingNotSOs
{
    public static class Request
    {
        public class Add
        {
            //public string? CmpnID { get; set; }
            public string? FactorID { get; set; }
            public string? EntryID { get; set; }
            public DateTime Odate { get; set; }
            public string? OID { get; set; }
            public string? SAPID { get; set; }
            public string? LemonID { get; set; }
            public int? DriverID { get; set; }
            public string? LicensePlate { get; set; }
            public int? ReasonID { get; set; }

            public decimal NowLat { get; set; }
            public decimal NowLong { get; set; }

            public string? FromAddress { get; set; }
            public string? FromTime { get; set; }
            public decimal FromLat { get; set; }
            public decimal FromLong { get; set; }
            public string? FromGPS { get; set; }
            public string? FromAcLink { get; set; }
            public string? FromAcTime { get; set; }
            public string? FromAcGPS { get; set; }
            public decimal FromKm { get; set; }
            public string? FromNote { get; set; }

            public string? ToAddress { get; set; }
            public string? ToTime { get; set; }
            public decimal ToLat { get; set; }
            public decimal ToLong { get; set; }
            public string? ToGPS { get; set; }
            public decimal ToKm { get; set; }
            public string? ToAcLink { get; set; }
            public string? ToAcTime { get; set; }
            public string? ToNote { get; set; }

            public string? Content {  get; set; }
            public int? UserID { get; set; }
            public string? ListUserID { get; set; }
            public int? VehicleTypeID {  get; set; }

            public string? EstimatedDeparture { get; set; }
            public string? EstimatedDestination { get; set; }

            public string? EstimatedStartGPS { get; set; }
            public string? EstimatedEndGPS { get; set; }

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

            public string? Note { get; set; }
            public string? Link { get; set; }

        }

        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
            public string? Link { get; set; }
            public string? Note { get; set; }
        }
        public class Running : GetByOID
        {
            public string? FromAcLink { get; set; }
            public string? FromNote { get; set; }
            public string? FromAcGPS { get; set; }
        }

        public class Finished : GetByOID
        {
            public string? ToAcLink { get; set; }
            public string? ToNote { get; set; }
            public string? ToAcGPS { get; set; }
        }
        public class Get
        {
            public string? EntryID { get; set; }
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