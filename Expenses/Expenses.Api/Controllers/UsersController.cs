using Expenses.Core.Models;
using Expenses.Core.Models.User;
using Expenses.Data.Context;
using Expenses.Data.Services;
using Expenses.Data.UnitOfWork;
using ExpensesApp.Core.Models.User;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseController
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
            return GetResponse(_userService.GetUsers());
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetUserBy(int id)
        {
            return GetResponse(_userService.GetUserById(id));
        }

        [HttpPost]
        [Route("validate")]
        public HttpResponseMessage GetUserByEmailAndPassword([FromBody] LoginUserModel loginUser)
        {
            return GetResponse(_userService.GetUserEmailAndPassaword(loginUser.Email, loginUser.Password));
        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostUser([FromBody] CreateUserModel createUser)
        {
            return GetResponse(_userService.PostUser(createUser));
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutUser([FromBody] UpdateUserModel updateUser, int id)
        {
            return GetResponse(_userService.PutUser(updateUser, id));
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            return GetResponse(_userService.DeleteUser(id));
        }
    }
}