using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Domain.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Roles= new HashSet<Role>();
            Blogs= new HashSet<Blog>();
        
        }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string? ImageURL { get; set; }   
        public ICollection<Role> Roles { get; set; }
      
        public ICollection<Blog> Blogs { get; set; }



    }
}
