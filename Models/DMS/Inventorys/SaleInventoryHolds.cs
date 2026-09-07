namespace DMS.Models.DMS.SaleInventorys;

public class SaleInventoryHolds
{
    public static class Request
    {
        public class Add : GetByOID
        {
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }
        
        public class AddHold : Add
        {
            /// <summary>
            /// Nghiệp vụ
            /// </summary>
            /// <example>Invenrotys</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// Chức năng
            /// </summary>
            /// <example>HoldSales</example>
            public string? EntryID { get; set; }
            
            /// <summary>
            /// Ngày CT
            /// </summary>
            /// <example>2025-03-25</example>
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
            /// Nhân viên đề xuất
            /// </summary>
            /// <example>0</example>
            public int? RequestUserID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            /// <example>0</example>
            public int? CustomerID { get; set; }
            
            /// <summary>
            /// Lý do yêu cầu
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }
            
            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention1 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention2 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention3 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention4 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention5 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention6 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention7 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention8 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention9 { get; set; }
            
            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention10 { get; set; }
            
            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention11 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention12 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention13 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention14 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention15 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention16 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention17 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention18 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention19 { get; set; }
            
            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention20 { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            /// <example>Link</example>
            public string? Link { get; set; }
            
            public List<AddHoldItem> Items { get; set; }
        }
        
        public class AddHoldItem : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// Sản phẩm
            /// </summary>
            public int? ItemID { get; set; }
            
            /// <summary>
            /// Nhà máy
            /// </summary>
            public int? FactoryID { get; set; }
            
            /// <summary>
            /// Kho
            /// </summary>
            public int? WarehouseID { get; set; }
            
            /// <summary>
            /// Số lượng
            /// </summary>
            public decimal Quantity { get; set; }
        }
        
        public class GetByOID
        {
            /// <summary>
            /// Mã CT
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }
        }

        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }
        
        public class Del : GetByOID
        {
            
        }
        
        public class Extend : GetByOID
        {
            /// <summary>
            /// Nội dung
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }
        }
        
        public class Cancel : GetByOID
        {
            /// <summary>
            /// Lý do hủy
            /// </summary>
            /// <example></example>
            public int? CancelReasonID { get; set; }

            /// <summary>
            /// Nội dung
            /// </summary>
            /// <example></example>
            public string? CancelReason { get; set; }
        }
    }
}