using BrabantPongASP.Models;

namespace BrabantPongASP.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            /*Ik voer de gemaakte seeders uit.*/
            SeedSpelers(context);
            SeedClubs(context);
            SeedRankings(context);
        }

        /*Dit is de SeedSpelers-methode die spelers in de database hoort te zetten.*/
        private static void SeedSpelers(ApplicationDbContext context)
        {
            if (!context.Spelers.Any())
            {
                var club = new Club { ClubNaam = "TTC Dilbeek" };
                context.Clubs.Add(club);
                context.SaveChanges();

                var ranking = new Ranking { RankingNaam = "C4" };
                context.Rankings.Add(ranking);
                context.SaveChanges();

                var speler = new Speler
                {
                    SpelerVoornaam = "Bram",
                    SpelerAchternaam = "Dekeyser",
                    ClubId = club.ClubId,
                    RankingId = ranking.RankingId
                };
                context.Spelers.Add(speler);
                context.SaveChanges();
            }
        }

        /*Dit is de SeedClubs-methode die spelers in de database hoort te zetten.*/
        private static void SeedClubs(ApplicationDbContext context)
        {
            if(!context.Clubs.Any())
            {
                var club = new Club { ClubNaam = "TTC Dilbeek" };
                context.Clubs.Add(club);
                context.SaveChanges();
            }
        }

        /*Dit is de SeedRankings-methode die spelers in de database hoort te zetten.*/
        private static void SeedRankings(ApplicationDbContext context)
        {
            if(!context.Rankings.Any())
            {
                var ranking = new Ranking { RankingNaam = "C4" };
                context.Rankings.Add(ranking);
                context.SaveChanges();
            }
        }
    }
}
