namespace DMS.Models.DMS.Inventorys;

public class SaleInventorys
{
    public class Request
    {
        public class GetItem
        {
            /// <summary>
            /// Sản phẩm
            /// </summary>
            /// <example>0</example>
            public string? ItemID { get; set; }
        }
    
        public class Get
        {       
            /// <summary>
            /// Ngành hàng
            /// </summary>
            /// <example></example>
            public string? GoodsTypes { get; set; }

            /// <summary>
            /// Sản phẩm
            /// </summary>
            /// <example></example>
            public string? ItemName { get; set; }
        }
    }
}