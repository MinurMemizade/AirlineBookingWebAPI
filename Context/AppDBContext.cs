using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingWebApi.Context
{
    public class AppDBContext : IdentityDbContext<AppUser, Role, Guid>
    {
        public DbSet<City> Cities {  get; set; }
        public DbSet<FligthDate> Flights { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Country> Country { get; set; }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FligthDate>()
                .HasOne(f => f.FromLocation)
                .WithMany()
                .HasForeignKey(f => f.FromLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FligthDate>()
                .HasOne(f=>f.ToDestination)
                .WithMany()
                .HasForeignKey(f=>f.ToDestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t=>t.Passenger)
                .WithMany()
                .HasForeignKey(t=>t.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t=>t.ReturnFlight)
                .WithMany()
                .HasForeignKey(t=>t.ReturnFlightId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t => t.OutboundFlight)
                .WithMany()
                .HasForeignKey(t => t.OutboundFlightId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
