using APISmartCity.Models.Categorys;

namespace DMS.Models.TMS.Category
{
    public static class NPLDrivers
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
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
                /// Hộ khẩu thường trú
                /// </summary>
                /// <example>131 Bành Văn Trân, phường 7, Tân Bình, Thành phố Hồ Chí Minh</example>
                public string? PermanentResidence { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 1
                /// </summary>
                /// <example>131 Banh Van Tran, Ward 7, Tan Binh, Ho Chi Minh City</example>
                public string? PermanentResidenceExtention1 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 2
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention2 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 3
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention3 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 4
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention4 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 5
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention5 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 6
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention6 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 7
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention7 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 8
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention8 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 9
                /// </summary>
                /// <example>1</example>
                public string? PermanentResidenceExtention9 { get; set; }

                /// <summary>
                /// Số điện thoại
                /// </summary>
                /// <example>08767347277</example>
                public string? PhoneNumber { get; set; }

                /// <summary>
                /// Số chứng minh nhân dân
                /// </summary>
                /// <example>240616794</example>
                public string? IDCard { get; set; }

                /// <summary>
                /// Giấy phép lái xe
                /// </summary>
                /// <example>12931-51D</example>
                public string? DriverLicense { get; set; }

                /// <summary>
                /// Ngày hết hạn giấy phép lái xe
                /// </summary>
                /// <example>2024-09-15</example>
                public string? ExpiryDate { get; set; }

                /// <summary>
                /// Loại hàng chạy được, 0: Hàng rời, 1: Hàng cont, %: Cả hai
                /// </summary>
                /// <example>%</example>
                public string? OrderTypeID { get; set; }

                /// <summary>
                /// Danh sách các mặt hàng chạy được. Cấu trúc gửi xuống : GoodTypeID:IsSelectd,GoodTypeID:IsSelectd,
                /// </summary>
                /// <example>12:0,13:1</example>
                public string? GoodType { get; set; }

                /// <summary>
                /// Ngày vào làm
                /// </summary>
                /// <example>2021-02-14</example>
                public string? StartDate { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 1
                /// </summary>
                /// <example>131 Banh Van Tran, Ward 7, Tan Binh, Ho Chi Minh City</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 2
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 3
                /// </summary>
                /// <example>1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 4
                /// </summary>
                /// <example>1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 5
                /// </summary>
                /// <example>1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 6
                /// </summary>
                /// <example>1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 7
                /// </summary>
                /// <example>1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Hộ khẩu thường trú 8
                /// </summary>
                /// <example>1</example>
                public string? Extention8 { get; set; }


                ///// <summary>
                ///// Ngày nghỉ việc ko nhập, BB bỏ
                ///// </summary>
                ///// <example>2022-02-22</example>
                //public string? EndDate { get; set; }
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
        }
    }
}