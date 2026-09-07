namespace APISmartCity.Models.Categorys
{
    public  class CustomerEvaluation
    {
        public  class Request
        {

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }

            public class AddOrEdit
            {
                public string? OID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? SAPID { get; set; }
                public string? LemonID { get; set; }
                public int? CustomerID { get; set; }
                public int? IsAddFromEval { get; set; }
                public DateTime? FromDate { get; set; }
                public DateTime? ToDate { get; set; }
                public string? Reason { get; set; }
                public string? StaffCount { get; set; }
                public string? OfficeArea { get; set; }
                public string? FactoryArea { get; set; }
                public string? BusinessSeniority { get; set; }
                public string? StaffAndInfrastructure { get; set; }
                public string? BusinessExperience { get; set; }
                public string? MainBusinessSector { get; set; }
                public string? OverallCustomerEvaluation { get; set; }
                public int? CustomerRankID { get; set; }
                public int? IsActive { get; set; }
                public string? Note { get; set; }
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
                public List<SalesPolicy> SalesPolicy { get; set; }
                public List<CustomerGoals> CustomerGoals { get; set; }
                public List<BusinessItem> BusinessItem { get; set; }
                public List<PurchaseOrder> PurchaseOrder { get; set; }

            }
            public class Supplier : GetByID
            {
                public int? ID { get; set; }
                public int? SupplierID { get; set; }
                public int? BusinessItemID { get; set; }
                public string? Note { get; set; }
                public int? IsActive { get; set; }
            }
            public class SalesPolicy : GetByID
            {
                public int? ID { get; set; }
                public string? SupplierID { get; set; }
                public int? ItemID { get; set; }
                public decimal ProductionQuantity { get; set; }
                public int? DeliveryMethodID { get; set; }
                public int? PaymentMethodID { get; set; }
                public decimal DiscountPolicy { get; set; }
                public int PaymentDueDate { get; set; }
                public decimal CreditLimit { get; set; }
                public int DeliveryDate { get; set; }
                public string? OtherSupportID { get; set; }
                public int? BankTransferMethodID { get; set; }
                public int? CurrencyTypeID { get; set; }
                public int? YearID { get; set; }
                public decimal Revenue { get; set; }
                public string? Note { get; set; }
                public int? IsActive { get; set; }
                public string? CmpnID { get; set; }
                public int? UnitID { get; set; }
            }
            public class CustomerGoals : GetByID
            {
                public int? ID { get; set; }
                public int? SectorID { get; set; }
                public decimal AverageQuantity { get; set; }
                public decimal AverageSales { get; set; }
                public int? UnitID { get; set; }
                public decimal Percentage { get; set; }
                public string? Address { get; set; }
                public string? Note { get; set; }
                public int? YearID { get; set; }
                public int? ItemID { get; set; }
                public int? CurrencyTypeID { get; set; }
                public int? IsActive { get; set; }
                public string? CmpnID { get; set; }
            }
            public class BusinessItem : GetByID
            {
                public int? ID { get; set; }
                public int? BusinessItemID { get; set; }
                public string? BrandID { get; set; }
                public string? SupplierID { get; set; }
                public int? SectorID { get; set; }
                public decimal ProductionOutput { get; set; }
                public int? MinimumQuantity { get; set; }
                public int? MaximumQuantity { get; set; }
                public decimal AverageSales { get; set; }
                public int? PaymentMethodID { get; set; }
                public string? Note { get; set; }
                public int? IsActive { get; set; }
                public string? CmpnID { get; set; }
            }
            public class PurchaseOrder : GetByID 
            {
                public int? ID { get; set; } 
                public string? OrderId { get; set; }
                public string? OrderDate { get; set; }
                public int? ItemID { get; set; }
                public decimal Quantity { get; set; }
                public decimal Revenue { get; set; }
                public string? Note { get; set; }
                public string? CmpnID { get; set; }
            }

            

            public class Del : GetByID
            {
            }
            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
            }
        }
    }
}