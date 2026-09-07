namespace APISmartCity.Models.Ver2.Complaints;

public static class Complaints
{
 
    public static class Request
    {
        /// <summary>
        /// Lớp đại diện cho thông tin chi tiết lỗi của một mục khiếu nại.
        /// </summary>
        public class ErrorItem
        {
            /// <summary>
            /// Mã lỗi.
            /// </summary>
            public int? ErrorId { get; set; }

            /// <summary>
            /// Mô tả chi tiết về lỗi.
            /// </summary>
            public string? ErrorDetails { get; set; }
            public string? CausalDetails { get; set; }

            /// <summary>
            /// Số lượng trả về
            /// </summary>
            public int? ReturnQuantity { get; set; }

            /// <summary>
            /// Số lượng hàng đang ở kho khách hàng
            /// </summary>
            public int? QtyCustomer { get; set; }

            /// <summary>
            /// Số lượng hàng đã về kho công ty.
            /// </summary>
            public int? QtyCompany { get; set; }
        }

        /// <summary>
        /// Lớp đại diện cho thông tin chính của một khiếu nại.
        /// </summary>
        public class Complaints
        {
            /// <summary>
            /// Mã nghiệp vụ
            /// </summary>
            public string? FactorID { get; set; }

            /// <summary>
            /// Mã chức năng
            /// </summary>
            public string? EntryID { get; set; }

            /// <summary>
            /// Ngày CT
            /// </summary>
            public DateTime ODate { get; set; }

            /// <summary>
            /// Mã định danh trong hệ thống SAP.
            /// </summary>
            public string? SAPID { get; set; }

            /// <summary>
            /// Mã định danh trong hệ thống Lemon.
            /// </summary>
            public string? LemonID { get; set; }

            /// <summary>
            /// Mã khách hàng.
            /// </summary>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Mã tham chiếu của khiếu nại.
            /// </summary>
            public string? ReferenceID { get; set; }

            /// <summary>
            /// Mã loại yêu cầu khiếu nại.
            /// </summary>
            public int? RequestTypeID { get; set; }

            /// <summary>
            /// Nội dung chi tiết của khiếu nại.
            /// </summary>
            public string? Content { get; set; }

            /// <summary>
            /// Ghi chú bổ sung cho khiếu nại.
            /// </summary>
            public string? Note { get; set; }

            /// <summary>
            /// Liên kết tới tài liệu hoặc nguồn liên quan đến khiếu nại.
            /// </summary>
            public string? Link { get; set; }

            /// <summary>
            /// Trường mở rộng 1 để lưu trữ thông tin bổ sung.
            /// </summary>
            public string? Extention1 { get; set; }

            /// <summary>
            /// Trường mở rộng 2 để lưu trữ thông tin bổ sung.
            /// </summary>
            public string? Extention2 { get; set; }

            /// <summary>
            /// Trường mở rộng 3 để lưu trữ thông tin bổ sung.
            /// </summary>
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

            /// <summary>
            /// Trường mở rộng 20 để lưu trữ thông tin bổ sung.
            /// </summary>
            public string? Extention20 { get; set; }
        }

        /// <summary>
        /// Lớp đại diện cho chi tiết đơn hàng bán (Sales Order - SO) liên quan đến khiếu nại.
        /// </summary>
        public class ComplaintDetailSOs
        {
            /// <summary>
            /// ID của SO khi EDIT
            /// </summary>
            public int? ID { get; set; }// bổ sung
            /// <summary>
            /// Mã khiếu nại
            /// </summary>
            public string? OID { get; set; }

            /// <summary>
            /// Mã tham chiếu của đơn hàng
            /// </summary>
            public string? ReferenceID { get; set; }

            /// <summary>
            /// Mã tham chiếu của OD
            /// </summary>
            public string? ODReferenceID { get; set; }

            /// <summary>
            /// Mã tham chiếu phiếu điều xe ngoài
            /// </summary>
            public string? NotSOReferenceID { get; set; }

            /// <summary>
            /// Mã loại chứng từ
            /// </summary>
            public int? DocumentTypeID { get; set; }

            /// <summary>
            /// Mã loại chứng từ
            /// </summary>
            public int? DocumentNumberID { get; set; }

            /// <summary>
            /// Mã loại chứng từ
            /// </summary>
            public string? DocumentNote { get; set; }

