using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.EntityModel
{
    [Table("user_has_category")]
    public class UserCategory : Auditory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("userId")]
        public int UserId { get; set; }
        [Column("userId")]
        public User User { get; set; }

        [ForeignKey("Category")]
        [Column("categoryId")]
        public int CategoryId { get; set; }
        [Column("categoryId")]
        public Category Category { get; set; }
    }
}
