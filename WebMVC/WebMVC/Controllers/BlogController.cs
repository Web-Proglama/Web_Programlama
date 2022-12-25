using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebMVC.Models;
using X.PagedList;

namespace WebMVC.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
		public async Task<IActionResult> Index(int page=1)
		{
			var httpClient=new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Blogs/GetAllBlogs");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonBlog=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<AllBlogViewModel>>(jsonBlog);
				
				return View(values.ToPagedList(page, 6));
			}
			//buraya sayfa bulunamadiya gonder
			return View();
		}

		public async Task<IActionResult> BlogByCategory(string id,int page=1)
		{
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Blogs/GetBlogsByCategory/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AllBlogViewModel>>(jsonBlog);
				ViewBag.id=id;
                return View("Index",values.ToPagedList(page, 6));
            }


            //burayi sayfa bulunamadiya gonder
            return View();
		}

    }
}
