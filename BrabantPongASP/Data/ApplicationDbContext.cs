using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrabantPongASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        /*Hieronder worden de DbSet's aangemaakt voor de verschillende modellen.*/
        public DbSet<Models.Speler> Spelers { get; set; }
        public DbSet<Models.Club> Clubs { get; set; }
        public DbSet<Models.Ranking> Rankings { get; set; }
        
        public DbSet<Models.Toernooi> Toernooien { get; set; }
        public DbSet<Models.ToernooiScheidsrechter> ToernooiScheidsrechters { get; set; }
        public DbSet<Models.Scheidsrechter> Scheidsrechters { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
