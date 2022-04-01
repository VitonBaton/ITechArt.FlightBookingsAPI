using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Contexts;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Repositories.EFRepositories;

public class TicketsRepository : ITicketsRepository
{
    private readonly FlightBookingsContext _dbContext;

    public TicketsRepository(FlightBookingsContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<IGrouping<Guid,Ticket>>> GetAllAsync(Guid userId)
    {
        
        var result = (await _dbContext.Tickets
            .Where(t => t.UserId == userId)
            .ToListAsync())
            .GroupBy(t => t.FlightId)
            .ToList();
        
        return result;
    }
}