using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITechArt.FlightBookingsAPI.Web.ViewModels;

public class FlightTicketTypeViewModel
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid TicketTypeId { get; set; }
    [Column(TypeName = "decimal(5, 2)")]
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int TotalCount { get; set; }
}