using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebMVC.Extensions;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Authorize(Roles ="user,Admin")]
    public class BlogDetailController : Controller
    {
        [HttpGet]
     
        public async Task<IActionResult> Index(string id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/BlogDetails/GetBlogById/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BlogDetailModel>(jsonBlog);
                if(values!=null)
                    return View(values);
            }
            return NotFound();
            //burada redirectoaction yaparak blog sayfasina yonlendiririz
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> AddComment(AddComment comment)
		{
            var userName = User.Claims.GetUserName();
            comment.UserName = userName;
            var httpclient = new HttpClient();
            var json=JsonConvert.SerializeObject(comment);
            StringContent  content=new StringContent(json,Encoding.UTF8,"application/json");
            var response = await httpclient.PostAsync("https://localhost:7018/api/Comments/AddComment", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "BlogDetail", new {id=comment.BlogId.ToString()});
            }
            ViewBag.message = "yorum yapilamadi";
             return RedirectToAction("index", "BlogDetail", new { id = comment.BlogId.ToString() });
        }
	
	}
}
