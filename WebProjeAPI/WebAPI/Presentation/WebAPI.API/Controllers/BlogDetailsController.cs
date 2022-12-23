using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Dtos;
using WebAPI.Application.Services;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDetailsController : ControllerBase
    {
        private IBlogService _blogService;

        public BlogDetailsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetBlogById(string id)
        {
      
                var blog = await _blogService.GetBlogById(id);
            if (blog.Success)
            {
                return Ok(blog.Data);
            }
            return NotFound();
            
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> EditBlog(EditBlogGet eBlog)
        {

          var result= await _blogService.EditBlog(eBlog);
            if (result.Success)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
