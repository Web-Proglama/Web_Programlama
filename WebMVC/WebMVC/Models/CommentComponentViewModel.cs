using System.Reflection.Metadata;

namespace WebMVC.Models
{
	public class CommentComponentViewModel
	{
		public string Content { get; set; }
		public Guid BlogId { get; set; }
		public Guid UserId { get; set; }
		public string ImageURL { get; set; }
		public string  UserName { get; set; }
		public string FirstName { get; set; }
		public string  LastName { get; set; }

	}
}
