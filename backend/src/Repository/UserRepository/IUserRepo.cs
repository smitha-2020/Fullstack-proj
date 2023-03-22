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
    Task<User?> SingnUpAsync(DTOUserSignUp user, string password);
    Task<bool> SingnInAsync(User request, string password);
    Task<User> IsUserEmail(string email);
}