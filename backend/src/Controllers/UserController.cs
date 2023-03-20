using Microsoft.AspNetCore.Mvc;
using backend.src.DTOs;
using backend.src.Services;
using backend.src.ModelValidation;

namespace backend.src.Controllers;

public class UserController : ApiController
{
    private readonly IUserService _service;

    public UserController(IUserService service) => _service = service;

    [HttpPost("/signup")]
    //[EnsureMandatoryFieldsActionFilter]
    public async Task<IActionResult?> SingnUp([FromBody] DTOUserSignUp request)
    {
        var user = await _service.SingnUpAsync(request);
        if (user is null)
        {
            return BadRequest();
        }
        return Ok(user);
        //return Ok(user.UserMapper());
    }

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
}