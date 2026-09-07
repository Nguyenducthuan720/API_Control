namespace APISmartCity.Models.TMS
{
    public static class RouteAllowances
    {
        public static class Request
        {
            public class RouteAllowancesDetails
            {
                /// <summary>
                /// Mã trạm thu phí
                /// </summary>
                /// <example>1</example>
                public int? ChargingStationID { get; set; }

                /// <summary>
                /// Mức phí
                /// </summary>
                /// <example>1</example>
                public int? ChargingCost { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>RQ_COATTARP</example>
                public string? EntryID { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2022/12/13</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Mã tuyến
                /// </summary>
                /// <example>3</example>
                public int? RouteID { get; set; }

                /// <summary>
                /// Mã loại hàng
                /// </summary>
                /// <example>105</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Hàng cont/ rời
                /// </summary>
                /// <example>8</example>
                public int? OrderTypeID { get; set; }

                /// <summary>
                /// Tổng chi phí trong tải
                /// </summary>
                /// <example>2000000.00</example>
                public decimal NoOverloadTotalCost { get; set; }

                /// <summary>
                /// Chi phí trong tải
                /// </summary>
                /// <example>3000000.00</example>
                public decimal NoOverloadCost { get; set; }

                /// <summary>
                /// Lương tài xế trong tải
                /// </summary>
                /// <example>4000000.00</example>
                public decimal NoOverloadSalary { get; set; }

                /// <summary>
                /// Tổng chi phí quá tải
                /// </summary>
                /// <example>1000000.00</example>
                public decimal OverloadTotalCost { get; set; }

                /// <summary>
                /// Chi phí quá tải
                /// </summary>
                /// <example>1000000.00</example>
                public decimal OverloadCost { get; set; }

                /// <summary>
                /// Lương tài xế quá tải
                /// </summary>
                /// <example>1000000.00</example>
                public decimal OverloadSalary { get; set; }

                /// <summary>
                /// Phí cầu đường
                /// </summary>
                /// <example>1000000.00</example>
                public decimal ChargingCost { get; set; }

                /// <summary>
                /// Phí khác
                /// </summary>
                /// <example>1000000.00</example>
                public decimal OtherCost { get; set; }

                /// <summary>
                /// Mô tả phí khác
                /// </summary>
                /// <example></example>
                public string? OtherCostDescription { get; set; }

                /// <summary>
                /// Chi tiết phí cầu đường
                /// </summary>
                /// <example>1</example>
                public List<RouteAllowancesDetails> RouteAllowancesDetails { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Link { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class Submit : GetByID
            {
 
                public int? IsLock { get; set; }
            }
            public class EditStatus : GetByID
            {

                public int? IsActive { get; set; }
            }
            public class Del : GetByID
            {
            }
        }
    }
}