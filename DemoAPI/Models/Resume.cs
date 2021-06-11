using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Resume
    {
        public int UserId { get; set; }
        public ResumeInfo resumeInfo { get; set; }
        public IEnumerable<Experience> experiences { get; set; }
        public IEnumerable<Education> educations { get; set; }
        public IEnumerable<Skill> skills { get; set; }
        public IEnumerable<IFormFile> files { get; set; }
    }
}
