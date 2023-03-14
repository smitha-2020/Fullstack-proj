using System.ComponentModel.DataAnnotations;
using backend.src.DTOs;
using Microsoft.AspNetCore.Identity;

namespace backend.src.Models;

public class User :IdentityUser<Guid>
{
    [MaxLength(30)]
    public string FirstName { get; set; } = null!;

    [MaxLength(30)]
    public string LastName { get; set; } = null!;
}

