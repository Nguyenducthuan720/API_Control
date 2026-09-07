namespace APISmartCity.Models.TMS
{
    public static class RequestVehicles
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>RQ_Eviction_Vehicle</example>
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
                /// Mã lái xe
                /// </summary>
                /// <example>3</example>
                public string? DriverID { get; set; }

                /// <summary>
                /// Mã loại xe
                /// </summary>
                /// <example>542</example>
                public int? TransportTypeID { get; set; }

                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>11725-51D</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Biển số xe đầu kéo
                /// </summary>
                /// <example>11725-51D</example>
                public string? VehicleLicensePlates { get; set; }

                /// <summary>
                /// Dự kiến thời gian giao
                /// </summary>
                /// <example>2023-03-20 12:00</example>
                public string? ExpectedTime { get; set; }

                /// <summary>
                /// Có phải là lái xe đã rời công ty?
                /// </summary>
                /// <example>1</example>
                public int? IsOutCmpn { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }
                /// <summary>
                /// Chọn tiêu chí kho
                /// </summary>
                /// <example>0</example>
                public int? WarehouseID { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>RQ_Eviction_Vehicle</example>
                public string? EntryID { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// Đang dùng
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }


            public class Submit : Del
            {
                /// <summary>
                /// Đang dùng
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }

            public class Del : GetByID
            {
            }
        }
    }
}