namespace WebMVC.Models
{
	public class AddComment
	{
		public string  UserName { get; set; }
		public string Content { get; set; }
		public Guid BlogId { get; set; }
	}
}
