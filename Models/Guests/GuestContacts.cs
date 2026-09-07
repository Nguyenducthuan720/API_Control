namespace APISmartCity.Models
{
    public static class GuestContacts
    {
        public static class Request
        {
            public class Add
            {
                public string? ParentID { get; set; }

                /// <summary>
                /// GeoCode
                /// </summary>
                /// <example>TREE</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example>Nguyen Van A</example>
                public string? Name { get; set; }

                /// <summary>
                /// Phone
                /// </summary>
                /// <example>0333666999</example>
                public string? Phone { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>email@gmail.com</example>
                public string? Email { get; set; }

                /// <summary>
                /// Subject
                /// </summary>
                /// <example>1</example>
                public string? Subject { get; set; }
                /// <summary>
                /// FeedBack
                /// </summary>
                /// <example>Note</example>
                public string? FeedBack { get; set; }
                /// <summary>
                /// Tie de FeedBack
                /// </summary>
                /// <example>Lừa Tiền</example>
                public string? FeedbackSubject { get; set; }

                /// <summary>
                /// Comment
                /// </summary>
                /// <example>Tài xế lừa tiền</example>
                public string? Comment { get; set; }
                /// <summary>
                /// FeedbackDate
                /// </summary>
                /// <example>Tài xế lừa tiền</example>
                public DateTime FeedbackDate { get; set; }

                /// <summary>
                /// Images
                /// </summary>
                /// <example>image.jpeg</example>
                public string? Images { get; set; }
            }
            public class EditContacts : Add
            {
                public string? ID { get; set; }
            }
            public class DelContacts 
            {
                public string? ID { get; set; }
            }

            public class SendFeedback
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// FeedbackSubject
                /// </summary>
                /// <example>Phản hồi: Re: Tiêu đề nè - Trường hợp số: 28</example>
                public string? FeedbackSubject { get; set; }

                /// <summary>
                /// Feedback as HTML
                /// </summary>
                /// <example><h1>This is heading 1</h1></example>
                public string? Feedback { get; set; }
            }

            public class GuestID_ByString
            {
                public string? GuestID { get; set; }
            }
            public class GetByParentID
            {
                public string? ParentID { get; set; }
            }
            public class ContactWithYou
            {
                public string? Name { get; set; }
                public string? Phone { get; set; }
                public string? Email { get; set; }
            }
        }
    }
}