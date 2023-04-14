using Microsoft.AspNetCore.Mvc;
using backend.src.DTOs;
using backend.src.Services;
using backend.src.ModelValidation;
using Microsoft.AspNetCore.Authorization;
using backend.src.DTOs.DTORequest;

namespace backend.src.Controllers;

[Authorize(Roles="Admin")]
public class UserController : ApiController
{
    private readonly IUserService _service;
    public UserController(IUserService service) => _service = service;

    [AllowAnonymous]
    [HttpPost("/signup")]
    public async Task<IActionResult?> SingnUp([FromBody] DTOUserSignUp request)
    {
        return Ok(await _service.SingnUpAsync(request));
    }

    [AllowAnonymous]
    [HttpPost("/signin")]
    public async Task<IActionResult?> SignIn([FromBody] DTOUserSignIn request)
    {
        return Ok(await _service.SingnInAsync(request));
    }

    [AllowAnonymous]
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult?> GetByGuid(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
    
    [HttpPost("isavailable")]
    public async Task<IActionResult?> IsAvailable([FromBody] DTOEmail request)
    {
        var isAvailableEmail = await _service.IsEmailAvailable(request.Email.Trim());
        if (isAvailableEmail)
        {
            return Ok(new { isAvailable = true });
        }
        return Ok(new { isAvailable = false });
    }

    [HttpGet("{id}/userrole")]
    public async Task<IActionResult> GetUserRole(Guid id)
    {
        var roles = await _service.GetUserRole(id);
        if (roles is null)
        {
            return Ok(new { message = "No Role Associated with the User" });
        }
        return Ok(roles);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _service.Delete(id));
    }
}