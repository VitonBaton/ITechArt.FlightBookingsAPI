using System.ComponentModel.DataAnnotations;

namespace ITechArt.FlightBookingsAPI.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Phone { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    public List<Ticket>? Tickets { get; set; }
}