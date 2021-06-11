using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class ResumeInfo
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
        public IFormFile? imageFile { get; set; }
    }
}
