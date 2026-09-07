using APISmartCity.Models.Categorys;

namespace DMS.Models.TMS.Category
{
    public static class NPLCategories
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
                /// <summary>
                /// Mã liên kết Lemon
                /// </summary>
                /// <example>1</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Code sử dụng riêng 1 số trường hợp
                /// </summary>
                /// <example>1</example>
                public string? Code { get; set; }

                /// <summary>
                /// CategoryType
                /// </summary>
                /// <example>1</example>
                public string? CategoryType { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>1</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ 1
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention1 { get; set; }

                /// <summary>
                /// Địa chỉ 2
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention2 { get; set; }

                /// <summary>
                /// Địa chỉ 3
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention3 { get; set; }

                /// <summary>
                /// Địa chỉ 4
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention4 { get; set; }

                /// <summary>
                /// Địa chỉ 5
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention5 { get; set; }

                /// <summary>
                /// Địa chỉ 6
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention6 { get; set; }

                /// <summary>
                /// Địa chỉ 7
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention7 { get; set; }

                /// <summary>
                /// Địa chỉ 8
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention8 { get; set; }

                /// <summary>
                /// Địa chỉ 9
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention9 { get; set; }

                /// <summary>
                /// Số điện thoại
                /// </summary>
                /// <example>1</example>
                public string? PhoneNumber { get; set; }

                /// <summary>
                /// GPS
                /// </summary>
                /// <example>10.800078,106.7447379</example>
                public string? GPS { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>1</example>
                public string? Email { get; set; }

                /// <summary>
                /// Số tài khoản ngân hàng
                /// </summary>
                /// <example>1</example>
                public string? BankNumber { get; set; }

                /// <summary>
                /// Tên người sử dụng tài khoản ngân hàng
                /// </summary>
                /// <example>1</example>
                public string? BankUsername { get; set; }

                /// <summary>
                /// Tiền nâng/hạ container 20
                /// </summary>
                /// <example>1</example>
                public int? Container20Cost { get; set; }

                /// <summary>
                /// Tiền nâng/hạ container 40
                /// </summary>
                /// <example>1</example>
                public int? Container40Cost { get; set; }

                /// <summary>
                /// Mã ngân hàng
                /// </summary>
                /// <example>1</example>
                public int? BankID { get; set; }

                /// <summary>
                /// Tên mã ngân hàng
                /// </summary>
                /// <example>MB</example>
                public string? BankCode { get; set; }

                /// <summary>
                /// Chi nhánh ngân hàng
                /// </summary>
                /// <example>1</example>
                public string? BankBranch { get; set; }

                /// <summary>
                /// Mã đơn vị (số lượng)
                /// </summary>
                /// <example>1</example>
                public int? QuantityUnitID { get; set; }

                /// <summary>
                /// Mã đơn vị (trọng lượng)
                /// </summary>
                /// <example>1</example>
                public int? WeightUnitID { get; set; }

                /// <summary>
                /// Trọng lượng tính quá tải
                /// </summary>
                /// <example>1</example>
                public decimal OverloadWeight { get; set; }

                /// <summary>
                /// Số lượng không tính phụ cấp phủ bạt
                /// </summary>
                /// <example>1</example>
                public int? OverloadQuantity { get; set; }

                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>1</example>
                public string? VehicleNumber { get; set; }

                /// <summary>
                /// Mã người dùng
                /// </summary>
                /// <example>1</example>
                public int? UserID { get; set; }

                /// <summary>
                /// Mã hãng xe thuê ngoài
                /// </summary>
                /// <example>1</example>
                public int? OVPID { get; set; }

                /// <summary>
                /// Định mức theo quy định nhà nước
                /// </summary>
                /// <example>1</example>
                public int? LeaveDay { get; set; }

                /// <summary>
                /// Mã chuyên viên
                /// </summary>
                /// <example>1</example>
                public int? ExpertID { get; set; }

                /// <summary>
                /// Mã loại công việc bảo trì
                /// </summary>
                /// <example>1</example>
                public int? JobTypeID { get; set; }

                /// <summary>
                /// Khối lượng công việc
                /// </summary>
                /// <example>1</example>
                public decimal AmountWork { get; set; }

                /// <summary>
                /// Số lượng nhân công
                /// </summary>
                /// <example>1</example>
                public int? AmountWorker { get; set; }

                /// <summary>
                /// Thời gian làm việc
                /// </summary>
                /// <example>1</example>
                public decimal AmountTime { get; set; }

                /// <summary>
                /// Mã vật tư
                /// </summary>
                /// <example>1</example>
                public int? MSID { get; set; }

                /// <summary>
                /// Số lượng vật tư
                /// </summary>
                /// <example>1</example>
                public int? MaintenanceSupplyAmount { get; set; }

                /// <summary>
                /// Loại vật tư
                /// </summary>
                /// <example>1</example>
                public string? MaintenanceSupplyType { get; set; }

                /// <summary>
                /// Nhà cung cấp vật tư
                /// </summary>
                /// <example>1</example>
                public string? MaintenanceSupplyProducer { get; set; }

                /// <summary>
                /// Số tiền qua trạm
                /// </summary>
                /// <example>1</example>
                public decimal DailyFare { get; set; }

                /// <summary>
                /// Vé tháng
                /// </summary>
                /// <example>1</example>
                public decimal MonthlyFare { get; set; }

                /// <summary>
                /// Mã đơn vị tính
                /// </summary>
                /// <example>1</example>
                public int? UnitID { get; set; }

                /// <summary>
                /// Vị trí
                /// </summary>
                /// <example>1</example>
                public string? Position { get; set; }

                /// <summary>
                /// Mã công việc phụ trách
                /// </summary>
                /// <example>1</example>
                public int? ChargeJobID { get; set; }

                /// <summary>
                /// Mã số thuế
                /// </summary>
                /// <example>1</example>
                public string? TaxCode { get; set; }

                /// <summary>
                /// Nghành hàng
                /// </summary>
                /// <example>1</example>
                public int? ProductTypeID { get; set; }

                /// <summary>
                /// Mã tỉnh, thành phố
                /// </summary>
                /// <example>1</example>
                public int? CityID { get; set; }

                /// <summary>
                /// Mã quận, huyện
                /// </summary>
                /// <example>1</example>
                public int? DistrictID { get; set; }

                /// <summary>
                /// Mã phường, xã
                /// </summary>
                /// <example>1</example>
                public int? WardID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public decimal RedeemRate { get; set; }

                /// <summary>
                /// Có phải đơn vị sửa chữa thuê ngoài?
                /// </summary>
                /// <example>1</example>
                public int? IsRepairSupply { get; set; }

                /// <summary>
                /// Bắt đầu nghỉ lễ
                /// </summary>
                /// <example>2023-09-01</example>
                public string? HolidayBegin { get; set; }

                /// <summary>
                /// kết thúc nghỉ lễ
                /// </summary>
                /// <example>2023-09-04</example>
                public string? HolidayEnd { get; set; }


                public int? InventoryMonth { get; set; }
                public string? InventoryListVehicle {  get; set; }

                public int? InventoryMin { get; set; }

                public int? InventoryMax { get; set; }

                /// <summary>
                /// Mở rộng 1
                /// </summary>
                /// <example>default 1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Mở rộng 2
                /// </summary>
                /// <example>default 2</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Mở rộng 3
                /// </summary>
                /// <example>default 3</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Mở rộng 4
                /// </summary>
                /// <example>default 4</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Mở rộng 5
                /// </summary>
                /// <example>default 5</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Mở rộng 6
                /// </summary>
                /// <example>default 6</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Mở rộng 7
                /// </summary>
                /// <example>default 7</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Mở rộng 8
                /// </summary>
                /// <example>default 8</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// CategoryType
                /// </summary>
                /// <example>Banks</example>
                public string? CategoryType { get; set; }

                /// <summary>
                /// Lấy danh mục để chọn và không có tất cả
                /// </summary>
                /// <example>0</example>
                public string? IsSelectAll { get; set; }
            }

            public class TransportType
            {
                /// <summary>
                /// Loại phương tiện. 542: Xe đầu kéo, 543: Rơ móc, 544: Xe tải
                /// </summary>
                /// <example>Banks</example>
                public int? TransportTypeID { get; set; }
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

            public class Sync
            {
                /// <summary>
                /// Loại sync; PetrolStations: trạm đổ dầu, MaintenanceSupplies: vật tư
                /// </summary>
                /// <example>PetrolStations</example>
                public string? Type { get; set; }
            }
            public class ImportExcel {

                public string? CategoryType { get; set; }
                public string? DataJson { get; set; }

            }

            public class Del : GetByID
            {
                public string? CategoryType { get; set; }
            }
        }
    }
}