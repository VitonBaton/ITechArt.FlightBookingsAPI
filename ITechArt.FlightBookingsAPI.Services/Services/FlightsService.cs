using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Contexts;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using ITechArt.FlightBookingsAPI.Services.Interfaces;

namespace ITechArt.FlightBookingsAPI.Services.Services;

public class FlightsService : IFlightsService
{
    private readonly IFlightsRepository _repository;

    public FlightsService(IFlightsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Flight> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Flight> CreateAsync(Flight flight)
    {
        flight.CreatedAt = DateTime.Now;
        return await _repository.CreateAsync(flight);
    }

    public async Task UpdateAsync(Flight flight)
    {
        var updatable = await _repository.GetByIdAsync(flight.Id);
        await _repository.UpdateAsync(flight);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}