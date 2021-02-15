using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.Interfaces.Base
{
    public interface IListRepository<T>
    {
        IList<T> List();
    }
}
