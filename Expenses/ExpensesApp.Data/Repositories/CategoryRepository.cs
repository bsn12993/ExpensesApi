using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Data.EntityModel;
using ExpensesApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Data.Repositories
{
    public class CategoryRepository : BaseRepository
    {

        public CategoryRepository(EntityContext context)
        {
            _context = context;
        }

        public List<Category> FindAll()
        {
            try
            {
                var findCategories = _context.Categories
                    .Where(x => x.DeletedAt == null)
                    .ToList();
                return findCategories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category FindById(int categoryId)
        {
            try
            {
                var findCategory = _context.Categories
                    .Where(x => x.Id == categoryId && x.DeletedAt == null)
                    .SingleOrDefault();
                return findCategory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserCategory> FindAll(int userId)
        {
            try
            {
                var findUserCategories = _context.UserCategories
                    .Include("User")
                    .Include("Category")
                    .Where(x => x.User.Id == userId && x.DeletedAt == null)
                    .ToList();

                return findUserCategories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category Create(Category category)
        {
            try
            {
                category.CreatedAt = DateTime.Now;
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category Update(Category category)
        {
            try
            {
                category.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return category;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Category Delete(Category category)
        {
            try
            {
                category.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                return category;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
