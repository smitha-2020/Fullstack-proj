using Microsoft.AspNetCore.Identity;
using backend.src.Models;

namespace backend.src.Repository.RoleRepository;

public interface IRoleRepo
{
    Task<IEnumerable<IdentityRole<Guid>>> GetAllRolesAsync();
    Task<bool> AssignRoleToUserAsync(User user, IEnumerable<string> roles);
    Task<IdentityRole<Guid>?> FindByNameAsync(string name);
    Task<IdentityResult?> CreateRoleAsync(string name);
    Task<User?> FindByIdAsync(Guid id);
    Task<ICollection<IdentityRole<Guid>>?> GetRolesAsync(IEnumerable<string> roles);
}