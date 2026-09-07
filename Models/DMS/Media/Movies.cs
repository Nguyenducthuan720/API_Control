namespace APISmartCity.Models.Ver2.Categorys
{
    public static class Movies
    {
        public class Requets
        {
            public class Content
            {

                /// <summary>
                /// LemonId
                /// </summary>
                /// <example>LemonId</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Title
                /// </summary>
                /// <example>Title</example>
                public string? Title { get; set; }

                /// <summary>
                /// ODate
                /// </summary>
                /// <example>ODate</example>
                public string? ODate { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention1 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention2 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention3 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention4 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention5 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention6 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention7 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention8 { get; set; }

                /// <summary>
                /// TitleExtention1
                /// </summary>
                /// <example>TitleExtention1</example>
                public string? TitleExtention9 { get; set; }

                /// <summary>
                /// Avatar
                /// </summary>
                /// <example>Avatar</example>
                public string? Avatar { get; set; }

                /// <summary>
                /// YearRelese
                /// </summary>
                /// <example>2024</example>
                public int? YearRelese { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? Description { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention1 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention2 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention3 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention4 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention5 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention6 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention7 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention8 { get; set; }

                /// <summary>
                /// Description
                /// </summary>
                /// <example></example>
                public string? DescriptionExtention9 { get; set; }

                /// <summary>
                /// NationID
                /// </summary>
                /// <example>1</example>
                public int? NationID { get; set; }

                /// <summary>
                /// TypeID
                /// </summary>
                /// <example>1</example>
                public int? TypeID { get; set; }

                /// <summary>
                /// ChannelID
                /// </summary>
                /// <example>1</example>
                public int? ChannelID { get; set; }

                /// <summary>
                /// MovieGenreID
                /// </summary>
                /// <example>1</example>
                public int? MovieGenreID { get; set; }

                /// <summary>
                /// Episodes
                /// </summary>
                /// <example>1</example>
                public int? Episodes { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Extention1</example>
                public string? Extention9 { get; set; }
                /// Extention10
                /// </summary>
                /// <example>Extention10</example>
                public string? Extention10 { get; set; }
            }

            public class GetByID
            {
                public int? ID { get; set; }
            }

            public class IOTSync
            {
                public string? IOTJson { get; set; }
            }

            public class GetByType
            {
                public string? CategoryType { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// CategoryType
                /// </summary>
                /// <example></example>
                public string? CategoryType { get; set; }

                public List<MovieFiles.Requets.Content> ListMovieFile { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public int? ID { get; set; }

                public List<MovieFiles.Requets.Content> ListMovieFile { get; set; }
            }

            public class GetDetail
            {
                public string? CategoryType { get; set; }
                public int? ID { get; set; }
            }

            public class GetRecently
            {
                public string? CategoryType { get; set; }
                public int? ChannelID { get; set; }
                public int? Top { get; set; }
                public int? MovieGenreID { get; set; }
                public int? NationID { get; set; }
            }

            public class GetRandomMusic
            {
                public string? CategoryType { get; set; }
                public int? Top { get; set; }
            }
        }
    }
}