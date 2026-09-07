namespace APISmartCity.Models.Ver2.Trainings;

public static class Trainings
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// OID
            /// </summary>
            /// <example>0</example>
            public string? OID { get; set; }

            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>1</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>1</example>
            public string? EntryID { get; set; }

            /// <summary>
            /// Content
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// ContentExtention1
            /// </summary>
            /// <example></example>
            public string? ContentExtention1 { get; set; }

            /// <summary>
            /// ContentExtention2
            /// </summary>
            /// <example></example>
            public string? ContentExtention2 { get; set; }

            /// <summary>
            /// ContentExtention3
            /// </summary>
            /// <example></example>
            public string? ContentExtention3 { get; set; }

            /// <summary>
            /// ContentExtention4
            /// </summary>
            /// <example></example>
            public string? ContentExtention4 { get; set; }

            /// <summary>
            /// ContentExtention5
            /// </summary>
            /// <example></example>
            public string? ContentExtention5 { get; set; }

            /// <summary>
            /// ContentExtention6
            /// </summary>
            /// <example></example>
            public string? ContentExtention6 { get; set; }

            /// <summary>
            /// ContentExtention7
            /// </summary>
            /// <example></example>
            public string? ContentExtention7 { get; set; }

            /// <summary>
            /// ContentExtention8
            /// </summary>
            /// <example></example>
            public string? ContentExtention8 { get; set; }

            /// <summary>
            /// ContentExtention9
            /// </summary>
            /// <example></example>
            public string? ContentExtention9 { get; set; }

            /// <summary>
            /// TrainingTypeID
            /// </summary>
            /// <example>TrainingTypeID</example>
            public int? TrainingTypeID { get; set; }

            /// <summary>
            /// TrainingLocation
            /// </summary>
            /// <example>TrainingLocation</example>
            public string? TrainingLocation { get; set; }

            /// <summary>
            /// RequiredNumberSessions
            /// </summary>
            /// <example>RequiredNumberSessions</example>
            public int? RequiredNumberSessions { get; set; }

            /// <summary>
            /// AttendanceScope
            /// </summary>
            /// <example>AttendanceScope</example>
            public decimal AttendanceScope { get; set; }

            /// <summary>
            /// Lat
            /// </summary>
            /// <example>Lat</example>
            public decimal Lat { get; set; }

            /// <summary>
            /// Long
            /// </summary>
            /// <example>Long</example>
            public decimal Long { get; set; }

            /// <summary>
            /// Note
            /// </summary>
            /// <example>Note</example>
            public string? Note { get; set; }

            /// <summary>
            /// Link
            /// </summary>
            /// <example>Link</example>
            public string? Link { get; set; }

            /// <summary>
            /// Active
            /// </summary>
            /// <example>1</example>
            public int? IsActive { get; set; }
        }

        public class AddTraining : Add
        {
            /// <summary>
            /// TrainingCode
            /// </summary>
            /// <example></example>
            public string? TrainingCode { get; set; }

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
            /// Name
            /// </summary>
            /// <example></example>
            public string? Name { get; set; }

            /// <summary>
            /// NameExtention1
            /// </summary>
            /// <example></example>
            public string? NameExtention1 { get; set; }

            /// <summary>
            /// NameExtention2
            /// </summary>
            /// <example></example>
            public string? NameExtention2 { get; set; }

            /// <summary>
            /// NameExtention3
            /// </summary>
            /// <example></example>
            public string? NameExtention3 { get; set; }

            /// <summary>
            /// NameExtention4
            /// </summary>
            /// <example></example>
            public string? NameExtention4 { get; set; }

            /// <summary>
            /// NameExtention5
            /// </summary>
            /// <example></example>
            public string? NameExtention5 { get; set; }

            /// <summary>
            /// NameExtention6
            /// </summary>
            /// <example></example>
            public string? NameExtention6 { get; set; }

            /// <summary>
            /// NameExtention7
            /// </summary>
            /// <example></example>
            public string? NameExtention7 { get; set; }

            /// <summary>
            /// NameExtention8
            /// </summary>
            /// <example></example>
            public string? NameExtention8 { get; set; }

            /// <summary>
            /// NameExtention9
            /// </summary>
            /// <example></example>
            public string? NameExtention9 { get; set; }

            /// <summary>
            /// Subjects
            /// </summary>
            /// <example></example>
            public string? Subjects { get; set; }

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
            /// TimeLimit
            /// </summary>
            /// <example>0</example>
            public int? TimeLimit { get; set; }

            /// <summary>
            /// RequiredScore
            /// </summary>
            /// <example>1</example>
            public decimal RequiredScore { get; set; }

            /// <summary>
            /// ID câu hỏi liên kết
            /// </summary>
            /// <example>0</example>
            public string? QuestionID { get; set; }
            public List<AddContent> ContentDetails { get; set; }
        }

        public class AddContent
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// OID
            /// </summary>
            /// <example></example>
            public string? OID { get; set; }

            /// <summary>
            /// Title
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// TitleExtention1
            /// </summary>
            /// <example></example>
            public string? ContentExtention1 { get; set; }

            /// <summary>
            /// ContentExtention2
            /// </summary>
            /// <example></example>
            public string? ContentExtention2 { get; set; }

            /// <summary>
            /// ContentExtention3
            /// </summary>
            /// <example></example>
            public string? ContentExtention3 { get; set; }

            /// <summary>
            /// ContentExtention4
            /// </summary>
            /// <example></example>
            public string? ContentExtention4 { get; set; }

            /// <summary>
            /// ContentExtention5
            /// </summary>
            /// <example></example>
            public string? ContentExtention5 { get; set; }

            /// <summary>
            /// ContentExtention6
            /// </summary>
            /// <example></example>
            public string? ContentExtention6 { get; set; }

            /// <summary>
            /// ContentExtention7
            /// </summary>
            /// <example></example>
            public string? ContentExtention7 { get; set; }

            /// <summary>
            /// ContentExtention8
            /// </summary>
            /// <example></example>
            public string? ContentExtention8 { get; set; }

            /// <summary>
            /// ContentExtention9
            /// </summary>
            /// <example></example>
            public string? ContentExtention9 { get; set; }

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
            /// Link
            /// </summary>
            /// <example></example>
            public string? Link { get; set; }

            /// <summary>
            /// Note
            /// </summary>
            /// <example></example>
            public string? Note { get; set; }
            /// <summary>
            /// StartDate
            /// </summary>
            /// <example></example>
            public DateTime StartDate { get; set; }
            /// <summary>
            /// EndDate
            /// </summary>
            /// <example></example>
            public DateTime EndDate { get; set; }
           

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
            /// <summary>
            /// IsTesting
            /// </summary>
            /// <example>0</example>
            public int? IsTesting { get; set; }
        }

        public class SaveAnswer : GetByOID
        {
            /// <summary>
            /// QuestionID
            /// </summary>
            /// <example>0</example>
            public int? QuestionID { get; set; }

            /// <summary>
            /// Answers
            /// </summary>
            /// <example></example>
            public string? Answers { get; set; }

            /// <summary>
            /// Note
            /// </summary>
            /// <example></example>
            public string? Note { get; set; }
        }

        public class SubmitAnswers : GetByOID
        {
        }



        public class SaveChoices : GetByOID
        {
            /// <summary>
            /// Câu hỏi
            /// </summary>
            /// <example>0</example>
            public int? QuestionID { get; set; }

            /// <summary>
            /// Tài khoản
            /// </summary>
            /// <example></example>
            public int? UserID { get; set; }

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
        public class CheckIn : GetByOID
        {
            public decimal CheckInLat { get; set; }
            public decimal CheckInLong { get; set; }
            public string? CheckInNote { get; set; }
            public string? CheckInLink { get; set; }
        }

        public class CheckOut : GetByOID
        {
            public decimal CheckOutLat { get; set; }
            public decimal CheckOutLong { get; set; }
            public string? CheckOutNote { get; set; }
            public string? CheckOutLink { get; set; }
        }
    }
}