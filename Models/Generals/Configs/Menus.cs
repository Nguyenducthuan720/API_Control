using static APISmartCity.Models.Ver2.Categorys.EventSystems.Requets;

namespace APISmartCity.Models.Ver2.Configs
{
    public static class Menus
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// MenuID
                /// </summary>
                /// <example>100</example>
                public string? MenuID { get; set; }

                /// <summary>
                /// MenuID
                /// </summary>
                /// <example>101</example>
                public string? ParentID { get; set; }

                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>Category</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>PowerTypes</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// Customize
                /// </summary>
                /// <example>Customize</example>
                public string? Customize { get; set; }

                /// <summary>
                /// TableName
                /// </summary>
                /// <example>CategoryGenerals</example>
                public string? TableName { get; set; }
                public string? MenuType { get; set; }
                public string? MenuAction { get; set; }
                public string? MenuController { get; set; }
                public string? MenuImage { get; set; }
                public string? FormAction { get; set; }


                /// <summary>
                /// MenuName
                /// </summary>
                /// <example>Tên Menu</example>
                public string? Name { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention1 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention2 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention3 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention4 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention5 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention6 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention7 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention8 { get; set; }

                /// <summary>
                /// MenuName Extention
                /// </summary>
                /// <example>MenuName Extention</example>
                public string? NameExtention9 { get; set; }
                public string? Extention1 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
                public string? Extention9 { get; set; }
                public string? ImportTemplate { get; set; }
                public string? ExportTemplate { get; set; }

                /// <summary>
                /// Menu Extention
                /// </summary>
                /// <example>Menu Extention</example>
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
                public string? Extention21 { get; set; }
                public string? Extention22 { get; set; }
                public string? Extention23 { get; set; }
                public string? Extention24 { get; set; }
                public string? Extention25 { get; set; }
                public string? Extention26 { get; set; }
                public string? Extention27 { get; set; }
                public string? Extention28 { get; set; }
                public string? Extention29 { get; set; }
                public string? Extention30 { get; set; }

                public int? IsActive { get; set; }

                /// <summary>
                /// Ghi chú
                /// </summary>
                /// <example>Ghi chú thêm</example>
                public string? Note { get; set; }

                public List<Factor> Datas { get; set; }
                public List<Factor> DatasNotify { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// List menuID
                /// </summary>
                /// <example>100:0;101:1;102:1;200:0;201:1;203:1;500:1;501:1;</example>
                public string? ListMenuID { get; set; }
            }

            public class GetParentID
            {
                /// <summary>
                /// Group userID
                /// </summary>
                /// <example>5122</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Mã menu
                /// </summary>
                /// <example>4041</example>
                public string? MenuID { get; set; }

                /// <summary>
                /// Code ứng dụng
                /// </summary>
                /// <example>NLT_SYS</example>
                public string? AppCode { get; set; }
            }

            public class GetMenuRightByGoupID
            {
                /// <summary>
                /// Group userID
                /// </summary>
                /// <example>5122</example>
                public string? GroupID { get; set; }

                /// <summary>
                /// Code ứng dụng
                /// </summary>
                /// <example>NLT_SYS</example>
                public string? AppCode { get; set; }
            }

            public class EditName : Content
            {
                /// <summary>
                /// Link menu
                /// </summary>
                /// <example>/admin/function/npl</example>
                public string? Link { get; set; }

                /// <summary>
                /// Link menu
                /// </summary>
                /// <example>fad fa-file-spreadsheet</example>
                public string? MenuIcon { get; set; }

                /// <summary>
                /// Link menu
                /// </summary>
                /// <example>3</example>
                public int? Sort { get; set; }
            }

            public class EditExtention  
            {
                /// <summary>
                /// MenuID
                /// </summary>
                /// <example>001</example>
                public string? MenuID { get; set; }

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

                public string? Extention21 { get; set; }

                public string? Extention22 { get; set; }

                public string? Extention23 { get; set; }

                public string? Extention24 { get; set; }

                public string? Extention25 { get; set; }

                public string? Extention26 { get; set; }
                public string? Extention27 { get; set; }
                public string? Extention28 { get; set; }
                public string? Extention29 { get; set; }

                /// <summary>
                /// Link tài liệu hướng dẫn sử dụng
                /// </summary>
                public string? Extention30 { get; set; }


            }


            public class AddMenuRight : Content
            {
            }

            public class EditMenuRight
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example>0</example>
                public int? GroupID { get; set; }

                /// <summary>
                /// List menuright ID
                /// </summary>
                /// <example>100:1;500:1;6:1;7:1;2:1;3:1;45:1;4:1;</example>
                public string? ListMenuID { get; set; }
            }

            public class EditListMenuRight
            {
                /// <summary>
                /// ID nhóm người dùng
                /// </summary>
                /// <example>0</example>
                public int? GroupID { get; set; }

                /// <summary>
                /// List menuright ID
                /// </summary>
                /// <example>100:1;500:1;6:1;7:1;2:1;3:1;45:1;4:1;</example>
                public List<ListMenuRight> ListMenuID { get; set; }
            }

            public class ListMenuRight
            {
                /// <summary>
                /// Mã menu
                /// </summary>
                /// <example>001</example>
                public string? MenuID { get; set; }

                /// <summary>
                /// Quyền truy cập
                /// </summary>
                /// <example>1</example>
                public int? AccessWrite { get; set; }
            }
            public class GetMenuNLTGroup
            {
                /// <summary>
                /// Mã công ty
                /// </summary>
                /// <example>-1</example>
                public string? CmpnID { get; set; }

                /// <summary>
                /// Mã truy cập
                /// </summary>
                /// <example>NLT_SYS</example>
                public string? AppCode { get; set; }
            }
        }

        public static class Response
        {
        }
    }
}