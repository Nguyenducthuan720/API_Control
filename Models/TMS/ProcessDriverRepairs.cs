namespace APISmartCity.Models.TMS
{
    public static class ProcessDriverRepairs
    {
        public static class Request
        {
            public class Get
            {
                public int? IsApproval { get; set; }
            }
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus : GetByID
            {
                /// <summary>
                /// Khóa hay không?
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit : GetByID
            {
                /// <summary>
                /// Khóa hay không?
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class UpdatePayments : GetByID
            {
                /// <summary>
                /// Khóa hay không?
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }

                /// <summary>
                /// Đơn vị sửa chữa
                /// </summary>
                /// <example>1</example>
                public int? RepairProducersID { get; set; }

            }

            public class Receive : GetByID
            {
                /// <summary>
                /// Đồng ý hay không?
                /// </summary>
                /// <example>1</example>
                public int? IsApproval { get; set; }

                /// <summary>
                /// Lý do từ chối
                /// </summary>
                /// <example>CCCCC</example>
                public string? CancelNote { get; set; }
            }
            public class ReceiveInfo : GetByID
            {
                /// <summary>
                /// Đồng ý hay không?
                /// </summary>
                /// <example>1</example>
                public int? ReceiveInfoStatus { get; set; }
                /// <summary>
                /// Ngày tiếp nhận thông tin xe
                /// </summary>
                public DateTime ReceiveInfoDate { get; set; }
                /// <summary>
                /// Nội dung tiếp nhận thông tin xe
                /// </summary>
                public string? ReceiveInfoContent { get; set; }
                /// <summary>
                /// Ghi chú tiếp nhận thông tin xe
                /// </summary>
                public string? ReceiveInfoNote { get; set; }

            }
            public class EditReceiveInfo : GetByID
            {
                /// <summary>
                /// Ngày tiếp nhận thông tin xe
                /// </summary>
                public DateTime ReceiveInfoDate { get; set; }
                /// <summary>
                /// Nội dung tiếp nhận thông tin xe
                /// </summary>
                public string? ReceiveInfoContent { get; set; }
                /// <summary>
                /// Ghi chú tiếp nhận thông tin xe
                /// </summary>
                public string? ReceiveInfoNote { get; set; }
            }

            public class Insurances
            {
                /// <summary>
                /// Ngày nhận
                /// </summary>
                /// <example>2023/05/30</example>
                public string? ReceiveDate { get; set; }

                /// <summary>
                /// Số tiền nhận
                /// </summary>
                /// <example>1000000</example>
                public decimal ReceiveMoney { get; set; }

                /// <summary>
                /// Số phiếu liên quan
                /// </summary>
                /// <example>1</example>
                public string? ReceiveCode { get; set; }

                /// <summary>
                /// Đơn vị bảo hiểm
                /// </summary>
                /// <example>93</example>
                public int? ExtendUnitsID { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
            }

            public class Outsources
            {
                /// <summary>
                /// Chi phí
                /// </summary>
                /// <example>Sửa bố thắng</example>
                public string? OutsourceCostName { get; set; }

                /// <summary>
                /// Số tiền
                /// </summary>
                /// <example>100000</example>
                public decimal OutsourceCost { get; set; }

                /// <summary>
                /// Ký hiệu và Hóa đơn
                /// </summary>
                /// <example>121965</example>
                public string? BillCode { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }
            }

            public class Rescues
            {
                /// <summary>
                /// Khu vực
                /// </summary>
                /// <example>33</example>
                public int? RegionID { get; set; }

                /// <summary>
                /// Nhân viên cứu xe
                /// </summary>
                /// <example>1</example>
                public string? RescueID { get; set; }

                /// <summary>
                /// Có phải xe cá nhân?
                /// </summary>
                /// <example>1</example>
                public int? IsPrivateCar { get; set; }

                /// <summary>
                /// Phụ cấp xăng
                /// </summary>
                /// <example>200000</example>
                public decimal FuelAllowance { get; set; }

                /// <summary>
                /// Phụ cấp ngoài giờ
                /// </summary>
                /// <example>10000</example>
                public decimal OvertimeAllowance { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }
            }

            public class Supplies
            {
                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>51</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Mã công việc
                /// </summary>
                /// <example>51</example>
                public int? MaintenanceJobsID { get; set; }

                /// <summary>
                /// Mã vật tư
                /// </summary>
                /// <example>48</example>
                public int? MaintenanceSuppliesID { get; set; }

                /// <summary>
                /// Mã công ty thuê ngoài
                /// </summary>
                /// <example>48</example>
                public int? SupplyProducersID { get; set; }

                /// <summary>
                /// Mã công ty sửa chữa
                /// </summary>
                /// <example>48</example>
                public int? RepairProducersID { get; set; }

                /// <summary>
                /// Số lượng
                /// </summary>
                /// <example>1</example>
                public decimal Amount { get; set; }

                /// <summary>
                /// Thành tiền
                /// </summary>
                /// <example>1</example>
                public decimal Prices { get; set; }

                /// <summary>
                /// Có phải thuê ngoài
                /// </summary>
                /// <example>1</example>
                public int? IsOutsource { get; set; }

                /// <summary>
                /// Có phải sửa gara bên ngoài
                /// </summary>
                /// <example>1</example>
                public int? IsOutsourceRepair { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }


                public int IsExported {  get; set; }
                public int IsLock { get; set; }
            }

            public class Repairs
            {
                /// <summary>
                /// Mã Đơn vị sửa chửa thuê ngoài
                /// </summary>
                /// <example>48</example>
                public int? RepairProducersID { get; set; }

                /// <summary>
                /// StartTime
                /// </summary>
                /// <example>2023-08-14 10:10:10</example>
                public string? StartTime { get; set; }

                /// <summary>
                /// EndTime
                /// </summary>
                /// <example>2023-08-16 10:10:10</example>
                public string? EndTime { get; set; }

                /// <summary>
                /// Tình trạng bàn giao
                /// </summary>
                /// <example>Kết quả tốt đẹp</example>
                public string? ReceiveNote { get; set; }

                /// <summary>
                /// Hướng giải quyết
                /// </summary>
                /// <example>Đá bà Trang</example>
                public string? ReceiveSolution { get; set; }

                /// <summary>
                /// Kết quả
                /// </summary>
                /// <example>Kết thúc thành công</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>123</example>
                public string? Note { get; set; }

                /// <summary>
                /// IDStatus
                /// </summary>
                /// <example>1</example>
                public int? IDStatus { get; set; }
            }

            public class EditReceive : GetByID
            {
                /// <summary>
                /// Có phải thuê sửa ngoài?
                /// </summary>
                /// <example>1</example>
                public int? IsOutsourceRepair { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2023-02-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Thời gian xe về
                /// </summary>
                /// <example>2023/04/13 11:00</example>
                public string? ReceiveVehicleTime { get; set; }

                /// <summary>
                /// Tình trạng tiếp nhận
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveNote { get; set; }

                /// <summary>
                /// Ghi chú tiếp nhận
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveOtherNote { get; set; }

                /// <summary>
                /// Hướng giải quyết
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveSolution { get; set; }

                /// <summary>
                /// Dự kiến thời gian giao
                /// </summary>
                /// <example>2023-03-20 12:00</example>
                public string? ExpectedTime { get; set; }
            }

            public class EditComplete : GetByID
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? Note { get; set; }

                /// <summary>
                /// Công việc hoàn thành
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Công việc chưa hoàn thành
                /// </summary>
                /// <example>Chưa thay nhớt</example>
                public string? UnfinishNote { get; set; }

                /// <summary>
                /// Số km bàn giao
                /// </summary>
                /// <example>24000</example>
                public decimal HandedOverkm { get; set; }

                /// <summary>
                /// Người thực hiện
                /// </summary>
                /// <example>1,2,3</example>
                public string? ListExecutor { get; set; }

                /// <summary>
                /// THÔNG TIN BẢO HIỂM CHI TRẢ
                /// </summary>
                public List<Insurances> Insurances { get; set; }

                /// <summary>
                /// CHI PHÍ SỬA CHỮA
                /// </summary>
                public List<Outsources> Outsources { get; set; }

                /// <summary>
                /// THÔNG TIN CỨU XE BÊN NGOÀI
                /// </summary>
                public List<Rescues> Rescues { get; set; }

                /// <summary>
                /// THÔNG TIN CÔNG VIỆC VÀ VẬT TƯ
                /// </summary>
                public List<Supplies> Supplies { get; set; }

                /// <summary>
                /// THÔNG TIN Sửa chữa ngoài
                /// </summary>
                public List<Repairs> Repairs { get; set; }
            }

            public class Edit : GetByID
            {
                /// <summary>
                /// Tình trạng tiếp nhận
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveNote { get; set; }

                /// <summary>
                /// Ghi chú tiếp nhận
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveOtherNote { get; set; }

                /// <summary>
                /// Hướng giải quyết
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveSolution { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? Note { get; set; }

                /// <summary>
                /// Công việc hoàn thành
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Công việc chưa hoàn thành
                /// </summary>
                /// <example>Chưa thay nhớt</example>
                public string? UnfinishNote { get; set; }

                /// <summary>
                /// Số km bàn giao
                /// </summary>
                /// <example>24000</example>
                public decimal HandedOverkm { get; set; }

                /// <summary>
                /// Người thực hiện
                /// </summary>
                /// <example>1,2,3</example>
                public string? ListExecutor { get; set; }

                /// <summary>
                /// Có phải thuê sửa ngoài?
                /// </summary>
                /// <example>1</example>
                public int? IsOutsourceRepair { get; set; }

                /// <summary>
                /// THÔNG TIN BẢO HIỂM CHI TRẢ
                /// </summary>
                public List<Insurances> Insurances { get; set; }

                /// <summary>
                /// CHI PHÍ SỬA CHỮA
                /// </summary>
                public List<Outsources> Outsources { get; set; }

                /// <summary>
                /// THÔNG TIN CỨU XE BÊN NGOÀI
                /// </summary>
                public List<Rescues> Rescues { get; set; }

                /// <summary>
                /// THÔNG TIN CÔNG VIỆC VÀ VẬT TƯ
                /// </summary>
                public List<Supplies> Supplies { get; set; }

                /// <summary>
                /// THÔNG TIN Sửa chữa ngoài
                /// </summary>
                public List<Repairs> Repairs { get; set; }
            }

            public class Complete : GetByID
            {
                /// <summary>
                /// Tình trạng bàn giao/thu hồi
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Tình trạng bàn giao/thu hồi
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? UnfinishNote { get; set; }

                /// <summary>
                /// Số km bàn giao
                /// </summary>
                /// <example>24000</example>
                public decimal HandedOverkm { get; set; }

                /// <summary>
                /// Chi chú
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? Note { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// Mã bảo trì
                /// </summary>
                /// <example>XLBD/23/04/006</example>
                public string? MaintenanceOID { get; set; }

                /// <summary>
                /// Mã sự cố
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? IncidentID { get; set; }
            }

            public class AddNoDriver
            {
                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>51</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Mã sự cố
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public int? IncidentID { get; set; }
            }

            public class Prices
            {
                /// <summary>
                /// Mã vật tư
                /// </summary>
                /// <example>48</example>
                public string? MaintenanceSuppliesID { get; set; }
            }
        }
    }
}