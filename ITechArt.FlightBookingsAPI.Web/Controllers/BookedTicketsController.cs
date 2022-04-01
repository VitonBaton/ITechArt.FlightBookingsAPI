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
    
    [HttpGet]
    [Route("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<TicketViewModel>> GetBookedTicket(Guid id)
    {
        var result = await _ticketsService.GetByIdAsync(UserId, id);
        return Ok(_mapper.Map<TicketViewModel>(result));
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<TicketViewModel>> BookTicket([FromBody] TicketViewModel ticket)
    {
        var result = await _ticketsService.CreateAsync(UserId, _mapper.Map<Ticket>(ticket));
        return Ok(_mapper.Map<TicketViewModel>(result));
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> UpdateTicket([FromBody] TicketViewModel ticket)
    {
        await _ticketsService.UpdateAsync(UserId, _mapper.Map<Ticket>(ticket));
        return Ok(MessageConstants.BookedTicketUpdated);
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> DeleteTicket(Guid id)
    {
        await _ticketsService.DeleteAsync(UserId, id);
        return Ok(MessageConstants.BookedTicketDeleted);
    }
}