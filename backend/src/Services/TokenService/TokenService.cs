namespace backend.src.Services.TokenService;

using backend.src.DTOs;
using backend.src.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using backend.src.Helpers;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    public TokenService(IConfiguration config, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _config = config;
        _userManager = userManager;
        _roleManager = roleManager;
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

        var roles = await _userManager.GetRolesAsync(user);

        claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

        // foreach (var role in roles)
        // {
        //     claims.Add(new Claim(ClaimTypes.Role, role));
        // }

        var secret = _config["jwt:Secret"];

        //Generate Secret
        var signkey = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256);

        var expiration_time = Double.TryParse(_config["jwt:Expiration"], out double a);
        //var expiration = DateTime.Now.AddHours(9);
        var expiration = DateTime.Now.AddHours(a);

        var token = new JwtSecurityToken(_config["jwt:Issuer"], _config["jwt:Aud"], claims, expires: expiration, signingCredentials: signkey);

        var tokenWriter = new JwtSecurityTokenHandler();

        return new DTOUserSignInResponse
        {
            AccessToken = tokenWriter.WriteToken(token),
            ExpirationTime = expiration,
        };
    }

    public async Task<Dictionary<string, string>?> GetTokenInfo(string token)
    {
        var TokenInfo = new Dictionary<string, string>();
        var handler = new JwtSecurityTokenHandler();
        if (token is null)
        {
            throw ServiceException.NotFound("Token is empty");
        }
        var jwtSecurityToken = await Task.Run(() => handler.ReadJwtToken(token));
        var claims = jwtSecurityToken.Claims.ToList();

        foreach (var claim in claims)
        {
            if (claim.Type.Contains("role"))
            {
                var arr = claim.Type.Split('/');
                TokenInfo.Add(claim.Type.Split('/')[arr.Length - 1], claim.Value);
            }
            else
            {
                TokenInfo.Add(claim.Type, claim.Value);
            }
        }
        return TokenInfo;
    }
}