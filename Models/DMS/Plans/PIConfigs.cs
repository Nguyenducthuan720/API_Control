using static APISmartCity.Models.Ver2.PIConfigs.PIAllocations.Request;

namespace APISmartCity.Models.Ver2.PIConfigs;

public static class PIConfigs
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }

        public class AddPI : Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Plannings</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>PIConfigs</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }
            
            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2025-05-08</example>
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
            /// Tên kế hoạch (VI)
            /// </summary>
            /// <example></example>
            public string? Name { get; set; }

            /// <summary>
            /// Tên kế hoạch (EN)
            /// </summary>
            /// <example></example>
            public string? NameExtention1 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention2 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention3 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention4 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention5 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention6 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention7 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention8 { get; set; }

            /// <summary>
            /// Tên kế hoạch mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention9 { get; set; }

            /// <summary>
            /// Thời gian bắt đầu
            /// </summary>
            /// <example></example>
            public string? From { get; set; }

            /// <summary>
            /// Thời gian kết thúc
            /// </summary>
            /// <example></example>
            public string? To { get; set; }

            /// <summary>
            /// Phòng ban áp dụng
            /// </summary>
            /// <example></example>
            public int? DepartmentID { get; set; }

            /// <summary>
            /// Nhân viên áp dụng
            /// </summary>
            /// <example></example>
            public string? Positions { get; set; }

            /// <summary>
            /// Khu vực áp dụng
            /// </summary>
            /// <example></example>
            public string? Regions { get; set; }

            /// <summary>
            /// Nội dung mục tiêu
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// Áp dụng điều kiện thời gian chia nhỏ
            /// </summary>
            /// <example></example>
            public int? IsSplitTime { get; set; }

            /// <summary>
            /// Thời gian áp dụng
            /// </summary>
            /// <example></example>
            public string? WorkPeriods { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            /// <example>Link</example>
            public string? Link { get; set; }

            /// <summary>
            /// Tiêu chí công việc
            /// </summary>
            public List<AddDetail> Details { get; set; }

            /// <summary>
            /// Chi tiết phân công
            /// </summary>
            public List<AddPIAllocation> Allocations { get; set; }
        }
        
        public class AddDetail : Add
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
            /// Sản lượng/Giá trị
            /// </summary>
            /// <example>0</example>
            public int? Value { get; set; }
            
            /// <summary>
            /// Trọng số
            /// </summary>
            /// <example>1</example>
            public int? Weight { get; set; }

            /// <summary>
            /// Tỉ lệ vượt tối đa
            /// </summary>
            /// <example>1</example>
            public int? MaxOverRate { get; set; }

            /// <summary>
            /// Diễn giải
            /// </summary>
            /// <example></example>
            public string? Description { get; set; }
        }
        
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
    }
}