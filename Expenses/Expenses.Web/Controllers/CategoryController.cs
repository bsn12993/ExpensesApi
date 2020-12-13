using Expenses.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Expenses.Core.Models;
using Expenses.Web.Helpers;
using Expenses.Data.EntityModel;
using Expenses.Web.ViewModels;

namespace Expenses.Web.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public async Task<ActionResult> Index()
        {
            if (SessionHelper.ExistUserInSession())
            {
                CategoryVM categoryVM = new CategoryVM();
                var response = await ApiServices.GetInstance()
                    .GetList<Response>($"api/category/byuser/{SessionHelper.GetUser().Id}");
                if (response.IsSuccess)
                {
                    return View((List<CategoryVM>)response.Result);
                }
                else
                {
                    categoryVM.IsSuccess = response.IsSuccess;
                    categoryVM.Message = response.Message;
                    return View(categoryVM);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        
    }
}