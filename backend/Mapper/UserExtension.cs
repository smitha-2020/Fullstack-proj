using backend.src.DTOs;
using backend.src.Models;

namespace backend;

public static class UserExtension
{
  public static DTOUserResponse UserMapper(this User user)
  {
    return new DTOUserResponse
    {
      FirstName = user.FirstName,
      LastName = user.LastName,
      Username = user.Email,
      Email = user.Email
    };
  }
}