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
        var userFull = await _userManager.FindByIdAsync(id.ToString());
        var data = await _userManager.DeleteAsync(userFull);
        return data.Succeeded;
        //return _userManager.DeleteAsync(userFull);
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
        // var userRole = new User
        // {
        //     FirstName = userdata.FirstName,
        //     LastName = userdata.LastName,
        //     UserName = userdata.Email,
        //     Email = userdata.Email,
        //     SecurityStamp = userFull.SecurityStamp
        // };

         var user = new User
        {
            FirstName = userdata.FirstName,
            LastName = userdata.LastName,
            UserName = userdata.Email,
            Email = userdata.Email
        };

        //Adds the data to the user table
        //var data = _mapper.Map<DTOUserSignUp, User>(user);
        //TODO: Put all these into a separate controller/service for roles
        var roles = new[] { "Admin", "Dev" };
        foreach (var role in roles)
        {
            if (await _roleManager.FindByNameAsync(role) is null)
            {
                _logger.LogCritical("null");
                await _roleManager.CreateAsync(new IdentityRole<Guid>
                {
                    Name = role,
                });
            }
        }
        await _userManager.AddToRolesAsync(userFull, roles);

        //replace until this 
        var userData = await _userManager.CreateAsync(user, password);
        return await _userManager.FindByEmailAsync(userdata.Email);
        //return _mapper.Map<IdentityResult, User>(userData);
    }

    public Task<User?> UpdateOneAsync(Guid id, User update)
    {
        throw new NotImplementedException();
    }
}