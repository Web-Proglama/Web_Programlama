using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
	public class AddUserViewModel
	{

		public string FirstName { get; set; }
		
		public string LastName { get; set; }
	
		public string UserName { get; set; }
	
		public string Password { get; set; }

		public string ImageURL { get; set; }
	}
}
