namespace APISmartCity.Models.Categorys
{
    public static class DataTypes
    {
        public static class Request
        {
            public class Add : CategoryDefault.Request.Add
            {
                /// <summary>
                /// Mã đặc biệt
                /// </summary>
                /// <example>SMARTMONITOR</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// parentID
                /// </summary>
                /// <example></example>
                public int? ParentID { get; set; }

                /// <summary>
                /// Phân quyền
                /// </summary>
                /// <example>1</example>
                public int? IsRight { get; set; }

                public string? IconLink { get; set; }

                public int? IsActive { get; set; }
            }

            public class Edit : CategoryDefault.Request.Edit
            {
                /// <summary>
                /// Mã đặc biệt
                /// </summary>
                /// <example>SMARTMONITOR</example>
                public string? GeoCode { get; set; }

                /// <summary>
                /// parentID
                /// </summary>
                /// <example></example>
                public int? ParentID { get; set; }

                /// <summary>
                /// Phân quyền
                /// </summary>
                /// <example>1</example>
                public int? IsRight { get; set; }

                public string? IconLink { get; set; }

                public int? IsActive { get; set; }
            }

            public class Del : CategoryDefault.Request.Del
            {
            }

            public class EditStatus : CategoryDefault.Request.EditStatus
            {
            }

            public class ByScreen
            {
                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>SMARTMONITOR</example>
                public string? Note { get; set; }
            }
        }

        public class Response
        {
        }
    }
}