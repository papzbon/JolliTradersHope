using JolliTradersHope.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JolliTradersHope.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetApplicationDetails()
        {
            //var appDetails = new ApplicationDetails("Login Flow with JWT", "1.0", DateTime.Now);
            //return Ok(ApiResponse<ApplicationDetails>.Success(appDetails));
            return Ok();
        }
    }
}
