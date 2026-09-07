namespace APISmartCity.Models
{
    public class Contacts
    {
        public class Request
        {
            public class Add
            {
                /// <summary>
                /// Tên khách hàng
                /// </summary>
                /// <example>Hà Thị Yến</example>
                public string? CusFullName { get; set; }

                /// <summary>
                /// Sdt khách hàng
                /// </summary>
                /// <example>0123654987</example>
                public string? CusPhone { get; set; }

                /// <summary>
                /// Email khách hàng
                /// </summary>
                /// <example>yenne@gmail.com</example>
                public string? CusEmail { get; set; }

                /// <summary>
                /// Khách hàng nêu yêu cầu, câu hỏi
                /// </summary>
                /// <example>Ngày 10 rồi còn chưa có lương :(</example>
                public string? CusContent { get; set; }
            }

            public class Edit_Note : Del
            {
                /// <summary>
                /// Kết quả
                /// </summary>
                /// <example>Noted</example>
                public string? Result { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Noted</example>
                public string? Note { get; set; }
            }

            public class Edit_Approval
            {
                /// <summary>
                /// Số ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                /// <summary>
                /// Kết quả
                /// </summary>
                /// <example>Noted</example>
                public int? IsApproval { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Số ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
        }

        public class Response
        {
        }
    }
}