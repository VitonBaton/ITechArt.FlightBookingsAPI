using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;

public interface ITicketsRepository
{
    public Task<IEnumerable<IGrouping<Guid,Ticket>>> GetAllAsync(Guid userId);
    public Task<Ticket> GetByIdAsync(Guid ticketId);
    public Task<Ticket> CreateAsync(Ticket ticket);
    public Task UpdateAsync(Ticket ticket);
    public Task DeleteAsync(Guid ticketId);
}