using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using ExpensesApp.Data.EntityModel;
using ExpensesApp.Data.Models;
using ExpensesApp.Data.Services;
using Expenses.Data.UnitOfWork;
using Expenses.Core.Models.Category;
using ExpensesApp.Core.Exceptions;
using ExpensesApp.Core.Enums;

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
                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", collection);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetCategoryById(int categoryId)
        {
            try
            {
                if (categoryId == 0) 
                    throw new IdRequiredException($"El id de la categoría es requerido");

                var findCategory = _uow.Repository.CategoryRepository.FindById(categoryId);
                if (findCategory == null) 
                    throw new RecordNotFoundException($"No se encontro la categoría con el id {categoryId}");

                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", findCategory);
            }
            catch(IdRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(RecordNotFoundException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetCategoryByUser(int userId)
        {
            try
            {
                if (userId == 0) throw new IdRequiredException($"El id del usuario es requerido");
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
                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", collection);
            }
            catch(IdRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response PostCategory(CreateCategoryModel createCategory)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (createCategory == null)
                        throw new ModelIsNullException("No se recibierón datos para crear la categoria");

                    if (string.IsNullOrEmpty(createCategory.Name))
                        throw new NameIsRequiredException("El nombre es requerido");

                    if (string.IsNullOrEmpty(createCategory.Description))
                        throw new DescriptionIsRequiredException("La descripción es requerido");

                    if (createCategory.UserId == 0)
                        throw new IdRequiredException("El id del usuario es requerido");

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
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", newCategory);
                }
                catch(NameIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(DescriptionIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(ModelIsNullException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }

        public Response PutCategory(UpdateCategoryModel updateCategory,int categoryId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (updateCategory == null)
                        throw new ModelIsNullException("No se recibierón datos para actualizar categoría");

                    if (categoryId == 0)
                        throw new IdRequiredException("El id de la categoría es requerido");

                    if (string.IsNullOrEmpty(updateCategory.Name))
                        throw new NameIsRequiredException("El nombre es requerido");

                    if (string.IsNullOrEmpty(updateCategory.Description))
                        throw new DescriptionIsRequiredException("La descripción es requerido");

                    var findCategory = _uow.Repository.CategoryRepository.FindById(categoryId);
                    if (findCategory == null) 
                        throw new RecordNotFoundException($"No se encontro la categoría con el id {categoryId} para actualizar");

                    findCategory.Name = updateCategory.Name;
                    findCategory.Description = updateCategory.Description;

                    var updateItem = _uow.Repository.CategoryRepository.Update(findCategory);
                    transaction.Commit();

                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", updateItem);
                }
                catch (NameIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (DescriptionIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(RecordNotFoundException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(ModelIsNullException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }

        public Response DeleteCategory(int categoryId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (categoryId == 0)
                        throw new IdRequiredException("El id de la categoría es requerido");

                    var findCategory = _uow.Repository.CategoryRepository.FindById(categoryId);
                    if (findCategory == null) 
                        throw new RecordNotFoundException($"No encontro la categoría con el id {categoryId} para eliminar");

                    var categoryDeleted = _uow.Repository.CategoryRepository.Delete(findCategory);
                    if (categoryDeleted == null)
                        throw new RecordNotFoundException($"No encontro la categoría con el id {categoryId} para eliminar");

                    var findUserCategory = _uow.Repository.UserCategoryRepository.Find(categoryId);
                    if (findUserCategory == null)
                        throw new RecordNotFoundException($"No encontro la categoría con el id {categoryId} para eliminar");

                    var findUserCategoryDeleted = _uow.Repository.UserCategoryRepository.Delete(findUserCategory);
                    if (findUserCategoryDeleted == null)
                        throw new RecordNotFoundException($"No encontro la categoría con el id {categoryId} para eliminar");

                    transaction.Commit();
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", categoryDeleted);
                }
                catch (IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (RecordNotFoundException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }
    }
}
