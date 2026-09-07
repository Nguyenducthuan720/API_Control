namespace DMS.Models.Generals.Configs
{
    public class OtherApprovals
    {
        public static class Request
        {
           public class AddOrEdit
           {
                /// <summary>
                /// Ngày chứng từ
                /// </summary>
                /// <example>2022/11/18</example>
                public string? ODate { get; set; }

                ///<summary>
                /// From date
                /// </summary>
                /// <example>12/01/2025</example>
                public string? FromDate { get; set; }

                ///<summary>
                /// To date
                /// </summary>
                /// <example>12/07/2025</example>
                public string? ToDate { get; set; }

                ///<summary>
                /// Loại đề xuất
                /// </summary>
                /// <example></example>
                public string? ProposalTypeID { get; set; }

                public string? RequestUserID { get; set; }

                public string? ReferenceID { get; set; }

                /// <summary>
                /// Nội dung
                /// </summary>
                /// <example>Test content</example>
                public string? Content { get; set; }

                /// <summary>
                /// Lý do đề xuất
                /// </summary>
                /// <example></example>
                public string? ReasonRequest { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                ///<example>Note</example>
                public string? Note { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                ///<example>http://abc.com</example>
                public string? Link { get; set; }

                /// <summary>
                /// IsLock
                /// </summary>
                /// <example>0</example>
                public int? IsLock { get; set; } = 0;

                /// <summary>
                /// Loại tiền tệ
                /// </summary>
                /// <example>0</example>
                public int? CurrencyID { get; set; }

                /// <summary>
                /// Tỷ giá tiền
                /// </summary>
                /// <example>1</example>
                public decimal ExchangeRate { get; set; }

                /// <summary>
                /// Ngày tỷ giá tiền
                /// </summary>
                /// <example>25/09/2025</example>
                public DateTime ExchangeRateDate { get; set; }

                /// <summary>
                /// Tổng đề xuất
                /// </summary>
                /// <example>0</example>
                public decimal TotalAmount { get; set; }

                /// <summary>
                /// BS1
                /// </summary>
                /// <example>Test BS1</example>
                public string? BS1 { get; set; }

                /// <summary>
                /// BS2
                /// </summary>
                /// <example>Test BS2</example>
                public string? BS2 { get; set; }

                /// <summary>
                /// BS3
                /// </summary>
                /// <example>Test BS3</example>
                public string? BS3 { get; set; }

                /// <summary>
                /// BS4
                /// </summary>
                /// <example>Test BS4</example>
                public string? BS4 { get; set; }

                /// <summary>
                /// BS5
                /// </summary>
                /// <example>Test BS5</example>
                public string? BS5 { get; set; }

                /// <summary>
                /// BS6
                /// </summary>
                /// <example>Test BS6</example>
                public string? BS6 { get; set; }

                /// <summary>
                /// BS7
                /// </summary>
                /// <example>Test BS7</example>
                public string? BS7 { get; set; }

                /// <summary>
                /// BS8
                /// </summary>
                /// <example>Test BS8</example>
                public string? BS8 { get; set; }

                /// <summary>
                /// BS9
                /// </summary>
                /// <example>Test BS9</example>
                public string? BS9 { get; set; }

                /// <summary>
                /// BS10
                /// </summary>
                /// <example>Test BS10</example>
                public string? BS10 { get; set; }

                /// <summary>
                /// BS11
                /// </summary>
                /// <example>Test BS11</example>
                public string? BS11 { get; set; }

                /// <summary>
                /// BS12
                /// </summary>
                /// <example>Test BS12</example>
                public string? BS12 { get; set; }

                /// <summary>
                /// BS13
                /// </summary>
                /// <example>Test BS13</example>
                public string? BS13 { get; set; }

                /// <summary>
                /// BS14
                /// </summary>
                /// <example>Test BS14</example>
                public string? BS14 { get; set; }

                /// <summary>
                /// BS15
                /// </summary>
                /// <example>Test BS15</example>
                public string? BS15 { get; set; }

                /// <summary>
                /// BS16
                /// </summary>
                /// <example>Test BS16</example>
                public string? BS16 { get; set; }

                /// <summary>
                /// BS17
                /// </summary>
                /// <example>Test BS17</example>
                public string? BS17 { get; set; }

                /// <summary>
                /// BS18
                /// </summary>
                /// <example>Test BS18</example>
                public string? BS18 { get; set; }

                /// <summary>
                /// BS19
                /// </summary>
                /// <example>Test BS19</example>
                public string? BS19 { get; set; }

                /// <summary>
                /// BS20
                /// </summary>
                /// <example>Test BS20</example>
                public string? BS20 { get; set; }

                /// <summary>
                /// BS21
                /// </summary>
                /// <example>Test BS21</example>
                public string? BS21 { get; set; }

                /// <summary>
                /// BS22
                /// </summary>
                /// <example>Test BS22</example>
                public string? BS22 { get; set; }

                /// <summary>
                /// BS23
                /// </summary>
                /// <example>Test BS23</example>
                public string? BS23 { get; set; }

                /// <summary>
                /// BS24
                /// </summary>
                /// <example>Test BS24</example>
                public string? BS24 { get; set; }

                /// <summary>
                /// BS25
                /// </summary>
                /// <example>Test BS25</example>
                public string? BS25 { get; set; }

                /// <summary>
                /// BS26
                /// </summary>
                /// <example>Test BS26</example>
                public string? BS26 { get; set; }

                /// <summary>
                /// BS27
                /// </summary>
                /// <example>Test BS27</example>
                public string? BS27 { get; set; }

                /// <summary>
                /// BS28
                /// </summary>
                /// <example>Test BS28</example>
                public string? BS28 { get; set; }

                /// <summary>
                /// BS29
                /// </summary>
                /// <example>Test BS29</example>
                public string? BS29 { get; set; }

                /// <summary>
                /// BS30
                /// </summary>
                /// <example>Test BS30</example>
                public string? BS30 { get; set; }

                /// <summary>
                /// Extention 1
                /// </summary>
                /// <example>Test Extention 1</example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention 2
                /// </summary>
                /// <example>Test Extention 2</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention 3
                /// </summary>
                /// <example>Test Extention 3</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention 4
                /// </summary>
                /// <example>Test Extention 4</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention 5
                /// </summary>
                /// <example>Test Extention 5</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention 6
                /// </summary>
                /// <example>Test Extention 6</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention 7
                /// </summary>
                /// <example>Test Extention 7</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention 8
                /// </summary>
                /// <example>Test Extention 8</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention 9
                /// </summary>
                /// <example>Test Extention 9</example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Extention 10
                /// </summary>
                /// <example>Test Extention 10</example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// Extention 11
                /// </summary>
                /// <example>Test Extention 11</example>
                public string? Extention11 { get; set; }

                /// <summary>
                /// Extention 12
                /// </summary>
                /// <example>Test Extention 12</example>
                public string? Extention12 { get; set; }

                /// <summary>
                /// Extention 13
                /// </summary>
                /// <example>Test Extention 13</example>
                public string? Extention13 { get; set; }

                /// <summary>
                /// Extention 14
                /// </summary>
                /// <example>Test Extention 14</example>
                public string? Extention14 { get; set; }

                /// <summary>
                /// Extention 15
                /// </summary>
                /// <example>Test Extention 15</example>
                public string? Extention15 { get; set; }

                /// <summary>
                /// Extention 16
                /// </summary>
                /// <example>Test Extention 16</example>
                public string? Extention16 { get; set; }

                /// <summary>
                /// Extention 17
                /// </summary>
                /// <example>Test Extention 17</example>
                public string? Extention17 { get; set; }

                /// <summary>
                /// Extention 18
                /// </summary>
                /// <example>Test Extention 18</example>
                public string? Extention18 { get; set; }

                /// <summary>
                /// Extention 19
                /// </summary>
                /// <example>Test Extention 19</example>
                public string? Extention19 { get; set; }

                /// <summary>
                /// Extention 20
                /// </summary>
                /// <example>Test Extention 20</example>
                public string? Extention20 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention21 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention22 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention23 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention24 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention25 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention26 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention27 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention28 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention29 { get; set; }

                /// <summary>
                /// Mở rộng
                /// </summary>
                /// <example></example>
                public string? Extention30 { get; set; }

                public List<OtherProposalDetails> Details { get; set; }
            }

            public class OtherProposalDetails
            {
                public int? ID { get; set; }
                public string? OID { get; set; }
                public string? A { get; set; }
                public string? B { get; set; }
                public string? C { get; set; }
                public string? D { get; set; }
                public string? E { get; set; }
                public string? F { get; set; }
                public string? G { get; set; }
                public string? H { get; set; }
                public string? I { get; set; }
                public string? J { get; set; }
                public string? K { get; set; }
                public string? L { get; set; }
                public string? M { get; set; }
                public string? N { get; set; }
                public string? O { get; set; }
                public string? P { get; set; }
                public string? Q { get; set; }
                public string? R { get; set; }
                public string? S { get; set; }
                public string? T { get; set; }
                public string? U { get; set; }
                public string? V { get; set; }
                public string? W { get; set; }
                public string? X { get; set; }
                public string? Y { get; set; }
                public string? Z { get; set; }
                public string? AA { get; set; }
                public string? AB { get; set; }
                public string? AC { get; set; }
                public string? AD { get; set; }
                public string? AE { get; set; }
                public string? AF { get; set; }
                public string? AG { get; set; }
                public string? AH { get; set; }
                public string? AI { get; set; }
                public string? AJ { get; set; }
                public string? AK { get; set; }
                public string? AL { get; set; }
                public string? AM { get; set; }
                public string? AN { get; set; }
                public string? AO { get; set; }
                public string? AP { get; set; }
                public string? AQ { get; set; }
                public string? AR { get; set; }
                public string? AS { get; set; }
                public string? AT { get; set; }
                public string? AU { get; set; }
                public string? AV { get; set; }
                public string? AW { get; set; }
                public string? AX { get; set; }
                public string? AY { get; set; }
                public string? AZ { get; set; }
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

            }
            public class Add : AddOrEdit {
                /// <sumary>
                /// FactorID
                /// </sumary>
                /// <example>TestFactorID</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>TestEntryID</example>
                public string? EntryID { get; set; }

            }
            public class Edit : AddOrEdit {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>Test/PL/25/09/0001</example>
                public string? OID { get; set; }
            }

            public class GetById
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>Test/PL/25/09/0001</example>
                public string? OID { get; set; }
            }
            
            public class Delete : GetById
            {

            }
            public class Submit  : GetById {
                /// <summary>
                /// IsLock
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }
            public class Annul : GetById
            {
                /// <summary>
                /// IsLock
                /// </summary>
                /// <example>1</example>
                public string? Extention2 { get; set; }
            }
            public class GetFilter
            {
                public string? FromDate { get; set; }
                public string? ToDate { get; set; }
            }
        }
    }
}
