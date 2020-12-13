using Expenses.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.Repositories
{
    public class BaseRepository
    {
        protected EntityContext _context { get; set; }
    }
}
