using APISmartCity.Models.Categorys;

namespace APISmartCity.Models.CustomerProfileChanges
{
    public static class CustomerProfileChanges
    {
        public class Request
        {
            public class GetByID
            {
                public int? ID { get; set; }
            }
            public class AddOrEdit
            {
                public int? ID { get; set; }
                public int? CustomerLinkageID { get; set; }
                public string? ReferenceID { get; set; }
                public int? CustomerID { get; set; }
                public int? UserID { get; set; }
                public string? ODate { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? SAPID { get; set; }
                public string? LemonID { get; set; }
                public string? Name { get; set; }
                public string? NameExtention1 { get; set; }
                public string? NameExtention2 { get; set; }
                public string? NameExtention3 { get; set; }
                public string? NameExtention4 { get; set; }
                public string? NameExtention5 { get; set; }
                public string? NameExtention6 { get; set; }
                public string? NameExtention7 { get; set; }
                public string? NameExtention8 { get; set; }
                public string? NameExtention9 { get; set; }
                public string? ShortName { get; set; }
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
                public string? Extention21 { get; set; }
                public string? Extention22 { get; set; }
                public string? Extention23 { get; set; }
                public string? Extention24 { get; set; }
                public string? Extention25 { get; set; }
                public string? Extention26 { get; set; }
                public string? Extention27 { get; set; }
                public string? Extention28 { get; set; }
                public string? Extention29 { get; set; }
                public string? Extention30 { get; set; }
                public string? Extention31 { get; set; }
                public string? Extention32 { get; set; }
                public string? Extention33 { get; set; }
                public string? Extention34 { get; set; }
                public string? Extention35 { get; set; }
                public string? Extention36 { get; set; }
                public string? Extention37 { get; set; }
                public string? Extention38 { get; set; }
                public string? Extention39 { get; set; }
                public string? Extention40 { get; set; }

                public string? Extention41 { get; set; }
                public string? Extention42 { get; set; }
                public string? Extention43 { get; set; }
                public string? Extention44 { get; set; }
                public string? Extention45 { get; set; }
                public string? Extention46 { get; set; }
                public string? Extention47 { get; set; }
                public string? Extention48 { get; set; }
                public string? Extention49 { get; set; }
                public string? Extention50 { get; set; }
                public string? SearchName { get; set; }
                public int? CustomerTypeID { get; set; }
                public int? TypeShareholderID { get; set; }
                public int? CustomerSupportID { get; set; }
                public string? ProposedContent { get; set; }
                public string? Description { get; set; }
                public string? Phone { get; set; }
                public string? Fax { get; set; }
                public string? WebSite { get; set; }
                public string? Email { get; set; }
                public string? InvoiceEmail { get; set; }
                public int? HonorificsID { get; set; }
                public string? TaxCode { get; set; }
                public int? CustomerGroupID { get; set; }
                public int? PartnerTypeID { get; set; }
                public int? PartnerGroupID { get; set; }
                public int? IsCustomer { get; set; }
                public int? IsSupplier { get; set; }
                public int? IsCompleteDocuments { get; set; }
                public int? IsCustomerVIP { get; set; }
                public int? NationID { get; set; }
                public int? ProvinceID { get; set; }
                public int? DistrictID { get; set; }
                public int? Ward { get; set; }
                public string? Address { get; set; }
                public decimal Lat { get; set; }
                public decimal Long { get; set; }
                public string? PostalCode { get; set; }
                public int? ReceivingChannelID { get; set; }
                public string? Note { get; set; }
                public int? BusinessType { get; set; }
                public int? BusinessDomainID { get; set; }
                public string? BusinessScale { get; set; }
                public decimal RegisteredCapital { get; set; }
                public string? LegalRepresentative { get; set; }
                public string? IDCardNumber { get; set; }
                public int? CustomerClassificationID { get; set; }
                public string? BusinessRegistrationTypeID { get; set; }
                public string? BusinessLicense { get; set; }
                public string? TaxIssuedDate { get; set; }
                public string? FoundingDate { get; set; }
                public string? PartnerStartDate { get; set; }
                public string? SalesInvoiceEmail { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? AccountingInvoiceEmail { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? Quantity { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public decimal Revenue { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? EmployeeCount { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? BusinessProductsID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? IndustryMinQuantity { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? IndustryMaxQuantity { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? Infrastructure { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? Brand { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? OfficeArea { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? FactoryArea { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? CustomerOverview { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? SignatureLink { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? CustomerLink { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? SupplierName { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? ProductID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? ProductTargetID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? SupplierPurchaseQuantity { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public decimal AverageSales { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? SupplierPaymentTermsID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? ShippingMethodID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public decimal SupplierCreditLimit { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? PaymentMethodID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? YearID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public decimal AverageMonthlyQuantity { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public decimal AverageMonthlyRevenue { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public int? UnitID { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public decimal PercentageOfCustomerSales { get; set; }
                /// <summary>
                /// InvoiceEmail
                /// </summary>
                /// <example></example>
                public string? FactoryAddress { get; set; }
                public string? MainBusinessSector { get; set; }
                public string? OverallCustomerEvaluation { get; set; }
                public string? StaffAndInfrastructure { get; set; }
                public string? LinkEvaluation { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
                public int? SalesChannelID { get; set; }
                public int? SalesOrganizationID { get; set; }
                public int? DistributionChannelID { get; set; }
                public int? RegionID { get; set; }
                public string? Route { get; set; }
                public string? HotlineNumber { get; set; }
                public int? SalesManagerID { get; set; }
                public int? SalesRouteID { get; set; }
                public int? AreaSupervisorID { get; set; }
                public int? SalesStaffID { get; set; }
                //public int? AreaRouteDetailsID { get; set; }
                public int? SalesTeamID { get; set; }
                public int? SalesSubTeamID { get; set; }
                public int? CurrencyTypeID { get; set; }
                public int? WarehouseCriteriaID { get; set; }
                public int? PricingCriteriaID { get; set; }
                public int? ProcessDefinitionID { get; set; }
                public string? CustomerProductInfo { get; set; }
                public int? CustomerRepresentativeID { get; set; }
                public int? SupportAgentID { get; set; }
                public int? IsViewLimit { get; set; }
                public int? IsViewInventory { get; set; }
                public decimal LimitPercentage { get; set; }
                public decimal InventoryPercentage { get; set; }
                public decimal LoanInterest { get; set; }
                public int? SAPCurrencyTypeID { get; set; }
                public string? SAPWarehouseCriteriaID { get; set; }
                public string? SAPPricingCriteriaID { get; set; }
                public string? SAPProcessDefinitionID { get; set; }
                public int? SAPIncotermsVersionID { get; set; }
                public int? SAPTradeTermsID { get; set; }
                public int? SAPPaymentTermsID { get; set; }
                public int? SAPRevenueAccountCriteriaID { get; set; }
                //public int? SAPOutputTaxID { get; set; }
                public int? SAPTaxTypeID { get; set; }
                public string? SAPOrderTolerance { get; set; }
                public string? SAPCompanyCode { get; set; }
                public string? SAPCustomerArAccount { get; set; }
                public int? SAPCustomerCashflowGroup { get; set; }
                public string? SAPOldSystemCustomerCode { get; set; }
                public int? SAPPaymentMethodID { get; set; }
                public int? PortExportID { get; set; }
                public int? PortDestinationID { get; set; }
                public int? FactoryID { get; set; }
                public int? ExportWarehouseID { get; set; }
                public int? CommunicationLanguageID { get; set; }
                public int? BrandID { get; set; }
                public List<BusinessSector> BusinessSector { get; set; }
                /// <summary>
                /// Thông tin liên lạc
                /// </summary>
                public List<ContactInfo> Contacts { get; set; }
                /// <summary>
                /// Thông tin giao hàng 
                /// </summary>
                public List<ShippingInformation> Shipping { get; set; }
                /// <summary>
                /// Thông tin ngân hàng
                /// </summary>
                public List<Bank> Banks { get; set; }
                /// <summary>
                /// Thông tin giấy tờ hồ sơ
                /// </summary>
                public List<Documents> Documents { get; set; }
                //public List<Details> CustomerEvaluation { get; set; }


            }
            public class Customer
            {
                public int? ID { get; set; }
                public int? CustomerID { get; set; }
                public string? CategoryType { get; set; }
                public int? IsActive { get; set; }
                public string? CmpnID { get; set; }
            }

            public class ContactInfo : Customer
            {
                public string? Name { get; set; }
                public string? NameExtention1 { get; set; }
                public string? BirthDate { get; set; }
                public int? ResponsibilitiesID { get; set; }
                public string? Email { get; set; }
                public string? PhoneNumber { get; set; }
                public string? Note { get; set; }
            }
            public class CustomerGroup
            {
                public int? CustomerGroupID { get; set; }
            }
            public class BusinessSector
            {
                public int? BusinessSectorID { get; set; }

                public List<CustomerGroup> CustomerGroup { get; set; }
            }

            public class ShippingInformation : Customer
            {
                public string? LemonID { get; set; }
                public string? SAPID { get; set; }
                public string? WarehouseName { get; set; }
                public int? AddressID { get; set; }
                public string? Name { get; set; }
                public string? PhoneNumber { get; set; }
                public string? SpecialRequest { get; set; }
                public int? DefaultWarehouseID { get; set; }
                public int? ShipmentPortID { get; set; }
                public int? DestinationPortID { get; set; }
                public string? Note { get; set; }
                public int? ReceivingFormID { get; set; }
                public string? LicensePlate { get; set; }
                public string? DrivingLicense { get; set; }
                public decimal Lat { get; set; }
                public decimal Long { get; set; }

                public int? NationID { get; set; }

                public int? ProvinceID { get; set; }

                public int? DistrictID { get; set; }

                public string? Street { get; set; }
            }

            public class Bank : Customer
            {
                public int? BankID { get; set; }
                public string? AccountNumber { get; set; }
                public string? AccountHolder { get; set; }
                public string? Branch { get; set; }
                public string? Note { get; set; }
                public string? IBAN { get; set; }
                public int? NationID { get; set; }
            }
            public class Documents : Customer
            {
                public string? Name { get; set; }
                public string? Note { get; set; }
                public string? Link { get; set; }
            }
            public class ManagementInfo
            {
                public int? ID { get; set; }
                public int? CustomerID { get; set; }
                public int? SalesChannelID { get; set; }
                public int? SalesOrganizationID { get; set; }
                public int? DistributionChannelID { get; set; }
                public int? RegionID { get; set; }
                public int? Route { get; set; }
                public string? HotlineNumber { get; set; }
                public int? SalesManagerID { get; set; }
                public int? SalesRouteID { get; set; }
                public int? AreaSupervisorID { get; set; }
                public int? SalesStaffID { get; set; }
                //public int? AreaRouteDetailsID { get; set; }
                public int? SalesTeamID { get; set; }
                public int? SalesSubTeamID { get; set; }
                public int? CurrencyTypeID { get; set; }
                public int? WarehouseCriteriaID { get; set; }
                public int? PricingCriteriaID { get; set; }
                public int? ProcessDefinitionID { get; set; }
                public string? CustomerProductInfo { get; set; }
                public int? CustomerRepresentativeID { get; set; }
                public int? SupportAgentID { get; set; }
                public int? IsViewLimit { get; set; }
                public int? IsViewInventory { get; set; }
                public decimal LimitPercentage { get; set; }
                public decimal InventoryPercentage { get; set; }
                public int? SAPIncotermsVersionID { get; set; }
                public int? SAPTradeTermsID { get; set; }
                public int? SAPPaymentTermsID { get; set; }
                public int? SAPRevenueAccountCriteriaID { get; set; }
                //public int? SAPOutputTaxID { get; set; }
                public int? SAPTaxTypeID { get; set; }

                public string? SAPOrderTolerance { get; set; }
                public string? SAPCompanyCode { get; set; }
                public string? SAPCustomerArAccount { get; set; }
                public int? SAPCustomerCashflowGroup { get; set; }
                public string? SAPOldSystemCustomerCode { get; set; }
                public int? SAPPaymentMethodID { get; set; }
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
            public class Details : CustomerEvaluation.Request.AddOrEdit
            {

            }
        }
    }
}