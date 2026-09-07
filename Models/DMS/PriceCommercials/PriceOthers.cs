namespace DMS.Models.DMS.PriceCommercials
{
    public class PriceOthers
    {
        public class Request
        {

            public class GetByID
            {
                /// <summary>
                /// Mã CT
                /// </summary>C
                /// <example>0</example>
                public string? OID { get; set; }
            }

            public class AddOrEdit
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>PriceCommercials</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>PriceShippings</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã CT
                /// </summary>
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
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-05-19</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Tên bảng giá (VI)
                /// </summary>
                public string? PriceName { get; set; }

                /// <summary>
                /// Tên bảng giá (EN)
                /// </summary>
                public string? PriceNameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? PriceNameExtention9 { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-05-19</example>
                public DateTime FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-05-19</example>
                public DateTime ToDate { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Điều kiện tính giá
                /// </summary>
                public int? ConditionKeyID { get; set; }

                /// <summary>
                /// Tổ chức bán hàng
                /// </summary>
                public string? SalesOrgID { get; set; }

                /// <summary>
                /// Kênh bán hàng
                /// </summary>
                public string? SalesChannelID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public string? GoodsTypeID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                public string? PriceGroupID { get; set; }

                /// <summary>
                /// Batch
                /// </summary>
                public string? Batch { get; set; }

                /// <summary>
                /// Tuyến NVKD
                /// </summary>
                public string? SalesStaffID { get; set; }

                /// <summary>
                /// Nhóm ngành hàng cấp 1
                /// </summary>
                public string? ProductTypeID { get; set; }

                /// <summary>
                /// Nhóm ngành hàng cấp 2
                /// </summary>
                public string? ItemGroupID { get; set; }

                /// <summary>
                /// Độ dày ván
                /// </summary>
                public string? ThicknessID { get; set; }

                /// <summary>
                /// Đơn vị vận chuyển
                /// </summary>
                public string? ShippingUnitID { get; set; }

                /// <summary>
                /// Điều khoản thương mại
                /// </summary>
                public string? IncotermID { get; set; }

                /// <summary>
                /// Đơn hàng nội địa
                /// </summary>
                public string? OrderID { get; set; }

                /// <summary>
                /// Nhóm danh mục mặt hàng
                /// </summary>
                public string? CategoryGroupID { get; set; }

                /// <summary>
                /// Thương hiệu (Đặc tính sản phẩm)
                /// </summary>
                public string? Brand1ID { get; set; }

                /// <summary>
                /// Nhà máy
                /// </summary>
                public string? FactoryID { get; set; }

                /// <summary>
                /// Điều khoản thanh toán
                /// </summary>
                public string? PaymentTermID { get; set; }

                /// <summary>
                /// Tỉnh/TP
                /// </summary>
                public string? RegionID { get; set; }

                /// <summary>
                /// Xác nhận đặt hàng
                /// </summary>
                public string? ContractID { get; set; }

                /// <summary>
                /// Loại chứng từ
                /// </summary>
                public string? DocumentTypeID { get; set; }

                /// <summary>
                /// Đơn vị bán
                /// </summary>
                public string? SaleUnitID { get; set; }

                /// <summary>
                /// Điểm xuất hàng
                /// </summary>
                public string? ShippingPointID { get; set; }

                /// <summary>
                /// Thương hiệu (Thông tin sản xuất)
                /// </summary>
                public string? Brand2ID { get; set; }

                /// <summary>
                /// Đơn vị tính
                /// </summary>
                public string? Units { get; set; }

                /// <summary>
                /// Đơn vị tiền tệ
                /// </summary>
                public int? CurrencyTypeID { get; set; }

                /// <summary>
                /// Tỷ giá
                /// </summary>
                public decimal CurrencyRate { get; set; }

                /// <summary>
                /// Ngày tỷ giá
                /// </summary>
                public string? CurrencyDate { get; set; }

                /// <summary>
                /// Tiêu chí tính giá
                /// </summary>
                public int? ConditionTypeID { get; set; }

                /// <summary>
                /// Chi tiết áp dụng
                /// </summary>
                public string? ObjectTypes { get; set; }

                /// <summary>
                /// Điều kiện áp dụng
                /// </summary>
                public string? ConditionsApply { get; set; }

                /// <summary>
                /// Doanh số đạt miễn phí vận chuyển
                /// </summary>
                public decimal RevenueAchievedFreeShipping { get; set; }

                /// <summary>
                /// Sản lượng đạt miễn phí vận chuyển
                /// </summary>
                public decimal OutputAchievedFreeShipping { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }

                /// <summary>
                /// Tệp đính kèm
                /// </summary>
                public string? Link { get; set; }

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
                /// Chi tiết bảng giá
                /// </summary>
                public List<OtherDetail> Details { get; set; }
            }

            public class OtherDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Loại đối tượng
                /// </summary>
                public string? ObjectType { get; set; }

                /// <summary>
                /// Đối tượng
                /// </summary>
                public int? ObjectID { get; set; }

                /// <summary>
                /// Kho xuất
                /// </summary>
                public int? WarehouseID { get; set; }

                /// <summary>
                /// Địa chỉ giao
                /// </summary>
                public int? RepresentativeAddressID { get; set; }

                /// <summary>
                /// SL từ
                /// </summary>
                public int? From { get; set; }

                /// <summary>
                /// SL đến
                /// </summary>
                public int? To { get; set; }

                /// <summary>
                /// Chi tiết giá
                /// </summary>
                public List<RouteDetail> Prices { get; set; }

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
            }

            public class RouteDetail
            {
                /// <summary>
                /// Bước duyệt
                /// </summary>
                public int? Step { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Chi tiết giá
                /// </summary>
                public List<RoutePrice> Details { get; set; }
            }

            public class RoutePrice
            {
                /// <summary>
                /// Đơn vị tính
                /// </summary>
                public int? UnitID { get; set; }

                /// <summary>
                /// Giá bán NCC
                /// </summary>
                public decimal ProviderPrice { get; set; }

                /// <summary>
                /// Đơn giá
                /// </summary>
                public decimal ProposePrice { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }
        }
    }
}