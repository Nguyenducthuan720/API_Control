namespace DMS.Models.DMS.PriceCommercials
{
    public class PriceProposals
    {
        public class Request
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
                /// Nghiệp vụ
                /// </summary>
                /// <example>PriceCommercials</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>SpecificPriceProposal</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                public string? OID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-05-19</example>
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
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Đề xuất giá riêng của khách hàng
                /// </summary>
                /// <example></example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Tiêu chí giảm giá
                /// </summary>
                /// <example></example>
                public string? ConditionTypes { get; set; }

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
                /// Lý do đề xuất
                /// </summary>
                public int? ReasonID { get; set; }

                /// <summary>
                /// Chi tiết đề xuất
                /// </summary>
                /// <example></example>
                public string? Content { get; set; }

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

                /// <summary>
                /// Loại tiền tệ
                /// </summary>
                public int? CurrencyTypeID { get; set; }

                /// <summary>
                /// Tỷ giá
                /// </summary>
                /// <example>1</example>
                public decimal CurrencyRate { get; set; }

                /// <summary>
                /// Ngày tỷ giá
                /// </summary>
                /// <example>2025-10-07</example>
                public string? CurrencyDate { get; set; }

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

                public List<PriceProposalDetail> Details { get; set; }
            }

            public class PriceProposalDetail
            {
                public int? ID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example>0</example>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example>0</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// ID model
                /// </summary>
                /// <example>0</example>
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
                /// Chiết khấu
                /// </summary>
                public decimal DiscountPrice { get; set; }

                /// <summary>
                /// Khuyến mãi
                /// </summary>
                public decimal PromotePrice { get; set; }

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

                public List<PriceProposalApproval> Prices { get; set; }
            }

            public class PriceProposalApproval
            {
                /// <summary>
                /// Bước duyệt
                /// </summary>
                /// <example>0</example>
                public int? Step { get; set; }

                /// <summary>
                /// Giá cơ sở
                /// </summary>
                public decimal BasePrice { get; set; }

                /// <summary>
                /// Giá bán đề xuất
                /// </summary>
                public decimal ProposePrice { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }

                public List<PriceProposalItemCondition> Details { get; set; }
            }

            public class PriceProposalItemCondition
            {
                /// <summary>
                /// Tiêu chí
                /// </summary>
                public int? ConditionTypeID { get; set; }

                /// <summary>
                /// Giá
                /// </summary>
                public decimal Price { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }

            public class GetBasePrices
            {
                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example>0</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example>0</example>
                public int? PriceGroupID { get; set; }

                /// <summary>
                /// Loại tiền tệ
                /// </summary>
                /// <example>0</example>
                public int? CurrencyTypeID { get; set; }

                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example></example>
                public string? GoodsTypes { get; set; }

                /// <summary>
                /// Sản phẩm
                /// </summary>
                /// <example></example>
                public string? Items { get; set; }
            }
        }
    }
}