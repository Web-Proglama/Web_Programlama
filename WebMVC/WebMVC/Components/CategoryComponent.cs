using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Components
{
    public class CategoryComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Categories/GetAllCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CategoryViewModel>>(jsonBlog);
                int count = 0;
                foreach (var item in values)
                {
                    count += item.BlogCount;
                }
                ViewBag.count = count;
                return View(values);
            }
            return View();
        }
    }
}
