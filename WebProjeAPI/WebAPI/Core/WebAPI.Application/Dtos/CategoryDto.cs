using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string  CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
