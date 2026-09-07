namespace APISmartCity.Models.Ver2.Shippings;

/// <summary>
/// Các model yêu cầu liên quan đến vận chuyển (Shipping)
/// </summary>
public static class Shippings
{
    public static class Request
    {
        /// <summary>
        /// Model thêm mới thông tin vận chuyển
        /// </summary>
        public class Add
        {

            /// <summary>Mã nghiệp vụ</summary>
            //public string? CmpnID { get; set; }

            /// <summary>Mã nghiệp vụ</summary>
            public string? FactorID { get; set; }

            /// <summary>Mã chức năng</summary>
            public string? EntryID { get; set; }
            public DateTime Odate { get; set; }

            /// <summary>Mã vận đơn</summary>
            public string? OID { get; set; }

            /// <summary>Mã SAP</summary>
            public string? SAPID { get; set; }

            /// <summary>Mã Lemon</summary>
            public string? LemonID { get; set; }

            /// <summary>ID tài xế chính</summary>
            public int? DriverID { get; set; }

            /// <summary>Xe điều phối</summary>
            public string? LicensePlates { get; set; }

            /// <summary>ID tài xế thay thế</summary>
            public int? DriverReplaceID { get; set; }

            /// <summary>Loại vận chuyển</summary>
            public int? ShipType { get; set; }

            /// <summary>Đơn vị vận chuyển</summary>
            public int? ShipUnit { get; set; }

            /// <summary>ID tuyến đường</summary>
            public int? RouteID { get; set; }

            /// <summary>Vĩ độ điểm đi</summary>
            public decimal FromLat { get; set; }

            /// <summary>Kinh độ điểm đi</summary>
            public decimal FromLong { get; set; }

            /// <summary>Ghi chú điểm đi</summary>
            public string? FromNote { get; set; }

            /// <summary>Vĩ độ điểm đến</summary>
            public decimal ToLat { get; set; }

            /// <summary>Kinh độ điểm đến</summary>
            public decimal ToLong { get; set; }

            /// <summary>Ghi chú điểm đến</summary>
            public string? ToNote { get; set; }

            /// <summary>Tổng tải trọng xe</summary>
            public decimal TotalVehicleLoad { get; set; }

            /// <summary>Tổng tải trọng đơn hàng</summary>
            public decimal TotalSOLoad { get; set; }


            /// <summary>Tài xế phụ</summary>
            public int? DriverAssistance { get; set; }

            /// <summary>Người bốc xếp tại chỗ</summary>
            public int? LocalHandlingUserID { get; set; }

            /// <summary>Người bốc xếp theo xe</summary>
            public int? VehicleHandlingUserID { get; set; }

            /// <summary>Chọn xe nâng</summary>
            public int? ForkliftID { get; set; }
            /// <summary>Tính sản lượng theo tải trọng xe (Có/Không)</summary>
            public int? IsVehicleLoad {  get; set; }

            /// <summary>Quy đổi sản lượng sang thùng</summary>
            public decimal ConvertedBoxQty { get; set; }

            /// <summary>CCCD/GPLX</summary>
            public string? DocumentNumber { get; set; }

            // <summary>Ghi chú chung</summary>
            public string? Note { get; set; }

            /// <summary>Đường dẫn tài liệu đính kèm</summary>
            public string? Link { get; set; }

            /// <summary>Đã nhận chứng từ hay chưa (1: Có, 0: Không)</summary>
            public int? IsReceiveDoc { get; set; }

            /// <summary>Trường mở rộng 1</summary>
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
            public string? Extention11 { get; set; }
            public string? Extention12 { get; set; }
            public string? Extention13 { get; set; }
            public string? Extention14 { get; set; }
            public string? Extention15 { get; set; }
            public string? Extention16 { get; set; }
            public string? Extention17 { get; set; }
            public string? Extention18 { get; set; }
            public string? Extention19 { get; set; }
            public string? Extention20 { get; set; }

            /// <summary>Danh sách chi tiết vận chuyển</summary>
            public List<ShippingDetail> Item { get; set; }
        }

        /// <summary>
        /// Model chi tiết hàng hóa vận chuyển
        /// </summary>
        public class ShippingDetail
        {
            /// <summary>Mã đơn hàng (SO)</summary>
            public string? ReferenceID { get; set; }

            /// <summary>ID mặt hàng</summary>
            public int? ItemID { get; set; }

            /// <summary>Đơn vị tính</summary>
            public int? ItemUnit { get; set; }

            /// <summary>Số lượng</summary>
            public decimal Quantity { get; set; }

            /// <summary>Khối lượng (kg)</summary>
            public decimal Weight { get; set; }

            /// <summary>Các trường mở rộng</summary>
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

        /// <summary>
        /// Lấy danh sách đơn hàng theo ngày
        /// </summary>
        public class GetSO : Get
        {
           public int? ShippingTypeID { get; set; }
        }
        public class GetSoByID
        {
            public string? ListOID { get; set; }
        }

        /// <summary>
        /// Xác nhận gửi đơn hàng
        /// </summary>
        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
            public string? Link { get; set; }
            public string? Note { get; set; }
            public string? CmpnID { get; set; }
        }

        /// <summary>
        /// Xác nhận đơn vận chuyển
        /// </summary>
        public class Confirm : GetByOID { }

        /// <summary>
        /// Cập nhật trạng thái "Đang vận chuyển"
        /// </summary>
        public class Running
        {
            public string? OID { get; set; }
            public string? ReferenceID { get; set; }
            public string? FromAcLink { get; set; }
            public string? FromNote { get; set; }
            public string? FromAcGPS { get; set; }
        }

        /// <summary>
        /// Cập nhật trạng thái "Hoàn thành"
        /// </summary>
        public class Finished
        {
            public string? OID { get; set; }
            public string? ReferenceID { get; set; }
            public string? ToAcLink { get; set; }
            public string? ToNote { get; set; }
            public string? ToAcGPS { get; set; }
        }

        /// <summary>
        /// Hủy vận chuyển
        /// </summary>
        public class Cancel
        {
            public string? OID { get; set; }
            public string? ReferenceID { get; set; }
            public string? ToAcLink { get; set; }
            public string? ToNote { get; set; }
            public string? ToAcGPS { get; set; }

        }

        /// <summary>
        /// Truy vấn theo mã đơn hàng
        /// </summary>
        public class GetByOID
        {
            public string? OID { get; set; }
        }

        /// <summary>
        /// Lịch sử vận chuyển theo bộ lọc
        /// </summary>
        public class GetHistory: Get
        {
            public string? FilterType { get; set; }
            public string? SearchKey { get; set; }
        }
        public class Get
        {
            /// <summary>
            /// Khi FilterType = FromTo thì truyền Fromdate
            /// </summary>
            public string? FromDate { get; set; }
            /// <summary>
            /// Khi FilterType = FromTo thì truyền Todate
            /// </summary>
            public string? ToDate { get; set; }
        }

        public class GetMonitor
        {
            public int? IsMonitor { get; set; }
        }

        public class GetLicensePlateByDriverID
        {
            public int? DriverID { get; set; }
        }

        public class GetDetailByID
        {
            public string? LicensePlate { get; set; }
        }
        public class GetDashboard: Get
        {
            /// <summary>
            /// Truyền Week, Month, Year, 3 thằng này không truyền FromDate,ToDate (trừ FromTo)
            /// </summary>
            public string? FilterType { get; set; }
        }

        /// <summary>
        /// Xóa đơn hàng vận chuyển
        /// </summary>
        public class Del : GetByOID { }
    }
}
