namespace APISmartCity.Models.Categorys
{
    public class FormPrints
    {
        public class Request
        {
            public class Get
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>Category</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>Banks</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Loại in
                /// </summary>
                /// <example>PDF</example>
                public string? PrintType { get; set; }
            }

            public class Print : Get
            {
                /// <summary>
                /// Mã nghiệp vụ
                /// </summary>
                /// <example>CPVC/17/01/23/002</example>
                public string? OID { get; set; }
            }

            public class Add : Get
            {


                /// <summary>
                /// Mẫu in
                /// </summary>
                /// <example>Template1</example>
                public string? PrintTemplate { get; set; }

                /// <summary>
                /// Hành động in
                /// </summary>
                /// <example>ExportFilePDF</example>
                public string? PrintAction { get; set; }

                /// <summary>
                /// Tên biểu mẫu
                /// </summary>
                /// <example>Test</example>
                public string? Name { get; set; } = "Test";

                /// <summary>
                /// Tên mở rộng 1
                /// </summary>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// Tên mở rộng 2
                /// </summary>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// Tên mở rộng 3
                /// </summary>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// Tên mở rộng 4
                /// </summary>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// Tên mở rộng 5
                /// </summary>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// Tên mở rộng 6
                /// </summary>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// Tên mở rộng 7
                /// </summary>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// Tên mở rộng 8
                /// </summary>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// Tên mở rộng 9
                /// </summary>
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>test lần 2</example>
                public string? Note { get; set; }

                /// <summary>
                /// Trạng thái phê duyệt
                /// </summary>
                /// <example>false</example>
                public bool IsApproval { get; set; } = false;
            }

            public class Delete
            {
                /// <summary>
                /// ID của bản ghi cần xóa
                /// </summary>
                /// <example>2</example>
                public int? ID { get; set; }
            }
        }
        public class Response
        {
        }
    }
}