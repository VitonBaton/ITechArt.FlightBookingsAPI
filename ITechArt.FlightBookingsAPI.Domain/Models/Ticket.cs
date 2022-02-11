using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Domain.Models;

public class Ticket
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid FlightId { get; set; }
    public Flight? Flight { get; set; }
    public Guid? FlightTicketTypeId { get; set; }
    public FlightTicketType? FlightTicketType { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}