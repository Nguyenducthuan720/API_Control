namespace APISmartCity.Models.Categorys
{
    public static class ExcelTemplates
    {
        public static class Request
        {
            public class Add : CategoryDefault.Request.Add
            {
                /// <summary>
                /// file
                /// </summary>
                public IFormFile file { get; set; }
            }

            public class Edit : CategoryDefault.Request.Edit
            {
                /// <summary>
                /// file
                /// </summary>
                public IFormFile file { get; set; }

                /// <summary>
                /// ExcelType
                /// </summary>
                /// <example>Import</example>
                public string? ExcelType { get; set; }
            }

            public class Del : CategoryDefault.Request.Del
            {
            }

            public class EditStatus : CategoryDefault.Request.EditStatus
            {
            }
        }

        public class Response
        {
        }
    }
}