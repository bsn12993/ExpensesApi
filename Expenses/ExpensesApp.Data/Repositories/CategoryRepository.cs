using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Data.Repositories
{
    public class CategoryRepository
    {
        EntityContext EntityContext { get; set; }

        public CategoryRepository()
        {
            EntityContext = new EntityContext();
        }

        public List<Category> GetCategories()
        {
            try
            {
                var Categories = EntityContext.Categories.ToList();
                return Categories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category GetCategoryById(int idcategory)
        {
            try
            {
                var Category = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (Category != null)
                {
                    return Category;
                }
                else throw new Exception("No se recuperaron datos de categorías");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserCategory> GetCategoryByUser(int iduser)
        {
            try
            {
                var userCategories = EntityContext.UserCategories
                    .Include("User").Include("Category").Where(x => x.User.User_Id == iduser).ToList();
                //var Category = EntityContext.
                //    Categories.Include("User").Where(x => x.User.User_Id == iduser).SingleOrDefault();
                return userCategories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category InsertCategory(UserCategory userCategory)
        {          
            using (var transaction = EntityContext.Database.BeginTransaction())
            {
                try
                {
                    EntityContext.Categories.Add(userCategory.Category);
                    EntityContext.SaveChanges();
                    userCategory.Category_Id = userCategory.Category.Category_Id;

                    EntityContext.UserCategories.Add(userCategory);
                    EntityContext.SaveChanges();

                    transaction.Commit();
                    return userCategory.Category;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
           
        


        public Category UpdateCategory(Category category, int idcategory)
        {
            try
            {
                var categoryTarget = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (categoryTarget != null)
                {
                    categoryTarget.Description = category.Description;
                    categoryTarget.Name = category.Name;
                    categoryTarget.Status = category.Status;
                    EntityContext.SaveChanges();

                    return categoryTarget;
                }
                else throw new Exception("No se encontraron datos disponibles");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Category DeleteCategory(int idcategory)
        {
            try
            {
                var category = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (category != null)
                {
                    EntityContext.Categories.Remove(category);
                    EntityContext.SaveChanges();

                    return category;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Category DeleteUserCategory(int idcategory, int iduser)
        {
            try
            {
                var userCategory = EntityContext.UserCategories
                    .Include("Category")
                    .Where(x => x.Category_Id == idcategory && x.User_Id == iduser)
                    .SingleOrDefault();
                if (userCategory != null)
                {
                    EntityContext.UserCategories.Remove(userCategory);
                    EntityContext.Categories.Remove(userCategory.Category);
                    EntityContext.SaveChanges();

                    return userCategory.Category;
                }
                else
                    throw new Exception("No se encontro disponible el registro");
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
