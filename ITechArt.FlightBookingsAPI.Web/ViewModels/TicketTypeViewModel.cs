using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class TicketTypeViewModel
{
    public Guid Id { get; set; }
    [Required]
    public string TypeName { get; set; } = null!;
}