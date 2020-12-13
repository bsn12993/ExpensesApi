using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Core.Models.Income
{
    public class CreateIncomeModel
    {
        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }
    }
}
