using DemoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Interfaces
{
    public interface IUserService
    {
        Task InsertUser(User user);
        IEnumerable<User> GetAllUser();
        Task<User> GetUserById(int userId);
    }
}
