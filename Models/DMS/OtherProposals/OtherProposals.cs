namespace DMS.Models.DMS.OtherProposals
{
    public class OtherProposals
    {
        public class Request
        {
            public class Add
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>OtherProposal</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>SONormals</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }

                /// <summary>
                /// ODate
                /// </summary>
                /// <example>2025-05-23</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Loại chứng từ
                /// </summary>
                public int? DocumentTypeID { get; set; }

                /// <summary>
                /// Số chứng từ
                /// </summary>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Lý do đề xuất
                /// </summary>
                /// <example></example>
                public int? ReasonID { get; set; }

                /// <summary>
                /// Gia hạn đến ngày
                /// </summary>
                /// <example></example>
                public string? ExtendDate { get; set; }

                /// <summary>
                /// Diễn giải lý do
                /// </summary>
                /// <example></example>
                public string? Reason { get; set; }

                /// <summary>
                /// Diễn giải đề xuất
                /// </summary>
                /// <example></example>
                public string? Proposal { get; set; }

                /// <summary>
                /// Bộ phận yêu cầu xử lý/hỗ trợ
                /// </summary>
                /// <example></example>
                public int? DepartmentID { get; set; }

                /// <summary>
                /// Nhân viên phụ trách
                /// </summary>
                /// <example></example>
                public int? ResponsibleUser { get; set; }

                /// <summary>
                /// Hạn xử lý
                /// </summary>
                /// <example></example>
                public string? ProcessingDeadline { get; set; }

                /// <summary>
                /// Nội dung yêu cầu
                /// </summary>
                /// <example></example>
                public string? RequestContent { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }

                /// <summary>
                /// Tệp đính kèm
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention11 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention12 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention13 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention14 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention15 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention16 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention17 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention18 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention19 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention20 { get; set; }
            }
            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
            }

            public class GetByOID
            {
                public string? OID { get; set; }
            }

            public class GetActive
            {
                public string? EntryID { get; set; }
            }

            public class Del : GetByOID
            {
            }
        }
    }
}
