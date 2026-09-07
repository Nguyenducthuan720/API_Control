namespace APISmartCity.DI
{
    public class UserInfo
    {
        public string? UserID { get; set; } = null!;
        public string? CmpnID { get; set; } = null!;
        public string? Language { get; set; } = null!;
        public string? TokenApp { get; set; } = null!;
        public string? IsGateWay { get; set; } = null!;

    }

    public class APIInfo
    {
        public string? APIKEY { get; set; } = null!;

        public string? LinkSubmit { get; set; } = null!;

        public string? Controller { get; set; } = null!;

        public string? Function { get; set; } = null!;

        public string? Language { get; set; } = null!;
        public string? CmpnID { get; set; } = null!;

        public string? AppCode { get; set; } = null!;

        public string? CollectFromServer { get; set; } = null!;

    }

   
}