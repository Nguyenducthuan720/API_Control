namespace APISmartCity.Models.TMS
{
    public static class ProcessChangeTires
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }
            }

            public class GetTire
            {
                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>69811-51C</example>
                public string? LicensePlates { get; set; }
            }

            public class Tires
            {
                /// <summary>
                /// Số seri vỏ cũ
                /// </summary>
                /// <example>1</example>
                public string? OldSerialNumber { get; set; }

                /// <summary>
                /// Số seri vỏ mới
                /// </summary>
                /// <example>1</example>
                public string? NewSerialNumber { get; set; }

                /// <summary>
                /// Nhà sản xuất
                /// </summary>
                /// <example>1</example>
                public int? TireProducerID { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2023-03-20</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Biển số xe
                /// </summary>
                /// <example>12312 51H</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Mã loại xe
                /// </summary>
                /// <example>542</example>
                public int? TransportTypeID { get; set; }

                /// <summary>
                /// Số km đi được
                /// </summary>
                /// <example>24000</example>
                public int? LastKm { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Chi tiết giấy tờ xe
                /// </summary>
                public List<Tires> Tires { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>PCT_ChangeTires</example>
                public string? EntryID { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// Đang dùng
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }
            public class Submit : Del
            {
                /// <summary>
                /// Đang dùng
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