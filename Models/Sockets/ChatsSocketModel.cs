using System;
using System.ComponentModel.DataAnnotations;

namespace DMS.Models.Sockets
{
    public class ChatsSocketModel
    {
        #region Request
        public class Request
        {
            /// <summary>
            /// Model cho request kết nối socket
            /// </summary>
            public class Connect
            {
                /// <summary>
                /// ID người dùng
                /// </summary>
                public int? UserID { get; set; }

                /// <summary>
                /// ID công ty
                /// </summary>
                public string? CmpnID { get; set; }

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
            /// Model cho request gửi tin nhắn
            /// </summary>
            public class SendMessage
            {
                /// <summary>
                /// ID người dùng
                /// </summary>
                public int? UserID { get; set; }

                /// <summary>
                /// UserName
                /// </summary>
                public string? UserName { get; set; }

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
                /// Loại tin nhắn
                /// </summary>
                public string? ChatType { get; set; }

                /// <summary>
                /// Nội dung tin nhắn
                /// </summary>
                public string? ChatMessage { get; set; }
            }

            /// <summary>
            /// Model cho request ngắt kết nối
            /// </summary>
            public class Disconnect
            {
                /// <summary>
                /// ID người dùng
                /// </summary>
                public int? UserID { get; set; }

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