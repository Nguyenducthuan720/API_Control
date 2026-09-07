namespace APISmartCity.Models.Ver2.Configs
{
    public class CustomizeTablesVer2
    {
        public class Request
        {
            public class Content
            {
                /// <summary>
                /// TableCode
                /// </summary>
                /// <example></example>
                public string? TableCode { get; set; }

                /// <summary>
                /// TableName
                /// </summary>
                /// <example></example>
                public string? TableName { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example></example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }
            }

            public class AddOrEdit : Content
            {
            }

            public class CopyTable
            {
                public string? TableCodeCopy { get; set;}

                public string? TableCodePaste { get; set; }
            }


            public class Delete
            {
                /// <summary>
                /// TableCode
                /// </summary>
                /// <example></example>
                public string? TableCode { get; set; }
            }

            public class GetByTableCode
            {
                /// <summary>
                /// TableCode
                /// </summary>
                /// <example></example>
                public string? TableCode { get; set; }
            }

            public class GetByEntryID
            {
                /// <summary>
                /// EntryID
                /// </summary>
                /// <example></example>
                public string? EntryID { get; set; }
            }

            public class AddRangeTable
            {
                public List<AddOrEdit> CustomizeTables { get; set; }
            }
        }
    }
}