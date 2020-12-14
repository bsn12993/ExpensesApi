using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.EntityModel
{
    [Table("incomes")]
    public class Income : Auditory
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("income_date")]
        public DateTime IncomeDate { get; set; }
        [Column("amount")]
        public decimal? Amount { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column("userId")]
        public User User { get; set; }
    }
}
