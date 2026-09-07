namespace APISmartCity.Models.Ver2.Configs
{
    public class CustomizeTypesVer2
    {
        public class Request
        {
            public class Content
            {
                /// <summary>
                /// CustomizeCode
                /// </summary>
                /// <example>1</example>
                public string? CustomizeCode { get; set; }

                /// <summary>
                /// CustomizeName
                /// </summary>
                /// <example>1</example>
                public string? CustomizeName { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example>1</example>
                public string? Note { get; set; }
            }

            public class AddOrEditCustomizeType : Content
            {
            }

            public class DeleteType
            {
                /// <summary>
                /// CustomizeCode
                /// </summary>
                /// <example>1</example>
                public string? CustomizeCode { get; set; }
            }

            public class AddRangeType
            {
                public List<AddOrEditCustomizeType> CustomizeTypes { get; set; }
            }
        }
    }
}