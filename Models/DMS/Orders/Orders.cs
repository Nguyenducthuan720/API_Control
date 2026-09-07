namespace DMS.Models.DMS.Orders;

public static class Orders
{
    public class Request
    {
        public class Add
        {
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Ghi chú</example>
            public string? Note { get; set; }
            
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
        }
        
        public class AddOrder : Add
        {
            /// <summary>
            /// Nghiệp vụ
            /// </summary>
            /// <example>OrderNormals</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// Chức năng
            /// </summary>
            /// <example>SONormals</example>
            public string? EntryID { get; set; }
			
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }
			
            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2025-05-23</example>
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
            /// Công ty
            /// </summary>
            /// <example></example>
            public string? CmpnID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            public int? CustomerID { get; set; }

			/// <summary>
			/// Khách hàng hỗ trợ
			/// </summary>
			public int? SupportCustomerID { get; set; }

            /// <summary>
            /// Loại chứng từ
            /// </summary>
            /// <example></example>
            public string? ReferenceFactorID { get; set; }

            /// <summary>
		    /// Loại chứng từ
			/// </summary>
            /// <example></example> 
			public string? ReferenceEntryID { get; set; }

            /// <summary>
            /// Số chứng từ
            /// </summary>
            /// <example></example>
            public string? ReferenceID { get; set; }

			/// <summary>
            /// Kênh bán hàng
            /// </summary>
            /// <example></example>
            public int? SalesChannelID { get; set; }

			/// <summary>
			/// Ngành hàng
			/// </summary>
			public int? GoodsTypeID { get; set; }

			/// <summary>
			/// Ngày dự kiến giao hàng
			/// </summary>
			public string? ExpectedDeliveryDate { get; set; }

            /// <summary>
            /// Nhóm giá
            /// </summary>
            public int? PriceGroupID { get; set; }

            /// <summary>
			/// Ngày tính giá
			/// </summary>
            /// <example>2025-08-21</example>
			public string? PriceDate { get; set; }

            /// <summary>
            /// Điều khoản thanh toán
            /// </summary>
            public int? PaymentTermID { get; set; }

            /// <summary>
            /// Hình thức thanh toán
            /// </summary>
            public int? PaymentMethodID { get; set; }

            /// <summary>
            /// Tiền tệ
            /// </summary>
            public int? CurrencyTypeID { get; set; } 
			
			/// <summary>
			/// Tỷ giá quy đổi
			/// </summary>
			public decimal CurrencyRate { get; set; }

			/// <summary>
			/// Ngày tỷ giá
			/// </summary>
			public string? CurrencyDate { get; set; }

            /// <summary>
            /// Yêu cầu cọc/thanh toán
            /// </summary>
            public int? RequireDepositPayment { get; set; }

            /// <summary>
            /// Giá trị cọc/thanh toán
            /// </summary>
            public int? DepositPaymentValue { get; set; }

            /// <summary>
            /// COD
            /// </summary>
            public int? IsCOD { get; set; }

            /// <summary>
            /// Giao 1 lần
            /// </summary>
            public int? IsDeliveryOnce { get; set; }

            /// <summary>
            /// Giao 1 lần
            /// </summary>
            /// <example>1</example>
            public int? OrderCombine { get; set; }

            /// <summary>
            /// Nhân viên kinh doanh
            /// </summary>
            public int? BusinessUserID { get; set; }

            /// <summary>
            /// Nhân viên hỗ trợ
            /// </summary>
            public int? BusinessSupportID { get; set; }

            /// <summary>
            /// Lot bán
            /// </summary>
            public string? SaleLots { get; set; }

            /// <summary>
            /// Check khách hàng tạo đơn
            /// </summary>
            public int? IsCustomer { get; set; }

            /// <summary>
            /// 1 nếu tất cả SP là MTS hoặc 0 nếu có ít nhất 1 SP không phải MTS
            /// </summary>
            public int? IsMTS { get; set; }

            /// <summary>
            /// Check hạn mức tín dụng
            /// </summary>
            public int? CheckCreditLimit { get; set; }

