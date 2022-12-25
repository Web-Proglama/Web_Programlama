using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = " ad gerekli Gerekli")]
		[MinLength(3, ErrorMessage = " ad 3 karakterden kucuk olamaz")]
		[MaxLength(40, ErrorMessage = " ad 40 karakterden uzun olamaz")]
		public string  FirstName { get; set; }
		[Required(ErrorMessage = " soyad gerekli Gerekli")]
		[MinLength(3, ErrorMessage = "soyad 3 karakterden kucuk olamaz")]
		[MaxLength(40, ErrorMessage = "soyad 40 karakterden uzun olamaz")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "kullanıcı adı gerekli Gerekli")]
		[MinLength(5, ErrorMessage = "kullanıcı adı 5 karakterden kucuk olamaz")]
		[MaxLength(40, ErrorMessage = "kullanıcı adı 40 karakterden uzun olamaz")]
		public string  UserName { get; set; }
		[Required(ErrorMessage ="Sifre Gerekli")]
		[MinLength(8,ErrorMessage ="sifre 8 karakterden kucuk olamaz")]
		[MaxLength(50,ErrorMessage ="sifre 50 karakterden uzun olamaz")]
		public string Password { get; set; }

		[Required(ErrorMessage ="resim seciniz")]
		public IFormFile ImageURL { get; set; }
		[FileExtensions(Extensions = "jpg,jpeg,png",ErrorMessage ="uzantı jpg,jpeg,png olmali")]
		public string FileName => ImageURL?.FileName;
	}
}
