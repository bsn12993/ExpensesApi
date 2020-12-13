using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.DataAccess;
using System;
using System.Collections.Generic;
using ExpensesApp.Data.EntityModel;
using ExpensesApp.Data.Models;

namespace Expenses.Data.Services
{
    public class CategoriesServices
    {
        private DA_Category DA_Category { get; set; }
        private Response _response;

        public CategoriesServices()
        {
            DA_Category = new DA_Category();
            _response = new Response();
        }

        public Response GetCategories()
        {
            try
            {
                var collection = DA_Category.GetCategories();
                return _response.GetResponse(true, "ok", collection);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetCategoryById(int idcategory)
        {
            try
            {
                var category = DA_Category.GetCategoryById(idcategory);
                return _response.GetResponse(true, "ok", category);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetCategoryByUser(int iduser)
        {
            try
            {
                var userCategories = DA_Category.GetCategoryByUser(iduser);
                var collection = new List<CategoryModel>();
                foreach (var item in userCategories)
                {
                    var category = new CategoryModel
                    {
                        Id = item.Category_Id,
                        Name = item.Category.Name,
                        Description = item.Category.Description,
                        UserId = item.User_Id
                    };
                    collection.Add(category);
                }
                return _response.GetResponse(true, "ok", collection);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PostCategory(CategoryModel categoryModel)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryModel.Name
                };
                var userCategory = new UserCategory
                {
                    User_Id = categoryModel.UserId,
                    Category = category
                };
                var newCategory = DA_Category.InsertCategory(userCategory);
                return _response.GetResponse(true, "ok", newCategory);

            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutCategory(CategoryModel categoryModel,int idcategory)
        {
            try
            {
                var currentItem = DA_Category.GetCategoryById(idcategory);
                currentItem.Name = categoryModel.Name;
                currentItem.Description = categoryModel.Description;
                var updateItem = DA_Category.UpdateCategory(currentItem, idcategory);
                return _response.GetResponse(true, "ok", updateItem);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response DeleteCategory(int idcategory)
        {
            try
            {
                var categoryDeleted=DA_Category.DeleteCategory(idcategory);
                return _response.GetResponse(true, "ok", categoryDeleted);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response DeleteUserCategory(int idcategory, int iduser)
        {
            try
            {
                var categoryDeleted = DA_Category.DeleteUserCategory(idcategory, iduser);
                return _response.GetResponse(true, "ok", categoryDeleted);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}
