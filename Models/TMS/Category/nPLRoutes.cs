using APISmartCity.Models.Categorys;

namespace DMS.Models.TMS.Category
{
    public static class NPLRoutes
    {
        public static class Request
        {
            public class Content : CategoryDefault.Request.Content
            {
                /// <summary>
                /// Mã Lemon
                /// </summary>
                /// <example>1</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Mã nhóm tuyến
                /// </summary>
                /// <example>1</example>
                public int? RouteGroupID { get; set; }

                /// <summary>
                /// Mã tuyến
                /// </summary>
                /// <example>1</example>
                public string? Code { get; set; }

                /// <summary>
                /// Mã đi tỉnh, thành phố
                /// </summary>
                /// <example>1</example>
                public int? StartCityID { get; set; }

                /// <summary>
                /// Mã đi quận, huyện
                /// </summary>
                /// <example>1</example>
                public int? StartDistrictID { get; set; }

                /// <summary>
                /// Mã đi phường, xã
                /// </summary>
                /// <example>1</example>
                public int? StartWardID { get; set; }

                /// <summary>
                /// Mã đến tỉnh, thành phố
                /// </summary>
                /// <example>1</example>
                public int? EndCityID { get; set; }

                /// <summary>
                /// Mã đến quận, huyện
                /// </summary>
                /// <example>1</example>
                public int? EndDistrictID { get; set; }

                /// <summary>
                /// Mã đến phường, xã
                /// </summary>
                /// <example>1</example>
                public int? EndWardID { get; set; }

                /// <summary>
                /// Chiều dài của tuyến
                /// </summary>
                /// <example>1</example>
                public decimal Distance { get; set; }

                public string Extention1 { get; set; }
                public string Extention2 { get; set; }

                public string Extention3 { get; set; }

                public string Extention4 { get; set; }

                public string Extention5 { get; set; }

                public string Extention6 { get; set; }

                public string Extention7 { get; set; }

                public string Extention8 { get; set; }



            }

            public class GetByID
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }
            }

            public class Add : CategoryDefault.Request.Content
            {
                /// <summary>
                /// Mã Lemon
                /// </summary>
                /// <example>1</example>
                public string? LemonID { get; set; }

                /// <summary>
                /// Mã tuyến
                /// </summary>
                /// <example>SG.Q1.DK-AG.CP.VTT</example>
                public string? Code { get; set; }

                /// <summary>
                /// Mã nhóm tuyến
                /// </summary>
                /// <example>17</example>
                public int? RouteGroupID { get; set; }

                /// <summary>
                /// Mã đi tỉnh, thành phố
                /// </summary>
                /// <example>45</example>
                public int? StartCityID { get; set; }

                /// <summary>
                /// Mã đi quận, huyện
                /// </summary>
                /// <example>554</example>
                public int? StartDistrictID { get; set; }

                /// <summary>
                /// Mã đi phường, xã
                /// </summary>
                /// <example>8765</example>
                public int? StartWardID { get; set; }

                /// <summary>
                /// Mã đến tỉnh, thành phố
                /// </summary>
                /// <example>50</example>
                public int? EndCityID { get; set; }

                /// <summary>
                /// Mã đến quận, huyện
                /// </summary>
                /// <example>606</example>
                public int? EndDistrictID { get; set; }

                /// <summary>
                /// Mã đến phường, xã
                /// </summary>
                /// <example>9371</example>
                public int? EndWardID { get; set; }

                /// <summary>
                /// Chiều dài của tuyến
                /// </summary>
                /// <example>280</example>
                public decimal Distance { get; set; }
                /// <summary>
                /// Tuyến bắc nam ?
                /// </summary>
                public int? IsNorthSouthRoute { get; set; }
            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã ID
                /// </summary>
                /// <example>7979</example>
                public int? ID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
                /// <summary>
                /// Tuyến bắc nam ?
                /// </summary>
                public int? IsNorthSouthRoute { get; set; }
            }

            public class EditStatus : Del
            {
                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }

            public class Check
            {
                /// <summary>
                /// Mã đi tỉnh, thành phố
                /// </summary>
                /// <example>45</example>
                public int? StartCityID { get; set; }

                /// <summary>
                /// Mã đi quận, huyện
                /// </summary>
                /// <example>554</example>
                public int? StartDistrictID { get; set; }

                /// <summary>
                /// Mã đi phường, xã
                /// </summary>
                /// <example>8765</example>
                public int? StartWardID { get; set; }

                /// <summary>
                /// Mã đến tỉnh, thành phố
                /// </summary>
                /// <example>50</example>
                public int? EndCityID { get; set; }

                /// <summary>
                /// Mã đến quận, huyện
                /// </summary>
                /// <example>606</example>
                public int? EndDistrictID { get; set; }

                /// <summary>
                /// Mã đến phường, xã
                /// </summary>
                /// <example>9371</example>
                public int? EndWardID { get; set; }
            }

            public class Del : GetByID
            {
            }
        }
    }
}