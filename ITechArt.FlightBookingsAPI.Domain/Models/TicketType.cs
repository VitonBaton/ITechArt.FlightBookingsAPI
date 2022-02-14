using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.FlightBookingsAPI.Domain.Models;

public class TicketType
{
    public Guid Id { get; set; }
    [Required]
    public string? TypeName { get; set; }
}