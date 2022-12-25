
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class AddBlogViewModel
    {
        [Required(ErrorMessage ="bos gecilemez")]
        public string  BlogTitle { get; set; }
        [Required(ErrorMessage = "bos gecilemez")]
        public string BlogContent { get; set; }
        [Required(ErrorMessage = "bos gecilemez")]
        public string  CategoryName { get; set; }
        [Required(ErrorMessage = "bos gecilemez")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "bos gecilemez")]
        public IFormFile  ImageURL { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg", ErrorMessage = "jpg ,jpeg olmali")]
        public string FileName => ImageURL?.FileName;
    }
}
