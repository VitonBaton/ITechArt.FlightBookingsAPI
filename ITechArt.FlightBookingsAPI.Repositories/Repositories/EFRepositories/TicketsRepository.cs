using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Constants;
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

    public async Task<Ticket> GetByIdAsync(Guid ticketId)
    {
        var result = await _dbContext.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(ticket => ticket.Id == ticketId);
        
        if (result is null)
        {
            throw new KeyNotFoundException(MessageConstants.TicketNotFoundError);
        }

        return result;
    }

    public async Task<Ticket> CreateAsync(Ticket ticket)
    {
        await _dbContext.Tickets.AddAsync(ticket);
        await _dbContext.SaveChangesAsync();
        return ticket;
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _dbContext.Update(ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid ticketId)
    {
        _dbContext.Tickets.Remove(await GetByIdAsync(ticketId));
        await _dbContext.SaveChangesAsync();
    }
}