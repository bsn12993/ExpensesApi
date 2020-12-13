using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Data.EntityModel
{
    public class Auditory
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
