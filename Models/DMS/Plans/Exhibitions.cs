namespace DMS.Models.Plans;

public static class Exhibitions
{
    public static class Request
    {
        public class Add
        {
            /// <summary>
            /// Ghi chú
            /// </summary>
            /// <example>Ghi chú</example>
            public string? Note { get; set; }
        }

        public class AddExhibition : Add
        {
            /// <summary>
            /// FactorID
            /// </summary>
            /// <example>Exhibitions</example>
            public string? FactorID { get; set; }

            /// <summary>
            /// EntryID
            /// </summary>
            /// <example>DiscountPercent</example>
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
            /// Tên
            /// </summary>
            /// <example></example>
            public string? Name { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention1 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention2 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention3 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention4 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention5 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention6 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention7 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention8 { get; set; }

            /// <summary>
            /// Tên mở rộng
            /// </summary>
            /// <example></example>
            public string? NameExtention9 { get; set; }

            /// <summary>
            /// Mục đích chương trình
            /// </summary>
            /// <example></example>
            public string? Purpose { get; set; }

            /// <summary>
            /// Từ ngày
            /// </summary>
            /// <example></example>
            public string? FromDate { get; set; }

            /// <summary>
            /// Đến ngày
            /// </summary>
            /// <example></example>
            public string? ToDate { get; set; }

            /// <summary>
            /// Ngành hàng
            /// </summary>
            /// <example></example>
            public string? GoodsTypes { get; set; }

            /// <summary>
            /// Phạm vi áp dụng
            /// </summary>
            /// <example></example>
            public string? Regions { get; set; }

            /// <summary>
            /// Diễn giải
            /// </summary>
            /// <example></example>
            public string? Interpretation { get; set; }

            /// <summary>
            /// Cách thức thực hiện
            /// </summary>
            /// <example></example>
            public string? ImplementationMethod { get; set; }

            /// <summary>
            /// Điều kiện khác
            /// </summary>
            /// <example></example>
            public string? OtherCondition { get; set; }

            /// <summary>
            /// Tiêu chí
            /// </summary>
            /// <example></example>
            public string? Criterias { get; set; }

            /// <summary>
            /// Tiêu chí khác
            /// </summary>
            /// <example></example>
            public string? CriteriaContent { get; set; }

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
            /// Tệp đinh kèm
            /// </summary>
            /// <example></example>
            public string? Link { get; set; }

            /// <summary>
            /// Câu hỏi
            /// </summary>
            /// <example></example>
            public string? QuestionID { get; set; }

            /// <summary>
            ///	Tặng phẩm
            /// </summary>
            public List<AddExhibitionItem> Gifts { get; set; }

            /// <summary>
            /// Sản phẩm trưng bày
            /// </summary>
            public List<AddExhibitionItem> Items { get; set; }

            ///// <summary>
            ///// Câu hỏi khảo sát
            ///// </summary>
            //public List<AddExhibitionSurvey> Questions { get; set; }
        }

        public class AddExhibitionItem : Add
        {
            /// <summary>
            /// ID
            /// </summary>
            /// <example>0</example>
            public int? ID { get; set; }

            /// <summary>
            /// ItemID
            /// </summary>
            /// <example>0</example>
            public int? ItemID { get; set; }

            /// <summary>
            /// Quantity
            /// </summary>
            /// <example>0</example>
            public int? Quantity { get; set; }

            /// <summary>
            /// Chiết khấu
            /// </summary>
            /// <example>0</example>
            public int? Discount { get; set; }

            /// <summary>
			/// Tiền/%
			/// </summary>
			/// <example>0</example>
			public int? IsPercent { get; set; }

            /// <summary>
            /// IsGift
            /// </summary>
            /// <example>0</example>
            public int? IsGift { get; set; }

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

        public class AddExhibitionSurvey : Add
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
            /// Nội dung
            /// </summary>
            /// <example>0</example>
            public string? Content { get; set; }

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

            /// <summary>
            /// Link
            /// </summary>
            /// <example></example>
            public string? Link { get; set; }

            /// <summary>
            /// Câu hỏi khảo sát
            /// </summary>
            /// <example></example>
            public List<AddExhibitionSurvey> Options { get; set; }
        }

        public class Submit : GetByOID
        {
            public int? IsLock { get; set; }
        }

        public class GetByOID
        {
            public string? OID { get; set; }
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

        public class Del : GetByOID
        {
        }

        public class Close : GetByOID
        {
        }

        //public class GetQuestions : GetByOID
        //{
        //    public int? CustomerID { get; set; }
        //}
    }
}