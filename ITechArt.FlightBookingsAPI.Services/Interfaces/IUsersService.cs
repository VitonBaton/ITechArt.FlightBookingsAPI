using ITechArt.FlightBookingsAPI.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace ITechArt.FlightBookingsAPI.Services.Interfaces;

public interface IUsersService
{
    public Task Register(User user, string password);
    public Task<string> Login(string username, string password, string securityKey, string issuer);
    public Task UpdateAccount(Guid userId, User userInfo);
    public Task DeleteAccount(Guid userId);
    public Task<List<User>> GetAll();
}