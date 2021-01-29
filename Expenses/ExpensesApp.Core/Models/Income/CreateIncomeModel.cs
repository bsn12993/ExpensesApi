using System;

namespace ExpensesApp.Core.Models.Income
{
    public class CreateIncomeModel
    {
        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }
        public int UserId { get; set; }
    }
}
