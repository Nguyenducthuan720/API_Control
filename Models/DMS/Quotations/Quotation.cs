using System;

namespace DMS.Models.DMS.Quotations
{
    public static class Quotation
    {
        public static class Request
        {

            public class GetByID
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
                /// Công ty
                /// </summary>
                /// <example>0</example>
                public string CmpnID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>QuotationDomestic</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>DomesticVLH</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã CT
                /// </summary>
                public string? OID { get; set; }

                /// <summary>
                /// Ngày CT
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
                /// Tên báo giá (VI)
                /// </summary>
                public string? QuotationName { get; set; }

                /// <summary>
                /// Tên báo giá (EN)
                /// </summary>
                public string? QuotationNameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? QuotationNameExtention9 { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                public DateTime FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                public DateTime ToDate { get; set; }

                /// <summary>
                /// Kênh bán hàng
                /// </summary>
                public int? SalesChannelID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                public string? Customers { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public string? GoodsTypes { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Giá chung/Giá riêng
                /// </summary>
                public int? IsGeneralPrice { get; set; }

                /// <summary>
                /// Áp dụng khuyến mãi
                /// </summary>
                public int? ApplyPromotion { get; set; }

                /// <summary>
                /// Điều khoản thanh toán
                /// </summary>
                public int? PaymentTermID { get; set; }

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
                /// Thông tin giao hàng
                /// </summary>
                public string? DeliveryTerms { get; set; }

                /// <summary>
                /// Thông tin khác
                /// </summary>
                public string? Info { get; set; }

                /// <summary>
                /// VAT
                /// </summary>
                public string VATValue { get; set; }

                /// <summary>
                /// Thành tiền
                /// </summary>
                public decimal ItemAmount { get; set; }

                /// <summary>
                /// Tiền thuế
                /// </summary>
                public decimal VATAmount { get; set; }

                /// <summary>
                /// Tổng tiền
                /// </summary>
                public decimal TotalAmount { get; set; }

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
                public List<Detail> Details { get; set; }
            }

            public class Detail : GetByID
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                public int? ItemID { get; set; }

                /// <summary>
                /// VAT
                /// </summary>
                public int? VAT { get; set; }

                /// <summary>
                /// SL
                /// </summary>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Giá bán
                /// </summary>
                public decimal Price { get; set; }

                /// <summary>
                /// Giá bán chưa VAT
                /// </summary>
                public decimal PriceNotVAT { get; set; }

                /// <summary>
                /// Thành tiền
                /// </summary>
                public decimal ItemAmount { get; set; }

                /// <summary>
                /// Tiền thuế
                /// </summary>
                public decimal VATAmount { get; set; }

                /// <summary>
                /// Tổng tiền
                /// </summary>
                public decimal TotalAmount { get; set; }

                /// <summary>
                /// Chi tiết tính giá
                /// </summary>
                public string? Details { get; set; }

                /// <summary>
                /// Chính sách giá
                /// </summary>
                public string? PricePolicyID { get; set; }

                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }
            }

            public class Del : GetByID
            {
            }
            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
            }

            public class GetItems
            {
                /// <summary>
                /// Công ty
                /// </summary>
                /// <example>QuotationDomestic</example>
                public string CmpnID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>QuotationDomestic</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>DomesticVLH</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Kênh bán hàng
                /// </summary>
                public int? SalesChannelID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                public string? Customers { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                public string? GoodsTypes { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Giá tham chiếu
                /// </summary>
                public int? IsGeneralPrice { get; set; }

                /// <summary>
                /// Áp dụng khuyến mãi
                /// </summary>
                public int? ApplyPromotion { get; set; }

                /// <summary>
                /// Đơn vị tiền tệ
                /// </summary>
                public int? CurrencyTypeID { get; set; }

                /// <summary>
                /// Danh sách sản phẩm
                /// </summary>
                public List<Detail> Details { get; set; }
            }
        }
    }
}