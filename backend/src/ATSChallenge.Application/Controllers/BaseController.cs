using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ATSChallenge.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected ObjectResult StatusCode(HttpStatusCode statusCode, object value)
        {
            return StatusCode((int)statusCode, value);
        }
    }
}
