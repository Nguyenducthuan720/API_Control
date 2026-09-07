namespace APISmartCity.Models.TMS
{
    public static class DriverRequests
    {
        public static class Request
        {
            public class Get
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>Report_Incident</example>
                public string? FactorID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>BCSC/001</example>
                public string? OID { get; set; }
            }

            public class FromDateToDate
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023-08-01</example>
                public string? FDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2023-09-01</example>
                public string? TDate { get; set; }
            }
            public class DriverInfo
            {
                /// <summary>
                /// Mã lái xe
                /// </summary>
                /// <example>172</example>
                public int? DriverID { get; set; }
            }

            public class GetparamLemon3
            {
                public string? PeriodOfMonth { get; set; }

                public string? CompanyCode { get; set; }

                public string? LicensePlates { get; set; }
            }

            public class Add : Get
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>RP_Incident</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã sự cố
                /// </summary>
                /// <example>37</example>
                public string? IncidentID { get; set; }

                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.801059717622437</example>
                public string? DriverLat { get; set; }

                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.67756691371261</example>
                public string? DriverLong { get; set; }

                /// <summary>
                /// Yêu cầu từ ngày
                /// </summary>
                /// <example>2023-02-10</example>
                public string? RequestFromDate { get; set; }

                /// <summary>
                /// Yêu cầu đến ngày
                /// </summary>
                /// <example>2023-02-10</example>
                public string? RequestToDate { get; set; }

                /// <summary>
                /// Số km hiện tại
                /// </summary>
                /// <example>0</example>
                public int? CurrentKm { get; set; }

                /// <summary>
                /// Số lít dầu yêu cầu
                /// </summary>
                /// <example>0.00</example>
                public string? RequestGasQuantity { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example></example>
                public string Link { get; set; }

                /// <summary>
                /// Danh sách hình ảnh dưới dạng base64 string
                /// </summary>
                /// <example></example>
                public List<ContentBase64> Base64s { get; set; }
            }

            public class AddCoordinator : Get
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>RP_Incident</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã tài xế
                /// </summary>
                /// <example>174</example>
                public int? DriverID { get; set; }

                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.801059717622437</example>
                public string? DriverLat { get; set; }

                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.67756691371261</example>
                public string? DriverLong { get; set; }

                /// <summary>
                /// Yêu cầu từ ngày
                /// </summary>
                /// <example>2023-02-10</example>
                public string? RequestFromDate { get; set; }

                /// <summary>
                /// Yêu cầu đến ngày
                /// </summary>
                /// <example>2023-02-10</example>
                public string? RequestToDate { get; set; }

                /// <summary>
                /// Số km hiện tại
                /// </summary>
                /// <example>0</example>
                public int? CurrentKm { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Danh sách hình ảnh dưới dạng base64 string
                /// </summary>
                /// <example></example>
                public List<ContentBase64> Base64s { get; set; }
            }

            public class ContentBase64
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>icon.jpeg</example>
                public string? FileName { get; set; }

                /// <summary>
                /// Loại nội dung
                /// </summary>
                /// <example>image/jpeg</example>
                public string? ContentType { get; set; }

                /// <summary>
                /// Dữ liệu file dưới dạng base64 string
                /// </summary>
                /// <example></example>
                public string? Base64 { get; set; }
            }

            public class UploadFiles
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>1</example>
                public string? FileName { get; set; }

                /// <summary>
                /// Loại nội dung
                /// </summary>
                /// <example>ALL</example>
                public string? ContentType { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example></example>
                public string? FileLink { get; set; }

                /// <summary>
                /// Path
                /// </summary>
                /// <example></example>
                public string? FilePath { get; set; }
            }

            public class Edit : Add
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>BCSC/001</example>
                public string? OID { get; set; }
            }

            public class EditCoordinator : AddCoordinator
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>BCSC/001</example>
                public string? OID { get; set; }
            }

            public class Cancel : GetByID
            {
            }

            public class Approval : GetByID
            {
                /// <summary>
                /// Đồng ý là 1, từ chối 0
                /// </summary>
                /// <example>1</example>
                public string? IsApproval { get; set; }

                /// <summary>
                /// ApprovalGasQuantity - Duyệt xin đổ dầu
                /// </summary>
                /// <example>50</example>
                public float ApprovalGasQuantity { get; set; }

                /// <summary>
                /// ApprovalGasMoney - Duyệt xin đổ dầu
                /// </summary>
                /// <example>500000</example>
                public string? ApprovalGasMoney { get; set; }

                /// <summary>
                /// ApprovalGasStationID - Duyệt xin đổ dầu
                /// </summary>
                /// <example>26</example>
                public string? ApprovalGasStationID { get; set; }

                /// <summary>
                /// ApprovalFromDate - cho xe dừng từ ngày - Duyệt các yêu cầu khác
                /// </summary>
                /// <example>2023-02-10</example>
                public string? ApprovalFromDate { get; set; }

                /// <summary>
                /// ApprovalToDate - Cho xe dừng đến ngày - Duyệt các yêu cầu khác
                /// </summary>
                /// <example>2023-02-10</example>
                public string? ApprovalToDate { get; set; }

                /// <summary>
                /// Nội dung xét duyệt - Tất cả các yêu cầu khác, xin đổ dầu, báo cáo sự cố
                /// </summary>
                /// <example>Đồng ý nha</example>
                public string? ApprovalNote { get; set; }
                /// <summary>
                /// Chọn biển số xe duyệt BCSC
                /// </summary>
                public string? Extention5 { get; set; }

            }

            public class DriverRequestsDetailsGas
            {
                /// <summary>
                /// FilledOilLastTime
                /// </summary>
                /// <example>1000</example>
                public double FilledOilLastTime { get; set; }

                /// <summary>
                /// CurrentKm
                /// </summary>
                /// <example>2000</example>
                public int? CurrentKm { get; set; }

                /// <summary>
                /// HasRunKm
                /// </summary>
                /// <example>1000</example>
                public int? HasRunKm { get; set; }

                /// <summary>
                /// BillsLading
                /// </summary>
                /// <example>3</example>
                public int? BillsLading { get; set; }

                /// <summary>
                /// LitersOilConsumed
                /// </summary>
                /// <example>15</example>
                public double LitersOilConsumed { get; set; }

                /// <summary>
                /// LitersSupplementaryOil
                /// </summary>
                /// <example>10</example>
                public double LitersSupplementaryOil { get; set; }

                /// <summary>
                /// LitersOilLeft
                /// </summary>
                /// <example>10</example>
                public double LitersOilLeft { get; set; }

                /// <summary>
                /// LitersOilPoured
                /// </summary>
                /// <example>50</example>
                public double LitersOilPoured { get; set; }

                /// <summary>
                /// CurrentLitersOil
                /// </summary>
                /// <example>35</example>
                public double CurrentLitersOil { get; set; }
            }

            public class UpdateGasContract
            {
                /// <summary>
                /// Hóa đơn
                /// </summary>
                /// <example>BCSC/001</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// file Hóa đơn
                /// </summary>
                /// <example>a.jpg</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Số tiền thực đổ
                /// </summary>
                /// <example></example>
                public decimal Extention3 { get; set; }

                /// <summary>
                /// ApprovalGasQuantity - Duyệt xin đổ dầu
                /// </summary>
                /// <example>50</example>
                public float ApprovalGasQuantity { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>BCSC/001</example>
                public string? OID { get; set; }
            }

            public class Submit : GetByID
            {
                /// <summary>
                /// Khóa hay không?
                /// </summary>
                /// <example>1</example>
                public int IsLock { get; set; }
            }
        }
    }
}