using Expenses.Data.Context;
using ExpensesApp.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.Repositories
{
    public class UserCategoryRepository : BaseRepository
    {
        public UserCategoryRepository(EntityContext context)
        {
            _context = context;
        }

        public UserCategory Find(int categoryId)
        {
            try
            {
                var findUserCategory = _context.UserCategories
                    .Where(x => x.CategoryId == categoryId && x.DeletedAt == null)
                    .SingleOrDefault();
                return findUserCategory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public UserCategory Create(UserCategory userCategory)
        {
            try
            {
                userCategory.CreatedAt = DateTime.Now;
                _context.UserCategories.Add(userCategory);
                _context.SaveChanges();
                return userCategory;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public UserCategory Delete(UserCategory userCategory)
        {
            try
            {
                userCategory.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                return userCategory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
