namespace APISmartCity.Models.TMS
{
    public static class ShippingsNoRevenues
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>VD/23/05/00001</example>
                public string? OID { get; set; }
            }

            public class Add
            {
                /// <summary>
                /// Lý do
                /// </summary>
                /// <example>1</example>
                public int? ReasonID { get; set; }

                /// <summary>
                /// Tài xế
                /// </summary>
                /// <example>1</example>
                public int? DriverID { get; set; }

                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>1</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Phí cầu đường
                /// </summary>
                /// <example>0</example>
                public decimal TurnpikeTolls { get; set; }

                /// <summary>
                /// Phí khác
                /// </summary>
                /// <example>0</example>
                public decimal OtherFees { get; set; }

                /// <summary>
                /// Điểm đi
                /// </summary>
                /// <example>43R Hồ Văn Huê</example>
                public string? DepartureAddress { get; set; }

                /// <summary>
                /// Điểm đến
                /// </summary>
                /// <example>43R Hồ Văn Huê</example>
                public string? DestinationAddress { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example>1</example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Dự kiến khởi hành
                /// </summary>
                /// <example>2023-05-12T10:30:00</example>
                public DateTime EstimatedDeparture { get; set; }

                /// <summary>
                /// Dự kiến đến nơi
                /// </summary>
                /// <example>2023-05-13T10:30:00</example>
                public DateTime EstimatedDestination { get; set; }

                /// <summary>
                /// Dự kiến tọa độ bắt đầu
                /// </summary>
                /// <example>10.800855,106.675979</example>
                public string? EstimatedStartLatLong { get; set; }

                /// <summary>
                /// Dự kiến tọa độ bắt đầu
                /// </summary>
                /// <example>10.802140,106.667352</example>
                public string? EstimatedEndLatLong { get; set; }

                /// <summary>
                /// List string point
                /// </summary>
                /// <example>[10.76239,106.77716],[10.76239,106.77716],[10.76239,106.77716]</example>
                public string? StringPoint { get; set; }

                /// <summary>
                /// List string point
                /// </summary>
                /// <example>[10.76239,106.77716],[10.76239,106.77716],[10.76239,106.77716]</example>
                public string? StringPointRoot { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>VD/23/05/00001</example>
                public string? OID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>VD/23/05/00001</example>
                public string? OID { get; set; }
            }

            public class ChangeStatus : Del
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
            public class Running : Del
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? DepartureNote { get; set; }
            }

            public class Finished : Del
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? DestinationNote { get; set; }
            }

            public class UpdateAdjustRouteID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>VD/23/05/00001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Điểm tuyến
                /// </summary>
                /// <example>[10.75759,106.72753],[10.800078,106.7447379],[10.75180,106.72891]</example>
                public string? StringPoint { get; set; }
            }
        }
    }
}