using DocumentFormat.OpenXml.Wordprocessing;
using static APISmartCity.Models.Systems.Default.Request;

namespace APISmartCity.Models.TMS
{
    public class Documents
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// Mã tài liệu (DOC-001)
                /// </summary>
                public string? DocumentCode { get; set; }

                /// <summary>
                /// Nội dung mô tả tài liệu
                /// </summary>
                public string? DocumentContent { get; set; }

                /// <summary>
                /// Loại tài liệu (DocumentType)
                /// </summary>
                public int DocumentTypeID { get; set; }
                /// <summary>
                /// Loại tài liệu (DocumentType)
                /// </summary>
                public int DocumentDetailTypeID { get; set; }

                /// <summary>
                /// Phòng ban ban hành
                /// </summary>
                public int DepartmentID { get; set; }

                /// <summary>
                /// Ngày hiệu lực
                /// </summary>
                public DateTime FromEffectiveDate { get; set; }

                /// <summary>
                /// Ngày hiệu lực
                /// </summary>
                public DateTime ToEffectiveDate { get; set; }

                /// <summary>
                /// Link file
                /// </summary>
                public string? Link { get; set; }

                /// <summary>
                /// Kiểu hiển thị (Public / Cá nhân / Đồng đội)
                /// </summary>
                public int ShowTypeID { get; set; }

                /// <summary>
                /// Danh sách phòng ban được xem (1,2,3)
                /// </summary>
                public string? PermissionDepartmentID { get; set; }
                /// <summary>
                /// Danh sách User được xem (1,2,3)
                /// </summary>
                public string? PermissionUserID { get; set; }
                //public string? Note { get; set; }

            }
             
            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
 
            public class Del
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class Get
            {
                public string? FromDate { get; set; }
                public string? ToDate { get; set; }
            }

                
            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }
             
 
        }
    }
}