            /// <summary>
            /// Check tồn kho
            /// </summary>
            public int? CheckInventory { get; set; }

            /// <summary>
            /// Tiền hàng
            /// </summary>
            public decimal ItemsAmount { get; set; }

			/// <summary>
			/// Tổng tiền thuế
			/// </summary>
			public decimal VATAmount { get; set; }

            /// <summary>
            /// Tiền giảm giá
            /// </summary>
            public decimal DiscountAmount { get; set; }

            /// <summary>
            /// Tổng cộng
            /// </summary>
            public decimal TotalAmount { get; set; }

			/// <summary>
			/// Còn lại
			/// </summary>
			public decimal RemainAmount { get; set; }

			/// <summary>
			/// Tổng cộng (VND)
			/// </summary>
			public decimal TotalAmountVND { get; set; }

			/// <summary>
			/// Còn lại (VND)
			/// </summary>
			public decimal RemainAmountVND { get; set; }
				
			/// <summary>
			/// Đơn vị vận chuyển
			/// </summary>
			public int? ShippingUnitID { get; set; }

            /// <summary>
            /// Loại vận chuyển
            /// </summary>
            public int? ShippingTypeID { get; set; }

            /// <summary>
            /// Họ tên người nhận
            /// </summary>
            public string? ReceiverName { get; set; }

			/// <summary>
			/// Số xe
			/// </summary>
			public string? LicensePlate { get; set; }

			/// <summary>
			/// SĐT (người nhận)
			/// </summary>
			public string? ReceiverPhone { get; set; }

			/// <summary>
			/// CMND/CCCD/Bằng lái (người nhận)
			/// </summary>
			public string? ReceiverIdentityCode { get; set; }

			/// <summary>
			/// Địa chỉ nhận hàng
			/// </summary>
			public int? ReceivingAddressID { get; set; }

            /// <summary>
            /// Địa chỉ nhận hàng thực tế đại diện
            /// </summary>
            public int? ActualReceivingAddressID { get; set; }

            /// <summary>
            /// Địa chỉ nhận hàng thực tế của khách hàng
            /// </summary>
            public string? ActualReceivingAddress { get; set; }

            /// <summary>
			/// Ghi chú khách hàng
			/// </summary>
			public string? CustomerNote { get; set; }

            /// <summary>
            /// Ghi chú kinh doanh
            /// </summary>
            public string? BusinessNote { get; set; }

            /// <summary>
            /// Ghi chú kế toán
            /// </summary>
            public string? AccountantNote { get; set; }
			
            /// <summary>
            /// Ghi chú giao hàng
            /// </summary>
            public string? DeliveryNote { get; set; }

            /// <summary>
            /// Ghi chú xác nhận đặt hàng
            /// </summary>
            public string? Text1 { get; set; }

            /// <summary>
            /// Ghi chú thông tin khác khi in XNĐH
            /// </summary>
            public string? Text2 { get; set; }

            /// <summary>
			/// Điều kiện thương mại
			/// </summary>
			public int? IncotermID { get; set; }

            /// <summary>
			/// Điều kiện giao hàng
			/// </summary>
			public int? DeliveryTermID { get; set; }

            /// <summary>
            /// Ghi chú đơn hàng
            /// </summary>
            public string? OrderNote { get; set; }

            /// <summary>
            /// Điểm lên hàng
            /// </summary>
            public int? DeliveryPickupPointID { get; set; }

            /// <summary>
            /// Giao hàng đến
            /// </summary>
            public int? DeliveryToID { get; set; }

            /// <summary>
            /// Cảng xuất hàng
            /// </summary>
            public int? DeparturePortID { get; set; }

            /// <summary>
            /// Cảng dỡ hàng
            /// </summary>
            public int? DischargePortID { get; set; }

            /// <summary>
            /// Hạn giao hàng
            /// </summary>
            public string? DeliveryDueDate { get; set; }

			/// <summary>
			/// Trọng lượng hàng
			/// </summary>
			public decimal Weight { get; set; }

