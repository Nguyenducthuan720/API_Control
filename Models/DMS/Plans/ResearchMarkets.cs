using static DMS.Models.Plans.Exhibitions.Request;

namespace DMS.Models.Plans;

public static class ResearchMarkets
{
    public static class Request
    {
        public class Add
        {          
            /// <summary>
            /// Nội dung
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }
            
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Ghi chú</example>
            public string? Note { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            /// <example>1</example>
            public string? Link { get; set; }
        }

        public class AddResearch : Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Plannings</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>ResearchMarkets</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }

            /// <summary>
            /// ODate
            /// </summary>
            /// <example>2024-11-19</example>
            public string? ODate { get; set; }
            
            /// <summary>
            /// SAPID
            /// </summary>
            /// <example></example>
            public string? SAPID { get; set; }

            /// <summary>
            /// LemonID
            /// </summary>
            /// <example></example>
            public string? LemonID { get; set; }

            /// <summary>
            /// Tên chương trình khảo sát (VI)
            /// </summary>
            /// <example></example>
            public string? ResearchName { get; set; }

            /// <summary>
            /// Tên chương trình khảo sát (EN)
            /// </summary>
            /// <example></example>
            public string? ResearchNameExtention1 { get; set; }

            /// <summary>
            /// ID câu hỏi liên kết
            /// </summary>
            /// <example>0</example>
            public string? QuestionID { get; set; }

            /// <summary>
            /// ProvinceID
            /// </summary>
            /// <example></example>
            public int? ProvinceID { get; set; }

            /// <summary>
            /// InvolvedStaff
            /// </summary>
            /// <example></example>
            public string? InvolvedStaff { get; set; }

            /// <summary>
            /// PlanOID
            /// </summary>
            /// <example></example>
            public string? PlanOID { get; set; }

            /// <summary>
            /// FromDate
            /// </summary>
            /// <example></example>
            public string? FromDate { get; set; }

            /// <summary>
            /// ToDate
            /// </summary>
            /// <example></example>
            public string? ToDate { get; set; }

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
            /// Extention11
            /// </summary>
            /// <example></example>
            public string? Extention11 { get; set; }

            /// <summary>
            /// Extention12
            /// </summary>
            /// <example></example>
            public string? Extention12 { get; set; }

            /// <summary>
            /// Extention13
            /// </summary>
            /// <example></example>
            public string? Extention13 { get; set; }

            /// <summary>
            /// Extention14
            /// </summary>
            /// <example></example>
            public string? Extention14 { get; set; }

            /// <summary>
            /// Extention15
            /// </summary>
            /// <example></example>
            public string? Extention15 { get; set; }

            /// <summary>
            /// Extention16
            /// </summary>
            /// <example></example>
            public string? Extention16 { get; set; }

            /// <summary>
            /// Extention17
            /// </summary>
            /// <example></example>
            public string? Extention17 { get; set; }

            /// <summary>
            /// Extention18
            /// </summary>
            /// <example></example>
            public string? Extention18 { get; set; }

            /// <summary>
            /// Extention19
            /// </summary>
            /// <example></example>
            public string? Extention19 { get; set; }

            /// <summary>
            /// Extention20
            /// </summary>
            /// <example></example>
            public string? Extention20 { get; set; }
        }

        public class AddSurvey : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// ID câu hỏi liên kết
            /// </summary>
            /// <example>0</example>
            public int? QuestionID { get; set; }

            /// <summary>
            /// Mô tả
            /// </summary>
            /// <example>0</example>
            public string? Description { get; set; }

            /// <summary>
            /// Loại câu hỏi
            /// </summary>
            /// <example>TN</example>
            public string? QuestionType { get; set; }

            /// <summary>
            /// Bắt buộc
            /// </summary>
            /// <example>0</example>
            public int? IsRequired { get; set; }

            /// <summary>
            /// Hàng/Cột
            /// </summary>
            /// <example>0</example>
            public int? IsRow { get; set; }

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
        }

        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }
        
        public class GetByOID
        {
            public string? OID { get; set; }
        }

        public class Del : GetByOID
        {
        }
        
        public class GetQuestions : GetByOID
        {
            
        }
        public class GetSurveyHistory : GetByOID
        {
            public int? CustomerID { get; set; }
        }

        public class SaveChoices : GetByOID
        {
            /// <summary>
            /// Câu hỏi
            /// </summary>
            /// <example>0</example>
            public int? QuestionID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            /// <example></example>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Lựa chọn
            /// </summary>
            /// <example></example>
            public string? Choices { get; set; }

            /// <summary>
            /// Trả lời văn bản
            /// </summary>
            /// <example></example>
            public string? AnswerContent { get; set; }
        }
    }
}