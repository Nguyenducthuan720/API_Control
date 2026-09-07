
namespace DMS.Models.DMS.SaleInventorys
{
    public static class DataBegins
    {
        public static class Request
        {
            public class Get
            {
                public string? EntryID { get; set; }
            }
            public class GetByOID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }
            public class AddOrEdit
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>Inventorys</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>TranferItems</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// ODate
                /// </summary>
                public string? ODate { get; set; }

                /// <summary>
                /// Code
                /// </summary>
                public string? Code { get; set; }

                /// <summary>
                /// SAPID
                /// </summary>
                public string? SAPID { get; set; }

                /// <summary>
                /// LemonID
                /// </summary>
                public string? LemonID { get; set; }

                /// <summary>
                /// RouteSales1
                /// </summary>
                public string? RouteSales1 { get; set; }

                /// <summary>
                /// RouteSales2
                /// </summary>
                public string? RouteSales2 { get; set; }

                /// <summary>
                /// RouteSales3
                /// </summary>
                public string? RouteSales3 { get; set; }

                /// <summary>
                /// RouteSales4
                /// </summary>
                public string? RouteSales4 { get; set; }

                /// <summary>
                /// Year
                /// </summary>
                public int? SaleYear { get; set; }

                /// <summary>
                /// Month
                /// </summary>
                public int? SaleMonth { get; set; }

                /// <summary>
                /// ProductTypeID
                /// </summary>
                public int? ProductTypeID { get; set; }

                /// <summary>
                /// ItemGroupID
                /// </summary>
                public int? ItemGroupID { get; set; }

                /// <summary>
                /// GoodsTypeID
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// ItemID
                /// </summary>
                public int? ItemID { get; set; }

                /// <summary>
                /// ProcessQty
                /// </summary>
                public int? ProcessQty { get; set; }
                /// <summary>
                /// DummyCode
                /// </summary>
                public string? DummyCode { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
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
                public List<Details> Details { get; set; }

            }
            public class Edit : AddOrEdit
            {
                public string? OID { get; set; }
            }
            public class Del : GetByOID
            {
            }
            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
            }
            public class Details
            {
                public string? BadgeToDate { get; set; }
                public string? BankToDate { get; set; }
                public string? RegisToDate { get; set; }
                public string? InsureToDate { get; set; }
                public string? MaintenanceToDate { get; set; }
                public int? GasLastKm { get; set; }
                public decimal GasLastQuantity { get; set; }
                public string? LicensePlates { get; set; }
                public int? MaintenanceCycle { get; set; }
                public int? MaintenanceLastKm { get; set; }
                public string? Note { get; set; }
            }
        }
    }
}