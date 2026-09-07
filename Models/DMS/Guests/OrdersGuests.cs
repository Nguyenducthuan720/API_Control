namespace APISmartCity.Models.Ver2.Guests
{
    public class OrdersGuests
    {
        public class Request
        {
            public class Content
            {
                public decimal ProductAmntVAT { get; set; }

                public decimal ProductAmnt { get; set; }

                public string? VoucherCode { get; set; }

                public decimal VoucherAmnt { get; set; }

                public decimal TotalAmnt { get; set; }

                public int? CustomerDeliveryID { get; set; }
            }

            public class Add : Content
            {
                public List<OrderDetailsGuests.Request.Add> OrderDetails { get; set; }
            }

            public class GetByID
            {
                public string? OID { get; set; }
            }

            public class GetHistory
            {
                public string? FromDate { get; set; }
                public string? ToDate { get; set; }
            }
        }
    }
}