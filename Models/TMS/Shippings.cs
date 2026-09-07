namespace APISmartCity.Models.TMS
{
    public static class Shippings
    {
        public static class Request
        {
            public class Approval
            {
                /// <summary>
                /// Đồng ý là 1, từ chối 0
                /// </summary>
                /// <example>1</example>
                public string? IsApproval { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Id của lý do hủy
                /// </summary>
                /// <example>1</example>
                public int? IDCancelApproval { get; set; }

                /// <summary>
                /// StatusNote
                /// </summary>
                /// <example>Lý do hủy bỏ (nếu có)</example>
                public string? StatusNoteApproval { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }
            public class GetPriceByOutSide
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public int? OutSideID { get; set; }
            }

            public class EditLicensePlates
            {
                /// <summary>
                /// ShippingID
                /// </summary>
                /// <example>106</example>
                public string? ShippingID { get; set; }

                /// <summary>
                /// LicensePlates
                /// </summary>
                /// <example>51C 12345</example>
                public string? LicensePlates { get; set; }
            }

            public class DelByID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
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

            public class GetVehicleByDepotID
            {
                /// <summary>
                /// DepotID địa điểm lấy hàng/giao hàng
                /// </summary>
                /// <example>492</example>
                public string? DepotID { get; set; }

                /// <summary>
                /// List các OID đơn hàng đang điều phối
                /// </summary>
                /// <example>ÐHCN/23/03/034;ÐHCN/23/03/015</example>
                public string? ListOID { get; set; }
            }

            public class GetByDriverID
            {
                /// <summary>
                /// Driver - ID của tài xế
                /// </summary>
                /// <example>50</example>
                public int? DriverID { get; set; }
            }

            public class Getcache
            {
                /// <summary>
                /// List string point
                /// </summary>
                /// <example>[10.76239,106.77716],[10.76239,106.77716],[10.76239,106.77716]</example>
                public string? StringPoint { get; set; }
            }

            public class GetDepotContract
            {
                /// <summary>
                /// List các OID đơn hàng đang điều phối
                /// </summary>
                /// <example>ÐHCN/23/03/034;ÐHCN/23/03/015</example>
                public string? ListOID { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>VD/23/03/0001</example>
                public string? OID { get; set; }
            }

            public class AddCont
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>DH/23/03/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// ContCode
                /// </summary>
                /// <example>120183103</example>
                public string? ContCode { get; set; }

                /// <summary>
                /// ContNumb
                /// </summary>
                /// <example>120112283103</example>
                public string? ContNumb { get; set; }

                /// <summary>
                /// ContSeal
                /// </summary>
                /// <example>12011Aa103</example>
                public string? ContSeal { get; set; }

                /// <summary>
                /// ContSeal
                /// </summary>
                /// <example>20</example>
                public int? ContLength { get; set; }
            }

            public class GetByReferenceID
            {
                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? ReferenceID { get; set; }
            }

            public class ContentRealMeal
            {
                /// <summary>
                /// Ngày
                /// </summary>
                /// <example>2023/01/01</example>
                public string? Odate { get; set; }

                /// <summary>
                /// p.c cho ngày gì
                /// </summary>
                /// <example>1,2</example>
                public string? AllowanceMealType { get; set; }

                /// <summary>
                /// Số tiền phụ cấp
                /// </summary>
                /// <example>120000</example>
                public decimal AllowanceMeal { get; set; }


                public decimal BasicSalary { get; set; }
                /// <summary>
                /// EntryName
                /// </summary>
                /// <example>Ngày trả hàng</example>
                public string? EntryName { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>120000</example>
                public string? Note { get; set; }

                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>VD/001</example>
                public string? OID { get; set; }
            }

            public class EditRealMeal : ContentRealMeal
            {
                public int? ID { get; set; }
                
            }

            public class GetByOIDAndReferenceID : GetByOID
            {
                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? ReferenceID { get; set; }
            }

            public class GetByViewAppRoval : GetByOID
            {
                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? FeeType { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// ID dữ liệu chi phí phát sinh
                /// </summary>
                /// <example>10</example>
                public int? ID { get; set; }
            }

            public class DriverUpdate
            {
                /// <summary>
                /// ID shipping
                /// </summary>
                /// <example>10</example>
                public int? ShippingID { get; set; }

                /// <summary>
                /// Status xác nhận
                /// </summary>
                /// <example>10</example>
                public int? ShippingStatus { get; set; }

                /// <summary>
                /// Text của nút xác nhận
                /// </summary>
                /// <example>10</example>
                public string? ShipActionNote { get; set; }

                /// <summary>
                /// Upload ảnh, file lên máy chủ và lấy link gửi vào đây (nếu có)
                /// </summary>
                /// <example>data.pdf</example>
                public string? FileLink { get; set; }
            }

            public class ContentByIncurreds
            {
                /// <summary>
                /// Mã vận đơn
                /// </summary>
                /// <example>VD/23/03/011</example>
                public string? OID { get; set; }

                /// <summary>
                /// Mã chi phí
                /// </summary>
                /// <example>10</example>
                public int? FeeID { get; set; }

                /// <summary>
                /// Số tiền đề xuất
                /// </summary>
                /// <example>500000</example>
                public decimal RequestMoney { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>.</example>
                public string? Note { get; set; }

                /// <summary>
                /// Check có VAT or ko VAT
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Số lượng
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Mã đơn vị tính
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Đơn giá
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Upload ảnh, file lên máy chủ và lấy link gửi vào đây (nếu có)
                /// </summary>
                /// <example>data.pdf</example>
                public string? FileLink { get; set; }
            }

            public class AddFeeByIncurreds : ContentByIncurreds
            {
            }

            public class AddFeeByIncurredsVer2 : ContentByIncurreds
            {
                /// <summary>
                /// Tính cho tài xế
                /// </summary>
                /// <example>0</example>
                public int? IsAddByDriver { get; set; }
            }

            public class AddRevByIncurreds : ContentByIncurreds
            {
                /// <summary>
                /// Mã đơn hàng
                /// </summary>
                /// <example>ĐHR/23/03/008</example>
                public string? ReferenceID { get; set; }
            }

            public class ApprovalByIncurreds
            {
                /// <summary>
                /// Đồng ý là 1, từ chối 0
                /// </summary>
                /// <example>1</example>
                public string? IsApproval { get; set; }

                /// <summary>
                /// ID Phí/Doanh thu phát sinh
                /// </summary>
                /// <example>10</example>
                public int? ID { get; set; }

                /// <summary>
                /// Số tiền duyệt
                /// </summary>
                /// <example>300000</example>
                public decimal ApprovalMoney { get; set; }

                /// <summary>
                /// nếu từ chối thì nhập lý do từ chối
                /// </summary>
                /// <example>Kho báo 50k</example>
                public string? ApprovalNote { get; set; }

                /// <summary>
                /// Số tiền cty npl trả
                /// </summary>
                /// <example>200000</example>
                public decimal Extention1 { get; set; }

                /// <summary>
                /// Số tiền khách hàng trả
                /// </summary>
                /// <example>100000</example>
                public decimal Extention2 { get; set; }

                /// <summary>
                /// Mã đơn hàng
                /// </summary>
                /// <example>ĐHR/23/03/008</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Có hóa đơn VAT không ?
                /// </summary>
                public int? HasVATInvoice { get; set; }

            }

            public class MultipleApproval
            {
                /// <summary>
                /// Đồng ý là 1, từ chối 0
                /// </summary>
                /// <example>1</example>
                public string? IsApproval { get; set; }

                /// <summary>
                /// ID Phí/Doanh thu phát sinh
                /// </summary>
                /// <example>10,11,12</example>
                public string? MultipleID { get; set; }

                /// <summary>
                /// nếu từ chối thì nhập lý do từ chối
                /// </summary>
                /// <example>Kho báo 50k</example>
                public string? ApprovalNote { get; set; }
            }

            public class GetByTypeList
            {
                /// <summary>
                /// WaitingApproval, Received, Shipping, Finish
                /// </summary>
                /// <example>WaitingApproval</example>
                public string? Type { get; set; }
            }

            public class GetByDetails
            {
                /// <summary>
                /// Mã vận đơn
                /// </summary>
                /// <example>VD/23/003/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Mã đơn hàng
                /// </summary>
                /// <example>ĐHR/23/03/008</example>
                public string? ReferenceID { get; set; }
            }

            public class ShippingEdit : GetByDetails
            {
                /// <summary>
                /// Ngày thực chạy
                /// </summary>
                /// <example>2023/01/31</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Số lượng
                /// </summary>
                /// <example>12</example>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Trọng lượng
                /// </summary>
                /// <example>30</example>
                public decimal Weight { get; set; }

                /// <summary>
                /// ID cont 20 - 01
                /// </summary>
                /// <example>1</example>
                public int? CodeCont20_01 { get; set; }

                /// <summary>
                /// ID cont 20 - 02
                /// </summary>
                /// <example>2</example>
                public int? CodeCont20_02 { get; set; }

                /// <summary>
                /// ID cont 40
                /// </summary>
                /// <example>3</example>
                public int? CodeCont40 { get; set; }

                /// <summary>
                /// Đã nhận chứng từ 0: chưa nhận, 1: Đã nhận, 2: Không có chứng từ
                /// </summary>
                /// <example>1</example>
                public int? IsReceiveDoc { get; set; }

                /// <summary>
                /// Lương tài xế
                /// </summary>
                /// <example>300000</example>
                public decimal SalaryDriver { get; set; }

                /// <summary>
                /// Phí khoán
                /// </summary>
                /// <example>300000</example>
                public decimal FeePackage { get; set; }

                /// <summary>
                /// Phí khác
                /// </summary>
                /// <example>300000</example>
                public decimal FeeOther { get; set; }

                /// <summary>
                /// Phụ cấp cơm
                /// </summary>
                /// <example>300000</example>
                public decimal AllowanceMeal { get; set; }

                /// <summary>
                /// Phụ cấp cẩu
                /// </summary>
                /// <example>300000</example>
                public decimal AllowanceCrane { get; set; }

                /// <summary>
                /// Phụ cấp phủ bạt
                /// </summary>
                /// <example>300000</example>
                public decimal AllowanceTarpaulin { get; set; }

                /// <summary>
                /// Phụ cấp lơ xe
                /// </summary>
                /// <example>300000</example>
                public decimal AllowanceDriverHelper { get; set; }

                /// <summary>
                /// Phụ cấp quá tải
                /// </summary>
                /// <example>300000</example>
                public decimal AllowanceOverLoad { get; set; }

                /// <summary>
                /// Quy đổi chuyến
                /// </summary>
                /// <example>1</example>
                public decimal QuantityShip { get; set; }

                /// <summary>
                /// Số chuyến thực tính
                /// </summary>
                /// <example>1</example>
                public decimal QuantityReal { get; set; }

                /// <summary>
                /// Quy đổi chuyến
                /// </summary>
                /// <example>1</example>
                public decimal QuantityDriverShip { get; set; }

                /// <summary>
                /// Tổng chuyến trong tháng
                /// </summary>
                /// <example>20</example>
                public decimal TotalShip { get; set; }

                /// <summary>
                /// Phụ cấp trên 35 chuyến
                /// </summary>
                /// <example>20</example>
                public decimal AllowanceTotalShip { get; set; }

                /// <summary>
                /// Phụ cấp hàng lẻ
                /// </summary>
                /// <example>50000</example>
                public decimal AllowanceRetail { get; set; }

                /// <summary>
                /// Phụ cấp khác
                /// </summary>
                /// <example>100000</example>
                public decimal AllowanceOther { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note cập nhật</example>
                public string? Note { get; set; }
            }

            public class GetByDetailsByOID
            {
                /// <summary>
                /// Mã vận đơn
                /// </summary>
                /// <example>VD/23/003/0001</example>
                public string? OID { get; set; }
            }

            public class FeeLOLOContents : GetByDetails
            {
                /// <summary>
                /// Mã phí
                /// </summary>
                /// <example>21628</example>
                public int? FeeID { get; set; }

                /// <summary>
                /// Mã cont
                /// </summary>
                /// <example>32</example>
                public int? ContID { get; set; }

                /// <summary>
                /// Mã DepotID
                /// </summary>
                /// <example>21540</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// Ký hiệu và số hóa đơn
                /// </summary>
                /// <example>TC18P-012345</example>
                public string? InvoiceCode { get; set; }

                /// <summary>
                /// Số tiền
                /// </summary>
                /// <example>15000000</example>
                public decimal InvoiceTotal { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// link File, upload lên server trước rồi lấy link submit vào đây
                /// </summary>
                /// <example>htpps://file.pdf</example>
                public string? LinkFile { get; set; }

                /// <summary>
                /// Có phải bổ sung?
                /// </summary>
                /// <example>0</example>
                public int? IsAdditional { get; set; }
            }

            public class AddFeeLOLO : FeeLOLOContents
            {
            }

            public class EditFeeLOLO : FeeLOLOContents
            {
                /// <summary>
                /// ID Phí đã thêm
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class EditCTGCL
            {
                /// <summary>
                /// Mã vận đơn
                /// </summary>
                /// <example>VD/23/003/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Trạng thái CTG CL
                /// </summary>
                /// <example>1</example>
                public int? IsReceiveDocCL { get; set; }
            }

            public class DelFeeLOLO
            {
                /// <summary>
                /// ID Phí đã thêm
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class GetByCusID
            {
                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>1</example>
                public string? CustomerID { get; set; }
            }

            public class AddDepot
            {
                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>1</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>1</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// ContactName
                /// </summary>
                /// <example>1</example>
                public string? ContactName { get; set; }

                /// <summary>
                /// ContactPhone
                /// </summary>
                /// <example>1</example>
                public string? ContactPhone { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>1</example>
                public string? Request { get; set; }

                /// <summary>
                /// Lat
                /// </summary>
                /// <example>1</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Long
                /// </summary>
                /// <example>1</example>
                public string? Long { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
            }

            public class AddInvoice
            {
                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Tên công ty xuất hóa đơn
                /// </summary>
                /// <example>1</example>
                public string? CmpnName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>1</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Mã số thuế
                /// </summary>
                /// <example>1</example>
                public string? TaxCode { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
            }

            public class Content
            {
                /// <summary>
                /// Ngày thực chạy
                /// </summary>
                /// <example>2023/09/01</example>
                public string? Odate { get; set; }

                /// <summary>
                /// Mã tài xế
                /// </summary>
                /// <example>1</example>
                public int? DriverID { get; set; }

                /// <summary>
                /// Số xe
                /// </summary>
                /// <example>07947-51D</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// Có quá tải?
                /// </summary>
                /// <example>1</example>
                public int? IsOverload { get; set; }

                /// <summary>
                /// IsOverETA
                /// </summary>
                /// <example>1</example>
                public int? IsOverETA { get; set; }

                /// <summary>
                /// IsOverETD
                /// </summary>
                /// <example>1</example>
                public int? IsOverETD { get; set; }

                /// <summary>
                /// IsWrongRoute
                /// </summary>
                /// <example>1</example>
                public int? IsWrongRoute { get; set; }

                /// <summary>
                /// IsNeckpair
                /// </summary>
                /// <example>1</example>
                public int? IsNeckpair { get; set; }

                /// <summary>
                /// IsJoinContract
                /// </summary>
                /// <example>1</example>
                public int? IsJoinContract { get; set; }

                /// <summary>
                /// IsJoinTripBefor
                /// </summary>
                /// <example>1</example>
                public int? IsJoinTripBefor { get; set; }

                /// <summary>
                /// TotalContract
                /// </summary>
                /// <example>1</example>
                public int? TotalContract { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example>1</example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Nếu thuê ngoài thì = 1, nội bộ = 0
                /// </summary>
                /// <example>0</example>
                public int? IsOutSide { get; set; }

                /// <summary>
                /// ID nhà cung cấp xe thuê ngoài
                /// </summary>
                /// <example>1</example>
                public int? OutSideID { get; set; }

                /// <summary>
                /// List string point
                /// </summary>
                /// <example>[10.76239,106.77716],[10.76239,106.77716],[10.76239,106.77716]</example>
                public string? StringPoint { get; set; }

                /// <summary>
                /// List string point
                /// </summary>
                /// <example>[10.76239,106.77716],[10.76239,106.77716],[10.76239,106.77716]</example>
                public string? StringPointRoot { get; set; }

                /// <summary>
                /// Details
                /// </summary>
                public List<Details> Details { get; set; }
            }

            public class Details
            {
                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example>1</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// ShipType
                /// </summary>
                /// <example>1</example>
                public string? ShipType { get; set; }

                /// <summary>
                /// ShipID
                /// </summary>
                /// <example>1</example>
                public int? ShipID { get; set; }

                /// <summary>
                /// Quantity
                /// </summary>
                /// <example>1</example>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Weight
                /// </summary>
                /// <example>1</example>
                public decimal Weight { get; set; }

                /// <summary>
                /// CodeCont20_01
                /// </summary>
                /// <example>1</example>
                public string? CodeCont20_01 { get; set; }

                /// <summary>
                /// CodeCont20_02
                /// </summary>
                /// <example>1</example>
                public string? CodeCont20_02 { get; set; }

                /// <summary>
                /// CodeCont40
                /// </summary>
                /// <example>1</example>
                public string? CodeCont40 { get; set; }

                /// <summary>
                /// RunDate
                /// </summary>
                /// <example>2022-03-04</example>
                public string? RunDate { get; set; }

                /// <summary>
                /// CargoCraneType
                /// </summary>
                /// <example>1</example>
                public int? CargoCraneType { get; set; }

                /// <summary>
                /// CargoCraneLicensePlates
                /// </summary>
                /// <example>1</example>
                public string? CargoCraneLicensePlates { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Mã hạ cont, cho hàng xuất
                /// </summary>
                /// <example>1</example>
                public string? CodeDownCont { get; set; }

                /// <summary>
                /// Số chuyến thực tính
                /// </summary>
                /// <example>1</example>
                public decimal QuantityReal { get; set; }
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

            public class EditOutSide
            {
                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example>ĐH/28/12/2022/006</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023/07/01 00:00:00</example>
                public string? FromDateOutSide { get; set; }

                /// <summary>
                /// đến ngày
                /// </summary>
                /// <example>2023/07/01 00:00:00</example>
                public string? ToDateOutSide { get; set; }

                /// <summary>
                /// NCC
                /// </summary>
                /// <example>1</example>
                public int? OutSideSupplierID { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>1</example>
                public string? OutSideNote { get; set; }

                /// <summary>
                /// SL tính
                /// </summary>
                /// <example>1</example>
                public decimal OutSideQuantity { get; set; }
            }

            public class OutSideID
            {
                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example>ĐH/28/12/2022/006</example>
                public string? ReferenceID { get; set; }
            }

            public class GetDetailsVehicleAndDriverID
            {
                /// <summary>
                /// Số xe
                /// </summary>
                /// <example>03609-50H</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// ID tài xê
                /// </summary>
                /// <example>172</example>
                public int? DriverID { get; set; }
            }

            public class GetLocationByLicensePlate
            {
                /// <summary>
                /// Số xe
                /// </summary>
                /// <example>03609-50H</example>
                public string? LicensePlates { get; set; }
            }

            public class GetDetailsVehicleByTeamID
            {
                /// <summary>
                /// Đội xe (% là tất cả các đội được phân quyền)
                /// </summary>
                /// <example>%</example>
                public string? VehicleTeamID { get; set; }
            }

            public class EditFee
            {
                /// <summary>
                /// ID Phí đã thêm
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Mã chi phí
                /// </summary>
                /// <example>10</example>
                public int? FeeID { get; set; }

                /// <summary>
                /// Số tiền đề xuất
                /// </summary>
                /// <example>500000</example>
                public decimal RequestMoney { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>.</example>
                public string? Note { get; set; }
            }

            public class DriverPosition
            {
                /// <summary>
                /// ID shipping
                /// </summary>
                /// <example>18</example>
                public int? ShippingID { get; set; }

                /// <summary>
                /// Vĩ độ
                /// </summary>
                /// <example>10.922723</example>
                public string? DriverLat { get; set; }

                /// <summary>
                /// Kinh độ
                /// </summary>
                /// <example>106.66663</example>
                public string? DriverLong { get; set; }
            }

            public class ListExportDownCont
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// LicensePlates
                /// </summary>
                /// <example>51C 12345</example>
                public string? LicensePlates { get; set; }

                public List<CT_LISTCONT> CT_LISTCONT { get; set; }
            }

            public class ListImportGetCont
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                public List<CT_GET_LISTCONT> CT_GET_LISTCONT { get; set; }
            }

            public class CT_LISTCONT
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// LicensePlates
                /// </summary>
                /// <example>51C 12345</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// ContCode
                /// </summary>
                /// <example>ABC12356487</example>
                public string? ContCode { get; set; }

                /// <summary>
                /// ContNumb
                /// </summary>
                /// <example>12344314112</example>
                public string? ContNumb { get; set; }
            }

            public class CT_GET_LISTCONT
            {
                /// <summary>
                /// ContCode
                /// </summary>
                /// <example>ABC12356487</example>
                public string? ContCode { get; set; }

                /// <summary>
                /// ContNumb
                /// </summary>
                /// <example>12344314112</example>
                public string? ContNumb { get; set; }

                /// <summary>
                /// ContSeal
                /// </summary>
                /// <example>123314112</example>
                public string? ContSeal { get; set; }

                /// <summary>
                /// ContLength
                /// </summary>
                /// <example>20</example>
                public string? ContLength { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
            }

            public class GetCodeDownCont
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// OID Đơn hàng
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? ReferenceID { get; set; }
            }

            public class UpdateCodeDownCont : GetCodeDownCont
            {
                /// <summary>
                /// Mã hạ cont, cho hàng xuất
                /// </summary>
                /// <example>1</example>
                public string? CodeDownCont { get; set; }
            }

            public class SaleContractByCont_GetByID
            {
                ///// <summary>
                ///// ID
                ///// </summary>
                ///// <example>1</example>
                public int? SaleContractsByContID { get; set; }
            }

            public class Edit_SaleContractByCont : SaleContractByCont_GetByID
            {
                /// <summary>
                /// ContCode
                /// </summary>
                /// <example>ABC12356487</example>
                public string? ContCode { get; set; }

                /// <summary>
                /// ContNumb
                /// </summary>
                /// <example>12344314112</example>
                public string? ContNumb { get; set; }

                /// <summary>
                /// ContSeal
                /// </summary>
                /// <example>123314112</example>
                public string? ContSeal { get; set; }

                /// <summary>
                /// ContLength
                /// </summary>
                /// <example>20</example>
                public string? ContLength { get; set; }
            }

            public class GetRevenueByOID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

            public class EditShipping
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>VD/28/12/2022/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Odate
                /// </summary>
                /// <example>2023/08/12</example>
                public string? Odate { get; set; }

                /// <summary>
                /// IsJoinContract
                /// </summary>
                /// <example>0</example>
                public int? IsJoinContract { get; set; }

                /// <summary>
                /// IsJoinTripBefor
                /// </summary>
                /// <example>0</example>
                public int? IsJoinTripBefor { get; set; }

                /// <summary>
                /// IsNeckpair
                /// </summary>
                /// <example>0</example>
                public int? IsNeckpair { get; set; }

                /// <summary>
                /// IsOverload
                /// </summary>
                /// <example>0</example>
                public int? IsOverload { get; set; }
            }

            public class FromDateToDate
            {

                /// <summary>
                /// Ký tháng/năm
                /// </summary>
                /// <example>06/2023</example>
                public string? Period { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023-09-06</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2023-10-06</example>
                public string? ToDate { get; set; }
            }
            public class ShowHideExpired
            {
                public int? IsHideExpired { get; set; }
            }
        }
        public class Response
        {
        }
    }
}