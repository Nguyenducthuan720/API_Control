namespace APISmartCity.Models.Categorys
{
    public static class Uploads
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã định danh
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }

                /// <summary>
                /// Lớp dữ liệu: Nhà hàng - GasRestaurent, Khu ăn uống - FoodCourt, Gia đình -
                /// GasFamily, Lighting - SLLamps, Cabin - SLCabinets, Cửa hàng - Stores
                /// </summary>
                /// <example>ALL</example>
                public string? Code { get; set; }
            }

            public class FormBase64s : GetByID
            {
                /// <summary>
                /// Danh sách hình ảnh đã mã hóa thành base64
                /// </summary>
                /// <example></example>
                public List<ContentBase64> Base64s { get; set; }
            }

            public class ContentBase64
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>1</example>
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

            public class FormFiles : GetByID
            {
                /// <summary>
                /// Danh sách files dưới dạng binary
                /// </summary>
                /// <example></example>
                public List<IFormFile> Files { get; set; }
            }

            public class ImportDatabase
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>1</example>
                public string? FileName { get; set; }

                /// <summary>
                /// Loại nội dung
                /// </summary>
                /// <example>image/jpeg</example>
                public string? ContentType { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

                /// <summary>
                /// Path
                /// </summary>
                /// <example></example>
                public string? Path { get; set; }
            }
        }

        public static class Response
        {
            public class Results
            {
                /// <summary>
                /// Tổng file upload
                /// </summary>
                /// <example></example>
                public int? TotalUpload { get; set; }

                /// <summary>
                /// Tổng file upload thành công
                /// </summary>
                /// <example></example>
                public int? TotalSuccess { get; set; }

                /// <summary>
                /// Danh sách file upload thành công
                /// </summary>
                /// <example></example>
                public List<SuccessInfos> SuccessInfos { get; set; }

                /// <summary>
                /// Tổng file upload thất bại
                /// </summary>
                /// <example></example>
                public int? TotalFailure { get; set; }

                /// <summary>
                /// Danh sách file upload thất bại
                /// </summary>
                /// <example></example>
                public List<FailureInfos> FailureInfos { get; set; }
            }

            public class SuccessInfos
            {
                /// <summary>
                /// Danh sách file upload thành công
                /// </summary>
                /// <example></example>
                /// A
                public string? FileName { get; set; }

                /// <summary>
                /// Danh sách file upload thành công
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }
            }

            public class FailureInfos
            {
                /// <summary>
                /// Danh sách file upload thành công
                /// </summary>
                /// <example></example>
                public string? FileName { get; set; }

                /// <summary>
                /// Danh sách file upload thành công
                /// </summary>
                /// <example></example>
                public string? Description { get; set; }
            }
        }
    }
}