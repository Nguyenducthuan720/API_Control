namespace APISmartCity.Models.TMS
{
    public static class MaintenanceAllowances
    {
        public static class Request
        {
            public class MaintenanceAllowancesPeriod
            {
                /// <summary>
                /// Số chu kỳ
                /// </summary>
                /// <example>1</example>
                public int? STT { get; set; }

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
                /// Số km theo chu kỳ
                /// </summary>
                /// <example>1</example>
                public decimal KmOfPeriod { get; set; }

                /// <summary>
                /// Dung sai
                /// </summary>
                /// <example>1</example>
                public decimal Deviant { get; set; }
            }

            public class MaintenanceAllowancesWork
            {
                /// <summary>
                /// Kỳ bảo dưỡng
                /// </summary>
                /// <example>1</example>
                public int? Period { get; set; }

                /// <summary>
                /// Số TT
                /// </summary>
                /// <example>1</example>
                public int? STT { get; set; }

                /// <summary>
                /// Mã công việc bảo dưỡng
                /// </summary>
                /// <example>1</example>
                public int? MaintenanceJobsID { get; set; }

                /// <summary>
                /// Mã vật tư
                /// </summary>
                /// <example>1146</example>
                public int? ItemID { get; set; }

                /// <summary>
                /// Số lượng vật tư
                /// </summary>
                /// <example>2</example>
                public decimal ItemQuantity { get; set; }

                /// <summary>
                /// Số giờ công
                /// </summary>
                /// <example>48</example>
                public decimal WorkQuantity { get; set; }

                /// <summary>
                /// Số lượng người bảo trì
                /// </summary>
                /// <example>0</example>
                public decimal PersonQuantity { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>RQ_COATTARP</example>
                public string? EntryID { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>1</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Mã loại xe
                /// </summary>
                /// <example>1</example>
                public int? VehicleTypeID { get; set; }

                /// <summary>
                /// Chi tiết kỳ bảo hành
                /// </summary>
                public List<MaintenanceAllowancesPeriod> MaintenanceAllowancesPeriods { get; set; }

                /// <summary>
                /// Chi tiết công việc bảo hành
                /// </summary>
                public List<MaintenanceAllowancesWork> MaintenanceAllowancesWorks { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                public string? Link { get; set; }

            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCC/18/11/22/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }


            public class Del : GetByID
            {
            }
        }
    }
}