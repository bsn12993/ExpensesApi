using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expenses.Web.ViewModels
{
    public class ResponseVM
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}