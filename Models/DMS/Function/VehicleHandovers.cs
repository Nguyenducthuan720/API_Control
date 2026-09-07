namespace APISmartCity.Models.Ver2.VehicleHandovers;

public static class VehicleHandovers
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }

        public class AddVehicleHandovers : Add
        {

            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Handover</example>
            //public string? CmpnID { get; set; }


            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Handover</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>VehicleHandover</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }
            
            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2024-11-19</example>
            public string? ODate { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>VehicleHandover</example>
            public string? ReferenceType { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? ReferenceID { get; set; }

            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2024-11-19</example>
            public string? ReferenceDate { get; set; }

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
            /// VehicleTypeID
            /// </summary>
            /// <example></example>
            public int? VehicleTypeID { get; set; }

            /// <summary>
            /// VehicleID
            /// </summary>
            /// <example></example>
            public int? VehicleID { get; set; }

            /// <summary>
            /// VehicleModelID
            /// </summary>
            /// <example></example>
            public int? VehicleModelID { get; set; }

            /// <summary>
            /// DriversID
            /// </summary>
            /// <example></example>
            public int? DriversID { get; set; }

            /// <summary>
            /// Phone
            /// </summary>
            /// <example></example>
            public string? Phone { get; set; }

            /// <summary>
            /// CCCD
            /// </summary>
            /// <example></example>
            public string? CCCD { get; set; }

            /// <summary>
            /// DriversLicense
            /// </summary>
            /// <example></example>
            public string? DriversLicense { get; set; }

            /// <summary>
            /// DriversLicenseValidity
            /// </summary>
            /// <example></example>
            public string? DriversLicenseValidity { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            /// <example></example>
            public string? Address { get; set; }

            /// <summary>
            /// AddressExtention1
            /// </summary>
            /// <example></example>
            public string? AddressExtention1 { get; set; }

            /// <summary>
            /// AddressExtention2
            /// </summary>
            /// <example></example>
            public string? AddressExtention2 { get; set; }

            /// <summary>
            /// AddressExtention3
            /// </summary>
            /// <example></example>
            public string? AddressExtention3 { get; set; }

            /// <summary>
            /// AddressExtention4
            /// </summary>
            /// <example></example>
            public string? AddressExtention4 { get; set; }

            /// <summary>
            /// AddressExtention5
            /// </summary>
            /// <example></example>
            public string? AddressExtention5 { get; set; }

            /// <summary>
            /// AddressExtention6
            /// </summary>
            /// <example></example>
            public string? AddressExtention6 { get; set; }

            /// <summary>
            /// AddressExtention7
            /// </summary>
            /// <example></example>
            public string? AddressExtention7 { get; set; }

            /// <summary>
            /// AddressExtention8
            /// </summary>
            /// <example></example>
            public string? AddressExtention8 { get; set; }

            /// <summary>
            /// AddressExtention9
            /// </summary>
            /// <example></example>
            public string? AddressExtention9 { get; set; }

            /// <summary>
            /// Image
            /// </summary>
            /// <example></example>
            public string? Image { get; set; }

            /// <summary>
            /// HandoverDate
            /// </summary>
            /// <example></example>
            public string? HandoverDate { get; set; }

            /// <summary>
            /// KmHandover
            /// </summary>
            /// <example></example>
            public string? KmHandover { get; set; }

            /// <summary>
            /// OilStatus
            /// </summary>
            /// <example></example>
            public int? OilStatusID { get; set; }

            /// <summary>
            /// OilVolume
            /// </summary>
            /// <example></example>
            public int? OilVolume { get; set; }

            /// <summary>
            /// HandoverStatus
            /// </summary>
            /// <example></example>
            public string? HandoverStatus { get; set; }

            /// <summary>
            /// HandoverNote
            /// </summary>
            /// <example></example>
            public string? HandoverNote { get; set; }

            /// <summary>
            /// ApprovalProcessID
            /// </summary>
            /// <example></example>
            public int? ApprovalProcessID { get; set; }

            /// <summary>
            /// ApprovalStep
            /// </summary>
            /// <example></example>
            public int? ApprovalStep { get; set; }

            /// <summary>
            /// ApprovalStatusID
            /// </summary>
            /// <example></example>
            public int? ApprovalStatusID { get; set; }

            /// <summary>
            /// ApprovalDate
            /// </summary>
            /// <example></example>
            public string? ApprovalDate { get; set; }

            /// <summary>
            /// ApprovalNote
            /// </summary>
            /// <example></example>
            public string? ApprovalNote { get; set; }

            /// <summary>
            /// AppliedToID
            /// </summary>
            /// <example></example>
            public string? AppliedToID { get; set; }

            /// <summary>
            /// IsLock
            /// </summary>
            /// <example></example>
            public int? IsLock { get; set; }

            /// <summary>
            /// Step
            /// </summary>
            /// <example></example>
            public int? Step { get; set; }

            /// <summary>
            /// RejectionStep
            /// </summary>
            /// <example></example>
            public int? RejectionStep { get; set; }

            /// <summary>
            /// IsCompleted
            /// </summary>
            /// <example></example>
            public int? IsCompleted { get; set; }
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

            /// <summary>
            /// IsActive
            /// </summary>
            /// <example></example>
            public int? IsActive { get; set; }

            /// <summary>
            /// IsDeleted
            /// </summary>
            /// <example></example>
            public int? IsDeleted { get; set; }

            /// <summary>
            /// LockDate
            /// </summary>
            /// <example></example>
            public string? LockDate { get; set; }

            /// <summary>
            /// EmployerCompleteID
            /// </summary>
            /// <example>EmployerCompleteID</example>
            public string? EmployerCompleteID { get; set; }

            /// <summary>
            /// EmployerCompleteDatetime
            /// </summary>
            /// <example>EmployerCompleteDatetime</example>
            public string? EmployerCompleteDatetime { get; set; }

            /// <summary>
            /// Documents
            /// </summary>
            public List<AddDocument> Documents { get; set; }

            /// <summary>
            /// Documents
            /// </summary>
            public List<AddDocument> ReferenceDocuments { get; set; }

            /// <summary>
            /// Tools
            /// </summary>
            public List<AddTool> Tools { get; set; }

            /// <summary>
            /// Tools
            /// </summary>
            public List<AddTool> ReferenceTools { get; set; }

            /// <summary>
            /// Tires
            /// </summary>
            public List<AddTire> Tires { get; set; }

            /// <summary>
            /// Tires
            /// </summary>
            public List<AddTire> ReferenceTires { get; set; }
        }

        public class AddDocument : Add
        {
            /// <summary>
            /// IDDoc
            /// </summary>
            /// <example></example>
            public int? IDDoc { get; set; }
            
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? HandoverType { get; set; }

            /// <summary>
            /// IsDocRoot
            /// </summary>
            /// <example></example>
            public int? IsDocRoot { get; set; }

            /// <summary>
            /// IsDocPhoto
            /// </summary>
            /// <example></example>
            public int? IsDocPhoto { get; set; }

            /// <summary>
            /// IsDocReturn
            /// </summary>
            /// <example></example>
            public int? IsDocReturn { get; set; }


        }
        
        public class AddTool : Add
        {
            /// <summary>
            /// IdTool
            /// </summary>
            /// <example></example>
            public int? IdTool { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? HandoverType { get; set; }

            /// <summary>
            /// IsToolReturn
            /// </summary>
            /// <example></example>
            public int? IsToolReturn { get; set; }

        }
        
        public class AddTire : Add
        {
            /// <summary>
            /// TiresSerial
            /// </summary>
            /// <example></example>
            public int? TiresSerial { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? HandoverType { get; set; }

            /// <summary>
            /// IDSuppliers
            /// </summary>
            /// <example></example>
            public string? IDSuppliers { get; set; }

            /// <summary>
            /// IDTireplacement
            /// </summary>
            /// <example></example>
            public string? IDTireplacement { get; set; }

            /// <summary>
            /// IsTiresReturn
            /// </summary>
            /// <example></example>
            public int? IsTiresReturn { get; set; }
        }
        
        
        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
            public string? EntryID { get; set; }
        }

        public class GetListVehicle
        {
            public int? IsHandOver { get; set; }

        }
        public class Confirm 
        {
            public string? OID { get; set; }
            public int? ConfirmDecision { get; set; }
            public string? ConfirmContent { get; set; }
            public string? ConfirmLink { get; set; }
            
        }

        public class Vehicle
        {
            public string? VehicleID { get; set; }
            public string? EntryID { get; set; }
        }
        public class Del : GetByOID
        {
        }
    }
}