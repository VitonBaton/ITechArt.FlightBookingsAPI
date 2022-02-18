﻿using System.Security.Claims;
using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Constants;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using ITechArt.FlightBookingsAPI.Web.Models;
using ITechArt.FlightBookingsAPI.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ITechArt.FlightBookingsAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;
    private readonly IOptions<JwtSettingsModel> _jwtSettings;
    private Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    
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
    
    [HttpDelete]
    [Authorize(Roles = IdentityRoles.UserRole)]
    public async Task<ActionResult> DeleteAccount()
    {
        await _usersService.DeleteAccount(UserId);
        return Ok();
    }

    [HttpPatch]
    [Authorize(Roles = IdentityRoles.UserRole)]
    public async Task<ActionResult> UpdateAccount([FromBody] UpdateUserModel userModel)
    {
        await _usersService.UpdateAccount(UserId, _mapper.Map<User>(userModel));
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult<List<GetUserModel>>> GetAllUsers()
    {
        var result =await _usersService.GetAll();
        return Ok(_mapper.Map<List<GetUserModel>>(result));
    }
    
    [HttpDelete]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    [Route("{userId}")]
    public async Task<ActionResult> DeleteAccount(Guid userId)
    {
        await _usersService.DeleteAccount(userId);
        return Ok();
    }

    [HttpPatch]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    [Route("{userId}")]
    public async Task<ActionResult> UpdateAccount(Guid userId,[FromBody] UpdateUserModel userModel)
    {
        await _usersService.UpdateAccount(userId, _mapper.Map<User>(userModel));
        return Ok();
    }
}