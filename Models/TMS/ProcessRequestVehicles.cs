namespace APISmartCity.Models.TMS
{
    public static class ProcessRequestVehicles
    {
        public static class Request
        {
            public class GetApproval
            {
                public int? IsApproval { get; set; }
            }
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>RQ_Eviction_Vehicle</example>
                public string? EntryID { get; set; }
            }

            public class ProcessRequestVehicles_ByDocuments
            {
                /// <summary>
                /// Mã loại giấy tờ
                /// </summary>
                /// <example>599</example>
                public int? VehicleDocumentTypesID { get; set; }

                /// <summary>
                /// Bản sao?
                /// </summary>
                /// <example>1</example>
                public int? IsPhoto { get; set; }

                /// <summary>
                /// Bản chính?
                /// </summary>
                /// <example>1</example>
                public int? IsOriginal { get; set; }
            }

            public class ProcessRequestVehicles_ByTools
            {
                /// <summary>
                /// Mã dụng cụ
                /// </summary>
                /// <example>605</example>
                public int? VehicleToolsID { get; set; }

                /// <summary>
                /// Số lượng
                /// </summary>
                /// <example>4</example>
                public int? Quantity { get; set; }
            }

            public class Evict_ByDocuments
            {
                /// <summary>
                /// Mã chung
                /// </summary>
                /// <example>599</example>
                public int? ID { get; set; }

                /// <summary>
                /// Có thu hồi?
                /// </summary>
                /// <example>1</example>
                public int? IsObtain { get; set; }
            }

            public class Evict_ByTools
            {
                /// <summary>
                /// Mã chung
                /// </summary>
                /// <example>599</example>
                public int? ID { get; set; }

                /// <summary>
                /// Số lượng thu hồi
                /// </summary>
                /// <example>4</example>
                public int? ObtainQuantity { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2023-03-20</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Dầu đầy bình?
                /// </summary>
                /// <example>1</example>
                public int? IsFullFuelTank { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCTH/23/02/13/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? Note { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// Tình trạng bàn giao
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? FinishNote { get; set; }

                /// <summary>
                /// Số km bàn giao
                /// </summary>
                /// <example>1</example>
                public int? HandedOverkm { get; set; }

                /// <summary>
                /// Chi tiết giấy tờ xe
                /// </summary>
                public List<ProcessRequestVehicles_ByDocuments> Documents { get; set; }

                /// <summary>
                /// Chi tiết dụng cụ bàn giao
                /// </summary>
                public List<ProcessRequestVehicles_ByTools> Tools { get; set; }
            }

            public class EditEvict : Content
            {
                /// <summary>
                /// Tình trạng thu hồi
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? EvictNote { get; set; }

                /// <summary>
                /// Số km thu hồi
                /// </summary>
                /// <example>1</example>
                public int? Evictkm { get; set; }

                /// <summary>
                /// Chi tiết giấy tờ xe
                /// </summary>
                public List<Evict_ByDocuments> Documents { get; set; }

                /// <summary>
                /// Chi tiết dụng cụ bàn giao
                /// </summary>
                public List<Evict_ByTools> Tools { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// Đang dùng
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Complete : GetByID
            {
            }

            public class Receive : GetByID
            {
                /// <summary>
                /// Tình trạng bàn giao/thu hồi
                /// </summary>
                /// <example>Hoạt động bình thường</example>
                public string? ReceiveNote { get; set; }

                /// <summary>
                /// Từ chối: 0, đồng ý: 1 tiếp nhận
                /// </summary>
                /// <example>0</example>
                public int? IsApproval { get; set; }

                /// <summary>
                /// Dự kiến thời gian giao
                /// </summary>
                /// <example>2023-03-20 12:00</example>
                public string? ExpectedTime { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class DriverInfo
            {
                /// <summary>
                /// Mã lái xe
                /// </summary>
                /// <example>172</example>
                public int? DriverID { get; set; }
            }

            public class Driver
            {
                /// <summary>
                /// Mã lái xe
                /// </summary>
                /// <example>3</example>
                public int? DriverID { get; set; }

                /// <summary>
                /// Mã loại xe
                /// </summary>
                /// <example>3</example>
                public int? TransportTypeID { get; set; }

                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>RQ_Eviction_Vehicle</example>
                public string? EvictionEntryID { get; set; }
            }

            public class Handover
            {
                /// <summary>
                /// Mã loại xe
                /// </summary>
                /// <example>3</example>
                public int? TransportTypeID { get; set; }
            }
        }
    }
}