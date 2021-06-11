using DemoAPI.Entities;
using DemoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<ResumeInfo> ResumeInfo { get; }
        IRepository<Skill> SkillRepository { get; }
        IRepository<Education> EducationRepository { get; }
        IRepository<Experience> ExperienceRepository { get; }
        IRepository<DocumentFile> DocumentFileRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
