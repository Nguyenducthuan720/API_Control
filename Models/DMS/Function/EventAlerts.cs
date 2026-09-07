using static APISmartCity.Models.Systems.Default.Request;

namespace APISmartCity.Models.Ver2.Function
{
    public class EventAlerts
    {
        public class Request
        {
            public class ContentEventAlerts : Extention
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>EventAlerts</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>SmartLighting</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// OID
                /// </summary>
                /// <example>Auto</example>
                public string? OID { get; set; }

                /// <summary>
                /// ngày
                /// </summary>
                /// <example>2024/04/05</example>
                public string? Odate { get; set; }

                /// <summary>
                /// List station setup
                /// </summary>
                /// <example>CS123,CS456</example>
                public string? StationID { get; set; }

                /// <summary>
                /// Trạng thái
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// note
                /// </summary>
                /// <example>haizzz</example>
                public string? Note { get; set; }
            }

            public class ContentEventAlertDetails : Extention
            {
                public int? IsSelected { get; set; }

                public int? EventID { get; set; }

                public int? Period { get; set; }

                public string? SendType { get; set; }

                public string? SendValue { get; set; }

                public string? SendTypeOther { get; set; }

                public string? SendValueOther { get; set; }

                public string? SendTypeSystem { get; set; }

                public string? SendValueSystem { get; set; }

                public int? IsSendCustomer { get; set; }

                public int? IsDefault { get; set; }

                public string? Title { get; set; }

                public string? TitleExtention1 { get; set; }

                public string? Body { get; set; }

                public string? BodyExtention1 { get; set; }

                public string? Image { get; set; }

                public string? Note { get; set; }
            }

            public class ContentEventAlertIndicators : Extention
            {
                public string? IndicatorCode { get; set; }

                public int? LevelID { get; set; }

                public decimal FromValue { get; set; }

                public decimal ToValue { get; set; }

                public string? Port { get; set; }

                public string? Note { get; set; }
            }

            public class GetByOID
            {
                public string? OID { get; set; }
            }
         
            public class EditStatus : GetByOID
            {
                public int? IsActive { get; set; }
            }

            public class Add : ContentEventAlerts
            {
                public List<ContentEventAlertDetails> Events { get; set; }

                public List<ContentEventAlertIndicators> Indicators { get; set; }
            }
            public class GetEntryID
            {
                public string? EntryID { get; set; }
            }
            public class GetOIDByEntryID
            {
                public string? OID { get; set; }

                public string? EntryID { get; set; }
            }
        }
      
    }
}