using APISmartCity.Models.Systems;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.Models.Ver2.Guests
{
    public class RefreshTokenUserGateWay
    {
        public string? UserID { get; set; }
        public string? Refreshtoken { get; set; }
    }
    public class UserGateWayModels
    {
        public class UserRegisterRequest
        {
            [StringLength(12)]
            public string? UserPhone { get; set; } = string.Empty;

            public string? UserPassword { get; set; } = string.Empty;

            public string? UserEmail { get; set; } = string.Empty;

            public string? FullName { get; set; } = string.Empty;
        }
        public class UserLoginRequest
        {
            [DefaultValue("string")]
            public string? UserName { get; set; }
            [DefaultValue("string")]
            public string? UserPassword { get; set; }
        }
        public class UserChangePassRequest
        {
            [Required]
            [DefaultValue("CurrentPassword")]
            public string? CurrentPassword { get; set; }

            [Required]
            [DefaultValue("NewPassword")]
            public string? NewPassword { get; set; }
        }
        public class UserChangeInfo
        {
            [StringLength(12)]
            public string? UserPhone { get; set; }
            public string? UserEmail { get; set; }
            public string? FullName { get; set; }
            public string? Address { get; set; }
            public string? Avatar { get; set; }
            public string? UserDescription { get; set; }
        }
        public class RefreshTokenRequest
        {
            public string? refreshToken { get; set; }
        }
        public class CheckTokenRequest
        {
            public string? Token { get; set; }
        }
    }
}
