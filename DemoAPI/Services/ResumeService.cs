using DemoAPI.Data;
using DemoAPI.Interfaces;
using DemoAPI.Models;
using DemoAPI.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResumeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddResume(Resume resume)
        {
            resume.resumeInfo.ImagePath = UploadImage(resume.resumeInfo.imageFile);
            var filePaths = UploadMultifile(resume.files, resume.resumeInfo.FirstName);

            await InsertResumeInfo(resume.resumeInfo, resume.UserId);

            await InsertSkill(resume.skills, resume.UserId);
            await InsertEducation(resume.educations, resume.UserId);
            await InsertExperience(resume.experiences, resume.UserId);

            await InsertEvidenceFile(filePaths, resume.UserId);
        }

        public async Task InsertEducation(IEnumerable<Education> educations, int userId)
        {
            if (educations.Any())
            {
                var educationList = new List<Entities.Education>();
                foreach (var item in educations)
                {
                    educationList.Add(new Entities.Education
                    {
                        MonthYear = item.MonthYear,
                        DegreeTitle = item.DegreeTitle,
                        School = item.School,
                        Description = item.Description,
                        UserId = userId,
                        Created_at = DateTime.Now
                    });
                }
                await _unitOfWork.EducationRepository.AddMany(educationList);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task InsertEvidenceFile(IEnumerable<string> files, int userId)
        {
            if (files.Any())
            {
                var fileList = new List<Entities.DocumentFile>();
                foreach (var item in files)
                {
                    fileList.Add(new Entities.DocumentFile
                    {
                        DocumentPath = item,
                        UserId = userId,
                        Created_at = DateTime.Now
                    });
                }
                await _unitOfWork.DocumentFileRepository.AddMany(fileList);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task InsertExperience(IEnumerable<Experience> experiences, int userId)
        {
            if (experiences.Any())
            {
                var expreienceList = new List<Entities.Experience>();
                foreach (var item in experiences)
                {
                    expreienceList.Add(new Entities.Experience
                    {
                        DateFrom = item.DateFrom,
                        DateTo = item.DateTo,
                        JobTitle = item.JobTitle,
                        Company = item.Company,
                        Description = item.Description,
                        UserId = userId,
                        Created_at = DateTime.Now
                    });
                }
                await _unitOfWork.ExperienceRepository.AddMany(expreienceList);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task InsertSkill(IEnumerable<Skill> skills, int userId)
        {
            if (skills.Any())
            {
                var skillList = new List<Entities.Skill>();
                foreach (var item in skills)
                {
                    skillList.Add(new Entities.Skill
                    {
                        SkillName = item.SkillName,
                        UserId = userId,
                        Created_at = DateTime.Now
                    });
                }
                await _unitOfWork.SkillRepository.AddMany(skillList);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task InsertResumeInfo(ResumeInfo resume, int userId)
        {
            if (resume != null)
            {
                var resumeInfoDto = resume.Adapt<Entities.ResumeInfo>();
                resumeInfoDto.UserId = userId;
                resumeInfoDto.Created_at = DateTime.Now;

                await _unitOfWork.ResumeInfo.Add(resumeInfoDto);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public string UploadImage(IFormFile imageFile)
        {
            var filePath = string.Empty;
            

            if (imageFile != null)
            {
                var fileType = imageFile.FileName.Split('.')[1];
                string uploadsFolder = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Images");
                var uniqueFileName = $"{DateTime.Now.ToFileTime().ToString()}.{fileType}";
                filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

            }
            return filePath;
        }

        public IEnumerable<string> UploadMultifile(IEnumerable<IFormFile> files, string name)
        {
            var filePaths = new List<string>();
            if (files.Any())
            {
                var uploadsFolder = Path.Combine($"{System.IO.Directory.GetCurrentDirectory()}\\Files", $"{name}");
                bool exists = System.IO.Directory.Exists(uploadsFolder);

                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(uploadsFolder);
                }

                files.ToList().ForEach(file =>
                {
                    var filePath = Path.Combine(uploadsFolder, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    filePaths.Add(filePath);
                });
            }

            return filePaths;
        }
    }
}
