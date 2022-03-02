using System.Security.Claims;
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
    public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlights()
    {
        var result = await _flightsService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<Flight>> GetFlightById(Guid id)
    {
        var result = await _flightsService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Flight>> CreateFlight(Flight flight)
    {
        var result = await _flightsService.CreateAsync(flight);
        return Ok(result);
    }

    [HttpPatch]
    [Route("{id:guid}")]
    public async Task<ActionResult> UpdateFlight(Guid id, [FromBody] Flight flight)
    {
        await _flightsService.UpdateAsync(id, flight);
        return Ok("Flight updated successfully");
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteFlight(Guid id)
    {
        await _flightsService.DeleteAsync(id);
        return Ok("Flight deleted successfully");
    }
}