using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Components
{
    public class AdminCategoryComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7018/api/Categories/GetAllCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CategoryViewModel>>(jsonBlog);
     
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var item in values)
                {
                     items.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryName });
                }

                return View(items);
            }
            return View();
        }
    }
}
