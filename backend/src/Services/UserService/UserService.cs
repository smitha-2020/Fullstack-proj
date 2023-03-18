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
        return _service.GetTokenAsync(validUser);
    }

    public async Task<DTOUserResponse?> SingnUpAsync(DTOUserSignUp request)
    {
        //var user = _mapper.Map<DTOUserSignUp, DTOCreateUser>(request);
        if (request is null)
        {
            throw new ArgumentNullException("Null Value found");
        }
        var isUser = await IsEmailAvailable(request.Email);
        if (!isUser)
        {
             throw ExceptionHandler.IllegalArgumentException("Email Address Already");
        }
        var userIdentity = await _repo.SingnUpAsync(request, request.Password);
        if (userIdentity is null)
        {
            throw new ArgumentNullException("Null Value found");
        }
        return _mapper.Map<User,DTOUserResponse>(userIdentity);
        //return userIdentity;
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
}