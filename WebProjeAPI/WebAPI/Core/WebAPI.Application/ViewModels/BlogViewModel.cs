using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.ViewModels
{
    public class BlogViewModel
    {

        public Guid BlogId { get; set; }
        public Guid  UserId { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
       // public List<Comment> Comments { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }   
    }
}
