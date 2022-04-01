namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class TicketsWithSummaryViewModel
{
    public Guid FlightId { get; set; }
    public IEnumerable<TicketViewModel> Tickets { get; set; } = null!;
}