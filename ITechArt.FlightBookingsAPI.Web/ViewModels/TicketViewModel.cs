using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class TicketViewModel
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    [Required]
    public Guid FlightTicketTypeId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}