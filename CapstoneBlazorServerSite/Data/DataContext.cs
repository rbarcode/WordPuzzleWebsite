
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CapstoneBlazorServerSite.Models;

namespace CapstoneBlazorServerSite.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CareerStats> CareerStats { get; set; }
        
        public DataContext(DbContextOptions options) : base(options) { }

    }
}
