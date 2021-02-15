using Expenses.Data.EntityModel;
using ExpensesApp.Data.EntityModel;
using ExpensesApp.Data.Models;
using System.Data.Entity;

namespace Expenses.Data.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext()
            :base("Data Source=expenses.mssql.somee.com;Initial Catalog=expenses;User ID=expense_admin;Password=bsn123456")
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
       
    }
}
