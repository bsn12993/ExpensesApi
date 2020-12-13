using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Core.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public Response GetResponse(bool isSuccess = false, string message = "", object result = null)
        {
            return new Response
            {
                IsSuccess = isSuccess,
                Message = message,
                Result = result
            };
        }
    }
}
