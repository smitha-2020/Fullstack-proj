using backend.src.DTOs;
using backend.src.Models;

namespace backend.src.Services;

public interface ITokenService
{
    DTOUserSignInResponse GetTokenAsync(User user);
}