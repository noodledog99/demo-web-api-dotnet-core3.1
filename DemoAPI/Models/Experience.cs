using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Experience
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
    }
}
