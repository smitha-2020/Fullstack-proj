using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repository;
using backend.src.Services.TokenService;
using backend.src.Helpers;

namespace backend.src.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _repo;
    private readonly ILogger<UserService> _logger;
    private readonly ITokenService _service;

    public UserService(IMapper mapper, IUserRepo repo, ILogger<UserService> logger, ITokenService service)
    {
        _mapper = mapper;
        _repo = repo;
        _logger = logger;
        _service = service;
    }

    public async Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request)
    {
        var validUser = await _repo.IsUserEmail(request.Email);
        if (validUser is null)
        {
            throw new ArgumentNullException("Not A valid email");
        }
        var userExists = await _repo.SingnInAsync(validUser, request.Password);
        if (!userExists)
        {
            throw new ArgumentNullException("InValid Password");
        }
        return await _service.GetTokenAsync(validUser);
    }

    public async Task<DTOUserResponse?> SingnUpAsync(DTOUserSignUp request)
    {
        if (request is null)
        {
            throw ServiceException.BadRequest("Please Fill All the Fields!!");
        }
        var isUser = await IsEmailAvailable(request.Email);
        if (!isUser)
        {
            throw ServiceException.BadRequest("Email Address Already Exists!!");
        }
        var userIdentity = await _repo.SingnUpAsync(request, request.Password);
        if (userIdentity is null)
        {
            throw ServiceException.BadRequest("Email Address With Password Does Not Match!!");
        }
        return _mapper.Map<User, DTOUserResponse>(userIdentity);
    }

    public async Task<bool> IsEmailAvailable(string email)
    {
        var isEmailAvailable = await _repo.IsUserEmail(email);
        if (isEmailAvailable is null)
        {
            return true;
        }
        return false;
    }

    public async Task<DTOUserResponse?> GetByIdAsync(Guid id)
    {
        var userData = await _repo.GetByIdAsync(id);
        if (userData is null)
        {
            return null;
        }
        return _mapper.Map<User, DTOUserResponse>(userData);
    }

    public async Task<bool> Delete(Guid id)
    {
        var userData = await _repo.DeleteOne(id);
        if (userData is null)
        {
            return false;
        }
        return true;
    }

    public async Task<ICollection<string>?> GetUserRole(Guid id)
    {
        var user = await _repo.GetByIdAsync(id);
        if(user is null){
            return null;
        }
        return await _repo.GetUserRole(user);
    }
}