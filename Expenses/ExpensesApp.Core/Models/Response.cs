namespace Expenses.Core.Models
{
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public Response GetResponse(int code, string message = "", object result = null)
        {
            return new Response
            {
                Code = code,
                Message = message,
                Result = result
            };
        }
    }
}
