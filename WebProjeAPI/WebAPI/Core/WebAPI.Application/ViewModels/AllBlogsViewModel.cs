using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.ViewModels
{
	public class AllBlogsViewModel
	{
		public Guid BlogId { get; set; }
		public string ImageURL { get; set; }
		//public string UserFirstName { get; set; }
		//public string UserLastName { get; set; }
		public string Title { get; set; }
		public DateTime CratedDate { get; set; }
		public string Content { get; set; }
		public bool Status { get; set; }

	}
}
