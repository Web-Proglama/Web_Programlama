using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Dtos;
using WebAPI.Application.Services;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IBlogService _blogService;


        public UsersController(IUserService userService,IBlogService blogService)
        {
            _blogService= blogService;
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser(CreateUser createUser) {
           var result=await _userService.CreateUser(createUser,"user");
            if(result.Success)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAdmin(CreateUser createUser)
        {
            var result = await _userService.CreateUser(createUser, "Admin");
            if (result.Success)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddBlog(AddBlogDto blogDto)
        {
            var deger =await _blogService.AddBlogAsync(blogDto);
            if(deger.Success) {
                return Ok(deger.Data);
            }
            return NotFound();

            //new()
            //{
            //    BlogContent = "herkese selamlar",
            //    Blogtitle = "selamlama",
            //    CategoryName = "selam",
            //    UserId = Guid.Parse("4c5ef7a1-8265-4e7b-9a28-7d34b437014d")
            //}
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteUser(DeleteUserDto deleteUser)
        {
            var result=  await _userService.DeleteUser(deleteUser);
            if(result.Success)
            return Ok();

            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetUserByUserName([FromRoute]string id)
        {
           var user= _userService.GetUserByUserName(id);
            if(user.Success)
            {
                return Ok(user.Data);
            }
            return NotFound();
        }
        
    }
}
