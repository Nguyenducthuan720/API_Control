using APISmartCity.Models.Systems;
using System.ComponentModel;

namespace APISmartCity.Models
{
    public class Users
    {
        public class Request
        {
            public class Content
            {
                /// <summary>
                /// Tên User
                /// </summary>
                /// <example>Trương Bình</example>
                public string? UserFullName { get; set; }

                /// <summary>
                /// Địa chỉ User
                /// </summary>
                /// <example>363/2/10 Bình lợi,Bình Thạnh,TP.HCM</example>
                public string? UserAddress { get; set; }

                /// <summary>
                /// Số điện thoại User
                /// </summary>
                /// <example>0858552245</example>
                public string? UserPhone { get; set; }

                /// <summary>
                /// Email User
                /// </summary>
                /// <example>xoke@gmail.com</example>
                public string? UserEmail { get; set; }

                /// <summary>
                /// Tên tài khoản
                /// </summary>
                /// <example>xoke</example>
                public string? UserName { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example>Anh xoke</example>
                public string? UserDescription { get; set; }

                /// <summary>
                /// ID Group
                /// </summary>
                /// <example>1</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Là saler có tính doanh thu
                /// </summary>
                /// <example>1</example>
                public int? IsSale { get; set; }

                /// <summary>
                /// Là khóa
                /// </summary>
                /// <example>1</example>
                public int? IsUnLock { get; set; }

                /// <summary>
                /// Là IT Support
                /// </summary>
                /// <example>1</example>
                public int? IsConfig { get; set; }
                public int? IsInfomationApp { get; set; }

                /// <summary>
                /// Là có quyền giữ hàng
                /// </summary>
                /// <example>1</example>
                public int? IsHold { get; set; }

                /// <summary>
                /// Đăng nhập user domain
                /// </summary>
                /// <example>1</example>
                public int? DomainLogin { get; set; }

                /// <summary>
                /// % xem tồn kho
                /// </summary>
                /// <example>10</example>
                public int? ViewStock { get; set; }
                /// <summary>
                /// ID Vùng
                /// </summary>
                /// <example>51</example>
                public string? Region { get; set; }

                /// <summary>
                /// SalesChannelID
                /// </summary>
                /// <example>51</example>
                public string? SalesChannelID { get; set; }

                /// <summary>
                /// RuleSpecialCode
                /// </summary>
                /// <example>auto</example>
                public string? RuleSpecialCode { get; set; }

                public string? PermanentResidence { get; set; }
                public string? PermanentResidenceExtention1 { get; set; }
                public DateTime? StartDate { get; set; }
                public DateTime? EndDate { get; set; }
                public string? IDCard { get; set; }
                public int? ExpertTypeID { get; set; }

                /// <summary>
                /// Phòng ban
                /// </summary>
                /// <example>Default name</example>
                public int? DepartmentID { get; set; }

                /// <summary>
                /// Phòng ban
                /// </summary>
                /// <example>Default name</example>
                public int? DepartmentDetailID { get; set; }

                /// <summary>
                /// Mẫu chữ ký
                /// </summary>
                /// <example>Mẫu chữ ký</example>
                public string? UserSignatureLink { get; set; }

                /// <summary>
                /// Code chữ ký
                /// </summary>
                /// <example>Code chữ ký</example>
                public string? UserSignatureCode { get; set; }

                /// <summary>
                /// Quyèn sửa chứng từ
                /// </summary>
                /// <example>IsEditDocument</example>
                public int? IsEditDocument { get; set; }

                /// <summary>
                /// RuleSpecialCode
                /// </summary>
                /// <example></example>
                public string? RuleGoodsTypes { get; set; }

                /// <summary>
                /// RuleSpecialCode
                /// </summary>
                /// <example></example>
                public string? ViewInventory { get; set; }

                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Có dùng/ không dùng
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Chức vụ
                /// </summary>
                /// <example>1</example>
                public int? PositionID { get; set; }
                /// <summary>
                /// Tên 1
                /// </summary>
                /// <example>Default name</example>
                public string? Extention1 { get; set; }
                /// <summary>
                /// Tên 2
                /// </summary>
                /// <example>Default name</example>
                public string? Extention2 { get; set; }
                /// <summary>
                /// Tên 3
                /// </summary>
                /// <example>Default name</example>
                public string? Extention3 { get; set; }
                /// <summary>
                /// Tên 4
                /// </summary>
                /// <example>Default name</example>
                public string? Extention4 { get; set; }
                /// <summary>
                /// Tên 5
                /// </summary>
                /// <example>Default name</example>
                public string? Extention5 { get; set; }
                /// <summary>
                /// Tên 6
                /// </summary>
                /// <example>Default name</example>
                public string? Extention6 { get; set; }
                /// <summary>
                /// Tên 7
                /// </summary>
                /// <example>Default name</example>
                public string? Extention7 { get; set; }
                /// <summary>
                /// Tên 8
                /// </summary>
                /// <example>Default name</example>
                public string? Extention8 { get; set; }
                /// <summary>
                /// Tên 9
                /// </summary>
                /// <example>Default name</example>
                public string? Extention9 { get; set; }
                /// <summary>
                /// Tên 10
                /// </summary>
                /// <example>Default name</example>
                public string? Extention10 { get; set; }
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }
                /// <summary>
                /// Tuyến 1
                /// </summary>
                /// <example>Default name</example>
                public string? RouteSales1 { get; set; }
                /// <summary>
                /// Tuyến 2
                /// </summary>
                /// <example></example>
                public string? RouteSales2 { get; set; }
                /// <summary>
                /// Tuyến 3
                /// </summary>
                /// <example></example>
                public string? RouteSales3 { get; set; }
                /// <summary>
                /// Tuyến 4
                /// </summary>
                /// <example></example>
                public string? RouteSales4 { get; set; }
                public string? SAPID { get; set; }
                public string? LemonID { get; set; }
                public string? Code { get; set; }
                /// <summary>
                /// Tuyến
                /// </summary>
                /// <example>Default name</example>
                public string? RouteSales { get; set; }
                /// <summary>
                /// Mật khẩu tài khoản
                /// </summary>
                /// <example>String</example>
                public string? UserPassword { get; set; }
            }

