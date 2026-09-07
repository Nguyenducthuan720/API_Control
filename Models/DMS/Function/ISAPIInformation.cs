namespace APISmartCity.Models.Ver2.Function
{
    public class ISAPIInformation
    {
        /// <summary>
        /// Địa chỉ IP
        /// </summary>
        /// <example>222.253.41.238</example>
        public string? IPAddress { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        /// <example>50080</example>
        public string? HttpPort { get; set; }

        /// <summary>
        /// tên đăng nhập
        /// </summary>
        /// <example>admin</example>
        public string? UserName { get; set; }

        /// <summary>
        /// mật khẩu
        /// </summary>
        /// <example>namlong2020</example>
        public string? Password { get; set; }

        /// <summary>
        /// kênh
        /// </summary>
        /// <example>24</example>
        public int? Channel { get; set; }
    }
}