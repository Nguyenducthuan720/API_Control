using System;

namespace APIMain.Models
{
    public class PostModel
    {
        /// <summary>
        /// Loại thao tác với bài viết
        /// </summary>
        /// <example>GET-ACTIVE</example>
        public string? Type { get; set; } = "GET-ACTIVE";  // Operation type for the post

        /// <summary>
        /// Mã ngôn ngữ của bài viết
        /// </summary>
        /// <example>vn</example>
        public string? Language { get; set; } = "vn";      // Language code (e.g., vn for Vietnamese)

        /// <summary>
        /// Mã định danh duy nhất của bài viết
        /// </summary>
        /// <example>3027</example>
        public int? ID { get; set; }                       // Unique identifier for the post

        /// <summary>
        /// Loại danh mục của bài viết
        /// </summary>
        /// <example>Post</example>
        public string? CategoryType { get; set; } = "Post"; // Type of category (e.g., Post, News, etc.)

        /// <summary>
        /// Đường dẫn hình ảnh đại diện
        /// </summary>
        /// <example>/images/posts/example.jpg</example>
        public string? Avatar { get; set; }                // URL or path to post's avatar/image

        /// <summary>
        /// Mã loại bài viết
        /// </summary>
        /// <example>4924</example>
        public string? PostTypeID { get; set; }            // Type ID of the post

        /// <summary>
        /// Thứ tự sắp xếp
        /// </summary>
        /// <example>10</example>
        public int? Sort { get; set; }                     // Sorting order

        /// <summary>
        /// Mã công ty
        /// </summary>
        /// <example>0</example>
        public string? CmpnID { get; set; }                // Company ID

        /// <summary>
        /// Mã code duy nhất của bài viết
        /// </summary>
        /// <example>HETHONGCHIEUSANGTHONGMINH</example>
        public string? Code { get; set; }                  // Unique code for the post

        /// <summary>
        /// Mã định danh phụ
        /// </summary>
        /// <example>LEMON123</example>
        public string? LemonID { get; set; }               // Additional identifier (Lemon ID)

        /// <summary>
        /// Từ khóa tìm kiếm
        /// </summary>
        /// <example>chiếu sáng</example>
        public string? SearchKey { get; set; }             // Search keyword

        #region Title Fields
        /// <summary>
        /// Tiêu đề chính của bài viết
        /// </summary>
        /// <example>Hệ thống chiếu sáng thông minh</example>
        public string? Title { get; set; }                 // Main title

        /// <summary>
        /// Tiêu đề mở rộng 1
        /// </summary>
        /// <example>Smart Lighting System</example>
        public string? TitleExtention1 { get; set; }       // Additional title field 1

        /// <summary>
        /// Tiêu đề mở rộng 2
        /// </summary>
        /// <example>Sistema de iluminación inteligente</example>
        public string? TitleExtention2 { get; set; }       // Additional title field 2

        /// <summary>
        /// Tiêu đề mở rộng 3
        /// </summary>
        public string? TitleExtention3 { get; set; }       // Additional title field 3

        /// <summary>
        /// Tiêu đề mở rộng 4
        /// </summary>
        public string? TitleExtention4 { get; set; }       // Additional title field 4

        /// <summary>
        /// Tiêu đề mở rộng 5
        /// </summary>
        public string? TitleExtention5 { get; set; }       // Additional title field 5

        /// <summary>
        /// Tiêu đề mở rộng 6
        /// </summary>
        public string? TitleExtention6 { get; set; }       // Additional title field 6

        /// <summary>
        /// Tiêu đề mở rộng 7
        /// </summary>
        public string? TitleExtention7 { get; set; }       // Additional title field 7

        /// <summary>
        /// Tiêu đề mở rộng 8
        /// </summary>
        public string? TitleExtention8 { get; set; }       // Additional title field 8

        /// <summary>
        /// Tiêu đề mở rộng 9
        /// </summary>
        public string? TitleExtention9 { get; set; }       // Additional title field 9
        #endregion

        #region Short Content Fields
        /// <summary>
        /// Nội dung tóm tắt của bài viết
        /// </summary>
        /// <example>Giới thiệu về hệ thống chiếu sáng thông minh và các tính năng chính...</example>
        public string? ShortContent { get; set; }          // Main short content/summary

        /// <summary>
        /// Nội dung tóm tắt mở rộng 1
        /// </summary>
        public string? ShortContentExtention1 { get; set; } // Additional short content 1

        /// <summary>
        /// Nội dung tóm tắt mở rộng 2
        /// </summary>
        public string? ShortContentExtention2 { get; set; } // Additional short content 2

        /// <summary>
        /// Nội dung tóm tắt mở rộng 3
        /// </summary>
        public string? ShortContentExtention3 { get; set; } // Additional short content 3

        /// <summary>
        /// Nội dung tóm tắt mở rộng 4
        /// </summary>
        public string? ShortContentExtention4 { get; set; } // Additional short content 4

        /// <summary>
        /// Nội dung tóm tắt mở rộng 5
        /// </summary>
        public string? ShortContentExtention5 { get; set; } // Additional short content 5

        /// <summary>
        /// Nội dung tóm tắt mở rộng 6
        /// </summary>
        public string? ShortContentExtention6 { get; set; } // Additional short content 6

