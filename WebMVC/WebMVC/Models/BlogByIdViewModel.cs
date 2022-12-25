namespace WebMVC.Models
{
	public class BlogByIdViewModel
	{
		public Guid BlogId { get; set; }
		public Guid UserId { get; set; }
		public string Title { get; set; }
		public string FullName { get; set; }
		public string Content { get; set; }
		public string ImageURL { get; set; }
		public bool Status { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
