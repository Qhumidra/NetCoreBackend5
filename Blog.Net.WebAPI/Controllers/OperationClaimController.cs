using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Net.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : ControllerBase
    {
        IOperationClaimServices _operationClaimServices;
        public OperationClaimController(IOperationClaimServices operationClaimServices)
        {
            _operationClaimServices = operationClaimServices;
        }
        [HttpPost("Add")]
        public IActionResult Add(OperationClaim operationClaim)
        {
            var result = _operationClaimServices.Add(operationClaim);

            return Ok(result);
        }
    }
}
