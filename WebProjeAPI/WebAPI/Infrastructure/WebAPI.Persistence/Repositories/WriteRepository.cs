using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Repositories;
using WebAPI.Domain.Entities.Common;
using WebAPI.Persistence.Contexts;

namespace WebAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly WebApiDbContext _context;

        public WriteRepository(WebApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table =>_context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
     
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T entity)
        {
            if(entity == null) return false;
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> Remove(string id)
        {
            Guid.TryParse(id, out var entityId);
           
            T model = await Table.FirstOrDefaultAsync(data => data.Id == entityId);
            return Remove(model);
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
