using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Components
{
    public class RecentPostComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Blogs/GetRecentBlogs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AllBlogViewModel>>(jsonBlog);
                return View(values);
            }
            //burada component bulunamiyor sayfasi olacak
            return View();
        }
    }
}
