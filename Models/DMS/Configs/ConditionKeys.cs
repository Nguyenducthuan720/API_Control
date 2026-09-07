namespace DMS.Models.DMS.Configs;

public static class ConditionKeys
{
    public class Request
    {
        public class Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// Loại điều kiện
            /// </summary>
            /// <example></example>
            public string? EntryType { get; set; }

            /// <summary>
            /// Công thức
            /// </summary>
            /// <example>Sales org./Distr. Chl/Price Grp/Division</example>
            public string? Formula { get; set; }
            
            /// <summary>
            /// Công thức tham số
            /// </summary>
            /// <example>CmpnID/SalesChannelID/PriceGroupID/ProductTypeID</example>
            public string? Parameters { get; set; }

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

            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }
            
            /// <summary>
            /// Dùng/không
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
        }

        public class GetParam
        {
            public string? EntryType { get; set; }
        }

        public class GetByID
        {
            public int? ID { get; set; }
        }

        public class Del : GetByID
        {
        }

        public class GetConfigs
        {
            public string? Parameters { get; set; }
        }
    }
}