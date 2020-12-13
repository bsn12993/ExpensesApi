using Expenses.Data.EntityModel;
using Expenses.Data.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        // GET: Users
        private UserService _userService { get; set; }

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetUsers()
        {
            var response = _userService.GetUsers();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetUserBy(int id)
        {
            var response = _userService.GetUserById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpGet]
        [Route("validate")]
        public HttpResponseMessage GetUserByEmailAndPassword(string email, string password)
        {
            var response = _userService.GetUserEmailAndPassaword(email, password);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostUser([FromBody] User user)
        {
            var response = _userService.PostUser(user);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutUser([FromBody] User user, int id)
        {
            var response = _userService.PutUser(user, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpPut]
        [Route("update/name/{id}")]
        public HttpResponseMessage PutUserName([FromBody] User user, int id)
        {
            var response = _userService.PutUserName(user.Name, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpPut]
        [Route("update/lastname/{id}")]
        public HttpResponseMessage PutUserLastName([FromBody] User user, int id)
        {
            var response = _userService.PutUserLastName(user.LastName, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpPut]
        [Route("update/email/{id}")]
        public HttpResponseMessage PutUserEmail([FromBody] User user, int id)
        {
            var response = _userService.PutUserEmail(user.Email, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpPut]
        [Route("update/password/{id}")]
        public HttpResponseMessage PutUserPassword([FromBody] User user, int id)
        {
            var response = _userService.PutUserPassword(user.Password, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }
    }
}