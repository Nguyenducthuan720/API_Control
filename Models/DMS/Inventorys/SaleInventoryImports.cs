
using static DMS.Models.DMS.SaleInventorys.SaleInventoryHolds.Request;

namespace DMS.Models.DMS.SaleInventorys
{
    public static class SaleInventoryImports
    {
        public static class Request
        {

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
                /// SAPID
                /// </summary>
                public string? SAPID { get; set; }

                /// <summary>
                /// LemonID
                /// </summary>
                public string? LemonID { get; set; }
                /// <summary>
                /// ID khách hàng
                /// </summary>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Mã yêu cầu nghiệp vụ
                /// </summary>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Nhà máy 
                /// </summary>
                public int? FactoryID { get; set; }

                /// <summary>
                /// Kho chính
                /// </summary>
                public int? WarehouseID { get; set; }

                /// <summary>
                /// Nội dung nghiệp vụ
                /// </summary>
                public string? Content { get; set; }
                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Link { get; set; }
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

                /// <summary>
                /// Danh sách sản phẩm 
                /// </summary>
                public List<Detail> Details {  get; set; }
            }

            public class Detail : GetByOID
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? ItemID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? UnitID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? Quantity { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }
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
        }
    }
}