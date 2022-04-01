using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;

public interface ITicketsRepository
{
    public Task<IEnumerable<IGrouping<Guid,Ticket>>> GetAllAsync(Guid userId);
}