            /// <summary>
            /// Số điện thoại đường dây nóng.
            /// </summary>
            public string? PhoneHotLine { get; set; }

            /// <summary>
            /// Tổ chức bán hàng.
            /// </summary>
            public string? SalesOrg { get; set; }

            /// <summary>
            /// Mã khu vực bán hàng.
            /// </summary>
            public int? SalesArea { get; set; }

            /// <summary>
            /// Mã vùng bán hàng.
            /// </summary>
            public int? SalesRegion { get; set; }

            /// <summary>
            /// Mã kênh bán hàng.
            /// </summary>
            public int? SalesChannelID { get; set; }

            /// <summary>
            /// Mã người dùng bán hàng.
            /// </summary>
            public string? SalesUserID { get; set; }

            /// <summary>
            /// Số lượng SO
            /// </summary>
            public decimal QtySO { get; set; }

            /// <summary>
            /// Số lượng sản phẩm trả lại.
            /// </summary>
            public decimal QtyReturn { get; set; }

            /// <summary>
            /// Số lượng sản phẩm lỗi.
            /// </summary>
            public decimal QtyFault { get; set; }

            /// <summary>
            /// Số lượng hàng đang ở kho khách hàng
            /// </summary>
            public decimal QtyAtCustomer { get; set; }

            /// <summary>
            /// Số lượng sản phẩm đã nhận.
            /// </summary>
            public decimal QtyReceived { get; set; }

            /// <summary>
            /// Giá trị lỗi của sản phẩm.
            /// </summary>
            public decimal FaultValue { get; set; }

            /// <summary>
            /// Ngày trả hàng.
            /// </summary>
            public DateTime ReturnDate { get; set; }

            /// <summary>
            /// Trường mở rộng 1 để lưu trữ thông tin bổ sung.
            /// </summary>
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
            public List<ComplaintDetailItems> ListItem { get; set; }
        }

        /// <summary>
        /// Lớp đại diện cho chi tiết các mục (items) trong khiếu nại.
        /// </summary>
        public class ComplaintDetailItems
        {
            /// <summary>
            /// ID item khi edit  
            /// </summary>
            public int? ID { get; set; }
            /// <summary>
            /// Mã sản phẩm.
            /// </summary>
            public int? ItemID { get; set; }

            /// <summary>
            /// Mã đơn vị ghi nhận.
            /// </summary>
            public int? RecordUnit { get; set; }

            /// <summary>
            /// Loại lỗi của mục hàng.
            /// </summary>
            public int? ErrorType { get; set; }
            /// <summary>
            /// Bộ phận ghi nhận lỗi
            /// </summary>
            public int? ErrorDepartmentID { get; set; }
            /// <summary>
            /// Giá trị hàng lỗi 
            /// </summary>
            public decimal FaultValue { get; set; }

            /// <summary>
            /// Mô tả chi tiết lỗi của mục hàng.
            /// </summary>
            public string? ErrorDescription { get; set; }

            /// <summary>
            /// Số lượng sản phẩm lỗi.
            /// </summary>
            public int? ErrorQuantity { get; set; }

            /// <summary>
            /// Số lượng sản phẩm đã đặt hàng.
            /// </summary>
            public int? OrderedQuantity { get; set; }
             
            /// <summary>
            /// chi tiết lỗi 
            /// </summary>
            public string? ItemErrorDescription { get; set; }

            /// <summary>
            /// Mã phòng ban chuyển tiếp xử lý.
            /// </summary>
            public int? ForwardDeptID { get; set; }

            /// <summary>
            /// Ngày bắt đầu yêu cầu xử lý.
            /// </summary>
            public DateTime RequestFromDate { get; set; }

            /// <summary>
            /// Ngày kết thúc yêu cầu xử lý.
            /// </summary>
            public DateTime RequestToDate { get; set; }

            /// <summary>
            /// Liên kết tới tài liệu hoặc nguồn liên quan.
            /// </summary>
            public string? Link { get; set; }
            
            // Field để chứa JSON list ERRORs
            public string? ItemListErrors { get; set; }
            /// <summary>
            /// .Danh sách chi tiết lỗi 
            /// </summary>
            public List<ErrorItem> ListErrors { get; set; }

