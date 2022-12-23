using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Domain.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Blogs= new HashSet<Blog>();
        }
        public string  CategoryName { get; set; }
        public ICollection<Blog> Blogs { get; set; }

    }
}
