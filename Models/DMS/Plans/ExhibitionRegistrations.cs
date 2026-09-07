namespace DMS.Models.Plans;

public static class ExhibitionRegistrations
{
    public static class Request
	{
		public class Add
		{
			/// <summary>
			/// FactorID
			/// </summary>
			/// <example>Exhibitions</example>
			public string? FactorID { get; set; }

			/// <summary>
			/// EntryID
			/// </summary>
			/// <example>ExhibitionRegistrations</example>
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
			/// ID chương trình trưng bày
			/// </summary>
			/// <example></example>
			public string? ReferenceID { get; set; }

            /// <summary>
            /// ID khách hàng
            /// </summary>
            /// <example></example>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Số lần cập nhật
            /// </summary>
            /// <example></example>
            public int? ImageUpdateCount { get; set; }

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

			/// <summary>
			/// Ghi chú
			/// </summary>
			/// <example>Note</example>
			public string? Note { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            /// <example></example>
            public string? Link { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            public List<AddRegistrationImage> Images { get; set; }

			/// <summary>
			/// Trả lời khảo sát
			/// </summary>
			public List<SaveChoices> Choices { get; set; }
        }

		public class AddRegistrationImage
		{
			/// <summary>
			/// ID
			/// </summary>
			public int? ID { get; set; }

            /// <summary>
            /// Tệp đính kèm
            /// </summary>
            public string? Link { get; set; }
        }

        public class EditImages : GetByOID
        {
            public List<AddRegistrationImage> Images { get; set; }
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

        public class SaveChoices
        {
            /// <summary>
            /// ID phản hồi của khách hàng
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// Câu hỏi
            /// </summary>
            /// <example>0</example>
            public int? QuestionID { get; set; }

            /// <summary>
            /// Lựa chọn
            /// </summary>
            /// <example></example>
            public string? Choices { get; set; }

            /// <summary>
            /// Trả lời văn bản
            /// </summary>
            /// <example></example>
            public string? AnswerText { get; set; }
        }
    }
}