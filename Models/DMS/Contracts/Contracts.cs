namespace APISmartCity.Models.Ver2.Contracts;

public static class Contracts
{
	public static class Request
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

        public class AddContract : Add
		{
			/// <summary>
			/// Nghiệp vụ
			/// </summary>
			/// <example>Contracts</example>
			public string? FactorID { get; set; }

			/// <summary>
			/// Chức năng
			/// </summary>
			/// <example>PrincipleContract</example>
			public string? EntryID { get; set; }

			/// <summary>
			/// Mã CT
			/// </summary>
			/// <example>0</example>
			public string? OID { get; set; }

			/// <summary>
			/// Ngày CT
			/// </summary>
			/// <example>2025-02-13</example>
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
			/// OID hợp đồng chính
			/// </summary>
			/// <example></example>
			public string? ContractID { get; set; }

			/// <summary>
			/// Báo giá
			/// </summary>
			/// <example></example>
			public string? QuotationID { get; set; }

			/// <summary>
			/// Inquiry
			/// </summary>
			/// <example></example>
			public string? InquiryID { get; set; }

			/// <summary>
			/// Từ ngày
			/// </summary>
			/// <example>2025-02-13</example>
			public string? FromDate { get; set; }

			/// <summary>
			/// Đến ngày
			/// </summary>
			/// <example>2025-03-20</example>
			public string? ToDate { get; set; }

			/// <summary>
			/// Đề xuất giữ hàng (Có/Không)
			/// </summary>
			/// <example>0</example>
			public int? IsHold { get; set; }

			/// <summary>
			/// Lý do giữ hàng
			/// </summary>
			/// <example></example>
			public string? HoldReason { get; set; }

			/// <summary>
			/// Tệp đính kèm
			/// </summary>
			/// <example></example>
			public string? HoldLink { get; set; }

			/// <summary>
			/// Tài khoản ngân hàng bên A
			/// </summary>
			/// <example>9914,9915</example>
			public string? ABankNumber { get; set; }

			/// <summary>
			/// Ủy nhiệm bên A
			/// </summary>
			/// <example></example>
			public int? AProxyID { get; set; }

            /// <summary>
            /// Sốy nhiệm bên A
            /// </summary>
            /// <example></example>
            public string? AAuthorizationNumber { get; set; }

            /// <summary>
            /// Khách hàng bên B
            /// </summary>
            /// <example></example>
            public int? BCustomerID { get; set; }

			/// <summary>
			/// Tài khoản ngân hàng bên B
			/// </summary>
			/// <example>9914</example>
			public string? BBankNumber { get; set; }

			/// <summary>
			/// Chức vụ (Người đại diện bên B)
			/// </summary>
			/// <example></example>
			public int? BPositionID { get; set; }

			/// <summary>
			/// Ủy nhiệm bên B
			/// </summary>
			/// <example></example>
			public int? BProxyID { get; set; }

            /// <summary>
            /// Số ủy nhiệm bên B
            /// </summary>
            /// <example></example>
            public string? BAuthorizationNumber { get; set; }

            /// <summary>
            /// In điều khoản chiết khấu
            /// </summary>
            /// <example>0</example>
            public int? PrintDiscountInfo { get; set; }

			/// <summary>
			/// Thông tin chiết khấu
			/// </summary>
			/// <example>Thông tin chiết khấu</example>
			public string? DiscountInfo { get; set; }

			/// <summary>
			/// SalerPhone
			/// </summary>
			/// <example>0123456789</example>
			public string? SalerPhone { get; set; }

			/// <summary>
			/// Lãi chậm thanh toán (%/ngày)
			/// </summary>
			/// <example>1</example>
			public double LatePaymentInterest { get; set; }

			/// <summary>
			/// In chi phí thanh toán qua ngân hàng
			/// </summary>
			/// <example>0</example>
			public int? PrintBankPaymentFee { get; set; }

