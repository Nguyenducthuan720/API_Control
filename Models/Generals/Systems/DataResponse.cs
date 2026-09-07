namespace APISmartCity.Models
{
    public class DataResponse
    {
        public int? StatusCode { get; set; }
        public int? Success { get; set; }
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
        public dynamic Result { get; set; }

        public DataResponse()
        {
            StatusCode = 200;
            Success = 1;
            Message = "";
            ErrorCode = "";
        }

        public DataResponse(string des, dynamic result, string err)
        {
            if (err == "0" || err == "000")
            {
                Success = 1;
                StatusCode = 200;
            }
            else
            {
                Success = 0;
                StatusCode = int.Parse(err);
            }
            Message = des;
            Result = result;
            ErrorCode = err;
        }
    }

    public class DataResponseEmbedded
    {
        public string? Message { get; set; }
        public dynamic Result { get; set; }

        public DataResponseEmbedded()
        {
            Message = "";
        }

        public DataResponseEmbedded(string des, dynamic result, string err)
        {
            Message = des;
            Result = result;
        }
    }
}