            /// <summary>
            /// Trường mở rộng 1 để lưu trữ thông tin bổ sung.
            /// </summary>
            /// 
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
        /// Lớp đại diện cho chi tiết các tác vụ liên quan đến khiếu nại.
        /// </summary>
        public class ComplaintDetailTasks
        {
            /// <summary>
            /// Mã của khiếu nại
            /// </summary>
            public string? OID { get; set; }

            /// <summary>
            /// Mã sản phẩm
            /// </summary>
            public int? ItemID { get; set; }
            /// <summary>
            /// lưu id Task
            /// </summary>
            public int? TaskID { get; set; }
            /// <summary>
            /// Loại tác vụ. Business(kinh doanh),  Factory(nhà máy), Action(hành động)
            /// </summary>
            public string? TaskType { get; set; }

            /// <summary>
            /// Nhóm mã tác vụ.
            /// </summary>
            public string? TaskCodeGroup { get; set; }

            /// <summary>
            /// Mã tác vụ.
            /// </summary>
            public string? TaskCode { get; set; }

            /// <summary>
            /// Mô tả ngắn gọn của mã tác vụ.
            /// </summary>
            public string? TaskCodeText { get; set; }

            /// <summary>
            /// Mô tả chi tiết của tác vụ.
            /// </summary>
            public string? TaskText { get; set; }

            /// <summary>
            /// Ngày bắt đầu thực hiện tác vụ.
            /// </summary>
            public DateTime TaskFromDate { get; set; }

            /// <summary>
            /// Ngày kết thúc thực hiện tác vụ.
            /// </summary>
            public DateTime TaskToDate { get; set; }

            /// <summary>
            /// Mã trạng thái của tác vụ.
            /// </summary>
            public int? TaskStatusID { get; set; }

            /// <summary>
            /// Thời gian cập nhật trạng thái tác vụ.
            /// </summary>
            public DateTime TaskStatusTime { get; set; }

            /// <summary>
            /// Mã người dùng thực hiện tác vụ.
            /// </summary>
            public string? TaskUserID { get; set; }

            /// <summary>
            /// Liên kết tới tài liệu hoặc nguồn liên quan đến tác vụ.
            /// </summary>
            public string? TaskLink { get; set; }

            /// <summary>
            /// Mã kho xuất hàng.
            /// </summary>
            public int? TaskExportWarehouseID { get; set; }

            /// <summary>
            /// Mã mục hàng xuất kho.
            /// </summary>
            public int? TaskExportItemID { get; set; }

            /// <summary>
            /// Số lượng xuất kho cho tác vụ.
            /// </summary>
            public decimal TaskExportQuantity { get; set; }
            /// <summary>
            /// Đơn vị tính
            /// </summary>
            public int? TaskUnitID { get; set; }
            /// <summary>
            /// Ghi chú
            /// </summary>
            public string? Note { get; set; }

            /// <summary>
            /// Trường mở rộng 1 để lưu trữ thông tin bổ sung.
            /// </summary>
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
        /// Lớp dùng để thêm mới một khiếu nại.
        /// </summary>
        public class Add : Complaints
        {
        }

        /// <summary>
        /// Lớp dùng để chỉnh sửa thông tin một khiếu nại.
        /// </summary>
        public class Edit : Complaints
        {
            /// <summary>
            /// Mã định danh duy nhất của khiếu nại cần chỉnh sửa.
            /// </summary>
            public string? OID { get; set; }
        }

        /// <summary>
        /// Lớp dùng để thêm mới một đơn hàng bán (SO).
        /// </summary>
        public class AddProfile : ComplaintDetailSOs
        {
        }
      
        /// <summary>
        /// Lớp dùng để xóa một đơn hàng bán (SO).
        /// </summary>
        public class DeleteProfile
        {
            /// <summary>
            /// ID của SO 
            /// </summary>
            public int? ID { get; set; }
        }


        /// <summary>
        /// Xác nhận hồ sơ ()
        /// </summary>
        public class SubmitProfile
        {
            /// <summary>
            /// Mã khiếu nại 
            /// </summary>
            public string? OID { get; set; }
            /// <summary>
            /// Mã đơn hàng
            /// </summary>
            public string? ReferenceID { get; set; }
        }
          
