using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T :BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> models);
        bool Remove(T entity);
        Task<bool> Remove(string id);
        bool RemoveRange(List<T> entities);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
