using backend.src.DTOs;
using backend.src.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Mapper;

public class UserMapper : BaseMapper
{
    public UserMapper()
    {
        CreateMap<DTOUserSignUp, DTOCreateUser>();
        CreateMap<DTOCreateUser, User>();
        CreateMap<IdentityResult, User>();
        CreateMap<DTOUserSignUp, User>();
        CreateMap<User, DTOUserResponse>();
    }
}
