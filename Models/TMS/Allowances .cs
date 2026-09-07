namespace APISmartCity.Models.TMS
{
    public static class Allowances
    {
        public static class Request
        {
            public class Vehicles
            {
                /// <summary>
                /// Mã xe
                /// </summary>
                /// <example>1</example>
                public int? VehicleID { get; set; }
            }

            public class CoatTarpAllowanceDetail
            {
                /// <summary>
                /// Mã hàng
                /// </summary>
                /// <example>1</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Phụ cấp cũ/chuyến
                /// </summary>
                /// <example>1</example>
                public decimal OldAllowance { get; set; }

                /// <summary>
                /// Phụ cấp mới/chuyến
                /// </summary>
                /// <example>1</example>
                public decimal NewAllowance { get; set; }

                /// <summary>
                /// Chênh lệch phụ cấp chuyến
                /// </summary>
                /// <example>1</example>
                public decimal DeviantAllowance { get; set; }

                /// <summary>
                /// Tổng phụ cấp cũ/tháng
                /// </summary>
                /// <example>1</example>
                public decimal TotalOldAllowance { get; set; }

                /// <summary>
                /// Tổng phụ cấp mới/tháng
                /// </summary>
                /// <example>1</example>
                public decimal TotalNewAllowance { get; set; }

                /// <summary>
                /// Chênh lệch phụ cấp tháng
                /// </summary>
                /// <example>1</example>
                public decimal DeviantMonthAllowance { get; set; }
            }

            public class OutSideVehiclesAllowancesDetail
            {
                /// <summary>
                /// Mã khu vực
                /// </summary>
                /// <example>1</example>
                public int? RegionID { get; set; }

                /// <summary>
                /// PC xăng ngoài các khu vực đã chọn cũ
                /// </summary>
                /// <example>1</example>
                public decimal OldOilAllowance { get; set; }

                /// <summary>
                /// PC ngoài giờ ngoài các khu vực đã chọn mới
                /// </summary>
                /// <example>1</example>
                public decimal NewOilAllowance { get; set; }

                /// <summary>
                /// Chênh lệch PC xăng ngoài các khu vực đã chọn
                /// </summary>
                /// <example>1</example>
                public decimal DeviantOilAllowance { get; set; }

                /// <summary>
                /// PC ngoài giờ ngoài các khu vực đã chọn cũ
                /// </summary>
                /// <example>1</example>
                public decimal OldOTAllowance { get; set; }

                /// <summary>
                /// PC xăng ngoài các khu vực đã chọn mới
                /// </summary>
                /// <example>1</example>
                public decimal NewOTAllowance { get; set; }

                /// <summary>
                /// Chênh lệch PC ngoài giờ ngoài các khu vực đã chọn
                /// </summary>
                /// <example>1</example>
                public decimal DeviantOTAllowance { get; set; }
            }

            public class PairshipAllowancesDetail
            {
                /// <summary>
                /// Tuyến đường
                /// </summary>
                /// <example>1</example>
                public int? RouteID { get; set; }

                /// <summary>
                /// Số lần quy đổi/chuyến
                /// </summary>
                /// <example>1</example>
                public int? NumberOfRedemptions { get; set; }
            }

            public class PieceTireAllowancesDetail
            {
                /// <summary>
                /// Từ chuyến
                /// </summary>
                /// <example>1</example>
                public int? FromTrip { get; set; }

                /// <summary>
                /// Đến chuyến
                /// </summary>
                /// <example>1</example>
                public int? ToTrip { get; set; }

                /// <summary>
                /// Số tiền phụ cấp
                /// </summary>
                /// <example>1</example>
                public decimal AllowanceCost { get; set; }
            }
            public class AllowancesDetailsVehicle 

            {
                /// <example>1</example>
                public int? FromTrip { get; set; }

                /// <summary>
                /// Đến chuyến
                /// </summary>
                /// <example>1</example>
                public int? ToTrip { get; set; }

                /// <summary>
                /// Số tiền phụ cấp
                /// </summary>
                /// <example>1</example>
                public decimal AllowanceCost { get; set; }
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
                /// Nghiệp vụ
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>1</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Danh sách nhóm xe
                /// </summary>
                /// <example>1</example>
                public string? VehicleGroupID { get; set; }

                /// <summary>
                /// Tổng tất cả phụ cấp tối đa/tháng
                /// </summary>
                /// <example>1</example>
                public decimal MaxAllowanceCost { get; set; }

                /// <summary>
                /// PC ngày không hàng
                /// </summary>
                /// <example>1</example>
                public decimal NonStockAllowance { get; set; }

                /// <summary>
                /// PC ngày có hàng
                /// </summary>
                /// <example>1</example>
                public decimal StockAllowance { get; set; }

                /// <summary>
                /// PC ngày trả hàng
                /// </summary>
                /// <example>1</example>
                public decimal BackStockAllowance { get; set; }

                /// <summary>
                /// Phụ cấp cơm xe đi đăng kiểm
                /// </summary>
                /// <example>0.00</example>
                public decimal MealRegistry { get; set; }

                /// <summary>
                /// Phụ cấp cơm xe đi bảo trì
                /// </summary>
                /// <example>0.00</example>
                public decimal MealMaintenance { get; set; }

                /// <summary>
                /// Phụ cấp cơm xe bị sự cố
                /// </summary>
                /// <example>0.00</example>
                public decimal MealAccidence { get; set; }

                /// <summary>
                /// Phụ cấp cơm xe nghỉ phép
                /// </summary>
                /// <example>0.00</example>
                public decimal MealRest { get; set; }

                /// <summary>
                /// Phụ cấp cơm xe đi bảo hiểm
                /// </summary>
                /// <example>0.00</example>
                public decimal MealInsurance { get; set; }

                /// <summary>
                /// Phụ cấp lơ xe có cẩu
                /// </summary>
                /// <example>0.00</example>
                public decimal CraneAllowance { get; set; }

                /// <summary>
                /// Phụ cấp lơ xe có cẩu chở không cẩu
                /// </summary>
                /// <example>0.00</example>
                public decimal CraneNoAllowance { get; set; }

                /// <summary>
                /// Phụ cấp lơ xe không cẩu
                /// </summary>
                /// <example>0.00</example>
                public decimal NoCraneAllowance { get; set; }


                /// <summary>
                /// Phụ cấp lơ xe không cẩu
                /// </summary>
                /// <example>0.00</example>

                public decimal BasicSalaryDriver { get; set; }

                /// <summary>
                /// Số tiền phụ cấp/chuyến(quá tải)
                /// </summary>
                /// <example>1</example>
                public decimal OverloadAllowance { get; set; }

                /// <summary>
                /// PC xăng ngoài các khu vực đã chọn
                /// </summary>
                /// <example>1</example>
                public decimal OtherOilAllowance { get; set; }

                /// <summary>
                /// PC ngoài giờ ngoài các khu vực đã chọn
                /// </summary>
                /// <example>1</example>
                public decimal OtherOTAllowance { get; set; }

                /// <summary>
                /// PC khi chở hàng không cẩu
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost0 { get; set; }

                /// <summary>
                /// CraneCost1
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost1 { get; set; }

                /// <summary>
                /// CraneCost2
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost2 { get; set; }

                /// <summary>
                /// CraneCost3
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost3 { get; set; }

                /// <summary>
                /// CraneCost4
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost4 { get; set; }

                /// <summary>
                /// CraneCost5
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost5 { get; set; }

                /// <summary>
                /// CraneCost6
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost6 { get; set; }

                /// <summary>
                /// CraneCost7
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost7 { get; set; }

                /// <summary>
                /// CraneCost8
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost8 { get; set; }

                /// <summary>
                /// CraneCost9
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost9 { get; set; }

                /// <summary>
                /// CraneCost10
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost10 { get; set; }

                /// <summary>
                /// Số tiền cẩu trên 10 lần
                /// </summary>
                /// <example>1</example>
                public decimal CraneCost11 { get; set; }

                /// <summary>
                /// Từ chuyến số
                /// </summary>
                /// <example>1</example>
                public int? TotalQuantityTrip { get; set; }

                /// <summary>
                /// Được phụ cấp
                /// </summary>
                public decimal TotalAmountTrip { get; set; }
     
                /// <summary>
                /// Số tiền lương cơ bản
                /// </summary>
                public decimal AmountSalary { get; set; }

                /// <summary>
                /// Chi tiết phủ bạt
                /// </summary>
                public List<CoatTarpAllowanceDetail> CoatTarpAllowanceDetails { get; set; }

                /// <summary>
                /// Chi tiết phụ cấp cứu xe bên ngoài
                /// </summary>
                public List<OutSideVehiclesAllowancesDetail> OutSideVehiclesAllowancesDetails { get; set; }

                /// <summary>
                /// Chi tiết phụ cấp chuyến tăng bo
                /// </summary>
                public List<PairshipAllowancesDetail> PairshipAllowancesDetails { get; set; }

                /// <summary>
                /// Chi tiết khoán vá vỏ
                /// </summary>
                public List<PieceTireAllowancesDetail> PieceTireAllowancesDetails { get; set; }
                public List<AllowancesDetailsVehicle> AllowancesDetailsVehicles { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }



                /// <summary>
                /// Mở rộng 1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Mở rộng 2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }


                /// <summary>
                /// Mở rộng 3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }


                /// <summary>
                /// Mở rộng 4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }


                /// <summary>
                /// Mở rộng 5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Link { get; set; }
                public decimal? CraneHelpAllowance { get; set; }

            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }

                ///// <summary>
                ///// Có dùng/không dùng
                ///// </summary>
                ///// <example>ÐXPCC/18/11/22/001</example>
                //public int? IsActive { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class Del : GetByID
            {
            }
        }
    }
}