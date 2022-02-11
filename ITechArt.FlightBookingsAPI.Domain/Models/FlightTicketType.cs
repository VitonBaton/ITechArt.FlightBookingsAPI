using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITechArt.FlightBookingsAPI.Domain.Models;

public class FlightTicketType
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Flight? Flight { get; set; }
    public Guid TicketTypeId { get; set; }
    public TicketType? TicketType { get; set; }
    [Column(TypeName = "decimal(5, 2)")]
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int TotalCount { get; set; }
}