        /// <summary>
        /// Lớp đại diện cho thông tin tiếp nhận mục khiếu nại.
        /// </summary>
        public class ReceptionItem
        {
            /// <summary>
            /// ID của Item 
            /// </summary>
            public int? ID { get; set; }
            /// <summary>
            /// Quyết định phản hồi cho khiếu nại.
            /// </summary>
            public int? ResponseDecision { get; set; }

            /// <summary>
            /// Mã phòng ban phản hồi.
            /// </summary>
            public int? ResponseDeptID { get; set; }

            /// <summary>
            /// Mã người dùng phản hồi.
            /// </summary>
            public int? ResponseUserID { get; set; }

            /// <summary>
            /// Ngày bắt đầu phản hồi.
            /// </summary>
            public DateTime ResponseFromDate { get; set; }

            /// <summary>
            /// Ngày kết thúc phản hồi.
            /// </summary>
            public DateTime ResponseToDate { get; set; }

            /// <summary>
            /// Nội dung phản hồi.
            /// </summary>
            public string? RepsoneContent { get; set; }

            /// <summary>
            /// Liên kết tới tài liệu hoặc nguồn liên quan đến phản hồi.
            /// </summary>
            public string? ResponseLink { get; set; }
        }

        /// <summary>
        /// Lớp đại diện cho thông tin phản hồi cho mục khiếu nại.
        /// </summary>
        public class ResponseItem
        {
            /// <summary>
            /// ID của Item 
            /// </summary>
            public int? ID { get; set; }

            /// <summary>
            /// Trạng thái phản hồi.
            /// </summary>
            public string? ResponseStatus { get; set; }

            /// <summary>
            /// Giải pháp phản hồi.
            /// </summary>
            public string? ResponseSolution { get; set; }

            /// <summary>
            /// Liên kết mở rộng 1 cho phản hồi.
            /// </summary>
            public string? ResponseLinkExtention1 { get; set; }
        }

        /// <summary>
        /// Lớp đại diện cho thông tin xử lý mục khiếu nại.
        /// </summary>
        public class ProcessItem
        {
            public int? ID { get; set; }
            /// <summary>
            /// Mã mức độ ưu tiên xử lý.
            /// </summary>
            public int? PriorityID { get; set; }

            /// <summary>
            /// Chỉ số đánh dấu mức độ nghiêm trọng (0: không nghiêm trọng, 1: nghiêm trọng).
            /// </summary>
            public int? IsSerious { get; set; }

            /// <summary>
            /// Ngày bắt đầu xử lý.
            /// </summary>
            public DateTime ProcessFromDate { get; set; }

            /// <summary>
            /// Ngày kết thúc xử lý.
            /// </summary>
            public DateTime ProcessToDate { get; set; }

            /// <summary>
            /// Mô tả quy trình xử lý.
            /// </summary>
            public string? ProcessDescription { get; set; }

            /// <summary>
            /// Mã phòng ban xử lý.
            /// </summary>
            public int? ProcessDeptID { get; set; }

            /// <summary>
            /// Ngày xử lý.
            /// </summary>
            public DateTime ProcessDate { get; set; }

            /// <summary>
            /// Mã người dùng xử lý.
            /// </summary>
            public int? ProcessUserID { get; set; }

            /// <summary>
            /// Chỉ số đánh dấu có thuộc quy trình Q4 hay không (0: không, 1: có).
            /// </summary>
            public int? IsQ4 { get; set; }

            /// <summary>
            /// Chỉ số đánh dấu có thuộc quy trình Q5 hay không (0: không, 1: có).
            /// </summary>
            public int? IsQ5 { get; set; }

            /// <summary>
            /// Chỉ số đánh dấu có phí xử lý hay không (0: không, 1: có).
            /// </summary>
            public int? IsHasFee { get; set; }

            public List<ComplaintDetailTasks> ListTask { get; set; } 
        }

        public class ProcessFeedback
        {
            /// <summary>
            /// ID của Item 
            /// </summary>
            public int? ID { get; set; }
            
            /// <summary>
            /// Nội dung kết quả xử lý.
            /// </summary>
            public string? ResultContent { get; set; }

            /// <summary>
            /// Liên kết tới tài liệu hoặc nguồn liên quan đến kết quả xử lý.
            /// </summary>
            public string? ResultLink { get; set; }
        }

