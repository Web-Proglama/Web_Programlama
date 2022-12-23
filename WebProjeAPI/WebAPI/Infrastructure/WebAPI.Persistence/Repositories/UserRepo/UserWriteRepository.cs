using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Repositories.UserRepo;
using WebAPI.Domain.Entities;
using WebAPI.Persistence.Contexts;

namespace WebAPI.Persistence.Repositories.UserRepo
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}
