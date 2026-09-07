namespace DMS.Models.DMS.PriceCommercials
{
    public class SpecialGroups
    {
        public class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }

            public class AddOrEdit
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>PriceCommercials</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Chức năng
                /// </summary>
                /// <example>GeneralPrice</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Mã CT
                /// </summary>
                public string? OID { get; set; }

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
                /// Ngày CT
                /// </summary>
                /// <example>2025-09-24</example>
                public string? ODate { get; set; }

                /// <summary>
                /// Tên nhóm giá (VI)
                /// </summary>
                public string? Name { get; set; }

                /// <summary>
                /// Tên nhóm giá (EN)
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
                /// Ngành hàng
                /// </summary>
                public int? GoodsTypeID { get; set; }

                /// <summary>
                /// Số nhóm giá
                /// </summary>
                public int? GroupCount { get; set; }

                /// <summary>
                /// Thuộc tính
                /// </summary>
                /// <example></example>
                public string? Parameters { get; set; }

                /// <summary>
                /// Chi tiết nhóm giá
                /// </summary>
                /// <example></example>
                public string? Content { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                public List<SpecialGroupDetail> Details { get; set; }

                /// <summary>
                /// ID công ty
                /// </summary>
                /// <example>0</example>
                public string? CmpnID { get; set; }
            }

            public class SpecialGroupDetail
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>0</example>
                public int? ID { get; set; }

                /// <summary>date
                /// Nhóm 
                /// </summary>
                /// <example>1</example>
                public int? Sort { get; set; }

                /// <summary>
                /// Thuộc tính 1
                /// </summary>
                public int? Category1ID { get; set; }

                /// <summary>
                /// Thuộc tính 2
                /// </summary>
                public int? Category2ID { get; set; }

                /// <summary>
                /// Thuộc tính 3
                /// </summary>
                public int? Category3ID { get; set; }

                /// <summary>
                /// Thuộc tính 4
                /// </summary>
                public int? Category4ID { get; set; }

                /// <summary>
                /// Thuộc tính 5
                /// </summary>
                public int? Category5ID { get; set; }

                /// <summary>
                /// Thuộc tính 6
                /// </summary>
                public int? Category6ID { get; set; }

                /// <summary>
                /// Thuộc tính 7
                /// </summary>
                public int? Category7ID { get; set; }

                /// <summary>
                /// Thuộc tính 8
                /// </summary>
                public int? Category8ID { get; set; }

                /// <summary>
                /// Thuộc tính 9
                /// </summary>
                public int? Category9ID { get; set; }

                /// <summary>
                /// Thuộc tính 10
                /// </summary>
                public int? Category10ID { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }
            }

            public class Del : GetByID
            {
            }

            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }

            public class GetActive
            {
                /// <summary>
                /// Ngành hàng
                /// </summary>
                /// <example></example>
                public int? GoodsTypeID { get; set; }
            }
        }
    }
}
