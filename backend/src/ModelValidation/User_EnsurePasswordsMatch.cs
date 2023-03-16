using System.ComponentModel.DataAnnotations;
using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.ModelValidation;

public class User_EnsurePasswordsMatch : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var userObj = validationContext.ObjectInstance as DTOUserSignUp;
        if (userObj != null && userObj.Password != null && userObj.ConfirmPassword != null)
        {
            if (userObj.Password != userObj.ConfirmPassword)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        return ValidationResult.Success;
    }

}