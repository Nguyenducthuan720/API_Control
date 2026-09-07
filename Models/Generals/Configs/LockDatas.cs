namespace APISmartCity.Models.Ver2.Configs
{
    public static class LockDatas
    {
        public static class Request
        {
            public class CheckLockData
            {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>1</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>1</example>
                public string? Type { get; set; }
            }

            public class LockData
            {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>1</example>
                public string? Period { get; set; }

                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>DP</example>
                public string? Type { get; set; }
            }

            public class GetTypes
            {
                /// <summary>
                /// Loại lock
                /// </summary>
                /// <example>DP</example>
                public string? Type { get; set; }
            }
        }
    }
}