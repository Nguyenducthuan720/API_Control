namespace DMS.Models.DMS.HandOverDocuments;

public static class HandOverDocument
{
	public static class Request
	{
		public class Add
		{
			/// <summary>
			/// Mã CT
			/// </summary>
			/// <example>0</example>
			public string? OID { get; set; }

			/// <summary>
			/// Ghi chú
			/// </summary>
			/// <example></example>
			public string? Note { get; set; }

			/// <summary>
			/// Tệp đính kèm
			/// </summary>
			/// <example></example>
			public string? Link { get; set; }
		}

		public class AddHandOverDocument : Add
		{
            /// <summary>
            /// Nghiệp vụ
            /// </summary>
            /// <example>HandOverDocuments</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// Chức năng
            /// </summary>
            /// <example>HandoverDirect</example>
            public string? EntryID { get; set; }

			/// <summary>
			/// Ngày CT
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
			/// Người giao
			/// </summary>
			/// <example></example>
			public int? DelivererID { get; set; }

            /// <summary>
            /// Phòng ban
            /// </summary>
            /// <example></example>
            public int? DepartmentID { get; set; }

            /// <summary>
            /// Người nhận
            /// </summary>
            /// <example></example>
            public int? RecipientID { get; set; }

            /// <summary>
            /// Nội dung bàn giao
            /// </summary>
            /// <example></example>
            public string? Content { get; set; }

            /// <summary>
            /// Số lượng chứng từ
            /// </summary>
            /// <example></example>
            public int? DocumentsCount { get; set; }

			/// <summary>
			/// Details
			/// </summary>
			public List<AddDetail> Details { get; set; }
		}

		public class AddDetail : Add
		{
			/// <summary>
			/// ID
			/// </summary>
			/// <example>0</example>
			public int? ID { get; set; }

            /// <summary>
            /// Khách hàng
            /// </summary>
            /// <example></example>
            public int? CustomerID { get; set; }

            /// <summary>
            /// Loại chứng từ
            /// </summary>
            /// <example></example>
            public int? DocumentTypeID { get; set; }

            /// <summary>
            /// Số chứng từ
            /// </summary>
            /// <example></example>
            public string? ReferenceID { get; set; }

            /// <summary>
            /// Số bản chính
            /// </summary>
            /// <example></example>
            public int? NumberOfOriginals { get; set; }

            /// <summary>
            /// Số bản sao y
            /// </summary>
            /// <example></example>
            public int? NumberOfCopies { get; set; }
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
	}
}