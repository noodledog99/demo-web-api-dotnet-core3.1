using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Entities
{
    [Table("resumeInfos")]
    public class ResumeInfo : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LinkIn { get; set; }
        public string Twitter { get; set; }
        public string Blog { get; set; }
        public string Portfolio { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
