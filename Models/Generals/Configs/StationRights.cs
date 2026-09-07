namespace APISmartCity.Models
{
    public static class ConfigStationRights
    {
        public static class Request
        {
            public class Get
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example>0</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Mã code
                /// </summary>
                /// <example>Air</example>
                public string? GeoCode { get; set; }
            }

            public class GetChild
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example>0</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Mã code
                /// </summary>
                /// <example>Warehouse</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Mã của cha
                /// </summary>
                /// <example>3333</example>
                public string? StationID { get; set; }
            }

            public class Edit
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example>0</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Mã code
                /// </summary>
                /// <example>Air</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Danh sách trạm
                /// </summary>
                /// <example>3333,C1111</example>
                public string? ListMenuID { get; set; }
            }

            public class EditRight
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example>0</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Mã code
                /// </summary>
                /// <example>Air</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Object ID Cấp quyền
                /// </summary>
                /// <example>3333</example>
                public string? StationID { get; set; }

                /// <summary>
                /// Cấp quyền gửi 1, không cấp gửi 0
                /// </summary>
                /// <example>1</example>
                public int? IsRight { get; set; }
            }

            public class EditRightByList
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example></example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Mã code
                /// </summary>
                /// <example>Air</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// Object ID Cấp quyền
                /// </summary>
                /// <example>3333,1122,112,123</example>
                public string? ListStationID { get; set; }
            }

            public class AddInfo
            {
                /// <summary>
                /// StationID Tram
                /// </summary>
                /// <example></example>
                public string? StationID { get; set; }

                /// <summary>
                /// AppCode
                /// </summary>
                /// <example>VGAS247</example>
                public string? AppCode { get; set; }
            }
        }

        public class Response
        {
        }
    }
}