using backend.DTOs;
using backend.Models;

namespace backend.Services;

public interface ITokenService
{
    DTOUserSignInResponse GetTokenAsync(User user);
}