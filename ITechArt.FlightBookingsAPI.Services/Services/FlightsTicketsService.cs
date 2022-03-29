using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Interfaces;
using ITechArt.FlightBookingsAPI.Services.Constants;
using ITechArt.FlightBookingsAPI.Services.Interfaces;

namespace ITechArt.FlightBookingsAPI.Services.Services;

public class FlightsTicketsService : IFlightsTicketsService
{
    private readonly IFlightsTicketsRepository _repository;

    public FlightsTicketsService(IFlightsTicketsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<FlightTicketType>> GetByFlightAsync(Guid flightId)
    {
        return await _repository.GetByFlightAsync(flightId);
    }

    public async Task AddAsync(FlightTicketType ftt)
    {
        await _repository.AddAsync(ftt);
    }

    public async Task UpdateAsync(FlightTicketType ftt)
    {
        var updatable = await _repository.GetByFlightAsync(ftt.FlightId);
        if (!updatable.Contains(ftt))
        {
            throw new KeyNotFoundException(MessageConstants.FlightTicketTypeNotFoundError);
        }
        
        await _repository.UpdateAsync(ftt);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}