namespace DMS.Models.DMS.PriceCommercials
{
    public static class Vouchers
    {
        public static class Request
        {

            public class GetByID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string OID { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>PriceCommercials</example>
                public string FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>Voucher</example>
                public string EntryID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-05-31</example>
                public string ODate { get; set; }

                public string? SAPID { get; set; }
                public string? LemonID { get; set; }

                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string CmpnID { get; set; }

                /// <summary>
                /// Tên mã giảm giá (VN)
                /// </summary>
                /// <example></example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên mã giảm giá (EN)
                /// </summary>
                /// <example></example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên mã giảm giá mở rộng
                /// </summary>
                /// <example></example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2025-01-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2025-12-31</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// File đính kèm
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

                /// <summary>
                /// Ngân sách dự kiến
                /// </summary>
                /// <example>100.00</example>
                public decimal Budget { get; set; }

                ///<summary>
                ///Nội dung đề xuất
                /// </summary>
                /// <example></example>
                public string? ProposalContent { get; set; }

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
            }

            public class Add : Content {
                /// <summary>
                /// Danh sách chi tiết thiết lập voucher
                /// </summary>
                public List<DetailsAdd> Details { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string OID { get; set; }

                /// <summary>
                /// Danh sách chi tiết thiết lập voucher
                /// </summary>
                public List<DetailsEdit> Details { get; set; }
            }


        public class DetailsAdd
            {
                /// <summary>
                /// Phân loại voucher (money, percent)
                /// </summary>
                /// <example>money</example>
                public string? VoucherType { get; set; }

                /// <summary>
                /// Giá trị voucher
                /// </summary>
                /// <example>100.00</example>
                public decimal VoucherValue { get; set; }

                /// <summary>
                /// Giá trị tối đa voucher
                /// </summary>
                /// <example>200.00</example>
                public decimal VoucherMaxValue { get; set; }

                /// <summary>
                /// Số lượng voucher phát hành
                /// </summary>
                /// <example>10</example>
                public int VoucherTotal { get; set; }

                /// <summary>
                /// Tổng cộng
                /// </summary>
                /// <example>1000.00</example>
                public decimal TotalAmount { get; set; }

                /// <summary>
                /// Điều kiện tính (quantity/sale/both/either)
                /// </summary>
                /// <example>quantity</example>
                public string ConditionType { get; set; }

                /// <summary>
                /// Điều kiện sản lượng
                /// </summary>
                /// <example>>=</example>
                public string? QuantityCondition { get; set; }

                /// <summary>
                /// Giá trị sản lượng
                /// </summary> 
                /// <example>100</example>
                public int? QuantityValue { get; set; }

                /// <summary>
                /// Điều kiện doanh số
                /// </summary>
                /// <example>>=</example>
                public string? SalesCondition { get; set; }

                /// <summary>
                /// Giá trị doanh số
                /// </summary>
                /// <example>1000.00</example>
                public decimal? SalesValue { get; set; }

                /// <summary>
                /// Nội dung mã giảm giá
                /// </summary>
                /// <example>Khuyến mãi giảm giá cho khách hàng mới</example>
                public string? Content { get; set; }

            }
            public class DetailsEdit: DetailsAdd
            {
                /// <summary>
                /// ID thiết lập voucher
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

            }

            public class GetByDetailId
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string OID { get; set; }

                /// <summary>
                /// ID của thiết lập voucher
                /// </summary>
                /// <example>1</example>
                public int IDReference { get; set; }
            }
            public class CheckVoucher
            {
                /// <summary>
                /// Mã voucher
                /// </summary>
                /// <example>E5F6G7H2</example>
                public string VoucherCode { get; set; }
            }

            public class ApplyVoucher
            {
                /// <summary>
                /// Mã voucher
                /// </summary>
                /// <example>E5F6G7H2</example>
                public string VoucherCode { get; set; }

                /// <summary>
                /// Đơn hàng áp dụng mã voucher
                /// </summary>
                /// <example>E5F6G7H2</example>
                public string ApplyOrder{ get; set; }
            }

            public class Submit
            {
                ///<summary>
                ///Mã CT
                /// </summary>
                /// <example></example>
                public string OID { get; set; }

                ///<summary>
                ///Khóa CT
                /// </summary>
                /// <example>0</example>
                public string IsLock { get; set; }
            }
        }
    }
}