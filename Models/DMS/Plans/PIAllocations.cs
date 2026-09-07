namespace APISmartCity.Models.Ver2.PIConfigs;

public static class PIAllocations
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example></example>
            public string? Note { get; set; }
        }
        
        public class AddPIAllocation : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }

            /// <summary>
            /// Thời gian áp dụng
            /// </summary>
            /// <example></example>
            public string? Month { get; set; }

            /// <summary>
            /// ID nhân viên
            /// </summary>
            /// <example></example>
            public int? UserID { get; set; }

            /// <summary>
            /// Tiêu chí
            /// </summary>
            /// <example></example>
            public List<AddAllocationDetail> Details { get; set; }
        }

        public class AddProposal
        {
            /// <summary>
            /// ID phân công
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }

            /// <summary>
            /// Tiêu chí
            /// </summary>
            /// <example></example>
            public List<AddAllocationDetail> Details { get; set; }
        }
        
        public class AddAllocationDetail
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }

            /// <summary>
            /// Tiêu chí công việc
            /// </summary>
            /// <example></example>
            public int? WorkCriteriaID { get; set; }

            /// <summary>
            /// Sản lượng/Giá trị được giao
            /// </summary>
            /// <example>0</example>
            public int? AssignedValue { get; set; }

            /// <summary>
            /// Sản lượng/Giá trị đề xuất
            /// </summary>
            /// <example>0</example>
            public int? ProposalValue { get; set; }

            /// <summary>
            /// Lý do đề xuất
            /// </summary>
            /// <example>0</example>
            public string? Reason { get; set; }

            /// <summary>
            /// Đề xuất kế hoạch
            /// </summary>
            public List<AddDetailPlan> Plans { get; set; }
        }

        public class AddDetailPlan
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }

            /// <summary>
            /// Từ ngày
            /// </summary>
            /// <example></example>
            public string? FromDate { get; set; }

            /// <summary>
            /// Đến ngày
            /// </summary>
            /// <example></example>
            public string? ToDate { get; set; }

            /// <summary>
            /// Công việc thực hiện
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// Chi phí dự kiến
            /// </summary>
            /// <example></example>
            public decimal Value { get; set; }
        }

        public class Submit : GetByID
        {
            public int? IsLock { get; set; }
        }

        public class GetByID
        {
            public int? ID { get; set; }
        }

        public class Del : GetByID
        {
        }
    }
}