			/// <summary>
			/// Trọng lượng tổng
			/// </summary>
			public decimal TotalWeight { get; set; }

			/// <summary>
			/// Nhà máy
			/// </summary>
			public int? FactoryID { get; set; }

			/// <summary>
			/// Kho
			/// </summary>
			public int? WarehouseID { get; set; }

			/// <summary>
			/// Điểm xuất hàng
			/// </summary>
			public int? DeparturePointID { get; set; }

			/// <summary>
			/// Điểm lên hàng
			/// </summary>
			public int? PickupPointID { get; set; }

            /// <summary>
			/// NVKD giao
			/// </summary>
			public int? DeliverySalesStaffID { get; set; }

            /// <summary>
            /// Cust. Reference
            /// </summary>
            public string? CustReference { get; set; }

            /// <summary>
            /// Diễn giải
            /// </summary>
            public string? Description { get; set; }

            /// <summary>
            /// Cost center
            /// </summary>
            public string? CostCenter { get; set; }

            /// <summary>
            /// Cross sale
            /// </summary>
            public int? IsCrossSale { get; set; }

            /// <summary>
            /// Áp chiết khấu
            /// </summary>
            public int? ApplyDiscount { get; set; }

            /// <summary>
            /// Áp khuyến mãi
            /// </summary>
            public int? ApplyPromotion { get; set; }

            /// <summary>
            /// Áp trưng bày
            /// </summary>
            public int? ApplyExhibition { get; set; }

            /// <summary>
            /// Áp hỗ trợ vận chuyển
            /// </summary>
            public int? ApplyShipping { get; set; }

            /// <summary>
			/// Ghi chú khách hàng
			/// </summary>
			public string? BillCustomerNote { get; set; }

            /// <summary>
            /// Ghi chú kinh doanh
            /// </summary>
            public string? BillBusinessNote { get; set; }

            /// <summary>
            /// Ghi chú kế toán
            /// </summary>
            public string? BillAccountantNote { get; set; }

            /// <summary>
            /// Ghi chú giao hàng
            /// </summary>
            public string? BillDeliveryNote { get; set; }

            /// <summary>
            /// Khách hàng thanh toán
            /// </summary>
            public int? PaymentCustomerID { get; set; }

			/// <summary>
			/// Khách hàng xuất hóa đơn
			/// </summary>
			public int? CustomerInvoiceID { get; set; }

			/// <summary>
			/// Email nhận hóa đơn khác (nếu có)
			/// </summary>
			public string? OtherEmail { get; set; }

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

            /// <summary>
            /// Danh sách sản phẩm
            /// </summary>
            public List<AddOrderItem> Items { get; set; }
        }

        public class AddOrderItem : Add
        { 
	        /// <summary>
	        /// ID
	        /// </summary>
	        public int? ID { get; set; }

            /// <summary>
	        /// Số thứ tự
	        /// </summary>
            /// <example>000001</example>
	        public string? ItemNo { get; set; }

            /// <summary>
            /// Phân loại
            /// </summary>
            public int? ItemCatID { get; set; }

			/// <summary>
	        /// Sản phẩm
			/// </summary>
	        public int? ItemID { get; set; }

            /// <summary>
            /// Tên khác của hàng hóa
            /// </summary>
            public string? ItemText1 { get; set; }

            /// <summary>
            /// Tên khác của hàng hóa trên hóa đơn
            /// </summary>
            public string? ItemText2 { get; set; }

            /// <summary>
            /// Tên khác của hàng hóa
            /// </summary>
            public string? ItemText3 { get; set; }

            /// <summary>
            /// Mức thuế
            /// </summary>
            public int? VAT { get; set; }

			/// <summary>
	        /// Số lượng đặt
			/// </summary>
			public decimal OrderedQuantity { get; set; }
			
			/// <summary>
			/// Số lượng duyệt
			/// </summary>
			public decimal ApprovedQuantity { get; set; }

			/// <summary>
	        /// Đơn giá (+VAT)
			/// </summary>
			public decimal Price { get; set; }

