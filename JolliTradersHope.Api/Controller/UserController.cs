using JolliTradersHope.Api.Data;
using JolliTradersHope.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JolliTradersHope.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JolliDbContext _context;

        public UserController(JolliDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser() => Ok(await _context.Users.ToListAsync());

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User users)
        {
            if (users != null)
            {
                var result = _context.Users.Add(users).Entity;
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            return BadRequest("Invalid Request");
        }

        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> LoginUser(string email, string password)
        {
            if (email is null || password is null)
            {
                User user = await _context.Users
                    .Where(x => x.Email!.ToLower().Equals(email.ToLower()) && x.Password == password)
                    .FirstOrDefaultAsync();

                return user != null ? Ok(user) : NotFound("User not found");
            }
            return BadRequest("Invalid Request");
        }

    }
}
