namespace APISmartCity.Models.TMS
{
    public static class ShippingsHandovers
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>2022/12/26</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Mã khách hàng
                /// </summary>
                /// <example>2</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Mã vùng
                /// </summary>
                /// <example>TT</example>
                public string? HandOverKey { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                public List<Details> Details { get; set; }
            }

            public class Details
            {
                /// <summary>
                /// Mã vận đơn
                /// </summary>
                /// <example>VD/23/04/00071</example>
                public string? ShippingOID { get; set; }

                /// <summary>
                /// Mã đơn hàng
                /// </summary>
                /// <example>ÐHR/23/04/00027</example>
                public string? SaleContractOID { get; set; }
            }

            public class GetDetails
            {
                /// <summary>
                /// Mã khách hàng
                /// </summary>
                /// <example>2</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Mã vùng
                /// </summary>
                /// <example>TT</example>
                public string? HandOverKey { get; set; }
            }

            public class HandOver
            {
                /// <summary>
                /// Mã vùng
                /// </summary>
                /// <example>TT</example>
                public string? HandOverKey { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXGVC/02/12/2022/001</example>
                public string? OID { get; set; }
            }

            public class EditDeliver : GetByID
            {
                /// <summary>
                /// Ghi chú bàn giao
                /// </summary>
                /// <example>Ghi chú bàn giao</example>
                public string? DeliverNote { get; set; }
            }

            public class EditReceive : GetByID
            {
                /// <summary>
                /// Ghi chú tiếp nhận
                /// </summary>
                /// <example>Ghi chú tiếp nhận</example>
                public string? ReceiveNote { get; set; }
            }

            public class Receive : GetByID
            {
                /// <summary>
                /// Có tiếp nhận hay không?
                /// </summary>
                /// <example>1</example>
                public int? IsReceive { get; set; }
            }

            public class Deliver : GetByID
            {
                /// <summary>
                /// Khóa hoặc mở khóa
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Submit : GetByID
            {
                /// <summary>
                /// Khóa hoặc mở khóa
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }
            public class GetByIDDetail
            {
                /// <summary>
                /// IDDetails
                /// </summary>
                /// <example>click vào dòng nào, lấy ID dòng đó</example>
                public int? IDDetail { get; set; }

                /// <summary>
                /// Lấy OID truyền vào
                /// </summary>
                /// <example>BK/01291379</example>
                public string? HandOverID { get; set; }
            }

            public class GetByCustomerID
            {
                /// <summary>
                /// ID Khach hang
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }
            }

            public class AddDetailInvoice
            {
                /// <summary>
                /// click vào dòng nào, lấy ID dòng đó
                /// </summary>
                /// <example>10</example>
                public int? IDDetail { get; set; }

                /// <summary>
                /// OID của lần bàn giao
                /// </summary>
                /// <example>BG019834718</example>
                public string? HandOverID { get; set; }

                /// <summary>
                /// OID của lần bàn giao
                /// </summary>
                /// <example>BG019834718</example>
                public string? DataType { get; set; }

                public List<DetailsInvoice> DetailsInvoice { get; set; }
            }

            public class DetailsInvoice
            {
                /// <summary>
                /// Mã cty xuất hóa đơn
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// TotalAmnt
                /// </summary>
                /// <example>10000000</example>
                public decimal TotalAmnt { get; set; }

                /// <summary>
                /// Ghi chú nếu cần
                /// </summary>
                /// <example>Ghi chú nha</example>
                public string? Note { get; set; }

                /// <summary>
                /// OID của lần bàn giao
                /// </summary>
                /// <example>BG019834718</example>
                public string? DataType { get; set; }
            }
        }
    }
}