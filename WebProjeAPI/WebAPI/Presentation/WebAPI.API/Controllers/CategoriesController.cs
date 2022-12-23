using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCategory()
        {
            var result = _categoryService.GetAllCategory();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
