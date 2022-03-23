namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class FlightViewModel
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public string DeparturePoint { get; set; } = string.Empty;
    public string DestinationPoint { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}