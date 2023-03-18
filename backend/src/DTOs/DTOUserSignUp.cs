using System.ComponentModel.DataAnnotations;
using backend.src.ModelValidation;

namespace backend.src.DTOs;

public class DTOUserSignUp
{
    [MaxLength(10)]
    public string FirstName { get; set; } = null!;

    [MaxLength(10)]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    //Custom Validation
    //[User_EnsurePasswordsMatch(ErrorMessage ="Password and Confirm Password do not Match")]
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;

    public bool CheckPasswordAndConfirmPasswordMatch()
    {
        if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            if (Password != ConfirmPassword)
            {
                return false;
            }
            return true;
        }
        return false;
    }
}

