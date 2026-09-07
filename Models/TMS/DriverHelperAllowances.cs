namespace APISmartCity.Models.TMS
{
    public class DriverHelperAllowances
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Số tiền
                /// </summary>
                /// <example>500000</example>
                public string? AllowanceAmount { get; set; }

                /// <summary>
                /// Ngày áp dụng
                /// </summary>
                /// <example>18/11/2022</example>
                public string? ApplicationDate { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// Trạng thái
                /// </summary>
                /// <example></example>
                public string? IsActive { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từng
                /// </summary>
                /// <example>ÐXPCL/24/11/22/006</example>
                public string? ReceiptCode { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {/// <summary>
             /// Mã chứng từng </summary> <example>ÐXPCL/24/11/22/006</example>
                public string? ReceiptCode { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Del : GetByID
            {
            }
        }
    }
}