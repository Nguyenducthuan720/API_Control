namespace DMS.Models.TMS.Category
{
    public static class NPLVehicles
    {
        public static class Request
        {
            public class Get
            {
                /// <summary>
                /// Mã loại danh mục. Ví dụ: Vehicles: xe, SMRMs: sơ mi rơ moóc
                /// </summary>
                /// <example>Vehicles</example>
                public string? CategoryType { get; set; }
            }

            public class GetTeamVehicle
            {
                /// <summary>
                /// Mã loại danh mục. Ví dụ: Vehicles: xe, SMRMs: sơ mi rơ moóc
                /// </summary>
                /// <example>Vehicles</example>
                public string? TeamVehicleID { get; set; }
            }

            public class GetStationVehicle
            {
                /// <summary>
                /// Mã trạm xe
                /// </summary>
                /// <example>Vehicles</example>
                public string? StationVehicleID { get; set; }
            }

            public class Tires
            {
                /// <summary>
                /// Số serial
                /// </summary>
                /// <example>789456</example>
                public string? SerialNumber { get; set; }

                /// <summary>
                /// Mã nhà sản xuất lốp xe
                /// </summary>
                /// <example>2991</example>
                public int? TireProducerID { get; set; }

                /// <summary>
                /// Vị trí
                /// </summary>
                /// <example>2993</example>
                public int? TirePositionID { get; set; }
            }

            public class Content : Get
            {
                /// <summary>
                /// Mã Lemon
                /// </summary>
                /// <example>1</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>07947-51D</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Mã loại xe
                /// </summary>
                /// <example>22</example>
                public int? VehicleTypeID { get; set; }

                /// <summary>
                /// Mã nhà sản xuất
                /// </summary>
                /// <example>88</example>
                public int? VehicleProducerID { get; set; }

                /// <summary>
                /// Năm sản xuất
                /// </summary>
                /// <example>2012</example>
                public string? ProductionYear { get; set; }

                /// <summary>
                /// Số khung
                /// </summary>
                /// <example>D6CAFJ285807</example>
                public string? ChassisNumber { get; set; }

                /// <summary>
                /// Số máy
                /// </summary>
                /// <example>KMEFC18SPG</example>
                public string? EngineNumber { get; set; }

                /// <summary>
                /// Dung tích xy lanh
                /// </summary>
                /// <example>1</example>
                public string? CylinderCapacity { get; set; }

                /// <summary>
                /// Công suất
                /// </summary>
                /// <example>1</example>
                public string? Power { get; set; }

                /// <summary>
                /// Hộp số
                /// </summary>
                /// <example>6 cấp</example>
                public string? EngineType { get; set; }

                /// <summary>
                /// Kích thước tổng thể (mm)
                /// </summary>
                /// <example>1</example>
                public string? VehicleSize { get; set; }

                /// <summary>
                /// Mã màu sắc xe
                /// </summary>
                /// <example>1</example>
                public int? VehicleColorID { get; set; }

                /// <summary>
                /// Năm hết niên hạn sử dụng
                /// </summary>
                /// <example>1</example>
                public string? ExpiryDate { get; set; }

                /// <summary>
                /// Trọng lượng bản thân
                /// </summary>
                /// <example>1</example>
                public string? KerbMass { get; set; }

                /// <summary>
                /// Trọng tải thiết kế
                /// </summary>
                /// <example>1</example>
                public string? DesignTotalMass { get; set; }

                /// <summary>
                /// Trọng tải kéo theo
                /// </summary>
                /// <example>1</example>
                public string? TowedMass { get; set; }

                /// <summary>
                /// Mã loại nhiên liệu
                /// </summary>
                /// <example>1</example>
                public int? FuelKindID { get; set; }

                /// <summary>
                /// Công suất lớn nhất/tốc độ quay
                /// </summary>
                /// <example>1</example>
                public string? MaxOutputRpm { get; set; }

                /// <summary>
                /// Thể tích làm việc ĐC
                /// </summary>
                /// <example>1</example>
                public string? Displacement { get; set; }

                /// <summary>
                /// Lượng dầu tối đa
                /// </summary>
                /// <example>100</example>
                public decimal OilCapacity { get; set; }

                /// <summary>
                /// Mã loại vỏ bánh xe
                /// </summary>
                /// <example>1</example>
                public int? VehicleTyreID { get; set; }

                /// <summary>
                /// Số lượng bánh xe
                /// </summary>
                /// <example>1</example>
                public int? TyresNumber { get; set; }

                /// <summary>
                /// Xe đầu kéo:1/ Xe tải: 0
                /// </summary>
                /// <example>1</example>
                public int? IsTractor { get; set; }
                /// <summary>
                /// Xe đầu kéo:1/ Xe tải: 0
                /// </summary>
                /// <example>1</example>
                public int? IsForklift { get; set; }

                /// <summary>
                /// Xe có cẩu:1/ Xe không cẩu: 0
                /// </summary>
                /// <example>1</example>
                public int? HasCrane { get; set; }

                /// <summary>
                /// Mã lơ xe
                /// </summary>
                /// <example>1</example>
                public int? DriveHelperID { get; set; }

                /// <summary>
                /// Thiết bị trên xe
                /// </summary>
                /// <example>1</example>
                public string? VehicleDevices { get; set; }

                /// <summary>
                /// Mô tả ắc quy
                /// </summary>
                /// <example>1</example>
                public string? Batteries { get; set; }

                /// <summary>
                /// Số lượng ắc quy
                /// </summary>
                /// <example>1</example>
                public int? BatteryNumber { get; set; }

                /// <summary>
                /// Loại rơ moóc
                /// </summary>
                /// <example>1</example>
                public int? SMRMTypeID { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Km ban đầu
                /// </summary>
                /// <example>100</example>
                public decimal BeginKm { get; set; }

                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }
                /// <summary>
                /// Extention
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }
                /// <example>1</example>
                public string? SerialNumber { get; set; }
                /// <example>1</example>
                public string? VehicleModel { get; set; }
                /// <example>1</example>
                public string? LiftingFrame { get; set; }
                /// <example>1</example>
                public string? LiftingLength { get; set; }
                /// <example>1</example>
                public string? LiftingHeight { get; set; }


                /// <summary>
                /// Danh sách lốp xe
                /// </summary>
                public List<Tires> ListTires { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
                /// <summary>
                /// Đã bán ?
                /// </summary>
                public int? IsSold { get; set; }
                /// <summary>
                /// Thời gian bán ghi nhận
                /// </summary>
                public DateTime SoldDate { get; set; }
                /// <summary>
                /// Hình ảnh ghi nhận đã bán
                /// </summary>
                public string? Link {get;set;}
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class UpdateSell : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? SellActionType { get; set; }
            }
            public class Del : GetByID
            {
            }
        }
    }
}