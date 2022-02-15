using ITechArt.FlightBookingsAPI.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace ITechArt.FlightBookingsAPI.Services.Interfaces;

public interface IUsersService
{
    public Task Register(User user, string password);
    public Task<string> Login(string username, string password, string securityKey, string issuer);
}