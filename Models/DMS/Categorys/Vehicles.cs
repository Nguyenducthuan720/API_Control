using APISmartCity.Models.Categorys;

namespace APISmartCity.Models.Ver2.Categorys
{
    public static class Vehicles
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1021</example>
                public int? ID { get; set; }
            }

            public class GetParentID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1021</example>
                public int? ParentID { get; set; }
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }
            public class Content
            {
                public string? Code { get; set; }
                public string? LemonID { get; set; }
                public string? EntryID { get; set; }
                public string? CategoryType { get; set; }
                public string? LicensePlates { get; set; }
                public int? VehicleTypeID { get; set; }
                public int? VehicleModelID { get; set; }
                public string? ProductionYear { get; set; }
                public string? ChassisNumber { get; set; }
                public string? EngineNumber { get; set; }
                public string? CylinderCapacity { get; set; }
                public string? Power { get; set; }
                public string? EngineType { get; set; }
                public string? VehicleSize { get; set; }
                public int? VehicleColorID { get; set; }
                public string? ExpiryDate { get; set; }
                public string? KerbMass { get; set; }
                public string? DesignTotalMass { get; set; }
                public string? TowedMass { get; set; }
                public int? FuelKindID { get; set; }
                public string? MaxOutputRpm { get; set; }
                public string? Displacement { get; set; }
                public decimal OilCapacity { get; set; }
                public decimal BeginKm { get; set; }
                public int? VehicleTyreID { get; set; }
                public int? TyresNumber { get; set; }
                public int? DriveHelperID { get; set; }
                public string? VehicleDevices { get; set; }
                public string? Batteries { get; set; }
                public int? BatteryNumber { get; set; }
                public int? SMRMTypeID { get; set; }
                public int? VehicleGroup { get; set; }
                public DateTime InspectionDate { get; set; }
                public DateTime BankDate { get; set; }
                public DateTime BadgeDate { get; set; }
                public int? Tolerance { get; set; }
                public int? IsTractor { get; set; }
                public int? HasCrane { get; set; }
                public int? IsHandover { get; set; }
                public int? IsApprove { get; set; }
                public int? IsDeleted { get; set; }
                public int? IsActive { get; set; }
                public string? Note { get; set; }
                public string? CreateUser { get; set; }
                public DateTime CreateDate { get; set; }
                public string? ChangeUser { get; set; }
                public DateTime ChangeDate { get; set; }
                public string? CmpnID { get; set; }

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

                public decimal MaintenanceKM { get; set; }
                public int? MaintenanceNext { get; set; }
                public int? VehicleProducerID { get; set; }

                /// <summary>
                /// Danh sách Tires
                /// </summary>
                public List<Tire> Tires { get; set; }
            }

            public class ContentDetails
            {
                /// <summary>
                /// ParentID
                /// </summary>
                /// <example>1</example>
                public int? ParentID { get; set; }
                /// <summary>
                /// UserID
                /// </summary>
                /// <example>1</example>
                public int? UserID { get; set; }

                /// <summary>
                /// EffectFromDate
                /// </summary>
                /// <example>1</example>
                public DateTime? EffectFromDate { get; set; }

                ///// <summary>
                ///// ExpiredFromDate
                ///// </summary>
                ///// <example>1</example>
                //public DateTime? ExpiredFromDate { get; set; }

                ///// <summary>
                ///// ApprovalToDate
                ///// </summary>
                ///// <example>1</example>
                //public DateTime? ApprovalToDate { get; set; }

                /// <summary>
                /// Reason
                /// </summary>
                /// <example>1</example>
                public string? Reason { get; set; }
            }
            public class Tire
            {
                public string? SerialNumber { get; set; }
                public int? TirePositionID { get; set; }
                public int? TireProducerID { get; set; }
            }
            public class Add : Content
            {
            }

            public class AddDetails : ContentDetails

            {
            }
            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }
            }

            public class Update : GetParentID
            {
            }
        }
    }
}