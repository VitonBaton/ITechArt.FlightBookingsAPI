using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ITechArt.FlightBookingsAPI.Domain.Errors;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ITechArt.FlightBookingsAPI.Services.Services;

public class UsersService : IUsersService
{
    private const string UserRole = "User";
    private const string AdminRole = "Admin";

    private readonly UserManager<User> _userManager;

    public UsersService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task Register(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.First().Description);
        }

        result = await _userManager.AddToRoleAsync(user, UserRole);
        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.First().Description);
        }
    }

    public async Task<string> Login(string username, string password, string securityKey, string issuer)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
        {
            throw new KeyNotFoundException("Incorrect login/password");
        }

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, username),
            new(ClaimTypes.Role, role ?? "")
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(1),
            claims: claims,
            issuer: issuer,
            audience: issuer,
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}