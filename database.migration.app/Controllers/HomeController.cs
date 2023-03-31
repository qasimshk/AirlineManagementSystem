using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace database.migration.app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("record")]
        [Consumes("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Record()
        {
            return Ok(new { 
                name = "Qasim"
            });
        }
    }
}
