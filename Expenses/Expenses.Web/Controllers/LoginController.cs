using Expenses.Data.EntityModel;
using Expenses.Web.Helpers;
using Expenses.Web.Services;
using Expenses.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new UserVM());
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserVM user)
        {

            var response = await ApiServices.GetInstance()
                .GetItem<User>($"api/users/validate/{user.Email.Encrypt()}/{user.Password.Encrypt()}");
            if (response.IsSuccess)
            {
                SessionHelper.AddUserToSession((User)response.Result);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                user.Message = response.Message;
                user.IsSuccess = response.IsSuccess;
                return View(user);
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}