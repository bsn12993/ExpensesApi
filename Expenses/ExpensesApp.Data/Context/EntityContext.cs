using Expenses.Data.EntityModel;
using ExpensesApp.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext():base("Data Source=LAPTOP-CFVKV8OI;Initial Catalog=Expenses_DEV;User ID=sa;Password=123;")
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
       
    }
}
