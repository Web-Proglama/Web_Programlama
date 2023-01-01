using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class LoginUserViewModel
    {
       
        
        [Required(ErrorMessage = "Kullanıcı adi zorunlu")]
        [MinLength(5, ErrorMessage = "minimum 5 karakter olmalı")]
        [MaxLength(40, ErrorMessage = "40 karakterden fazla olamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="şifre zorunlu")]
		[MinLength(8, ErrorMessage = "minimum 8 karakter olmalı")]
		[MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
		public string Password { get; set; }
        public Guid UserID { get; set; }

        public string? RoleName { get; set; }
        public string? ImageURL { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


    }
}
