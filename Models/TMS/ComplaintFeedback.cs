using DocumentFormat.OpenXml.Wordprocessing;
using static APISmartCity.Models.Systems.Default.Request;

namespace APISmartCity.Models.TMS
{
    public class ComplaintFeedback
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>COMPLAINT</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Entry nghiệp vụ
                /// </summary>
                /// <example>COMPLAINT_HANDLE</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>2026-01-16</example>
                public DateTime? ODate { get; set; }

                /// <summary>
                /// Mã SAP
                /// </summary>
                public string? SAPID { get; set; }

                /// <summary>
                /// Mã Lemon
                /// </summary>
                public string? LemonID { get; set; }

                /// <summary>
                /// Nghiệp vụ bị khiếu nại
                /// </summary>
                public int FuncComplaintID { get; set; }

                /// <summary>
                /// Bộ phận bị khiếu nại
                /// </summary>
                public string DepartmentID { get; set; }

                /// <summary>
                /// ReferenceID (OID liên quan)
                /// </summary>
                public string? ReferenceID { get; set; }
                /// <summary>
                /// ReferenceID (OID liên quan)
                /// </summary>
                public string? ListUserID { get; set; }


                /// <summary>
                /// Loại nguyên nhân
                /// </summary>
                public int ReasonTypeID { get; set; }

                /// <summary>
                /// Nội dung khiếu nại
                /// </summary>
                public string? Content { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                public string? Note { get; set; }

                /// <summary>
                /// Link đính kèm
                /// </summary>
                public string? Link { get; set; }

                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public string? Extention10 { get; set; }
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }

            }


            public class Edit : Add
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class Approval
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
                public string? ReceiveContent { get; set; }
                public string? ReceiveLink { get; set; }
                public int? ReceiveStatus { get; set; }
                public string? ReceiveUser { get; set; }

                public string? ReceiveSolution { get; set; }
                public int? ReceiveDepartmentID { get; set; }
                public string? Extention1 { get; set; }
                public string? Extention2 { get; set; }
                public string? Extention3 { get; set; }
                public string? Extention4 { get; set; }
                public string? Extention5 { get; set; }
                public string? Extention6 { get; set; }
                public string? Extention7 { get; set; }
                public string? Extention8 { get; set; }
                public string? Extention9 { get; set; }
                public string? Extention10 { get; set; }
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }

            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>GTL/09/02/2023/001</example>
                public string? OID { get; set; }
            }

            public class Get
            {
            }


            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
            }

            public class UpdateFinal : GetByID
            {
                public int FinalStatus { get; set; }
                public string FinalContent { get; set; }
			    public string FinalLink { get; set; }
            }

            //public class GetMobile
            //{
            //    /// <summary>
            //    /// Loại nghiệp vụ
            //    /// </summary>
            //    /// <example>RQ_SHIPPINGPRICE</example>
            //    public string? EntryID { get; set; }
            //}
        }
    }
}