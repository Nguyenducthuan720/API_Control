using static APISmartCity.Models.Ver2.Function.SchedulesGenerals;

namespace APISmartCity.Models.Ver2.Function
{
    public static class SchedulesGenerals
    {
        public class RequestOID
        {
            /// <summary>
            /// Mã lịch điều khiển
            /// </summary>
            /// <example>LÐK/24/04/003</example>
            public string? OID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>SmartMonitor</example>
            public string? EntryID { get; set; }

        }

        public class RequestEntryID
        {
            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>SmartMonitor</example>
            public string? EntryID { get; set; }
        }



        public class Add
        {
            /// <summary>
            /// Danh sách vùng, tủ điều khiển
            /// </summary>
            /// <example>L003</example>
            public List<string> StationList { get; set; }

            /// <summary>
            /// Loại lịch điều khiển
            /// </summary>
            /// <example>SmartMonitor</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// Loại lịch điều khiển
            /// </summary>
            /// <example>2024/06/26</example>
            public string? Odate { get; set; }

            /// <summary>
            /// Tên
            /// </summary>
            /// <example>Tên mặc định</example>
            public string? Name { get; set; }

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
            /// Mã lịch, 1: 1 lần, 2: theo lịch tuần
            /// </summary>
            /// <example>1</example>
            public int? SelectID { get; set; }

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
            /// Mã điều khiển đèn
            /// </summary>
            /// <example>3</example>
            public int? ActionID { get; set; }

            /// <summary>
            /// IsActive
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention1 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention2 { get; set; }


            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention3 { get; set; }

            /// <summary>
            /// TMở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention4 { get; set; }


            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention5 { get; set; }


            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention6 { get; set; }


            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention7 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention8 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention9 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example>Mở rộng</example>
            public string? Extention10 { get; set; }

            /// <summary>
            /// Json table details
            /// </summary>
            /// <example>Mở rộng</example>
            public string? DataDetail { get; set; }

            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }

        public class Edit : Add
        {
            /// <summary>
            /// Mã lịch điều khiển
            /// </summary>
            /// <example>1</example>
            public string? OID { get; set; }
        }

        public class EditStatus : RequestOID
        {
            /// <summary>
            /// Trạng thái
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
        }

        public class Delete : RequestOID
        {
        }
    }
}