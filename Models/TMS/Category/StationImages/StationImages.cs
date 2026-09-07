namespace APISmartCity.Models.Categorys
{
    public static class StationImages
    {
        public static class Request
        {
            public class GetByID
            {
                /// <summary>
                /// Mã định danh
                /// </summary>
                /// <example></example>
                public string? StationID { get; set; }

                /// <summary>
                /// Lớp dữ liệu: Nhà hàng - GasRestaurent, Khu ăn uống - FoodCourt, Gia đình -
                /// GasFamily, Lighting - SLLamps, Cabin - SLCabinets, Cửa hàng - Stores
                /// </summary>
                /// <example></example>
                public string? GeoCode { get; set; }
            }

            public class UploadBase64Strings : GetByID
            {
                /// <summary>
                /// Danh sách hình ảnh đã mã hóa thành base64
                /// </summary>
                /// <example></example>
                public List<string> Base64Strings { get; set; }
            }
        }
    }
}