			/// <summary>
			/// Chi phí thanh toán qua ngân hàng
			/// </summary>
			/// <example>chi phí thanh toán qua ngân hàng</example>
			public string? BankPaymentFee { get; set; }

			/// <summary>
			/// Thuế GTGT
			/// </summary>
			/// <example>10</example>
			public string? VATValues { get; set; }

			/// <summary>
			/// Dung sai (Danh mục)
			/// </summary>
			/// <example></example>
			public int? ToleranceID { get; set; }

			/// <summary>
			/// Giá trị dung sai (%)
			/// </summary>
			/// <example>10</example>
			public int? ToleranceValue { get; set; }

			/// <summary>
			/// Tổng cộng
			/// </summary>
			/// <example>0</example>
			public decimal ItemsAmount { get; set; }

			/// <summary>
			/// Trị giá tính thuế VAT
			/// </summary>
			/// <example></example>
			public decimal VATAmount { get; set; }

			/// <summary>
			/// Công nợ
			/// </summary>
			/// <example>0</example>
			public decimal DebtAmount { get; set; }

			/// <summary>
			/// Giá trị thanh toán
			/// </summary>
			/// <example>0</example>
			public decimal TotalAmount { get; set; }

			/// <summary>
			/// Số thùng
			/// </summary>
			public int? TotalCont { get; set; }

			/// <summary>
			/// Số Kg
			/// </summary>
			public decimal TotalWeight { get; set; }

			/// <summary>
			/// Số tiền (USD)
			/// </summary>
			public decimal TotalAmountUSD { get; set; }

			/// <summary>
			/// Diễn giải điều kiện thanh toán
			/// </summary>
			public string? PaymentDescription { get; set; }

			/// <summary>
			/// Từ ngày (giao nhận)
			/// </summary>
			/// <example>2025-02-13</example>
			public string? DeliveryFromDate { get; set; }

			/// <summary>
			/// Đến ngày (giao nhận)
			/// </summary>
			/// <example>2025-02-16</example>
			public string? DeliveryToDate { get; set; }

			/// <summary>
			/// Phương thức giao nhận
			/// </summary>
			/// <example></example>
			public int? DeliveryMethodID { get; set; }

			/// <summary>
			/// Số lần kiểm kê
			/// </summary>
			/// <example>2</example>
			public int? InventoryCount { get; set; }

			/// <summary>
			/// Địa điểm giao nhận
			/// </summary>
			/// <example></example>
			public string? DeliveryLocation { get; set; }

			/// <summary>
			/// Tên người nhận
			/// </summary>
			/// <example>Nguyễn Văn A</example>
			public string? ReceiverName { get; set; }

			/// <summary>
			/// SĐT người nhận
			/// </summary>
			/// <example>0123456789</example>
			public string? ReceiverPhone { get; set; }

			/// <summary>
			/// Cam kết chung
			/// </summary>
			/// <example>Cam kết chung</example>
			public string? CommitNote { get; set; }

			/// <summary>
			/// Trách nhiệm bên A
			/// </summary>
			/// <example>Trách nhiệm bên A</example>
			public string? AResponsibility { get; set; }

			/// <summary>
			/// Trách nhiệm bên B
			/// </summary>
			/// <example>Trách nhiệm bên B</example>
			public string? BResponsibility { get; set; }

			/// <summary>
			/// Điều khoản thay đổi/bổ sung
			/// </summary>
			/// <example>Điều khoản thay đổi/bổ sung</example>
			public string? AdditionalContent { get; set; }

			/// <summary>
			/// Ghi chú thêm
			/// </summary>
			/// <example>Ghi chú thêm</example>
			public string? AdditionalNote { get; set; }

			/// <summary>
			/// Thời gian thanh toán
			/// </summary>
			/// <example></example>
			public string? PaymentDate { get; set; }

			/// <summary>
			/// Nhóm giá
			/// </summary>
			/// <example></example>
			public int? PriceGroupID { get; set; }

