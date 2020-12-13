using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.UnitOfWork;

namespace ExpensesApp.Data.Services
{
    public class BaseService
    {
        protected EntityContext _context { get; set; }
        protected Response _response { get; set; }
        protected UnitOfWorkContainer _uow { get; set; }
    }
}
