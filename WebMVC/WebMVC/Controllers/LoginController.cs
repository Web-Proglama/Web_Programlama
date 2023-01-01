using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebMVC.Models;

namespace WebMVC.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginUserViewModel user)
		{
			if (!ModelState.IsValid)
				return View(user);
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Users/GetUserByUserName/" + user.UserName);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<LoginUserViewModel>(jsonBlog);
				if (values == null)
				{
					return View(user);
				}
				if (values.Password == user.Password)
				{
					List<Claim> claims = new List<Claim>()
					{
						new Claim(ClaimTypes.Name,user.UserName),
						new Claim(ClaimTypes.Role,values.RoleName),
						new Claim(ClaimTypes.NameIdentifier,values.UserID.ToString()),
						new Claim("FirstName",values.FirstName)
					};
					var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var authProperties = new AuthenticationProperties();
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

					return RedirectToAction("Index", "Blog");
				}
			}
			return View(user);

		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "blog");
		}
	}
}
