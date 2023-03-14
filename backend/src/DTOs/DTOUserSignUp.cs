using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOUserSignUp
{
    [MaxLength(10)]
    public string FirstName { get; set; } = null!;

    [MaxLength(10)]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    //password and confirm password needs to be validated
    public string Password { get; set; } = null!;
    public string? ConfirmPassword { get; set; } = null!;
}

