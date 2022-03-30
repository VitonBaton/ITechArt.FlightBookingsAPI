using System.Security.Claims;
using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Constants;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using ITechArt.FlightBookingsAPI.Web.Constants;
using ITechArt.FlightBookingsAPI.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITechArt.FlightBookingsAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : Controller
{
    private readonly IFlightsTicketsService _flightsTicketsService;
    private readonly IMapper _mapper;
    private Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    public TicketsController(IFlightsTicketsService service, IMapper mapper)
    {
        _flightsTicketsService = service;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("types")]
    [Authorize(Roles = IdentityRoles.UserRole+"," + IdentityRoles.AdminRole)]
    public async Task<ActionResult<IEnumerable<TicketTypeViewModel>>> GetAllTicketTypes()
    {
        var result = await _flightsTicketsService.GetAllTicketTypesAsync();
        return Ok(_mapper.Map<IEnumerable<TicketTypeViewModel>>(result));
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    [Authorize(Roles = IdentityRoles.UserRole+"," + IdentityRoles.AdminRole)]
    public async Task<ActionResult<IEnumerable<FlightTicketTypeViewModel>>> GetAllFlightTickets(Guid id)
    {
        var result = await _flightsTicketsService.GetByFlightAsync(id);
        return Ok(_mapper.Map<IEnumerable<FlightTicketTypeViewModel>>(result));
    }

    [HttpPost]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult<FlightViewModel>> AddTicketsForFlight([FromBody] FlightTicketTypeViewModel ftt)
    {
        await _flightsTicketsService.AddAsync(_mapper.Map<FlightTicketType>(ftt));
        return Ok(MessageConstants.FlightTicketAdded);
    }

    [HttpPut]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult> UpdateFlightTicket([FromBody] FlightTicketTypeViewModel ftt)
    {
        await _flightsTicketsService.UpdateAsync(_mapper.Map<FlightTicketType>(ftt));
        return Ok(MessageConstants.FlightTicketUpdated);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [Authorize(Roles = IdentityRoles.AdminRole)]
    public async Task<ActionResult> DeleteFlight(Guid id)
    {
        await _flightsTicketsService.DeleteAsync(id);
        return Ok(MessageConstants.FlightDeleted);
    }
}