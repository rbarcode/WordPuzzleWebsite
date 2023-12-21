
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CapstoneBlazorServerSite.Models;
using Microsoft.AspNetCore.Identity;

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
                    new CareerStats { PlayerId = "ghi789", PlayerName = "Player C", HighScore = 749, CareerScore = 5993, CareerNumberOfWords = 941, CareerPointsPerWord = 6.369, CareerMinutesPlayed = 1037.44, CareerPointsPerMinute = 5.7767},
                    new CareerStats { PlayerId = "jkl098", PlayerName = "Player D", HighScore = 206, CareerScore = 817, CareerNumberOfWords = 233, CareerPointsPerWord = 3.506, CareerMinutesPlayed = 401.889, CareerPointsPerMinute = 0.5798},
                    new CareerStats { PlayerId = "mno765", PlayerName = "Player E", HighScore = 571, CareerScore = 6912, CareerNumberOfWords = 827, CareerPointsPerWord = 8.358, CareerMinutesPlayed = 698.171, CareerPointsPerMinute = 9.9},
                    new CareerStats { PlayerId = "pqr432", PlayerName = "Player F", HighScore = 445, CareerScore = 5058, CareerNumberOfWords = 769, CareerPointsPerWord = 6.577, CareerMinutesPlayed = 506.474, CareerPointsPerMinute = 9.9867},
                    new CareerStats { PlayerId = "stu123", PlayerName = "Player G", HighScore = 603, CareerScore = 7749, CareerNumberOfWords = 1738, CareerPointsPerWord = 4.459, CareerMinutesPlayed = 714.627, CareerPointsPerMinute = 2.432},
                    new CareerStats { PlayerId = "vwx456", PlayerName = "Player H", HighScore = 592, CareerScore = 4165, CareerNumberOfWords = 642, CareerPointsPerWord = 6.488, CareerMinutesPlayed = 552.206, CareerPointsPerMinute = 7.542},
                    new CareerStats { PlayerId = "yza789", PlayerName = "Player I", HighScore = 93, CareerScore = 756, CareerNumberOfWords = 194, CareerPointsPerWord = 3.897, CareerMinutesPlayed = 112.983, CareerPointsPerMinute = 6.6913},
                    new CareerStats { PlayerId = "bcd098", PlayerName = "Player J", HighScore = 832, CareerScore = 7425, CareerNumberOfWords = 775, CareerPointsPerWord = 9.581, CareerMinutesPlayed = 663.72, CareerPointsPerMinute = 11.1869},
                    new CareerStats { PlayerId = "efg765", PlayerName = "Player K", HighScore = 158, CareerScore = 8868, CareerNumberOfWords = 2716, CareerPointsPerWord = 3.265, CareerMinutesPlayed = 1025.91, CareerPointsPerMinute = 8.644},
                    new CareerStats { PlayerId = "hij432", PlayerName = "AlphaOmega", HighScore = 313, CareerScore = 3199, CareerNumberOfWords = 419, CareerPointsPerWord = 7.635, CareerMinutesPlayed = 372, CareerPointsPerMinute = 8.599},
                    new CareerStats { PlayerId = "klm123", PlayerName = "Player L", HighScore = 71, CareerScore = 698, CareerNumberOfWords = 175, CareerPointsPerWord = 3.989, CareerMinutesPlayed = 100, CareerPointsPerMinute = 6.98},
                    new CareerStats { PlayerId = "nop456", PlayerName = "Player M", HighScore = 100, CareerScore = 800, CareerNumberOfWords = 250, CareerPointsPerWord = 3.2, CareerMinutesPlayed = 200, CareerPointsPerMinute = 4}
                );

            PasswordHasher<IdentityUser> hasher = new();

            builder.Entity<ApplicationUser>()
              .HasData(
                new ApplicationUser { Id = "hij432", UserName = "AlphaOmega", NormalizedUserName = "ALPHAOMEGA", Email = "ao@ao.com", NormalizedEmail = "AO@AO.COM", PasswordHash = hasher.HashPassword(null, "infinity") }
              );

            base.OnModelCreating(builder);
        }

    }
}
