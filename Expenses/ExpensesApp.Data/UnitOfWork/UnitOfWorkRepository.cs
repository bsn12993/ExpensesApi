using Expenses.Data.Context;
using Expenses.Data.Repositories;
using ExpensesApp.Data.Repositories;

namespace Expenses.Data.UnitOfWork
{
    public class UnitOfWorkRepository
    {
        public CategoryRepository CategoryRepository { get; }
        public ExpenseRepository ExpenseRepository { get; }
        public IncomeRepository IncomeRepository { get; }
        public UserRepository UserRepository { get; }
        public UserCategoryRepository UserCategoryRepository { get; }

        public UnitOfWorkRepository(EntityContext context)
        {
            CategoryRepository = new CategoryRepository(context);
            ExpenseRepository = new ExpenseRepository(context);
            IncomeRepository = new IncomeRepository(context);
            UserRepository = new UserRepository(context);
            UserCategoryRepository = new UserCategoryRepository(context);
        }
    }
}
