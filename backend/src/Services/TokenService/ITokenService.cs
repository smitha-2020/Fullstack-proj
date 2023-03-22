using backend.src.DTOs;
using backend.src.Models;

namespace backend.src.Services.TokenService;

public interface ITokenService
{
    Task<DTOUserSignInResponse> GetTokenAsync(User user);
}