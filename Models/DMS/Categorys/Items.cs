using APISmartCity.Models.Categorys;
using static APISmartCity.Models.Categorys.CategoryDefault.Request;

namespace APISmartCity.Models.Ver2.Categorys
{
    public static class Items
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
                public int? VAT { get; set; }
                public decimal PriceVAT { get; set; }
                public string? LinkAvatar { get; set; }
                public string? LinkImg { get; set; }
                public int? GoodsTypeID { get; set; }
                public int? ItemGroupID { get; set; }
                public int? ProductTypeID { get; set; }
                public int? BrandGroupID { get; set; }
                public int? Brand { get; set; }
                public string? ItemOrigin { get; set; }
                public int? CategoryGroupID { get; set; }
                public int? MaterialType { get; set; }
                public int? MaterialGroup { get; set; }
                public int? GroupLevel3 { get; set; }
                public int? ProductHierarchy { get; set; }
                public int? CoreBoardID { get; set; }
                public int? ColorID { get; set; }
                public int? EmissionLevelID { get; set; }
                public int? RuloID { get; set; }
                public int? NumberOfFacesID { get; set; }
                public int? PackingTypeID { get; set; }
                public int? GlueTypeID { get; set; }
                public int? ThicknessID { get; set; }
                public int? PatternGroupID { get; set; }
                public int? PatternID { get; set; }
                public int? CodeColorID { get; set; }
                public int? PhysicalID { get; set; }
                public int? PaperBalanceID { get; set; }
                public int? PackingType2ID { get; set; }
                public int? GlueTypeM2ID { get; set; }
                public int? PatternGroupM2ID { get; set; }
                public int? PatternM2ID { get; set; }
                public int? CodeColorM2ID { get; set; }
                public int? PhysicalM2ID { get; set; }
                public int? UnitSaleID { get; set; }
                public int? UnitBaseID { get; set; }
                public int? UnitWeightID { get; set; }
                public int? UnitSizeID { get; set; }
                public int? UnitVolumeID { get; set; }
                public decimal ConversionBase { get; set; }
                public decimal ConversionWeightNet { get; set; }
                public decimal ConversionWeightGross { get; set; }
                public string? Dimension { get; set; }
                public decimal Volume { get; set; }
                public int? SalesChannel { get; set; }
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
                public int? BrandID { get; set; }
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
                public string? ProductionType { get; set; }
            }

            public class Add : Content
            {
            }

            public class Get
            {
                /// <summary>
                /// UsageType
                /// </summary>
                /// <example>199279</example>
                public int? UsageType { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1021</example>
                public int? ID { get; set; }
            }

            public class GetByGoodTypeID
            {
                public string? ListID { get; set; }
            }
            public class IDs
            {
                public int? ID { get; set; }
            }

            public class GetByCustomer
            {
                public int? CustomerID { get; set; }
            }

            public class GetGoodsTypeID
            {
                public int? GoodsTypeID { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }
            }

            public class Search
            {
                public string? ListID { get; set; }
                public string? ListCoreBoard { get; set; }
                public string? Name { get; set; }
            }
        }
    }
}