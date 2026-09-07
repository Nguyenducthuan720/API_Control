namespace DMS.Models.DMS.CustomerRequests;

public static class CustomerRequests
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>CustomerRequest</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>WeldingOrderRequests</example>
            public string? EntryID { get; set; }
			
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }
			
            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2024-11-19</example>
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
            /// Khách hàng
            /// </summary>
            /// <example>0</example>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Ngành hàng
            /// </summary>
            /// <example></example>
            public int? GoodsTypeID { get; set; }

            /// <summary>
            /// Cấp 5 - Loại
            /// </summary>
            /// <example></example>
            public int? TypeID { get; set; }

            /// <summary>
            /// Cấp 5 - Model
            /// </summary>
            /// <example></example>
            public int? ModelID { get; set; }

            /// <summary>
            /// Cấp 5 - Lõi Ván
            /// </summary>
            /// <example></example>
            public int? CoreID { get; set; }

            /// <summary>
            /// Cấp 6 - Màu
            /// </summary>
            /// <example></example>
            public int? ColorID { get; set; }

            /// <summary>
            /// Cấp 6 - Décor
            /// </summary>
            /// <example></example>
            public int? DecorID { get; set; }

            /// <summary>
            /// Cấp 6 - Bao bì
            /// </summary>
            /// <example></example>
            public int? PackagingID { get; set; }

            /// <summary>
            /// Cấp 6 - Loại chống ẩm
            /// </summary>
            /// <example></example>
            public int? MoistureProofID { get; set; }

            /// <summary>
            /// Cấp 7 - Cơ lí hóa tính
            /// </summary>
            /// <example></example>
            public int? PhysicalID { get; set; }

            /// <summary>
            /// Cấp 7 - Chống trầy
            /// </summary>
            /// <example></example>
            public int? ScratchResistanceID { get; set; }

            /// <summary>
            /// Cấp 7 - Tỷ trọng
            /// </summary>
            /// <example></example>
            public int? DensityID { get; set; }

            /// <summary>
            /// Cấp 7 - Cấp phát thải
            /// </summary>
            /// <example></example>
            public int? EmissionLevelID { get; set; }

            /// <summary>
            /// Cấp 7 - Mạ
            /// </summary>
            /// <example></example>
            public int? PlatingID { get; set; }

            /// <summary>
            /// Cấp 8 - Rulo
            /// </summary>
            /// <example></example>
            public int? RuloID { get; set; }

            /// <summary>
            /// Cấp 8 - Phẩm cấp
            /// </summary>
            /// <example></example>
            public int? GradeID { get; set; }

            /// <summary>
            /// Cấp 8 - Màu sắc lõi Ván
            /// </summary>
            /// <example></example>
            public int? CoreColorID { get; set; }

            /// <summary>
            /// Cấp 9 - Backing
            /// </summary>
            /// <example></example>
            public int? BackingID { get; set; }

            /// <summary>
            /// Cấp 9 - Dòng Keo
            /// </summary>
            /// <example></example>
            public int? GlueLineID { get; set; }

            /// <summary>
            /// Cấp 9 - Nhóm Đóng gói
            /// </summary>
            /// <example></example>
            public int? PackagingGroupID { get; set; }

            /// <summary>
            /// Cấp 9 - Số mặt phủ
            /// </summary>
            /// <example></example>
            public int? NumberOfSurfacesID { get; set; }

            /// <summary>
            /// Cấp 10 - Quy cách/đóng gói 1
            /// </summary>
            /// <example></example>
            public int? Specification1ID { get; set; }

            /// <summary>
            /// Cấp 11 - Quy cách/đóng gói 2
            /// </summary>
            /// <example></example>
            public int? Specification2ID { get; set; }

            /// <summary>
            /// Cấp 12 - Loại keo
            /// </summary>
            /// <example></example>
            public int? GlueTypeID { get; set; }

            /// <summary>
            /// Cấp 12 - Loại Khuôn
            /// </summary>
            /// <example></example>
            public int? MoldTypeID { get; set; }

            /// <summary>
            /// Cấp 12 - Hèm khóa
            /// </summary>
            /// <example></example>
            public int? LockSeamID { get; set; }

            /// <summary>
            /// Cấp 12 - Nhãn hiệu M1
            /// </summary>
            /// <example></example>
            public int? BrandM1ID { get; set; }

            /// <summary>
            /// Cấp 13 - Dòng SP theo quy cách
            /// </summary>
            /// <example></example>
            public int? ProductLineID { get; set; }

            /// <summary>
            /// Cấp 13 - Nhóm hoa văn M1
            /// </summary>
            /// <example></example>
            public int? PatternGroupM1ID { get; set; }

            /// <summary>
            /// Cấp 13 - Nhóm hoa văn M2
            /// </summary>
            /// <example></example>
            public int? PatternGroupM2ID { get; set; }

            /// <summary>
            /// Cấp 14 - Dòng SP theo Hoa văn+Khuôn
            /// </summary>
            /// <example></example>
            public int? ProductLineByPatternMoldID { get; set; }

            /// <summary>
            /// Cấp 14 - Hoa Văn M1
            /// </summary>
            /// <example></example>
            public int? PatternM1ID { get; set; }

            /// <summary>
            /// Cấp 20 - Hoa Văn M2
            /// </summary>
            /// <example></example>
            public int? PatternM2ID { get; set; }

            /// <summary>
            /// Cấp 20 - Độ dày Backing
            /// </summary>
            /// <example></example>
            public int? BackingThicknessID { get; set; }

            /// <summary>
            /// Cấp 15 - Mã màu M1
            /// </summary>
            /// <example></example>
            public int? ColorCodeM1ID { get; set; }

            /// <summary>
            /// Cấp 15 - Cấp phát thải For
            /// </summary>
            /// <example></example>
            public int? EmissionLevelForID { get; set; }

            /// <summary>
            /// Cấp 21- Mã màu M2
            /// </summary>
            /// <example></example>
            public int? ColorCodeM2ID { get; set; }

            /// <summary>
            /// Cấp 16 - Phẩm cấp Sản xuất
            /// </summary>
            /// <example></example>
            public int? ProductionGradeID { get; set; }

            /// <summary>
            /// Cấp 16 - Khuôn M1
            /// </summary>
            /// <example></example>
            public int? MoldM1ID { get; set; }

            /// <summary>
            /// Cấp 22 - Khuôn M2
            /// </summary>
            /// <example></example>
            public int? MoldM2ID { get; set; }

            /// <summary>
            /// Cấp 17- Giấy Overlay
            /// </summary>
            /// <example></example>
            public int? OverlayPaperID { get; set; }

            /// <summary>
            /// Cấp 17- Div M2
            /// </summary>
            /// <example></example>
            public int? DivisionM2ID { get; set; }

            /// <summary>
            /// Cấp 18- Giấy Balance
            /// </summary>
            /// <example></example>
            public int? BalancePaperID { get; set; }

            /// <summary>
            /// Cấp 18- Nhãn hiệu M2
            /// </summary>
            /// <example></example>
            public int? BrandM2ID { get; set; }

            /// <summary>
            /// Sản phẩm
            /// </summary>
            /// <example></example>
            public int? ItemID { get; set; }

            /// <summary>
            /// Tên sản phẩm
            /// </summary>
            /// <example></example>
            public string? ItemName { get; set; }

            /// <summary>
            /// Số lượng yêu cầu
            /// </summary>
            /// <example>100</example>
            public int? Quantity { get; set; }

            /// <summary>
            /// Yêu cầu của khách hàng/Mô tả yêu cầu
            /// </summary>
            /// <example>Đây là mô tả chi tiết của khách hàng cho yêu cầu đặt hàng này</example>
            public string? CustomerRequest { get; set; }

            /// <summary>
            /// Yêu cầu của kinh doanh
            /// </summary>
            /// <example></example>
            public string? BusinessRequest { get; set; }

            /// <summary>
            /// Khách hàng tạo yêu cầu
            /// </summary>
            /// <example>0</example>
            public int? IsCustomer { get; set; }
            
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Ghi chú</example>
            public string? Note { get; set; }

            /// <summary>
            /// Loại yêu cầu của khách hàng
            /// </summary>
            /// <example>7</example>
            public int? CustomerRequestTypeID { get; set; }

            /// <summary>
            /// File đính kèm
            /// </summary>
            /// <example></example>
            public string? RequestLink { get; set; }

            /// <summary>
            /// Bộ phận chuyển tiếp
            /// </summary>
            /// <example></example>
            public int? TransferDepartmentID { get; set; }

            /// <summary>
            /// Nhân viên phụ trách
            /// </summary>
            /// <example></example>
            public int? ResponsibleEmployeeID { get; set; }

            /// <summary>
            /// Hạn xử lý
            /// </summary>
            /// <example>2025-07-01</example>
            public string? RequestDueDate { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention1 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention2 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention3 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention4 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention5 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention6 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention7 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention8 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention9 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention10 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention11 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention12 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention13 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention14 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention15 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention16 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention17 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention18 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention19 { get; set; }

            /// <summary>
            /// Mở rộng
            /// </summary>
            /// <example></example>
            public string? Extention20 { get; set; }
        }

        public class Submit : GetByOID
        {
            /// <summary>
            /// Khóa/Mở khóa
            /// </summary>
            public int? IsLock { get; set; }

            /// <summary>
            /// Từ chối/Xác nhận
            /// </summary>
            /// <example>0</example>
            public int? IsRejected { get; set; }

            /// <summary>
            /// Nội dung xác nhận (Tiếp nhận)
            /// </summary>
            /// <example></example>
            public string? ConfirmNote { get; set; }

            /// <summary>
            /// Tệp đính kèm (Tiếp nhận)
            /// </summary>
            public string? ConfirmLink { get; set; }

            /// <summary>
            /// Bộ phận chuyển tiếp
            /// </summary>
            /// <example></example>
            public int? TransferDepartmentID { get; set; }

            /// <summary>
            /// Nhân viên phụ trách
            /// </summary>
            /// <example></example>
            public int? ResponsibleEmployeeID { get; set; }

            /// <summary>
            /// Hạn xử lý
            /// </summary>
            /// <example>2025-07-01</example>
            public string? RequestDueDate { get; set; }

            /// <summary>
            /// Nội dung yêu cầu (Chuyển tiếp)
            /// </summary>
            /// <example></example>
            public string? TransferNote { get; set; }

            /// <summary>
            /// Tệp đính kèm (Chuyển tiếp)
            /// </summary>
            /// <example></example>
            public string? TransferLink { get; set; }
        }

        public class Receive : GetByOID
        {
            /// <summary>
            /// Từ chối/Xác nhận
            /// </summary>
            /// <example>0</example>
            public int? IsRejected { get; set; }

            /// <summary>
            /// Nội dung xác nhận
            /// </summary>
            /// <example></example>
            public string? Note { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            public string? Link { get; set; }
        }

        public class Response : GetByOID
        {
            /// <summary>
            /// Đã hoàn thành
            /// </summary>
            /// <example>0</example>
            public int? IsCompleted { get; set; }

            /// <summary>
            /// Người xác nhận
            /// </summary>
            /// <example>0</example>
            public int? ResponseUser { get; set; }

            /// <summary>
            /// Ngày xác nhận
            /// </summary>
            /// <example>0</example>
            public string? ResponseDate { get; set; }

            /// <summary>
            /// Nội dung xác nhận
            /// </summary>
            /// <example></example>
            public string? Note { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            public string? Link { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }

        public class Del : GetByOID
        {
        }

        public class GetItem
        {
            /// <summary>
            /// Ngành hàng
            /// </summary>
            /// <example></example>
            public int? GoodsTypeID { get; set; }

            /// <summary>
            /// Cấp 5 - Loại
            /// </summary>
            /// <example></example>
            public int? TypeID { get; set; }

            /// <summary>
            /// Cấp 5 - Model
            /// </summary>
            /// <example></example>
            public int? ModelID { get; set; }

            /// <summary>
            /// Cấp 5 - Lõi Ván
            /// </summary>
            /// <example></example>
            public int? CoreID { get; set; }

            /// <summary>
            /// Cấp 6 - Màu
            /// </summary>
            /// <example></example>
            public int? ColorID { get; set; }

            /// <summary>
            /// Cấp 6 - Décor
            /// </summary>
            /// <example></example>
            public int? DecorID { get; set; }

            /// <summary>
            /// Cấp 6 - Bao bì
            /// </summary>
            /// <example></example>
            public int? PackagingID { get; set; }

            /// <summary>
            /// Cấp 6 - Loại chống ẩm
            /// </summary>
            /// <example></example>
            public int? MoistureProofID { get; set; }

            /// <summary>
            /// Cấp 7 - Cơ lí hóa tính
            /// </summary>
            /// <example></example>
            public int? PhysicalID { get; set; }

            /// <summary>
            /// Cấp 7 - Chống trầy
            /// </summary>
            /// <example></example>
            public int? ScratchResistanceID { get; set; }

            /// <summary>
            /// Cấp 7 - Tỷ trọng
            /// </summary>
            /// <example></example>
            public int? DensityID { get; set; }

            /// <summary>
            /// Cấp 7 - Cấp phát thải
            /// </summary>
            /// <example></example>
            public int? EmissionLevelID { get; set; }

            /// <summary>
            /// Cấp 7 - Mạ
            /// </summary>
            /// <example></example>
            public int? PlatingID { get; set; }

            /// <summary>
            /// Cấp 8 - Rulo
            /// </summary>
            /// <example></example>
            public int? RuloID { get; set; }

            /// <summary>
            /// Cấp 8 - Phẩm cấp
            /// </summary>
            /// <example></example>
            public int? GradeID { get; set; }

            /// <summary>
            /// Cấp 8 - Màu sắc lõi Ván
            /// </summary>
            /// <example></example>
            public int? CoreColorID { get; set; }

            /// <summary>
            /// Cấp 9 - Backing
            /// </summary>
            /// <example></example>
            public int? BackingID { get; set; }

            /// <summary>
            /// Cấp 9 - Dòng Keo
            /// </summary>
            /// <example></example>
            public int? GlueLineID { get; set; }

            /// <summary>
            /// Cấp 9 - Nhóm Đóng gói
            /// </summary>
            /// <example></example>
            public int? PackagingGroupID { get; set; }

            /// <summary>
            /// Cấp 9 - Số mặt phủ
            /// </summary>
            /// <example></example>
            public int? NumberOfSurfacesID { get; set; }

            /// <summary>
            /// Cấp 10 - Quy cách/đóng gói 1
            /// </summary>
            /// <example></example>
            public int? Specification1ID { get; set; }

            /// <summary>
            /// Cấp 11 - Quy cách/đóng gói 2
            /// </summary>
            /// <example></example>
            public int? Specification2ID { get; set; }

            /// <summary>
            /// Cấp 12 - Loại keo
            /// </summary>
            /// <example></example>
            public int? GlueTypeID { get; set; }

            /// <summary>
            /// Cấp 12 - Loại Khuôn
            /// </summary>
            /// <example></example>
            public int? MoldTypeID { get; set; }

            /// <summary>
            /// Cấp 12 - Hèm khóa
            /// </summary>
            /// <example></example>
            public int? LockSeamID { get; set; }

            /// <summary>
            /// Cấp 12 - Nhãn hiệu M1
            /// </summary>
            /// <example></example>
            public int? BrandM1ID { get; set; }

            /// <summary>
            /// Cấp 13 - Dòng SP theo quy cách
            /// </summary>
            /// <example></example>
            public int? ProductLineID { get; set; }

            /// <summary>
            /// Cấp 13 - Nhóm hoa văn M1
            /// </summary>
            /// <example></example>
            public int? PatternGroupM1ID { get; set; }

            /// <summary>
            /// Cấp 13 - Nhóm hoa văn M2
            /// </summary>
            /// <example></example>
            public int? PatternGroupM2ID { get; set; }

            /// <summary>
            /// Cấp 14 - Dòng SP theo Hoa văn+Khuôn
            /// </summary>
            /// <example></example>
            public int? ProductLineByPatternMoldID { get; set; }

            /// <summary>
            /// Cấp 14 - Hoa Văn M1
            /// </summary>
            /// <example></example>
            public int? PatternM1ID { get; set; }

            /// <summary>
            /// Cấp 20 - Hoa Văn M2
            /// </summary>
            /// <example></example>
            public int? PatternM2ID { get; set; }

            /// <summary>
            /// Cấp 20 - Độ dày Backing
            /// </summary>
            /// <example></example>
            public int? BackingThicknessID { get; set; }

            /// <summary>
            /// Cấp 15 - Mã màu M1
            /// </summary>
            /// <example></example>
            public int? ColorCodeM1ID { get; set; }

            /// <summary>
            /// Cấp 15 - Cấp phát thải For
            /// </summary>
            /// <example></example>
            public int? EmissionLevelForID { get; set; }

            /// <summary>
            /// Cấp 21- Mã màu M2
            /// </summary>
            /// <example></example>
            public int? ColorCodeM2ID { get; set; }

            /// <summary>
            /// Cấp 16 - Phẩm cấp Sản xuất
            /// </summary>
            /// <example></example>
            public int? ProductionGradeID { get; set; }

            /// <summary>
            /// Cấp 16 - Khuôn M1
            /// </summary>
            /// <example></example>
            public int? MoldM1ID { get; set; }

            /// <summary>
            /// Cấp 22 - Khuôn M2
            /// </summary>
            /// <example></example>
            public int? MoldM2ID { get; set; }

            /// <summary>
            /// Cấp 17- Giấy Overlay
            /// </summary>
            /// <example></example>
            public int? OverlayPaperID { get; set; }

            /// <summary>
            /// Cấp 17- Div M2
            /// </summary>
            /// <example></example>
            public int? DivisionM2ID { get; set; }

            /// <summary>
            /// Cấp 18- Giấy Balance
            /// </summary>
            /// <example></example>
            public int? BalancePaperID { get; set; }

            /// <summary>
            /// Cấp 18- Nhãn hiệu M2
            /// </summary>
            /// <example></example>
            public int? BrandM2ID { get; set; }
        }
    }
}