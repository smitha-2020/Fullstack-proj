using System.ComponentModel.DataAnnotations;

namespace backend.src.DTOs;

public class DTOUserSignIn
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}