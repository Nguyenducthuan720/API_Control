namespace APISmartCity.Models.Categorys
{
    public static class ApprovalProcess
    {
        public static class Request
        {
            public class AddOrEdit : GetByID
            {
                public string CmpnIDList { get; set; }
                public List<Factor> Process { get; set; }
                public string SAPID { get; set; }
                public string LemonID { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string Name { get; set; }

                /// <summary>
                /// ApprovalCode
                /// </summary>
                /// <example></example>
                public string ApprovalCode { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Note</example>
                public string Note { get; set; }

                public string DetailContent { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string NameExtention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string NameExtention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string NameExtention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string NameExtention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string NameExtention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string NameExtention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string NameExtention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string NameExtention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string NameExtention9 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string NameExtention10 { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string Extention9 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string Extention10 { get; set; }
                public string Extention11 { get; set; }
                public string Extention12 { get; set; }
                public string Extention13 { get; set; }
                public string Extention14 { get; set; }
                public string Extention15 { get; set; }
                public string Extention16 { get; set; }
                public string Extention17 { get; set; }
                public string Extention18 { get; set; }
                public string Extention19 { get; set; }
                public string Extention20 { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int IsActive { get; set; }
                public int IsProcessApply { get; set; }
                public List<AddDetail> Details { get; set; }
            }
            public class AddDetail
            {
                public int ID { get; set; }
                public int IsApprovalExtendedInfo { get; set; }
                public int ApprovalProcessID { get; set; }
                public int Step { get; set; }
                public int ApprovalStep { get; set; }
                public int RejectionStep { get; set; }
                public int ActionTypeID { get; set; }
                public string Description { get; set; }
                public string Note { get; set; }
                public string Formula { get; set; }
                public string AdditionalFormula { get; set; }
                public int TransitionStep01 { get; set; }
                public int TransitionStep02 { get; set; }
                public int TransitionStep03 { get; set; }
                public int TransitionStep04 { get; set; }
                public int TransitionStep05 { get; set; }
                public int TransitionStep06 { get; set; }
                public int TransitionStep07 { get; set; }
                public int TransitionStep08 { get; set; }
                public int TransitionStep09 { get; set; }
                public int IsAppliesCondition { get; set; }
                public int IsStructureApply { get; set; }
                public string DefaultApprover { get; set; }
                public string DefaultApprovalGroup { get; set; }
                public int ReminderInterval { get; set; }
                public string SigningNotice { get; set; }
                public string RejectionNotice { get; set; }
                public string Extention1 { get; set; }
                public string Extention2 { get; set; }
                public string Extention3 { get; set; }
                public string Extention4 { get; set; }
                public string Extention5 { get; set; }
                public string Extention6 { get; set; }
                public string Extention7 { get; set; }
                public string Extention8 { get; set; }
                public string Extention9 { get; set; }
            }

            public class AddOrEditArray
            {
                public List<AddDetail> dataJson { get; set; }
            }

            public class Entry
            {
                public string EntryID { get; set; }
            }
            public class Factor
            {
                public string FactorID { get; set; }

                public List<Entry> Entry { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// ApprovalProcessID
                /// </summary>
                /// <example></example>
                public int ApprovalProcessID { get; set; }
            }
            public class GetDetail : GetByID
            {
                /// <summary>
                /// Mã CT
                /// </summary>
                public string OID { get; set; }
            }
        }
    }
}