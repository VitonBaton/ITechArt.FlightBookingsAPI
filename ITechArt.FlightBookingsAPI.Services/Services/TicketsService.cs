using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using ITechArt.FlightBookingsAPI.Services.Interfaces;

namespace ITechArt.FlightBookingsAPI.Services.Services;

public class TicketsService : ITicketsService
{
    private readonly ITicketsRepository _repository;

    public TicketsService(ITicketsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<IGrouping<Guid, Ticket>>> GetAllAsync(Guid userId)
    {
        return await _repository.GetAllAsync(userId);
    }
}