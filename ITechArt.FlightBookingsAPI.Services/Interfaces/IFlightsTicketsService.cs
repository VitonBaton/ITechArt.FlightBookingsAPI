using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Services.Interfaces;

public interface IFlightsTicketsService
{
    public Task<IEnumerable<FlightTicketType>> GetByFlightAsync(Guid flightId);
    public Task AddAsync(FlightTicketType ftt);
    public Task UpdateAsync(FlightTicketType ftt);
    public Task DeleteAsync(Guid id);
}