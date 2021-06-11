using DemoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task AddMany(IEnumerable<T> entities);
        void Update(T entity);
        Task Delete(int id);
    }
}
