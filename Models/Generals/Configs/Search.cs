namespace APISmartCity.Models.Categorys
{
    public class Search
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
                /// Nghiệp vụ
                /// </summary>
                /// <example>Banks</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// List Search
                /// </summary>
                /// <example>Full paremeter</example>
                public List<SearhParameter> ListSearch { get; set; }
            }

            public class SearhParameter
            {
                /// <summary>
                /// Tên cần search
                /// </summary>
                /// <example>Name</example>
                public string? Name { get; set; }

                /// <summary>
                /// Mã lấy từ customize Method
                /// </summary>
                /// <example>Like</example>
                public string? Operator { get; set; }

                /// <summary>
                /// Tham số 1
                /// </summary>
                /// <example>t</example>
                public string? Param1 { get; set; }

                /// <summary>
                /// Tham số 2
                /// </summary>
                /// <example>t</example>
                public string? Param2 { get; set; }
            }
        }

        public class Response
        {
        }
    }
}