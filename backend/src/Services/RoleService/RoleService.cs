using Microsoft.AspNetCore.Identity;
using backend.src.Repository.RoleRepository;

namespace backend.src.Services.RoleService;

public class RoleService : IRoleService
{
    private readonly IRoleRepo _repo;
    public RoleService(IRoleRepo repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names)
    {
        List<string> addedRoles = new List<string>();
        foreach (var name in names)
        {
            var result = await _repo.FindByNameAsync(name);
            if (result is null)
            {
                var role = await _repo.CreateRoleAsync(name);
                if (role is not null && role.Succeeded)
                {
                    addedRoles.Add(name);
                }
            }
        }
        return addedRoles;
    }

    public async Task<bool> AssignRoleToUserAsync(Guid id, IEnumerable<string> role_names)
    {
        var user = await _repo.FindByIdAsync(id);
        var roles = await _repo.GetRolesAsync(role_names);
        if (user is null || roles is null)
        {
            return false;
        }
        return await _repo.AssignRoleToUserAsync(user, roles.Select(e => e.Name).ToArray());
    }

    public async Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync()
    {
        return await _repo.GetAllRolesAsync();
    }
}