using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.EntityModel
{
    [Table("expenses")]
    public class Expense : Auditory
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("expense_date")]
        public DateTime ExpenseDate { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column("categoryId")]
        public Category Category { get; set; }
        [Column("userId")]
        public User User { get; set; }
    }
}
