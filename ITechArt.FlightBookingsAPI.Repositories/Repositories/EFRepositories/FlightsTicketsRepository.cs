using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Constants;
using ITechArt.FlightBookingsAPI.Infrastructure.Contexts;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Repositories.EFRepositories;

public class FlightsTicketsRepository : IFlightsTicketsRepository
{
    private readonly FlightBookingsContext _dbContext;

    public FlightsTicketsRepository(FlightBookingsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<FlightTicketType>> GetByFlightAsync(Guid flightId)
    {
        var result = await  _dbContext.FlightTicketTypes
            .Where(ftt => ftt.FlightId == flightId)
            .AsNoTracking()
            .ToListAsync();

        return result;
    }

    public async Task AddAsync(FlightTicketType ftt)
    {
        await _dbContext.FlightTicketTypes.AddAsync(ftt);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(FlightTicketType ftt)
    {
        _dbContext.FlightTicketTypes.Update(ftt);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var ftt = await _dbContext.FlightTicketTypes.FindAsync(id);

        if (ftt is null)
        {
            throw new KeyNotFoundException(MessageConstants.FlightTicketTypeNotFoundError);
        }
        
        _dbContext.FlightTicketTypes.Remove(ftt);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TicketType>> GetAllTicketTypesAsync()
    {
        return await _dbContext.TicketTypes.ToListAsync();
    }
}