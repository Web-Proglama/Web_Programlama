using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Dtos
{
    public class AddBlogDto
    {
        public string Blogtitle { get; set; }
        public string  BlogContent { get; set; }
        public string CategoryName { get; set; }
        public Guid UserId { get; set; }
        public string  ImageURL { get; set; }
    }
}
