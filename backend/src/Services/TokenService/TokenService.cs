namespace backend.src.Services.TokenService;

using backend.src.DTOs;
using backend.src.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    public TokenService(IConfiguration config, UserManager<User> userManager)
    {
        _config = config;
        _userManager = userManager;

    }
    public async Task<DTOUserSignInResponse> GetTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email!),
            new Claim(JwtRegisteredClaimNames.Name,user.FirstName!)
        };

        var roles =await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        //var secret = user.PasswordHash;
        var secret = _config["jwt:Secret"];

        //Generate Secret
        var signkey = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256);

        //var expiration_time = Double.TryParse(_config["jwt:Expiration"], out double a);
        var expiration = DateTime.Now.AddHours(3);
        //var expiration = DateTime.Now.AddHours(a);

        var token = new JwtSecurityToken(_config["jwt:Issuer"], _config["jwt:Aud"], claims, expires: expiration, signingCredentials: signkey);

        var tokenWriter = new JwtSecurityTokenHandler();

        return new DTOUserSignInResponse
        {
            AccessToken = tokenWriter.WriteToken(token),
            ExpirationTime = expiration,
        };
    }
}