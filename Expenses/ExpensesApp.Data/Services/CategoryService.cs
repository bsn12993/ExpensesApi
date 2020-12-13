using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using ExpensesApp.Data.EntityModel;
using ExpensesApp.Data.Models;
using ExpensesApp.Data.Services;
using Expenses.Data.UnitOfWork;
using Expenses.Core.Models.Category;

namespace Expenses.Data.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService(UnitOfWorkContainer uow)
        {
            _response = new Response();
            _context = new Context.EntityContext();
            _uow = uow;
        }

        public Response GetCategories()
        {
            try
            {
                var collection = _uow.Repository.CategoryRepository.FindAll();
                return _response.GetResponse(true, "ok", collection);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetCategoryById(int categoryId)
        {
            try
            {
                var findCategory = _uow.Repository.CategoryRepository.FindById(categoryId);
                if (findCategory == null) throw new Exception("No se encontro el registro");
                return _response.GetResponse(true, "ok", findCategory);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetCategoryByUser(int userId)
        {
            try
            {
                var userCategories = _uow.Repository.CategoryRepository.FindAll(userId);
                var collection = new List<CategoryModel>();
                foreach (var item in userCategories)
                {
                    var category = new CategoryModel
                    {
                        Id = item.CategoryId,
                        Name = item.Category.Name,
                        Description = item.Category.Description,
                        UserId = item.UserId
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

        public Response PostCategory(CreateCategoryModel createCategory)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var category = new Category
                    {
                        Name = createCategory.Name
                    };
                    var userCategory = new UserCategory
                    {
                        UserId = createCategory.UserId,
                        Category = category
                    };
                    var newCategory = _uow.Repository.CategoryRepository.Create(category);
                    userCategory.CategoryId = newCategory.Id;

                    var newUserCategory = _uow.Repository.UserCategoryRepository.Create(userCategory);
                    transaction.Commit();
                    return _response.GetResponse(true, "ok", newCategory);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }

        public Response PutCategory(UpdateCategoryModel updateCategory,int categoryId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var findCategory = _uow.Repository.CategoryRepository.FindById(categoryId);
                    if (findCategory == null) throw new Exception("No encontro el registro");

                    findCategory.Name = updateCategory.Name;
                    findCategory.Description = updateCategory.Description;

                    var updateItem = _uow.Repository.CategoryRepository.Update(findCategory);
                    transaction.Commit();

                    return _response.GetResponse(true, "ok", updateItem);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }

        public Response DeleteCategory(int categoryId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var findCategory = _uow.Repository.CategoryRepository.FindById(categoryId);
                    if (findCategory == null) throw new Exception("No encontro el registro");

                    var categoryDeleted = _uow.Repository.CategoryRepository.Delete(findCategory);

                    transaction.Commit();
                    return _response.GetResponse(true, "ok", categoryDeleted);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }
    }
}
