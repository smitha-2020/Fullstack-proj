using Microsoft.AspNetCore.Mvc;
using backend.src.DTOs;
using backend.src.Services;
using backend.src.ModelValidation;
using Microsoft.AspNetCore.Authorization;
using backend.src.DTOs.DTORequest;

namespace backend.src.Controllers;

[Authorize]
public class UserController : ApiController
{
    private readonly IUserService _service;
    public UserController(IUserService service) => _service = service;

    [AllowAnonymous]
    [HttpPost("/signup")]
    public async Task<IActionResult?> SingnUp([FromBody] DTOUserSignUp request)
    {
        var user = await _service.SingnUpAsync(request);
        if (user is null)
        {
            return BadRequest();
        }
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("/signin")]
    public async Task<IActionResult?> SignIn([FromBody] DTOUserSignIn request)
    {
        var response = await _service.SingnInAsync(request);
        if (response is null)
        {
            return Unauthorized();
        }
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult?> GetByGuid(Guid id)
    {
        var userData = await _service.GetByIdAsync(id);
        if (userData is null)
        {
            return BadRequest();
        }
        return Ok(userData);
    }

    [HttpGet("isavailable")]
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
    public async Task<bool> Delete(Guid id)
    {
        return await _service.Delete(id);
    }
}