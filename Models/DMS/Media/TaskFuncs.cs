namespace APISmartCity.Models.Ver2.Categorys
{
    public static class TaskFuncs
    {
        public class Requets
        {
            public class Content
            {

                public string? FactorID { get; set; } 

                public string? EntryID { get; set; } 

                public string? OID { get; set; }
            }

            public class GetByID
            {
                public string? OID { get; set; } = "";
            }

            public class Approval : Content
            {
                public int? ReceiveStatus { get; set; }

                public string? ReceiveLink { get; set; }

                public string? ReceiveContent { get; set; }

                public string? TransferLink { get; set; }

                public string? TransferContent { get; set; }

                public string? TransferNote { get; set; }
                public int? OwnerID { get; set; }
                public int? OwnerDeparment { get; set; }

                public string? FinalLink { get; set; }

                public DateTime FinalDate { get; set; }

                public string? FinalContent { get; set; }
            }
        }
    }
}
