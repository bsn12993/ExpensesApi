using Expenses.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void ExecuteCore()
        {
            if (SessionHelper.ExistUserInSession())
            {
                ViewBag.UserName = SessionHelper.GetUser().Name;
            }
            else
            {
                ViewBag.UserName = string.Empty;
            }
        }
    }
}