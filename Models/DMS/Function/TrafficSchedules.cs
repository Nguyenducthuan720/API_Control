namespace APISmartCity.Models.Ver2.Function
{
    public static class TrafficSchedules
    {
        public class CoreSchedule
        {
            /// <summary>
            /// Mã lịch điều khiển
            /// </summary>
            /// <example>LÐK/24/04/003</example>
            public string? OID { get; set; }
        }
        public class TreeNode
        {
            public string? Key { get; set; }
            public NodeData Data { get; set; }
            public List<TreeNode> Children { get; set; }

            // Thêm thuộc tính ID ở đây
            public string? ID => Data.ID;
            // Tạo một thuộc tính mới để kiểm tra xem nút này có phải là nút gốc không
            public bool IsRoot => Data.ParentID == "0";
        }

        public class NodeData
        {
            public string? ID { get; set; }
            public string? ParentID { get; set; }
            public int? NodeLevel { get; set; }
            public string? Name { get; set; }
            public int? IsSelected { get; set; }
            public int? totalPhase { get; set; }
            public int? totalDirection { get; set; }
            public List<Person> StationNodesJSON { get; set; }

        }
        public class Person
        {
            public string? Phase { get; set; }
            public string? DirectionName { get; set; }

        }
        public class TreeNodeDTO
        {
            public string? key { get; set; }
            public NodeData data { get; set; }
            public List<TreeNodeDTO> children { get; set; }
        }

        public class CoreStation
        {
            /// <summary>
            /// Mã lịch điều khiển
            /// </summary>
            /// <example>LÐK/24/04/003</example>
            public string? StationID { get; set; }
        }

        public class Add
        {
            /// <summary>
            /// Danh sách vùng, tủ điều khiển
            /// </summary>
            /// <example>L003</example>
            public List<string> StationList { get; set; }

            /// <summary>
            /// Lịch phase theo giờ
            /// </summary>
            public List<PhaseDetails> Details { get; set; }

            /// <summary>
            /// Loại lịch điều khiển
            /// </summary>
            /// <example>Lamp</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// Tên
            /// </summary>
            /// <example>Tên mặc định</example>
            /// 
            public string? Name { get; set; }

            /// <summary>
            /// SelectID
            /// </summary>
            /// <example>Tên mặc định</example>
            /// 
            public int? SelectID { get; set; }

            /// <summary>
            /// Tên 1
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention1 { get; set; }

            /// <summary>
            /// Tên 2
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention2 { get; set; }

            /// <summary>
            /// Tên 3
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention3 { get; set; }

            /// <summary>
            /// Tên 4
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention4 { get; set; }

            /// <summary>
            /// Tên 5
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention5 { get; set; }

            /// <summary>
            /// Tên 6
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention6 { get; set; }

            /// <summary>
            /// Tên 7
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention7 { get; set; }

            /// <summary>
            /// Tên 8
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention8 { get; set; }

            /// <summary>
            /// Tên 9
            /// </summary>
            /// <example>Default name</example>
            public string? NameExtention9 { get; set; }

            /// <summary>
            /// Chọn thứ hai
            /// </summary>
            /// <example>1</example>
            public int? T2 { get; set; }

            /// <summary>
            /// Chọn thứ ba
            /// </summary>
            /// <example>1</example>
            public int? T3 { get; set; }

            /// <summary>
            /// Chọn thứ tư
            /// </summary>
            /// <example>1</example>
            public int? T4 { get; set; }

            /// <summary>
            /// Chọn thứ năm
            /// </summary>
            /// <example>1</example>
            public int? T5 { get; set; }

            /// <summary>
            /// Chọn thứ sáu
            /// </summary>
            /// <example>1</example>
            public int? T6 { get; set; }

            /// <summary>
            /// Chọn thứ bảy
            /// </summary>
            /// <example>1</example>
            public int? T7 { get; set; }

            /// <summary>
            /// Chọn thứ bảy
            /// </summary>
            /// <example>1</example>
            public int? CN { get; set; }

            /// <summary>
            /// IsActive
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }

            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }

        public class PhaseDetails
        {
            /// <summary>
            /// Giờ (24h)
            /// </summary>
            /// <example>10</example>
            public int? Hour { get; set; }

            /// <summary>
            /// Phút
            /// </summary>
            /// <example>10</example>
            public int? Minute { get; set; }

            /// <summary>
            /// Loại điều khiển
            /// </summary>
            /// <example>1</example>
            public int? ControlMode { get; set; }

            /// <summary>
            /// Phút
            /// </summary>
            /// <example>10</example>
            public List<Phases> Details { get; set; }
        }

        public class Actions
        {
            /// <summary>
            /// Loại điều khiển
            /// </summary>
            /// <example>1</example>
            public string? StationID { get; set; }

            /// <summary>
            /// Loại điều khiển
            /// </summary>
            /// <example>3</example>
            public int? ControlMode { get; set; }

            /// <summary>
            /// Phút
            /// </summary>
            /// <example>10</example>
            public List<Phases> Details { get; set; }
        }

        public class Phases
        {
            /// <summary>
            /// Hướng
            /// </summary>
            /// <example>1</example>
            public int? STT { get; set; }

            /// <summary>
            /// Chỉ số phase
            /// </summary>
            public int? Period { get; set; }
        }

        public class Edit : Add
        {
            /// <summary>
            /// Mã lịch điều khiển
            /// </summary>
            /// <example>1</example>
            public string? OID { get; set; }
        }

        public class EditStatus : CoreSchedule
        {
            /// <summary>
            /// Trạng thái
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
        }

        public class Delete : CoreSchedule
        {
        }
    }
}