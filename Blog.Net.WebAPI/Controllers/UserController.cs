using Microsoft.AspNetCore.Mvc;

namespace Blog.Net.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        IActionResult GetAll()
        {
            return Ok();
        }
    }
}
