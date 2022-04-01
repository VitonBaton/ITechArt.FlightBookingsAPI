using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Services.Interfaces;

public interface ITicketsService
{
    public Task<IEnumerable<IGrouping<Guid,Ticket>>> GetAllAsync(Guid userId);
}