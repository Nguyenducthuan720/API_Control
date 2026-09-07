namespace APISmartCity.Models.Ver2.Guests
{
    public class OrderDetailsGuests
    {
        public class Request
        {
            public class Content
            {
                public int? ItemID { get; set; }

                public int? UnitID { get; set; }

                public int? VAT { get; set; }

                public int? Quantity { get; set; }

                public decimal ItemPrice { get; set; }

                public decimal ItemPriceVAT { get; set; }

                public decimal PrdAmnt { get; set; }

                public decimal PrdAmntVAT { get; set; }

                public decimal DiscontPercent { get; set; }

                public decimal DiscountAmnt { get; set; }

                public int? AdjustPriceDetailID { get; set; }
            }

            public class Add : Content
            {
            }
        }
    }
}