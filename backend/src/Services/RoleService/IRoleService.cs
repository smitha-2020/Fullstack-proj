using Microsoft.AspNetCore.Identity;
using backend.src.DTOs.DTORequest;

namespace backend.src.Services.RoleService;

public interface IRoleService
{
    Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names);
    Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync();
    Task<bool> AssignRoleToUserAsync(Guid id, IEnumerable<string> roles);
}