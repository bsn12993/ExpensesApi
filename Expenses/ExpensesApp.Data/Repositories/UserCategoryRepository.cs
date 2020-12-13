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

        public UserCategory Create(UserCategory userCategory)
        {
            try
            {
                _context.UserCategories.Add(userCategory);
                _context.SaveChanges();
                return userCategory;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
