namespace DMS.Models.Plans;

public static class ExhibitionExtensions
{
    public static class Request
    {
      
        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }
        public class Del : GetByOID
        {
        }
        public class Extend : GetByOID
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>0</example>
            public string? FactorID { get; set; }
            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>0</example>
            public string? EntryID { get; set; }
            /// <summary>
            /// ODate
            /// </summary>
            /// <example></example>
            public string? ODate { get; set; }
           
            /// <summary>
            /// Reference
            /// </summary>
            /// <example>0</example>
            public string? ReferenceID { get; set; }
            /// <summary>
            /// Câu hỏi
            /// </summary>
            /// <example>0</example>
            public string? ToDate { get; set; }

            /// <summary>
            /// Loại lý do gia hạn
            /// </summary>
            /// <example></example>
            public int? ReasonTypeID { get; set; }

            /// <summary>
            /// Diễn giải lý do
            /// </summary>
            /// <example></example>
            public string? Reason { get; set; }

            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example></example>
            public string? Note { get; set; }
            /// <summary>
            /// Hình ảnh
            /// </summary>
            /// <example></example>
            public string? Link { get; set; }
        }


    }
}