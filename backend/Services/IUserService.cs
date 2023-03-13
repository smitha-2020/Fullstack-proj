namespace backend.Services;

using backend.DTOs;
using backend.Models;

public interface IUserservice
{
    Task<User?> SingnUpAsync(DTOUserSignUp request);
    Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request);
}