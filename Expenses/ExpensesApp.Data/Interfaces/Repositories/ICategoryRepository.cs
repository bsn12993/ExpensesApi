using ExpensesApp.Data.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.Interfaces.Repositories
{
    public interface ICategoryRepository<T> : 
        IFindRepository<T>, 
        IListRepository<T>, 
        ICreateRepository<T>,
        IUpdateRepository<T>
    {
    }
}
