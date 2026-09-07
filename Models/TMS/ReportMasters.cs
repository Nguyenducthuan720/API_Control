namespace APISmartCity.Models.TMS
{
    public static class ReportMasters
    {
        public static class Request
        {
            public class FindDate
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023-06-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2023-07-15</example>
                public string? ToDate { get; set; }
            }

            public class FindODate
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// ngày xem
                /// </summary>
                /// <example>2023-09-01</example>
                public string? Odate { get; set; }
            }

            public class FindDateByType : FindDate
            {
                /// <summary>
                /// Loại báo cáo
                /// </summary>
                /// <example>1</example>
                public string? Type { get; set; }

                /// <summary>
                /// Chi cho tài xế, 0 ko chi, 1 chi, 2 tất cả
                /// </summary>
                /// <example>1</example>
                public int? IsAddByDriver { get; set; }

                /// <summary>
                /// Lọc thêm đội xe 
                /// </summary>
                /// <example>607</example>
                public string? VehicleTeamID { get; set; }
            }

            public class FindDatePeriod
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Ký tháng/năm
                /// </summary>
                /// <example>06/2023</example>
                public string? Period { get; set; }
            }

            public class FindFromToDatePeriod
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Từ kỳ tháng/năm
                /// </summary>
                /// <example>06/2023</example>
                public string? FromPeriod { get; set; }

                /// <summary>
                /// Đến kỳ tháng/năm
                /// </summary>
                /// <example>09/2023</example>
                public string? ToPeriod { get; set; }
            }

            public class FindYear
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// năm
                /// </summary>
                /// <example>02023</example>
                public string? PeriodYear { get; set; }
            }

            public class FindCmpnID
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }
            }

            public class FindByVehicleTeamByDate : FindDate
            {
                /// <summary>
                /// Danh sách đội xe
                /// </summary>
                /// <example>21,230,507,607,691</example>
                public string? VehicleTeamID { get; set; }
            }

            public class FindByVehicleTeamByPeriod : FindDatePeriod
            {
                /// <summary>
                /// Danh sách đội xe
                /// </summary>
                /// <example>21, 230, 507, 607, 691, 23529</example>
                public string? VehicleTeamID { get; set; }
            }

            public class FindByVehicleTeamByPeriodYear : FindYear
            {
                /// <summary>
                /// Danh sách đội xe
                /// </summary>
                /// <example>21, 230, 507, 607, 691, 23529</example>
                public string? VehicleTeamID { get; set; }
            }

            public class FindByDrvierID
            {
                /// <summary>
                /// Ký tháng/năm
                /// </summary>
                /// <example>06/2023</example>
                public string? Period { get; set; }

                /// <summary>
                /// tài xế
                /// </summary>
                /// <example>1729</example>
                public int? DriverID { get; set; }
            }
            public class FindByManagementRegionID : FindDate
            {
                public string ListManagementRegionID { get; set; }
            }

            public class FindByOutsideID : FindDate
            {
                public int OutSideID { get; set; }
            }
            public class FindByType : FindDate
            {
               public string TopType { get; set; }
            }


        }

        public static class Response
        {
        }
    }
}