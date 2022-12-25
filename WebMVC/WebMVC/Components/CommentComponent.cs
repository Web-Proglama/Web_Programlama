using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Components
{
    public class CommentComponent:ViewComponent
    {
        public  async Task<IViewComponentResult> InvokeAsync(string id)
        {
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Comments/GetCommentByBlogIdWithUser/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<CommentComponentViewModel>>(jsonBlog);
				return View(values);
			}
			return View();
        }
    }
}