			/// <summary>
			/// Bắt buộc cọc/thanh toán
			/// </summary>
			public int? RequiredDepositPayment { get; set; }

			/// <summary>
			/// Giá trị cọc/thanh toán
			/// </summary>
			public int? DepositPaymentValue { get; set; }

			/// <summary>
			/// Điều khoản thanh toán
			/// </summary>
			/// <example></example>
			public int? PaymentTermID { get; set; }

			/// <summary>
			/// Tòa án
			/// </summary>
			/// <example></example>
			public int? CourtID { get; set; }

			/// <summary>
			/// Số bản hợp đồng
			/// </summary>
			/// <example>4</example>
			public int? NumberOfContracts { get; set; }

			/// <summary>
			/// Số bản hợp đồng bên A giữ
			/// </summary>
			/// <example>2</example>
			public int? AContractHoldings { get; set; }

			/// <summary>
			/// Số bản hợp đồng bên B giữ
			/// </summary>
			/// <example>2</example>
			public int? BContractHoldings { get; set; }

			/// <summary>
			/// Tài liệu đính kèm
			/// </summary>
			/// <example></example>
			public string? Link { get; set; }

			/// <summary>
			/// Loại cont
			/// </summary>
			/// <example></example>
			public int? ContTypeID { get; set; }

			/// <summary>
			/// Số lượng cont
			/// </summary>
			/// <example></example>
			public int? ContQuantity { get; set; }

			/// <summary>
			/// Đóng gói
			/// </summary>
			/// <example></example>
			public string? Packaging { get; set; }

			/// <summary>
			/// Ký mã hiệu
			/// </summary>
			/// <example></example>
			public string? SignCode { get; set; }

			/// <summary>
			/// Số PI
			/// </summary>
			/// <example></example>
			public string? PINo { get; set; }

			/// <summary>
			/// Số Pallet
			/// </summary>
			/// <example></example>
			public string? PalletNo { get; set; }

			/// <summary>
			/// C/NO
			/// </summary>
			/// <example>MADE IN VIETNAM</example>
			public string? CNo { get; set; }

			/// <summary>
			/// Khối lượng cả bao bì
			/// </summary>
			/// <example>0</example>
			public int? GrossWeight { get; set; }

			/// <summary>
			/// Khối lượng tịnh
			/// </summary>
			/// <example>0</example>
			public int? NetWeight { get; set; }

			/// <summary>
			/// Incoterm
			/// </summary>
			/// <example>0</example>
			public int? IncotermID { get; set; }

			/// <summary>
			/// Điều kiện giao hàng
			/// </summary>
			/// <example>0</example>
			public int? DeliveryTermID { get; set; }

			/// <summary>
			/// Ghi chú đơn hàng
			/// </summary>
			public string? OrderNote { get; set; }

			/// <summary>
			/// Điểm lên hàng
			/// </summary>
			/// <example>0</example>
			public int? PickupPointID { get; set; }

			/// <summary>
			/// Giao hàng đến
			/// </summary>
			/// <example>0</example>
			public int? EndPointID { get; set; }

			/// <summary>
			/// Cảng xuất hàng
			/// </summary>
			public int? DeparturePortID { get; set; }

			/// <summary>
			/// Cảng dỡ hàng
			/// </summary>
			public int? DischargePortID { get; set; }

			/// <summary>
			/// Tài khoản
			/// </summary>
			public int? BankAccountID { get; set; }

			/// <summary>
			/// Ngân hàng
			/// </summary>
			public int? BankID { get; set; }

			/// <summary>
			/// Mã Swift ngân hàng
			/// </summary>
			public string? SwiftCode { get; set; }

			/// <summary>
			/// Số tài khoản
			/// </summary>
			public string? BankNumber { get; set; }

