namespace DMS.Models.DMS.Plans
{
    public class PIEvaluations
    {
        public static class Request
        {
            public class Add : GetByOID
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }
            }
            public class AddPIEvaluation : Add
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>Plannings</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>PIEvaluations</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2025-03-25</example>
                public string? ODate { get; set; }

                /// <summary>
                /// SAPID
                /// </summary>
                /// <example></example>
                public string? SAPID { get; set; }

                /// <summary>
                /// LemonID
                /// </summary>
                /// <example></example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Kế hoạch PI
                /// </summary>
                /// <example></example>
                public string? PIConfigID { get; set; }

                /// <summary>
                /// Tệp đính kèm
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

                /// <summary>
                /// Danh sách đánh giá
                /// </summary>
                public List<AddEvaluation> Evaluations { get; set; }
            }

            public class AddEvaluation
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example></example>
                public int? ID { get; set; }

                /// <summary>
                /// Mã nhân viên
                /// </summary>
                /// <example></example>
                public int? UserID { get; set; }

                /// <summary>
                /// Thời gian áp dụng
                /// </summary>
                public string? Month { get; set; }

                /// <summary>
                /// Tỉ lệ thực hiện
                /// </summary>
                /// <example>100</example>
                public decimal PerformanceRate { get; set; }

                /// <summary>
                /// Đánh giá
                /// </summary>
                /// <example>1</example>
                public int? Evaluation { get; set; }

                /// <summary>
                /// Chi tiết đánh giá
                /// </summary>
                public List<AddEvaluationDetail> Details { get; set; }
            }

            public class AddEvaluationDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example></example>
                public int? ID { get; set; }

                /// <summary>
                /// Tiêu chí đánh giá
                /// </summary>
                /// <example></example>
                public int? WorkCriteriaID { get; set; }

                /// <summary>
                /// Phân công
                /// </summary>
                /// <example>100</example>
                public decimal AssignedValue { get; set; }

                /// <summary>
                /// Thực hiện
                /// </summary>
                /// <example>100</example>
                public decimal PerformanceValue { get; set; }

                /// <summary>
                /// Tỉ lệ thực hiện
                /// </summary>
                /// <example>100</example>
                public decimal PerformanceRate { get; set; }

                /// <summary>
                /// Đánh giá
                /// </summary>
                /// <example>1</example>
                public int? Evaluation { get; set; }
            }

            public class GetPI
            {
                /// <summary>
                /// Kế hoạch PI
                /// </summary>
                /// <example></example>
                public string? PIConfigID { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example></example>
                public string? OID { get; set; }
            }

            public class Submit : GetByOID
            {
                public int? IsLock { get; set; }
            }

            public class Del : GetByOID
            {
            }
        }
    }
}
