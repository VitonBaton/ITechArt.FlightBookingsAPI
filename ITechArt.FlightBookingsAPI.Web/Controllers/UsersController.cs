using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using ITechArt.FlightBookingsAPI.Web.Models;
using ITechArt.FlightBookingsAPI.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ITechArt.FlightBookingsAPI.Web.Controllers;

public class UsersController : Controller
{
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;
    private readonly IOptions<JwtSettingsModel> _jwtSettings;

    public UsersController(IUsersService service, IMapper mapper, IOptions<JwtSettingsModel> jwtSettings)
    {
        _usersService = service;
        _mapper = mapper;
        _jwtSettings = jwtSettings;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegistrationModel model)
    {
        await _usersService.Register(_mapper.Map<User>(model), model.Password);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenModel>> Login(LoginModel model)
    {
        var token = await _usersService.Login(model.Login,
            model.Password,
            _jwtSettings.Value.Key,
            _jwtSettings.Value.Issuer);
        return Ok(new TokenModel { Token = token });
    }
}