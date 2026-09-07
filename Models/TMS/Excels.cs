namespace APISmartCity.Models
{
    public static class Excels
    {
        public static class Request
        {
            public class Import
            {
                /// <summary>
                /// Import type
                /// </summary>
                /// <example>FACE</example>
                public string Type { get; set; }

                /// <summary>
                /// File Excel
                /// </summary>
                public IFormFile File { get; set; }
            }

            public class ImportExcel
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>MCT123</example>
                public string OID { get; set; }

                /// <summary>
                /// Import Factor
                /// </summary>
                /// <example>Category</example>
                public string FactorID { get; set; }

                /// <summary>
                /// Import Entry
                /// </summary>
                /// <example>Banks</example>
                public string EntryID { get; set; }

                /// <summary>
                /// File Excel
                /// </summary>
                public IFormFile File { get; set; }
            }

            public class Export
            {
                /// <summary>
                /// 'GET-TOTAL','GET-DETAILS'
                /// </summary>
                /// <example>GET-TOTAL</example>
                public string ExportType { get; set; }

                /// <summary>
                /// 'GET-TOTAL','GET-DETAILS'
                /// </summary>
                /// <example>1|2|3|4|5|6|1007|</example>
                public string StoreID { get; set; }

                /// <summary>
                /// Lấy tất cả
                /// </summary>
                /// <example>1</example>
                public string IsAll { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2021/08/22</example>
                public string FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2021/09/11</example>
                public string ToDate { get; set; }

                /// <summary>
                /// Nhân viên
                /// </summary>
                /// <example>1</example>
                public string ListUser { get; set; }

                /// <summary>
                /// Mở rộng 1
                /// </summary>
                /// <example></example>
                public string Para1 { get; set; }

                /// <summary>
                /// Mở rộng 2
                /// </summary>
                /// <example></example>
                public string Para2 { get; set; }

                /// <summary>
                /// Mở rộng 3
                /// </summary>
                /// <example></example>
                public string Para3 { get; set; }

                /// <summary>
                /// Mở rộng 4
                /// </summary>
                /// <example></example>
                public string Para4 { get; set; }

                /// <summary>
                /// Mở rộng 5
                /// </summary>
                /// <example></example>
                public string Para5 { get; set; }
            }

            public class Del : Get_ByID
            {
            }

            public class Get_ByID
            {
                public int DataID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2021/08/22</example>
                public string FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2021/09/11</example>
                public string ToDate { get; set; }
            }
        }

        public class Response
        {
        }
    }
}