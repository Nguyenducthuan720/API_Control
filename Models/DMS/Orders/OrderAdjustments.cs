namespace DMS.Models.DMS.Orders
{
    public class OrderAdjustments
    {
        public class Request
        {
            public class Add
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }

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
            }

            public class AddAdjustment : Add
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>OrderNormals</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>SONormals</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// ODate
                /// </summary>
                /// <example>2025-05-23</example>
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
                /// Khách hàng
                /// </summary>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Đề xuất của kinh doanh
                /// </summary>
                public string? ProposalID { get; set; }

                /// <summary>
                /// Số chứng từ
                /// </summary>
                public string? Reason { get; set; }

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
                /// Danh sách sản phẩm
                /// </summary>
                public List<AddItem> Items { get; set; }
            }

            public class AddItem : Add
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Phân loại
                /// </summary>
                public string? Type { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? ItemID { get; set; }

                /// <summary>
                /// Mức thuế
                /// </summary>
                public int? VAT { get; set; }

                /// <summary>
                /// Số lượng đặt
                /// </summary>
                public int? OrderedQuantity { get; set; }

                /// <summary>
                /// Số lượng còn lại
                /// </summary>
                public int? RemainingQuantity { get; set; }

                /// <summary>
                /// Số lượng điều chỉnh
                /// </summary>
                public int? AdjustQuantity { get; set; }

                /// <summary>
                /// Đơn giá (+VAT)
                /// </summary>
                public decimal Price { get; set; }

                /// <summary>
                /// Tiền hàng
                /// </summary>
                public decimal ItemAmount { get; set; }

                /// <summary>
                /// Tiền VAT
                /// </summary>
                public decimal VATAmount { get; set; }

                /// <summary>
                /// Thành tiền
                /// </summary>
                public decimal TotalAmount { get; set; }

                /// <summary>
                /// Yêu cầu khác
                /// </summary>
                public string? OtherRequirements { get; set; }

                /// <summary>
                /// Nhà máy sản xuất
                /// </summary>
                public int? FactoryID { get; set; }

                /// <summary>
                /// Kho xuất
                /// </summary>
                public int? WarehouseID { get; set; }

                /// <summary>
                /// Điểm xuất hàng
                /// </summary>
                public int? DeparturePointID { get; set; }

                /// <summary>
                /// Loại hàng (MTS - MTO - MTS/MTO)
                /// </summary>
                public string? GoodsType { get; set; }

                /// <summary>
                /// Bảo hành
                /// </summary>
                public int? WarrantyID { get; set; }

                /// <summary>
                /// Áp chiết khấu
                /// </summary>
                public int? ApplyDiscount { get; set; }

                /// <summary>
                /// Áp khuyến mãi
                /// </summary>
                public int? ApplyPromotion { get; set; }

                /// <summary>
                /// Áp trưng bày
                /// </summary>
                public int? ApplyExhibition { get; set; }

                /// <summary>
                /// Áp hỗ trợ vận chuyển
                /// </summary>
                public int? ApplyShipping { get; set; }

                /// <summary>
                /// Chi tiết giá
                /// </summary>
                /// <example></example>
                public string? Details { get; set; }
            }

            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
            }

            public class GetByOID
            {
                public string? OID { get; set; }
            }

            public class GetByCustomerID
            {
                public int? CustomerID { get; set; }
            }

            public class Del : GetByOID
            {
            }
        }
    }
}
