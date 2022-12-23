using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Repositories;
using WebAPI.Domain.Entities.Common;
using WebAPI.Persistence.Contexts;

namespace WebAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly WebApiDbContext _context;

        public ReadRepository(WebApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table =>_context.Set<T>();  

        public IQueryable<T> GetAll(bool tracking = true)
        {
           var table=Table.AsQueryable();
            if (!tracking)
            {
                table=table.AsNoTracking();
            }
            return table;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (!tracking)
            {
                table=table.AsNoTracking();
            }
            return await table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var table=Table.AsQueryable();
            if(!tracking)
            {
                table=table.AsNoTracking();

            }
            return await table.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
           var table=Table.Where(method);
            if (!tracking)
            {
                table=table.AsNoTracking();
            }
            return table;
        }
    }
}
