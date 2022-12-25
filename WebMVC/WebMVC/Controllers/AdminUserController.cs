using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
	public class AdminUserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
