using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Services;

namespace WebAPI.Persistence.ServicesConcrete
{
private IRoleService _role;
    public class RoleService:IRoleService
    {
        public RoleService(IRoleService role){
            _role=role;
        }
    }
    
}
