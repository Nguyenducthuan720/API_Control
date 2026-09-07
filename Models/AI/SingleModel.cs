using System;
using System.ComponentModel.DataAnnotations;

namespace DMS.Models.AI
{
    public class SingleModel
    {
        #region Request
        public class Request
        {
            /// <summary>
            /// Model cho request lấy danh sách single
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
            /// Model cho request lấy thông tin single theo ID
            /// </summary>
            public class GetByID
            {
                /// <summary>
                /// ID single cần lấy
                /// </summary>
                public int? ID { get; set; }
            }

            /// <summary>
            /// Model cho request thêm mới single
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
                /// Loại single
                /// </summary>
                public string? SingleType { get; set; }

                /// <summary>
                /// Nội dung single
                /// </summary>
                public string? SingleMessage { get; set; }
            }

            /// <summary>
            /// Model cho request xóa single
            /// </summary>
            public class Del
            {
                /// <summary>
                /// ID single cần xóa
                /// </summary>
                public int? ID { get; set; }
            }

            /// <summary>
            /// Model cho request nội dung single
            /// </summary>
            public class Content
            {
                /// <summary>
                /// ID single
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Nội dung single
                /// </summary>
                public string? SingleContent { get; set; }
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