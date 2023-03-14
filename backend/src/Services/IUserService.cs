namespace backend.src.Services;

using backend.src.DTOs;
using backend.src.Models;

public interface IUserservice
{
    Task<User?> SingnUpAsync(DTOUserSignUp request);
    Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request);
}