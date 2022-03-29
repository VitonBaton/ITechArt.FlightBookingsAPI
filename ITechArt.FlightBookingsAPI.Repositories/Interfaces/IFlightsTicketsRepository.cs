using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;

public interface IFlightsTicketsRepository
{
    public Task<IEnumerable<FlightTicketType>> GetByFlightAsync(Guid flightId);

    public Task AddAsync(FlightTicketType ftt);
    
    public Task UpdateAsync(FlightTicketType ftt);

    public Task DeleteAsync(Guid id);
}