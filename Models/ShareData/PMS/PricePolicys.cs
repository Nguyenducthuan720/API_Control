namespace OsControl.Models.ShareData.PMS
{
    public class PricePolicys
    {
        public class Request
        {
            public class GetBasePrices
            {
                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>2A00</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Tổ chức bán hàng
                /// </summary>
                /// <example>2A02</example>
                public string? SalesOrgID { get; set; }

                /// <summary>
                /// Nhóm giá
                /// </summary>
                /// <example>07</example>
                public string? PriceGroupID { get; set; }

                /// <summary>
                /// SKU
                /// </summary>/
                /// <example>510101440003001</example>
                public string? SKU { get; set; }
            }
        }
    }
}
