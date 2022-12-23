using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.ViewModels
{
	public class UserViewModel
	{
		public Guid UserID { get; set; }
		public string UserName { get; set; }
		public string  FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string  RoleName { get; set; }
	}
}
