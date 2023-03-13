using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using backend.Models;

namespace backend.Services;

public class DBUserService : IUserservice
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    //private readonly ITokenService _service;

    public DBUserService(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
       // _service = service;
    }
    
    public async Task<User?> SingnUpAsync(DTOUserSignUp request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email,
            Email = request.Email
        };
        var data = await _userManager.CreateAsync(user, request.Password);
        if (data.Succeeded)
        {
            return user;
        }
        return null;
    }

    public async Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return null;
        }
        var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!checkPassword)
        {
            return null;
        }
        return null;
       //return _service.GetTokenAsync(user);
    }
}