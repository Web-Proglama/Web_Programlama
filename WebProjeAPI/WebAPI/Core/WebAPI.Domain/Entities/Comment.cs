using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Domain.Entities
{
    public class Comment:BaseEntity
    {
        
        public string Content { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
    }
}
