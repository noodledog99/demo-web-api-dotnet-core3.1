using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Interfaces
{
    public interface IResumeService
    {
        Task InsertResumeInfo(ResumeInfo resume, int userId);
        Task InsertSkill(IEnumerable<Skill> skills, int userId);
        Task InsertEducation(IEnumerable<Education> educations, int userId);
        Task InsertExperience(IEnumerable<Experience> experiences, int userId);
        Task InsertEvidenceFile(IEnumerable<string> files, int userId);
        Task AddResume(Resume resume);
        string UploadImage(IFormFile imageFile);
        IEnumerable<string> UploadMultifile(IEnumerable<IFormFile> files, string userName);
    }
}
