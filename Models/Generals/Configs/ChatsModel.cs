using System;
using System.ComponentModel.DataAnnotations;

namespace DMS.Models.Generals.Configs
{
    public class ChatsModel
    {
        #region Request
        public class Request
        {
            /// <summary>
            /// Model cho request lấy danh sách chat
            /// </summary>
            public class Get
            {
                /// <summary>
                /// ID yếu tố
                /// </summary>
                public string? FactorID { get; set; }

                /// <summary>
                /// ID entry
                /// </summary>
                public string? EntryID { get; set; }

                /// <summary>
                /// ID đối tượng
                /// </summary>
                public string? OID { get; set; }
            }

            /// <summary>
            /// Model cho request lấy thông tin chat theo ID
            /// </summary>
            public class GetByID
            {
                /// <summary>
                /// ID chat cần lấy
                /// </summary>
                public int? ID { get; set; }
            }

            /// <summary>
            /// Model cho request thêm mới chat
            /// </summary>
            public class Add
            {
                /// <summary>
                /// ID yếu tố
                /// </summary>
                public string? FactorID { get; set; }

                /// <summary>
                /// ID entry
                /// </summary>
                public string? EntryID { get; set; }

                /// <summary>
                /// ID đối tượng
                /// </summary>
                public string? OID { get; set; }

                /// <summary>
                /// ID người dùng
                /// </summary>
                public int? UserID { get; set; }

                /// <summary>
                /// Loại chat
                /// </summary>
                public string? ChatType { get; set; }

                /// <summary>
                /// Nội dung tin nhắn
                /// </summary>
                public string? ChatMessage { get; set; }
            }

            /// <summary>
            /// Model cho request xóa chat
            /// </summary>
            public class Del
            {
                /// <summary>
                /// ID chat cần xóa
                /// </summary>
                public int? ID { get; set; }
            }
        }
        #endregion

        #region Response
        public class Response
        {
            public string? ErrorCode { get; set; }
            public string? ErrorDescription { get; set; }
            public object Data { get; set; }
        }
        #endregion
    }
} 