using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Entities
{
    [Table("documents")]
    public class DocumentFile : BaseEntity
    {
        public string DocumentPath { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
