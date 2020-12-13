using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Core.Models.Income
{
    public class UpdateIncomeModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }
    }
}