        /// <summary>
        /// Lớp dùng để lấy thông tin khiếu nại theo mã OID.
        /// </summary>
        public class GetByOID
        {
            /// <summary>
            /// Mã định danh duy nhất của khiếu nại.
            /// </summary>
            public string? OID { get; set; }
            /// <summary>
            /// Mã vận đơn lọc sản phẩm theo vận đơn 
            /// </summary>
            public string? ReferenceID { get; set; }

        }

        public class GetByCusID
        {
            /// <summary>
            /// Mã khách hàng
            /// </summary>
            public int? CustomerID { get; set; }
            /// <summary>
            /// Mã chức năng cần tham chiếu trước đó
            /// </summary>
            public string? EntryID { get; set; }
        }

        /// <summary>
        /// Lớp dùng để lấy danh sách đơn hàng bán theo mã khách hàng.
        /// </summary>
        public class GetSOByCusID
        {
            /// <summary>
            /// Mã định danh của khách hàng.
            /// </summary>
            public int? CustomerID { get; set; }
        }
        /// <summary>
        /// Lấy danh sách vận đơn
        /// </summary>
        public class GetODBySo
        {
            /// <summary>
            /// Mã định danh của khách hàng.
            /// </summary>
            public string? ReferenceID { get; set; }
        }

        /// <summary>
        /// Lớp dùng để xóa một khiếu nại.
        /// </summary>
        public class Del : GetByOID
        {
        }

        /// <summary>
        /// Lớp dùng để gửi (submit) một khiếu nại.
        /// </summary>
        public class Submit : GetByOID
        {
            /// <summary>
            /// Trạng thái khóa của khiếu nại (0: không khóa, 1: khóa).
            /// </summary>
            public int? IsLock { get; set; } 
        }

        /// <summary>
        /// Lớp dùng để lấy thông tin khiếu nại theo mã ID.
        /// </summary>
        public class GetByID
        {
            /// <summary>
            /// Mã định danh của khiếu nại.
            /// </summary>
            public int? ID { get; set; }
        }

        /// <summary>
        /// Lớp dùng để cập nhật đánh giá cho khiếu nại.
        /// </summary>
        public class UpdateRating : GetByOID
        {
            /// <summary>
            /// Điểm đánh giá (rating) của khiếu nại.
            /// </summary>
            public int? Ratting { get; set; }

            /// <summary>
            /// Nội dung đánh giá.
            /// </summary>
            public string? RateContent { get; set; }

            /// <summary>
            /// Liên kết tới tài liệu hoặc nguồn liên quan đến đánh giá.
            /// </summary>
            public string? RateLink { get; set; }
        }

        /// <summary>
        /// Lớp dùng để cập nhật trạng thái đóng khiếu nại.
        /// </summary>
        public class UpdateClose : GetByOID
        {
            /// <summary>
            /// Trạng thái đóng hồ sơ của khiếu nại (0: chưa đóng, 1: đã đóng).
            /// </summary>
            public int? IsClose { get; set; }
        }

        /// <summary>
        /// Lớp dùng để cập nhật nội dung yêu cầu của khiếu nại.
        /// </summary>
        public class UpdateRequest : GetByOID
        {
            /// <summary>
            /// Tiếp nhận đồng ý/ từ chối (1/-1)
            /// </summary>
            public int? RequestDecision { get; set; }
            
            /// <summary>
            /// Nội dung yêu cầu cập nhật.
            /// </summary>
            public string? RequestContent { get; set; }

            /// <summary>
            /// Ghi chú bổ sung cho yêu cầu.
            /// </summary>
            public string? RequestNote { get; set; }
            /// <summary>
            /// Link hình ảnh file đính kèm 
            /// </summary>
            public string? RequestLink { get; set; }
        }

        /// <summary>
        /// Lớp dùng để cập nhật phản hồi cho khiếu nại.
        /// </summary>
        public class UpdateResponse : GetByOID
        {
            /// <summary>
            /// Nội dung phản hồi cập nhật.
            /// </summary>
            public string? ResponseContent { get; set; }

            /// <summary>
            /// Ghi chú bổ sung cho phản hồi.
            /// </summary>
            public string? ResponseNote { get; set; }

            public string? ResponseLink { get; set; }
        }
    }
}