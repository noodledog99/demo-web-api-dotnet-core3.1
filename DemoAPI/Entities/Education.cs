using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Entities
{
    [Table("educations")]
    public class Education : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime MonthYear { get; set; }
        public string DegreeTitle { get; set; }
        public string School { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
