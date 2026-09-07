using APISmartCity.Models.Systems;

namespace APISmartCity.Models.Categorys
{
    public static class GroupCusID_nPL
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
            }

            public class ContentRequest : Content
            {
            }

            public class Add : ContentRequest
            {
            }

            public class Edit : ContentRequest
            {
                /// <summary>
                /// Mã Phương thức liên hệ
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }

            public class EditStatus : Default.Request.EditStatus
            {
            }

            public class Del : Default.Request.Del
            {
            }
        }

        public static class Response
        {
        }
    }
}