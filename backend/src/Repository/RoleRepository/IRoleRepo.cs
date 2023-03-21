using Microsoft.AspNetCore.Identity;
using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.Repository.RoleRepository;

public interface IRoleRepo
{
    Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names);
    Task<List<IdentityRole<Guid>>> GetRolesAsync();
    //Task<bool> RemoveRolesAsync(ICollection<string> names);
    //Task<bool> AssignRoleToUserAsync(User user,ICollection<Guid> names);
    Task<IdentityRole<Guid>?> FindByNameAsync(string name);
    Task<IdentityResult?> CreateRoleAsync(string name);
    Task<User?> FindByIdAsync(Guid id);
    // Task<bool> UnAssignRoleToUserAsync();
}