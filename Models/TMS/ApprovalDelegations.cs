namespace DMS.Models.TMS
{
    public class ApprovalDelegations
    {
        public static class Request
        {
            public class AddOrEdit
            {
                /// <summary>
                /// Mã định danh chứng từ hoặc phiếu cần duyệt
                /// </summary>
                /// <example>PCCO/23/05/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Ngày bắt đầu ủy quyền
                /// </summary>
                /// <example>2025-10-14T00:00:00</example>
                public DateTime StartDate { get; set; }

                /// <summary>
                /// Ngày kết thúc ủy quyền
                /// </summary>
                /// <example>2025-10-20T00:00:00</example>
                public DateTime EndDate { get; set; }

                /// <summary>
                /// Người đề xuất (UserID)
                /// </summary>
                /// <example>USR001</example>
                public string? RequestUserId { get; set; }

                /// <summary>
                /// Người duyệt thay thế (UserID)
                /// </summary>
                /// <example>USR002</example>
                public string? SubstituteUserId { get; set; }

                /// <summary>
                /// Nội dung đề xuất
                /// </summary>
                /// <example>Ủy quyền duyệt chứng từ PCCO tháng 10</example>
                public string? Content { get; set; }

                /// <summary>
                /// Link liên kết chi tiết chứng từ
                /// </summary>
                /// <example>http://example.com</example>
                public string? Link { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Thay mặt trong thời gian nghỉ phép</example>
                public string? Note { get; set; }

                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Mã trạng thái
                /// </summary>
                /// <example>0</example>
                public int? StatusID { get; set; }

                /// <summary>
                /// Mở rộng 1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// Mở rộng 2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }
                /// <summary>
                /// Mở rộng 3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }
                /// <summary>
                /// Mở rộng 4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }
                /// <summary>
                /// Mở rộng 5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }
                /// <summary>
                /// Mở rộng 6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }
                /// <summary>
                /// Mở rộng 7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }
                /// <summary>
                /// Mở rộng 8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }
                /// <summary>
                /// Mở rộng 9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }
                /// <summary>
                /// Mở rộng 10
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }
            }
            public class GetByID
            {
                ///<summary>
                /// ID
                /// </summary>
                /// <example></example>
                public int? ID { get; set; }
            }
            public class GetByOID
            {
                ///<summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>PCCO/23/05/001</example>
                public string? OID { get; set; }
            }
            public class Add : AddOrEdit
            {

            }
            public class Edit : AddOrEdit
            {
                ///<summary>
                /// ID
                /// </summary>
                /// <example></example>
                public int? ID { get; set; }
            }
            public class Delete
            {
                ///<summary>
                /// ID
                /// </summary>
                /// <example></example>
                public int? ID { get; set; }
            }
        }
    }
}
