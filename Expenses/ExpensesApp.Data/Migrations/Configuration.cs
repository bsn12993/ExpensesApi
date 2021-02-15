using System.Data.Entity.Migrations;

namespace ExpensesApp.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Expenses.Data.Context.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Expenses.Data.Context.EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

       
    }
}
