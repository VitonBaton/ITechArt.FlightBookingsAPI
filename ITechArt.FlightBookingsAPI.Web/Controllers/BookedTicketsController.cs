using System.Security.Claims;
using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Constants;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Services.Interfaces;
using ITechArt.FlightBookingsAPI.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITechArt.FlightBookingsAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookedTicketsController : Controller
{
    private readonly ITicketsService _ticketsService;
    private readonly IMapper _mapper;
    private Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    public BookedTicketsController(ITicketsService service, IMapper mapper)
    {
        _ticketsService = service;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<TicketsWithSummaryViewModel>>> GetBookedTicketsWithSummary()
    {
        var result = await _ticketsService.GetAllAsync(UserId);
        return Ok(_mapper.Map<IEnumerable<TicketsWithSummaryViewModel>>(result));
    }
}