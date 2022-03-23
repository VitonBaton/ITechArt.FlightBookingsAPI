using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;

public interface IFlightsRepository
{
    public Task<IEnumerable<Flight>> GetAllAsync();
    public Task<Flight> GetByIdAsync(Guid id);
    public Task<Flight> CreateAsync(Flight flight);
    public Task UpdateAsync(Flight flight);
    public Task DeleteAsync(Guid id);
}