            public class UserLoginRequest
            {
                [DefaultValue("administrator")]
                public string? UserName { get; set; }

                [DefaultValue("123")]
                public string? UserPassword { get; set; }
            }

            public class UserLoginRequestApp
            {
                [DefaultValue("administrator")]
                public string? UserName { get; set; }

                [DefaultValue("123")]
                public string? UserPassword { get; set; }

                [DefaultValue("VGAS247")]
                public string? AppCode { get; set; }
            }

            public class UserLoginCmpnRequest : UserLoginRequest
            {
                [DefaultValue("-1")]
                public string? CmpnID { get; set; }
            }

            public class UserLoginApp : UserLoginRequest
            {
                [DefaultValue("VGAS247")]
                public string? AppCode { get; set; }
            }
            public class UserLoginGateway : UserLoginCmpnRequest
            {
                [DefaultValue("NLT_SYS")]
                public string? AppCode { get; set; }

                [DefaultValue("NLT7004")]
                public string? CollectFromServer { get; set; }
            }

            public class RefreshTokenRequest
            {
                public string? refreshToken { get; set; }
            }

            public class CheckTokenRequest
            {
                public string? Token { get; set; }
            }

            public class AddUser : Content
            {
            }

            public class EditUser : Content
            {
                /// <summary>
                /// UserID
                /// </summary>
                /// <example>2</example>
                public int? ID { get; set; }
            }

            public class EditAvatar
            {
                /// <summary>
                /// UserID
                /// </summary>
                /// <example>2</example>
                public int? ID { get; set; }

                /// <summary>
                /// Avatar
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }
            }

            public class EditStatusUser : Default.Request.EditStatus
            {
            }

            public class DelUser : Default.Request.Del
            {
            }

            public class ResetPasswordUser
            {
                /// <summary>
                /// ID User
                /// </summary>
                /// <example>32</example>
                public int? ID { get; set; }
                /// <summary>
                /// NewPassword
                /// </summary>
                /// <example>String</example>
                public string? NewPassword { get; set; }
                /// <summary>
                /// Lý do đặt lại mât khẩu
                /// </summary>
                /// <example>Lý do</example>
                public string? Extention1 { get; set; }
            }

            public class GetContact
            {
                [DefaultValue("VGAS247")]
                public string? AppCode { get; set; }
            }

