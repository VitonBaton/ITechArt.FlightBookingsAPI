using System.Security.Claims;
using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Constants;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using ITechArt.FlightBookingsAPI.Web.Constants;
using ITechArt.FlightBookingsAPI.Web.ViewModels;
using ITechArt.FlightBookingsAPI.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ITechArt.FlightBookingsAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : Controller
{
    private readonly IFlightsService _flightsService;
    private readonly IMapper _mapper;
    private Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    public FlightsController(IFlightsService service, IMapper mapper)
    {
        _flightsService = service;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = IdentityRoles.UserRole+"," + IdentityRoles.AdminRole)]
    public async Task<ActionResult<IEnumerable<FlightViewModel>>> GetAllFlights()
    {
        var result = await _flightsService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<FlightViewModel>>(result));
    }

    [HttpGet]
    [Route("{id:guid}")]
    [Authorize(Roles = IdentityRoles.UserRole+"," + IdentityRoles.AdminRole)]
    public async Task<ActionResult<FlightViewModel>> GetFlightById(Guid id)
    {
        var result = await _flightsService.GetByIdAsync(id);
        return Ok(_mapper.Map<FlightViewModel>(result));
    }

    [HttpPost]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult<FlightViewModel>> CreateFlight(FlightViewModel flight)
    {
        var result = await _flightsService.CreateAsync(_mapper.Map<Flight>(flight));
        return Ok(_mapper.Map<FlightViewModel>(result));
    }

    [HttpPatch]
    [Route("{id:guid}")]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult> UpdateFlight(Guid id, [FromBody] FlightViewModel flight)
    {
        await _flightsService.UpdateAsync(id, _mapper.Map<Flight>(flight));
        return Ok(MessageConstants.FlightUpdated);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult> DeleteFlight(Guid id)
    {
        await _flightsService.DeleteAsync(id);
        return Ok(MessageConstants.FlightDeleted);
    }
}