using BrabantPongASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrabantPongASP.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public DbSet<Models.Speler> Spelers { get; set; }
        public DbSet<Models.Club> Clubs { get; set; }
        public DbSet<Models.Ranking> Rankings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
