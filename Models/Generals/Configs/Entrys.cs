using static APISmartCity.Models.Ver2.Configs.CompanyConfigs.Request;

namespace APISmartCity.Models.Categorys
{
    public class Entrys
    {
        public class Request
        {
            public class GetByFactorID
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>COLLECT</example>
                public string? FactorID { get; set; }
            }

            public class GetByFactorEntry
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>COLLECT</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }
            }

            public class AddEditEntry
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }

                /// <summary>
                /// SAPID
                /// </summary>
                /// <example></example>
                public string? SAPID { get; set; }

                /// <summary>
                /// FindType
                /// </summary>
                /// <example></example>
                public string? FindType { get; set; }

                ///// <summary>
                ///// ImportTemplate
                ///// </summary>
                ///// <example></example>
                //public string? ImportTemplate { get; set; }

                ///// <summary>
                ///// ExportTemplate
                ///// </summary>
                ///// <example></example>
                //public string? ExportTemplate { get; set; }

                /// <summary>
                /// SortNumb
                /// </summary>
                /// <example></example>
                public int? SortNumb { get; set; }

                /// <summary>
                /// EntryName
                /// </summary>
                /// <example></example>
                public string? EntryName { get; set; }

                /// <summary>
                /// EntryNameExtention1
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention1 { get; set; }

                /// <summary>
                /// EntryNameExtention2
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention2 { get; set; }

                /// <summary>
                /// EntryNameExtention3
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention3 { get; set; }

                /// <summary>
                /// EntryNameExtention4
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention4 { get; set; }

                /// <summary>
                /// EntryNameExtention5
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention5 { get; set; }

                /// <summary>
                /// EntryNameExtention6
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention6 { get; set; }

                /// <summary>
                /// EntryNameExtention7
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention7 { get; set; }

                /// <summary>
                /// EntryNameExtention8
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention8 { get; set; }

                /// <summary>
                /// EntryNameExtention9
                /// </summary>
                /// <example></example>
                public string? EntryNameExtention9 { get; set; }

                /// <summary>
                /// Formula
                /// </summary>
                /// <example></example>
                public string? Formula { get; set; }

                /// <summary>
                /// Number
                /// </summary>
                /// <example></example>
                public int? Number { get; set; }

                /// <summary>
                /// ApprovalProcess
                /// </summary>
                /// <example></example>
                public string? ApprovalProcess { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Extention10
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// IsNotify
                /// </summary>
                /// <example>0</example>
                public int? IsNotify { get; set; }

                /// <summary>
                /// DocumentLink
                /// </summary>
                /// <example></example>
                public string? DocumentLink { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// ImportTemplate
                /// </summary>
                /// <example></example>
                public List<ImportTemplates> ImportTemplates { get; set; }

                /// <summary>
                /// ExportTemplate
                /// </summary>
                /// <example></example>
                public List<ExportTemplates> ExportTemplates { get; set; }

                /// <summary>
                /// PrintTemplates
                /// </summary>
                /// <example></example>
                public List<PrintTemplates> PrintTemplates { get; set; }
            }

            public class Edit : AddEditEntry
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? NewEntryID { get; set; }
            }

            public class DeleteEntry
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }
            }

            public class UploadDocument
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Name.Extension
                /// </summary>
                /// <example>abc.pdf</example>
                public List<IFormFile> File { get; set; }
            }

            public class ImportTemplates
            {
                public int? ID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? PrintType { get; set; }
                public string? PrintTemplate { get; set; }
                public string? PrintAction { get; set; }
                public string? FormPrintName { get; set; }
                public string? Note { get; set; }
                public int? IsApproval { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
                public string? PrinterExtention2 { get; set; }

            }

            public class ExportTemplates
            {
                public int? ID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? PrintType { get; set; }
                public string? PrintTemplate { get; set; }
                public string? PrintAction { get; set; }
                public string? FormPrintName { get; set; }
                public string? Note { get; set; }
                public int? IsApproval { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
                public string? PrinterExtention2 { get; set; }
            }

            public class PrintTemplates
            {
                public int? ID { get; set; }
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public string? PrintType { get; set; }
                public string? PrintTemplate { get; set; }
                public string? PrintAction { get; set; }
                public string? FormPrintName { get; set; }
                public string? Note { get; set; }
                public int? IsApproval { get; set; }
                public string? CreateUser { get; set; }
                public string? CmpnID { get; set; }
            }

        }

        public class Response
        {
        }
    }
}