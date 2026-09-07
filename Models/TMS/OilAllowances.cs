namespace APISmartCity.Models.TMS
{
    public static class OilAllowances
    {
        public static class Request
        {
            public class OilAllowancesGoodType
            {
                /// <summary>
                /// Mã loại hàng hóa
                /// </summary>
                /// <example>1</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Định mức mới
                /// </summary>
                /// <example>1</example>
                public int? NewQuota { get; set; }

                /// <summary>
                /// Định mức cũ
                /// </summary>
                /// <example>2</example>
                public int? OldQuota { get; set; }

                /// <summary>
                /// Mức chênh lệch
                /// </summary>
                /// <example>1</example>
                public int? Deviant { get; set; }
            }

            public class OilAllowancesGoodTypeTotal : OilAllowancesGoodType
            {
                /// <summary>
                /// Trong tải/quá tải
                /// </summary>
                /// <example>1</example>
                public int? IsOverload { get; set; }

                /// <summary>
                /// Mã loại hàng hóa
                /// </summary>
                /// <example>1</example>
                public int? OrderTypeID { get; set; }

                /// <summary>
                /// Chuyến ghép / không ghép
                /// </summary>
                /// <example>0</example>
                public int? IsJoinShip { get; set; }
            }

            public class OilAllowancesRoute
            {
                /// <summary>
                /// Mã tuyến đường
                /// </summary>
                /// <example>1</example>
                public int? RouteID { get; set; }

                /// <summary>
                /// Định mức mới
                /// </summary>
                /// <example>1</example>
                public int? NewQuota { get; set; }

                /// <summary>
                /// Định mức cũ
                /// </summary>
                /// <example>2</example>
                public int? OldQuota { get; set; }

                /// <summary>
                /// Mức chênh lệch
                /// </summary>
                /// <example>1</example>
                public int? Deviant { get; set; }
            }

            public class OilAllowancesVehicle
            {
                /// <summary>
                /// Mã xe
                /// </summary>
                /// <example>1</example>
                public int? VehicleID { get; set; }

                /// <summary>
                /// Định mức mới
                /// </summary>
                /// <example>1</example>
                public int? NewQuota { get; set; }

                /// <summary>
                /// Định mức cũ
                /// </summary>
                /// <example>2</example>
                public int? OldQuota { get; set; }

                /// <summary>
                /// Mức chênh lệch
                /// </summary>
                /// <example>1</example>
                public int? Deviant { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class GoodTypes
            {
                /// <summary>
                /// Mã loại hàng
                /// </summary>
                /// <example>12</example>
                public string? GoodsTypeID { get; set; }

                /// <summary>
                /// Trong tải/quá tải
                /// </summary>
                /// <example>1</example>
                public int? IsOverload { get; set; }

                /// <summary>
                /// Mã loại hàng hóa
                /// </summary>
                /// <example>1</example>
                public int? OrderTypeID { get; set; }

                /// <summary>
                /// Chuyến ghép / không ghép
                /// </summary>
                /// <example>0</example>
                public int? IsJoinShip { get; set; }

            }

            public class Routes
            {
                /// <summary>
                /// Mã tuyến đường
                /// </summary>
                /// <example>2</example>
                public string? RouteID { get; set; }
            }

            public class Vehicles
            {
                /// <summary>
                /// Mã xe
                /// </summary>
                /// <example>1</example>
                public string? VehicleID { get; set; }
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
                /// <example>1</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>21,230</example>
                public string? VehicleGroupID { get; set; }

                /// <summary>
                /// Mức phụ cấp xe có cẩu (số lít/tấn)
                /// </summary>
                /// <example>0</example>
                public decimal Cranes { get; set; }

                /// <summary>
                /// Mức phụ cấp xe không cẩu (số lít/tấn)
                /// </summary>
                /// <example>0</example>
                public decimal NoCranes { get; set; }

                /// <summary>
                /// Mức phụ cấp trong tải/chuyến (hàng rời)
                /// </summary>
                /// <example>0</example>
                public decimal NotOverloadNotCont { get; set; }

                /// <summary>
                /// Mức phụ cấp trong tải/chuyến (hàng cont)
                /// </summary>
                /// <example>0</example>
                public decimal NotOverloadCont { get; set; }

                /// <summary>
                /// Mức phụ cấp quá tải/chuyến (hàng rời)
                /// </summary>
                /// <example>0</example>
                public decimal OverloadNotCont { get; set; }

                /// <summary>
                /// Mức phụ cấp quá tải/chuyến (hàng cont)
                /// </summary>
                /// <example>0</example>
                public decimal OverloadCont { get; set; }

                // <summary>
                /// Mức phụ cấp ghép/chuyến (hàng cont)
                /// </summary>
                /// <example>0</example>
                public decimal JoinShipOilCont { get; set; }
                // <summary>
                /// Mức phụ cấp ghép/chuyến (hàng rời)
                /// </summary>
                /// <example>0</example>
                public decimal JoinShipOilNotCont { get; set; }

                /// <summary>
                /// Chi tiết định mức mặt hàng trong tải (hàng rời)
                /// </summary>
                public List<OilAllowancesGoodType> NotOverloadNotContGoodTypes { get; set; }

                /// <summary>
                /// Chi tiết định mức mặt hàng trong tải (hàng cont)
                /// </summary>
                public List<OilAllowancesGoodType> NotOverloadContGoodTypes { get; set; }

                /// <summary>
                /// Chi tiết định mức mặt hàng quá tải (hàng rời)
                /// </summary>
                public List<OilAllowancesGoodType> OverloadNotContGoodTypes { get; set; }

                /// <summary>
                /// Chi tiết định mức mặt hàng quá tải (hàng cont)
                /// </summary>
                public List<OilAllowancesGoodType> OverloadContGoodTypes { get; set; }

                /// <summary>
                /// Chi tiết định mức mặt hàng quá tải (hàng rời)
                /// </summary>
                public List<OilAllowancesGoodType> JoinShipOilNotContGoodTypes { get; set; }

                /// <summary>
                /// Chi tiết định mức mặt hàng quá tải (hàng cont)
                /// </summary>
                public List<OilAllowancesGoodType> JoinShipOilContGoodTypes { get; set; }

                /// <summary>
                /// Chi tiết phụ cấp cứu xe bên ngoài
                /// </summary>
                public List<OilAllowancesRoute> OilAllowancesRoutes { get; set; }

                /// <summary>
                /// Chi tiết phụ cấp cứu xe bên ngoài
                /// </summary>
                public List<OilAllowancesVehicle> OilAllowancesVehicles { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
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

            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class Submit : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Del : GetByID
            {
            }
        }
    }
}