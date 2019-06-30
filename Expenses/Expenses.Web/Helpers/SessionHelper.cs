using Expenses.Data.EntityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Expenses.Web.Helpers
{
    public class SessionHelper
    {
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.Session["usuario"] != null;
        }

        public static void DestroyUserSession()
        {
            if (ExistUserInSession()) HttpContext.Current.Session.Abandon();
        }

        public static User GetUser()
        {
            User user = (User)HttpContext.Current.Session["usuario"];
            return user;
        }

        public static void AddUserToSession(User user)
        {
            HttpContext.Current.Session["usuario"] = user;
        }

    }
}