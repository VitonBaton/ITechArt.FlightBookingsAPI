using ITechArt.FlightBookingsAPI.Domain.Errors;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using ITechArt.FlightBookingsAPI.Services.Constants;
using ITechArt.FlightBookingsAPI.Services.Interfaces;

namespace ITechArt.FlightBookingsAPI.Services.Services;

public class TicketsService : ITicketsService
{
    private readonly ITicketsRepository _repository;

    public TicketsService(ITicketsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<IGrouping<Guid, Ticket>>> GetAllAsync(Guid userId)
    {
        return await _repository.GetAllAsync(userId);
    }

    public async Task<Ticket> GetByIdAsync(Guid userId, Guid ticketId)
    {
        var ticket = await _repository.GetByIdAsync(ticketId);
        if (ticket.UserId != userId)
        {
            throw new ArgumentException(MessageConstants.TicketNotOwnedByUser);
        }

        return ticket;
    }

    public async Task<Ticket> CreateAsync(Guid userId, Ticket ticket)
    {
        ticket.UserId = userId;
        var result =await _repository.CreateAsync(ticket);
        return result;
    }

    public async Task UpdateAsync(Guid userId, Ticket ticket)
    {
        var updatable = await _repository.GetByIdAsync(ticket.Id);
        if (updatable.UserId != userId)
        {
            throw new ArgumentException(MessageConstants.TicketNotOwnedByUser);
        }

        ticket.UserId = userId;
        await _repository.UpdateAsync(ticket);
    }

    public async Task DeleteAsync(Guid userId, Guid ticketId)
    {
        var ticket = await _repository.GetByIdAsync(ticketId);
        if (ticket.UserId != userId)
        {
            throw new ArgumentException(MessageConstants.TicketNotOwnedByUser);
        }

        await _repository.DeleteAsync(ticketId);
    }
}