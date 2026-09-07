using APISmartCity.Models.Categorys;

namespace DMS.Models.TMS.Category
{
    public static class NPLCustomers
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
                /// <summary>
                /// Mã khách hàng
                /// </summary>
                /// <example>7979</example>
                public string? Code { get; set; }

                /// <summary>
                /// Mã Lemon
                /// </summary>
                /// <example>LM1</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Địa chỉ
                /// </summary>
                /// <example>Ấp Dên Dên,TT Tân Phú,Đồng Phú,Bình Phước</example>
                public string? Address { get; set; }

                /// <summary>
                /// Địa chỉ 1
                /// </summary>
                /// <example>Den Den Hamlet, Tan Phu Town, Dong Phu, Binh Phuoc</example>
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
                /// Tên ngắn
                /// </summary>
                /// <example>Cty.NL</example>
                public string? ShortName { get; set; }

                /// <summary>
                /// Mã khu vực thành phố
                /// </summary>
                /// <example>51</example>
                public int? City { get; set; }

                /// <summary>
                /// District
                /// </summary>
                /// <example>633</example>
                public int? District { get; set; }

                /// <summary>
                /// Ward
                /// </summary>
                /// <example>9737</example>
                public int? Ward { get; set; }

                /// <summary>
                /// PhoneNumber
                /// </summary>
                /// <example>0986753421</example>
                public string? PhoneNumber { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>tes@gmail.com</example>
                public string? Email { get; set; }

                /// <summary>
                /// TaxCode
                /// </summary>
                /// <example>234563456</example>
                public string? TaxCode { get; set; }

                /// <summary>
                /// BankUsername
                /// </summary>
                /// <example>Nguyen Thanh An</example>
                public string? BankUsername { get; set; }

                /// <summary>
                /// BankNumber
                /// </summary>
                /// <example>5678290</example>
                public string? BankNumber { get; set; }

                /// <summary>
                /// BankID
                /// </summary>
                /// <example>1</example>
                public int? BankID { get; set; }

                /// <summary>
                /// ContactTypeID
                /// </summary>
                /// <example>4</example>
                public int? ContactTypeID { get; set; }

                /// <summary>
                /// GroupID
                /// </summary>
                /// <example>6</example>
                public int? GroupID { get; set; }

                /// <summary>
                /// EnterpriseEstablishmentDay
                /// </summary>
                /// <example>2012-02-14</example>
                public string? EnterpriseEstablishmentDay { get; set; }

                /// <summary>
                /// ChairmanBirthday
                /// </summary>
                /// <example>1974-05-31</example>
                public string? ChairmanBirthday { get; set; }

                /// <summary>
                /// OrderBirthday
                /// </summary>
                /// <example>1974-05-31</example>
                public string? OrderBirthday { get; set; }

                /// <summary>
                /// ManagementRegionID
                /// </summary>
                /// <example>100</example>
                public int? ManagementRegionID { get; set; }

                /// <summary>
                /// ProductTypeID
                /// </summary>
                /// <example>12</example>
                public int? ProductTypeID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }
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

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
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

            public class Search
            {
                public List<SearhParameter> ListSearch { get; set; }
            }

            public class SearhParameter
            {
                /// <summary>
                /// Tên cần search
                /// </summary>
                /// <example>NumberOfDayDebt</example>
                public string? Name { get; set; }

                /// <summary>
                /// Mã lấy từ customize Method
                /// </summary>
                /// <example>&gt;</example>
                public string? Operator { get; set; }

                /// <summary>
                /// Tham số 1
                /// </summary>
                /// <example>5</example>
                public string? Param1 { get; set; }

                /// <summary>
                /// Tham số 2
                /// </summary>
                /// <example>10</example>
                public string? Param2 { get; set; }
            }

            public class GetContactByCusID
            {
                /// <summary>
                /// Mã khách hàng đang chọn
                /// </summary>
                /// <example>1</example>
                public string? CusIDSelect { get; set; }
            }
        }
    }
}