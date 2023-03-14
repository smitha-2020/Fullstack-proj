using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Services;
using backend.Mapper;

namespace backend.Controllers;

public class UserController : ApiController
{
    private readonly IUserservice _service;

    public UserController(IUserservice service) => _service = service;

    [HttpPost("/signup")]
    public async Task<IActionResult?> SingnUp([FromBody] DTOUserSignUp request)
    {
        var user = await _service.SingnUpAsync(request);
        if (user is null)
        {
            return BadRequest();
        }
        return Ok();
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
}