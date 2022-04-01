using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class TicketViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid FlightId { get; set; }
    [Required]
    public string TicketTypeName { get; set; } = null!;
    [Required]
    public DateTime CreatedAt { get; set; }
}