using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesApp.Data.EntityModel;

namespace Expenses.Data.Services
{
    public class CategoriesServices
    {
        DA_Category DA_Category { get; set; }

        public CategoriesServices()
        {
            DA_Category = new DA_Category();
        }

        public Response GetCategories()
        {
            return DA_Category.GetCategories();
        }

        public Response GetCategoryById(int idcategory)
        {
            return DA_Category.GetCategoryById(idcategory);
        }

        public Response GetCategoryByUser(int iduser)
        {
            return DA_Category.GetCategoryByUser(iduser);
        }

        public Response PostCategory(UserCategory userCategory)
        {
            return DA_Category.InsertCategory(userCategory);
        }

        public Response PutCategory(Category category,int idcategory)
        {
            return DA_Category.UpdateCategory(category, idcategory);
        }

        public Response DeleteCategory(int idcategory)
        {
            return DA_Category.DeleteCategory(idcategory);
        }

        public Response DeleteUserCategory(int idcategory, int iduser)
        {
            return DA_Category.DeleteUserCategory(idcategory, iduser);
        }
    }
}
