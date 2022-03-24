using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class FlightViewModel
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    [Required]
    public string DeparturePoint { get; set; } = null!;
    [Required]
    public string DestinationPoint { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}