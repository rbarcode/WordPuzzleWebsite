
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
                    new CareerStats { PlayerId = "abc123", PlayerName = "Player A", HighScore = 375, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "def456", PlayerName = "Player B", HighScore = 112, CareerScore = 900, CareerNumberOfWords = 230, CareerPointsPerWord = 3.913, CareerMinutesPlayed = 175, CareerPointsPerMinute = 5.1429},
                    new CareerStats { PlayerId = "ghi789", PlayerName = "Player C", HighScore = 749, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "jkl098", PlayerName = "Player D", HighScore = 206, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "mno765", PlayerName = "Player E", HighScore = 571, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "pqr432", PlayerName = "Player F", HighScore = 445, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "stu123", PlayerName = "Player G", HighScore = 603, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "vwx456", PlayerName = "Player H", HighScore = 592, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "yza789", PlayerName = "Player I", HighScore = 93, CareerScore = 3300, CareerNumberOfWords = 450, CareerPointsPerWord = 7.33, CareerMinutesPlayed = 315, CareerPointsPerMinute = 10.4762},
                    new CareerStats { PlayerId = "bcd098", PlayerName = "Player J", HighScore = 832, CareerScore = 7425, CareerNumberOfWords = 775, CareerPointsPerWord = 9.581, CareerMinutesPlayed = 663.72, CareerPointsPerMinute = 11.1869}
                );
        }

    }
}
