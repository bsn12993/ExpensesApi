using Expenses.Core.Models;
using Expenses.Core.Models.User;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using Expenses.Data.Services;
using Expenses.Data.UnitOfWork;
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
        private UnitOfWorkContainer _uow { get; set; }
        private EntityContext _context;

        public UsersController()
        {
            _context = new EntityContext();
            _uow = new UnitOfWorkContainer(_context);
            _userService = new UserService(_uow);
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
        public HttpResponseMessage PostUser([FromBody] CreateUserModel createUser)
        {
            var response = _userService.PostUser(createUser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutUser([FromBody] UpdateUserModel updateUser, int id)
        {
            var response = _userService.PutUser(updateUser, id);
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