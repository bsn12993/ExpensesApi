using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expenses.Web.ViewModels
{
    public class UserVM : ResponseVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}