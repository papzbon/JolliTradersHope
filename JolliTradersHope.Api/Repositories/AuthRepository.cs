using JolliTradersHope.Shared.Dtos;
using JolliTradersHope.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JolliTradersHope.Api.Repositories
{
    public interface IAuthRepository
    {
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto, CancellationToken cancellationToken = default);
    }

    //public sealed class AuthRepository : IAuthRepository
    //{
    //private readonly ITokenRepository _tokenRepository;

    //public AuthRepository(ITokenRepository tokenRepository)
    //{
    //    _tokenRepository = tokenRepository;
    //}

    //public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto, CancellationToken cancellationToken)
    //{
    //    // Inject UserRepo
    //    // Get the user Info from database
    //    // Validate Password

    //    var user = new LoggedInUser(Guid.NewGuid(), "Bon Jovie Belonghilot", "Admin", "Papiebon");

    //    var jwt = _tokenRepository.GenerateJWT(user);
    //    var authResponse = new AuthResponseDto
    //    {
    //        UserId = user.Id,
    //        Username = user.Username,
    //        Name = user.Name,
    //        Role = user.Role,
    //        Token = "tokenenene",
    //    };
    //    return ApiResponse<AuthResponseDto>.Success(authResponse);
    //}
    //}
}
