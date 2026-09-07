namespace APISmartCity.Models.Ver2.KPIConfigs;

public static class KPIConfigs
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }

        public class AddKPI : Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Plannings</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>KPIConfigs</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }
            
            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2024-11-19</example>
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
            /// Name
            /// </summary>
            /// <example></example>
            public string? Name { get; set; }

            /// <summary>
            /// NameExtention1
            /// </summary>
            /// <example></example>
            public string? NameExtention1 { get; set; }

            /// <summary>
            /// NameExtention2
            /// </summary>
            /// <example></example>
            public string? NameExtention2 { get; set; }

            /// <summary>
            /// NameExtention3
            /// </summary>
            /// <example></example>
            public string? NameExtention3 { get; set; }

            /// <summary>
            /// NameExtention4
            /// </summary>
            /// <example></example>
            public string? NameExtention4 { get; set; }

            /// <summary>
            /// NameExtention5
            /// </summary>
            /// <example></example>
            public string? NameExtention5 { get; set; }

            /// <summary>
            /// NameExtention6
            /// </summary>
            /// <example></example>
            public string? NameExtention6 { get; set; }

            /// <summary>
            /// NameExtention7
            /// </summary>
            /// <example></example>
            public string? NameExtention7 { get; set; }

            /// <summary>
            /// NameExtention8
            /// </summary>
            /// <example></example>
            public string? NameExtention8 { get; set; }

            /// <summary>
            /// NameExtention9
            /// </summary>
            /// <example></example>
            public string? NameExtention9 { get; set; }
            
            /// <summary>
            /// GoodsTypeID
            /// </summary>
            /// <example></example>
            public int? GoodsTypeID { get; set; }
            
            /// <summary>
            /// Year
            /// </summary>
            /// <example></example>
            public int? Year { get; set; }
            
            /// <summary>
            /// Link
            /// </summary>
            /// <example>Link</example>
            public string? Link { get; set; }
            
            /// <summary>
            /// ForecastingModels
            /// </summary>
            public List<AddForecastingModel> ForecastingModels { get; set; }
            
            /// <summary>
            /// DividedByNames
            /// </summary>
            public List<AddDividedByName> DividedByNames { get; set; }
            
            /// <summary>
            /// DividedByDepartments
            /// </summary>
            public List<AddDividedByDepartment> DividedByDepartments { get; set; }
            
            /// <summary>
            /// DividedByRegions
            /// </summary>
            public List<AddDividedByRegion> DividedByRegions { get; set; }
            
            /// <summary>
            /// SKUDividedByRegions
            /// </summary>
            public List<AddSKUDividedByRegion> SKUDividedByRegions { get; set; }
        }

        public class AddForecastingModel : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }
            
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// DepartmentID
            /// </summary>
            /// <example></example>
            public int? DepartmentID { get; set; }
            
            /// <summary>
            /// PastRate
            /// </summary>
            /// <example></example>
            public decimal PastRate { get; set; }
            
            /// <summary>
            /// ForecastRate
            /// </summary>
            /// <example></example>
            public decimal ForecastRate { get; set; }
            
            /// <summary>
            /// Month1
            /// </summary>
            /// <example></example>
            public int? Month1 { get; set; }
            
            /// <summary>
            /// Month2
            /// </summary>
            /// <example></example>
            public int? Month2 { get; set; }
            
            /// <summary>
            /// Month3
            /// </summary>
            /// <example></example>
            public int? Month3 { get; set; }
            
            /// <summary>
            /// Month4
            /// </summary>
            /// <example></example>
            public int? Month4 { get; set; }
            
            /// <summary>
            /// Month5
            /// </summary>
            /// <example></example>
            public int? Month5 { get; set; }
            
            /// <summary>
            /// Month6
            /// </summary>
            /// <example></example>
            public int? Month6 { get; set; }
            
            /// <summary>
            /// Month7
            /// </summary>
            /// <example></example>
            public int? Month7 { get; set; }
            
            /// <summary>
            /// Month8
            /// </summary>
            /// <example></example>
            public int? Month8 { get; set; }
            
            /// <summary>
            /// Month9
            /// </summary>
            /// <example></example>
            public int? Month9 { get; set; }
            
            /// <summary>
            /// Month10
            /// </summary>
            /// <example></example>
            public int? Month10 { get; set; }
            
            /// <summary>
            /// Month11
            /// </summary>
            /// <example></example>
            public int? Month11 { get; set; }
            
            /// <summary>
            /// Month12
            /// </summary>
            /// <example></example>
            public int? Month12 { get; set; }
        }
        
        public class AddDividedByName : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }
            
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// Content
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }
            
            /// <summary>
            /// Year
            /// </summary>
            /// <example></example>
            public int? Year { get; set; }
            
            /// <summary>
            /// Month1
            /// </summary>
            /// <example></example>
            public decimal Month1 { get; set; }
            
            /// <summary>
            /// Month2
            /// </summary>
            /// <example></example>
            public decimal Month2 { get; set; }
            
            /// <summary>
            /// Month3
            /// </summary>
            /// <example></example>
            public decimal Month3 { get; set; }
            
            /// <summary>
            /// Month4
            /// </summary>
            /// <example></example>
            public decimal Month4 { get; set; }
            
            /// <summary>
            /// Month5
            /// </summary>
            /// <example></example>
            public decimal Month5 { get; set; }
            
            /// <summary>
            /// Month6
            /// </summary>
            /// <example></example>
            public decimal Month6 { get; set; }
            
            /// <summary>
            /// Month7
            /// </summary>
            /// <example></example>
            public decimal Month7 { get; set; }
            
            /// <summary>
            /// Month8
            /// </summary>
            /// <example></example>
            public decimal Month8 { get; set; }
            
            /// <summary>
            /// Month9
            /// </summary>
            /// <example></example>
            public decimal Month9 { get; set; }
            
            /// <summary>
            /// Month10
            /// </summary>
            /// <example></example>
            public decimal Month10 { get; set; }
            
            /// <summary>
            /// Month11
            /// </summary>
            /// <example></example>
            public decimal Month11 { get; set; }
            
            /// <summary>
            /// Month12
            /// </summary>
            /// <example></example>
            public decimal Month12 { get; set; }
        }
        
        public class AddDividedByDepartment : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }
            
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// DepartmentID
            /// </summary>
            /// <example></example>
            public int? DepartmentID { get; set; }
            
            /// <summary>
            /// Rate
            /// </summary>
            /// <example></example>
            public decimal Rate { get; set; }
            
            /// <summary>
            /// Month1
            /// </summary>
            /// <example></example>
            public decimal Month1 { get; set; }
            
            /// <summary>
            /// Month2
            /// </summary>
            /// <example></example>
            public decimal Month2 { get; set; }
            
            /// <summary>
            /// Month3
            /// </summary>
            /// <example></example>
            public decimal Month3 { get; set; }
            
            /// <summary>
            /// Month4
            /// </summary>
            /// <example></example>
            public decimal Month4 { get; set; }
            
            /// <summary>
            /// Month5
            /// </summary>
            /// <example></example>
            public decimal Month5 { get; set; }
            
            /// <summary>
            /// Month6
            /// </summary>
            /// <example></example>
            public decimal Month6 { get; set; }
            
            /// <summary>
            /// Month7
            /// </summary>
            /// <example></example>
            public decimal Month7 { get; set; }
            
            /// <summary>
            /// Month8
            /// </summary>
            /// <example></example>
            public decimal Month8 { get; set; }
            
            /// <summary>
            /// Month9
            /// </summary>
            /// <example></example>
            public decimal Month9 { get; set; }
            
            /// <summary>
            /// Month10
            /// </summary>
            /// <example></example>
            public decimal Month10 { get; set; }
            
            /// <summary>
            /// Month11
            /// </summary>
            /// <example></example>
            public decimal Month11 { get; set; }
            
            /// <summary>
            /// Month12
            /// </summary>
            /// <example></example>
            public decimal Month12 { get; set; }
        }
        
        public class AddDividedByRegion : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }
            
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// RegionID
            /// </summary>
            /// <example></example>
            public int? RegionID { get; set; }
            
            /// <summary>
            /// PastRate
            /// </summary>
            /// <example></example>
            public decimal PastRate { get; set; }
            
            /// <summary>
            /// ForecastRate
            /// </summary>
            /// <example></example>
            public decimal ForecastRate { get; set; }
            
            /// <summary>
            /// PlanRate
            /// </summary>
            /// <example></example>
            public decimal PlanRate { get; set; }
            
            /// <summary>
            /// Month1
            /// </summary>
            /// <example></example>
            public int? Month1 { get; set; }
            
            /// <summary>
            /// Month2
            /// </summary>
            /// <example></example>
            public int? Month2 { get; set; }
            
            /// <summary>
            /// Month3
            /// </summary>
            /// <example></example>
            public int? Month3 { get; set; }
            
            /// <summary>
            /// Month4
            /// </summary>
            /// <example></example>
            public int? Month4 { get; set; }
            
            /// <summary>
            /// Month5
            /// </summary>
            /// <example></example>
            public int? Month5 { get; set; }
            
            /// <summary>
            /// Month6
            /// </summary>
            /// <example></example>
            public int? Month6 { get; set; }
            
            /// <summary>
            /// Month7
            /// </summary>
            /// <example></example>
            public int? Month7 { get; set; }
            
            /// <summary>
            /// Month8
            /// </summary>
            /// <example></example>
            public int? Month8 { get; set; }
            
            /// <summary>
            /// Month9
            /// </summary>
            /// <example></example>
            public int? Month9 { get; set; }
            
            /// <summary>
            /// Month10
            /// </summary>
            /// <example></example>
            public int? Month10 { get; set; }
            
            /// <summary>
            /// Month11
            /// </summary>
            /// <example></example>
            public int? Month11 { get; set; }
            
            /// <summary>
            /// Month12
            /// </summary>
            /// <example></example>
            public int? Month12 { get; set; }
        }
        
        public class AddSKUDividedByRegion : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example></example>
            public int? ID { get; set; }
            
            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// RegionID
            /// </summary>
            /// <example></example>
            public int? RegionID { get; set; }
            
            /// <summary>
            /// ItemID
            /// </summary>
            /// <example></example>
            public int? ItemID { get; set; }
            
            /// <summary>
            /// PastRate
            /// </summary>
            /// <example></example>
            public decimal PastRate { get; set; }
            
            /// <summary>
            /// ForecastRate
            /// </summary>
            /// <example></example>
            public decimal ForecastRate { get; set; }
            
            /// <summary>
            /// PlanRate
            /// </summary>
            /// <example></example>
            public decimal PlanRate { get; set; }
            
            /// <summary>
            /// Month1
            /// </summary>
            /// <example></example>
            public int? Month1 { get; set; }
            
            /// <summary>
            /// Month2
            /// </summary>
            /// <example></example>
            public int? Month2 { get; set; }
            
            /// <summary>
            /// Month3
            /// </summary>
            /// <example></example>
            public int? Month3 { get; set; }
            
            /// <summary>
            /// Month4
            /// </summary>
            /// <example></example>
            public int? Month4 { get; set; }
            
            /// <summary>
            /// Month5
            /// </summary>
            /// <example></example>
            public int? Month5 { get; set; }
            
            /// <summary>
            /// Month6
            /// </summary>
            /// <example></example>
            public int? Month6 { get; set; }
            
            /// <summary>
            /// Month7
            /// </summary>
            /// <example></example>
            public int? Month7 { get; set; }
            
            /// <summary>
            /// Month8
            /// </summary>
            /// <example></example>
            public int? Month8 { get; set; }
            
            /// <summary>
            /// Month9
            /// </summary>
            /// <example></example>
            public int? Month9 { get; set; }
            
            /// <summary>
            /// Month10
            /// </summary>
            /// <example></example>
            public int? Month10 { get; set; }
            
            /// <summary>
            /// Month11
            /// </summary>
            /// <example></example>
            public int? Month11 { get; set; }
            
            /// <summary>
            /// Month12
            /// </summary>
            /// <example></example>
            public int? Month12 { get; set; }
        }
        
        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
        }

        public class Del : GetByOID
        {
        }
    }
}