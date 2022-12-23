using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Domain.Entities
{
    public class Blog:BaseEntity
    {
        public Blog()
        {
            Categories= new HashSet<Category>();
            Comments= new HashSet<Comment>();
        }
        public string  ImageURL { get; set; }
        public string Content { get; set; }
        public string  Title { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool Status { get; set; }
    }
}
