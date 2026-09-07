namespace DMS.Models.DMS.PriceCommercials
{
    public class PriceSpecials
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
                /// <example>PriceSpecials</example>
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
                /// Tên bảng giá (VI)
                /// </summary>
                public string? Name { get; set; }

                /// <summary>
                /// Tên bảng giá (EN)
                /// </summary>
                /// <example></example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention9 { get; set; }

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
                /// Ngành hàng
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Nhóm giá theo ngành hàng
                /// </summary>
                /// <example></example>
                public string? SpecialGroupID { get; set; }

                /// <summary>
                /// Điều kiện tính giá
                /// </summary>
                public int? ConditionKeyID { get; set; }

                /// <summary>
                /// Tiêu chí tính giá
                /// </summary>
                /// <example></example>
                public int? ConditionTypeID { get; set; }

                /// <summary>
                /// Tổ chức bán hàng
                /// </summary>
                public string? SalesOrgID { get; set; }

                /// <summary>
                /// Kênh bán hàng
                /// </summary>
                public string? SalesChannelID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example>0</example>
                public string? PriceGroupID { get; set; }

                /// <summary>
                /// Nhóm ngành hàng cấp 1
                /// </summary>
                public string? ProductTypeID { get; set; }

                /// <summary>
                /// Điều khoản thương mại
                /// </summary>
                public string? IncotermID { get; set; }

                /// <summary>
                /// Nhóm danh mục mặt hàng
                /// </summary>
                public string? CategoryGroupID { get; set; }

                /// <summary>
                /// Nhà máy
                /// </summary>
                public string? FactoryID { get; set; }

                /// <summary>
                /// Điều khoản thanh toán
                /// </summary>
                public string? PaymentTermID { get; set; }

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
                public List<PriceSpecialDetail> Details { get; set; }
            }

            public class PriceSpecialDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Quy cách
                /// </summary>
                public int? SpecificationID { get; set; }

                /// <summary>
                /// Model
                /// </summary>
                public List<ItemPrice> Prices { get; set; }
            }

            public class ItemPrice
            {
                /// <summary>
                /// Bước duyệt
                /// </summary>
                /// <example>0</example>
                public int? Step { get; set; }

                /// <summary>
                /// Giá hiện tại 1
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice1 { get; set; }

                /// <summary>
                /// Giá đề xuất 1
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice1 { get; set; }

                /// <summary>
                /// Giá hiện tại 2
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice2 { get; set; }

                /// <summary>
                /// Giá đề xuất 2
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice2 { get; set; }

                /// <summary>
                /// Giá hiện tại 3
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice3 { get; set; }

                /// <summary>
                /// Giá đề xuất 3
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice3 { get; set; }

                /// <summary>
                /// Giá hiện tại 4
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice4 { get; set; }

                /// <summary>
                /// Giá đề xuất 4
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice4 { get; set; }

                /// <summary>
                /// Giá hiện tại 5
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice5 { get; set; }

                /// <summary>
                /// Giá đề xuất 5
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice5 { get; set; }

                /// <summary>
                /// Giá hiện tại 6
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice6 { get; set; }

                /// <summary>
                /// Giá đề xuất 6
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice6 { get; set; }

                /// <summary>
                /// Giá hiện tại 7
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice7 { get; set; }

                /// <summary>
                /// Giá đề xuất 7
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice7 { get; set; }

                /// <summary>
                /// Giá hiện tại 8
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice8 { get; set; }

                /// <summary>
                /// Giá đề xuất 8
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice8 { get; set; }

                /// <summary>
                /// Giá hiện tại 9
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice9 { get; set; }

                /// <summary>
                /// Giá đề xuất 9
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice9 { get; set; }

                /// <summary>
                /// Giá hiện tại 10
                /// </summary>
                /// <example>0</example>
                public decimal CurrentPrice10 { get; set; }

                /// <summary>
                /// Giá đề xuất 10
                /// </summary>
                /// <example>0</example>
                public decimal ProposePrice10 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }
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
                /// Công ty
                /// </summary>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>/
                /// <example></example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Nhóm giá theo ngành hàng
                /// </summary>
                /// <example></example>
                public string? SpecialGroupID { get; set; }

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
                /// <example>0</example>
                public string? PriceGroupID { get; set; }

                /// <summary>
                /// Quy cách
                /// </summary>/
                /// <example></example>
                public string? Specifications { get; set; }

                /// <summary>
                /// Tiêu chí
                /// </summary>
                /// <example>47</example>
                public int? ConditionTypeID { get; set; }

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
                /// Điều khoản thương mại
                /// </summary>
                /// <example>0</example>
                public string? IncotermID { get; set; }

                /// <summary>
                /// Nhóm danh mục mặt hàng
                /// </summary>
                /// <example>0</example>
                public string? CategoryGroupID { get; set; }

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
                /// Loại tiền tệ
                /// </summary>
                /// <example>17692</example>
                public int? CurrencyTypeID { get; set; }
            }
        }
    }
}