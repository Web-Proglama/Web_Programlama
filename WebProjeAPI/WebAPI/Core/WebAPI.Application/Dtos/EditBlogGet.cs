using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Dtos
{
	public class EditBlogGet
	{
		
		public string Content { get; set; }
		public string Title { get; set; }
		public string BlogID { get; set; }

	
	}
}
