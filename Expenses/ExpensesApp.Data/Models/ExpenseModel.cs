using System;

namespace ExpensesApp.Data.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
    }
}
