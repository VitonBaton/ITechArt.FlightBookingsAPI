using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Domain.Models;

public class Flight
{
    public Guid Id { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public string? DeparturePoint { get; set; }
    [Required]
    public string? DestinationPoint { get; set; }
    public List<Ticket>? Tickets { get; set; }
    public List<FlightTicketType>? FlightTickets { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}