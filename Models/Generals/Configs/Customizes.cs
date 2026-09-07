namespace APISmartCity.Models
{
    public class Customizes
    {
        public class Request
        {
            public class Content
            {
                /// <summary>
                /// Colum Name
                /// </summary>
                /// <example>jp</example>
                public string? ClName { get; set; }

                /// <summary>
                /// Show name
                /// </summary>
                /// <example>1</example>
                public string? ShwName { get; set; }

                /// <summary>
                /// Show name Extention1
                /// </summary>
                /// <example>1</example>
                public string? ShwNameExtention1 { get; set; }

                /// <summary>
                /// Show name Extention2
                /// </summary>
                /// <example>2</example>
                public string? ShwNameExtention2 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>3</example>
                public string? ShwNameExtention3 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>4</example>
                public string? ShwNameExtention4 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>5</example>
                public string? ShwNameExtention5 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>6</example>
                public string? ShwNameExtention6 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>7</example>
                public string? ShwNameExtention7 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>8</example>
                public string? ShwNameExtention8 { get; set; }

                /// <summary>
                /// Show name Extention
                /// </summary>
                /// <example>9</example>
                public string? ShwNameExtention9 { get; set; }

                public string? TableName { get; set; }

                /// <summary>
                /// IsHide
                /// </summary>
                /// <example>1</example>
                public int? IsHide { get; set; }
            }

            public class GetCustomizeByColumnName
            {
                public string? ClName { get; set; }
            }

            public class AddEditCustomize : Content
            {
            }

            public class MobileLanguage
            {
                /// <summary>
                /// Cho yến
                /// </summary>
                /// <example>NLTSmarts</example>
                public string? ApplicationName { get; set; }
            }

            public class EditHideCustomize
            {
                /// <summary>
                /// Colum Name
                /// </summary>
                /// <example>jp</example>
                public string? ClName { get; set; }

                /// <summary>
                /// IsHide
                /// </summary>
                /// <example>1</example>
                public int? IsHide { get; set; }
            }

            public class DelCustomize
            {
                /// <summary>
                /// Colum Name
                /// </summary>
                /// <example>jp</example>
                public string? ClName { get; set; }
            }

            public class GetCustomizeByObjectName
            {
                public string? ObjectName { get; set; }
            }
        }

        public class CustomizeReponse
        {
        }
    }
}