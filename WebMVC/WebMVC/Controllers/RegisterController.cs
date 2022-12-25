using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel user)
        {
            if(!ModelState.IsValid)
            {
                 return View(user);
            }
            
            var extencion = Path.GetExtension(user.ImageURL.FileName);
            var newImageName = Guid.NewGuid() + extencion;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/web/Images/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            user.ImageURL.CopyTo(stream);
            var addUser = new AddUserViewModel();
            addUser.ImageURL = "/web/Images/"+newImageName;
            addUser.UserName = user.UserName;
            addUser.FirstName = user.FirstName;
            addUser.LastName = user.LastName;
            addUser.Password = user.Password;


			var httpclient = new HttpClient();
			var json = JsonConvert.SerializeObject(addUser);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpclient.PostAsync("https://localhost:7018/api/Users/CreateUser", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("index","Login",new LoginUserViewModel() { Password=user.Password,UserName=user.Password});
			}
          
			ViewBag.userName = "Kayit yapilamadi "+ addUser.UserName+" Kullanıcı adında biri olabilir";
            return View(user);


		
           
        }
    }
}
