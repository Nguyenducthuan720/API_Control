namespace APISmartCity.Models.TMS
{
    public static class DataBeginStartsVehicle
    {
        public static class Request
        {
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
                /// <example>Data_DateMooc</example>
                public string? EntryID { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2023-03-20</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>Link</example>
                public string? Link { get; set; }

                /// <summary>
                /// Danh sách xe
                /// </summary>
                public List<Details> Details { get; set; }
            }

            public class Details
            {
                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>51H-435.34</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Số km chốt dầu
                /// </summary>
                /// <example>1</example>
                public int? GasLastKm { get; set; }

                /// <summary>
                /// Số dầu tồn
                /// </summary>
                /// <example>1.00</example>
                public decimal GasLastQuantity { get; set; }

                /// <summary>
                /// Số km bảo trì
                /// </summary>
                /// <example>1</example>
                public int? MaintenanceLastKm { get; set; }

                /// <summary>
                /// Chu kỳ bảo trì/bảo dưỡng
                /// </summary>
                /// <example>1</example>
                public int? MaintenanceCycle { get; set; }

                /// <summary>
                /// Ngày đăng kiểm
                /// </summary>
                /// <example>2023-03-20</example>
                public string? RegisToDate { get; set; }

                /// <summary>
                /// Ngày gia hạn giấy tờ ngân hàng
                /// </summary>
                /// <example>2023-03-20</example>
                public string? BankToDate { get; set; }

                /// <summary>
                /// Ngày bảo hiểm
                /// </summary>
                /// <example>2023-03-20</example>
                public string? InsureToDate { get; set; }

                /// <summary>
                /// Ngày Gia hạn phí bảo trì đường bộ
                /// </summary>
                /// <example>2023-03-20</example>
                public string? MaintenanceToDate { get; set; }

                /// <summary>
                /// Ngày gia hạn Phù hiệu phương tiện
                /// </summary>
                /// <example>2023-03-20</example>
                public string? BadgeToDate { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>Data_DateMooc</example>
                public string? EntryID { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Đang dùng
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// Đang dùng
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit : Del
            {
                /// <summary>
                /// Đang dùng
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