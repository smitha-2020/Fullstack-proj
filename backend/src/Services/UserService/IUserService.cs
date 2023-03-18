using backend.src.DTOs;
using backend.src.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.src.Services;

public interface IUserService
{
    Task<DTOUserResponse?> SingnUpAsync(DTOUserSignUp request);
    Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request);
    Task<bool> IsEmailAvailable(string email);
}