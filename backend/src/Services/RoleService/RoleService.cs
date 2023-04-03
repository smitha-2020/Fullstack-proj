using Microsoft.AspNetCore.Identity;
using backend.src.Repository.RoleRepository;
using backend.src.Helpers;

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
        if (names.Count() < 0)
        {
            throw ServiceException.BadRequest("There should be atleast 1 role in the array");
        }
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
        ICollection<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();
        var count = 0;
        var user = await _repo.FindByIdAsync(id);
        if (user is null)
        {
            throw ServiceException.NotFound("Not a Valid User");
        }
        foreach (var role in role_names)
        {
            var validRole = await _repo.FindByNameAsync(role);
            if (validRole is null)
            {
                count++;
            }
            else
            {
                roles.Add(validRole);
            }
        }
        if (count == roles.Count)
        {
            throw ServiceException.BadRequest("Roles cannot be assigned to the user since it is an InValid");
        }
        if (user is null || roles is null)
        {
            throw ServiceException.BadRequest("Either UserId or RoleName field is empty");
        }
        else
        {
            return await _repo.AssignRoleToUserAsync(user, roles.Select(e => e.Name).ToArray());
        }
    }

    public async Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync()
    {
        return await _repo.GetAllRolesAsync();
    }
}