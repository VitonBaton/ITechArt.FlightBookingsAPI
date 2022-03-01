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

    public async Task UpdateAsync(Guid id, Flight flight)
    {
        var updatable = await _repository.GetByIdAsync(id);

        foreach (var property in flight.GetType().GetProperties())
        {
            var value = property.GetValue(flight);
            if (!(value is null || value.Equals(DateTime.MinValue) || value.Equals(Guid.Empty)))
            {
                property.SetValue(updatable,value);
            }
        }
        await _repository.UpdateAsync(updatable);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}