using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Education
    {
        public DateTime MonthYear { get; set; }
        public string DegreeTitle { get; set; }
        public string School { get; set; }
        public string Description { get; set; }
    }
}
