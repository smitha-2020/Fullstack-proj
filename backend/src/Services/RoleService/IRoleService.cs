using Microsoft.AspNetCore.Identity;
using backend.src.DTOs;

namespace backend.src.Services.RoleService;

public interface IRoleService
{
    Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names);
    Task<List<IdentityRole<Guid>>> GetRolesAsync();
    //Task<bool> RemoveRolesAsync(ICollection<string> names);
    //Task<bool> AssignRoleToUserAsync(Guid id,ICollection<Guid> names);
    
    // Task<bool> UnAssignRoleToUserAsync();
}