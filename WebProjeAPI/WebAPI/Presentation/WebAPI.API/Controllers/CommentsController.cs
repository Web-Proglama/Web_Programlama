using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Dtos;
using WebAPI.Application.Services;
using WebAPI.Persistence.ServicesConcrete;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddComment(AddCommentDto addCommentDto)
        {
            var result = await _commentService.addCommentAsync(addCommentDto);
            if (result.Success)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetCommentByBlogIdWithUser([FromRoute]string id)
        {
           var result= _commentService.GetCommentsByBlogId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
