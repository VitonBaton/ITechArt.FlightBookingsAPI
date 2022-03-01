using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Services.Interfaces;

public interface IFlightsService
{
    public Task<IEnumerable<Flight>> GetAllAsync();
    public Task<Flight> GetByIdAsync(Guid id);
    public Task<Flight> CreateAsync(Flight flight);
    public Task UpdateAsync(Guid id, Flight flight);
    public Task DeleteAsync(Guid id);
}