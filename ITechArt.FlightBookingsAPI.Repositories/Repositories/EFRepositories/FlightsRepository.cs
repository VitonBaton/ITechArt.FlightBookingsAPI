using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Constants;
using ITechArt.FlightBookingsAPI.Infrastructure.Contexts;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Repositories.EFRepositories;

public class FlightsRepository : IFlightsRepository
{
    private readonly FlightBookingsContext _dbContext;

    public FlightsRepository(FlightBookingsContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        var result = await _dbContext.Flights.ToListAsync();
        return result;
    }

    public async Task<Flight> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Flights.AsNoTracking().FirstOrDefaultAsync(flight => flight.Id == id);
        if (result is null)
        {
            throw new KeyNotFoundException(MessageConstants.FlightNotFoundError);
        }
        return result;
    }

    public async Task<Flight> CreateAsync(Flight flight)
    {
        await _dbContext.Flights.AddAsync(flight);
        await _dbContext.SaveChangesAsync();
        return flight;
    }

    public async Task UpdateAsync(Flight flight)
    {
        _dbContext.Flights.Update(flight);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var result = await GetByIdAsync(id);
        _dbContext.Flights.Remove(result);
        await _dbContext.SaveChangesAsync();
    }
}