        /// <summary>
        /// Nội dung tóm tắt mở rộng 7
        /// </summary>
        public string? ShortContentExtention7 { get; set; } // Additional short content 7

        /// <summary>
        /// Nội dung tóm tắt mở rộng 8
        /// </summary>
        public string? ShortContentExtention8 { get; set; } // Additional short content 8

        /// <summary>
        /// Nội dung tóm tắt mở rộng 9
        /// </summary>
        public string? ShortContentExtention9 { get; set; } // Additional short content 9
        #endregion

        #region Full Content Fields
        /// <summary>
        /// Nội dung đầy đủ của bài viết
        /// </summary>
        /// <example>Nội dung chi tiết về hệ thống chiếu sáng thông minh...</example>
        public string? FullContent { get; set; }           // Main full content

        /// <summary>
        /// Nội dung đầy đủ mở rộng 1
        /// </summary>
        public string? FullContentExtention1 { get; set; } // Additional full content 1

        /// <summary>
        /// Nội dung đầy đủ mở rộng 2
        /// </summary>
        public string? FullContentExtention2 { get; set; } // Additional full content 2

        /// <summary>
        /// Nội dung đầy đủ mở rộng 3
        /// </summary>
        public string? FullContentExtention3 { get; set; } // Additional full content 3

        /// <summary>
        /// Nội dung đầy đủ mở rộng 4
        /// </summary>
        public string? FullContentExtention4 { get; set; } // Additional full content 4

        /// <summary>
        /// Nội dung đầy đủ mở rộng 5
        /// </summary>
        public string? FullContentExtention5 { get; set; } // Additional full content 5

        /// <summary>
        /// Nội dung đầy đủ mở rộng 6
        /// </summary>
        public string? FullContentExtention6 { get; set; } // Additional full content 6

        /// <summary>
        /// Nội dung đầy đủ mở rộng 7
        /// </summary>
        public string? FullContentExtention7 { get; set; } // Additional full content 7

        /// <summary>
        /// Nội dung đầy đủ mở rộng 8
        /// </summary>
        public string? FullContentExtention8 { get; set; } // Additional full content 8

        /// <summary>
        /// Nội dung đầy đủ mở rộng 9
        /// </summary>
        public string? FullContentExtention9 { get; set; } // Additional full content 9
        #endregion

        #region Extension Fields
        /// <summary>
        /// Trường mở rộng 1
        /// </summary>
        public string? Extention1 { get; set; }            // Generic extension field 1

        /// <summary>
        /// Trường mở rộng 2
        /// </summary>
        public string? Extention2 { get; set; }            // Generic extension field 2

        /// <summary>
        /// Trường mở rộng 3
        /// </summary>
        public string? Extention3 { get; set; }            // Generic extension field 3

        /// <summary>
        /// Trường mở rộng 4
        /// </summary>
        public string? Extention4 { get; set; }            // Generic extension field 4

        /// <summary>
        /// Trường mở rộng 5
        /// </summary>
        public string? Extention5 { get; set; }            // Generic extension field 5

        /// <summary>
        /// Trường mở rộng 6
        /// </summary>
        public string? Extention6 { get; set; }            // Generic extension field 6

        /// <summary>
        /// Trường mở rộng 7
        /// </summary>
        public string? Extention7 { get; set; }            // Generic extension field 7

        /// <summary>
        /// Trường mở rộng 8
        /// </summary>
        public string? Extention8 { get; set; }            // Generic extension field 8

        /// <summary>
        /// Trường mở rộng 9
        /// </summary>
        public string? Extention9 { get; set; }            // Generic extension field 9

        /// <summary>
        /// Trường mở rộng 10
        /// </summary>
        public string? Extention10 { get; set; }           // Generic extension field 10
        #endregion

        #region Status and Meta Fields
        /// <summary>
        /// Trạng thái kích hoạt của bài viết
        /// </summary>
        /// <example>1</example>
        public int? IsActive { get; set; } = 1;            // Active status (1 = active, 0 = inactive)

        /// <summary>
        /// Ghi chú về bài viết
        /// </summary>
        /// <example>Quan trọng lắm</example>
        public string? Note { get; set; }                  // Notes or comments about the post

        /// <summary>
        /// ID người dùng hiện tại
        /// </summary>
        /// <example>4142</example>
        public string? UserIDCurent { get; set; }          // Current user ID

        /// <summary>
        /// Mã ứng dụng
        /// </summary>
        /// <example>NLT_GROUP</example>
        public string? AppCode { get; set; }               // Application code

        /// <summary>
        /// Số trang hiện tại
        /// </summary>
        /// <example>1</example>
        public int? PageNumber { get; set; } = 1;          // Page number for pagination

        /// <summary>
        /// Số bài viết trên mỗi trang
        /// </summary>
        /// <example>3</example>
        public int? PageSizePost { get; set; } = 3;        // Number of posts per page

        /// <summary>
        /// Kiểu lấy dữ liệu
        /// </summary>
        /// <example>NewCreate</example>
        public string? TypeGet { get; set; } = "NewCreate"; // Type of data retrieval
        #endregion
    }
} 