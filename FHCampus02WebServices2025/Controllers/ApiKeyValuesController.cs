using FHCampus02WebServices2025.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FHCampus02WebServices2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ApiKeyValuesController : ControllerBase
    {
        [HttpGet("helloWorldSecure")]
        public IActionResult Get()
        {
            return Ok("You have access to this protected resource.");
        }
    }
}
