using APISmartCity.Models.Systems;

namespace APISmartCity.Models
{
    public class GroupUsers
    {
        public class Request
        {
            public class StationRights
            {
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
            }

            public class Content
            {
                /// <summary>
                /// Code Group
                /// </summary>
                /// <example></example>
                public string? GroupCode { get; set; }

                /// <summary>
                /// Tên nhóm
                /// </summary>
                /// <example>admin test</example>
                public string? GroupName { get; set; }

                /// <summary>
                /// Ghi chú nhóm
                /// </summary>
                /// <example>note</example>
                public string? GroupDescription { get; set; }

                /// <summary>
                /// phân loại truy cập
                /// </summary>
                /// <example></example>
                public string? GroupType { get; set; }

                /// <summary>
                /// CompanyData
                /// </summary>
                /// <example></example>
                public string? CompanyData { get; set; }

                /// <summary>
                /// SaleOrgData
                /// </summary>
                /// <example></example>
                public string? SaleOrgData { get; set; }


                /// <summary>
                /// SaleRouteData
                /// </summary>
                /// <example></example>
                public string? SaleRouteData { get; set; }

                /// <summary>
                /// SaleChanelData
                /// </summary>
                /// <example></example>
                public string? SaleChanelData { get; set; }

                /// <summary>
                /// DivisonData
                /// </summary>
                /// <example></example>
                public string? DivisonData { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention13 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention14 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention15 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention16 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention17 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention18 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention19 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention20 { get; set; }
            }

            public class Add : Content
            {
                // đa thừa kế
            }

            public class Edit : Content
            {
                /// <summary>
                /// ID nhóm
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }
            }

            public class EditVer2 : Edit
            {
                /// <summary>
                /// List menuright ID
                /// </summary>
                /// <example>100:1;500:1;6:1;7:1;2:1;3:1;45:1;4:1;</example>
                public string? ListMenuID { get; set; }

                /// <summary>
                /// Danh sách StationRight
                /// </summary>
                public List<StationRights> ListStationRight { get; set; }
            }

            public class EditStatus : Default.Request.EditStatus
            {
            }

            public class Del : Default.Request.Del
            {
            }
        }

        public class Response
        {
        }
    }
}