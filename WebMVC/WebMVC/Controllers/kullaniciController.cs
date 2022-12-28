using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class kullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
