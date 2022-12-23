using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Repositories;
using WebAPI.Application.Repositories.RoleRepo;
using WebAPI.Domain.Entities;
using WebAPI.Persistence.Contexts;

namespace WebAPI.Persistence.Repositories.RoleRepo
{
    public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}
