namespace APISmartCity.Models.TMS
{
    public static class ProcessDriverMaintenances
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

            public class Receives : GetByID
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

            public class Complete : GetByID
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? Note { get; set; }

                /// <summary>
                /// Tình trạng bàn giao/thu hồi
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Công việc chưa xử lý
                /// </summary>
                /// <example>Nhớt xe chưa thay</example>
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
            }

            public class Edit : GetByID
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? Note { get; set; }

                /// <summary>
                /// Tình trạng bàn giao/thu hồi
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Công việc chưa xử lý
                /// </summary>
                /// <example>Nhớt xe chưa thay</example>
                public string? UnfinishNote { get; set; }

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
                /// Số km bàn giao
                /// </summary>
                /// <example>24000</example>
                public decimal HandedOverkm { get; set; }

                /// <summary>
                /// Người thực hiện
                /// </summary>
                /// <example>1,2,3</example>
                public string? ListExecutor { get; set; }
            }

            public class Receive : GetByID
            {
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
                /// Dự kiến thời gian giao
                /// </summary>
                /// <example>2023-03-20 12:00</example>
                public string? ExpectedTime { get; set; }
            }

            public class BeforeReceive : GetByID
            {
                /// <summary>
                /// Dự kiến tiếp nhận
                /// </summary>
                /// <example>2023/04/13 11:00</example>
                public string? ReceiveExpectedTime { get; set; }
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
            public class UpdateExpectTime : GetByID
            {
                /// <summary>
                /// Ghi chú lý do
                /// </summary>
                /// <example>2023-02-24</example>
                public string? Note { get; set; }

                /// <summary>
                /// Dự kiến hoàn thành
                /// </summary>
                /// <example>2023/04/13 11:00</example>
                public string? ExpectedTime { get; set; }
            }

            public class Details
            {
                /// <summary>
                /// Số thứ tự
                /// </summary>
                /// <example>51</example>
                public int? STT { get; set; }

                /// <summary>
                /// Số lượng
                /// </summary>
                /// <example>48</example>
                public float ItemQuantity { get; set; }
            }

            public class UpdateQuantity : GetByID
            {
                /// <summary>
                /// Danh sách vật tư
                /// </summary>
                public List<Details> Details { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>51</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Số km hiện tại
                /// </summary>
                /// <example>0</example>
                public int? CurrentKm { get; set; }
            }
        }
    }
}