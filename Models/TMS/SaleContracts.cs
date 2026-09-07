namespace APISmartCity.Models.TMS
{
    public static class SaleContracts
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>SALE_CONTRACT</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>CT_NOBOX</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Odate
                /// </summary>
                /// <example>2023/03/06</example>
                public string? Odate { get; set; }

                /// <summary>
                /// ReferenceID
                /// </summary>
                /// <example>1111111111</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// IsTractor
                /// </summary>
                /// <example>0</example>
                public int? IsTractor { get; set; }

                /// <summary>
                /// IsPaymentHelp
                /// </summary>
                /// <example>1</example>
                public int? IsPaymentHelp { get; set; }

                /// <summary>
                /// InspectionUnitID
                /// </summary>
                /// <example>32</example>
                public int? InspectionUnitID { get; set; }

                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>1</example>
                public int? CustomerID { get; set; }

                /// <summary>
                /// Mã khách hỗ trợ
                /// </summary>
                /// <example>33</example>
                public int? CustomerSupportID { get; set; }

                /// <summary>
                /// CustomerContactID
                /// </summary>
                /// <example>33</example>
                public int? CustomerContactID { get; set; }

                /// <summary>
                /// CustomerContactName
                /// </summary>
                /// <example>Trương Bình</example>
                public string? CustomerContactName { get; set; }

                /// <summary>
                /// CustomerContactPhone
                /// </summary>
                /// <example>0979821240</example>
                public string? CustomerContactPhone { get; set; }

                /// <summary>
                /// CustomerContactEmail
                /// </summary>
                /// <example>binhth@gmail.com</example>
                public string? CustomerContactEmail { get; set; }

                /// <summary>
                /// RouteID
                /// </summary>
                /// <example>208</example>
                public int? RouteID { get; set; }

                /// <summary>
                /// GoodTypeID
                /// </summary>
                /// <example>12</example>
                public int? GoodTypeID { get; set; }

                /// <summary>
                /// Quantity
                /// </summary>
                /// <example>20</example>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Weight
                /// </summary>
                /// <example>100</example>
                public decimal Weight { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// UnitID
                /// </summary>
                /// <example>2986</example>
                public int? UnitID { get; set; }

                /// <summary>
                /// UnitPrice
                /// </summary>
                /// <example>5500000.00</example>
                public decimal UnitPrice { get; set; }

                /// <summary>
                /// FeeTransport
                /// </summary>
                /// <example>16500000</example>
                public decimal FeeTransport { get; set; }

                /// <summary>
                /// Discount
                /// </summary>
                /// <example>500000</example>
                public decimal Discount { get; set; }

                /// <summary>
                /// DiscountDescription
                /// </summary>
                /// <example>Khách mới, giảm giá</example>
                public string? DiscountDescription { get; set; }

                /// <summary>
                /// TotalRevenue
                /// </summary>
                /// <example>16000000</example>
                public decimal TotalRevenue { get; set; }

                /// <summary>
                /// Dự kiến số lượng xe
                /// </summary>
                /// <example>1</example>
                public int? EstimatedVehicle { get; set; }

                /// <summary>
                /// Yêu cầu đặt biệt
                /// </summary>
                /// <example>1,2,3,4,5</example>
                public string? RequestSpecial { get; set; }

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
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example>1</example>
                public string? Link { get; set; }

                /// <summary>
                /// Là hàng lô
                /// </summary>
                /// <example>0</example>
                public int? IsShipment { get; set; }

                /// <summary>
                /// Số lượng theo đơn vị tính
                /// </summary>
                /// <example>1</example>
                public decimal QuantityDVT { get; set; }

                public List<CT_INVOICE> CT_INVOICE { get; set; }

                public List<CT_LISTCONT> CT_LISTCONT { get; set; }

                public List<CT_NOBOX_GET> CT_NOBOX_GET { get; set; }

                public List<CT_NOBOX_RETURN> CT_NOBOX_RETURN { get; set; }

                public List<CT_CONT_IMP_GET_CONT> CT_CONT_IMP_GET_CONT { get; set; }

                public List<CT_CONT_IMP_RETURN_CONT> CT_CONT_IMP_RETURN_CONT { get; set; }

                public List<CT_CONT_IMP_DOWN_EMPTY> CT_CONT_IMP_DOWN_EMPTY { get; set; }

                public List<CT_CONT_EXP_GET_EMPTY> CT_CONT_EXP_GET_EMPTY { get; set; }

                public List<CT_CONT_EXP_PACKING> CT_CONT_EXP_PACKING { get; set; }

                public List<CT_CONT_EXP_DOWN_CONT> CT_CONT_EXP_DOWN_CONT { get; set; }
            }

            public class CT_INVOICE
            {
                /// <summary>
                /// Mã công ty xuất hóa đơn
                /// </summary>
                /// <example>111</example>
                public int? InvoiceCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceCusTaxCode { get; set; }

                /// <summary>
                /// Số tiền xuất hóa đơn
                /// </summary>
                /// <example>100000</example>
                public int? InvoiceTotal { get; set; }

                /// <summary>
                /// Ghi chú nếu có
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }
            }

            public class CT_LISTCONT
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

            public class CT_NOBOX_GET
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// Số đơn hàng
                /// </summary>
                /// <example>CL2435</example>
                public string? OrderNumber { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>Cảng Cát Lái, Đường Nguyễn Thị Định, Phường Cát Lái, Quận 2, TP.HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>Liên hệ bảo vệ</example>
                public string? Request { get; set; }

                /// <summary>
                /// ContactName
                /// </summary>
                /// <example>Trương Bình</example>
                public string? ContactName { get; set; }

                /// <summary>
                /// ContactPhone
                /// </summary>
                /// <example>0979821240</example>
                public string? ContactPhone { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/20 16:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// Quantity
                /// </summary>
                /// <example>20</example>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Weight tấn
                /// </summary>
                /// <example>100</example>
                public decimal Weight { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_GET_DETAILS { get; set; }
            }

            public class CT_NOBOX_RETURN
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example></example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Kho NLT</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>43R Hồ Văn Huê, phường 09, Quận Phú Nhuận, HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>Liên hệ bảo vệ</example>
                public string? Request { get; set; }

                /// <summary>
                /// ContactName
                /// </summary>
                /// <example>Nguyệt Thu</example>
                public string? ContactName { get; set; }

                /// <summary>
                /// ContactPhone
                /// </summary>
                /// <example>0328541530</example>
                public string? ContactPhone { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/20 16:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// Quantity
                /// </summary>
                /// <example>20</example>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Weight tấn
                /// </summary>
                /// <example>100</example>
                public decimal Weight { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_RETURN_DETAILS { get; set; }
            }

            public class CT_CONT_IMP_GET_CONT
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>Cảng Cát Lái, Đường Nguyễn Thị Định, Phường Cát Lái, Quận 2, TP.HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>Liên hệ BV</example>
                public string? Request { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/13 18:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// BillNoImport
                /// </summary>
                /// <example>LO019830281</example>
                public string? BillNoImport { get; set; }

                /// <summary>
                /// BillFileImport
                /// </summary>
                /// <example>file.pdf</example>
                public string? BillFileImport { get; set; }

                /// <summary>
                /// DaySaveCont
                /// </summary>
                /// <example>2023/03/13 16:00:00</example>
                public string? DaySaveCont { get; set; }

                /// <summary>
                /// DayGetCont
                /// </summary>
                /// <example>2023/03/13 16:00:00</example>
                public string? DayGetCont { get; set; }

                /// <summary>
                /// DaySurcharge
                /// </summary>
                /// <example>2023/03/13 16:00:00</example>
                public string? DaySurcharge { get; set; }

                /// <summary>
                /// DaySavePort
                /// </summary>
                /// <example>2023/03/13 16:00:00</example>
                public string? DaySavePort { get; set; }

                /// <summary>
                /// DayArrivalShip
                /// </summary>
                /// <example>2023/03/03 16:00:00</example>
                public string? DayArrivalShip { get; set; }

                /// <summary>
                /// InvoiceLOLOCusID
                /// </summary>
                /// <example>111</example>
                public int? InvoiceLOLOCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceLOLOCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceLOLOCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceLOLOCusTaxCode { get; set; }

                /// <summary>
                /// InvoiceSurchargeCusID
                /// </summary>
                /// <example>112</example>
                public int? InvoiceSurchargeCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceSurchargeCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceSurchargeCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceSurchargeCusTaxCode { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_GET_DETAILS { get; set; }
            }

            public class CT_CONT_IMP_RETURN_CONT
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>1</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Kho NLT</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>Liên hệ BV</example>
                public string? Request { get; set; }

                /// <summary>
                /// ContactName
                /// </summary>
                /// <example>Trương Bình</example>
                public string? ContactName { get; set; }

                /// <summary>
                /// ContactPhone
                /// </summary>
                /// <example>0979821240</example>
                public string? ContactPhone { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 16:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/13 16:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_RETURN_DETAILS { get; set; }
            }

            public class CT_CONT_IMP_DOWN_EMPTY
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>Cảng Cát Lái, Đường Nguyễn Thị Định, Phường Cát Lái, Quận 2, TP.HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>Liên hệ BV</example>
                public string? Request { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/13 18:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// File lệnh hạ
                /// </summary>
                /// <example>file.pdf</example>
                public string? FileDown { get; set; }

                /// <summary>
                /// InvoiceLOLOCusID
                /// </summary>
                /// <example>111</example>
                public int? InvoiceLOLOCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceLOLOCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceLOLOCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceLOLOCusTaxCode { get; set; }

                /// <summary>
                /// InvoiceSurchargeCusID
                /// </summary>
                /// <example>112</example>
                public int? InvoiceSurchargeCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceSurchargeCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceSurchargeCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceSurchargeCusTaxCode { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_DOWN_DETAILS { get; set; }
            }

            public class CT_CONT_EXP_GET_EMPTY
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>Cảng Cát Lái, Đường Nguyễn Thị Định, Phường Cát Lái, Quận 2, TP.HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// BillNoEmpty
                /// </summary>
                /// <example>B121891</example>
                public string? BillNoEmpty { get; set; }

                /// <summary>
                /// BillFileEmpty
                /// </summary>
                /// <example>file.pdf</example>
                public string? BillFileEmpty { get; set; }

                /// <summary>
                /// BillFileEmptyApproval
                /// </summary>
                /// <example>file.pdf</example>
                public string? BillFileEmptyApproval { get; set; }

                /// <summary>
                /// DayEmptyFirst
                /// </summary>
                /// <example>2023/03/03 14:00:00</example>
                public string? DayEmptyFirst { get; set; }

                /// <summary>
                /// DayEmptyLast
                /// </summary>
                /// <example>2023/03/13 14:00:00</example>
                public string? DayEmptyLast { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// InvoiceLOLOCusID
                /// </summary>
                /// <example>111</example>
                public int? InvoiceLOLOCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceLOLOCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceLOLOCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceLOLOCusTaxCode { get; set; }

                /// <summary>
                /// InvoiceSurchargeCusID
                /// </summary>
                /// <example>112</example>
                public int? InvoiceSurchargeCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceSurchargeCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceSurchargeCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceSurchargeCusTaxCode { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_GET_DETAILS { get; set; }
            }

            public class CT_CONT_EXP_PACKING
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>Cảng Cát Lái, Đường Nguyễn Thị Định, Phường Cát Lái, Quận 2, TP.HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>Liên hệ bảo vệ</example>
                public string? Request { get; set; }

                /// <summary>
                /// ContactName
                /// </summary>
                /// <example>Trương Bình</example>
                public string? ContactName { get; set; }

                /// <summary>
                /// ContactPhone
                /// </summary>
                /// <example>0979821240</example>
                public string? ContactPhone { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/20 16:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_RETURN_DETAILS { get; set; }
            }

            public class CT_CONT_EXP_DOWN_CONT
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FullAddress
                /// </summary>
                /// <example>Cảng Cát Lái, Đường Nguyễn Thị Định, Phường Cát Lái, Quận 2, TP.HCM</example>
                public string? FullAddress { get; set; }

                /// <summary>
                /// Request
                /// </summary>
                /// <example>1</example>
                public string? Request { get; set; }

                /// <summary>
                /// DayDownFirst
                /// </summary>
                /// <example>2023/03/03 13:00:00</example>
                public string? DayDownFirst { get; set; }

                /// <summary>
                /// DayDownLast
                /// </summary>
                /// <example>2023/03/13 13:00:00</example>
                public string? DayDownLast { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// InvoiceLOLOCusID
                /// </summary>
                /// <example>111</example>
                public int? InvoiceLOLOCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceLOLOCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceLOLOCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceLOLOCusTaxCode { get; set; }

                /// <summary>
                /// InvoiceSurchargeCusID
                /// </summary>
                /// <example>112</example>
                public int? InvoiceSurchargeCusID { get; set; }

                /// <summary>
                /// Tên công ty
                /// </summary>
                /// <example>Tập đoàn đầu tư công nghệ nam long</example>
                public string? InvoiceSurchargeCusName { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>43R Hồ Văn Huê, Phường 09, Quận Phú Nhuận, HCM</example>
                public string? InvoiceSurchargeCusAddress { get; set; }

                /// <summary>
                /// Mã số thuê
                /// </summary>
                /// <example>03125446455</example>
                public string? InvoiceSurchargeCusTaxCode { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }

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
                /// File lệnh hạ
                /// </summary>
                /// <example>file.pdf</example>
                public string? FileDown { get; set; }

                /// <summary>
                /// Chi tiết
                /// </summary>
                /// <example></example>
                public List<CT_GET_DETAILS> CT_DOWN_DETAILS { get; set; }
            }

            public class CT_GET_DETAILS
            {
                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/20 16:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// Quantity
                /// </summary>
                /// <example>20</example>
                public decimal Quantity { get; set; }

                /// <summary>
                /// Weight tấn
                /// </summary>
                /// <example>100</example>
                public decimal Weight { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }

                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>4</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Hellword</example>
                public string? DepotName { get; set; }
            }

            public class CT_CONT_IMP_GET_CONT_DETAILS
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// FromTime
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// ToTime
                /// </summary>
                /// <example>2023/03/13 18:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }
            }

            public class CT_CONT_EXP_GET_EMPTY_DETAILS
            {
                /// <summary>
                /// DepotID
                /// </summary>
                /// <example>29</example>
                public int? DepotID { get; set; }

                /// <summary>
                /// DepotName
                /// </summary>
                /// <example>Công ty cổ phần cảng Cát Lái</example>
                public string? DepotName { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? FromTime { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2023/03/03 11:00:00</example>
                public string? ToTime { get; set; }

                /// <summary>
                /// QuantityCont20
                /// </summary>
                /// <example>2</example>
                public decimal QuantityCont20 { get; set; }

                /// <summary>
                /// QuantityCont40
                /// </summary>
                /// <example>4</example>
                public decimal QuantityCont40 { get; set; }
            }

            public class Add : Content
            {
            }

            public class EditListCont
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }

                public List<CT_LISTCONT> CT_LISTCONT { get; set; }
            }
            public class Get
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? OID { get; set; }
            }

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


            public class UpdateMultiClose
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>YCVC/28/12/2022/006</example>
                public string? ListOID { get; set; }
                public string? Extention1 { get; set; }

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
                /// <example>ÐHCX/23/03/001</example>
                public string? OID { get; set; }
            }

            public class GetByCusID
            {
                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>1</example>
                public string? CustomerID { get; set; }
            }

            public class FromDateToDate
            {
                /// <summary>
                /// String
                /// </summary>
                /// <example>2023/08/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// String
                /// </summary>
                /// <example>2023/08/31</example>
                public string? ToDate { get; set; }
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

            public class GeoCode
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>Bến Nhà Rồng</example>
                public string? Address { get; set; }
            }

            public class VietMapRoute
            {
                /// <summary>
                /// Danh sách GPS
                /// </summary>
                /// <example>[10.753915,106.574959],[10.749826,106.642388]</example>
                public string? StringPoint { get; set; }
            }

            public class RefID
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>Bến Nhà Rồng</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                public string? RefId { get; set; }
            }

            public class GetLatLong
            {
                /// <summary>
                /// Địa chỉ
                /// </summary>
                public string? RefId { get; set; }
            }

            public class AddGeoCode : GeoCode
            {
                /// <summary>
                /// Lat
                /// </summary>
                /// <example>10.8</example>
                public string? Lat { get; set; }

                /// <summary>
                /// Long
                /// </summary>
                /// <example>106</example>
                public string? Long { get; set; }
            }

            public class Test
            {
                /// <summary>
                /// Test
                /// </summary>
                /// <example>31</example>
                public int? CustomerID { get; set; }
            }

            public class GetRoute
            {
                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.753915,106.574959],[10.789581,106.652680],[10.749826,106.642388]</example>
                public string? StringPoint { get; set; }
            }

            public class Routes
            {
                /// <summary>
                /// Test
                /// </summary>
                /// <example>[10.753915,106.574959],[10.789581,106.652680],[10.749826,106.642388]</example>
                public string? StringPoint { get; set; }

                /// <summary>
                /// distance
                /// </summary>
                /// <example>1</example>
                public decimal distance { get; set; }

                /// <summary>
                /// weight
                /// </summary>
                /// <example>1</example>
                public decimal weight { get; set; }

                /// <summary>
                /// time
                /// </summary>
                /// <example>1</example>
                public decimal time { get; set; }

                /// <summary>
                /// transfers
                /// </summary>
                /// <example>1</example>
                public int? transfers { get; set; }

                /// <summary>
                /// points_encoded
                /// </summary>
                /// <example>1</example>
                public string? points_encoded { get; set; }

                /// <summary>
                /// Bbox
                /// </summary>
                /// <example>1</example>
                public string? Bbox { get; set; }

                /// <summary>
                /// Points
                /// </summary>
                /// <example>1</example>
                public string? Points { get; set; }

                /// <summary>
                /// Instructions
                /// </summary>
                /// <example>1</example>
                public string? Instructions { get; set; }

                /// <summary>
                /// Snapped_waypoints
                /// </summary>
                /// <example>1</example>
                public string? Snapped_waypoints { get; set; }
            }

            public class EstimatedNumberOfVehicles
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Dự kiến số lượng xe
                /// </summary>
                /// <example>1</example>
                public int? EstimatedVehicle { get; set; }

                /// <summary>
                /// Lý do điều chỉnh
                /// </summary>
                /// <example>Hết xe</example>
                public string? Extention5 { get; set; }
            }

            public class ListInvoice
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>ÐHCX/23/03/001</example>
                public string? OID { get; set; }

                public List<CT_IMP_INVOICE> CT_IMP_INVOICE { get; set; }
            }

            public class CT_IMP_INVOICE
            {
                /// <summary>
                /// Mã
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// Mã công ty xuất hóa đơn
                /// </summary>
                /// <example>111</example>
                public int? InvoiceCusID { get; set; }

                /// <summary>
                /// Số tiền xuất hóa đơn
                /// </summary>
                /// <example>100000</example>
                public int? InvoiceTotal { get; set; }

                /// <summary>
                /// Ghi chú nếu có
                /// </summary>
                /// <example>Ghi chú</example>
                public string? Note { get; set; }
            }
        }

        public class Response
        {
        }
    }
}