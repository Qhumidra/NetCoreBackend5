using Blog.Net.Entities.Concrete;
using Blog.Net.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Net.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _postServices.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetbyTitle")]
        public IActionResult GetByTitle(string title)
        {
            var result = _postServices.GetByTitle(title);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpPost("Add")]
        public IActionResult Add(Post post)
        {
            var result = _postServices.Add(post);

            if (!result.Success)
                return BadRequest();
            return Ok(result.Message);
        }
    }
}
