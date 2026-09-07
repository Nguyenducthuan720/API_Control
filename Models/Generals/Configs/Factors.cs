namespace APISmartCity.Models.Configs
{
    public class Factors
    {
        public class Request
        {
            public class AddEditFactor
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }

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
                /// SortNumb
                /// </summary>
                /// <example>0</example>
                public int? SortNumb { get; set; }

                /// <summary>
                /// IsNotify
                /// </summary>
                /// <example>0</example>
                public int? IsNotify { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

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
                /// ParentID
                /// </summary>
                /// <example></example>
                public string? ParentID { get; set; }
            }

            public class DeleteFactor
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }
            }

            public class GetByIDFactor
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example></example>
                public string? FactorID { get; set; }
            }

            public class GetByParentID
            {
                /// <summary>
                /// ParentID
                /// </summary>
                /// <example></example>
                public string? ParentID { get; set; }
            }
        }
    }
}