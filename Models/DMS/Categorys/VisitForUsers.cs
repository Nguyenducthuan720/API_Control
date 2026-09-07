namespace APISmartCity.Models.Categorys
{
    public static class VisitForUsers
    {
        public static class Request
        {
            

            public class CheckIn
            {
                public int? ID { get; set; }
                public decimal CheckIn_Lat { get; set; }
                public decimal CheckIn_Long { get; set; }
                public DateTime CheckInTime { get; set; }
                public string? LinkCheckIn { get; set; }
            }

            public class CheckOut
            {
                public int? ID { get; set; }
                public decimal CheckOut_Lat { get; set; }
                public decimal CheckOut_Long { get; set; }
                public DateTime CheckOutTime { get; set; }
                public string? LinkCheckOut { get; set; }
            }
            public class AddFeedBack
            {
                public int? ID { get; set; }
                public string? TypeMachines { get; set; }
                public string? NumberMachines { get; set; }
                public string? NumberWorkers { get; set; }
                public string? ConsumedOutput { get; set; }
                public string? CheckInNotes { get; set; }
                public string? FeedBack { get; set; }
                public string? LinkFeedBack { get; set; }
            }
            public class AddRival
            {
                public int? ID { get; set; }
                public string? RivalNote { get; set; }
                public string? LinkRival { get; set; }
            }

            public class OFFRoute
            {
                public int? ID { get; set; }
                public int? CustomerID { get; set; }
                public string? Reason { get; set; }
                public string? Link { get; set; }
            }
            public class AddBusiness
            {
                public int? ID { get; set; }
                public string? BusinessNote { get; set; }
                public string? LinkBusiness { get; set; }
            }

            public class Cancel
            {
                public int? ID { get; set; }
                public int? StatusID { get; set; }
                public string? StatisticReason { get; set; }
                public string? Link { get; set; }
            }

            public class AddInventory
            {
                public List<Inventory> inventoryList { get; set; }
            }

            public class Inventory
            {
                public int? PlanScheduleDetailID { get; set; }

                public int? ProductID { get; set; }

                public decimal Quantity { get; set; }

                public int? UnitID { get; set; }

                public int? ID { get; set; }
            }
            public class ByDay
            {
                public int? Option { get; set; }
                public DateTime FromDate { get; set; }
                public DateTime ToDate { get; set; }
            }
            public class DetailID
            {
                public int? ID { get; set; }
            }

            public class VisitDetails
            {
                public int? PlanScheduleDetailID { get; set; }

                public string? TypeLink { get; set; }

                public string? Link { get; set; }
            }
        }
    }
}