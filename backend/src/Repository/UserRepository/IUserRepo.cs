using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using Microsoft.AspNetCore.Identity;

namespace backend.src.Repository;

public interface IUserRepo
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> UpdateOneAsync(Guid id, User update);
    Task<bool> DeleteOneAsync(Guid id);
    //Task<IEnumerable<User>?> GetAllAsync();
    Task<User?> SingnUpAsync(DTOUserSignUp user, string password);
    Task<bool> SingnInAsync(User request, string password);
    // Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request);
    Task<User> IsUserEmail(string email);
    //Task<User?> GetPasswordHash(string Email);
}