using JolliTradersHope.Api.Repositories;
using JolliTradersHope.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JolliTradersHope.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto, CancellationToken cancellationToken = default)
        {
            var response = await _authRepository.LoginAsync(dto, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
