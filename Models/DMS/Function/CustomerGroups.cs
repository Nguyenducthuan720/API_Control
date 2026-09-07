namespace APISmartCity.Models.Ver2.Function
{
    public class CustomerGroups
    {
        public class Request
        {
            public class GetByID
            {
                public int? ID { get; set; }
            }
            public class GetBYIDDetails
            {
                public int? UserID { get; set; }
            }
            public class GetGroupID
            {
                public string? GroupID { get; set; }
            }
            public class AddOrEditUsers
            {
                public int? UserID { get; set; }
                public int? GroupID { get; set; }
                public string? ListCustomerID { get; set; }
            }
            public class EditGroup
            {
                public int? UserID { get; set; }
                public int? GroupID { get; set; }
            }
        }
    }
}
