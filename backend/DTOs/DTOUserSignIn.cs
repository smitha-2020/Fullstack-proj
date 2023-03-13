using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class DTOUserSignIn
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}