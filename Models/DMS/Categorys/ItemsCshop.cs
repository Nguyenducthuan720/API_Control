using APISmartCity.Models.Categorys;
 
namespace APISmartCity.Models.Ver2.Categorys
{
    public static class ItemsCshop
    {
        public static class Request
        {
            public class Get
            {
                public string? GeoCode { get; set; }

            }
            public class GetByID : Get
            {
                public int? ID { get; set; }
            }

            public class GetProductTypeByID: Get
            {
                public int? ProductTypeID { get; set; }
            }
            public class GetByListID : Get
            {
                public string? ListGoodsTypeID { get; set; }
            }

            public class Cart
            {
                public int? ID { get; set; }
                public string? ItemType { get; set; }
                public int? ItemID { get; set; }
                public decimal ItemQty { get; set; }
                public decimal ItemPrice { get; set; }
                public decimal ItemTotalPrice  { get; set; }
                public int? GoodsTypeID { get; set; }
                public string? GeoCode { get; set; }
            }

            public class GetCart : Get
            {
                public string? ItemType { get; set; }
            }
            public class GetFavorite : Get
            {
                public string? ItemType { get; set; }
            }

            public class DelCart : Get
            {
                public string? ListID { get; set; }
            }

            public class  Search:Get 
            {
                public int? GoodsTypeID { get; set; }
                public int? TypeID { get; set; } 
                public int? ModelID { get; set; } 
                public int? CoreID { get; set; } 
                public int? ColorID { get; set; } 
                public int? DecorID { get; set; } 
                public int? PackagingID { get; set; } 
                public int? MoistureProofID { get; set; } 
                public int? PhysicalID { get; set; } 
                public int? ScratchResistanceID { get; set; } 
                public int? DensityID { get; set; } 
                public int? EmissionLevelID { get; set; } 
                public int? PlatingID { get; set; } 
                public int? RuloID { get; set; } 
                public int? GradeID { get; set; } 
                public int? CoreColorID { get; set; } 
                public int? BackingID { get; set; } 
                public int? GlueLineID { get; set; } 
                public int? PackagingGroupID { get; set; } 
                public int? NumberOfSurfacesID { get; set; } 
                public int? Specification1ID { get; set; } 
                public int? Specification2ID { get; set; } 
                public int? GlueTypeID { get; set; } 
                public int? MoldTypeID { get; set; } 
                public int? LockSeamID { get; set; } 
                public int? BrandM1ID { get; set; } 
                public int? ProductLineID { get; set; } 
                public int? PatternGroupM1ID { get; set; } 
                public int? PatternGroupM2ID { get; set; } 
                public int? ProductLineByPatternMoldID { get; set; } 
                public int? PatternM1ID { get; set; } 
                public int? PatternM2ID { get; set; } 
                public int? BackingThicknessID { get; set; } 
                public int? ColorCodeM1ID { get; set; } 
                public int? EmissionLevelForID { get; set; } 
                public int? ColorCodeM2ID { get; set; } 
                public int? ProductionGradeID { get; set; } 
                public int? MoldM1ID { get; set; } 
                public int? MoldM2ID { get; set; } 
                public int? OverlayPaperID { get; set; } 
                public int? DivisionM2ID { get; set; } 
                public int? BalancePaperID { get; set; } 
                public int? BrandM2ID { get; set; } 

            }


        }
    }
}