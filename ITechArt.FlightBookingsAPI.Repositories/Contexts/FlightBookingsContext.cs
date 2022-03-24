using ITechArt.FlightBookingsAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.FlightBookingsAPI.Infrastructure.Contexts;

public class FlightBookingsContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<TicketType> TicketTypes { get; set; } = null!;
    public DbSet<FlightTicketType> FlightTicketTypes { get; set; } = null!;

    public FlightBookingsContext(DbContextOptions<FlightBookingsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
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
        
        base.OnModelCreating(modelBuilder);
    }
}