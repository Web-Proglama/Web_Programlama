using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebMVC.Extensions;
using WebMVC.Models;
using X.PagedList;

namespace WebMVC.Controllers
{
	[Authorize(Roles ="Admin")]
	public class AdminBlogController : Controller
	{
		public async  Task<IActionResult> Index(int page=1)
		{
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Blogs/GetAllBlogs");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<AllBlogViewModel>>(jsonBlog);

				return View(values.ToPagedList(page, 9));
			}
			//buraya sayfa bulunamadiya gonder
			return View();
			//https://localhost:7018/api/Blogs/DeleteBlogById/
		}
		[HttpGet]
		public async Task<IActionResult> Delete(string id){
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Blogs/DeleteBlogById/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Adminblog");
			}
			//buraya sayfa bulunamadiya gonder
			return View();
		}

		[HttpGet]
        public async Task<IActionResult> BlogAdd()
        {

            return View();
        }

        public async Task<IActionResult> BlogAdd(AddBlogViewModel blog){
			Guid UserID = Guid.Empty;
			if (!ModelState.IsValid)
			{
				return View();
			}
            var id = User.Claims.GetUserID();
            UserID = Guid.Parse(id);
            var addblog = new AddBlogStringImgViewModel();
			addblog.BlogTitle = blog.BlogTitle.Trim();
			addblog.BlogContent = blog.BlogContent.Trim();
			addblog.UserID = UserID;
			addblog.CategoryName = blog.CategoryName.Trim();
			if(blog.ImageURL!= null)
			{
				var extencion = Path.GetExtension(blog.ImageURL.FileName);
				var newimageName = Guid.NewGuid() + extencion;
				var location =Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/web/Images/", newimageName);
				var stream =new FileStream(location,FileMode.Create);
				blog.ImageURL.CopyTo(stream);
				addblog.ImageURL = "/web/Images/"+newimageName;
			}


            var httpclient = new HttpClient();
            var json = JsonConvert.SerializeObject(addblog);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpclient.PostAsync("https://localhost:7018/api/Users/AddBlog", content);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("index", "adminblog");
            }
			//ekleme yapilamadi sayfasi
			ViewBag.messages = "Hata Blog eklenemedi";
            return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id){

		

				var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/BlogDetails/GetBlogById/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<BlogByIdViewModel>(jsonBlog);
				
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(BlogByIdViewModel blog)
		{
			

			var edittedBlog = new EditBlogModel();
			edittedBlog.Title = blog.Title;
			edittedBlog.content=blog.Content;
			edittedBlog.Blogid = blog.BlogId;
			var httpclient = new HttpClient();
			var json = JsonConvert.SerializeObject(edittedBlog);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpclient.PostAsync("https://localhost:7018/api/BlogDetails/EditBlog", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("index", "adminblog");
			}
			ViewBag.hata = "blog düzenlemedi";
			return View(blog);

		}

	}
}
