using APISmartCity.Models.Categorys;

namespace DMS.Models.TMS.Category
{
    public static class nPLCustomersDetails
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
                /// <summary>
                /// Mã liên kết Lemon
                /// </summary>
                /// <example>1</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// CusID
                /// </summary>
                /// <example>1</example>
                public int? CusID { get; set; }

                /// <summary>
                /// CategoryType
                /// </summary>
                /// <example>1</example>
                public string? CategoryType { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>1</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ 1
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention1 { get; set; }

                /// <summary>
                /// Địa chỉ 2
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention2 { get; set; }

                /// <summary>
                /// Địa chỉ 3
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention3 { get; set; }

                /// <summary>
                /// Địa chỉ 4
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention4 { get; set; }

                /// <summary>
                /// Địa chỉ 5
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention5 { get; set; }

                /// <summary>
                /// Địa chỉ 6
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention6 { get; set; }

                /// <summary>
                /// Địa chỉ 7
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention7 { get; set; }

                /// <summary>
                /// Địa chỉ 8
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention8 { get; set; }

                /// <summary>
                /// Địa chỉ 9
                /// </summary>
                /// <example>1</example>
                public string? AddressExtention9 { get; set; }

                /// <summary>
                /// Số điện thoại
                /// </summary>
                /// <example>1</example>
                public string? PhoneNumber { get; set; }

                /// <summary>
                /// Vị trí
                /// </summary>
                /// <example>1</example>
                public string? Position { get; set; }

                /// <summary>
                /// GPS
                /// </summary>
                /// <example>10.800078,106.7447379</example>
                public string? GPS { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>1</example>
                public string? Email { get; set; }

                /// <summary>
                /// Mã số thuế
                /// </summary>
                /// <example>1</example>
                public string? TaxCode { get; set; }

                /// <summary>
                /// Mã công việc phụ trách
                /// </summary>
                /// <example>1</example>
                public int? ChargeJobID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// CusID
                /// </summary>
                /// <example>1</example>
                public int? CusID { get; set; }

                /// <summary>
                /// CategoryType
                /// </summary>
                /// <example>Banks</example>
                public string? CategoryType { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }
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