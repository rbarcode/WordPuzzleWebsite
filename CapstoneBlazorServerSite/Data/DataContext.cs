
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CapstoneBlazorServerSite.Models;

namespace CapstoneBlazorServerSite.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CareerStats> CareerStats { get; set; }
        
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CareerStats>()
                .HasData(
                    new CareerStats { PlayerId = "abc123", PlayerName = "Player A", HighScore = 375, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762}
                );
        }

    }
}
