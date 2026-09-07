namespace APISmartCity.Models.TMS
{
    public static class ReceiveShipRequests
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2022-10-07</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Người liên hệ
                /// </summary>
                /// <example>226</example>
                public string? CustomerContactsName { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>NLT@gmail.com</example>
                public string? Email { get; set; }

                /// <summary>
                /// Sđt
                /// </summary>
                /// <example>0909092222</example>
                public string? Phone { get; set; }

                /// <summary>
                /// ID loại hàng
                /// </summary>
                /// <example>7</example>
                public int? OrderTypeID { get; set; }

                /// <summary>
                /// ID đơn vị tính
                /// </summary>
                /// <example>388</example>
                public int? nPLUnitsID { get; set; }

                /// <summary>
                /// ID loại hàng
                /// </summary>
                /// <example>12</example>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// số lượng
                /// </summary>
                /// <example>1</example>
                public int? Quantity { get; set; }

                /// <summary>
                /// sô lượng cont 20
                /// </summary>
                /// <example>1</example>
                public int? Cont20Quantity { get; set; }

                /// <summary>
                /// Số lượng cont 40
                /// </summary>
                /// <example>1</example>
                public int? Cont40Quantity { get; set; }

                /// <summary>
                /// Trọng lượng
                /// </summary>
                /// <example>10</example>
                public int? Weight { get; set; }

                /// <summary>
                /// Thông tin điểm lấy
                /// </summary>
                /// <example>Cát lái</example>
                public string? BeginAddressInfo { get; set; }

                /// <summary>
                /// Thông tin điểm trả
                /// </summary>
                /// <example>Kho Ðại Nhất – Bến Tre</example>
                public string? EndAddressInfo { get; set; }

                /// <summary>
                /// Thời gian yêu cầu lấy
                /// </summary>
                /// <example>Oct 1 2022 12:00AM</example>
                public string? RequestTimeTake { get; set; }

                /// <summary>
                /// Thời gian yêu cầu trả
                /// </summary>
                /// <example>Jan 1 1900 12:00AM</example>
                public string? RequestTimeBack { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>TEST LAN 1</example>
                public string? Note { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example>TEST LAN 1</example>
                public string? Link { get; set; }
                /// <summary>
                /// ID khách hàng
                /// </summary>
                /// <example>0</example>
                public int? nPLCustomersID { get; set; }

                /// <summary>
                /// Khách hàng
                /// </summary>
                /// <example>Công Ty Test</example>
                public string? CustomerName { get; set; }

                /// <summary>
                /// ID người liên hệ
                /// </summary>
                /// <example>0</example>
                public int? ContactID { get; set; }
            }

            public class Get : Content
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>RC_SHIPREQUETS</example>
                public string? EntryID { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

            public class AddMobile : Content
            {
            }

            public class EditMobile : Content
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

            public class Cancel
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Id của lý do hủy
                /// </summary>
                /// <example>1</example>
                public int? IDCancel { get; set; }

                /// <summary>
                /// StatusNote
                /// </summary>
                /// <example>Lý do hủy bỏ (nếu có)</example>
                public string? StatusNote { get; set; }
            }

            public class CoordinatorProcess : Cancel
            {
                /// <summary>
                /// Đồng ý là 1, từ chối 0
                /// </summary>
                /// <example>1</example>
                public string? IsApproval { get; set; }
            }

            public class SaleProcess
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Id của lý do hủy
                /// </summary>
                /// <example>1</example>
                public int? IDCancelReply { get; set; }

                /// <summary>
                /// StatusNote
                /// </summary>
                /// <example>Lý do hủy bỏ (nếu có)</example>
                public string? StatusReplyNote { get; set; }

                /// <summary>
                /// Đồng ý là 1, từ chối 0
                /// </summary>
                /// <example>1</example>
                public string? IsApprovalReply { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Submit
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

            public class GetContactByCusID
            {
                /// <summary>
                /// Mã khách hàng đang chọn
                /// </summary>
                /// <example>1</example>
                public string? CusIDSelect { get; set; }
            }
        }

        public class Response
        {
        }
    }
}