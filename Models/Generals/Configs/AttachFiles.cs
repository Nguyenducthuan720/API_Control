namespace APISmartCity.Models.Ver2.Configs
{
    public class AttachFiles
    {
        public class Request
        {
            public class Content
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>Test</example>
                public string? Name { get; set; }

                public string? NameExtention1 { get; set; }
                public string? NameExtention2 { get; set; }
                public string? NameExtention3 { get; set; }
                public string? NameExtention4 { get; set; }
                public string? NameExtention5 { get; set; }
                public string? NameExtention6 { get; set; }
                public string? NameExtention7 { get; set; }
                public string? NameExtention8 { get; set; }
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Ghi chú. truyền mã shipping ID vào đây nếu attach file tài xế
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

                /// <summary>
                /// FormFile
                /// </summary>
                /// <example></example>
                public List<IFormFile> File { get; set; }
            }

            public class ContentBase64
            {
                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>Test</example>
                public string? Name { get; set; }

                public string? NameExtention1 { get; set; }
                public string? NameExtention2 { get; set; }
                public string? NameExtention3 { get; set; }
                public string? NameExtention4 { get; set; }
                public string? NameExtention5 { get; set; }
                public string? NameExtention6 { get; set; }
                public string? NameExtention7 { get; set; }
                public string? NameExtention8 { get; set; }
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Ghi chú. truyền mã shipping ID vào đây nếu attach file tài xế
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

                /// <summary>
                /// FormFile
                /// </summary>
                /// <example></example>
                public List<string> ListBase64 { get; set; }
            }

            public class AddFileCont : Content
            {
                public string? EntryID { get; set; }
            }

            public class AddFileDriver : Content
            {
                /// <summary>
                /// Truyền EntryID của đơn hàng vào đây
                /// </summary>
                /// <example>CT_NOBOX</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Truyền mã vận đơn vào đây
                /// </summary>
                /// <example>VD/23/03/0011</example>
                public string? OID { get; set; }

                /// <summary>
                /// Truyền mã đơn hàngvào đây
                /// </summary>
                /// <example>ĐHR/23/03/008</example>
                public string? ReferenceID { get; set; }

                /// <summary>
                /// Truyền ShippingID
                /// </summary>
                /// <example>1</example>
                public int? ShippingID { get; set; }
            }

            public class Get
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCL/24/11/22/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>ALLOWANCE</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>DRIVERHELPER</example>
                public string? EntryID { get; set; }
            }

            public class GetFileDriver
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCL/24/11/22/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>ALLOWANCE</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>DRIVERHELPER</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// ShippingID
                /// </summary>
                /// <example>1</example>
                public int? ShippingID { get; set; }
            }

            public class Add : Content
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCL/24/11/22/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>ALLOWANCE</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>DRIVERHELPER</example>
                public string? EntryID { get; set; }
            }

            public class AddBase64 : ContentBase64
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCL/24/11/22/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>ALLOWANCE</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>DRIVERHELPER</example>
                public string? EntryID { get; set; }
            }

            public class Edit
            {
                public int? ID { get; set; }

                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>ÐXPCL/24/11/22/006</example>
                public string? OID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>ALLOWANCE</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// Nghiệp vụ
                /// </summary>
                /// <example>DRIVERHELPER</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Tên file
                /// </summary>
                /// <example>Test</example>
                public string? Name { get; set; }

                public string? NameExtention1 { get; set; }

                public string? NameExtention2 { get; set; }
                public string? NameExtention3 { get; set; }
                public string? NameExtention4 { get; set; }
                public string? NameExtention5 { get; set; }
                public string? NameExtention6 { get; set; }
                public string? NameExtention7 { get; set; }
                public string? NameExtention8 { get; set; }
                public string? NameExtention9 { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

                /// <summary>
                /// Name.Extension
                /// </summary>
                /// <example>abc.pdf</example>
                public List<IFormFile> File { get; set; }

                public string? OldLinks { get; set; }
            }

            public class Del
            {
                public int? ID { get; set; }
            }

            public class DelByOID
            {
                /// <summary>
                /// Truyền mã vận đơn vào đây
                /// </summary>
                /// <example>VD/23/03/0011</example>
                public string? OID { get; set; }

                /// <summary>
                /// Mã giao hàng
                /// </summary>
                /// <example>1</example>
                public int? ShippingID { get; set; }

                /// <summary>
                /// Link
                /// </summary>
                /// <example>https://abc.def</example>
                public string? DeleteLink { get; set; }
            }
        }

        public class Response
        {
        }
    }
}