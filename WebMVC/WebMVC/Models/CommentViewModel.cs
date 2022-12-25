using System.Reflection.Metadata;

namespace WebMVC.Models
{
    public class CommentViewModel
    {

        public string Content { get; set; }
        public Guid BlogId { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
    }
}
