namespace APISmartCity.Models.Ver2.ProductionCapacitys;

public static class ProductionCapacitys
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }
            
            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
        }
        
        public class AddProductionCapacity : Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Plannings</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>ProductionCapacity</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2025-01-16</example>
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
            /// FactoryID
            /// </summary>
            /// <example></example>
            public int? FactoryID { get; set; }
			
            /// <summary>
            /// FromWeek
            /// </summary>
            /// <example></example>
            public int? FromWeek { get; set; }

            /// <summary>
            /// ToWeek
            /// </summary>
            /// <example></example>
            public int? ToWeek { get; set; }
            
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
            /// Link
            /// </summary>
            /// <example>Link</example>
            public string? Link { get; set; }
            
            /// <summary>
            /// Details
            /// </summary>
            public List<AddDetail> Details { get; set; }
        }
        
        public class AddDetail : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// Week
            /// </summary>
            /// <example></example>
            public int? Week { get; set; }
            
            /// <summary>
            /// ItemID
            /// </summary>
            /// <example></example>
            public int? ItemID { get; set; }
            
            /// <summary>
            /// Value1Kg
            /// </summary>
            /// <example>0</example>
            public int? Value1Kg { get; set; }

            /// <summary>
            /// Value5Kg
            /// </summary>
            /// <example></example>
            public int? Value5Kg { get; set; }
            
            /// <summary>
            /// D06
            /// </summary>
            /// <example></example>
            public int? D06 { get; set; }
            
            /// <summary>
            /// D0609
            /// </summary>
            /// <example>0</example>
            public int? D0609 { get; set; }

            /// <summary>
            /// RL300
            /// </summary>
            /// <example></example>
            public int? RL300 { get; set; }
            
            /// <summary>
            /// RLNhom
            /// </summary>
            /// <example></example>
            public int? RLNhom { get; set; }
            
            /// <summary>
            /// BS300
            /// </summary>
            /// <example>0</example>
            public int? BS300 { get; set; }

            /// <summary>
            /// Robot
            /// </summary>
            /// <example></example>
            public int? Robot { get; set; }
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