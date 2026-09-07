namespace APISmartCity.Models.Categorys
{
    public static class CreditLimitProposal
    {
        public static class Request
        {

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }

            public class GetBySO
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>%</example>
                public string? TypeGet { get; set; }

                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>%</example>
                public string? CustomerID { get; set; }


                /// <summary>
                /// SO
                /// </summary>
                /// <example>%</example>
                public string? OrderID { get; set; }
            }



            public class AddOrEdit 
            {
                public string? OID { get; set; }
                public DateTime Odate { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? SAPID { get; set; }
                public string? LemonID { get; set; }
                public int? ProposalTypeID { get; set; }
                public int? SalesTypeID { get; set; }
                public int? ObjectTypeID { get; set; }
                public int? ObjectID { get; set; }
                public decimal RequestedLimit { get; set; }
                public int? CurrencyTypeID { get; set; }
                public decimal ExchangeRate { get; set; }
                public decimal ConvertToVND { get; set; }
                public DateTime EffectiveDateFrom { get; set; }
                public DateTime EffectiveDateTo { get; set; }
                public int? PaymentTermsID { get; set; }
                public string? Description { get; set; }
                public string? Note { get; set; }
                public string? CustomerProposalContent { get; set; }
                public string? BusinessProposalContent { get; set; }
                public string? Link { get; set; }
                public decimal RequestedLimitSO { get; set; }
                public decimal RequestedLimitOD { get; set; }
                public int? GuarantorID { get; set; }
                public int? BeneficiaryID { get; set; }
                public int? GuaranteedEntityID { get; set; }
                public int? BeneficiaryEntity { get; set; }
                public int? GuarantorCustomerID { get; set; }
                public int? PartnerTypeID { get; set; }
                public decimal ConvertedCreditLimit { get; set; }
                public decimal ConvertedExportLimit { get; set; }
                public decimal SAPRequestedLimit { get; set; }
                public decimal SAPRequestedLimitSO { get; set; }
                public decimal SAPRequestedLimitOD { get; set; }
                public int? SAPCurrencyTypeID { get; set; }
                public decimal SAPExchangeRate { get; set; }
                public decimal SAPDefinedLimit { get; set; }
                public DateTime SAPExpirationDate { get; set; }
                public decimal SAPMaxDailySales3Months { get; set; }
                public decimal SAPAvgSales3Months { get; set; }
                public decimal SAPAvgReceivablesSales3Months { get; set; }
                public DateTime SAPDay1 { get; set; }
                public DateTime SAPDay2 { get; set; }
                public DateTime SAPDay3 { get; set; }
                public int? SAPOrderCountDay1 { get; set; }
                public int? SAPOrderCountDay2 { get; set; }
                public int? SAPOrderCountDay3 { get; set; }
                public decimal SAPSalesDay1 { get; set; }
                public decimal SAPSalesDay2 { get; set; }
                public decimal SAPSalesDay3 { get; set; }
                public string? Orders { get; set; }
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
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }
                public int? IsConfirm { get; set; }
                public string? ConfirmNote { get; set; }
                public string? ConfirmLink { get; set; }

                //Hạn mức ngắn hạn
                /// <summary>
                /// Trị giá SO
                /// </summary>
                /// <example>0</example>
                public decimal LimitValueSo { get; set; }

                /// <summary>
                /// Trị giá OD
                /// </summary>
                /// <example>0</example>
                public decimal LimitValueOd { get; set; }

                /// <summary>
                /// Số nợ phải thu
                /// </summary>
                /// <example>0</example>
                public decimal ReceivableAmount { get; set; }

                /// <summary>
                /// Hạn mức hiện tại
                /// </summary>
                /// <example>0</example>
                public decimal CurrentCreditLimit { get; set; }

                /// <summary>
                /// Hạn mức tín dụng đề nghị
                /// </summary>
                /// <example>0</example>
                public decimal CreditLimitProposed { get; set; }

                /// <summary>
                /// Hạn mức tín dụng đề xuất vượt
                /// </summary>
                /// <example>0</example>
                public decimal CreditLimitExceeded { get; set; }

                /// <summary>
                /// Tình trạng công nợ
                /// </summary>
                /// <example>''</example>
                public string DebtStatus { get; set; }

                /// <summary>
                /// Cam kết thanh toán
                /// </summary>
                /// <example>''</example>
                public string PaymentCommitment { get; set; }

                /// <summary>
                /// Danh sách đơn hàng (OID)
                /// </summary>
                /// <example>'DH1000/11/11/01, DH1000/11/11/02, DH1000/11/11/03 '</example>
                public string OrderList { get; set; }

                /// <summary>
                /// ID Công ty
                /// </summary>
                /// <example>''</example>
                public string CmpnID { get; set; }


            }
            public class GetCShop
            {
                /// <summary>
                /// Kind
                /// </summary>
                /// <example>0</example>
                public string? Kind { get; set; }
            }
            public class GetInfoSale
            {
                public int? ObjectTypeID { get; set; }

                public int? ObjectID { get; set; }

                public string CmpnID { get; set; }
            }

            public class GetSAPInfo
            {
                public int? ObjectTypeID { get; set; }
                public int? ObjectID { get; set; }
            }

            public class GetListCategory
            {
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
            }
            public class Del : GetByID
            {
            }
            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
                public int? IsConfirm { get; set; }
                public string? ConfirmNote { get; set; }
                public string? ConfirmLink { get; set; }

            }

            public class Confirm : GetByID
            {
                public int? IsConfirm { get; set; }
                public string? Note { get; set; }
                public string? Link { get; set; }
            }
        }
    }
}