
namespace DMS.Models.DMS.Media
{
    public class PostModel
    {
        #region Request
        public class Request
        {
            public class Get
            {
                /// <summary>
                /// Loại danh mục bài viết
                /// </summary>
                /// <example>Posts</example>
                public string? CategoryType { get; set; }
            }

            /// <summary>
            /// Model cho request lấy bài viết theo ID
            /// </summary>
            public class GetByID
            {
                /// <summary>
                /// ID bài viết cần lấy thông tin
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {

                /// <summary>
                /// Islock
                /// </summary>
                /// <example>1</example>
                public int? Islock { get; set; }
            }

            /// <summary>
            /// Model cho nội dung bài viết
            /// </summary>
            public class Content
            {

                /// <summary>
                /// Loại danh mục của bài viết
                /// </summary>
                /// <example>Posts</example>
                public string? CategoryType { get; set; }

                /// <summary>
                /// Đường dẫn hình ảnh đại diện
                /// </summary>
                /// <example>/images/posts/example.jpg</example>
                public string? Avatar { get; set; } 

                /// <summary>
                /// Mã loại bài viết
                /// </summary>
                /// <example>4924</example>
                public int? PostTypeID { get; set; }

                /// <summary>
                /// Thứ tự sắp xếp
                /// </summary>
                /// <example>10</example>
                public int? Sort { get; set; }

                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Mã code duy nhất của bài viết
                /// </summary>
                /// <example>HETHONGCHIEUSANGTHONGMINH</example>
                public string? Code { get; set; }

                /// <summary>
                /// Mã định danh phụ
                /// </summary>
                /// <example>LEMON123</example>
                public string? LemonID { get; set; } 

                /// <summary>
                /// Từ khóa tìm kiếm
                /// </summary>
                /// <example>chiếu sáng</example>
                public string? SearchKey { get; set; }

                /// <summary>
                /// Tags
                /// </summary>
                /// <example>LED</example>
                public List<string> Tags { get; set; }

                /// <summary>
                /// PostLink
                /// </summary>
                /// <example>chiếu sáng</example>
                public string? PostLink { get; set; }

                #region Title Fields
                /// <summary>
                /// Tiêu đề chính của bài viết
                /// </summary>
                /// <example>Hệ thống chiếu sáng thông minh</example>
                public string? Title { get; set; } 

                /// <summary>
                /// Tiêu đề mở rộng 1
                /// </summary>
                /// <example>Smart Lighting System</example>
                public string? TitleExtention1 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 2
                /// </summary>
                /// <example>Sistema de iluminación inteligente</example>
                public string? TitleExtention2 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 3
                /// </summary>
                public string? TitleExtention3 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 4
                /// </summary>
                public string? TitleExtention4 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 5
                /// </summary>
                public string? TitleExtention5 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 6
                /// </summary>
                public string? TitleExtention6 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 7
                /// </summary>
                public string? TitleExtention7 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 8
                /// </summary>
                public string? TitleExtention8 { get; set; }

                /// <summary>
                /// Tiêu đề mở rộng 9
                /// </summary>
                public string? TitleExtention9 { get; set; }
                #endregion

                #region Short Content Fields
                /// <summary>
                /// Nội dung tóm tắt của bài viết
                /// </summary>
                /// <example>Giới thiệu về hệ thống chiếu sáng thông minh và các tính năng chính...</example>
                public string? ShortContent { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 1
                /// </summary>
                public string? ShortContentExtention1 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 2
                /// </summary>
                public string? ShortContentExtention2 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 3
                /// </summary>
                public string? ShortContentExtention3 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 4
                /// </summary>
                public string? ShortContentExtention4 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 5
                /// </summary>
                public string? ShortContentExtention5 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 6
                /// </summary>
                public string? ShortContentExtention6 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 7
                /// </summary>
                public string? ShortContentExtention7 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 8
                /// </summary>
                public string? ShortContentExtention8 { get; set; }

                /// <summary>
                /// Nội dung tóm tắt mở rộng 9
                /// </summary>
                public string? ShortContentExtention9 { get; set; } 
                #endregion

                #region Full Content Fields
                /// <summary>
                /// Nội dung đầy đủ của bài viết
                /// </summary>
                /// <example>Nội dung chi tiết về hệ thống chiếu sáng thông minh...</example>
                public string? FullContent { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 1
                /// </summary>
                public string? FullContentExtention1 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 2
                /// </summary>
                public string? FullContentExtention2 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 3
                /// </summary>
                public string? FullContentExtention3 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 4
                /// </summary>
                public string? FullContentExtention4 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 5
                /// </summary>
                public string? FullContentExtention5 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 6
                /// </summary>
                public string? FullContentExtention6 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 7
                /// </summary>
                public string? FullContentExtention7 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 8
                /// </summary>
                public string? FullContentExtention8 { get; set; }

                /// <summary>
                /// Nội dung đầy đủ mở rộng 9
                /// </summary>
                public string? FullContentExtention9 { get; set; }
                #endregion

                #region Extension Fields
                /// <summary>
                /// Trường mở rộng 1
                /// </summary>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Trường mở rộng 2
                /// </summary>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Trường mở rộng 3
                /// </summary>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Trường mở rộng 4
                /// </summary>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Trường mở rộng 5
                /// </summary>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Trường mở rộng 6
                /// </summary>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Trường mở rộng 7
                /// </summary>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Trường mở rộng 8
                /// </summary>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Trường mở rộng 9
                /// </summary>
                public string? Extention9 { get; set; } 

                /// <summary>
                /// Trường mở rộng 10
                /// </summary>
                public string? Extention10 { get; set; } 
                #endregion

                #region Status and Meta Fields
                /// <summary>
                /// Trạng thái kích hoạt của bài viết
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; } = 1;

                /// <summary>
                /// Ghi chú về bài viết
                /// </summary>
                /// <example>Quan trọng lắm</example>
                public string? Note { get; set; }

                /// <summary>
                /// ID người dùng hiện tại
                /// </summary>
                /// <example>4142</example>
                public string? UserIDCurent { get; set; }

                /// <summary>
                /// Mã ứng dụng
                /// </summary>
                /// <example>NLT_GROUP</example>
                public string? AppCode { get; set; }

                /// <summary>
                /// Số trang hiện tại
                /// </summary>
                /// <example>1</example>
                public int? PageNumber { get; set; } = 1;

                /// <summary>
                /// Số bài viết trên mỗi trang
                /// </summary>
                /// <example>3</example>
                public int? PageSizePost { get; set; } = 3;

                /// <summary>
                /// Kiểu lấy dữ liệu
                /// </summary>
                /// <example>NewCreate</example>
                public string? TypeGet { get; set; }
                #endregion
            }
            public class Edit : Content
            {
                public int? ID { get; set; }
            }
        }


        #endregion

        #region Response
        public class Response
        {
            /// <summary>
            /// Mã lỗi
            /// </summary>
            /// <example>0</example>
            public string? ErrorCode { get; set; }

            /// <summary>
            /// Mô tả lỗi
            /// </summary>
            public string? ErrorDescription { get; set; }

            /// <summary>
            /// Dữ liệu trả về
            /// </summary>
            public object Data { get; set; }
        }
        #endregion
    }
}