namespace APISmartCity.Models.Systems
{
    public static class Default
    {
        public static class Request
        {
            public class FromDateToDate
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/03/10</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/05/10</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// IsFinal
                /// </summary>
                /// <example>0</example>
                public int? IsFinal { get; set; }
            }
            public class FromDateToDateType
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/03/10</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2022/05/10</example>
                public string? ToDate { get; set; }
                public string? ReportType { get; set; }
            }
            public class ID_ByString
            {
                public string? ID { get; set; }
            }

            public class ID_ByString_StationID
            {
                public string? GeoCode { get; set; }

                public string? StationID { get; set; }
            }

            public class ID_ByInt
            {
                public int? ID { get; set; }
            }

            public class UpdatePlanWorking
            {
                public string? OID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? JsonData { get; set; }
                public string? Extention3 { get; set; }

                public string? MaxDate { get; set; }
            }

            public class UpdateFinal
            {
                public string? OID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? NoteFinal { get; set; }

                public string? LinkFinal { get; set; }
            }

            public class ParentID_ByInt
            {
                /// <summary>
                /// Cấp lớn nhất = 0
                /// </summary>
                /// <example>0</example>
                public int? ParentID { get; set; }
            }

            public class ParentID_ByString
            {
                /// <summary>
                /// Cấp lớn nhất = 0
                /// </summary>
                /// <example>0</example>
                public string? ParentID { get; set; }
            }

            public class GroupID_ByString
            {
                public string? GroupID { get; set; }
            }

            public class OID_ByString
            {
                public string? OID { get; set; }
            }
            public class OID_ByStringDetail
            {
                public string? OID { get; set; }
                public int? DetailID { get; set; }

            }

            public class OID_ByInt
            {
                public int? OID { get; set; }
            }

            public class Language
            {
                public string? OID { get; set; }
            }

            public class GroupID_ByInt
            {
                public int? GroupID { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>2</example>
                public int? ID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class EditStatus_StationID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>2</example>
                public int? StationID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class EditStatus_ByString
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>2</example>
                public string? ID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class EditStatus_ByString_StationID
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>2</example>
                public string? StationID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Del_ByString
            {
                /// <summary>
                /// Mã
                /// </summary>
                /// <example>1</example>
                public string? ID { get; set; }
            }

            public class Del_ByString_StationID
            {
                /// <summary>
                /// Mã
                /// </summary>
                /// <example>1</example>
                public string? StationID { get; set; }
            }

            public class Del_ByStationID
            {
                /// <summary>
                /// Mã
                /// </summary>
                /// <example>1</example>
                public int? StationID { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }
            }
            public class GetByGeoCode
            {
                /// <summary>
                /// Geocode
                /// </summary>
                /// <example></example>
                public string? GeoCode { get; set; }
            }

            public class Extention
            {
                public string? Extention1 { get; set; }

                public string? Extention2 { get; set; }

                public string? Extention3 { get; set; }

                public string? Extention4 { get; set; }

                public string? Extention5 { get; set; }

                public string? Extention6 { get; set; }

                public string? Extention7 { get; set; }

                public string? Extention8 { get; set; }

                public string? Extention9 { get; set; }
            }

            public class BodyExtention : Extention
            {
                public string? Body { get; set; }

                public string? BodyExtention1 { get; set; }

                public string? BodyExtention2 { get; set; }

                public string? BodyExtention3 { get; set; }

                public string? BodyExtention4 { get; set; }

                public string? BodyExtention5 { get; set; }

                public string? BodyExtention6 { get; set; }

                public string? BodyExtention7 { get; set; }

                public string? BodyExtention8 { get; set; }

                public string? BodyExtention9 { get; set; }
            }

            public class TitleExtention : BodyExtention
            {
                public string? Title { get; set; }

                public string? TitleExtention1 { get; set; }

                public string? TitleExtention2 { get; set; }

                public string? TitleExtention3 { get; set; }

                public string? TitleExtention4 { get; set; }

                public string? TitleExtention5 { get; set; }

                public string? TitleExtention6 { get; set; }

                public string? TitleExtention7 { get; set; }

                public string? TitleExtention8 { get; set; }

                public string? TitleExtention9 { get; set; }
            }

            public class EventExtention : TitleExtention
            {
            }

            public class NameExtention
            {
                public string? Name { get; set; }

                public string? NameExtention1 { get; set; }

                public string? NameExtention2 { get; set; }

                public string? NameExtention3 { get; set; }

                public string? NameExtention4 { get; set; }

                public string? NameExtention5 { get; set; }

                public string? NameExtention6 { get; set; }

                public string? NameExtention7 { get; set; }

                public string? NameExtention8 { get; set; }

                public string? NameExtention9 { get; set; }
            }

            public class AddressExtention
            {
                public string? Address { get; set; }

                public string? AddressExtention1 { get; set; }

                public string? AddressExtention2 { get; set; }

                public string? AddressExtention3 { get; set; }

                public string? AddressExtention4 { get; set; }

                public string? AddressExtention5 { get; set; }

                public string? AddressExtention6 { get; set; }

                public string? AddressExtention7 { get; set; }

                public string? AddressExtention8 { get; set; }

                public string? AddressExtention9 { get; set; }
            }
        }
    }
}