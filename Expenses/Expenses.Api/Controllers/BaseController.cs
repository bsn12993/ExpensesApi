using Expenses.Core.Models;
using ExpensesApp.Core.Enums;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    public class BaseController : ApiController
    {
        public HttpResponseMessage GetResponse(Response response)
        {
            if (response.Code == (int)EnumCodeResponse.SUCCESS)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else if (response.Code == (int)EnumCodeResponse.WARNING)
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
            else
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, response.Message);
        }
    }
}
