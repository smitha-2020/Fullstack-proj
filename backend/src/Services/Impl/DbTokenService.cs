namespace backend.src.Services;

using backend.src.DTOs;
using backend.src.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class DbTokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    public DbTokenService(IConfiguration config, UserManager<User> userManager)
    {
        _config = config;
        _userManager = userManager;

    }
    public DTOUserSignInResponse GetTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(JwtRegisteredClaimNames.Name,user.FirstName)
        };
        var secret = _config["jwt:Secret"];

        //Generate Secret
        var signkey = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256);

        var expiration_time = Double.TryParse(_config["jwt:Expiration"], out double a);
        var expiration = DateTime.Now.AddHours(1);

        var token = new JwtSecurityToken(_config["jwt:Issuer"], _config["jwt:Aud"], claims, expires: expiration, signingCredentials: signkey);

        var tokenWriter = new JwtSecurityTokenHandler();

        var result = new DTOUserSignInResponse
        {
            AccessToken = tokenWriter.WriteToken(token),
            ExpirationTime = expiration,
        };
        return result;
    }
}