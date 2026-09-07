namespace APISmartCity.Models.Function
{
    public static class MaintenanceProcess
    {
        public static class Request
        {
            public class GetEntryID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>LightMaintence</example>
                public string? EntryID { get; set; }
            }
            public class GetEntryIDFromDateToDate : GetEntryID
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2021-08-22</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2021-09-11</example>
                public string? ToDate { get; set; }
            }
            public class FromDateToDate
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2021-08-22</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2021-09-11</example>
                public string? ToDate { get; set; }
            }
            public class Content
            {
                /// <summary>
                /// Ngày tạo
                /// </summary>
                /// <example>2023-11-24</example>
                public string? ODate { get; set; }


                /// <summary>
                /// Loại xử lý
                /// </summary>
                /// <example>BCSC/24/04/002</example>
                public string? ReferenceType { get; set; }
                public int? TotalQuantity { get; set; }


                /// <summary>
                /// Vấn đề xử lý
                /// </summary>
                /// <example>BCSC/24/04/002</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>SmartLighting</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/04/10</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2022/05/10</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Loại yêu cầu duy tu
                /// </summary>
                /// <example>1</example>
                public int? MaintenanceRequestTypeID { get; set; }

                /// <summary>
                /// Nếu loại yêu cầu duy tu là cả tuyến thì dùng đến cái này, danh sách các tủ điều khiển
                /// </summary>
                /// <example>1,2</example>
                public string? ListStation { get; set; }

                /// <summary>
                /// Nhóm/nhân viên: Group/User
                /// </summary>
                /// <example>Group</example>
                public string? CoordinatorType { get; set; }

                /// <summary>
                /// Danh sách nhóm hoặc nhân viên
                /// </summary>
                /// <example>1,2,3</example>
                public string? CoordinatorValue { get; set; }

                /// <summary>
                /// Mô tả yêu cầu duy tu
                /// </summary>
                /// <example>Cắt tỉa cây theo hình trái tim</example>
                public string? MaintenanceDescription { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Lưu ý xử lý cỏ dưới gốc cây</example>
                public string? Note { get; set; }

                /// <summary>
                /// Tỉnh quận huyện
                /// </summary>
                /// <example>11369</example>
                public string? RegionID { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// ManagemenUnitID
                /// </summary>
                /// <example>6089</example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// ManagemenUnitID
                /// </summary>
                /// <example>6089</example>
                public string? Extention2 { get; set; }
                /// <summary>
                /// Danh sách cây xanh
                /// </summary>
                /// <example></example>
                public List<Details> Details { get; set; }
            }

            public class Details
            {
                /// <summary>
                /// Là Station hay Node
                /// </summary>
                /// <example>1</example>
                public int? IsStation { get; set; }

                /// <summary>
                /// Mã StationID hoặc NodeID
                /// </summary>
                /// <example>NLT_CS_0002</example>
                public string? StationID { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Lưu ý xử lý cỏ dưới gốc cây</example>
                public string? Note { get; set; }
            }

            public class Edit : Add 
            {
                /// <summary>
                /// ManagemenUnitID
                /// </summary>
                /// <example>6089</example>
                public string? Extention2 { get; set; }
                /// <summary>
                /// OID
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? OID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? OID { get; set; }
            }

            public class Close : Del
            {
                /// <summary>
                /// Đóng mở lệnh
                /// </summary>
                /// <example>1</example>
                public int? IsClose { get; set; }
            }

            public class EditStatusContent
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// Mã tham chiếu
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? ReferenceID { get; set; }
            }

            public class Confirm : EditStatusContent
            {
                /// <summary>
                /// Mô tả trạng thái khi xác nhận duy tu
                /// </summary>
                /// <example>Cây bị bệnh</example>
                public string? RealityDescription { get; set; }

                /// <summary>
                /// Mô tả giải pháp duy tu
                /// </summary>
                /// <example>Gọi bác sĩ</example>
                public string? SolutionDescription { get; set; }

                /// <summary>
                /// FE nhập 1, Mobile nhập 0
                /// </summary>
                /// <example>1</example>
                public int? IsManager { get; set; }

                /// <summary>
                /// Mã nhân viên
                /// </summary>
                /// <example>1</example>
                public int? EmployerID { get; set; }

                /// <summary>
                /// Danh sách hình ảnh đã mã hóa thành base64
                /// </summary>
                /// <example></example>
                public List<string> LinkImages { get; set; }
            }

            public class Complete : EditStatusContent
            {
                /// <summary>
                /// Mô tả trạng thái khi xác nhận duy tu
                /// </summary>
                /// <example>Bác sĩ đã khám và chửa bệnh cho cây</example>
                public string? ResultDescription { get; set; }

                /// <summary>
                /// FE nhập 1, Mobile nhập 0
                /// </summary>
                /// <example>1</example>
                public int? IsManager { get; set; }

                /// <summary>
                /// Mã nhân viên
                /// </summary>
                /// <example>1</example>
                public int? EmployerID { get; set; }

                /// <summary>
                /// Danh sách hình ảnh đã mã hóa thành base64
                /// </summary>
                /// <example></example>
                public List<string> @LinkImages { get; set; }
            }

            public class Commit : EditStatusContent
            {
                /// <summary>
                /// Mô tả trạng thái khi xét duyệt duy tu đúng yêu cầu
                /// </summary>
                /// <example>Tuyệt vời, amazing good job em</example>
                public string? ManagerDescription { get; set; }
            }

            public class Return : EditStatusContent
            {
                /// <summary>
                /// Mô tả trạng thái khi xét duyệt duy tu sai yêu cầu
                /// </summary>
                /// <example>A đù, em làm vầy là không được, kiểm tra lại tình trạng cây đi.</example>
                public string? ManagerDescription { get; set; }
            }

            public class ReportTreeMaintenanceRequest
            {
                /// <summary>
                /// TOTAL, DETAILS
                /// </summary>
                /// <example>TOTAL</example>
                public string? Type { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/04/11</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2022/04/15</example>
                public string? ToDate { get; set; }
            }

            public class ReportTreeCategories
            {
                /// <summary>
                /// TOTAL, DETAILS
                /// </summary>
                /// <example>TOTAL</example>
                public string? Type { get; set; }

                /// <summary>
                /// Danh mục
                /// </summary>
                /// <example>#</example>
                public string? List { get; set; }
            }

            public class Report
            {
                /// <summary>
                /// Danh mục
                /// </summary>
                /// <example>#</example>
                public string? List { get; set; }

                /// <summary>
                /// TOTAL, DETAILS
                /// </summary>
                /// <example>TOTAL</example>
                public string? Type { get; set; }
            }

            public class EditLock : Del
            {
                /// <summary>
                /// Khóa/Mở khóa
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Employer_Confirm
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Mô tả hiện trạng
                /// </summary>
                /// <example>Hiện trạng</example>
                public string? RealityDescription { get; set; }

                /// <summary>
                /// Mô tả giải pháp
                /// </summary>
                /// <example>Giải pháp</example>
                public string? SolutionDescription { get; set; }

                /// <summary>
                /// Hình ảnh
                /// </summary>
                /// <example>http;http;http</example>
                public string? LinkImages { get; set; }

                /// <summary>
                /// Là quản lý thao tác
                /// </summary>
                /// <example>1</example>
                public int? IsManager { get; set; }

                /// <summary>
                /// Mã nhân viên
                /// </summary>
                /// <example>1054</example>
                public int? EmployerID { get; set; }
            }

            public class Employer_Complete
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Mô tả kết quả
                /// </summary>
                /// <example>Kết quả</example>
                public string? ResultDescription { get; set; }

                /// <summary>
                /// Hình ảnh
                /// </summary>
                /// <example>http;http;http</example>
                public string? LinkImages { get; set; }

                /// <summary>
                /// Là quản lý thao tác
                /// </summary>
                /// <example>1</example>
                public int? IsManager { get; set; }

                /// <summary>
                /// Mã nhân viên
                /// </summary>
                /// <example>1054</example>
                public int? EmployerID { get; set; }
            }

            public class Manager_Confirm
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Lý do duyệt
                /// </summary>
                /// <example>Duyệt</example>
                public string? ManagerDescription { get; set; }
            }

            public class Manager_Reject
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>TMR/16042022/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Lý do từ chới
                /// </summary>
                /// <example>Từ chối</example>
                public string? ManagerDescription { get; set; }
            }
            public class GetListTreeByRegionID
            {
                public string? ListRegionID { get; set; }
            }
            public class GetSearchTree
            {
                public string? RouteID { get; set; }
                public string? TreeNumber { get; set; }
            }
        }
    }
}