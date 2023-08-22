using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JolliTradersHope.Shared.Models;
using JolliTradersHope.Shared.Dtos;

namespace JolliTradersHope.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            //Get users from database
            var users = new UserDto[]
            {
                new (Guid.NewGuid(), "Papie", true),
                new (Guid.NewGuid(), "Bon", true),
                new (Guid.NewGuid(), "Jovie", true),
                new (Guid.NewGuid(), "Rawr", true)
            };
            //return Ok(ApiResponse<UserDto[]>.Success(users));
            return Ok(users);
        }
    }
}
