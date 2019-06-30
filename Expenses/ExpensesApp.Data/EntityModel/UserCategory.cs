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
    [Table("UserCategory")]
    public class UserCategory
    {
        [Key]
        [Column("idusercategory")]
        public int UserCategory_Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        [Column("iduser")]
        public User User { get; set; }

        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        [Column("idcategory")]
        public Category Category { get; set; }
    }
}
