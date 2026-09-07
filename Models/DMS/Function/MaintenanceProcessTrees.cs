namespace APISmartCity.Models.Function
{
    public static class MaintenanceProcessTrees
    {
        public class TreeDigitizingGet
        {
            public string? ReportType { get; set; }
        }
        public class GetMap
        {
            public string? RegionID { get; set; }
        }

        public class TreeDigitizingTree
        {
            public string? Label { get; set; }

            public string? Key { get; set; }
            public TreeDigitizingData Data { get; set; }
            public List<TreeDigitizingTree> Children { get; set; }

            // Thêm thuộc tính ID ở đây
            public string? ID => Data.ID;
            // Tạo một thuộc tính mới để kiểm tra xem nút này có phải là nút gốc không
            public bool IsRoot => Data.ParentID == "0";
        }

        public class TreeDigitizingData
        {
            public string? ID { get; set; }
            public int? Level { get; set; }
            public string? ParentID { get; set; }
            public string? Name { get; set; }
            public string? WaitingAmount { get; set; }
            public string? GoodAmount { get; set; }
            public string? SickAmount { get; set; }
            public string? ReplaceAmount { get; set; }
            public string? TotalAmount { get; set; }
            public decimal Ratio { get; set; }
        }

        public class TreeDigitizingDTO
        {
            public string? label { get; set; }
            public string? key { get; set; }
            public TreeDigitizingData data { get; set; }
            public List<TreeDigitizingDTO> children { get; set; }
        }


        public static class Request
        {
            public class Content
            {
                public string? OID { get; set; }

                public int? TreeID { get; set; }

                public string? TreeNumber { get; set; }

                public string? TreeHeight { get; set; }

                public string? TreeDiameter { get; set; }

                public string? FoliageDiameter { get; set; }

                public string? TreeAge { get; set; }

                public string? Lat { get; set; }

                public string? Long { get; set; }

                public string? FullAddress { get; set; }

                public string? Note { get; set; }

                public string? LinkImg { get; set; }

                public string? TreeTypeID { get; set; }

                public int? TreeStatus { get; set; }
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
            public class GetTreeByID
            {
                public int? ID { get; set; }
            }
            public class AddMobile : Content
            {

            }
            public class AddProcessTree
            {
                public string? ReferenceID {  get; set; }
                public int? TreeID { get; set; }

                public string? TreeNumber { get; set; }

                public string? TreeHeight { get; set; }

                public string? TreeDiameter { get; set; }

                public string? FoliageDiameter { get; set; }

                public string? TreeAge { get; set; }

                public string? Lat { get; set; }

                public string? Long { get; set; }

                public string? FullAddress { get; set; }

                public string? Note { get; set; }

                public string? LinkImg { get; set; }

                public int? TreeStatus { get; set; }
                public string? TreeTypeID { get; set; }
                public string? RouteID { get; set; }
                public int? ManagementUnitID { get; set; }

            }
            public class EditProcessTree : AddProcessTree
            {
                public int? ID { get; set; }
            }
            public class DeteleProcessTree
            {
                public int? ID { get; set; }
            }

            public class EditMobile : AddMobile
            {
                public int? ID { get; set; }
            }
            public class ChangeStatus
            {
                public int? ID { get; set; }
                public string? Note { get; set; }

            }
            public class ChangeStatusRoute
            {
                public string? OID { get; set; }
                public string? Note { get; set; }

            }
            public class ChangeLocation
            {
                public int? ID { get; set; }
                public string? Lat { get; set; }
                public string? Long { get; set; }
            }

            public class GetReport
            {
                /// <summary>
                /// Truyen thang-nam
                /// </summary>
                /// <example>2022-11</example>
                public string? FromDate { get; set; }
                /// <summary>
                /// Truyen thang-nam
                /// </summary>
                /// <example>2024-12</example>
                public string? ToDate { get; set; }
            }



        }
    }
}