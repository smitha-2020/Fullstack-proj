using System.ComponentModel.DataAnnotations;
using backend.src.DTOs;

namespace backend.src.ModelValidation;

public class User_EnsurePasswordsMatch : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var userObj = validationContext.ObjectInstance as DTOUserSignUp;
        if (userObj is not null)
        {
            if (!userObj.CheckPasswordAndConfirmPasswordMatch())
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        return ValidationResult.Success;
    }

}