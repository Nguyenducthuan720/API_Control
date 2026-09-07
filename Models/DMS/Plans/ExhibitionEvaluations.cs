namespace DMS.Models.Plans;

public static class ExhibitionEvaluations
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
			/// Ghi chú
			/// </summary>
			/// <example>Note</example>
			public string? Note { get; set; }
		}

		public class AddEvaluation : Add
		{
			/// <summary>
			/// FactorID
			/// </summary>
			/// <example>Exhibitions</example>
			public string? FactorID { get; set; }

			/// <summary>
			/// EntryID
			/// </summary>
			/// <example>ExhibitionEvaluations</example>
			public string? EntryID { get; set; }

			/// <summary>
			/// ODate
			/// </summary>
			/// <example>2024-11-19</example>
			public string? ODate { get; set; }

            /// <summary>
            /// ID chương trình trưng bày
            /// </summary>
            /// <example></example>
            public string? ExhibitionID { get; set; }

            /// <summary>
            /// ID đăng ký trưng bày
            /// </summary>
            /// <example></example>
            public string? RegistrationID { get; set; }

            /// <summary>
            /// Đánh giá (AI đánh giá)
            /// </summary>
            /// <example></example>
            public int? IsPass { get; set; }
			
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
            /// Đánh giá
            /// </summary>
            public List<AddEvaluationDetail> Details { get; set; }
		}

		public class AddEvaluationDetail : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

			/// <summary>
			/// Tiêu chí
			/// </summary>
			/// <example>0</example>
			public int? CriteriaID { get; set; }

            /// <summary>
            /// Trọng số
            /// </summary>
            /// <example>0</example>
            public int? Weight { get; set; }

            /// <summary>
            /// AI đánh giá
            /// </summary>
            /// <example>0</example>
            public int? AIEvaluation { get; set; }

            /// <summary>
            /// MKT đánh giá
            /// </summary>
            /// <example>0</example>
            public int? UserEvaluation { get; set; }
		}

		public class Submit : GetByOID
		{
            /// <summary>
            /// Khóa/Mở khóa
            /// </summary>
			/// <example>1</example>
            public int? IsLock { get; set; }

            /// <summary>
            /// Đạt/Không đạt
            /// </summary>
            /// <example>1</example>
            public int? IsPass { get; set; }

            /// <summary>
            /// Nội dung đánh giá
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// Đánh giá
            /// </summary>
            public List<AddEvaluationDetail> Details { get; set; }
        }

		public class GetByOID
		{
			public string? OID { get; set; }
		}
	}
}