using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;

namespace WebAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private IBlogService _blogService;

		public BlogsController(IBlogService blogService)
		{
			_blogService = blogService;
		}

		[HttpGet]
		[Route("[action]")]
		public IActionResult GetAllBlogs()
		{
			var result= _blogService.GetBlogList();
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return NotFound(result.Message);
			
		}
		[HttpGet]
		[Route("[action]/{id}")]
		public IActionResult GetBlogsByCategory([FromRoute]string id)
		{
			var resutl=_blogService.GetBlogByCategory(id);
			if (resutl.Success)
			{
				return Ok(resutl.Data);
			}
			return NotFound();
		}
		[HttpGet]
		[Route("[action]")]
		public IActionResult GetRecentBlogs() { 
			var result=_blogService.GetRecentBlogs();
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return NotFound();
		}

		[HttpGet]
		[Route("[action]/{id}")]
		public async Task<IActionResult> DeleteBlogById([FromRoute]string id)
		{
			var result=await _blogService.DeleteBlogByIdAsync(id);
			if(result.Success)
			{
				return Ok();
			}
			return NotFound();
		}
	}
}
