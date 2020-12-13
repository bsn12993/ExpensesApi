using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.Repositories;
using System;
using System.Collections.Generic;
using ExpensesApp.Data.EntityModel;
using ExpensesApp.Data.Models;

namespace Expenses.Data.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository { get; set; }
        private Response _response;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
            _response = new Response();
        }

        public Response GetCategories()
        {
            try
            {
                var collection = _categoryRepository.GetCategories();
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
                var category = _categoryRepository.GetCategoryById(idcategory);
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
                var userCategories = _categoryRepository.GetCategoryByUser(iduser);
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
                var newCategory = _categoryRepository.InsertCategory(userCategory);
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
                var currentItem = _categoryRepository.GetCategoryById(idcategory);
                currentItem.Name = categoryModel.Name;
                currentItem.Description = categoryModel.Description;
                var updateItem = _categoryRepository.UpdateCategory(currentItem, idcategory);
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
                var categoryDeleted=_categoryRepository.DeleteCategory(idcategory);
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
                var categoryDeleted = _categoryRepository.DeleteUserCategory(idcategory, iduser);
                return _response.GetResponse(true, "ok", categoryDeleted);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}
