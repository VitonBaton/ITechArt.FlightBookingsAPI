using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ITechArt.FlightBookingsAPI.Domain.Constants;
using ITechArt.FlightBookingsAPI.Domain.Errors;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ITechArt.FlightBookingsAPI.Services.Services;

public class UsersService : IUsersService
{
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
            throw new ArgumentException(result.Errors.First().Description);
        }

        result = await _userManager.AddToRoleAsync(user, IdentityRoles.UserRole);
        if (!result.Succeeded)
        {
            throw new ArgumentException(result.Errors.First().Description);
        }
    }

    public async Task<string> Login(string username, string password, string securityKey, string issuer)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
        {
            throw new ArgumentException("Incorrect login/password");
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

    public async Task UpdateAccount(Guid userId, User userInfo)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (!string.IsNullOrEmpty(userInfo.Email))
        {
            user.Email = userInfo.Email;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new ArgumentException(result.Errors.First().Description);
            }
        }

        if (!string.IsNullOrEmpty(userInfo.PhoneNumber))
        {
            user.PhoneNumber = userInfo.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new ArgumentException(result.Errors.First().Description);
            }
        }
    }

    public async Task DeleteAccount(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new ServerErrorException("Error while deleting");
        }
    }
    
    public async Task<List<User>> GetAll()
    {
        return await _userManager.Users.ToListAsync();
    }
}