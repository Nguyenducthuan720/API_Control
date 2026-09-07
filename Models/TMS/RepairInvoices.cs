namespace APISmartCity.Models.TMS
{
    public static class RepairInvoices
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }
            }

            public class GetDetail
            {
                /// <summary>
                /// Mã đơn vị sửa chữa
                /// </summary>
                /// <example>3</example>
                public int? RepairProducersID { get; set; }

                /// <summary>
                /// Từ ngày
                /// </summary>
                /// <example>2023/07/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Đến ngày
                /// </summary>
                /// <example>2023/09/10</example>
                public string? ToDate { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Trạng thái
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }


            public class Submit
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// Trạng thái
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class UpdatePayment
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }

                /// <summary>
                /// StrDetail
                /// </summary>
                /// <example>1,2,3</example>
                public string? ProcessDriverRepairsSuppliesID { get; set; }


            }

            public class Edit : Content
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>KHBH/0001</example>
                public string? OID { get; set; }
            }

            public class Add : Content
            {
            }

            public class Content
            {
                /// <summary>
                /// Odate
                /// </summary>
                /// <example>2023/09/01</example>
                public string? ODate { get; set; }

                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example>3</example>
                public int? RepairProducersID { get; set; }

                /// <summary>
                /// FromDate
                /// </summary>
                /// <example>2023/07/01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// FromDate
                /// </summary>
                /// <example>2023/09/10</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// TotalAmntShip
                /// </summary>
                /// <example>10000000</example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example>Đại diện bên A</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example>Chức vụ bên A</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example>Đại diện bên B</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example>Chức vụ bên B</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example>Đại diện bên A</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example>Chức vụ bên A</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example>Đại diện bên B</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example>Chức vụ bên B</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example>Chức vụ bên B</example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// StrDetail
                /// </summary>
                /// <example>1,2,3</example>
                public string? ProcessDriverRepairsSuppliesID { get; set; }
            }
        }
    }
}