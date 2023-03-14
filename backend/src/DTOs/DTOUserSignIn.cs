using System.ComponentModel.DataAnnotations;

namespace backend.src.DTOs;

public class DTOUserSignIn
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}