			/// <summary>
	        /// Tiền hàng
			/// </summary>
	        public decimal ItemAmount { get; set; }

			/// <summary>
	        /// Tiền VAT
			/// </summary>
	        public decimal VATAmount { get; set; }

            /// <summary>
            /// Thành tiền
            /// </summary>
            public decimal TotalAmount { get; set; }

            /// <summary>
            /// Khối lượng
            /// </summary>
            public decimal NetWeight { get; set; }

            /// <summary>
            /// Khối lượng (bao gồm bao bì)
            /// </summary>
            public decimal GrossWeight { get; set; }

            /// <summary>
            /// Yêu cầu khác
            /// </summary>
            public string? OtherRequirements { get; set; }

            /// <summary>
            /// Nhà máy sản xuất
            /// </summary>
            public int? FactoryID { get; set; }

			/// <summary>
	        /// Kho xuất
			/// </summary>
	        public int? WarehouseID { get; set; }

			/// <summary>
	        /// Điểm xuất hàng
			/// </summary>
			public int? DeparturePointID { get; set; }

			/// <summary>
	        /// Loại hàng (MTS - MTO - MTS/MTO)
			/// </summary>
			public string? GoodsType { get; set; }

			/// <summary>
	        /// Bảo hành
			/// </summary>
	        public int? WarrantyID { get; set; }

            /// <summary>
            /// Áp chiết khấu
            /// </summary>
            public int? ApplyDiscount { get; set; }

            /// <summary>
            /// Áp khuyến mãi
            /// </summary>
            public int? ApplyPromotion { get; set; }

            /// <summary>
            /// Áp trưng bày
            /// </summary>
            public int? ApplyExhibition { get; set; }

            /// <summary>
            /// Áp hỗ trợ vận chuyển
            /// </summary>
            public int? ApplyShipping { get; set; }

            /// <summary>
            /// Ngày tính giá
            /// </summary>
            /// <example>2025-08-13</example>
            public string? PriceDate { get; set; }

            /// <summary>
            /// Tuyến đường
            /// </summary>
            /// <example></example>
            public int? RouteID { get; set; }

            /// <summary>
            /// POD (Bắt buộc check đối với SO xuất khẩu, dùng để xuất kho ghi nhận giá vốn)
            /// </summary>
            /// <example>0</example>
            public int? POD { get; set; }

            /// <summary>
            /// Cảng nhận hàng
            /// </summary>
            /// <example></example>
            public int? Incoterms2ID { get; set; }

            /// <summary>
            /// Chi tiết giá
            /// </summary>
            /// <example></example>
            public string Details { get; set; }

            /// <summary>
            /// Giá chung/Giá riêng
            /// </summary>
            public int IsGeneral { get; set; }

            /// <summary>
            /// Bảng giá áp dụng
            /// </summary>
            public string PriceOID { get; set; }
        }
        
        public class Submit : GetByOID
        {
	        public int? IsLock { get; set; }
        }

        public class GetByOID
        {
	        public string? OID { get; set; }
        }

        public class GetByCustomerID
		{
            /// <summary>
            /// Khách hàng
            /// </summary>
            public int? CustomerID { get; set; }
        }

        public class GetAddress
        {
            /// <summary>
            /// Khách hàng
            /// </summary>
            public int? CustomerID { get; set; }

            public int? IsCustomer { get; set; }
        }

        public class GetItems
        {
            /// <summary>
            /// Công ty
            /// </summary>
            /// <example></example>
            public string? CmpnID { get; set; }

            public string? FactorID { get; set; }

            public string? EntryID { get; set; }

            public string? ReferenceFactorID { get; set; }

            public string? ReferenceEntryID { get; set; }

            /// <summary>
            /// Số hợp đồng/báo giá
            /// </summary>
            public string? ReferenceID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Ngành hàng
            /// </summary>
            public int? GoodsTypeID { get; set; }

            /// <summary>
            /// Nhóm giá
            /// </summary>
            public int? PriceGroupID { get; set; }

            /// <summary>
            /// Ngày tính giá
            /// </summary>
            /// <example>2025-08-21</example>
            public string? PriceDate { get; set; }