            /// <summary>
            /// Ngân sách tài trợ (Tối đa đối với Showroom có diện tích <100m2 (VND))
            /// </summary>
            public decimal SponsorshipBudgetMax100 { get; set; }

            /// <summary>
            /// Ngân sách tài trợ (Tối đa đối với Showroom có diện tích 100m2 <= diện tích <150m2 (VND))
            /// </summary>
            public decimal SponsorshipBudgetMax150 { get; set; }

            /// <summary>
            /// Chiết khấu trên đơn giá niêm yết cho nguyên vật liệu KES (áp dụng cho mặt hàng Ván Sàn, Melamine) (%)
            /// </summary>
            public int? DiscountOnKES { get; set; }

            /// <summary>
            /// Chiết khấu trên đơn giá niêm yết cho mặt hàng Laminate, Acrylic (%)
            /// </summary>
            public int? DiscountOnLaminate { get; set; }

            /// <summary>
            /// Trong thời hạn tối đa kể từ ngày Hợp đồng được ký kết và Bên B bàn giao mặt bằng hạ tầng kỹ thuật theo đúng thiết kế (ngày)
            /// </summary>
            public int? InstallationLimitDays { get; set; }

            /// <summary>
            /// Địa điểm lắp đặt
            /// </summary>
            public string? InstallationLocation { get; set; }

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
            /// Công ty
            /// </summary>
            /// <example>0</example>
            public string? CmpnID { get; set; }

            /// <summary>
            /// Tiền tệ
            /// </summary>
            /// <example>0</example>
            public int? CurrencyTypeID { get; set; }

            /// <summary>
            /// Tỷ giá
            /// </summary>
            /// <example>0</example>
            public decimal CurrencyRate { get; set; }

            /// <summary>
            /// Ngày tỷ giá
            /// </summary>
            /// <example>0</example>
            public string? CurrencyDate { get; set; }

            /// <summary>
            /// Điều kiện thanh toán
            /// </summary>
            public List<AddContractPayment> Payments { get; set; }

			/// <summary>
			/// Hồ sơ chứng từ thanh toán
			/// </summary>
			public List<AddContractDocument> Documents { get; set; }

			/// <summary>
			/// Tên hàng - Quy cách - Đơn giá - Trị giá hợp đồng
			/// </summary>
			public List<AddContractItem> Items { get; set; }

			/// <summary>
			/// Chiết khấu
			/// </summary>
			public List<AddContractDiscount> Discounts { get; set; }

			/// <summary>
			/// Sản phẩm phân phối
			/// </summary>
			public List<AddContractProduct> Products { get; set; }

			/// <summary>
			/// Cam kết phân phối
			/// </summary>
			public List<AddContractCommit> Commits { get; set; }

			/// <summary>
			/// Đặt hàng
			/// </summary>
			public List<AddContractOrder> Orders { get; set; }

            /// <summary>
            /// Giá trị tài trợ
            /// </summary>
            public List<AddContractSponsorship> Sponsorships { get; set; }
        }

		public class AddContractPayment : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Đợt thanh toán
			/// </summary>
			/// <example>1</example>
			public int? PaymentNo { get; set; }

			/// <summary>
			/// Nội dung thanh toán (Danh mục)
			/// </summary>
			/// <example>0</example>
			public int? PaymentTermID { get; set; }

