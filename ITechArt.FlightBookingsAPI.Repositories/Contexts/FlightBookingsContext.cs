using ITechArt.FlightBookingsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Contexts;

public class FlightBookingsContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<FlightTicketType> FlightTicketTypes { get; set; }

    public FlightBookingsContext(DbContextOptions<FlightBookingsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketType>()
            .HasIndex(tt => tt.TypeName)
            .IsUnique();

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.FlightTicketType)
            .WithMany(t => t.Tickets)
            .OnDelete(DeleteBehavior.NoAction);
    }
}