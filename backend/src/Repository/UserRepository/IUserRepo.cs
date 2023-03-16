using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using Microsoft.AspNetCore.Identity;

namespace backend.src.Repository;

public interface IUserRepo
{
    Task<User?> SingnUpAsync(DTOUserSignUp user, string password);
    Task<bool> SingnInAsync(User request, string password);
    // Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request);
   
    Task<User> IsUserEmail(string email);
}