            /// <summary>
            /// Tiền tệ
            /// </summary>
            public string? CurrencyType { get; set; }

            /// <summary>
            /// Áp chiết khấu
            /// </summary>
            public int? ApplyDiscount { get; set; }

            /// <summary>
            /// Áp khuyến mãi
            /// </summary>
            public int? ApplyPromotion { get; set; }

            /// <summary>
            /// Áp trưng bày
            /// </summary>
            public int? ApplyExhibition { get; set; }

            /// <summary>
            /// Áp hỗ trợ vận chuyển
            /// </summary>
            public int? ApplyShipping { get; set; }
        }

        public class CheckInventory
        {
            /// <summary>
            /// Công ty
            /// </summary>
            public string CmpnID { get; set; }

            public List<ItemInventory> Items { get; set; }
        }

        public class ItemInventory
        {
            /// <summary>
            /// Sản phẩm
            /// </summary>
            public int? ItemID { get; set; }

            /// <summary>
            /// Số lượng
            /// </summary>
            public decimal Quantity { get; set; }

            /// <summary>
            /// Kho
            /// </summary>
            public int? WarehouseID { get; set; }
        }

        public class Del : GetByOID
        {
        }
        
        public class EditPrices
        {
            /// <summary>
            /// Công ty
            /// </summary>
            public string CmpnID { get; set; }

            /// <summary>
            /// Nghiệp vụ
            /// </summary>
            public string? FactorID { get; set; }

            /// <summary>
            /// Chức năng
            /// </summary>
            public string? EntryID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
	        public int? CustomerID { get; set; }

            public string? ReferenceFactorID { get; set; }

            public string? ReferenceEntryID { get; set; }

            /// <summary>
            /// Số hợp đồng/báo giá
            /// </summary>
            public string? ReferenceID { get; set; }

            /// <summary>
            /// Nhóm giá
            /// </summary>
            public int? PriceGroupID { get; set; }

            /// <summary>
            /// Tiền tệ
            /// </summary>
            public string? CurrencyType { get; set; }

            public List<EditItemPrice> Items { get; set; }
        }

        public class EditItemPrice
        {
            /// <summary>
	        /// ID
	        /// </summary>
	        public int? ID { get; set; }

            /// <summary>
            /// Sản phẩm
            /// </summary>
            public int? ItemID { get; set; }

            /// <summary>
            /// Mức thuế
            /// </summary>
            public int? VAT { get; set; }

            /// <summary>
            /// Ngày tính giá
            /// </summary>
            /// <example>2025-08-21</example>
            public string? PriceDate { get; set; }

            /// <summary>
            /// Số lượng duyệt
            /// </summary>
            public decimal ApprovedQuantity { get; set; }

            /// <summary>
            /// Áp chiết khấu
            /// </summary>
            public int? ApplyDiscount { get; set; }

            /// <summary>
            /// Áp khuyến mãi
            /// </summary>
            public int? ApplyPromotion { get; set; }

            /// <summary>
            /// Áp trưng bày
            /// </summary>
            public int? ApplyExhibition { get; set; }

            /// <summary>
            /// Áp hỗ trợ vận chuyển
            /// </summary>
            public int? ApplyShipping { get; set; }

            /// <summary>
            /// Chi tiết giá
            /// </summary>
            /// <example></example>
            public string Details { get; set; }

            /// <summary>
            /// Giá chung/Giá riêng
            /// </summary>
            public int IsGeneral { get; set; }

            /// <summary>
            /// Bảng giá áp dụng
            /// </summary>
            public string PriceOID { get; set; }
        }

        public class Cancel : GetByOID
        {
            /// <summary>
            /// Lý do hủy
            /// </summary>
            public int? CancelReasonID { get; set; }

            /// <summary>
            /// Chi tiết lý do
            /// </summary>
            public string? CancelReason { get; set; }

            /// <summary>
            /// Tệp đính kèm (nếu có)
            /// </summary>
            public string? CancelLink { get; set; }
        }
    }
}