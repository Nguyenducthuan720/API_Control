namespace APISmartCity.Models.Ver2.ItemPublish
{
    public static class ItemPublish
    {
        public class Get
        {
            public int? Top { get; set; }
        }

        public class GetList
        {
            /// <summary>
            /// Category name
            /// </summary>
            /// <example>Đèn Led Pha</example>
            public string? CategoryName { get; set; }

            /// <summary>
            /// Order by
            /// </summary>
            /// <example>Best-Seller</example>
            public string? Order {  get; set; }

            /// <summary>
            /// PageNumber
            /// </summary>
            /// <example>1</example>
            public int? PageNumber { get; set; }
            /// <summary>
            /// PageSize
            /// </summary>
            /// <example>15</example>
            public int? PageSize { get; set; }

            public int? Top { get; set; }
        }

        public class GetMobile
        {
            /// <summary>
            /// AppCode
            /// </summary>
            /// <example>VGAS247</example>
            public string? AppCode { get; set; }

            public string? GoodsTypeID { get; set; }
            public int? Top { get; set; }
            public string? Order { get; set; }
        }

        public class GetByID
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>1021</example>
            public int? ID { get; set; }
        }

        public class Search : GetList
        {
            /// <summary>
            /// Tên sản phẩm cần tìm
            /// </summary>
            /// <example>den led</example>
            public string? SearchKey { get; set; }
        }
        public class GetDetailbyLink
        {
            public string? LinkItem { get; set; }
        }

        public class GetTypeItem
        {
            public string? TypeIndustry { get; set; }
        }

        public class GetListItem
        {   /// <summary>
            /// Code
            /// </summary>
            /// <example>%</example>
            public string? code { get; set; }
            /// <summary>
            /// Normal/Topsale/Topview/lowtohigh/hightolow 
            /// </summary>
            /// <example>Normal</example>
            public string? SortType { get; set; }
            /// <summary>
            /// trang số
            /// </summary>
            /// <example>1</example>
            public int? PageNumber { get; set; }

            /// <summary>
            /// số lượng bài trên 1 trang
            /// </summary>
            /// <example>10</example>
            public int? PageSize { get; set; }
        }
    }
}