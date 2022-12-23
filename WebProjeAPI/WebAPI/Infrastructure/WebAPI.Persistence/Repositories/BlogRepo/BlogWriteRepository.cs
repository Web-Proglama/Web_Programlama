using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Repositories.BlogRepo;
using WebAPI.Domain.Entities;
using WebAPI.Persistence.Contexts;

namespace WebAPI.Persistence.Repositories.BlogRepo
{
    public class BlogWriteRepository : WriteRepository<Blog>, IBlogWriteRepository
    {
        public BlogWriteRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}
