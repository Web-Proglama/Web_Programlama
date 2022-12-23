using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Dtos
{
    public class AddCommentDto
    {
        public string Content { get; set; }
        public Guid BlogId { get; set; }
        public string UserName { get; set; }
    }
}
