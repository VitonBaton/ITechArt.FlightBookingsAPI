using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Infrastructure.DataSeeds;

public class TicketTypesSeeds
{
    private static readonly List<TicketType> TicketTypes = new()
    {
        new TicketType
        {
            Id = new Guid("00000000000000000000000000000001"),
            TypeName = "Economy"
        },
        new TicketType
        {
            Id = new Guid("00000000000000000000000000000002"),
            TypeName = "Business"
        },
        new TicketType
        {
            Id = new Guid("00000000000000000000000000000003"),
            TypeName = "Deluxe"
        }
    };
    
    public static IEnumerable<TicketType> GetTypes()
    {
        return TicketTypes;
    }
}