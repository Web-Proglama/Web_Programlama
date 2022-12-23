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
    public class BlogReadRepository : ReadRepository<Blog>, IBlogReadRepository
    {
        public BlogReadRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}
