using backend.src.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.src.ModelValidation;

public class EnsureMandatoryFieldsActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        bool isValid = true;
        var user = context.ActionArguments["request"] as DTOUserSignUp;
        if (user != null && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.ConfirmPassword))
        {
            if(user.Password !=user.ConfirmPassword)
           
                context.ModelState.AddModelError("message", "Password and Confirm Password does not Match");
                isValid = false;
            
            // if (string.IsNullOrWhiteSpace(user.FirstName))
            // {
            //     context.ModelState.AddModelError("FirstName", "FirstName cannot be empty");
            //     isValid = false;
            // }
            // if (string.IsNullOrWhiteSpace(user.LastName))
            // {
            //     context.ModelState.AddModelError("LastName", "LastName cannot be empty");
            //     isValid = false;
            // }
            // if (string.IsNullOrWhiteSpace(user.Email))
            // {
            //     context.ModelState.AddModelError("Email", "Email cannot be empty");
            //     isValid = false;
            // }
            // if (string.IsNullOrWhiteSpace(user.Password))
            // {
            //     context.ModelState.AddModelError("Password", "Password cannot be empty");
            //     isValid = false;
            // }
            // if (string.IsNullOrWhiteSpace(user.ConfirmPassword))
            // {
            //     context.ModelState.AddModelError("ConfirmPassword", "ConfirmPassword cannot be empty");
            //     isValid = false;
            // }
        }
        if (!isValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}