			/// <summary>
			/// Ngày thanh toán
			/// </summary>
			/// <example>2025-02-20</example>
			public string? PaymentDate { get; set; }
		}

		public class AddContractDocument : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Đợt thanh toán
			/// </summary>
			/// <example>0</example>
			public int? PaymentNo { get; set; }

			/// <summary>
			/// Chứng từ (danh mục)
			/// </summary>
			/// <example>0</example>
			public int? DocumentID { get; set; }
		}

		public class AddContractDiscount : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Mặt hàng
			/// </summary>
			/// <example>0</example>
			public int? GoodsTypeID { get; set; }

			/// <summary>
			/// Đơn vị tính
			/// </summary>
			/// <example>0</example>
			public int? ItemUnitID { get; set; }

			/// <summary>
			/// Tính theo sản lượng/doanh thu
			/// </summary>
			/// <example>0</example>
			public int? IsRevenue { get; set; }

			/// <summary>
			/// Điều kiện 1
			/// </summary>
			/// <example>0</example>
			public string? Condition1 { get; set; }

			/// <summary>
			/// Sản lượng/Doanh thu 1
			/// </summary>
			/// <example>0</example>
			public decimal Quantity1 { get; set; }

			/// <summary>
			/// Chiết khấu 1
			/// </summary>
			/// <example>0</example>
			public decimal Discount1 { get; set; }

			/// <summary>
			/// Điều kiện 2
			/// </summary>
			/// <example>0</example>
			public string? Condition2 { get; set; }

			/// <summary>
			/// Sản lượng/Doanh thu 2
			/// </summary>
			/// <example>0</example>
			public decimal Quantity2 { get; set; }

			/// <summary>
			/// Chiết khấu 2
			/// </summary>
			/// <example>0</example>
			public decimal Discount2 { get; set; }

			/// <summary>
			/// Điều kiện 3
			/// </summary>
			/// <example>0</example>
			public string? Condition3 { get; set; }

			/// <summary>
			/// Sản lượng/Doanh thu 3
			/// </summary>
			/// <example>0</example>
			public decimal Quantity3 { get; set; }

			/// <summary>
			/// Chiết khấu 3
			/// </summary>
			/// <example>0</example>
			public decimal Discount3 { get; set; }

			/// <summary>
			/// Điều kiện 4
			/// </summary>
			/// <example>0</example>
			public string? Condition4 { get; set; }

			/// <summary>
			/// Sản lượng/Doanh thu 4
			/// </summary>
			/// <example>0</example>
			public decimal Quantity4 { get; set; }

			/// <summary>
			/// Chiết khấu 4
			/// </summary>
			/// <example>0</example>
			public decimal Discount4 { get; set; }
		}

		public class AddContractItem : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

            /// <summary>
            /// 1 = Giá chung, 0 = Giá riêng
            /// </summary>
            /// <example>1</example>
            public int? IsGeneral { get; set; }

            /// <summary>
            /// Mã bảng giá
            /// </summary>
            /// <example></example>
            public string? PriceOID { get; set; }

            /// <summary>
            /// Sản phẩm
            /// </summary>
            /// <example>0</example>
            public int? ItemID { get; set; }

			/// <summary>
			/// VAT
			/// </summary>
			/// <example>0</example>
			public int? VAT { get; set; }

			/// <summary>
			/// Số lượng
			/// </summary>
			/// <example>1</example>
			public decimal Quantity { get; set; }

			/// <summary>
			/// Đơn giá
			/// </summary>
			/// <example>0</example>
			public decimal Price { get; set; }

			/// <summary>
			/// Đơn giá (Không VAT)
			/// </summary>
			/// <example>0</example>
			public decimal PriceNotVAT { get; set; }

			/// <summary>
			/// Thành tiền
			/// </summary>
			/// <example>0</example>
			public decimal ItemAmount { get; set; }

			/// <summary>
			/// Thuế
			/// </summary>
			/// <example>0</example>
			public decimal VATAmount { get; set; }

			/// <summary>
			/// Tổng trị giá
			/// </summary>
			/// <example>0</example>
			public decimal TotalAmount { get; set; }

			/// <summary>
			/// Chi tiết giá
			/// </summary>
			/// <example>[]</example>
			public string? Details { get; set; }

            /// <summary>
            /// Yêu cầu khác
            /// </summary>
			/// <example></example>
            public string? OtherRequirements { get; set; }

            /// <summary>
            /// Bảo hành
            /// </summary>
            /// <example>1</example>
            public int? WarrantyID { get; set; }

            /// <summary>
            /// Nhà máy sản xuất
            /// </summary>
            /// <example>1</example>
            public int? FactoryID { get; set; }

            /// <summary>
            /// Kho
            /// </summary>
            /// <example>1</example>
            public int? WarehouseID { get; set; }

            /// <summary>
            /// Điểm xuất hàng
            /// </summary>
            /// <example>1</example>
            public int? DeparturePointID { get; set; }
		}

		public class AddContractProduct : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Nhóm sản phẩm
			/// </summary>
			/// <example>0</example>
			public int? ItemGroupID { get; set; }

			/// <summary>
			/// Dòng sản phẩm
			/// </summary>
			/// <example>0</example>
			public int? SeriesID { get; set; }

			/// <summary>
			/// Sản lượng 1
			/// </summary>
			/// <example>0</example>
			public decimal Quantity1 { get; set; }

			/// <summary>
			/// Sản lượng 2
			/// </summary>
			/// <example>0</example>
			public decimal Quantity2 { get; set; }

			/// <summary>
			/// Sản lượng 3
			/// </summary>
			/// <example>0</example>
			public decimal Quantity3 { get; set; }

			/// <summary>
			/// Sản lượng 4
			/// </summary>
			/// <example>0</example>
			public decimal Quantity4 { get; set; }

			/// <summary>
			/// Sản lượng 5
			/// </summary>
			/// <example>0</example>
			public decimal Quantity5 { get; set; }

			/// <summary>
			/// Sản lượng 6
			/// </summary>
			/// <example>0</example>
			public decimal Quantity6 { get; set; }

			/// <summary>
			/// Sản lượng 7
			/// </summary>
			/// <example>0</example>
			public decimal Quantity7 { get; set; }

			/// <summary>
			/// Sản lượng 
			/// </summary>
			/// <example>0</example>
			public decimal Quantity8 { get; set; }

			/// <summary>
			/// Sản lượng 9
			/// </summary>
			/// <example>0</example>
			public decimal Quantity9 { get; set; }

			/// <summary>
			/// Sản lượng 10
			/// </summary>
			/// <example>0</example>
			public decimal Quantity10 { get; set; }

			/// <summary>
			/// Sản lượng 11
			/// </summary>
			/// <example>0</example>
			public decimal Quantity11 { get; set; }

			/// <summary>
			/// Sản lượng 12
			/// </summary>
			/// <example>0</example>
			public decimal Quantity12 { get; set; }

			/// <summary>
			/// Sản lượng tổng
			/// </summary>
			/// <example>0</example>
			public decimal TotalQuantity { get; set; }
		}

		public class AddContractCommit : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Nhóm sản phẩm
			/// </summary>
			/// <example>0</example>
			public int? ItemGroupID { get; set; }

			/// <summary>
			/// Số lượng mã sản phẩm tồn kho và triển khai ra thị trường
			/// </summary>
			/// <example></example>
			public string? ItemCodeQuantity { get; set; }

			/// <summary>
			/// Số điểm bán tối thiểu triển khai trên thị trường
			/// </summary>
			/// <example></example>
			public string? MinimumSalePoints { get; set; }
		}

		public class AddContractOrder : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Sản phẩm
			/// </summary>
			/// <example>0</example>
			public int? ItemID { get; set; }

			/// <summary>
			/// Số thùng
			/// </summary>
			/// <example>0</example>
			public int? ContQuantity { get; set; }

			/// <summary>
			/// Số KG
			/// </summary>
			/// <example>0</example>
			public decimal Weight { get; set; }

			/// <summary>
			/// Đơn giá (USD/KG)	
			/// </summary>
			/// <example>0</example>
			public decimal Price { get; set; }

			/// <summary>
			/// Số tiền (USD)	
			/// </summary>
			/// <example>0</example>
			public decimal USDAmount { get; set; }

			/// <summary>
			/// Số KG 1
			/// </summary>
			/// <example>0</example>
			public decimal Weight1 { get; set; }

			/// <summary>
			/// Thời gian giao 1
			/// </summary>
			/// <example></example>
			public string? DeliveryDate1 { get; set; }

			/// <summary>
			/// Số KG 2
			/// </summary>
			/// <example>0</example>
			public decimal Weight2 { get; set; }

			/// <summary>
			/// Thời gian giao 2
			/// </summary>
			/// <example></example>
			public string? DeliveryDate2 { get; set; }

			/// <summary>
			/// Số KG 3
			/// </summary>
			/// <example>0</example>
			public decimal Weight3 { get; set; }

			/// <summary>
			/// Thời gian giao 3
			/// </summary>
			/// <example></example>
			public string? DeliveryDate3 { get; set; }

			/// <summary>
			/// Số KG 4
			/// </summary>
			/// <example>0</example>
			public decimal Weight4 { get; set; }

			/// <summary>
			/// Thời gian giao 4
			/// </summary>
			/// <example></example>
			public string? DeliveryDate4 { get; set; }
		}

        public class AddContractSponsorship : Add
        {
			/// <summary>
			/// ID
			/// </summary>
            public int? ID { get; set; }

            /// <summary>
            /// Nội dung tài trợ
            /// </summary>
			/// <example></example>
            public string? Content { get; set; }

			/// <summary>
			/// Giá trị
			/// </summary>
			public decimal Amount { get; set; }
        }

        public class Submit : GetByOID
		{
			public int? IsLock { get; set; }
		}

		public class GetByOID
		{
			public string? OID { get; set; }
		}

		public class GetItems
		{
            /// <summary>
            /// Nghiệp vụ
            /// </summary>
            /// <example>QuotationDomestic</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// Chức năng
            /// </summary>
            /// <example>DomesticVLH</example>
            public string? EntryID { get; set; }

            ///// <summary>
            ///// Báo giá
            ///// </summary>
            //public string? QuotationID { get; set; }

			/// <summary>
			/// Khách hàng
			/// </summary>
			public int? BCustomerID { get; set; }

            /// <summary>
            /// Nhóm giá
            /// </summary>
            public int? PriceGroupID { get; set; }

            /// <summary>
            /// Tiền tệ
            /// </summary>
            /// <example>0</example>
            public int? CurrencyTypeID { get; set; }

            /// <summary>
            /// Công ty
            /// </summary>
            /// <example>0</example>
            public string? CmpnID { get; set; }
        }

		public class EditPrices : GetItems
		{
            /// <summary>
            /// Tên hàng - Quy cách - Đơn giá - Trị giá hợp đồng
            /// </summary>
            public List<AddContractItem> Items { get; set; }
        }

		public class GetDiscounts
		{
            /// <summary>
            /// Công ty
            /// </summary>
            /// <example>0</example>
            public string? CmpnID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            public int? BCustomerID { get; set; }
        }

        public class Del : GetByOID
		{
		}

		public class CustomerSign : GetByOID
		{
			public string? Link { get; set; }
			public string? ApprovalNote { get; set; }
		}

		public class Extend : GetByOID
		{
			/// <summary>
			/// Nội dung gia hạn
			/// </summary>
			/// <example></example>
			public string? ExtendContent { get; set; }

			/// <summary>
			/// Tệp đinh kèm
			/// </summary>
			/// <example></example>
			public string? ExtendLink { get; set; }
		}

		public class Cancel : GetByOID
		{
			/// <summary>
			/// Lý do hủy
			/// </summary>
			/// <example></example>
			public int? CancelReasonID { get; set; }

			/// <summary>
			/// Nội dung hủy
			/// </summary>
			/// <example></example>
			public string? CancelContent { get; set; }

			/// <summary>
			/// Tệp đính kèm
			/// </summary>
			/// <example></example>
			public string? CancelLink { get; set; }

		}
	}
}