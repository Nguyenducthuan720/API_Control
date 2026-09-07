namespace DMS.Models.DMS.PriceCommercials
{
    public class PricePolicys
    {
        public class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
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
                /// <example>GeneralPrice</example>
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
                /// <example>2025-09-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Bảng giá tham chiếu
                /// </summary>
                /// <example></example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Tên bảng giá (VI)
                /// </summary>
                public string? PriceName { get; set; }

                /// <summary>
                /// Tên bảng giá (EN)
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? PriceNameExtention9 { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-09-24</example>
                public DateTime FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-09-24</example>
                public DateTime ToDate { get; set; }

                /// <summary>
                /// Điều kiện tính giá
                /// </summary>
                public int? ConditionKeyID { get; set; }

                /// <summary>
                /// Tiêu chí
                /// </summary>
                /// <example></example>
                public string? ConditionTypes { get; set; }

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
                /// <example>12051,12066</example>
                public string? PriceGroups { get; set; }

                /// <summary>
                /// Nhóm giá theo quy tắc
                /// </summary>
                /// <example>12051,12066</example>
                public string? CalculatedPriceGroups { get; set; }

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
                /// <example></example>
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
                /// <example></example>
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
                /// <example>2025-09-24</example>
                public string? CurrencyDate { get; set; }

                /// <summary>
                /// Điều kiện áp dụng
                /// </summary>
                /// <example></example>
                public string? ConditionsApply { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Tệp đính kèm
                /// </summary>
                /// <example></example>
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
                public List<PricePolicyDetail> Details { get; set; }

                ///// <summary>
                ///// Chi tiết chiết khấu
                ///// </summary>
                //public List<PricePolicyDiscount> Discounts { get; set; }
            }

            public class PricePolicyDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Tiêu chí
                /// </summary>
                public int? ConditionTypeID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Model
                /// </summary>
                public int? ModelID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? ItemID { get; set; }

                /// <summary>
                /// SL từ
                /// </summary>
                public int? From { get; set; }

                /// <summary>
                /// SL đến
                /// </summary>
                public int? To { get; set; }

                /// <summary>
                /// VAT
                /// </summary>
                public int? VAT { get; set; }

                /// <summary>
                /// Giá hiện tại
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice { get; set; }

                /// <summary>
                /// Model
                /// </summary>
                public List<PriceStep> Prices { get; set; }
            }

            public class PriceStep
            {
                /// <summary>
                /// Bước duyệt
                /// </summary>
                /// <example>0</example>
                public int? Step { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Các mức giá
                /// </summary>
                public List<ItemPriceDetail> Details { get; set; }
            }

            public class ItemPriceDetail
            {
                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example>0</example>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Giá đề xuất
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice { get; set; }
            }

            public class PricePolicyDiscount
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Model
                /// </summary>
                public int? ModelID { get; set; }

                /// <summary>
                /// Quy cách 
                /// </summary>
                public int? PackingTypeID { get; set; }

                /// <summary>
                /// ĐVT
                /// </summary>
                public int? UnitID { get; set; }

                /// <summary>
                /// VAT 
                /// </summary>
                public int? VAT { get; set; }

                public List<DiscountStep> Prices { get; set; }
            }

            public class DiscountStep
            {
                /// <summary>
                /// Bước duyệt
                /// </summary>
                /// <example>0</example>
                public int? Step { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Các mức giá
                /// </summary>
                public List<DiscountDetail> Details { get; set; }
            }

            public class DiscountDetail
            {
                /// <summary>
                /// Nhóm khách hàng
                /// </summary>
                /// <example>0</example>
                public int? CustomerGroupID { get; set; }

                /// <summary>
                /// Nhóm chiết khấu
                /// </summary>
                /// <example>0</example>
                public int? DiscountGroupID { get; set; }

                /// <summary>
                /// Giá trị
                /// </summary>
                /// <example>0</example>
                public decimal Value { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }

            public class GetPricesBefore
            {
                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Bảng giá tham chiếu
                /// </summary>
                /// <example></example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Tổ chức bán hàng
                /// </summary>
                /// <example>55760</example>
                public string? SalesOrgID { get; set; }

                /// <summary>
                /// Kênh bán hàng
                /// </summary>
                /// <example>56778</example>
                public string? SalesChannelID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example>18933</example>
                public string? PriceGroups { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>/
                /// <example></example>
                public string? GoodsTypeID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>/
                /// <example></example>
                public string? Items { get; set; }

                /// <summary>
                /// Tiêu chí
                /// </summary>
                /// <example>47,68</example>
                public string? ConditionTypes { get; set; }

                /// <summary>
                /// Batch
                /// </summary>
                /// <example>0</example>
                public string? Batch { get; set; }

                /// <summary>
                /// Tuyến NVKD
                /// </summary>
                /// <example>0</example>
                public string? SalesStaffID { get; set; }

                /// <summary>
                /// Nhóm ngành hàng cấp 1
                /// </summary>
                /// <example>0</example>
                public string? ProductTypeID { get; set; }

                /// <summary>
                /// Nhóm ngành hàng cấp 2
                /// </summary>
                /// <example>0</example>
                public string? ItemGroupID { get; set; }

                /// <summary>
                /// Độ dày ván
                /// </summary>
                /// <example>0</example>
                public string? ThicknessID { get; set; }

                /// <summary>
                /// Đơn vị vận chuyển
                /// </summary>
                /// <example>0</example>
                public string? ShippingUnitID { get; set; }

                /// <summary>
                /// Điều khoản thương mại
                /// </summary>
                /// <example>0</example>
                public string? IncotermID { get; set; }

                /// <summary>
                /// Đơn hàng nội địa
                /// </summary>
                /// <example></example>
                public string? OrderID { get; set; }

                /// <summary>
                /// Nhóm danh mục mặt hàng
                /// </summary>
                /// <example>0</example>
                public string? CategoryGroupID { get; set; }

                /// <summary>
                /// Thương hiệu (Đặc tính sản phẩm)
                /// </summary>
                /// <example>0</example>
                public string? Brand1ID { get; set; }

                /// <summary>
                /// Nhà máy
                /// </summary>
                /// <example>0</example>
                public string? FactoryID { get; set; }

                /// <summary>
                /// Điều khoản thanh toán
                /// </summary>
                /// <example>0</example>
                public string? PaymentTermID { get; set; }

                /// <summary>
                /// Tỉnh/TP
                /// </summary>
                /// <example>0</example>
                public string? RegionID { get; set; }

                /// <summary>
                /// Xác nhận đặt hàng
                /// </summary>
                /// <example></example>
                public string? ContractID { get; set; }

                /// <summary>
                /// Loại chứng từ
                /// </summary>
                /// <example>0</example>
                public string? DocumentTypeID { get; set; }

                /// <summary>
                /// Đơn vị bán
                /// </summary>
                /// <example>0</example>
                public string? SaleUnitID { get; set; }

                /// <summary>
                /// Điểm xuất hàng
                /// </summary>
                /// <example>0</example>
                public string? ShippingPointID { get; set; }

                /// <summary>
                /// Thương hiệu (Thông tin sản xuất)
                /// </summary>
                /// <example>0</example>
                public string? Brand2ID { get; set; }

                /// <summary>
                /// Loại tiền tệ
                /// </summary>
                /// <example>17692</example>
                public int? CurrencyTypeID { get; set; }
            }

            public class CalculatePrice
            {
                /// <summary>
                /// Công ty
                /// </summary>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Nhóm giá 
                /// </summary>
                /// <example>12051</example>
                public string? PriceGroups { get; set; }

                /// <summary>
                /// Bước duyệt
                /// </summary>
                /// <example>0</example>
                public int? Step { get; set; }

                public List<CalculateItem> Items { get; set; }
            }

            public class CalculateItem
            {
                /// <summary>
                /// Sản phẩm
                /// </summary>
                /// <example>0</example>
                public int? ItemID { get; set; }

                /// <summary>
                /// Số lượng từ
                /// </summary>
                /// <example>0</example>
                public int? From { get; set; }

                /// <summary>
                /// Số lượng đến
                /// </summary>
                /// <example>0</example>
                public int? To { get; set; }

                /// <summary>
                /// Giá đề xuất
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice { get; set; }
            }
        }
    }
}