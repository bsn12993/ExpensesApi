using System;

namespace ExpensesApp.Data.Models
{
    public class IncomeModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }
    }
}