            public class GetGroupID
            {
                public string? GroupID { get; set; }
            }

            public class GetGeoCode
            {
                public string? GeoCode { get; set; }
            }

            public class ChangePassword
            {
                public string? AppCode { get; set; }

                /// <summary>
                /// Mật khẩu hiện tại
                /// </summary>
                /// <example>xoke</example>
                public string? UserPassword { get; set; }

                /// <summary>
                /// Mật khẩu mới
                /// </summary>
                /// <example>xoke123</example>
                public string? UserPassNew { get; set; }

                /// <summary>
                /// UserID
                /// </summary>
                /// <example>0</example>
                public int? UserID { get; set; }
            }

            public class ChangeInfo
            {
                /// <summary>
                /// ID User
                /// </summary>
                /// <example>32</example>
                public int? ID { get; set; }

                /// <summary>
                /// Họ và tên
                /// </summary>
                /// <example>Trương Bình</example>
                public string? Name { get; set; }

                /// <summary>
                /// Điện thoại
                /// </summary>
                /// <example>0979821240</example>
                public string? PhoneNumber { get; set; }

                /// <summary>
                /// Email
                /// </summary>
                /// <example>truongbinh.angiang@gmail.com</example>
                public string? Email { get; set; }

                /// <summary>
                /// Ngày sinh
                /// </summary>
                /// <example>08/12/1994</example>
                public string? OrderBirthday { get; set; }

                /// <summary>
                /// Mã Thành Phố
                /// </summary>
                /// <example>1</example>
                public int? City { get; set; }

                /// <summary>
                /// Mã Quận huyện
                /// </summary>
                /// <example>1</example>
                public int? District { get; set; }

                /// <summary>
                /// Mã Phường xã
                /// </summary>
                /// <example>1</example>
                public int? Ward { get; set; }

                /// <summary>
                /// Address
                /// </summary>
                /// <example>1</example>
                public string? Address { get; set; }
            }

            public class SendCodeForgetPassword
            {
                public string? UserEmail { get; set; }
            }

            public class SendCodeForgetPasswordApp
            {
                public string? AppCode { get; set; }
                public string? UserEmail { get; set; }
            }

            public class ChangePasswordBySecurityCode
            {
                public string? AppCode { get; set; }
                public string? UserEmail { get; set; }
                public string? SecurityCode { get; set; }
                public string? UserPassNew { get; set; }
            }

            public class CheckSecurityByEmployerId
            {
                public string? SecurityCode { get; set; }
            }

            public class GetSaler
            {
                public string? StoreID { get; set; }
            }

            public class Logout
            {
                /// <summary>
                /// Jwt token đăng nhập
                /// </summary>
                /// <example>123123123</example>
                public string? JwtToken { get; set; }

                /// <summary>
                /// Refreshtoken
                /// </summary>
                /// <example>123123123</example>
                public string? Refreshtoken { get; set; }

                /// <summary>
                /// Token app firebase
                /// </summary>
                /// <example>123123123</example>
                public string? TokenApps { get; set; }
            }

            public class GroupUserCodes
            {
                /// <summary>
                /// Mã loại người dùng/nhóm người dùng
                /// </summary>
                /// <example>Maintenance</example>
                public string? GroupUserCode { get; set; }
            }

            public class ByName
            {
                /// <summary>
                /// Tên người dùng
                /// </summary>
                /// <example></example>
                public string? UserFullName { get; set; }
            }

            public class ByGroupType
            {
                /// <summary>
                /// Loại nhóm sử dụng
                /// </summary>
                /// <example>UserFunction</example>
                public string? GroupType { get; set; }
            }

            public class ByCmpnID
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>1</example>
                public string? CmpnID { get; set; }
            }
            public class AddOrEditUsers
            {
                public int? UserID { get; set; }
                public int? GroupID { get; set; }
                public string? ListCustomerID { get; set; }
            }
            public class EditGroup
            {
                public int? UserID { get; set; }
                public int? GroupID { get; set; }
            }

            public class GetBYIDDetails
            {
                public int? UserID { get; set; }
            }

            public class SwitchCompanyUserCmpnID
            {
                public string? CmpnID { get; set; }
            }


        }

        public class Response
        {
        }
    }
}