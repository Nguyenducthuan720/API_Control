namespace APISmartCity.Models.Categorys
{
    public class ExportPDF
    {
        public class Request
        {
            public class Get
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>Contracts</example>
                public string FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>PrincipleContract</example>
                public string EntryID { get; set; }

                //public string Step { get; set; }
                /// <summary>
                /// OID
                /// </summary>
                /// <example>HDNT/1000/25/08/0015</example>
                public string OID { get; set; }

                public string TempID { get; set; }
                public string Extention1 { get; set; }
                /// <summary>
                /// Với output HTML: danh sách output bổ sung, phân cách bằng dấu phẩy.
                /// Hỗ trợ PDF, XLSX, DOCX hoặc ALL. HTML luôn được tạo.
                /// </summary>
                public string Extention2 { get; set; }
                public string Extention3 { get; set; }
                public string Extention4 { get; set; }
                public string Extention5 { get; set; }



                public string Json { get; set; }

            }
            public class GetByID : Get
            {

            }
        }
    }
}
