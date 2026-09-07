using APISmartCity.Models.Categorys;
using static APISmartCity.Models.Categorys.CategoryDefault.Request;

namespace OsControl.Models.ShareData.PMS
{
    public static class ItemSAP
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
                public string? Code { get; set; }
                public string? LemonID { get; set; }
                public string? SKU { get; set; }
                public string? ScientificName { get; set; }
                public string? RepresentativeName { get; set; }
                public string? CustomsName { get; set; }
                public string? HSCode { get; set; }
                public string? ProductTags { get; set; }
                public decimal PriceNotVAT { get; set; }
                public string? VAT { get; set; }
                public decimal PriceVAT { get; set; }
                public string? LinkAvatar { get; set; }
                public string? LinkImg { get; set; }
                public string? GoodsTypeID { get; set; }
                public string? ItemGroupID { get; set; }
                public string? ProductTypeID { get; set; }
                public string? BrandGroupID { get; set; }
                public string? BrandID { get; set; }
                public string? ItemOrigin { get; set; }
                public string? MaterialTypeID { get; set; }
                public string? MaterialGroupID { get; set; }
                public string? GroupLevel3ID { get; set; }
                public string? ProductHierarchyID { get; set; }
                public string? CategoryGroupID { get; set; }
                public string? CoreBoardID { get; set; }
                public string? ColorID { get; set; }
                public string? EmissionLevelID { get; set; }
                public string? RuloID { get; set; }
                public string? NumberOfFacesID { get; set; }
                public string? PackingType1ID { get; set; }
                public string? GlueTypeID { get; set; }
                public string? ThicknessID { get; set; }
                public string? PatternGroupID { get; set; }
                public string? PatternID { get; set; }
                public string? CodeColorID { get; set; }
                public string? PhysicalID { get; set; }
                public string? PaperBalanceID { get; set; }
                public string? PackingType2ID { get; set; }
                public string? GlueTypeM2ID { get; set; }
                public string? PatternGroupM2ID { get; set; }
                public string? PatternM2ID { get; set; }
                public string? CodeColorM2ID { get; set; }
                public string? PhysicalM2ID { get; set; }
                public string? UnitSaleID { get; set; }
                public string? UnitBaseID { get; set; }
                public string? UnitWeightID { get; set; }
                public string? UnitSizeID { get; set; }
                public string? UnitVolumeID { get; set; }
                public decimal ConversionBase { get; set; }
                public decimal ConversionWeightNet { get; set; }
                public decimal ConversionWeightGross { get; set; }
                public string? Dimension { get; set; }
                public decimal Volume { get; set; }
                public string? SalesChannel { get; set; }
                /// <summary>
                /// Tuyến
                /// </summary>
                /// <example></example>
                public string? RouteSales { get; set; }
                /// <summary>
                /// Tuyến 1
                /// </summary>
                /// <example></example>
                public string? RouteSales1 { get; set; }
                /// <summary>
                /// Tuyến 2
                /// </summary>
                /// <example></example>
                public string? RouteSales2 { get; set; }
                /// <summary>
                /// Tuyến 3
                /// </summary>
                /// <example></example>
                public string? RouteSales3 { get; set; }
                /// <summary>
                /// Tuyến 4
                /// </summary>
                /// <example></example>
                public string? RouteSales4 { get; set; }
                /// <summary>
                /// public int? BrandID { get; set; }
                /// </summary>
                public int? NationID { get; set; }
                public int? Company { get; set; }
                public string? TotalWeight { get; set; }
                public string? NetWeight { get; set; }
                public string? Color { get; set; }
                public string? MaterialComposition { get; set; }
                public string? ManufacturingStandard { get; set; }
                public string? AntiCounterfeitTag { get; set; }
                public string? FireInsurance { get; set; }
                public string? InfoDetail { get; set; }
                public string? InfoDetailExtention1 { get; set; }
                public string? InfoDetailExtention2 { get; set; }
                public string? InfoDetailExtention3 { get; set; }
                public string? InfoDetailExtention4 { get; set; }
                public string? InfoDetailExtention5 { get; set; }
                public string? InfoDetailExtention6 { get; set; }
                public string? InfoDetailExtention7 { get; set; }
                public string? InfoDetailExtention8 { get; set; }
                public string? InfoDetailExtention9 { get; set; }

                public string? InfoDescription { get; set; }
                public string? InfoDescriptionExtention1 { get; set; }
                public string? InfoDescriptionExtention2 { get; set; }
                public string? InfoDescriptionExtention3 { get; set; }
                public string? InfoDescriptionExtention4 { get; set; }
                public string? InfoDescriptionExtention5 { get; set; }
                public string? InfoDescriptionExtention6 { get; set; }
                public string? InfoDescriptionExtention7 { get; set; }
                public string? InfoDescriptionExtention8 { get; set; }
                public string? InfoDescriptionExtention9 { get; set; }
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
                public int? IsActive { get; set; }
                public int? IsDeleted { get; set; }
                public int? ViewCount { get; set; }
                public string? CmpnID { get; set; }
                public string? CreateUser { get; set; }
                public DateTime CreateDate { get; set; }
                public string? ChangeUser { get; set; }
                public DateTime ChangeDate { get; set; }
                public string? AccAsgGrp { get; set; }
                public int? IsShowApp { get; set; }
            }
            public class Add : Content
            {
            }
            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public string? SKU { get; set; }
            }
            public class Get
            {
                public string? UsageType { get; set; }
            }
            public class GetByID
            {
                public string? SKU { get; set; }
            }
        }
    }
}