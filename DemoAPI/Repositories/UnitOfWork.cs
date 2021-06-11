using DemoAPI.Data;
using DemoAPI.Entities;
using DemoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataContext _context;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Skill> _skillRepository;
        private readonly IRepository<Education> _educationRepository;
        private readonly IRepository<Experience> _experienceRepository;
        private readonly IRepository<DocumentFile> _documentFileRepository;
        private readonly IRepository<ResumeInfo> _resumeInfoRepository;

        public UnitOfWork(ApplicationDataContext context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);
        public IRepository<Skill> SkillRepository => _skillRepository ?? new BaseRepository<Skill>(_context);
        public IRepository<Education> EducationRepository => _educationRepository ?? new BaseRepository<Education>(_context);
        public IRepository<Experience> ExperienceRepository => _experienceRepository ?? new BaseRepository<Experience>(_context);
        public IRepository<DocumentFile> DocumentFileRepository => _documentFileRepository ?? new BaseRepository<DocumentFile>(_context);
        public IRepository<ResumeInfo> ResumeInfo => _resumeInfoRepository ?? new BaseRepository<ResumeInfo>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
