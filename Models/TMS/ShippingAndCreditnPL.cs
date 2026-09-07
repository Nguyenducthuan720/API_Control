namespace APISmartCity.Models.TMS
{
    public class ShippingAndCreditnPL
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2022/12/26</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>RQ_SHIPPINGPRICE</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// ID Khách hàng hoặc xe thuê ngoài
                /// </summary>
                /// <example>3</example>
                public int? nPLCustomersID { get; set; }

                /// <summary>
                /// ID Khách hàng
                /// </summary>
                /// <example>3</example>
                public int? CustomersID { get; set; }

                /// <summary>
                /// ID Đơn vị tính
                /// </summary>
                /// <example>10</example>
                public int? nPLUnitsID { get; set; }

                /// <summary>
                /// Hạn mức tín dụng
                /// </summary>
                /// <example>10000000</example>
                public decimal CreditLimit { get; set; }

                /// <summary>
                /// Thời gian thanh toán
                /// </summary>
                /// <example>10</example>
                public int? TimeToPay { get; set; }

                /// <summary>
                /// Dung sai
                /// </summary>
                /// <example>10</example>
                public string? Deviant { get; set; }

                /// <summary>
                /// chặn hạn mức
                /// </summary>
                /// <example>1</example>
                public int? IsBlock { get; set; }

                /// <summary>
                /// Tuyến đường
                /// </summary>
                /// <example>2</example>
                public int? RouteID { get; set; }

                /// <summary>
                /// 0: chuyến đi, 1: chuyến về
                /// </summary>
                /// <example>12</example>
                public int? IsReturn { get; set; }

                /// <summary>
                /// Loại hàng
                /// </summary>
                /// <example>12</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Mặt hàng
                /// </summary>
                /// <example>7</example>
                public int? OrderTypeID { get; set; }

                /// <summary>
                /// Giá dầu
                /// </summary>
                /// <example>1000000</example>
                public decimal OilPrices { get; set; }

                /// <summary>
                /// Giá chưa VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal NonVATPrices { get; set; }

                /// <summary>
                /// % VAT
                /// </summary>
                /// <example>10</example>
                public decimal PercentVAT { get; set; }

                /// <summary>
                /// Giá đã có VAT
                /// </summary>
                /// <example>1100000</example>
                public decimal VATPrices { get; set; }

                /// <summary>
                /// Yêu cầu đặc biệt
                /// </summary>
                /// <example>475,476,474</example>
                public string? SpecialRequirementID { get; set; }

                /// <summary>
                /// Giá cặp cổ chưa VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceNotVATNeckpair { get; set; }

                /// <summary>
                /// Giá cặp cổ có VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceVATNeckpair { get; set; }

                /// <summary>
                /// Giá cặp bán chưa VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceSaleNotVAT { get; set; }

                /// <summary>
                /// Giá bán có VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceSaleVAT { get; set; }

                /// <summary>
                /// Giá cặp bán chưa VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceSaleNotVATNeckpair { get; set; }

                /// <summary>
                /// Giá bán có VAT
                /// </summary>
                /// <example>1000000</example>
                public decimal PriceSaleVATNeckpair { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Link { get; set; }

                /// <summary>
                /// Điểm bắt đầu
                /// </summary>
                /// <example>8</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Điểm kết thúc
                /// </summary>
                /// <example>8</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }
                public string RequestUserID { get; set; }
                public string? ReferenceID { get; set; }

            }

            public class ShippingAndCreditnPLDetail
            {
                /// <summary>
                /// Mã loại phí
                /// </summary>
                /// <example>34</example>
                public int? CostIncurredsID { get; set; }

                /// <summary>
                /// Mức chi phí
                /// </summary>
                /// <example>1100000</example>
                public decimal Amount { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
               
            }

            public class Add : Content
            {
                public List<ShippingAndCreditnPLDetail> shippingAndCreditnPLDetailList { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class GetByCusID
            {
                /// <summary>
                /// ID Khách hàng
                /// </summary>
                /// <example>3</example>
                public int? nPLCustomersID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>RQ_SHIPPINGPRICE</example>
                public string? EntryID { get; set; }
            }
            public class GetOutside 
            {
                public string? EntryID { get; set; }
                public int? RouteID { get; set; }
                public int? CustomersID { get; set; }
                public int? nPLUnitsID { get; set; }
                public int? GoodsTypeID { get; set; }

            }

            public class GetMobile
            {
                /// <summary>
                /// Loại nghiệp vụ
                /// </summary>
                /// <example>RQ_SHIPPINGPRICE</example>
                public string? EntryID { get; set; }
            }
        }
    }
}