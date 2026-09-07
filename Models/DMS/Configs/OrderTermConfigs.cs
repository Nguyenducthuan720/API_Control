namespace DMS.Models.DMS.Configs
{
    public class OrderTermConfigs
    {
        public class Request
        {
            public class AddOrUpdate
            {
                /// <summary>
                /// ID
                /// </summary>
                public int? ID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example></example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng
                /// </summary>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example></example>
                public DateTime FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example></example>
                public DateTime ToDate { get; set; }

                /// <summary>
                /// Hạn MTS (ngày)
                /// </summary>
                /// <example>0</example>
                public int? MTSTerm { get; set; }

                /// <summary>
                /// Hủy đơn khi hết hạn (MTS)
                /// </summary>
                public int? MTSCancelExpired { get; set; }

                /// <summary>
                /// Hạn MTO mặc định (ngày)
                /// </summary>
                /// <example>0</example>
                public int? MTOTerm { get; set; }

                /// <summary>
                /// Hủy đơn khi hết hạn (MTO)
                /// </summary>
                public int? MTOCancelExpired { get; set; }

                /// <summary>
                /// Hạn MTS/MTO mặc định (ngày)
                /// </summary>
                /// <example>0</example>
                public int? HybridTerm { get; set; }

                /// <summary>
                /// Hủy đơn khi hết hạn (MTO/MTS)
                /// </summary>
                public int? HybridCancelExpired { get; set; }

                /// <summary>
                /// Công ty áp dụng
                /// </summary>
                public string? Companys { get; set; }

                /// <summary>
                /// Phòng ban áp dụng
                /// </summary>
                public string? SalesOrgs { get; set; }

                /// <summary>
                /// Điểm xuất hàng
                /// </summary>
                /// <example></example>
                public string? ShippingPoints { get; set; }

                /// <summary>
                /// Nghiệp vụ áp dụng
                /// </summary>
                /// <example></example>
                public string? Factors { get; set; }

                /// <summary>
                /// Chức năng áp dụng
                /// </summary>
                /// <example></example>
                public string? Entrys { get; set; }

                /// <summary>
                /// Đang hoạt động
                /// </summary>
                public int? IsActive { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }

                /// <summary>
                /// Tệp đính kèm
                /// </summary>
                public string? Link { get; set; }

                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public string? Extention10 { get; set; }
            }

            public class GetByID
            {
                public int? ID { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Lock : GetByID
            {
                public int? IsLock { get; set; }
            }
        }
    }
}
