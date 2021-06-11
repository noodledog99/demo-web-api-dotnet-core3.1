using DemoAPI.Entities;
using DemoAPI.Interfaces;
using DemoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _unitOfWork.UserRepository.GetById(userId);
        }

        public async Task InsertUser(User user)
        {
            user.Created_at = DateTime.Now;
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
