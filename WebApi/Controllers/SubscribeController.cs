using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
