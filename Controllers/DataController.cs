using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WindowsLoginSample.Controllers
{
    [Route("data")]
    [Authorize]
    public class DataController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return $"OK! ({DateTime.UtcNow}) -> {HttpContext.User?.Identity?.Name}";
        }
    }
}
