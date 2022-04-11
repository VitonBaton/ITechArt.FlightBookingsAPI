using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Services.Interfaces;

public interface ITicketsService
{
    public Task<IEnumerable<IGrouping<Guid,Ticket>>> GetAllAsync(Guid userId);
    public Task<Ticket> GetByIdAsync(Guid userId,Guid ticketId);
    public Task<Ticket> CreateAsync(Guid userId, Ticket ticket);
    public Task UpdateAsync(Guid userId,Ticket ticket);
    public Task DeleteAsync(Guid userId,Guid ticketId);   
    
}