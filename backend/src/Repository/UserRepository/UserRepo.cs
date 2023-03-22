using backend.src.DTOs;
using Microsoft.AspNetCore.Identity;
using backend.src.Models;
using AutoMapper;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository;

public class UserRepo : IUserRepo
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly IMapper _mapper;
    private readonly ILogger<UserRepo> _logger;

    public UserRepo(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IMapper mapper, ILogger<UserRepo> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> DeleteOneAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        var data = await _userManager.DeleteAsync(user);
        return data.Succeeded;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }

    public async Task<User> IsUserEmail(string email)
    {
        var validUser = await _userManager.FindByEmailAsync(email);
        return validUser;
    }

    public async Task<bool> SingnInAsync(User request, string password)
    {
        var checkPassword = await _userManager.CheckPasswordAsync(request, password);
        return checkPassword;
    }

    public async Task<User?> SingnUpAsync(DTOUserSignUp userdata, string password)
    {
        var userFull = await _userManager.FindByEmailAsync(userdata.Email);
         var user = new User
        {
            FirstName = userdata.FirstName.Trim(),
            LastName = userdata.LastName.Trim(),
            UserName = userdata.Email.Trim(),
            Email = userdata.Email.Trim()
        };
        var userData = await _userManager.CreateAsync(user, password);
        return await _userManager.FindByEmailAsync(userdata.Email);
    }

    public Task<User?> UpdateOneAsync(Guid id, User update)
    {
        throw new NotImplementedException();
    }
}