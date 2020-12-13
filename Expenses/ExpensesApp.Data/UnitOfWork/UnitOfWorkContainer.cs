using Expenses.Data.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Expenses.Data.UnitOfWork
{
    public class UnitOfWorkContainer
    {
        private readonly EntityContext _context;
        public UnitOfWorkRepository Repository { get; }

        public UnitOfWorkContainer(EntityContext context)
        {
            _context = context;
            Repository = new UnitOfWorkRepository(_context);
        }

        #region Detect Changes
        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }
        #endregion

        #region Save Changes
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Transactions
        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        #endregion
    }
}
