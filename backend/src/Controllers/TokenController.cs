using backend.src.Controllers;
using backend.src.DTOs;
using backend.src.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class TokenController : ApiController
{
    private readonly ITokenService _service;
    public TokenController(ITokenService service)
    {
        _service = service;
    }

    //[AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult?> GetTokenClaims([FromHeader] DTOToken jwttoken)
    {
       
        var jwtTokenString=(jwttoken.Authorization.Length>0)?jwttoken.Authorization.Split(' ')[1]:null;
         Console.WriteLine("rtertertertretertereteter",jwtTokenString);
        if(jwtTokenString is null){
            return null;
        }
        return Ok(await _service.GetTokenInfo(jwtTokenString));
    }
}