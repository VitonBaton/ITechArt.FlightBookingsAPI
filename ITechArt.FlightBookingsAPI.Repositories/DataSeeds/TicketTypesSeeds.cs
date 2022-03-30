using ITechArt.FlightBookingsAPI.Domain.Models;

namespace ITechArt.FlightBookingsAPI.Infrastructure.DataSeeds;

public class TicketTypesSeeds
{
    private static readonly List<TicketType> TicketTypes = new()
    {
        new TicketType
        {
            Id = new Guid("be6efb48-2df0-495d-bfc0-77040e66ab8d"),
            TypeName = "Economy"
        },
        new TicketType
        {
            Id = new Guid("2a223348-e2ae-4a9d-9670-c2de1b909d38"),
            TypeName = "Business"
        },
        new TicketType
        {
            Id = new Guid("e5023336-e00d-4c2d-a095-3cf3d589d998"),
            TypeName = "Deluxe"
        }
    };
    
    public static IEnumerable<TicketType> GetTypes()
    {
        return TicketTypes;
    }
}