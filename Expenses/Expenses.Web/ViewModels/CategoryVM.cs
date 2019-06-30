using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expenses.Web.ViewModels
{
    public class CategoryVM : ResponseVM
    {
        public int Category_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}