using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ITechArt.FlightBookingsAPI.Domain.Models;

public class User : IdentityUser<Guid>
{
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    public List<Ticket>? Tickets { get; set; }
}