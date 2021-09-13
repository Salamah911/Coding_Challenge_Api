using Microsoft.AspNetCore.Mvc;

namespace Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodingChallengeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Coding Challenge!");
        }
    }
}
