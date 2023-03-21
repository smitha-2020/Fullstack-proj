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

    // public Task<IdentityResult> AssignRoleToUserAsync(User user,string role)
    // {
    //      _userManager.AddToRoleAsync(user, role);
    // }

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

    public async Task<List<IdentityRole<Guid>>> GetRolesAsync()
    {
        return await Task.Run(()=> _roleManager.Roles.ToList());
    }
}