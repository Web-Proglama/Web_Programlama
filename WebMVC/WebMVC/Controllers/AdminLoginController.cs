using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebMVC.Controllers
{
	[AllowAnonymous]
	public class AdminLoginController : Controller
	{
		[Route("Admin")]
		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}
		[Route("Admin")]
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
						new Claim(ClaimTypes.Name,values.UserName),
						new Claim(ClaimTypes.Role,values.RoleName),
						new Claim(ClaimTypes.NameIdentifier,values.UserID.ToString())
						

					};
					var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var authProperties = new AuthenticationProperties();
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

					return RedirectToAction("Index", "adminblog");
				}
			}
			return View();
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "adminLogin");
		}
	}
}
