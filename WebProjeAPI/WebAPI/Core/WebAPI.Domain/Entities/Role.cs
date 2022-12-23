using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Domain.Entities
{
    public class Role :BaseEntity
    {
        public Role()
        {
            Users=new HashSet<User>();
        }
        public string  RoleName { get; set; }
        public ICollection<User> Users { get; set; }


    }
}
