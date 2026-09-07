namespace APISmartCity.Models.Ver2.ItemPublish
{
    public static class CustomerNoAuth
    {
        public class Register
        {
            /// <summary>
            /// AppCode
            /// </summary>
            /// <example>123</example>
            public string? AppCode { get; set; }

            /// <summary>
            /// Tên khách hàng
            /// </summary>
            /// <example>1</example>
            public string? UserFullName { get; set; }

            /// <summary>
            /// Email
            /// </summary>
            /// <example>abc@gmail.com</example>
            public string? UserEmail { get; set; }

            /// <summary>
            /// Số điện thoại
            /// </summary>
            /// <example>123465789</example>
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Mật khẩu
            /// </summary>
            /// <example>123</example>
            public string? UserPassword { get; set; }
        }
    }
}