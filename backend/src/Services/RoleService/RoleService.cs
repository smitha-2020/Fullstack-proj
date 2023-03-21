using Microsoft.AspNetCore.Identity;
using backend.src.Models;
using backend.src.DTOs;
using backend.src.Repository.RoleRepository;

namespace backend.src.Services.RoleService;

public class RoleService : IRoleService
{
    private readonly IRoleRepo _repo;

    public RoleService(IRoleRepo repo)
    {
        _repo = repo;
    }

    //IdentityRole<Guid> is the table with Guid as id
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

    // public async Task<bool> AssignRoleToUserAsync(Guid id,ICollection<Guid> names)
    // {
    //     var user = await _repo.FindByIdAsync(id);
    //     foreach(var role in names){
    //          _roleManager.FindByNameAsync(role.RoleName);'

    // public async Task<bool> AssignRolesToUserAsync(string[] roles, User user)
    // {
    //     var result = await _userManager.AddToRolesAsync(user, roles);
    //     return result.Succeeded;
    // }
    //          await _repo.AssignRoleToUserAsync(user,role);
    //     }
    //     return await _repo.AssignRoleToUserAsync(user,names);
    // }

    public async Task<List<IdentityRole<Guid>>> GetRolesAsync()
    {
        return await _repo.GetRolesAsync();
    }

    // public async Task<bool> AssignRoleToUserAsync(DTORole role)
    // {
    //   //check if the user exists
    //   var user = await _userManager.FindByEmailAsync(role.Email);
    //   if (user is null)
    //   {
    //     return false;
    //   }
    //   //check if the role exists
    //   var userRole = _roleManager.FindByNameAsync(role.RoleName);
    //   if (userRole is null)
    //   {
    //     return false;
    //   }
    //   //add role to user
    //   var assignedUser = await _userManager.AddToRoleAsync(user, role.RoleName);
    //   if (!assignedUser.Succeeded)
    //   {
    //     return false;
    //   }
    //   return true;
    // }

    // public async Task<bool> RemoveRolesAsync(ICollection<string> names)
    // {
    //   var count = names.Count();
    //   var i = 0;
    //   foreach (var name in names)
    //   {
    //     if (!(await _roleManager.FindByNameAsync(name) is null))
    //     {
    //       await _roleManager.DeleteAsync(new IdentityRole<Guid> { Name = name });
    //     }
    //   }
    //   if (i == 0)
    //   {
    //     return false;
    //   }
    //   return true;
    // }

    // public Task<bool> UnAssignRoleToUserAsync()
    // {
    //   throw new NotImplementedException();
    // }
}