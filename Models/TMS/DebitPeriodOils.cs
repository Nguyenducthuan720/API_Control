using Org.BouncyCastle.Crypto.Macs;

namespace APISmartCity.Models.TMS
{
    public static class DebitPeriodOils
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>2023/03/05</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Kỳ hạn theo tháng
                /// </summary>
                /// <example>03/2023</example>
                public string? PeriodOfMonth { get; set; }

                /// <summary>
                /// từ ngày
                /// </summary>
                /// <example>2023-03-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// đến ngày
                /// </summary>
                /// <example>2023-03-31</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Mã đội xe
                /// </summary>
                /// <example>1</example>
                public string? VehicleGroupID { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>test</example>
                public string? Note { get; set; }
            }

            public class DebitPeriodOilsDetails
            {
                /// <summary>
                /// ID Details, khi load lên có ID thì truyền xuống ID lại, còn ko có thì mặc định = 0
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>11425-51D</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Mã tài xế
                /// </summary>
                /// <example>2</example>
                public int? DriverID { get; set; }
                public string TL { get; set; }

                public decimal? KmBefor { get; set; }
                public decimal? KmLast { get; set; }

                public decimal? KmRun { get; set; }

                public decimal? KmGPS { get; set; }
                public decimal? Oil_TT { get; set; }

                public decimal? Oil_BP { get; set; }
                public decimal? KmErrorAllow { get; set; }


            }

            public class Add : Content
            {
                /// <summary>
                /// Chi tiết danh sách lái xe
                /// </summary>
                public List<DebitPeriodOilsDetails> DebitPeriodOilsDetail { get; set; }
            }

            public class AddDetails
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>test</example>
                public string? Note { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class GetVehicleGroupID
            {
                /// <summary>
                /// Mã đội xe
                /// </summary>
                /// <example>21</example>
                public string? VehicleGroupID { get; set; }
            }

            public class Submit
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCTU/10/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class UploadFiles
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>1</example>
                public string? FileName { get; set; }

                /// <summary>
                /// Loại nội dung
                /// </summary>
                /// <example>ALL</example>
                public string? ContentType { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example></example>
                public string? FileLink { get; set; }

                /// <summary>
                /// Path
                /// </summary>
                /// <example></example>
                public string? FilePath { get; set; }
            }

            public class ContentBase64
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>icon.jpeg</example>
                public string? FileName { get; set; }

                /// <summary>
                /// Loại nội dung
                /// </summary>
                /// <example>image/jpeg</example>
                public string? ContentType { get; set; }

                /// <summary>
                /// Dữ liệu file dưới dạng base64 string
                /// </summary>
                /// <example></example>
                public string? Base64 { get; set; }
            }

            public class DrvierUdpdateDetails
            {
                /// <summary>
                /// ID Details
                /// </summary>
                /// <example>11</example>
                public int? ID { get; set; }

                /// <summary>
                /// Số km trên taplo của xe
                /// </summary>
                /// <example>10000</example>
                public int? KmDriver { get; set; }

                /// <summary>
                /// Note, Ghi chú nếu có
                /// </summary>
                /// <example>Nhập gì cũng đc</example>
                public string? Note { get; set; }

                /// <summary>
                /// Link file
                /// </summary>
                /// <example>File link upload</example>
                public string? LinkFile { get; set; }

                /// <summary>
                /// Danh sách hình ảnh dưới dạng base64 string
                /// </summary>
                /// <example></example>
                public List<ContentBase64> Base64s { get; set; }
            }
        }
    }
}