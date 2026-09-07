namespace APISmartCity.Models.Ver2.Configs
{
    public static class CompanyConfigs
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// parentID
                /// </summary>
                /// <example>0</example>
                public int? ParentID { get; set; }
                /// <summary>
                /// Mã công ty - không được trùng
                /// </summary>
                /// <example>LM123</example>
                public string? Code { get; set; }

                /// <summary>
                /// Mã lemon
                /// </summary>
                /// <example>LM123</example>
                public string? LemonID { get; set; }
                /// <summary>
                /// Mã SAP
                /// </summary>
                /// <example>LM123</example>
                public string? SAPID { get; set; }

                /// <summary>
                /// Tên
                /// </summary>
                /// <example>Tên mặc định</example>
                public string? Name { get; set; }

                /// <summary>
                /// Tên 1
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên 2
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên 3
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên 4
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên 5
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên 6
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên 7
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên 8
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên 9
                /// </summary>
                /// <example>Default name</example>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>Ấp Dên Dên,TT Tân Phú,Đồng Phú,Bình Phước</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ 1
                /// </summary>
                /// <example>Den Den Hamlet, Tan Phu Town, Dong Phu, Binh Phuoc</example>
                public string? AddressExtention1 { get; set; }

                /// <summary>
                /// Địa chỉ 2
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention2 { get; set; }

                /// <summary>
                /// Địa chỉ 3
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention3 { get; set; }

                /// <summary>
                /// Địa chỉ 4
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention4 { get; set; }

                /// <summary>
                /// Địa chỉ 5
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention5 { get; set; }

                /// <summary>
                /// Địa chỉ 6
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention6 { get; set; }

                /// <summary>
                /// Địa chỉ 7
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention7 { get; set; }

                /// <summary>
                /// Địa chỉ 8
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention8 { get; set; }

                /// <summary>
                /// Địa chỉ 9
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention9 { get; set; }

                /// <summary>
                /// Mã số thuế
                /// </summary>
                /// <example>8364624270</example>
                public string? TaxCode { get; set; }

                /// <summary>
                /// phone
                /// </summary>
                /// <example>1</example>
                public string? Phone { get; set; }

                /// <summary>
                /// email
                /// </summary>
                /// <example>1</example>
                public string? Email { get; set; }

                /// <summary>
                /// website
                /// </summary>
                /// <example>1</example>
                public string? Website { get; set; }

                /// <summary>
                /// Link File
                /// </summary>
                /// <example></example> 
                public string? Logo { get; set; }

                /// <summary>
                /// Format tiền tệ
                /// </summary>
                /// <example>1</example>
                public int? FormatCurrency { get; set; }

                /// <summary>
                /// sử dụng bao nhiêu số thập phân sau dâu phẩy/chấm
                /// </summary>
                /// <example>1</example>
                public int? FormatDecimal { get; set; }

                /// <summary>
                /// Cho phép sửa ngày CT
                /// </summary>
                /// <example>1</example>
                public int? IsEditODate { get; set; }

                /// <summary>
                /// Quản lý đơn hàng quốc tế
                /// </summary>
                public int? ManageGlobalOrder { get; set; }

                public int? LimitGlobalMTS { get; set; }
                public int? CancelExpiredGlobalMTS { get; set; }
                public int? AdjustLimitGlobalMTS { get; set; }
                public int? LimitGlobalMTS_Adjust { get; set; }
                public DateTime LimitGlobalMTS_From { get; set; }
                public DateTime LimitGlobalMTS_To { get; set; }

                public int? LimitGlobalMTO { get; set; }
                public int? CancelExpiredGlobalMTO { get; set; }
                public int? AdjustLimitGlobalMTO { get; set; }
                public int? LimitGlobalMTO_Adjust { get; set; }
                public DateTime LimitGlobalMTO_From { get; set; }
                public DateTime LimitGlobalMTO_To { get; set; }

                /// <summary>
                /// Quản lý đơn hàng nội địa
                /// </summary>
                public int? ManageLocalOrder { get; set; }
                public int? LimitLocalMTO_Adjust { get; set; }
                public DateTime LimitLocalMTO_To { get; set; }
                public DateTime LimitLocalMTO_From { get; set; }
                public int? AdjustLimitLocalMTO { get; set; }
                public int? LimitLocalMTO { get; set; }
                public int? CancelExpiredLocalMTO { get; set; }

                public int? LimitLocalMTS_Adjust { get; set; }
                public DateTime LimitLocalMTS_To { get; set; }
                public DateTime LimitLocalMTS_From { get; set; }
                public int? AdjustLimitLocalMTS { get; set; }
                public int? LimitLocalMTS { get; set; }
                public int? CancelExpiredLocalMTS { get; set; }

                /// <summary>
                /// Auto duyệt đơn hàng
                /// </summary>
                /// <example>1</example>
                public int? ApprovalOrder { get; set; }

                /// <summary>
                /// Auto duyệt phát sinh
                /// </summary>
                /// <example>1</example>
                public int? ApprovalIncurredFee { get; set; }

                /// <summary>
                /// Khung thời gian duyệt phát sinh
                /// </summary>
                /// <example>1</example>
                public string? TimeApprovalIncurredFee { get; set; }

                /// <summary>
                /// Thời gian chờ trước khi duyệt phát sinh
                /// </summary>
                /// <example>1</example>
                public int? TimeBeforeApprovingIncurredFee { get; set; }

                /// <summary>
                /// Tài xế được từ chối đơn
                /// </summary>
                /// <example>1</example>
                public int? DriverRejectOrder { get; set; }

                /// <summary>
                /// Có/không Nhắc việc
                /// </summary>
                /// <example>1</example>
                public int? RemindJob { get; set; }

                /// <summary>
                /// Chu kỳ nhắc việc
                /// </summary>
                /// <example>1</example>
                public int? CycleRemindJob { get; set; }

                /// <summary>
                /// Auto Nhắc bảo trì
                /// </summary>
                /// <example>1</example>
                public int? RemindMaintenance { get; set; }

                /// <summary>
                /// Bán kinh cảnh báo
                /// </summary>
                /// <example>1</example>
                public int? RadiusWrongRoutesAlert { get; set; }

                /// <summary>
                /// Cảnh báo sai tuyến
                /// </summary>
                /// <example>1</example>
                public int? WrongRoutesAlert { get; set; }

                /// <summary>
                /// Số km cảnh báo thay vỏ
                /// </summary>
                /// <example>15000</example>
                public int? QuantityKmRM { get; set; }

                /// <summary>
                /// Số ngày cảnh báo gia hạn giấy tờ
                /// </summary>
                /// <example>15</example>
                public int? QuantityDayDoc { get; set; }

                /// <summary>
                /// Số phút cho phép bàn giao trễ
                /// </summary>
                /// <example>15</example>
                public int? VehicleDelayMinutes { get; set; }

                /// <summary>
                /// Bán kính tối đa
                /// </summary>
                /// <example>300000</example>
                public int? MaximumArrivalRadius { get; set; }

                /// <summary>
                /// Cảnh báo tài liệu quá hạn
                /// </summary>
                /// <example>3</example>
                public int? DocumentOverdueWarning { get; set; }

                /// <summary>
                /// </summary>
                /// <example>0</example>
                public decimal RepairLat { get; set; }

                /// <summary>
                /// </summary>
                /// <example>0</example>
                public decimal RepairLong { get; set; }

                /// <summary>
                /// </summary>
                /// <example>3</example>
                public decimal RepairDistance { get; set; }

                /// <summary>
                /// </summary>
                /// <example>0</example>
                public int? IsRepairCalculate { get; set; }

                /// <summary>
                /// </summary>
                /// <example>F:/NLTSystemFile/</example>
                public string? DiskFolderSave { get; set; }

                /// <summary>
                /// </summary>
                /// <example>https://viewfile.nlt-group.com/</example>
                public string? LinkFolderSave { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? TokenFirebase { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? ServerName { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? ServerCode { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? ServerConnectString { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>8364624270</example>
                public string? ServerConnectAPI { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? EmailUserName { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? EmailPassword { get; set; }

                /// <summary>
                /// </summary>
                /// <example>mail@nlt-group.com</example>
                public string? EmailServer { get; set; }

                /// <summary>
                /// </summary>
                /// <example>517</example>
                public int? EmailPort { get; set; }

                /// <summary>
                /// </summary>
                /// <example>0</example>
                public int? EmailSSL { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? CodeLinkOther { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? APIOtherLink { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? APIOtherAuthen { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? APIOtherKey { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? APIOtherToken { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? APIOtherUserName { get; set; }

                /// <summary>
                /// </summary>
                /// <example></example>
                public string? APIOtherPassword { get; set; }

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

                /// <summary>
                /// Hoạt động/Không hoạt động
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>8364624270</example>
                public string? Note { get; set; }

                /// <summary>
                /// isDeleted = 1 dữ liệu đã xóa
                /// </summary>
                /// <example>0</example>
                public int? IsDeleted { get; set; }

                /// <summary>
                /// Vĩ độ công ty
                /// </summary>
                /// <example>10.7304049</example>
                public decimal Lat { get; set; }

                /// <summary>
                /// Kinh độ công ty
                /// </summary>
                /// <example>106.5880049</example>
                public decimal Long { get; set; }

                /// <summary>
                /// Link API thiết bị
                /// </summary>
                /// <example>https://device-api.nlt-group.com</example>
                public string? LinkDeviceAPI { get; set; }

                /// <summary>
                /// Link API mobile
                /// </summary>
                /// <example>https://mobile-api.nlt-group.com</example>
                public string? LinkMobileAPI { get; set; }

                /// <summary>
                /// Email nhận thông báo
                /// </summary>
                /// <example></example>
                public string? Extention11 { get; set; }

                public string? Extention12 { get; set; }
                /// <summary>
                /// Cho phép giữ hàng?
                /// </summary>
                /// <example></example>
                public int? IsHold { get; set; }
                /// <summary>
                /// Thời gian giữ hàng
                /// </summary>
                /// <example></example>
                public int? HoldDuration { get; set; }
                /// <summary>
                /// Số lần được phép gia hạn
                /// </summary>
                /// <example></example>
                public string? ExtendLimitCount { get; set; }
                /// <summary>
                /// Thời gian gia hạn mỗi lần
                /// </summary>
                /// <example></example>
                public string? HoldExtendDuration { get; set; }
                /// <summary>
                /// Tồn kho hiển thị đối với KH (%)
                /// </summary>
                /// <example></example>
                public string? SalesViewPercentage { get; set; }
                /// <summary>
                /// Tồn kho hiển thị đối với nhân viên kinh doanh (%)
                /// </summary>
                /// <example></example>
                public string? CustomerViewPercentage { get; set; }
                /// <summary>
                /// Chặn vượt han mức
                /// </summary>
                /// <example></example>
                public int? BlockODLimit { get; set; }
                /// <summary>
                /// Chặn hết tồn kho
                /// </summary>
                /// <example></example>
                public int? BlockOutOfStock { get; set; }
                /// <summary>
                /// Xác nhận hạn mức
                /// </summary>
                /// <example></example>
                public int? BlockDepositConfirmation { get; set; }
                /// <summary>
                /// Hạn mức OD
                /// </summary>
                /// <example></example>
                public int? BlockOverLimit { get; set; }
                /// <summary>
                /// Quá hạn SO MTS nội địa
                /// </summary>
                /// <example></example>
                public int? OverdueMTSDomestic { get; set; }
                /// <summary>
                /// Quá hạn SO MTO nội địa
                /// </summary>
                /// <example></example>
                public int? OverdueMTODomestic { get; set; }
                /// <summary>
                /// Quá hạn SO MTO quốc tế
                /// </summary>
                /// <example></example>
                public int? OverdueMTOInternational { get; set; }
                /// <summary>
                /// Quá hạn SO MTS quốc tế
                /// </summary>
                /// <example></example>
                public int? OverdueMTSInternational { get; set; }
                /// <summary>
                /// ID người đại diện
                /// </summary>
                /// <example></example>
                public int? RepresentativeID { get; set; }
                /// <summary>
                /// ID người uy nhiệm
                /// </summary>
                /// <example></example>
                public int? DelegatorID { get; set; }

                /// <summary>
                /// Chức vụ người đại diện
                /// </summary>
                /// <example></example>
                public string? RepresentativePosition { get; set; }
                /// <summary>
                /// Chức vụ người uy nhiệm
                /// </summary>
                /// <example></example>
                public string? DelegatorPosition { get; set; }

                /// <summary>
                /// Cảnh báo Km thay vỏ bánh cầu
                /// </summary>
                public decimal KmAlertChangeWheelDrive { get; set; }

                /// <summary>
                /// Vị trí bánh cầu cần thay (Bánh cầu)
                /// </summary>
                public string? PositionWheelDriveNeedChange { get; set; }

                /// <summary>
                /// Cảnh báo Km thay vỏ bánh lái
                /// </summary>
                public decimal KmAlertChangeWheelSteer { get; set; }

                /// <summary>
                /// Vị trí bánh cầu cần thay (Bánh lái)
                /// </summary>
                public string? PositionWheelSteerNeedChange { get; set; }

                /// <summary>
                /// Có cảnh báo sai tuyến (0: Không, 1: Có)
                /// </summary>
                public int? IsWrongRouteAlert { get; set; }

                /// <summary>
                /// Số giờ cảnh báo sai tuyến
                /// </summary>
                public decimal WarningRouteAlertHour { get; set; }

                /// <summary>
                /// Có check bán kính xác nhận vận chuyển (0: Không, 1: Có)
                /// </summary>
                public int? IsConfirmCheckRadius { get; set; }

                /// <summary>
                /// Số giờ xác nhận bán kính vận chuyển
                /// </summary>
                public decimal CheckRadiusHour { get; set; }

                /// <summary>
                /// Có cảnh báo bàn giao chứng từ (0: Không, 1: Có)
                /// </summary>
                public int? IsDocHandoverAlert { get; set; }

                /// <summary>
                /// Số giờ cảnh báo bàn giao chứng từ
                /// </summary>
                public decimal DocHandoverHour { get; set; }

                /// <summary>
                /// Tài xế được phép chối đơn (0: Không, 1: Có)
                /// </summary>
                public int? IsDriverCanReject { get; set; }

                /// <summary>
                /// Tự động duyệt đơn khi còn năng lực (0: Không, 1: Có)
                /// </summary>
                public int? IsAutoApproveByCapacity { get; set; }

                /// <summary>
                /// Tự động duyệt chi phí phát sinh (0: Không, 1: Có)
                /// </summary>
                public int? IsAutoApproveCost { get; set; }

                /// <summary>
                /// Thời gian chờ duyệt (phút)
                /// </summary>
                public decimal WaitingMinute { get; set; }

                /// <summary>
                /// Khung giờ được duyệt từ (hh:mm)
                /// </summary>
                public TimeSpan ApproveTimeFrom { get; set; }

                /// <summary>
                /// Khung giờ được duyệt đến (hh:mm)
                /// </summary>
                public TimeSpan ApproveTimeTo { get; set; }

                /// <summary>
                /// Kết nối tích hợp
                /// </summary>
                /// <example></example>
                public List<Integrations> Integration { get; set; }

                /// <summary>
                /// BankAccount
                /// </summary>
                /// <example></example>
                public List<BankAccount> BankAccount { get; set; }

                /// <summary>
                /// Thời gian nhắc nhở
                /// </summary>
                /// <example></example>
                public string? TimeRemindFirebase { get; set; }

                /// <summary>
                /// Mã định danh cho hệ thống ERP
                /// </summary>
                /// <example>ERP123</example>
                public string? ERPCode { get; set; }

                /// <summary>
                /// Đường dẫn API của hệ thống ERP
                /// </summary>
                /// <example>https://api.erpcompany.com</example>
                public string? ERPAPILink { get; set; }

                /// <summary>
                /// Phương thức xác thực cho API ERP
                /// </summary>
                /// <example></example>
                public string? ERPAuthMethod { get; set; }

                /// <summary>
                /// API Key để truy cập hệ thống ERP
                /// </summary>
                /// <example></example>
                public string? ERPAPIKey { get; set; }

                /// <summary>
                /// Mã Token được sử dụng để xác thực với hệ thống ERP
                /// </summary>
                /// <example></example>
                public string? ERPToken { get; set; }

                /// <summary>
                /// Tên đăng nhập của người dùng trong hệ thống ERP
                /// </summary>
                /// <example></example>
                public string? ERPUserName { get; set; }

                /// <summary>
                /// Mật khẩu của người dùng ERP
                /// </summary>
                /// <example>P@ssw0rd</example>
                public string? ERPPassword { get; set; }

                /// <summary>
                /// IsSystemSignature
                /// </summary>
                /// <example>IsSystemSignature</example>
                public int? IsSystemSignature { get; set; }

                /// <summary>
                /// SignatureLink
                /// </summary>
                /// <example>SignatureLink</example>
                public string? SignatureLink { get; set; }


                /// <summary>
                /// SignatureID
                /// </summary>
                /// <example>SignatureID</example>
                public int? SignatureID { get; set; } 
                

                /// <summary>
                /// Slogan
                /// </summary>
                /// <example>Slogan</example>
                public string? Slogan { get; set; }

                /// <summary>
                /// MainColor
                /// </summary>
                /// <example>MainColor</example>
                public string? MainColor { get; set; }

                /// <summary>
                /// FactoryList 
                /// </summary>
                public string? FactoryList { get; set; }

                /// <summary>
                /// WarehouseGroupList 
                /// </summary>
                public string? WarehouseGroupList { get; set; }

            }

            public class Add : Content
            {
            }
            
            public class Integrations
            {
                public int? ID { get; set; }
                public string? Code { get; set; }
                public string? AuthenMethod { get; set; }
                public string? TokenAuthen { get; set; }
                public string? APIUserName { get; set; }
                public string? APIPassword { get; set; }
                public string? Note { get; set; }
                public int? IsActive { get; set; }
                public int? CmpnID { get; set; }
                public string? Url {  get; set; }
                public string? Endpoint { get; set; }
            }

            public class Warehouse
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string? Code { get; set; }
                public string? CategoryType { get; set; }
                public string? Name { get; set; }
                public string? NameExtention1 { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
            }

            public class ShippingPoint
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string? Code { get; set; }
                public string? CategoryType { get; set; }
                public string? Name { get; set; }
                public string? NameExtention1 { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
            }

            public class WarehouseGroup
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public int? STT { get; set; }
                public string? Code { get; set; }
                public string? CategoryType { get; set; }
                public string? Name { get; set; }
                public string? NameExtention1 { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
            }

            public class WarehouseForGroup
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public int? STT { get; set; }
                public string? Code { get; set; }
                public string? CategoryType { get; set; }
                public string? Name { get; set; }
                public string? NameExtention1 { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
            }
            public class BankAccount
            {
                public string? Code { get; set; }
                public string? CategoryType { get; set; }
                public string? Name { get; set; }
                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Address { get; set; }
                public string? Note { get; set; }
                public string? CmpnID { get; set; }
            }
            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
            public class GetByID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }


            public class EditStatus : GetByID
            {
                /// <summary>
                /// Khóa/ không khóa
                /// </summary>
                /// <example>1</example>
                public int IsActive { get; set; }
            }

            public class CheckLockData
            {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>1</example>
                public string ODate { get; set; }

                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>1</example>
                public string Type { get; set; }
            }

            public class LockData
            {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>1</example>
                public string Period { get; set; }

                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>DP</example>
                public string Type { get; set; }
            }
            public class AddLockData
            {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>1</example>
                public string Period { get; set; }

                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>DP</example>
                public string Type { get; set; }
                public string StartDate { get; set; }
                public string EndDate { get; set; }
            }

            public class GetTypes
            {
                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>DP</example>
                public string Type { get; set; }
            }
        }
    }
}