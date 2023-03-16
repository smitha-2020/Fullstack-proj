using backend.src.DTOs;
using  backend.src.Models;

namespace project.services;

public interface ITokenService
{
    DTOUserSignInResponse GetTokenAsync(User user);
}