using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.ViewModels
{
	public class CommentWithImage
	{

		public string Content { get; set; }
		public Guid BlogId { get; set; }
		public Guid UserId { get; set; }
		public string ?ImageURL { get; set; }
		public string userName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

}
