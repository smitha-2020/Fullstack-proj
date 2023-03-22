using Microsoft.AspNetCore.Identity;
using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.Repository.RoleRepository;

public class RoleRepo : IRoleRepo
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<User> _userManager;

    public RoleRepo(RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AssignRoleToUserAsync(User user, IEnumerable<string> roles)
    {
        var result = await _userManager.AddToRolesAsync(user, roles);
        return result.Succeeded;
    }

    public async Task<ICollection<IdentityRole<Guid>>?> GetRolesAsync(IEnumerable<string> request)
    {
        ICollection<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();
        foreach (var role in request)
        {
            roles.Add(await _roleManager.FindByNameAsync(role));
        }
        return roles;
    }

    public async Task<IdentityResult?> CreateRoleAsync(string name)
    {
        return await _roleManager.CreateAsync(new IdentityRole<Guid> { Name = name });
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }

    public async Task<IdentityRole<Guid>?> FindByNameAsync(string name)
    {
        return await _roleManager.FindByNameAsync(name);
    }

    public async Task<IEnumerable<IdentityRole<Guid>>> GetAllRolesAsync()
    {
        return await Task.Run(() => _roleManager.Roles.ToArray());
    }
}